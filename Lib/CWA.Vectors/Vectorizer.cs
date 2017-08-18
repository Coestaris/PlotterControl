/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:


	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.


	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.Vectors \ Vectorizer.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;

namespace CWA.Vectors
{
    /// <summary>
    /// Класс предоставляет методы для векторизации изображения и получения из него эклемпляры класса Vect.
    /// </summary>
    public class Vectorizer
    {
        #region Private Fields
        /// <summary>
        /// Делегат ивента PrStatusChanged.
        /// </summary>
        /// <param name="a">Параметры изменения статуса векторизации.</param>
        public delegate void prStatusChanged(PrStausChangedParameters a);

        /// <summary>
        /// Событие изменения статуса векторизации.
        /// </summary>
        private prStatusChanged VectChanged;

        /// <summary>
        /// Определяет, будет ли выводится дебаг-информация в консоль.
        /// </summary>
        private bool _say;

        /// <summary>
        /// Количесвто потоков выполнения векторизации.
        /// </summary>
        private int _num;

        /// <summary>
        /// Форматная строка вывода сообщения при начале векторизации.
        /// </summary>
        private string _initSay = "Stream: {0}. ThreadState: {1}. Priority: {2}. Time -- {3}s";

        /// <summary>
        /// Форматная строка вывода сообщения при изменении статуса потока выполнения векторизации.
        /// </summary>
        private string _stateSay = "ID: {0}. Operation: {1}. Time -- {2}s";

        /// <summary>
        /// Текущий прогресс выполнения процесса векторизации.
        /// </summary>
        private int _numPr;

        /// <summary>
        /// Время затраченное на векторизацию.
        /// </summary>
        private double _cNum;

        /// <summary>
        /// Копия исходного изображения.
        /// </summary>
        private Bitmap _proceedBitmap;

        /// <summary>
        /// Словарь с информацией про окончания выполнения потоков.
        /// </summary>
        private Dictionary<int, bool> _endList;

        /// <summary>
        /// Словарь с информацией про прогресс выполнения потоков.
        /// </summary>
        private Dictionary<int, int> _proList;

        /// <summary>
        /// Словарь с "материалами" для потоков. Т. е. те изображения, над котороми будут работать потоки.
        /// </summary>
        private Dictionary<int, Bitmap> _imgMap;

        /// <summary>
        /// Словарь с результатами выполнения потоков.
        /// </summary>
        private Dictionary<Bitmap, VPointEx[][]> _imgVect;

        /// <summary>
        /// Результирующии векторные данные.
        /// </summary>
        private VPointEx[][] _rawData;

        /// <summary>
        /// Результирующий заголовок вектора.
        /// </summary>
        private VectHeader _header;

        /// <summary>
        /// Временная метка начала процесса.
        /// </summary>
        private DateTime _dt;

        /// <summary>
        /// Количество миллисекунд, которое прошло с момента векторизации.
        /// </summary>
        private int Milliseconds
        {
            get { return (int)(DateTime.Now - _dt).TotalMilliseconds; }
        }
        #endregion

        #region Public Fileds
        /// <summary>
        /// Срабатывает при изменении статуса процесса векторизации.
        /// </summary>
        public event prStatusChanged PrStatusChanged
        {
            add { VectChanged = (prStatusChanged)Delegate.Combine(VectChanged, value); }
            remove
            {
                VectChanged = (prStatusChanged)Delegate.Remove(VectChanged, value);
            }
        }
        
        /// <summary>
        /// Изображение над которым будут проводится операции.
        /// </summary>
        public Bitmap ImageToProceed { get; set; }
        #endregion

        #region Private Methods

        /// <summary>
        /// Вызывает ивент PrStatusChanged с параметром а.
        /// </summary>
        /// <param name="a">Параметр вызова события.</param>
        private void VectChangedSimulate(PrStausChangedParameters a)
        {
            VectChanged?.Invoke(a);
        }

