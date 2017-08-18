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
* CWA.Printing.Macro \ PrintMacros_Macro.cs
*
* Created: 17.06.2017 21:03
* Last Edited: 18.08.2017 20:23:26
*
*=================================*/

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
                var neme = document.ChildNodes[1].ChildNodes[0].Attributes[0].Value;
                var d = document.ChildNodes[1].ChildNodes[0].Attributes[1].Value;
                int mav = int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[0].Value);
                int miv = int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[1].Value);
                int bn = int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[2].Value);
                int rev = int.Parse(document.ChildNodes[1].ChildNodes[1].Attributes[3].Value);
                CreatedVersion = new Version(mav, miv, bn, rev);
                Name = neme;
                Discr = d;
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
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode el = document.CreateElement("S");
            document.DocumentElement.AppendChild(el);
            XmlAttribute name = document.CreateAttribute("N"); name.Value = Name; el.Attributes.Append(name);
            XmlAttribute discr = document.CreateAttribute("D"); discr.Value = Discr; el.Attributes.Append(discr);
            XmlNode vers = document.CreateElement("V");
            XmlAttribute mav = document.CreateAttribute("MV"); mav.Value = CreatedVersion.Major.ToString(); vers.Attributes.Append(mav);
            XmlAttribute miv = document.CreateAttribute("MnrV"); miv.Value = CreatedVersion.Minor.ToString(); vers.Attributes.Append(miv);
            XmlAttribute bn = document.CreateAttribute("BNr"); bn.Value = CreatedVersion.Build.ToString(); vers.Attributes.Append(bn);
            XmlAttribute rev = document.CreateAttribute("R"); rev.Value = CreatedVersion.Revision.ToString(); vers.Attributes.Append(rev);
            document.DocumentElement.AppendChild(vers);
            foreach (var a in Elems)
            {
                XmlNode element = document.CreateElement("ME");
                document.DocumentElement.AppendChild(element);
                XmlAttribute Type = document.CreateAttribute("T"); Type.Value = MacroElem.NormalToShorted(a.Type).ToString(); element.Attributes.Append(Type);
                XmlAttribute ToolMove = document.CreateAttribute("TM"); ToolMove.Value = a.ToolMove.ToString(); element.Attributes.Append(ToolMove);
                XmlAttribute MoveToPoint = document.CreateAttribute("MTP"); MoveToPoint.Value = string.Format("{0}_{1}", a.MoveToPoint.X, a.MoveToPoint.Y); element.Attributes.Append(MoveToPoint);
                XmlAttribute MoveRelative = document.CreateAttribute("MR"); MoveRelative.Value = string.Format("{0}_{1}", a.MoveRelative.X, a.MoveRelative.Y); element.Attributes.Append(MoveRelative);
                XmlAttribute Delay = document.CreateAttribute("D"); Delay.Value = a.Delay.ToString(CultureInfo.InvariantCulture); element.Attributes.Append(Delay);
            }
            document.Save(filename);
        }
    }
}
