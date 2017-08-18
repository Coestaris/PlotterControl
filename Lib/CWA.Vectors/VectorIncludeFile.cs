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
* CWA.Vectors \ VectorIncludeFile.cs
*
* Created: 18.08.2017 18:20
* Last Edited: 18.08.2017 20:23:26
*
*=================================*/

using System;
using System.Collections.Generic;

namespace CWA.Vectors
{
    /// <summary>
    /// Класс-оболочка для сериализации файла.
    /// Хранит основную информацию о файлах данного архива.
    /// </summary>
    [Serializable]
    internal class VectorIncludeFile
    {
        /// <summary>
        /// Коллекция файлов.
        /// </summary>
        public List<VectorIncludeFileItem> Items;

        /// <summary>
        /// Создает новый экзепляр класса <see cref="VectorIncludeFile"/>.
        /// </summary>
        public VectorIncludeFile() { }
    }
}