        /// <summary>
        /// "Окружает" задданый двумерный массив нулями.
        /// </summary>
        /// <param name="b">Массив для "окружения".</param>
        private void Surround(ref int[][] b)
        {
            var tm = new int[0];
            for (int i = 0; i <= b[0].Length - 1; i++) Helper.InsertToArray(ref tm, 0);
            Helper.InsertToArray(ref b, tm);
            Helper.InsertToArray(ref b, tm);
            for (int i = b.Length - 2; i >= 1; i--) Helper.Swap(ref b[i], ref b[i - 1]);
            for (int i = 0; i <= b.Length - 1; i++)  { Helper.InsertToArray(ref b[i], 0); Helper.InsertToArray(ref b[i], 0); };
            for (int i = 0; i <= b.Length - 1; i++) for (int ii = b.Length - 2; ii >= 1; ii--) Helper.Swap(ref b[i][ii], ref b[i][ii - 1]); 
        }

        /// <summary>
        /// Определяет, есть ли в массиве, рядом с указанной точкой элемент со значением k.
        /// </summary>
        /// <param name="digmap">Массив для поиска.</param>
        /// <param name="x">Х точки массива.</param>
        /// <param name="y">Y точки массива.</param>
        /// <param name="k">Значение для поиска.</param>
        /// <returns>True если граничет, False если нет.</returns>
        private bool NearK(int[][] digmap, int x, int y, int k)
        {
            if (digmap[x + 1][y + 1] == k) return true;
            if (digmap[x + 1][y - 1] == k) return true;
            if (digmap[x - 1][y + 1] == k) return true;
            if (digmap[x - 1][y - 1] == k) return true;
            if (digmap[x + 1][y] == k) return true;
            if (digmap[x - 1][y] == k) return true;
            if (digmap[x][y + 1] == k) return true;
            if (digmap[x][y - 1] == k) return true;
            return false;
        }

        /// <summary>
        /// Находит растояние между двумя точками.
        /// </summary>
        /// <param name="ar1">Первая точка.</param>
        /// <param name="ar2">Вторая точка.</param>
        private double Distance(VPoint ar1, VPoint ar2)
        {
            return Math.Sqrt((ar1.X - ar2.X) * (ar1.X - ar2.X) + (ar1.Y - ar2.Y) * (ar1.Y - ar2.Y));
        }

        /// <summary>
        /// Сортировка контуров так, чтобы расстояние между ними было минимальное, и перо совершало найменшее количество перемещений.
        /// </summary>
        /// <param name="Arr"></param>
        private void CSort(ref VPointEx[][] Arr)
        {
            var res = new VPointEx[0][];
            var checked_ = new VPointEx[0];
            var first = Arr[0]; checked_ = first;
            var uncheckedmask = new bool[Arr.Length];
            for(int ii = 0; ii <= Arr.Length; ii++)
            {
                var mostshort = 99999.9;
                int num = 0;
                for(int i =0;i<=Arr.Length-1;i++) if(!uncheckedmask[i])
                {
                    var dist = Distance(checked_[checked_.Length - 1].BasePoint, Arr[i][0].BasePoint);
                    if (dist < mostshort) { mostshort = dist; num = i; }
                }
                checked_ = Arr[num];
                uncheckedmask[num] = true;
                Helper.InsertToArray(ref res, checked_);
            }
            Arr = res;
        }
        
        /// <summary>
        /// Сорирует точки в массиве так, чтобы они были последовательны и их возможно было напечатать.
        /// </summary>
        /// <param name="Arr">Массив для сортировки.</param>
        private void PointSort(ref VPoint[] Arr)
        {
            var res = new VPoint[0];
            VPoint checked_; ;
            var first = Arr[0]; checked_ = first;
            var uncheckedmask = new bool[Arr.Length];
            for (int ii = 0; ii <= Arr.Length; ii++)
            {
                var mostshort = 99999.9;
                int num = 0;
                for (int i = 0; i <= Arr.Length - 1; i++) if (!uncheckedmask[i])
                    {
                        var dist = Distance(checked_, Arr[i]);
                        if (dist < mostshort) { mostshort = dist; num = i; }
                    }
                checked_ = Arr[num];
                uncheckedmask[num] = true;
                Helper.InsertToArray(ref res, checked_);
            }
            Arr = res;
        }

