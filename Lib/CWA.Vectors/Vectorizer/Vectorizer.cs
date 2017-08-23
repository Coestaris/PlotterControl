/*=================================\
* CWA.Vectors\Vectorizer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:32
* Last Edited: 23.08.2017 20:35:06
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
        private bool _outputDebugInfo;

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
        /// Вызывает ивент <see cref="PrStatusChanged"/> с параметром а.
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
        /// 2й по важности метод класса. Разбивает массив точек на контура, в зависимости от того, с какими областями\объектами они граничат. В связке с <see cref="ImagePrData"/> фактически полностью векторизирует изображение.
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
        /// Основной метод класса. Выделяет те самые массивы точек, которые методом <see cref="SortPointArray(VPointEx[])"/> бьются на контура. Сортирует их и чистит от хлама. Возвращает и берет данные с соответсвущих словарей. Многопоточная операция.
        /// </summary>
        private void ImagePrData()
        {
            // == ШАГ 1: ОБЪЯВЛЕНИЕ ЛОКАЛЬНЫХ ПЕРЕМЕННЫХ ==


            //Основной счетчик. Обозначает уникальный номер области или объекта.
            int AreaMark = 0;
            //Результирующий массив контуров.
            var Contours = new VPointEx[0][];
            //Изначальное биннарное представление изображения. Если пиксель равен (0,0,0), то digMap на этом индексе будет равен 1.
            var digMap = new int[0][];
            //Само изображение данного потока.
            var ProceedImage = _imgMap[Thread.CurrentThread.ManagedThreadId];
            //Массив, с обозначенными на нем областями.
            var WhiteMap = new int[0][];
            //Массив цветов изображения.
            Color[][] BufferImage = new Color[0][];
    

            // == ШАГ 2: ПОДГОТОВКА ==


            //Вывод информации о выполении новой операции.
            if (_outputDebugInfo)
            {
                Console.WriteLine(string.Format(_initSay, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.ThreadState, Thread.CurrentThread.Priority, (Milliseconds / 1000)));
                Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Init", (Milliseconds / 1000)));
            }
            _proList[Thread.CurrentThread.ManagedThreadId]++;

            //Задаем размер BufferImage.
            Helper.ResizeArray(ref BufferImage, ProceedImage.Height, ProceedImage.Width);
            //Задаем размер digMap.
            Helper.ResizeArray(ref digMap, BufferImage.Length, BufferImage[0].Length);
            
            //Заполняем BufferImage цветами из ProceedImage.
            for (int i = 0; i <= ProceedImage.Width - 1; i++)
                for (int ii = 0; ii <= ProceedImage.Height - 1; ii++)
                    BufferImage[ii][i] = ProceedImage.GetPixel(i, ii);

            //Заполняем digMap по вышеуказанному правилу.
            for (int i = 0; i <= BufferImage.Length - 2; i++)
                for (int ii = 0; ii <= BufferImage[0].Length - 2; ii++)
                    if (BufferImage[i][ii].R == 0 && BufferImage[i][ii].G == 0 && BufferImage[i][ii].B == 0) digMap[i][ii] = 1;

            //Добавляем digMap по 2 пустых ячейки с каждой стороны.
            Surround(ref digMap);
            Surround(ref digMap);

            //Создаем копию digMap.
            WhiteMap = digMap;


            // == ШАГ 3: ПОИСК ОБЛАСТЕЙ ==


            //Вывод информации о выполении новой операции.
            if (_outputDebugInfo) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Searching For Areas", (Milliseconds / 1000)));
            _proList[Thread.CurrentThread.ManagedThreadId]++;

            //Присваиваем 3, потому что 0,1 и 2 зарезервированы.
            AreaMark = 3;

            //Для каждого пикселя выполняем.
            for (int i = 1; i <= BufferImage.Length - 2; i++)
                for (int ii = 1; ii <= BufferImage[0].Length - 2; ii++)
                {
                    //Если, проверяеммый пиксель пустой (что есть условием существования области)
                    if (WhiteMap[i][ii] == 0)
                    {
                        //Обозначиваем этот пиксель уникальным для области номером.
                        WhiteMap[i][ii] = AreaMark;

                        //Следующая операция выполняется для присваивания всем пикселям данной области, одного и того же номера.
                        //Некий аналог рекурсивного метода поиска объектов.
                        while (true)
                        {
                            //Указывает на то, были ли произведены какие-либо изменения.
                            bool changedSomething = false;

                            //Для каждого пикселя выполняем.
                            for (int i2 = 1; i2 <= BufferImage.Length - 2; i2++)
                                for (int ii2 = 1; ii2 <= BufferImage[0].Length - 2; ii2++)
                                    //Если есть пиксель, рядом с пикселем, помеченным нашим текущем AreaMark, то...
                                    if (WhiteMap[i2][ii2] == 0 && NearK(WhiteMap, i2, ii2, AreaMark))
                                    {
                                        //...и этот пиксель помечаем, как AreaMark.
                                        WhiteMap[i2][ii2] = AreaMark;
                                        //Помечаем, что изменили что-то.
                                        changedSomething = true;
                                    }
                            if (!changedSomething) break;
                        }
                        AreaMark++;
                    }
                }


            // == ШАГ 4: ПОИСК ОБЪЕКТОВ ==

            //Вывод информации о выполении новой операции.
            if (_outputDebugInfo) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Searching For Objects", (Milliseconds / 1000)));
            _proList[Thread.CurrentThread.ManagedThreadId]++;


            //Создаем копию digMap.
            var MaskArray = digMap;

            //Для отделения областей от объектов, добавляем к счетчику еще 2.
            var ObjectMark = AreaMark + 2;

            //Для каждого пикселя выполняем.
            for (int i = 1; i <= BufferImage.Length - 2; i++)
                for (int ii = 1; ii <= BufferImage[0].Length - 2; ii++)
                    //Если, проверяеммый пиксель не пустой (что есть условием существования объекта)
                    if (MaskArray[i][ii]==1)
                    {
                        //tempPointArray - временный массив несортированых точек.
                        VPointEx[] tempPointArray = new VPointEx[0];

                        //Обозначиваем этот пиксель уникальным для объетка номером.
                        MaskArray[i][ii] = ObjectMark;

                        //Если, этот пиксель граничит с каким-то пикселем из области (т.е. его значение <= AreaMark)...
                        for (int d = 3; d <= AreaMark - 1; d++) if (NearK(WhiteMap, i, ii, d))
                                //..., то добавляем его в наш массив.
                                Helper.InsertToArray(ref tempPointArray, new VPointEx(i, ii, d, Color.Empty));

                        //Далее выполняется аналог предыдущей операции, с некоторым изменениям.
                        while(true)
                        {
                            //Указывает на то, были ли произведены какие-либо изменения.
                            bool changedSomething = false;

                            //Для каждого пикселя выполняем.
                            for (int i2 = 1; i2 <= BufferImage.Length - 2; i2++) 
                                for (int ii2 = 1; ii2 <= BufferImage[0].Length - 2; ii2++)
                                {
                                    //Если есть пиксель, рядом с пикселем, помеченным нашим текущем ObjectMark, то...
                                    if (MaskArray[i2][ii2] == 1 && NearK(MaskArray, i2, ii2, ObjectMark)) 
                                    {
                                        //...и этот пиксель помечаем, как ObjectMark.
                                        MaskArray[i2][ii2] = ObjectMark;
                                        //Помечаем, что изменили что-то.
                                        changedSomething = true;
                                        
                                        //В этом случаем, мы выполняем то же, что и с первым пекселем.
                                        //Если, этот пиксель граничит с каким-то пикселем из области (т.е. его значение <= AreaMark)...
                                        for (int d = 3; d <= AreaMark - 1; d++)
                                            if (NearK(WhiteMap, i2, ii2, d)) 
                                            {
                                                //..., то добавляем его в наш массив.
                                                Helper.InsertToArray(ref tempPointArray, new VPointEx(i2, ii2, d, Color.Empty));
                                                break;
                                            }
                                    }
                                }
                            if (!changedSomething) break;
                        }
                        ObjectMark++;

                        //Далее сортируем наш массив.
                        var tmp = SortPointArray(tempPointArray);
                        //Сливаем его с нашим Contours.
                        Helper.ConcatArrays(ref Contours, ref tmp);
                        tmp = null;
                        tempPointArray = null;
                    }


            // == ШАГ 5: ОБРАБОТКА РЕЗУЛЬТАТОВ ==


            // ШАГ 5.1: Сортировка точек.

            //Вывод информации о выполении новой операции.
            if (_outputDebugInfo) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Sorting Points", (Milliseconds / 1000)));
            _proList[Thread.CurrentThread.ManagedThreadId]++;

            //Для каждого контура...
            for(int ii=0; ii<=Contours.Length-1; ii++)
            {
                VPoint[] sortedArray = new VPoint[0];
                //Добавляем в новый массив необходимые точки.
                //Это необходимо из-за различия типов VPoint и VPointEx.
                for (int i = 0; i <= Contours[ii].Length - 1; i++) Helper.InsertToArray(ref sortedArray, Contours[ii][i].BasePoint);

                //Сортируем наш массив.
                PointSort(ref sortedArray);

                //Выполняем обратную операцию пресваивания.
                for (int i = 0; i <= Contours[ii].Length - 1; i++) Contours[ii][i].BasePoint = sortedArray[i];
                sortedArray = null;
            }

            // ШАГ 5.2: Сортировка контуров и сохранения результата.

            //Вывод информации о выполении новой операции.
            if (_outputDebugInfo) Console.WriteLine(string.Format(_stateSay, Thread.CurrentThread.ManagedThreadId, "Sorting Contours", (Milliseconds / 1000)));
            _proList[Thread.CurrentThread.ManagedThreadId]++;

            //Сортировка всех контуров.
            CSort(ref Contours);

            //Сохраняем результат.
            _imgVect.Add(ProceedImage, Contours);
            
            //Отмечаем что процесс завершенн.
            _endList[Thread.CurrentThread.ManagedThreadId] = true;

            //Вывод информации о завершении процесса.
            if (_outputDebugInfo) Console.WriteLine("Stream Ended. ID: " + Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// Бьет изображение на части и запускает для кождого <see cref="ImagePrData()"/> на отдельных потоках. Ждет пока они завершаться.
        /// </summary>
        private void ImagePr()
        {
            //Отмечается метка начала процесса.
            var startSeconds = Milliseconds / 1000;

            //Вывод информации о начале процесса.
            if (_outputDebugInfo)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("Vectorization Started");
                Console.WriteLine("     1. Preparing Image");
            }

            //Рабочее изображение.
            Bitmap Bmp = _proceedBitmap;

            //Ширина одной части изображения.
            int Width = _proceedBitmap.Width / _num;

            //Части изображения.
            Bitmap[] bitmaps = new Bitmap[_num];
            int i = 0, gli = 0, currbmp = 0;
            bitmaps[0] = new Bitmap(Width, _proceedBitmap.Height, PixelFormat.Format24bppRgb);
            
            //Процесс резделения изображения на _Num частей.
            if (_num != 1)
                while (i != Bmp.Width)
                {
                    i++; gli++;
                    if (i % Width == 0 && i + currbmp * Width != Bmp.Width && currbmp + 1 != bitmaps.Length)
                    {
                        currbmp += 1;
                        bitmaps[currbmp] = new Bitmap(Width, _proceedBitmap.Height, PixelFormat.Format24bppRgb);
                        i = 0;
                    }
                    if (i > Width - 1) break;
                    if (i + currbmp * Width > Bmp.Width) break;
                    Color[] hpixels = new Color[Bmp.Height];
                    try
                    {
                        for (int ii = 0; ii <= Bmp.Height - 1; ii++) hpixels[ii] = Bmp.GetPixel(gli, ii);
                        for (int ii = 0; ii <= Bmp.Height - 1; ii++) bitmaps[currbmp].SetPixel(i, ii, hpixels[ii]);
                        hpixels = null;
                    }
                    catch { }
                } else { bitmaps[0] = Bmp; }

            //Массив потоков выполнения.
            Thread[] streams = new Thread[_num];

            //Каждому потоку задается метод.
            //К его ID привязывается: статус выполнения, метка о том, закончил ли поток, изображения для этого потока.
            for (int ii = 0; ii <= _num - 1; ii++)
            {
                streams[ii] = new Thread(ImagePrData);
                _proList.Add(streams[ii].ManagedThreadId, 0);
                _endList.Add(streams[ii].ManagedThreadId, false);
                _imgMap.Add(streams[ii].ManagedThreadId, bitmaps[ii]);
            }

            //Каждый поток запускается.
            for (int ii = 0; ii <= _num - 1; ii++) streams[ii].Start();

            int MaxValue = _num * 5;
            int LastValue = 0;

            //Вывод информации о выполении новой операции.
            if (_outputDebugInfo) Console.WriteLine("     2. Processing");

            while (true)
            {
                //Собирает общий статус-каунт всех потоков.
                for (int ii = 0; ii <= _num - 1; ii++)
                    if (streams[ii].ThreadState == ThreadState.Running) _numPr += _proList[streams[ii].ManagedThreadId];
                //Если значение изменилось, то...
                if (LastValue != _numPr) 
                {
                    //... вызвать ивент изменения.
                    if (_numPr > MaxValue) MaxValue = _numPr;
                    VectChanged(new PrStausChangedParameters(MaxValue, _numPr));
                    LastValue = _numPr;
                }
                Thread.Sleep(500);
                _numPr = 0;

                //Если все потоки завершили свою работу, то...
                bool f = true;
                for (int ii = 0; ii <= _num - 1; ii++) 
                    if(!_endList.Values.ToArray()[ii])
                    {
                        f = false;
                        break;
                    }
                //... прервать цикл.
                if (f) break;
            }

            //Для всех частей.
            for (int ii = 0; ii <= _num - 1; ii++)
            {
                //Каждый результат склеивается с предыдущим, с небольшим смщением.
                var tmVect = _imgVect[bitmaps[ii]];
                for (int a = 0; a <= tmVect.Length - 1; a++)
                    for (int b = 0; b <= tmVect[a].Length - 1; b++)
                        tmVect[a][b].BasePoint = new VPoint(tmVect[a][b].BasePoint.X, tmVect[a][b].BasePoint.Y + ii * Width - ii, tmVect[a][b].BasePoint.Color);
                Helper.ConcatArrays(ref _rawData, ref tmVect);
                tmVect = null;
            }
            _endList = null;
            _proList = null;
            _imgMap = null;
            _imgVect = null;
            if (_outputDebugInfo)
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
            _outputDebugInfo = WriteDebugInfo;
            _num = StreamCount;
            _proceedBitmap = Image;
            ImagePr();
            _header = new VectHeader()
            {
                CountOfCont = _rawData.Length,
                Width = Image.Width,
                Height = Image.Height,
                VectType = VectType.Rastr
            };
            var v = new Vector()
            {
                Header = _header,
                RawData = _rawData
            };
            return v;
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
            _outputDebugInfo = WriteDebugInfo;
            _num = StreamCount;
            _proceedBitmap = ImageToProceed;
            ImagePr();
            _header = new VectHeader()
            {
                CountOfCont = _rawData.Length,
                Width = ImageToProceed.Width,
                Height = ImageToProceed.Height,
                VectType = VectType.Rastr
            };
            var v = new Vector()
            {
                Header = _header,
                RawData = _rawData
            };
            return v;
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
