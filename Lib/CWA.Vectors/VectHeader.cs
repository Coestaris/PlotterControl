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
* CWA.Vectors \ VectHeader.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:23:26
*
*=================================*/

using System.Collections.Generic;

namespace CWA.Vectors
{
    /// <summary>
    /// Предоставляет информацию о векторе.
    /// </summary>
    public class VectHeader
    {
        /// <summary>
        /// Отображаемое имя вектора.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Ширина вектора.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота вектора.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Тип получения вектора.
        /// </summary>
        public VectType VectType { get; set; }

        /// <summary>
        /// Количество контуров вектора.
        /// </summary>
        public int CountOfCont { get; set; }

        /// <summary>
        /// Дополнительные параметеры вектора.
        /// </summary>
        public Dictionary<string, string> ExParams { get;  set; }

        /// <summary>
        /// Оператор сравнения хедеров.
        /// </summary>
        public static bool operator ==(VectHeader a, VectHeader b)
        {
            return a.VectType == b.VectType 
                && a.Width == b.Width 
                && a.Height == b.Height
                && a.CountOfCont == b.CountOfCont
                && a.ExParams == b.ExParams
                && a.Name == b.Name;
        }

        /// <summary>
        /// Оператор неравенства хедеров.
        /// </summary>
        public static bool operator !=(VectHeader a, VectHeader b)
        {
            return a.VectType != b.VectType
                || a.Width != b.Width
                || a.Height != b.Height
                || a.CountOfCont != b.CountOfCont
                || a.ExParams != b.ExParams
                || a.Name != b.Name;
        }

        /// <summary>
        /// Сравнивает данный хедер с obj.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this == (VectHeader)obj;
        }

        /// <summary>
        /// Возвращает хеш-код класса.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
