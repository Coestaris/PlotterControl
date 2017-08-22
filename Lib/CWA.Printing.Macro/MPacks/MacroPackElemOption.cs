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
    /// Описывает параметры элемента макро пака. 
    /// </summary>
    [Serializable]
    public class MacroPackElemOption
    {
        /// <summary>
        /// Надпись (название) элемента.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Символ запуска элемента в команде.
        /// </summary>
        public char CharBind { get; set; }

        /// <summary>
        /// Горячая клавиша элемента.
        /// </summary>
        public Key KeyBind { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="MacroPackElemOption"/>.
        /// </summary>
        public MacroPackElemOption() { }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="MacroPackElemOption"/>.
        /// </summary>
        /// <param name="caption">Надпись (название) элемента.</param>
        /// <param name="charBind">Символ запуска элемента в команде.</param>
        /// <param name="keyBind"> Горячая клавиша элемента.</param>
        public MacroPackElemOption(string caption, char charBind, Key keyBind) : this()
        {
            Caption = caption;
            CharBind = charBind;
            KeyBind = keyBind;
        }
    }
}
