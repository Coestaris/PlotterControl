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
using System.Xml;

namespace CWA.Vectors
{
    /// <summary>
    /// Предоставляет дополнительные методы для библиотеки.
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// Удаляет из строки заданное количество символов.
        /// </summary>
        /// <param name="s">Строка для удаления.</param>
        /// <param name="index">Индекс с которого будут удалятся символы.</param>
        /// <param name="count">Количество символов, которые будут удалятся.</param>
        public static void Delete(ref string s, int index, int count)
        {
            if (index < 1 || index > s.Length || count <= 0) return;
            if (index + count - 1 > s.Length) count = s.Length - index + 1;
            s = s.Remove(index - 1, count);
        }

        /// <summary>
        /// Дополняет массив элементом.
        /// </summary>
        /// <typeparam name="S">Тип массива.</typeparam>
        /// <param name="a">Сам массив для дополнения.</param>
        /// <param name="x">Элемент для дополнения.</param>
        public static void InsertToArray<S>(ref S[] a, S x)
        {
            if (a == null)
            {
                a = new S[0];
            }
            var b = a.ToList();
            b.Add(x);
            a = b.ToArray();
        }

        /// <summary>
        /// Объеденяет 2 массива.
        /// </summary>
        /// <typeparam name="T">Тип массивов.</typeparam>
        /// <param name="a">Первый массив.</param>
        /// <param name="b">Второй массив.</param>
        public static void ConcatArrays<T>(ref T[] a, ref T[] b)
        {
            if (a == null) Array.Resize(ref a, 0);
            var c = a.ToList();
            c.AddRange(b);
            a = c.ToArray();
        }

        /// <summary>
        /// Меняет значения 2х переменных местами.
        /// </summary>
        /// <typeparam name="T">Тип переменных.</typeparam>
        /// <param name="a">Первая переменная.</param>
        /// <param name="b">Вторая переменная.</param>
        public static void Swap<T>(ref T a,ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        /// <summary>
        /// Удаляет элемент из массива.
        /// </summary>
        /// <typeparam name="T">Тип массива.</typeparam>
        /// <param name="index">Индекс элемента.</param>
        /// <param name="ar">Массив для удаления.</param>
        public static void DeleteFromArray<T>(int index, ref T[] ar)
        {
            var a = ar.ToList();
            a.RemoveAt(index-1);
            ar = a.ToArray();
        }

        /// <summary>
        /// Задает массиву размер (по высоте и ширене).
        /// </summary>
        /// <typeparam name="t">Тип массива.</typeparam>
        /// <param name="arr">Массив для задачи.</param>
        /// <param name="a">Размер по ширине.</param>
        /// <param name="b">Размер по высоте.</param>
        public static void ResizeArray<t>(ref t[][] arr, int a, int b)
        {
            arr = new t[a][];
            for (int i = 0; i <= a - 1; i++) arr[i] = new t[b];
        }

        /// <summary>
        /// Регистрирует параметр в файле.
        /// </summary>
        /// <param name="type_">Тип параметра.</param>
        /// <param name="value">Значение параметра.</param>
        /// <param name="name">Имя файла</param>
        public static void RegisterValue(string type_, string value, string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(name + "\\content.xml");
            XmlElement xmlElement = xmlDocument.CreateElement("Include");
            XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("Type");
            xmlAttribute.Value = type_;
            xmlElement.Attributes.Append(xmlAttribute);
            xmlElement.InnerText = value;
            xmlDocument.LastChild.AppendChild(xmlElement);
            xmlDocument.Save(name + "\\content.xml");
        }
    }
}