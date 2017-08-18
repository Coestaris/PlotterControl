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
* CWA.Printing.Macro \ PrintMacros_MacroPack.cs
*
* Created: 17.06.2017 21:03
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System.Collections.Generic;
using CWA.Connection;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// ��������� ����� ��� - ��������� ��������, ������������ � ���� ����� ��������, ��� ����� �������� �������������.
    /// </summary>
    [Serializable]
    public class MacroPack
    {
        /// <summary>
        /// ��� ����.
        /// </summary>
        //public string Name { get; set; }
        public string Name;

        /// <summary>
        /// �������� ����.
        /// </summary>
        public string Discr { get; set; }

        /// <summary>
        /// ������������ ��� ����.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// ������ "�������" ����.
        /// </summary>
        public List<string> Samples { get; set; }
        /// <summary>
        /// ����������� ��� �����.
        /// </summary>
        public ComPortName PortName { get; set; }

        /// <summary>
        /// ������ ���� ����.
        /// </summary>
        public Size WindowSize { get; set; }

        /// <summary>
        /// ����������� �������� ��������� � ������.
        /// </summary>
        public BdRate PortBD { get; set; }

        /// <summary>
        /// ������ ���� ��������� ����.
        /// </summary>
        public List<MacroPackElem> Elems { get; set; }

        /// <summary>
        ///  ���������� �������� ��������.
        /// </summary>
        /// <param name="CantLoadList">���������� ������ ���������, ������� �� ���������� ���������.</param>
        /// <returns></returns>
        public List<Macro> GetElems(out List<string> CantLoadList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="MacroPack"/>.
        /// </summary>
        public MacroPack() { }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="MacroPack"/>.
        /// </summary>
        /// <param name="name">��� ����.</param>
        /// <param name="discr">�������� ����.</param>
        /// <param name="caption">������������ ���.</param>
        public MacroPack(string name, string discr, string caption)
        {
            Name = name;
            Discr = discr;
            Caption = caption;
            Elems = new List<MacroPackElem>();
            PortName = new ComPortName(GlobalOptions.Mainport);
            Samples = new List<string>();
            PortBD = new BdRate(GlobalOptions.Mainbd);
        }
        
        /// <summary>
        /// ��������� ����� ��� � ����.
        /// </summary>
        /// <param name="FileName">��� ����� ��� ����������.</param>
        public void Save(string FileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(MacroPack));
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="MacroPack"/>, �������� ��� � �����.
        /// </summary>
        /// <param name="filename">��� ����� ��� ����������.</param>
        public static MacroPack Load(string FileName)
        {
            MacroPack result;
            XmlSerializer formatter = new XmlSerializer(typeof(MacroPack));
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                result = (MacroPack)formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
