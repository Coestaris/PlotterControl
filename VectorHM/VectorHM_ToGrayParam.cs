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

using System.Collections.Generic;
using System.Drawing;

namespace CWA.Vectors
{
    /// <summary>
    /// Описывает параметры для выполнения многопоточной операции преобразования в черно-белый формат.
    /// </summary>
    internal class ToGrayParam
    {
        /// <summary>
        /// Изображение для обработки.
        /// </summary>
        public Bitmap Bmp;

        /// <summary>
        /// Ссылка на словарь всех изображений.
        /// </summary>
        public @Dictionary<int, Bitmap> Res;

        /// <summary>
        /// Создает новый экземпляр класса ToGrayParam.
        /// </summary>
        /// <param name="b">Изображение для выполнения операций.</param>
        /// <param name="res">Ссылка на словарь остальных значений.</param>
        public ToGrayParam(Bitmap b, @Dictionary<int, Bitmap> res)
        {
            Bmp = b;
            this.Res = res;
        }
    }
}
