/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

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
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

using Compresser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CWA.Vectors
{
    /// <summary>
    /// Векторное изображение. Предоставляет методы для работы с векторами.
    /// </summary>
    public class Vect : ICloneable
    {

        #region Private Fileds
        /// <summary>
        /// Рандомайзер для метода ToBitmap().
        /// </summary>
        private Random _rand = new Random();

        /// <summary>
        /// Приватный параметр. Заголовок вектора.
        /// </summary>
        private VectHeader _header;

        /// <summary>
        /// Приватный параметр. Имя файла, с которого был загружен вектор.
        /// </summary>
        private string _filename;

        /// <summary>
        /// Приватный параметр. Базовая информация о векторе.
        /// </summary>
        private VPointEx[][] _rawData;

        /// <summary>
        /// Приватный параметр. Информация о мульти векторе.
        /// </summary>
        private VPointEx[][][] _rawdDataEx;
        #endregion

        #region Private Methods
        /// <summary>
        /// Инициализирует экземлпяр.
        /// </summary>
        private void Init()
		{
            _header = new VectHeader();
            if (string.IsNullOrEmpty(_filename)) _filename = "";
        }

        /// <summary>
        /// Загружает вектор формата .CVF.
        /// </summary>
        /// <param name="filename">Имя файла для загрузки</param>
        private void LoadVectCvf(string filename)
        {
            VPointEx[][] contours = new VPointEx[0][];
            string s = File.ReadAllText(filename);
            if(s.StartsWith("vectarch")) Compresser.Compresser.DeCompress(filename, false);
            s = File.ReadAllText(filename);
            var data = s.Split(';');
            var head = new VectHeader();
            var header_ = data[0].Split(',');
            head.Width = float.Parse(header_[1], CultureInfo.InvariantCulture);
            head.Height = float.Parse(header_[2], CultureInfo.InvariantCulture);
            switch(header_[3].ToLower().Trim())
            {
                case ("rastr"): head.VectType = VectType.Rastr;
                    break;
                case ("func"):
                    head.VectType = VectType.Func;
                    break;
                case ("curve"):
                    head.VectType = VectType.Curve;
                    break;
                case ("svgvector"):
                    head.VectType = VectType.SvgVector;
                    break;
                default: throw new ArgumentException("Указан неверный тип вектора");
            }
            //try { head.CountOfCont = int.Parse(header_[4]); } catch { throw new ArgumentException("Указано неверное число контуров вектора"); }
            var p = data[1].Split('?');
            head.CountOfCont = p.Length;
            contours = new VPointEx[p.Length][];
            for (int i = 0; i <= p.Length - 1; i++)
            {
                var data1= p[i];
                var data2= data1.Split(':');
                var countofpoints= data2.Length;
                contours[i] = new VPointEx[countofpoints-1];
                for(int ii = 0; ii<=data2.Length-2; ii++)
                {
                    var Coordinates = data2[ii].Split(',');
                    var xs= Coordinates[0];
                    var ys= Coordinates[1];
                    contours[i][ii]= new VPointEx(float.Parse(xs, CultureInfo.InvariantCulture), float.Parse(ys, CultureInfo.InvariantCulture), 0, Color.Black);
                }
            }
            Helper.DeleteFromArray(contours.Length, ref contours);
            _header = head;
            _rawData = contours;
            Compresser.Compresser.Compress(filename, false, "vectarch");
        }

        /// <summary>
        /// Загружает вектор формата .PRRES.
        /// </summary>
        /// <param name="filename">Имя файла для загрузки.</param>
        private void LoadVectPrres(string filename)
        {
            VPointEx[][] contours;// = new VPointEx[0][];
            var s = File.ReadAllText(filename);
            var main = s.Split('$');
            var header = main[0].Split(';');
            VectHeader headerr = new VectHeader();
            if (header[0] == "prres")
            {
                headerr.Width = int.Parse(header[1]);
                headerr.Height = int.Parse(header[2]);
                headerr.CountOfCont = int.Parse(header[6]);
                headerr.VectType = VectType.Rastr; //TODO sdelat` normalnoe opredelenie tipa vectora
                contours = new VPointEx[headerr.CountOfCont][];
                for (int i = 0; i <= headerr.CountOfCont - 1; i++)
                {
                    var data1 = main[i + 1].Split('?');
                    var countofpoints = data1[0];
                    contours[i] = new VPointEx[int.Parse(countofpoints)];
                    var data2 = data1[1].Split(';');
                    for (int j = 0; j <= data2.Length - 2; j++)
                    {
                        var coordinates = data2[j].Split(',');
                        var xs = coordinates[0];
                        Helper.Delete(ref xs, 1, 1);
                        var ys = coordinates[1];
                        Helper.Delete(ref ys, ys.Length, 1);
                        contours[i][j] = new VPointEx(int.Parse(xs), int.Parse(ys), 0, Color.Black);
                    }
                }
            }
            else return;
            Header = headerr;
            _rawData = contours;
        }

        /// <summary>
        /// Сохраняет базовую информацию о векторе в формате .CVF.
        /// </summary>
        /// <param name="filename">Имя файла для загрузки.</param>
        /// <param name="_RawData_">Вектор для сохранения.</param>
        public void SaveData(string filename, VPointEx[][] _RawData_)
        {
            var t = new StreamWriter(File.OpenWrite(filename));
            t.Write("vect,");
            t.Write(Header.Width+",");
            t.Write(Header.Height + ",");
            t.Write(Header.VectType + ",");
            t.Write(RawData.Length + ",");
            t.Write(";");
            for (int i = 0; i <= _rawData.Length - 1; i++)
            {
                for (int ii = 0; ii <= _rawData[i].Length - 1; ii++) t.Write(string.Format("{0},{1}:", _rawData[i][ii].Pnt.X.ToString(CultureInfo.InvariantCulture), _rawData[i][ii].Pnt.Y.ToString(CultureInfo.InvariantCulture)));
                if(_rawData.Length-1 != i) t.Write("?");
            }
            t.Write("end");
            t.Close();
        }

        #endregion

        #region Public Fields
        /// <summary>
        /// Заголовок вектора.
        /// </summary>
        public VectHeader Header
        {
            get { return _header; }
            internal set { _header = value; }
        }

        /// <summary>
        /// Имя файла, с которого был загружен вектор.
        /// </summary>
        public string Filename
        {
            get { return _filename;  }
            set { _filename = value; }
        }

        /// <summary>
        /// Базовая информация о векторе.
        /// </summary>
        public VPointEx[][] RawData
        {
            get { return _rawData;  }
            set { _rawData = value; }
        }

        /// <summary>
        /// Информация о мульти векторе.
        /// </summary>
        public VPointEx[][][] RaswDataEX
        {
            get { return _rawdDataEx; }
            set { _rawdDataEx = value; }
        }

        /// <summary>
        /// Количество точек вектора.
        /// </summary>
        public int Points
        {
            get
            {
                int count = 0;
                for (int i = 0; i <= _rawData.Length - 1; i++)
                    count += _rawData[i].Length;
                return count;
            }
        }

        /// <summary>
        /// Размер вектора класса Size.
        /// </summary>
        public Size Size
        {
            get { return new Size((int)(_header.Width), (int)(_header.Height)); }
        }

        /// <summary>
        /// Размер вектора класса SizeF.
        /// </summary>
        public SizeF SizeF
        {
            get { return new SizeF((float)_header.Width, (float)_header.Height); }
        }

        /// <summary>
        /// Количество контуров вектора.
        /// </summary>
        public int ContorurCount
        {
            get { return _rawData.Length; }
        }

        /// <summary>
        /// Разрешение ветктора в формате "{0}x{1}".
        /// </summary>
        public string Resolution
        {
            get { return _header.Width.ToString() + "x" + _header.Height.ToString(); }
        }

        /// <summary>
        /// Представление вектора в виде класса GraphicsPath. 
        /// </summary>
        public GraphicsPath GrPath
        {
            get
            {
                GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
                try { for (int i = 0; i <= _rawData.Length - 1; i++) graphicsPath.AddPolygon(PointexToPoint(_rawData[i])); }
                catch { }
                return graphicsPath;
            }
        }

        /// <summary>
        /// Указывает на то, пустой ли вектор.
        /// </summary>
        public bool IsEmpty
        {
            get { return RawData == null || RawData.Length == 0; }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Сохраняет вектор в старом формате.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <param name="Ori">Имя оригинального изображения (оставленно для совместимости).</param>
        /// <param name="Resname">Имя промежуточного результата (оставленно для совместимости).</param>
        public void SaveOld(string name, string Ori = "Not used", string Resname = "Not used")
        {
            var text = new StreamWriter(File.OpenWrite(name));
            text.Write( "prres;");
            text.Write(_header.Width + ";");
            text.Write(_header.Height + ";");
            text.Write(_header.VectType);
            text.Write(Ori + ";");
            text.Write(0 + ";");
            text.Write(Resname + ";");
            text.Write(_rawData.Length + ";");
            for (int i = 0; i <= _rawData.Length - 1; i++) 
            {
                text.Write("$");
                text.Write(_rawData[i].Length + "?");
                for (int ii = 0; ii <= _rawData[i].Length - 1; ii++) text.Write("(" + _rawData[i][ii].Pnt.X + "," + _rawData[i][ii].Pnt.Y + ");");
                text.Write("#");
            }
            text.Close();
        }

        /// <summary>
        /// Сохраняет вектор.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <param name="ExParams">Дополнительный параметры сохранения (опционально).</param>
        public void Save(string name, Dictionary<string, string> ExParams = null)
        {
            SaveData(name, _rawData);
        } //TODO 

        /// <summary>
        /// Сортировка контуров вектора за ихним размером.
        /// </summary>
        public void SortContoursByLength()
        {
            RawData = RawData.ToList().OrderByDescending(p => p.Length).ToArray();
        }

        /// <summary>
        /// Рендер вектора.
        /// </summary>
        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap((int)(_header.Width), (int)(_header.Height));
            for (int x = 0; x <= _rawData.Length-1; x++)
            {
                Color drcolor = Color.FromArgb(_rand.Next(50, 255), _rand.Next(50, 255), _rand.Next(50, 255));
                for (int y = 0; y <= _rawData[x].Length-1; y++)
                    bitmap.SetPixel((int)_rawData[x][y].Pnt.Y, (int)_rawData[x][y].Pnt.X, drcolor);
            }
            return bitmap;
        }

        /// <summary>
        /// Рендер вектора. С заданными параметрами.
        /// </summary>
        /// <param name="backcolor">Цвет фона.</param>
        public Bitmap ToBitmap(Color backcolor)
        {
            Bitmap bitmap = new Bitmap((int)(_header.Width), (int)(_header.Height));
            Rectangle rec = new Rectangle(0, 0, (int)(_header.Width), (int)(_header.Height));
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.FillRectangle(new SolidBrush(backcolor), rec);
            }
            for (int x = 0; x <= _rawData.Length - 1; x++)
            {
                Color drcolor = Color.FromArgb(_rand.Next(50, 255), _rand.Next(50, 255), _rand.Next(50, 255));
                for (int y = 0; y <= _rawData[x].Length - 1; y++)
                    bitmap.SetPixel((int)_rawData[x][y].Pnt.Y, (int)_rawData[x][y].Pnt.X, drcolor);
            }
            return bitmap;
        }

        /// <summary>
        /// Рендер вектора. С заданными параметрами.
        /// </summary>
        /// <param name="backcolor">Цвет фона.</param>
        /// <param name="drcolor">Цвет рисования.</param>
        public Bitmap ToBitmap(Color backcolor, Color drcolor)
        {
            Bitmap bitmap = new Bitmap((int)(_header.Width), (int)(_header.Height));
            Rectangle rec = new Rectangle(0, 0, (int)(_header.Width), (int)(_header.Height));
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.FillRectangle(new SolidBrush(backcolor), rec);
            }
            for (int x = 0; x <= _rawData.Length - 1; x++)
                for (int y = 0; y <= _rawData[x].Length - 1; y++)
                    bitmap.SetPixel((int)_rawData[x][y].Pnt.Y, (int)_rawData[x][y].Pnt.X, drcolor);
            return bitmap;
        }

        /// <summary>
        /// Рендер вектора. С заданными параметрами.
        /// </summary>
        /// <param name="e">(добавленно для совместимости).</param>
        /// <param name="drcolor">Цвет рисования линий.</param>
        public Bitmap ToBitmap(int e, Color drcolor)
        {
            Bitmap bitmap = new Bitmap((int)(_header.Width), (int)(_header.Height));
            for (int x = 0; x <= _rawData.Length - 1; x++)
                for (int y = 0; y <= _rawData[x].Length - 1; y++)
                    bitmap.SetPixel((int)_rawData[x][y].Pnt.Y, (int)_rawData[x][y].Pnt.X, drcolor);
            return bitmap;
        }

        /// <summary>
        /// Форматирует разешение согласно заданому формату. Например "[{0}-{1}]" = [100-200].
        /// </summary>
        /// <param name="fstring">Строка формата.</param>
        public string GetResolutionByFormat(string fstring)
        {
            try
            {
                return string.Format(fstring, _header.Width, _header.Height);
            }
            catch { return Resolution; }
        }

        /// <summary>
        /// Проверяет коректный ли файл вектора.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        public static bool IsCorrectVectFile(string filename)
        {
            Vect vect = new Vect();
            try
            {
                if (File.ReadLines(filename).First().StartsWith("prres"))  vect.LoadVectCvf(filename);
                else if (File.ReadLines(filename).First().StartsWith("vect") || File.ReadLines(filename).First().StartsWith("vectarch")) vect.LoadVectPrres(filename);
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Рендерит изображение с заданными параметрами с помощию класса GraphicsPath.
        /// </summary>
        /// <param name="c">Цвет фона.</param>
        /// <param name="pencol">Цвет линий.</param>
        public Bitmap ToBitmapByGrPath(Color c, Color pencol)
        {
            Bitmap bitmap = new Bitmap(Size.Width, Size.Height);
            Rectangle rect = new Rectangle(0, 0, Size.Width, Size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(c), rect);
            graphics.DrawPath(new Pen(pencol), GrPath);
            return bitmap;
        }

        /// <summary>
        /// Рендерит изображение с заданными параметрами с помощию класса GraphicsPath.
        /// </summary>
        /// <param name="c">Цвет фона.</param>
        /// <param name="pencol">Цфет линий.</param>ram>
        /// <param name="selectedcol">Цвет выделения.</param>
        /// <param name="selected">Индекс выделенного контура.</param>
        public Bitmap ToBitmapByGrPath(Color c, Color pencol, Color selectedcol, int selected)
        {
            Bitmap bitmap = new Bitmap(Size.Width, Size.Height);
            Rectangle rect = new Rectangle(0, 0, Size.Width, Size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(c), rect);
            graphics.DrawPath(new Pen(pencol), GrPath);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddPolygon(PointexToPoint(_rawData[selected]));
            graphics.DrawPath(new Pen(selectedcol), graphicsPath);
            return bitmap;
        }

        /// <summary>
        /// Рендерит изображение с заданными параметрами с помощию класса GraphicsPath.
        /// </summary>
        /// <param name="c">Цвет фона.</param>
        /// <param name="pencol">Цфет линий.</param>
        /// <param name="gp">Информация о векторе в формате класса GraphicsPath.</param>
        public Bitmap ToBitmapByGrPath(Color c, Color pencol, GraphicsPath gp)
        {
            Bitmap bitmap = new Bitmap(Size.Width, Size.Height);
            Rectangle rect = new Rectangle(0, 0, Size.Width, Size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(c), rect);
            graphics.DrawPath(new Pen(pencol), gp);
            return bitmap;
        }
        #endregion

        #region Ctors
        
        /// <summary>
        /// Создает новый экземпляр класса.
        /// </summary>
        public Vect()
        {
            Init();
        }

        /// <summary>
        /// Создает новый экземпляр класса.
        /// </summary>
        /// <param name="filename">Файл, с которого будет загружен вектор.</param>
        public Vect(string filename)
        {
            Init();
            string ind =  File.ReadLines(filename).First();
            if (ind.StartsWith("prres")) LoadVectPrres(filename);
            else if (ind.StartsWith("vect") || ind.StartsWith("vectarch")) LoadVectCvf(filename);
            else throw new FileFormatException();
            Filename = filename;
        }

        /// <summary>
        /// Создает новый экземпляр класса.
        /// </summary>
        /// <param name="size">Размер вектора.</param>
        public Vect(SizeF size)
        {
            Init();
            _header.Width= size.Width;
            _header.Height = size.Height;
        }

        /// <summary>
        /// Создает новый экземпляр класса.
        /// </summary>
        /// <param name="size">Размер вектора.</param>
        /// <param name="data">Данные о векторе.</param>
        public Vect(SizeF size, VPointEx[][] data)
        {
            Init();
            _header.Width = size.Width;
            _header.Height = size.Height;
            _rawData = data;
        }
        #endregion

        #region Static And Other Methods
        /// <summary>
        /// Приводит экземпляр к типу String.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Vector: [Is Empty: {0}, Width: {1}, Heigth: {2}, Contours: {3}]", IsEmpty, _header.Width, _header.Height, _rawData.Length);
        }

        /// <summary>
        /// Рендерит вектор с указанными параметрами, выделяя один из контуров.
        /// </summary>
        /// <param name="size">Размер вектора.</param>
        /// <param name="c">Цвет фона.</param>
        /// <param name="pencol">Цвет линий вектора.</param>
        /// <param name="selectedcol">Цвет выбранного.</param>
        /// <param name="selected">Индекс выбранного.</param>
        /// <param name="gp">Информация о векторе класса GraphicsPath.</param>
        /// <param name="arr">Информация о векторе.</param>
        public static Bitmap ToBitmapByGrPath(Size size, Color c, Color pencol, Color selectedcol, int selected, GraphicsPath gp, VPointEx[][] arr)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(c), rect);
            graphics.DrawPath(new Pen(pencol), gp);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddPolygon(Vect.PointexToPoint(arr[selected]));
            graphics.DrawPath(new Pen(selectedcol), graphicsPath);
            return bitmap;
        }

        /// <summary>
        /// Приводит массив VPointEx к массиву PointF.
        /// </summary>
        /// <param name="Arr">Массив для приведения.</param>
        public static PointF[] PointexToPoint(VPointEx[] Arr)
        {
            List<PointF> list = new List<PointF>();
            for (int i = 0; i <= Arr.Length - 1; i++)
                if (Arr[i].Pnt != VPointEx.ZeroPoint.Pnt) list.Add((PointF)VPoint.SwapCoordinates(Arr[i].Pnt));
            return list.ToArray<PointF>();
        }

        /// <summary>
        /// Клонирует экземпляр класса.
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion
    }
}