        /// <summary>
        /// 2й по важности метод класса. Разбивает массив точек на контура, в зависимости от того, с какими областями\объектами они граничат. В связке с ImagePrData() фактически полностью векторизирует изображение.
        /// </summary>
        /// <param name="arr">Массив для выделения контуров</param>
        private VPointEx[][] SortPointArray(VPointEx[] arr)
        {
            VPointEx[][] result = new VPointEx[0][];
            while (arr.Length > 0)
            {
                var a = arr[0].BordWith;
                var tm = new VPointEx[0];
                Helper.InsertToArray(ref tm, arr[0]);
                Helper.DeleteFromArray(1, ref arr);
                var needtodelete = new int[0];
                for(int i =0; i<=arr.Length-1; i++) if(arr[i].BordWith == a)
                    {
                        Helper.InsertToArray(ref tm, arr[i]);
                        Helper.InsertToArray(ref needtodelete, i + 1);
                    }
                if(arr.Length !=0) if(needtodelete!=null)
                    {
                        Array.Sort(needtodelete);
                        for (int ii = needtodelete.Length - 1; ii >= 0; ii--)
                            Helper.DeleteFromArray(needtodelete[ii], ref arr);
                    }
                Helper.InsertToArray(ref result, tm);
            }
            return result;
        }

