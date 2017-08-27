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
    /// Описывает макро пак - контейнер макросов, объедененных в один общий документ, для более удобного использования.
    /// </summary>
    [Serializable]
    public class MacroPack
    {
        /// <summary>
        /// Имя пака.
        /// </summary>
        public string Name { get; set; }
        //public string Name;

        /// <summary>
        /// Описание пака.
        /// </summary>
        public string Discr { get; set; }

        /// <summary>
        /// Отображаемое имя пака.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Список "семплов" пака.
        /// </summary>
        public List<string> Samples { get; set; }
        /// <summary>
        /// Стандартное имя порта.
        /// </summary>
        public ComPortName PortName { get; set; }

        /// <summary>
        /// Размер окна пака.
        /// </summary>
        public Size WindowSize { get; set; }

        /// <summary>
        /// Стандартная скорость соеденеия с портом.
        /// </summary>
        public BdRate PortBD { get; set; }

        /// <summary>
        /// Список имен элементов пака.
        /// </summary>
        public List<MacroPackElem> Elems { get; set; }

        /// <summary>
        ///  Возвращает дочерные элементы.
        /// </summary>
        /// <param name="CantLoadList">Возвращает список элементов, которые не получилось загрузить.</param>
        /// <returns></returns>
        public List<Macro> GetElems(out List<string> CantLoadList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="MacroPack"/>.
        /// </summary>
        public MacroPack() { }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="MacroPack"/>.
        /// </summary>
        /// <param name="name">Имя пака.</param>
        /// <param name="discr">Описание пака.</param>
        /// <param name="caption">Отображаемое имя.</param>
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
        /// Сохраняет макро пак в файл.
        /// </summary>
        /// <param name="FileName">Имя файла для сохранения.</param>
        public void Save(string FileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(MacroPack));
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="MacroPack"/>, загружая его с файла.
        /// </summary>
        /// <param name="filename">Имя файла для сохранения.</param>
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
