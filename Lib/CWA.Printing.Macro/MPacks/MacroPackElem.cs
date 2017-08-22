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