        /// <summary>
        /// Основной метод класса. Выделяет те самые массивы точек, которые методом SortPointArray() бьются на контура. Сортирует их и чистит от хлама. Возвращает и берет данные с соответсвущих словарей. Многопоточная операция.
        /// </summary>
        private void ImagePrData()
        {
            var contours = new VPointEx[0][];
            int mark = 0, prcounter = 0;
            int[][] whitemap = new int[0][];
            if (_say)
            {
                Console.WriteLine(string.Format(_initSay, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.ThreadState, Thread.CurrentThread.Priority, (Milliseconds / 1000)));
                Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Init", (Milliseconds / 1000)));
            }
            else
            {
                prcounter += 1;
                _proList[Thread.CurrentThread.ManagedThreadId] = prcounter;
            }
            var buffimgp = _imgMap[Thread.CurrentThread.ManagedThreadId];
            Color[][] buffimg = new Color[0][];
            Helper.ResizeArray(ref buffimg, buffimgp.Height, buffimgp.Width);
            for (int i = 0; i <= buffimgp.Width - 1; i++)
                for (int ii = 0; ii <= buffimgp.Height - 1; ii++)
                    buffimg[ii][i] = buffimgp.GetPixel(i, ii);
            var digmap = new int[0][];
            Helper.ResizeArray(ref digmap, buffimg.Length, buffimg[0].Length);
            for (int i = 0; i <= buffimg.Length - 2; i++)
                for (int ii = 0; ii <= buffimg[0].Length - 2; ii++)
                    if (buffimg[i][ii].R == 0 && buffimg[i][ii].G == 0 && buffimg[i][ii].B == 0) digmap[i][ii] = 1;
            Surround(ref digmap);
            Surround(ref digmap);
            whitemap = digmap;
            if (_say) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Searching For Areas", (Milliseconds / 1000)));
            else
            {
                prcounter += 1;
                _proList[Thread.CurrentThread.ManagedThreadId] = prcounter;
            }
            mark = 3;
            for (int i = 1; i <= buffimg.Length - 2; i++)
                for (int ii = 1; ii <= buffimg[0].Length - 2; ii++)
                {
                    if (whitemap[i][ii] == 0)
                    {
                        whitemap[i][ii] = mark;
                        while (true)
                        {
                            bool b = false;
                            for (int i2 = 1; i2 <= buffimg.Length - 2; i2++)
                                for (int ii2 = 1; ii2 <= buffimg[0].Length - 2; ii2++)
                                    if (whitemap[i2][ii2] == 0 && NearK(whitemap, i2, ii2, mark))
                                    {
                                        whitemap[i2][ii2] = mark;
                                        b = true;
                                    }
                            if (!b) break;
                        }
                        mark++;
                    }
                }
            if (_say) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Searching For Objects", (Milliseconds / 1000)));
            else
            {
                prcounter += 1;
                _proList[Thread.CurrentThread.ManagedThreadId] = prcounter;
            }
            var mask = digmap; var p = mark + 2;
            for (int i = 1; i <= buffimg.Length - 2; i++)
                for (int ii = 1; ii <= buffimg[0].Length - 2; ii++)
                    if(mask[i][ii]==1)
                    {
                        VPointEx[] tm = new VPointEx[0];
                        mask[i][ii] = p;
                        for(int d = 3; d<=mark-1; d++) if(NearK(whitemap, i ,ii ,d)) Helper.InsertToArray(ref tm, new VPointEx(i, ii, d, Color.Empty));
                        while(true)
                        {
                            bool b = false;
                            for (int i2 = 1; i2 <= buffimg.Length - 2; i2++) 
                                for (int ii2 = 1; ii2 <= buffimg[0].Length - 2; ii2++)
                                {
                                    if(mask[i2][ii2] == 1 && NearK(mask,i2,ii2,p))
                                    {
                                        mask[i2][ii2] = p;
                                        b = true;
                                        for (int d = 3; d <= mark - 1; d++)
                                            if (NearK(whitemap,i2,ii2,d))
                                            {
                                                Helper.InsertToArray(ref tm, new VPointEx(i2, ii2, d, Color.Empty));
                                                break;
                                            }
                                    }
                                }
                            if (!b) break;
                        }
                        p++;
                        var tmp = SortPointArray(tm);
                        Helper.ConcatArrays(ref contours,ref tmp);
                        tmp = null;
                        tm = null;
                    }
            if (_say) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Sorting Points", (Milliseconds / 1000)));
            else
            {
                prcounter += 1;
                _proList[Thread.CurrentThread.ManagedThreadId] = prcounter;
            }
            for(int ii=0; ii<=contours.Length-1; ii++)
            {
                VPoint[] aaa = new VPoint[0];
                for (int i = 0; i <= contours[ii].Length - 1; i++) Helper.InsertToArray(ref aaa, contours[ii][i].BasePoint);
                PointSort(ref aaa);
                for (int i = 0; i <= contours[ii].Length - 1; i++) contours[ii][i].BasePoint = aaa[i];
                aaa = null;
            }
            if (_say) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Sorting Contours", (Milliseconds / 1000)));
            else
            {
                prcounter += 1;
                _proList[Thread.CurrentThread.ManagedThreadId] = prcounter;
            }
            CSort(ref contours);
            _imgVect.Add(buffimgp, contours);
            _endList[Thread.CurrentThread.ManagedThreadId]= true;
            if (_say) Console.WriteLine("Stream Ended. ID: " + Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// Бьет изображение на части и запускает для кождого ImagePrData() на отдельных потоках. Ждет пока они завершаться.
        /// </summary>
        private void ImagePr()
        {
            var m = Milliseconds / 1000;
            if (_say)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("Vectorization Started");
                Console.WriteLine("     1. Preparing Image");
            }
            int N = _num;
            Bitmap Bmp = _proceedBitmap;
            int W = _proceedBitmap.Width / N;
            Bitmap[] bitmaps = new Bitmap[N];
            int i = 0, gli = 0, currbmp = 0;
            bitmaps[0] = new Bitmap(W, _proceedBitmap.Height, PixelFormat.Format24bppRgb);
            if (N != 1)
                while (i != Bmp.Width)
                {
                    i++; gli++;
                    if (i % W == 0 && i + currbmp * W != Bmp.Width && currbmp + 1 != bitmaps.Length)
                    {
                        currbmp += 1;
                        bitmaps[currbmp] = new Bitmap(W, _proceedBitmap.Height, PixelFormat.Format24bppRgb);
                        i = 0;
                    }
                    if (i > W - 1) break;
                    if (i + currbmp * W > Bmp.Width) break;
                    Color[] hpixels = new Color[Bmp.Height];
                    try
                    {
                        for (int ii = 0; ii <= Bmp.Height - 1; ii++) hpixels[ii] = Bmp.GetPixel(gli, ii);
                        for (int ii = 0; ii <= Bmp.Height - 1; ii++) bitmaps[currbmp].SetPixel(i, ii, hpixels[ii]);
                        hpixels = null;
                    }
                    catch { }
                } else { bitmaps[0] = Bmp; }
            Thread[] streams = new Thread[N];
            for (int ii = 0; ii <= N - 1; ii++)
            {
                streams[ii] = new Thread(ImagePrData);
                _proList.Add(streams[ii].ManagedThreadId, 0);
                _endList.Add(streams[ii].ManagedThreadId, false);
                _imgMap.Add(streams[ii].ManagedThreadId, bitmaps[ii]);
            }
            for (int ii = 0; ii <= N - 1; ii++) streams[ii].Start();
            int maxval = N * 5, lastval = 0;
            if (_say) Console.WriteLine("     2. Processing");
            while(true)
            {
                for (int ii = 0; ii <= N - 1; ii++) if (streams[ii].ThreadState == ThreadState.Running) _numPr += _proList[streams[ii].ManagedThreadId];
                if(lastval!=_numPr)
                {
                    if (_numPr > maxval) maxval = _numPr;
                    VectChanged(new PrStausChangedParameters(maxval, _numPr));
                    lastval = _numPr;
                }
                Thread.Sleep(500);
                _numPr = 0;
                bool f = true;
                for (int ii = 0; ii <= N - 1; ii++) 
                    if(!_endList.Values.ToArray()[ii])
                    {
                        f = false;
                        break;
                    }
                if (f) break;
            }
            for (int ii = 0; ii <= N - 1; ii++)
            {
                var tmVect = _imgVect[bitmaps[ii]];
                for (int a = 0; a <= tmVect.Length - 1; a++)
                    for (int b = 0; b <= tmVect[a].Length - 1; b++)
                        tmVect[a][b].BasePoint = new VPoint(tmVect[a][b].BasePoint.X, tmVect[a][b].BasePoint.Y + ii * W - ii, tmVect[a][b].BasePoint.Color);
                Helper.ConcatArrays(ref _rawData, ref tmVect);
                tmVect = null;
            }
            _endList = null;
            _proList = null;
            _imgMap = null;
            _imgVect = null;
            if (_say)
            {
                Console.WriteLine(string.Format("DONE in {0} second(s) or {1:0.##} minute(s)", (Milliseconds/1000), (Milliseconds/60000)));
                Console.WriteLine("=================================");
            }
            _cNum = Milliseconds;
        }

        /// <summary>
        /// Инициализирует эклемляр.
        /// </summary>
        private void Init()
        {
            _endList = new Dictionary<int, bool>();
            _proList = new Dictionary<int, int>();
            _imgMap = new Dictionary<int, Bitmap>();
            _imgVect = new Dictionary<Bitmap, VPointEx[][]>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Запускает процесс векторизации для изображения <see cref="Image"></see>.
        /// </summary>
        /// <param name="Image">Изображени, которое будет обробатыватся.</param>
        /// <param name="WriteDebugInfo">Параметр, который определяет, будет ли выводится дебаг-информация в консоль</param>
        /// <param name="StreamCount">Количество потоков выполнения операции.</param>
        /// <returns>Возвращает вектор.</returns>
        public Vector Proceed(Bitmap Image, bool WriteDebugInfo = false, int StreamCount = 1)
        {
            _say = WriteDebugInfo;
            _num = StreamCount;
            _proceedBitmap = Image;
            ImagePr();
            _header = new VectHeader();
            _header.CountOfCont = _rawData.Length;
            _header.Width = Image.Width;
            _header.Height = Image.Height;
            _header.VectType = VectType.Rastr;
            var l = new Vector();
            l.Header = _header;
            l.RawData = _rawData;
            return l;
        }
        
        /// <summary>
        /// Запускает процесс векторизации для изображения.
        /// </summary>
        /// <param name="WriteDebugInfo">Параметр, который определяет, будет ли выводится дебаг-информация в консоль.</param>
        /// <param name="StreamCount">Количество потоков выполнения операции.</param>
        /// <returns>Возвращает вектор.</returns>
        public Vector Proceed(bool WriteDebugInfo = false, int StreamCount = 1)
        {
            _dt = DateTime.Now;
            _say = WriteDebugInfo;
            _num = StreamCount;
            _proceedBitmap = ImageToProceed;
            ImagePr();
            _header = new VectHeader();
            _header.CountOfCont = _rawData.Length;
            _header.Width = ImageToProceed.Width;
            _header.Height = ImageToProceed.Height;
            _header.VectType = VectType.Rastr;
            var l = new Vector();
            l.Header = _header;
            l.RawData = _rawData;
            return l;
        }
        #endregion

        #region Ctors

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Vectorizer"/>.
        /// </summary>
        public Vectorizer()
        {
            Init();
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Vectorizer"/>, заранее задавая изображение для векторизации.
        /// </summary>
        /// <param name="Image">Изображение, которое может быть использовано методом Proceed().</param>
        public Vectorizer(Bitmap Image)
        {
            Init();
            ImageToProceed = Image;   
        }
        #endregion
    }
}
