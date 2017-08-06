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

using System;
using System.Linq;
using System.Windows.Input;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// Описывает элемент макро пака.
    /// </summary>
    [Serializable]
    public class MacroPackElem
    {
        /// <summary>
        /// Создает новый экземпляр класса <see cref="MacroPackElem"/>.
        /// 
        public MacroPackElem() { }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="MacroPackElem"/>, загружая его из файла.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        public MacroPackElem(string filename, string Name)
        {
            Options = new MacroPackElemOption(Name, Name.First(), Key.None);
            Path = filename;
        }

        /// <summary>
        /// Путь к файлу, с которого был загружен элемент.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Базовый макрос.
        /// </summary>
        private Macro basicMacro;


        /// <summary>
        /// Возвращает значение базового макроса.
        /// </summary>
        public Macro GetMacro()
        {
            return basicMacro;
        }

        /// <summary>
        /// Устонавливает значения базовому макросу.
        /// </summary>
        /// <param name="val">Значение макрос</param>
        public void SetMacro(Macro val)
        {
            basicMacro = val;
        }

        /// <summary>
        /// Дополнительные параметры элемента.
        /// </summary>
        public MacroPackElemOption Options { get; set; }
    }
}