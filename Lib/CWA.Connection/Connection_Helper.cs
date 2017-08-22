/*=================================\
* CWA.Connection\Connection_Helper.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

namespace CWA.Connection
{
    /// <summary>
    /// Предоставляет дополнительные методы для библиотеки <see cref="Connection"/>.
    /// </summary>
    internal class ExOperators
    {
        /// <summary>
        /// Найти в XML документе значение с конкретным ID.
        /// </summary>
        /// <param name="s">Id для поиска.</param>
        /// <param name="doc">Документ для поиска.</param>
        /// <returns></returns>
        public static string Find(string s, XmlDocument doc)
        {
            foreach (var a in doc.LastChild.ChildNodes.Cast<XmlNode>())
            {
                if (a.Attributes != null && (a.Attributes[0].Name == "id" && a.Attributes[0].Value == s)) return a.InnerText;
            }
            return "";
        }

        /// <summary>
        /// Преобразование цвета в 16ый формат (Color to HEX).
        /// </summary>
        /// <param name="c">Цвет для преобразования.</param>
        public static string ColorToHex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        /// <summary>
        /// Преобразования цвета с 16го формата в обычный.
        /// </summary>
        /// <param name="s">Строка для приведения.</param>
        public static Color ColorFromHex(string s)
        {
            if (s.StartsWith("#")) s = s.Substring(1);
            return Color.FromArgb(
               int.Parse(s.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
               int.Parse(s.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
               int.Parse(s.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
        }

        /// <summary>
        /// Возвращает соответсвующий елемент перечисления из строки.
        /// </summary>
        /// <typeparam name="T">Тип перечисления.</typeparam>
        /// <param name="source">Имя элемента в строковом представлении.</param>
        public static T GetEnum<T>(string source)
        {
            return (T)Enum.Parse(typeof(T), source);
        }

        /// <summary>
        /// Загрузка данных с XML файла в словарь.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        public static Dictionary<string, string> Load(string filename)
        {
            var document = new XmlDocument();
            document.Load(filename);
            return document.LastChild.ChildNodes.Cast<XmlNode>().ToDictionary(a => a.Attributes[0].Value, a => a.InnerText);
        }

        /// <summary>
        /// Сохранение словаря в XML файл с коментарием.
        /// </summary>
        /// <param name="filename">Имя файла для сохранения.</param>
        /// <param name="a">Данные для сохранения. Ключ - ID элемента, Значение - значение элемента.</param>
        /// <param name="comment">Коментарий после XML заголовка</param>
        public static void Save(string filename, Dictionary<string, string> a, string comment)
        {
            XmlTextWriter textWritter = new XmlTextWriter(filename, Encoding.UTF8);
            textWritter.WriteStartDocument();
            textWritter.WriteComment(comment);
            textWritter.WriteStartElement("Options");
            textWritter.WriteEndElement();
            textWritter.Close();
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            foreach (var b in a)
            {
                var j = document.CreateAttribute("id");
                j.Value = b.Key;
                var g = document.CreateElement("Option");
                g.Attributes.Append(j);
                g.InnerText = b.Value;
                document.LastChild.AppendChild(g);
            }
            document.Save(filename);
        }
    }
}
