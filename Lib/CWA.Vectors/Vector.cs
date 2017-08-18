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
* CWA.Vectors \ Vector.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;

namespace CWA.Vectors
{
    /// <summary>
    /// Векторное изображение. Предоставляет методы для работы с векторами.
    /// </summary>
    public class Vector : ICloneable
    {
        #region Private Fileds
        /// <summary>
        /// Рандомайзер для метода ToBitmap().
        /// </summary>
        private Random _rand = new Random();
        #endregion

        #region Private Methods
        /// <summary>
        /// Инициализирует экземлпяр.
        /// </summary>
        private void Init()
		{
            Header = new VectHeader();
            if (string.IsNullOrEmpty(Filename)) Filename = "";
        }

        /// <summary>
        /// Загружает вектор формата .PCV.
        /// </summary>
        /// <param name="filename">Имя файла для загрузки</param>
        private void LoadVectPCV(string filename)
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
            Header = head;
            RawData = contours;
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
            RawData = contours;
        }

        /// <summary>
        /// Сохраняет базовую информацию о векторе в формате .PCV.
        /// </summary>
        /// <param name="filename">Имя файла для загрузки.</param>
        /// <param name="RawData_">Вектор для сохранения.</param>
        [Obsolete]
        public void SavePCV(string filename, VPointEx[][] RawData_)
        {
            var t = new StreamWriter(File.OpenWrite(filename));
            t.Write("vect,");
            t.Write(Header.Width+",");
            t.Write(Header.Height + ",");
            t.Write(Header.VectType + ",");
            t.Write(RawData.Length + ",");
            t.Write(";");
            for (int i = 0; i <= RawData.Length - 1; i++)
            {
                for (int ii = 0; ii <= RawData[i].Length - 1; ii++) t.Write(string.Format("{0},{1}:", RawData[i][ii].BasePoint.X.ToString(CultureInfo.InvariantCulture), RawData[i][ii].BasePoint.Y.ToString(CultureInfo.InvariantCulture)));
                if(RawData.Length-1 != i) t.Write("?");
            }
            t.Write("end");
            t.Close();
        }

        #endregion

        #region Public Fields

        /// <summary>
        /// Заголовок вектора.
        /// </summary>
        public VectHeader Header { get; set; }
      
        /// <summary>
        /// Имя файла, с которого был загружен вектор.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Базовая информация о векторе.
        /// </summary>
        public VPointEx[][] RawData { get; set; }

        /// <summary>
        /// Информация о мульти векторе.
        /// </summary>
        public VPointEx[][][] RaswDataEX { get; set; }

        /// <summary>
        /// Количество точек вектора.
        /// </summary>
        public int Points
        {
            get
            {
                int count = 0;
                for (int i = 0; i <= RawData.Length - 1; i++)
                    count += RawData[i].Length;
                return count;
            }
        }

        /// <summary>
        /// Размер вектора класса <see cref="System.Drawing.Size"/>.
        /// </summary>
        public Size Size
        {
            get { return new Size((int)(Header.Width), (int)(Header.Height)); }
        }

        /// <summary>
        /// Размер вектора класса <see cref="System.Drawing.SizeF"/>.
        /// </summary>
        public SizeF SizeF
        {
            get { return new SizeF((float)Header.Width, (float)Header.Height); }
        }

        /// <summary>
        /// Количество контуров вектора.
        /// </summary>
        public int ContorurCount { get; internal set; }

        /// <summary>
        /// Разрешение ветктора в формате "{0}x{1}".
        /// </summary>
        public string Resolution
        {
            get { return Header.Width.ToString() + "x" + Header.Height.ToString(); }
        }

