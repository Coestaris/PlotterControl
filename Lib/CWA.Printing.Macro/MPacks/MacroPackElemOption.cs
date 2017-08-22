/*=================================\
* CWA.Printing.Macro\MacroPackElemOption.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:36
* Last Edited: 01.07.2017 13:09:58
*=================================*/

using System;
using System.Windows.Input;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// ��������� ��������� �������� ����� ����. 
    /// </summary>
    [Serializable]
    public class MacroPackElemOption
    {
        /// <summary>
        /// ������� (��������) ��������.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// ������ ������� �������� � �������.
        /// </summary>
        public char CharBind { get; set; }

        /// <summary>
        /// ������� ������� ��������.
        /// </summary>
        public Key KeyBind { get; set; }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="MacroPackElemOption"/>.
        /// </summary>
        public MacroPackElemOption() { }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="MacroPackElemOption"/>.
        /// </summary>
        /// <param name="caption">������� (��������) ��������.</param>
        /// <param name="charBind">������ ������� �������� � �������.</param>
        /// <param name="keyBind"> ������� ������� ��������.</param>
        public MacroPackElemOption(string caption, char charBind, Key keyBind) : this()
        {
            Caption = caption;
            CharBind = charBind;
            KeyBind = keyBind;
        }
    }
}
