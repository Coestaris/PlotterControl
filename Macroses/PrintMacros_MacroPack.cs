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

using System.Collections.Generic;
using System.Text;
using System.Xml;
using CWA.Connection;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// ��������� ����� ��� - ��������� ��������, ������������ � ���� ����� ��������, ��� ����� �������� �������������.
    /// </summary>
    public class MacroPack
    {

        /// <summary>
        /// ��������� ��������. ������ ��������� ����.
        /// </summary>
        private List<MacroPackElem> _elems;

        /// <summary>
        /// ��������� ��������. ��� ����.
        /// </summary>
        private string _name;

        /// <summary>
        /// ��������� ��������. �������� ����.
        /// </summary>
        private string _discr;

        /// <summary>
        /// ��������� ��������. ������������ ��� ����.
        /// </summary>
        private string _caption;

        /// <summary>
        /// ��������� ��������. ������ "�������" ����.
        /// </summary>
        private List<string> _samples;

        /// <summary>
        /// ��������� ��������. ����������� ��� �����.
        /// </summary>
        private ComPortName _portName;

        /// <summary>
        /// ��������� ��������. ����������� �������� ��������� � ������.
        /// </summary>
        private BdRate _portBD;

        /// <summary>
        /// ��� ����.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// �������� ����.
        /// </summary>
        public string Discr
        {
            get { return _discr; }
            set { _discr = value; }
        }

        /// <summary>
        /// ������������ ��� ����.
        /// </summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        /// <summary>
        /// ������ "�������" ����.
        /// </summary>
        public List<string> Samples
        {
            get { return _samples; }
            set { _samples = value; }
        }

        /// <summary>
        /// ����������� ��� �����.
        /// </summary>
        public ComPortName PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// ����������� �������� ��������� � ������.
        /// </summary>
        public BdRate PortBD
        {
            get { return _portBD; }
            set { _portBD = value; }
        }

        /// <summary>
        /// ������ ��������� ����.
        /// </summary>
        public List<MacroPackElem> Elems
        {
            get { return _elems; }
            set { _elems = value; }
        }

        /// <summary>
        /// ������� ����� ��������� ������ MacroPack.
        /// </summary>
        /// <param name="name">��� ����.</param>
        /// <param name="discr">�������� ����.</param>
        /// <param name="caption">������������ ���.</param>
        public MacroPack(string name, string discr, string caption)
        {
            Name = name;
            Discr = discr;
            Caption = caption;
            _elems = new List<MacroPackElem>();
            PortName = new ComPortName(GlobalOptions.Mainport);
            Samples = new List<string>();
            PortBD = new BdRate(GlobalOptions.Mainbd);
        }

        /// <summary>
        /// ��������� ����� ��� � ����.
        /// </summary>
        /// <param name="filename">��� ����� ��� ����������.</param>
        public void Save(string filename)
        {
            XmlTextWriter textWritter = new XmlTextWriter(filename, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("macropack");
            textWritter.WriteEndElement();
            textWritter.Close();
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode el = document.CreateElement("packsetup");
            XmlElement name = document.CreateElement("name"); name.InnerText = Name; el.AppendChild(name);
            XmlElement disc = document.CreateElement("disc"); disc.InnerText = Discr; el.AppendChild(disc);
            XmlElement capt = document.CreateElement("capt"); capt.InnerText = Caption; el.AppendChild(capt);
            XmlElement portnm = document.CreateElement("portnm"); portnm.InnerText = PortName; el.AppendChild(portnm);
            XmlElement portbd = document.CreateElement("portbd"); portbd.InnerText = PortBD.ToString(); el.AppendChild(portbd);
            XmlNode el1 = document.CreateElement("samples");
            foreach (string s in Samples)
            {
                XmlElement smpl = document.CreateElement("saple");
                smpl.InnerText = s;
                el1.AppendChild(smpl);
            }
            XmlNode el2 = document.CreateElement("macroses");
            foreach (var a in _elems)
            {
                XmlElement smpl = document.CreateElement("macro");
                XmlAttribute at1 = document.CreateAttribute("capt"); at1.Value = a.Options.Caption; smpl.Attributes.Append(at1);
                XmlAttribute at2 = document.CreateAttribute("CharBind"); at1.Value = a.Options.CharBind.ToString(); smpl.Attributes.Append(at2);
                XmlAttribute at3 = document.CreateAttribute("KeyBind"); at1.Value = a.Options.KeyBind.ToString(); smpl.Attributes.Append(at3);
                XmlAttribute at4 = document.CreateAttribute("path"); at1.Value = a.Path; smpl.Attributes.Append(at4);
                el2.AppendChild(smpl);
            }
            document.AppendChild(el);
            document.AppendChild(el1);
            document.AppendChild(el2);
            document.Save(filename);
        }
    }
}