        /// <summary>
        /// Представление вектора в виде класса <see cref="GraphicsPath"/>. 
        /// </summary>
        public GraphicsPath GrPath
        {
            get
            {
                GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
                try { for (int i = 0; i <= RawData.Length - 1; i++) graphicsPath.AddPolygon(PointexToPoint(RawData[i])); }
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
        [Obsolete]
        public void SavePRRES(string name, string Ori = "Not used", string Resname = "Not used")
        {
            var text = new StreamWriter(File.OpenWrite(name));
            text.Write( "prres;");
            text.Write(Header.Width + ";");
            text.Write(Header.Height + ";");
            text.Write(Header.VectType);
            text.Write(Ori + ";");
            text.Write(0 + ";");
            text.Write(Resname + ";");
            text.Write(RawData.Length + ";");
            for (int i = 0; i <= RawData.Length - 1; i++) 
            {
                text.Write("$");
                text.Write(RawData[i].Length + "?");
                for (int ii = 0; ii <= RawData[i].Length - 1; ii++) text.Write("(" + RawData[i][ii].BasePoint.X + "," + RawData[i][ii].BasePoint.Y + ");");
                text.Write("#");
            }
            text.Close();
        }

        private void LoadVectOPCV(string FileName)
        {
            string DirectoryName = FileName.Split('.').Reverse().ToArray()[1] + '\\';

            ZipFile.ExtractToDirectory(FileName, DirectoryName);

            VectorIncludeFile Include = null;
            VectorFileInfo FileInfo = null;
            RawVector Vector = null;
            List<RawVector> VectorsEx = null;
            Dictionary<string, string> ExParams = null;
            XmlSerializer includeFormatter = new XmlSerializer(typeof(VectorIncludeFile));
            using (FileStream fs = new FileStream(DirectoryName + "includes.xml", FileMode.Open))
            {
                Include = (VectorIncludeFile)includeFormatter.Deserialize(fs);
            }
            foreach (var item in Include.Items)
            {
                switch (item.Type)
                {
                    case VectorFileType.FileInfo:
                        {
                            XmlSerializer fileInfoFormatter = new XmlSerializer(typeof(VectorFileInfo));
                            using (FileStream fs = new FileStream(DirectoryName + item.FileName, FileMode.Open))
                            {
                                FileInfo = (VectorFileInfo)fileInfoFormatter.Deserialize(fs);
                            }
                        }
                        break;
                    case VectorFileType.Vector:
                        {
                            if (Vector == null)
                                Vector = new RawVector(File.ReadAllBytes(DirectoryName + item.FileName));
                            else
                            {
                                if (VectorsEx == null)
                                    VectorsEx = new List<RawVector>();
                                VectorsEx.Add(new RawVector(File.ReadAllBytes(DirectoryName + item.FileName)));
                            }
                        }
                        break;
                    case VectorFileType.PenInfo:
                        break;
                    case VectorFileType.OtherData:
                        {
                            if (ExParams == null)
                                ExParams = new Dictionary<string, string>();
                            ExParams.Add(item.FileName.Split('|').First(), item.FileName.Split('|').Last());
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in Directory.GetFiles(DirectoryName))
                File.Delete(item);
            Directory.Delete(DirectoryName);

            if (Vector == null)
                throw new ArgumentNullException(nameof(Vector));
            if (FileInfo == null)
                throw new ArgumentNullException(nameof(Vector));
            var result = Vector.ToVector();
            result.Header = FileInfo.ToHeader();
            result.Header.CountOfCont = result.RawData.Length;
            if (VectorsEx != null)
                result.RaswDataEX = VectorsEx.Select(p => p.ToRawData()).ToArray();
            if (ExParams != null)
                result.Header.ExParams = ExParams;
            //////////////////////////////////////////Не забуть доделать это -_-
        }

        private void SaveOPCV(String FileName)
        {
            string DirectoryName = FileName.Split('.').Reverse().ToArray()[1] + '\\';
            Directory.CreateDirectory(DirectoryName);
            var Include = new VectorIncludeFile() { Items = new List<VectorIncludeFileItem>() };
            var fileInfo = new VectorFileInfo()
            {
                DisplayName = FileName,
                Height = (UInt16)Header.Height,
                VectType = Header.VectType,
                Width = (UInt16)Header.Width
            };
            Include.Items.Add(new VectorIncludeFileItem() { FileName = "fileInfo.xml", Type = VectorFileType.FileInfo });
            Include.Items.Add(new VectorIncludeFileItem() { FileName = "1.rawVect", Type = VectorFileType.Vector });
            int vectCounter = 2;
            if (RaswDataEX != null) foreach (var item in RaswDataEX)
                {
                    string locFileName = vectCounter++ + ".rawVect";
                    Include.Items.Add(new VectorIncludeFileItem() { FileName = locFileName, Type = VectorFileType.Vector });
                    using (FileStream fs = new FileStream(DirectoryName + locFileName, FileMode.OpenOrCreate))
                    {
                        var bytes = new RawVector(this, item).ToBytes();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            if (Header.ExParams != null) foreach (var item in Header.ExParams)
                    Include.Items.Add(new VectorIncludeFileItem() { FileName = item.Key + "|" + item.Value, Type = VectorFileType.OtherData });

            XmlSerializer fileInfoFormatter = new XmlSerializer(typeof(VectorFileInfo));
            using (FileStream fs = new FileStream(DirectoryName + "fileInfo.xml", FileMode.OpenOrCreate))
            {
                fileInfoFormatter.Serialize(fs, fileInfo);
            }
            using (FileStream fs = new FileStream(DirectoryName + "1.rawVect", FileMode.OpenOrCreate))
            {
                var bytes = new RawVector(this).ToBytes();
                fs.Write(bytes, 0, bytes.Length);
            }
            XmlSerializer includeFormatter = new XmlSerializer(typeof(VectorIncludeFile));
            using (FileStream fs = new FileStream(DirectoryName + "includes.xml", FileMode.OpenOrCreate))
            {
                includeFormatter.Serialize(fs, Include);
            }
            if (File.Exists(FileName))
                File.Delete(FileName);
            ZipFile.CreateFromDirectory(DirectoryName, FileName);
            foreach (var item in Directory.GetFiles(DirectoryName))
                File.Delete(item);
            Directory.Delete(DirectoryName);
        }

        /// <summary>
        /// Сохраняет вектор.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        /// <param name="ExParams">Дополнительный параметры сохранения (опционально).</param>
        public void Save(string FileName)
        {
           
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
            Bitmap bitmap = new Bitmap((int)(Header.Width), (int)(Header.Height));
            for (int x = 0; x <= RawData.Length-1; x++)
            {
                Color drcolor = Color.FromArgb(_rand.Next(50, 255), _rand.Next(50, 255), _rand.Next(50, 255));
                for (int y = 0; y <= RawData[x].Length-1; y++)
                    bitmap.SetPixel((int)RawData[x][y].BasePoint.Y, (int)RawData[x][y].BasePoint.X, drcolor);
            }
            return bitmap;
        }

        /// <summary>
        /// Рендер вектора. С заданными параметрами.
        /// </summary>
        /// <param name="BackColor">Цвет фона.</param>
        /// <param name="DrawColor">Цвет рисования.</param>
        public Bitmap ToBitmap(Color BackColor, Color DrawColor)
        {
            Bitmap bitmap = new Bitmap((int)(Header.Width), (int)(Header.Height));
            Rectangle rec = new Rectangle(0, 0, (int)(Header.Width), (int)(Header.Height));
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.FillRectangle(new SolidBrush(BackColor), rec);
            }
            for (int x = 0; x <= RawData.Length - 1; x++)
                for (int y = 0; y <= RawData[x].Length - 1; y++)
                    bitmap.SetPixel((int)RawData[x][y].BasePoint.Y, (int)RawData[x][y].BasePoint.X, DrawColor);
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
                return string.Format(fstring, Header.Width, Header.Height);
            }
            catch { return Resolution; }
        }

        /// <summary>
        /// Проверяет коректный ли файл вектора.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        public static bool IsCorrectVectFile(string filename)
        {
            Vector vect = new Vector();
            try
            {
                if (File.ReadLines(filename).First().StartsWith("prres"))  vect.LoadVectPCV(filename);
                else if (File.ReadLines(filename).First().StartsWith("vect") || File.ReadLines(filename).First().StartsWith("vectarch")) vect.LoadVectPrres(filename);
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Находит разницу двух точек и возвращает результаты типа <see cref="Int16"/>, как массив 4х байтов.
        /// </summary>
        /// <param name="pn1">Первая точка.</param>
        /// <param name="pn2">Вторая точка.</param>
        private byte[] DeltaPoints(VPointEx p1, VPointEx p2)
        {
            var dx = BitConverter.GetBytes((Int16)( - p1.BasePoint.X + p2.BasePoint.X));
            var dy = BitConverter.GetBytes((Int16)( - p1.BasePoint.Y + p2.BasePoint.Y));
            var bytes = new byte[4];
            Buffer.BlockCopy(dx, 0, bytes, 0, 2);
            Buffer.BlockCopy(dy, 0, bytes, 2, 2);
            return bytes;
        }

        /// <summary>
        /// Находит дистанцию между двумя точками.
        /// </summary>
        /// <param name="pn1">Первая точка.</param>
        /// <param name="pn2">Вторая точка.</param>
        internal static float Distance(VPoint pn1, VPoint pn2)
        {
            return (float)Math.Sqrt((pn2.X - pn1.X) * (pn2.X - pn1.X) + (pn2.Y - pn1.Y) * (pn2.Y - pn1.Y));
        }

        private readonly static byte[] ByteDownPattern = new byte[4] { 100, 100, 100, 100 };
        private readonly static byte[] ByteUpPattern = new byte[4] { 101, 101, 101, 101 };

        public Vector ClearThisVector(UInt32 DeleteThreshold)
        {
            var temp = RawData.ToList();
            for (int i = temp.Count-1; i >= 0; i--)
                if (temp[i].Length <= DeleteThreshold)
                    temp.RemoveAt(i);
            RawData = temp.ToArray();
            return this;
        }

        /// <summary>
        /// Преобразует вектор в бинарно-примитивный формат, для отправки на утсройство.
        /// </summary>
        /// <returns></returns>
        public byte[] ToBinnaryVector()
        {
            var bytes = new List<byte>();
            bytes.AddRange(DeltaPoints(new VPointEx(0, 0), RawData[0][0]));
            bytes.AddRange(ByteDownPattern);
            for (int i = 0; i < RawData.Length; i++) 
            {
                for (int ii = 0; ii < RawData[i].Length - 1; ii++)
                {
                    if (Distance(RawData[i][ii].BasePoint, RawData[i][ii + 1].BasePoint) >= 20)
                    {
                        if(RawData[i].Skip(ii).Count() <= 10)
                            break;
                        bytes.AddRange(ByteUpPattern);
                        bytes.AddRange(DeltaPoints(RawData[i][ii], RawData[i][ii + 1]));
                        bytes.AddRange(ByteDownPattern);
                        continue;
                    }
                    bytes.AddRange(DeltaPoints(RawData[i][ii], RawData[i][ii + 1]));
                }
                bytes.AddRange(ByteUpPattern);
                if (i != RawData.Length - 1)
                {
                    bytes.AddRange(DeltaPoints(RawData[i].Last(), RawData[i + 1].First()));
                    bytes.AddRange(ByteDownPattern);
                } else
                {
                    bytes.AddRange(DeltaPoints(RawData.Last().Last(), new VPointEx(0, 0)));
                }
            }
            return bytes.ToArray();
        }

        /// <summary>
        /// Рендерит изображение с заданными параметрами с помощию класса <see cref="GraphicsPath"/>.
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
        /// Рендерит изображение с заданными параметрами с помощию класса <see cref="GraphicsPath"/>.
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
            graphicsPath.AddPolygon(PointexToPoint(RawData[selected]));
            graphics.DrawPath(new Pen(selectedcol), graphicsPath);
            return bitmap;
        }

        /// <summary>
        /// Рендерит изображение с заданными параметрами с помощию класса <see cref="GraphicsPath"/>.
        /// </summary>
        /// <param name="c">Цвет фона.</param>
        /// <param name="pencol">Цфет линий.</param>
        /// <param name="gp">Информация о векторе в формате класса <see cref="GraphicsPath"/>..</param>
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
        public Vector()
        {
            Init();
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Vector"/>.
        /// </summary>
        /// <param name="filename">Файл, с которого будет загружен вектор.</param>
        public Vector(string filename)
        {
            Init();
            string ind =  File.ReadLines(filename).First();
            if (ind.StartsWith("prres")) LoadVectPrres(filename);
            else if (ind.StartsWith("vect") || ind.StartsWith("vectarch")) LoadVectPCV(filename);
            else LoadVectOPCV(filename);
            Filename = filename;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Vector"/>.
        /// </summary>
        /// <param name="size">Размер вектора.</param>
        public Vector(SizeF size)
        {
            Init();
            Header.Width= size.Width;
            Header.Height = size.Height;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Vector"/>.
        /// </summary>
        /// <param name="size">Размер вектора.</param>
        /// <param name="data">Данные о векторе.</param>
        public Vector(SizeF size, VPointEx[][] data)
        {
            Init();
            Header.Width = size.Width;
            Header.Height = size.Height;
            RawData = data;
        }
        #endregion

        #region Static And Other Methods
        /// <summary>
        /// Приводит экземпляр к типу <see cref="string"/>.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Vector: [Is Empty: {0}, Width: {1}, Heigth: {2}, Contours: {3}]", IsEmpty, Header.Width, Header.Height, RawData.Length);
        }

        /// <summary>
        /// Рендерит вектор с указанными параметрами, выделяя один из контуров.
        /// </summary>
        /// <param name="size">Размер вектора.</param>
        /// <param name="c">Цвет фона.</param>
        /// <param name="pencol">Цвет линий вектора.</param>
        /// <param name="selectedcol">Цвет выбранного.</param>
        /// <param name="selected">Индекс выбранного.</param>
        /// <param name="gp">Информация о векторе класса <see cref="GraphicsPath"/>.</param>
        /// <param name="arr">Информация о векторе.</param>
        public static Bitmap ToBitmapByGrPath(Size size, Color c, Color pencol, Color selectedcol, int selected, GraphicsPath gp, VPointEx[][] arr)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(c), rect);
            graphics.DrawPath(new Pen(pencol), gp);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddPolygon(Vector.PointexToPoint(arr[selected]));
            graphics.DrawPath(new Pen(selectedcol), graphicsPath);
            return bitmap;
        }

        /// <summary>
        /// Приводит массив <see cref="VPointEx"/> к массиву <see cref="PointF"/>.
        /// </summary>
        /// <param name="Arr">Массив для приведения.</param>
        public static PointF[] PointexToPoint(VPointEx[] Arr)
        {
            List<PointF> list = new List<PointF>();
            for (int i = 0; i <= Arr.Length - 1; i++)
                if (Arr[i].BasePoint != VPointEx.ZeroPoint.BasePoint) list.Add((PointF)VPoint.SwapCoordinates(Arr[i].BasePoint));
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
