/*=================================\
* CWA.Printing.Macro\MacroPack.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:36
* Last Edited: 27.08.2017 13:30:22
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
        public string Name { get; set; }
        //public string Name;

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
