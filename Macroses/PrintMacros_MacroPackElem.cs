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

using System.Linq;
using System.Windows.Input;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// Описывает элемент макро пака.
    /// </summary>
    public struct MacroPackElem
    {
        /// <summary>
        /// Приватный параметр. Базовый макрос.
        /// </summary>
        private Macro _macro;

        /// <summary>
        /// Приватный параметр. Дополнительные параметры элемента.
        /// </summary>
        private MacroPackElemOption _opts;

        /// <summary>
        /// Приватный параметр. Путь к файлу, с которого был загружен элемент.
        /// </summary>
        private string _path;

        /// <summary>
        /// Создает новый экземпляр класса MacroPackElem, загружая его из файла.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        public MacroPackElem(string filename)
        {
            _macro = new Macro(filename);
            _opts = new MacroPackElemOption();
            _opts.Caption = _macro.Name;
            _opts.CharBind = _macro.Name.First();
            _opts.KeyBind = Key.None;
            _path = filename;
        }

        /// <summary>
        /// Путь к файлу, с которого был загружен элемент.
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// Базовый макрос.
        /// </summary>
        public Macro Macros
        {
            get { return _macro; }
            set { _macro = value; }
        }

        /// <summary>
        /// Дополнительные параметры элемента.
        /// </summary>
        public MacroPackElemOption Options
        {
            get { return _opts; }
            set { _opts = value; }
        }
    }
}