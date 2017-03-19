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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Векторный документ - контейнер объектов, который Вы в следствии сможете превратить в вектор.
    /// Полезен, когда, например, вы хотите добавить на ваш вектор надпись или другой вектор.
    /// </summary>
    public class Document
    {
        public DocumentBorder Border { get; internal set; }

        /// <summary>
        /// Визуальный параметр рендера. Перо отрисовки границы документа.
        /// </summary>
        public Pen BorderPen { get; internal set; }

        /// <summary>
        /// Версия программы, в которой был создан документ.
        /// </summary>
        public Version CreatedVersion { get; internal set; }

        /// <summary>
        /// Описание документа.
        /// </summary>
        public string FileDescr { get; internal set; }

        /// <summary>
        /// Полное имя документа.
        /// Например, если Name = "tableofvals", то FileName предположительно должен быть равен "Table of Values of Temperature.". 
        /// </summary>
        public string FileName { get; internal set; }

        /// <summary>
        /// Имя автора документа.
        /// </summary>
        public string FileAutor { get; internal set; }

        /// <summary>
        /// Список объектов документа.
        /// </summary>
        public List<DocumentItem> Items { get; internal set; }

        /// <summary>
        /// Имя документа. 
        /// Например, если Name = "tableofvals", то FileName предположительно должен быть равен "Table of Values of Temperature.". 
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Размер документа.
        /// </summary>
        public SizeF Size { get; internal set; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Document"/>.
        /// </summary>
        /// <param name="size">Размер документа.</param>
        public Document(SizeF size)
        {
            Size = size;
            Items = new List<DocumentItem>();
            Border = new DocumentBorder();
            FileName = "AwesomeFile";
            FileDescr = "ItsTrulyAwesomeFile";
            FileAutor = "AwesomeMe";
            CreatedVersion = Version.Parse(Application.ProductVersion);
            BorderPen = Pens.Black;
        }

        /// <summary>
        ///  Добавить новый объект в документ.
        /// </summary>
        /// <param name="i">Объект для добавления.</param>
        /// <param name="name">Новое имя объекта (перезапишется в любом случае).</param>
        public void AddItem(DocumentItem i, string name)
        {
            i.DispColor = Color.Black;
            i.Name = name;
            Items.Add(i);
        }

        /// <summary>
        /// Сохранить документ в файл с разширением .vdoc.
        /// </summary>
        /// <param name="filename">Имя файла для сохранения.</param>
        public void Save(string filename)
        {
            filename = filename.Split('.')[0];
            Directory.CreateDirectory(filename);
            var datacounter = 0;
            var textWritter = new XmlTextWriter(filename + "\\" + new DirectoryInfo(filename).Name + ".xml",
                Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("root");
            textWritter.WriteEndElement();
            textWritter.Close();
            var document = new XmlDocument();
            document.Load(filename + "\\" + new DirectoryInfo(filename).Name + ".xml");
            XmlNode element = document.CreateElement("document");
            document.DocumentElement.AppendChild(element);
            var name = document.CreateAttribute("name");
            var sizex = document.CreateAttribute("sizex");
            var sizey = document.CreateAttribute("sizey");
            name.Value = Name;
            sizex.Value = Size.Width.ToString(CultureInfo.InvariantCulture);
            sizey.Value = Size.Height.ToString(CultureInfo.InvariantCulture);
            element.Attributes.Append(name);
            element.Attributes.Append(sizex);
            element.Attributes.Append(sizey);
            XmlNode element1 = document.CreateElement("settings");
            XmlNode bord = document.CreateElement("border");
            XmlNode vers = document.CreateElement("version");
            var mav = document.CreateAttribute("MajorVersion");
            var miv = document.CreateAttribute("MinorVersion");
            var bn = document.CreateAttribute("BuildNumber");
            var rev = document.CreateAttribute("Revision");
            mav.Value = CreatedVersion.Major.ToString();
            miv.Value = CreatedVersion.Minor.ToString();
            bn.Value = CreatedVersion.Build.ToString();
            rev.Value = CreatedVersion.Revision.ToString();
            vers.Attributes.Append(mav);
            vers.Attributes.Append(miv);
            vers.Attributes.Append(bn);
            vers.Attributes.Append(rev);
            document.DocumentElement.AppendChild(element1);
            var bord_style = document.CreateAttribute("style");
            var bord_offset = document.CreateAttribute("offset");
            var bord_use = document.CreateAttribute("use");
            bord_style.Value = Border.Style.ToString();
            bord_offset.Value = Border.Offset.ToString(CultureInfo.InvariantCulture);
            bord_use.Value = Border.Use.ToString();
            ;
            bord.Attributes.Append(bord_style);
            bord.Attributes.Append(bord_offset);
            bord.Attributes.Append(bord_use);
            element1.AppendChild(bord);
            XmlNode fi = document.CreateElement("fileinfo");
            var fi_name = document.CreateAttribute("finame");
            var fi_descr = document.CreateAttribute("fidescr");
            var fi_autor = document.CreateAttribute("autor");
            fi_name.Value = FileName;
            fi_descr.Value = FileDescr;
            fi_autor.Value = FileAutor;
            fi.Attributes.Append(fi_name);
            fi.Attributes.Append(fi_descr);
            fi.Attributes.Append(fi_autor);
            element1.AppendChild(fi);
            element1.AppendChild(vers);
            foreach (var a in Items)
            {
                XmlNode el = document.CreateElement("item");
                element.AppendChild(el);
                var type = document.CreateAttribute("type");
                var dispcolor = document.CreateAttribute("dispcolor");
                var neme = document.CreateAttribute("Name");
                var PositionX = document.CreateAttribute("PositionX");
                var PositionY = document.CreateAttribute("PositionY");
                var SizeW = document.CreateAttribute("SizeW");
                var SizeH = document.CreateAttribute("SizeH");
                var Angle = document.CreateAttribute("Angle");
                var usecdispcolor = document.CreateAttribute("usecdispcolor");
                type.Value = a.Type.ToString();
                dispcolor.Value = "(" + a.DispColor.R + "," + a.DispColor.G + "," + a.DispColor.B + ")";
                neme.Value = a.Name;
                PositionX.Value = a.Position.X.ToString(CultureInfo.InvariantCulture);
                PositionY.Value = a.Position.Y.ToString(CultureInfo.InvariantCulture);
                SizeW.Value = a.Size.Width.ToString(CultureInfo.InvariantCulture);
                SizeH.Value = a.Size.Height.ToString(CultureInfo.InvariantCulture);
                Angle.Value = a.Angle.ToString(CultureInfo.InvariantCulture);
                usecdispcolor.Value = a.UseDispColor.ToString();
                el.Attributes.Append(type);
                el.Attributes.Append(dispcolor);
                el.Attributes.Append(neme);
                el.Attributes.Append(PositionX);
                el.Attributes.Append(PositionY);
                el.Attributes.Append(SizeW);
                el.Attributes.Append(SizeH);
                el.Attributes.Append(usecdispcolor);
                el.Attributes.Append(Angle);
                if (a.GetType() == typeof(DocumentText))
                {
                    var tmp = (DocumentText) a;
                    XmlNode sb_text = document.CreateElement("text");
                    XmlNode sb_ff = document.CreateElement("FontFamily");
                    XmlNode sb_fs = document.CreateElement("FontStyle");
                    XmlNode sb_fsi = document.CreateElement("FontSize");
                    sb_fsi.InnerText = tmp.Font.Size.ToString(CultureInfo.InvariantCulture);
                    sb_fs.InnerText = tmp.Font.Style.ToString();
                    sb_ff.InnerText = tmp.Font.FontFamily.Name;
                    sb_text.InnerText = tmp.Caption;
                    el.AppendChild(sb_text);
                    el.AppendChild(sb_ff);
                    el.AppendChild(sb_fs);
                    el.AppendChild(sb_fsi);
                }
                else if (a.GetType() == typeof(DocumentData))
                {
                    var d = (a as DocumentData).BaseData;
                    XmlNode ori = document.CreateElement("OriVectFilename");
                    XmlNode use = document.CreateElement("UsedVectFilename");
                    ori.InnerText = d.Filename.Replace('\\', '|');
                    use.InnerText = "v" + datacounter;
                    el.AppendChild(ori);
                    el.AppendChild(use);
                    d.Save(filename + "\\" + "v" + datacounter++);
                }
            }
            document.Save(filename + "\\" + new DirectoryInfo(filename).Name + ".xml");
            try { File.Delete(filename + ".vdoc");}
            catch { //ignored 
            }
            ZipFile.CreateFromDirectory(filename, filename + ".vdoc");
            foreach (var a in Directory.GetFiles(filename))
                File.Delete(a);
            Directory.Delete(filename);
        }

        /// <summary>
        /// Загружает документ с файла с разширением .vdoc.
        /// </summary>
        /// <param name="filename">Имя файла, с которого будет грузится документ.</param>
        /// <returns>Экземпляр класса Document, загруженный с файла.</returns>
        public static Document Load(string filename)
        {
            try
            {
                filename = filename.Split('.')[0];
                try
                {
                    Directory.CreateDirectory(filename);
                    ZipFile.ExtractToDirectory(filename + ".vdoc", filename);
                }
                catch
                {
                    try
                    {
                        foreach (var a in Directory.GetFiles(filename)) File.Delete(a);
                        Directory.Delete(filename);
                        ZipFile.ExtractToDirectory(filename + ".vdoc", filename);
                    }
                    catch
                    {
                        throw new FileLoadException("Can`t load file", filename);
                    }
                }
                var document = new XmlDocument();
                var s = filename + "\\" + new DirectoryInfo(filename).Name;
                document.Load(s + ".xml");
                var Sizew = int.Parse(document.ChildNodes[1].ChildNodes[0].Attributes[1].Value);
                var Sizeh = int.Parse(document.ChildNodes[1].ChildNodes[0].Attributes[2].Value);
                var neme = document.ChildNodes[1].ChildNodes[0].Attributes[0].Value;
                var result = new Document(new SizeF(Sizew, Sizeh));
                var bord_style =
                    (DocumentBorderStyle)
                    Enum.Parse(typeof(DocumentBorderStyle),
                        document.ChildNodes[1].ChildNodes[1].ChildNodes[0].Attributes[0].Value);
                var bord_offset = float.Parse(document.ChildNodes[1].ChildNodes[1].ChildNodes[0].Attributes[1].Value, CultureInfo.InvariantCulture);
                var bord_use = bool.Parse(document.ChildNodes[1].ChildNodes[1].ChildNodes[0].Attributes[2].Value);
                result.Border = new DocumentBorder(bord_offset, bord_style, bord_use);
                var fn = document.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes[0].Value;
                var fd = document.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes[1].Value;
                var fa = document.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes[2].Value;
                var v1 = document.ChildNodes[1].ChildNodes[1].ChildNodes[2].Attributes[0].Value;
                var v2 = document.ChildNodes[1].ChildNodes[1].ChildNodes[2].Attributes[1].Value;
                var v3 = document.ChildNodes[1].ChildNodes[1].ChildNodes[2].Attributes[2].Value;
                var v4 = document.ChildNodes[1].ChildNodes[1].ChildNodes[2].Attributes[3].Value;
                result.CreatedVersion = new Version(int.Parse(v1), int.Parse(v2), int.Parse(v3), int.Parse(v4));
                result.FileAutor = fa;
                result.FileDescr = fd;
                result.FileName = fn;
                result.Name = neme;
                foreach (XmlNode node in document.ChildNodes[1].ChildNodes[0].ChildNodes)
                {
                    var colmod = node.Attributes[1].Value.Remove(0, 1);
                    colmod = colmod.Remove(colmod.Length - 1, 1);
                    var c = Color.FromArgb(int.Parse(colmod.Split(',')[0]), int.Parse(colmod.Split(',')[1]),
                        int.Parse(colmod.Split(',')[2]));
                    var type = (DocumentItemType) Enum.Parse(typeof(DocumentItemType), node.Attributes[0].Value);
                    var name = node.Attributes[2].Value;
                    var posx = float.Parse(node.Attributes[3].Value, CultureInfo.InvariantCulture);
                    var posy = float.Parse(node.Attributes[4].Value, CultureInfo.InvariantCulture);
                    var sizew = float.Parse(node.Attributes[5].Value, CultureInfo.InvariantCulture);
                    var sizeh = float.Parse(node.Attributes[6].Value, CultureInfo.InvariantCulture);
                    var usecol = bool.Parse(node.Attributes[7].Value);
                    var angle = float.Parse(node.Attributes[8].Value, CultureInfo.InvariantCulture);
                    if (type == DocumentItemType.Image)
                    {
                        var v = new Vector(filename + "\\" + node.ChildNodes[1].InnerText.Replace('|', '\\'));
                        v.Filename = node.ChildNodes[0].InnerText.Replace('|', '\\');
                        var d = new DocumentData(new PointF(posx, posy), v);
                        d.DispColor = c;
                        d.Name = name;
                        d.UseDispColor = usecol;
                        d.Angle = angle;
                        result.Items.Add(d);
                    }
                    else if (type == DocumentItemType.Text)
                    {
                        var text = node.ChildNodes[0].InnerText;
                        var ff = new FontFamily(node.ChildNodes[1].InnerText);
                        var fs = (FontStyle) Enum.Parse(typeof(FontStyle), node.ChildNodes[2].InnerText);
                        var fsi = float.Parse(node.ChildNodes[3].InnerText, CultureInfo.InvariantCulture);
                        var d = new DocumentText(new PointF(posx, posy), new SizeF(sizew, sizeh), text, new Font(ff, fsi, fs));
                        d.DispColor = c;
                        d.Name = name;
                        d.Angle = angle;
                        d.UseDispColor = usecol;
                        var size_ = Graphics.FromImage(new Bitmap(10, 10)).MeasureString(text, new Font(ff, fsi, fs));
                        d.Size = new SizeF((float) (size_.Width * 0.75 - 5), size_.Height);
                        result.Items.Add(d);
                    }
                }
                foreach (var a in Directory.GetFiles(filename))
                    File.Delete(a);
                Directory.Delete(filename);
                return result;
            }
            catch (Exception e)
            {
                throw new FileLoadException("Unknown error", e);
            }
        }

        /// <summary>
        /// Рендерит докумет с дополнительными параметрами.
        /// </summary>
        /// <param name="zoom">Множитель увеличения. Например: 1 - без увеличения, 0.5 - уменьшить в 2 раза.</param>
        /// <param name="im">Выходное изображение.</param>
        /// <param name="c">Цвет выделенного контура.</param>
        /// <param name="cont">Выделенный контур.</param>
        public void RenderEX(float zoom, out Bitmap im, Color c, GraphicsPath cont)
        {
            var width = (int) (Size.Width * zoom);
            var heigh = (int) (Size.Height * zoom);
            try
            {
                var rec = new Rectangle(0, 0, width, heigh);
                var rec1 = new Rectangle(0, 0, width - 2, heigh - 2);
                var p = new Pen(Color.Black, 1.5f);
                var pp = new Pen(Color.Black, 1.5f);
                p.DashStyle = DashStyle.Dot;
                var bmp = new Bitmap(width, heigh);
                using (var gr = Graphics.FromImage(bmp))
                {
                    gr.FillRectangle(Brushes.White, rec);
                    gr.DrawRectangle(p, rec1);
                    if (Border.Use)
                    {
                        var g = DocumentBorderRender.Render((DocumentBorder) Border.Clone(), Size);
                        var m = new Matrix();
                        m.Scale(zoom, zoom);
                        g.Transform(m);
                        gr.DrawPath(BorderPen, g);
                    }
                    foreach (var a in Items)
                    {
                        var g = (GraphicsPath) a.Render().Clone();
                        //GraphicsPath scaled = Scale(g, a.Size.Width, a.Size.Height);
                        var m = new Matrix();
                        m.Scale(zoom, zoom);
                        g.Transform(m);
                        m.RotateAt(a.Angle, new PointF(a.Size.Width / 2, a.Size.Height / 2));
                        if (a.UseDispColor)
                        {
                            pp = new Pen(a.DispColor, 1.5f);
                            gr.DrawPath(pp, g);
                        }
                        else
                        {
                            gr.DrawPath(Pens.Black, g);
                        }
                    }
                    {
                        var m = new Matrix();
                        m.Scale(zoom, zoom);
                        cont.Transform(m);
                        pp = new Pen(c, 1.5f);
                        gr.DrawPath(pp, cont);
                    }
                }
                im = bmp;
            }
            catch
            {
                im = null;
            }
        }

        /// <summary>
        /// Рендерит докумет.
        /// </summary>
        /// <param name="zoom">Множитель увеличения. Например: 1 - без увеличения, 0.5 - уменьшить в 2 раза.</param>
        /// <param name="im">Выходное изображение.</param>
        public void Render(float zoom, out Bitmap im)
        {
            var width = (int) (Size.Width * zoom);
            var heigh = (int) (Size.Height * zoom);
            try
            {
                var rec = new Rectangle(0, 0, width, heigh);
                var rec1 = new Rectangle(0, 0, width - 2, heigh - 2);
                var p = new Pen(Color.Black, 1.5f);
                var pp = new Pen(Color.Black, 1.5f);
                p.DashStyle = DashStyle.Dot;
                var bmp = new Bitmap(width, heigh);
                using (var gr = Graphics.FromImage(bmp))
                {
                    gr.FillRectangle(Brushes.White, rec);
                    gr.DrawRectangle(p, rec1);
                    if (Border.Use)
                    {
                        var g = DocumentBorderRender.Render((DocumentBorder)Border.Clone(), Size);
                        var m = new Matrix();
                        m.Scale(zoom, zoom);
                        g.Transform(m);
                        gr.DrawPath(BorderPen, g);
                    }
                    foreach (var a in Items)
                    {
                        var g = (GraphicsPath) a.Render().Clone();
                        var m = new Matrix();
                        m.Scale(zoom, zoom);
                        g.Transform(m);
                        if (a.UseDispColor)
                        {
                            pp = new Pen(a.DispColor, 1.5f);
                            gr.DrawPath(pp, g);
                        }
                        else
                        {
                            gr.DrawPath(Pens.Black, g);
                        }
                    }
                }
                im = bmp;
            }
            catch
            {
                im = null;
            }
        }
    }
}