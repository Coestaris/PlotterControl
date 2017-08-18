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
* CWA.Vectors.Document \ VEditor_DocumentBorder.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Предоставляет информацию о границе документа.
    /// </summary>
    public class DocumentBorder : ICloneable
    {
        /// <summary>
        /// Сдвиг границы от края документа.
        /// </summary>
        public float Offset { get; set; }

        /// <summary>
        /// Стиль границы.
        /// </summary>
        public DocumentBorderStyle Style { get; set; }

        /// <summary>
        /// Использовать ли границу.
        /// </summary>
        public bool Use { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentBorder"/>.
        /// </summary>
        /// <param name="offset">Сдвиг границы от краев документа.</param>
        /// <param name="style"> Стиль границы.</param>
        /// <param name="use">Использовать ли границу.</param>
        public DocumentBorder(float offset, DocumentBorderStyle style, bool use)
        {
            Offset = offset;
            Style = style;
            Use = use;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentBorder"/>.
        /// </summary>
        public DocumentBorder() { }

        /// <summary>
        /// Клонирует данный экземпляр.
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
