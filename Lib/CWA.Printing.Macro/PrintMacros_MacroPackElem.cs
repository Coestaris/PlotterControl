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
* CWA.Printing.Macro \ PrintMacros_MacroPackElem.cs
*
* Created: 17.06.2017 21:03
* Last Edited: 18.08.2017 20:21:25
*
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
