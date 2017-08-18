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
* CWA.Vectors \ VectorFileInfo.cs
*
* Created: 18.08.2017 18:20
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System;

namespace CWA.Vectors
{
    /// <summary>
    /// Класс-оболочка для сериализации файла.
    /// Хранит основную информацию о векторе.
    /// </summary>
    [Serializable]
    internal class VectorFileInfo
    {
        /// <summary>
        /// Ширина вектора.
        /// </summary>
        public UInt16 Width;

        /// <summary>
        /// Высота вектора.
        /// </summary>
        public UInt16 Height;

        /// <summary>
        /// Тип вектора.
        /// </summary>
        public VectType VectType;

        /// <summary>
        /// Отображаемое имя вектора.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Приведение данного экзепляра к <see cref="VectHeader"/>.
        /// </summary>
        public VectHeader ToHeader()
        {
            return new VectHeader()
            {
                CountOfCont = 0,
                Height = Height,
                Name = DisplayName,
                Width = Width
            };
        }

        /// <summary>
        /// Создает новый экзепляр класса <see cref="VectorFileInfo"/>.
        /// </summary>
        public VectorFileInfo() { }
    }
}
