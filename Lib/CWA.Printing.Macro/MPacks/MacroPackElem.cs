/*=================================\
* CWA.Printing.Macro\MacroPackElem.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:36
* Last Edited: 01.07.2017 13:09:58
*=================================*/

using System;
using System.Linq;
using System.Windows.Input;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// ��������� ������� ����� ����.
    /// </summary>
    [Serializable]
    public class MacroPackElem
    {
        /// <summary>
        /// ������� ����� ��������� ������ <see cref="MacroPackElem"/>.
        /// 
        public MacroPackElem() { }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="MacroPackElem"/>, �������� ��� �� �����.
        /// </summary>
        /// <param name="filename">��� �����.</param>
        public MacroPackElem(string filename, string Name)
        {
            Options = new MacroPackElemOption(Name, Name.First(), Key.None);
            Path = filename;
        }

        /// <summary>
        /// ���� � �����, � �������� ��� �������� �������.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// ������� ������.
        /// </summary>
        private Macro basicMacro;


        /// <summary>
        /// ���������� �������� �������� �������.
        /// </summary>
        public Macro GetMacro()
        {
            return basicMacro;
        }

        /// <summary>
        /// ������������� �������� �������� �������.
        /// </summary>
        /// <param name="val">�������� ������</param>
        public void SetMacro(Macro val)
        {
            basicMacro = val;
        }

        /// <summary>
        /// �������������� ��������� ��������.
        /// </summary>
        public MacroPackElemOption Options { get; set; }
    }
}
