/*=================================\
* CWA.Printing.Macro\Macro.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:37
* Last Edited: 28.08.2017 14:52:49
*=================================*/

using CWA.DTP.Plotter;
using CWA.Vectors.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// Описывает макрос - последовательность действий, выполняемых на устройстве.
    /// </summary>
    public class Macro
    {
        /// <summary>
        /// Имя макроса.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание макроса.
        /// </summary>
        public string Discr { get; set; }

        /// <summary>
        /// Версия программы, в которой был создан макрос.
        /// </summary>
        public Version CreatedVersion { get; set; }

        /// <summary>
        /// Список элементов макроса.
        /// </summary>
        public List<MacroElem> Elems { get; set; }

        /// <summary>
        /// Имя изображения, привязанного к макросу.
        /// </summary>
        public string PicFileName { get; set; }

        /// <summary>
        /// Размер изображения, привязанного к макросу.
        /// </summary>
        public SizeF PicSize { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса  <see cref="Macro"/>.
        /// </summary>
        /// <param name="name">Имя макроса.</param>
        /// <param name="discr">Описание макроса.</param>
        public Macro(string name, string discr)
        {
            CreatedVersion = new Version(GlobalOptions.Ver);
            Elems = new List<MacroElem>(0);
            Name = name;
            Discr = discr;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Macro"/>, загружая его из файла.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        public Macro(string filename)
        {
            try
            {
                Elems = new List<MacroElem>(0);
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                Name = document.ChildNodes[1].ChildNodes[0].Attributes[0].Value;
                Discr = document.ChildNodes[1].ChildNodes[0].Attributes[1].Value;
                PicFileName = document.ChildNodes[1].ChildNodes[0].Attributes[2].Value;
                string[] PicSizeValues = document.ChildNodes[1].ChildNodes[0].Attributes[3].Value.Split('_');
                PicSize = new SizeF(float.Parse(PicSizeValues[0], CultureInfo.InvariantCulture), float.Parse(PicSizeValues[1], CultureInfo.InvariantCulture));
                CreatedVersion = new Version(
                    int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[0].Value),
                    int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[1].Value),
                    int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[2].Value),
                    int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[3].Value));
                Elems = new List<MacroElem>();
                for (int i = 2; i <= document.ChildNodes[1].ChildNodes.Count - 1; i++)
                {
                    MacroElemType type = MacroElem.ShortedTypeToNormal(ExOperators.GetEnum<MacroElemTypeShorted>(document.ChildNodes[1].ChildNodes[i].Attributes[0].Value));
                    int toolmove = int.Parse(document.ChildNodes[1].ChildNodes[i].Attributes[1].Value);
                    string[] MoveToPointS = document.ChildNodes[1].ChildNodes[i].Attributes[2].Value.Split('_');
                    PointF MoveToPoint = new PointF(float.Parse(MoveToPointS[0], CultureInfo.InvariantCulture), float.Parse(MoveToPointS[1], CultureInfo.InvariantCulture));
                    string[] MoveRelativeS = document.ChildNodes[1].ChildNodes[i].Attributes[3].Value.Split('_');
                    PointF MoveRelative = new PointF(float.Parse(MoveRelativeS[0], CultureInfo.InvariantCulture), float.Parse(MoveRelativeS[1], CultureInfo.InvariantCulture));
                    float Delay = float.Parse(document.ChildNodes[1].ChildNodes[i].Attributes[4].Value, CultureInfo.InvariantCulture);
                    Elems.Add(new MacroElem() { Delay = Delay, MoveRelative = MoveRelative, MoveToPoint = MoveToPoint, ToolMove = toolmove, Type = type });
                }
            }
            catch (Exception e)
            {
                throw new FileLoadException("Unknown error", e);
            }
        }

        public FlFormat ToFlFormat()
        {
            var fl = new FlFormat();
            Int16 lastX = 0;
            Int16 lastY = 0;
            foreach (var item in Elems)
            {
                fl.Elements.Add(new FlFormatElement((Int16)(item.MoveToPoint.X - lastX), (Int16)(item.MoveToPoint.Y - lastY), (Int16)(item.ToolMove), (UInt16)(item.Delay)));
                lastX = (Int16)item.MoveToPoint.X;
                lastY = (Int16)item.MoveToPoint.Y;
            }
            return fl;
        }

        private void AppendAttrToNode(XmlDocument document, XmlNode node, string AttributeName, string Value)
        {
            XmlAttribute attr = document.CreateAttribute(AttributeName);
            attr.Value = Value;
            node.Attributes.Append(attr);
        }

        /// <summary>
        /// Сохраняет макрос в файл с разширением .pcmacros.
        /// </summary>
        /// <param name="filename">Имя файла для сохранения.</param>
        public void Save(string filename)
        {
            XmlTextWriter textWritter = new XmlTextWriter(filename, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("MACRO");
            textWritter.WriteEndElement();
            textWritter.Close();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode el = doc.CreateElement("S");
            doc.DocumentElement.AppendChild(el);
            AppendAttrToNode(doc, el, "N", Name);
            AppendAttrToNode(doc, el, "D", Discr);
            AppendAttrToNode(doc, el, "PN", PicFileName);
            AppendAttrToNode(doc, el, "PS", string.Format("{0}_{1}", PicSize.Width, PicSize.Height));
            XmlNode vers = doc.CreateElement("V");
            AppendAttrToNode(doc, vers, "MV", CreatedVersion.Major.ToString());
            AppendAttrToNode(doc, vers, "MnrV", CreatedVersion.Minor.ToString());
            AppendAttrToNode(doc, vers, "BNr", CreatedVersion.Build.ToString());
            AppendAttrToNode(doc, vers, "R", CreatedVersion.Revision.ToString());
            doc.DocumentElement.AppendChild(vers);
            foreach (var a in Elems)
            {
                XmlNode node = doc.CreateElement("ME");
                doc.DocumentElement.AppendChild(node);
                AppendAttrToNode(doc, node, "T", MacroElem.NormalToShorted(a.Type).ToString());
                AppendAttrToNode(doc, node, "TM", a.ToolMove.ToString());
                AppendAttrToNode(doc, node, "MTP", string.Format("{0}_{1}", a.MoveToPoint.X, a.MoveToPoint.Y));
                AppendAttrToNode(doc, node, "MR", string.Format("{0}_{1}", a.MoveRelative.X, a.MoveRelative.Y));
                AppendAttrToNode(doc, node, "D", a.Delay.ToString(CultureInfo.InvariantCulture));
            }
            doc.Save(filename);
        }
    }
}
