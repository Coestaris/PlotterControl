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

using System.Windows.Input;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// Описывает параметры элемента макро пака. 
    /// </summary>
    public struct MacroPackElemOption
    {

        /// <summary>
        /// Приватный параметр. Надпись (название) элемента.
        /// </summary>
        private string _caption;

        /// <summary>
        /// Приватный параметр. Символ запуска элемента в команде.
        /// </summary>
        private char _charBind;

        /// <summary>
        /// Приватный параметр. Горячая клавиша элемента.
        /// </summary>
        private Key _keyBind;

        /// <summary>
        /// Надпись (название) элемента.
        /// </summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        /// <summary>
        /// Символ запуска элемента в команде.
        /// </summary>
        public char CharBind
        {
            get { return _charBind; }
            set { _charBind = value; }
        }

        /// <summary>
        /// Горячая клавиша элемента.
        /// </summary>
        public Key KeyBind
        {
            get { return _keyBind; }
            set { _keyBind = value; }
        }

        /// <summary>
        /// Создает новый экземпляр класса MacroPackElemOption.
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