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

using System.Drawing;

namespace CWA.Printing
{
    /// <summary>
    /// Описывает параметры необходимые для печати.
    /// </summary>
    public struct PrintOptions
    {
        /// <summary>
        /// Смещение по оси Х в ММ.
        /// </summary>
        public float XOffset { get; set; }

        /// <summary>
        /// Смещение по оси Y в ММ.
        /// </summary>
        public float YOffset { get; set; }

        /// <summary>
        /// ММ в одном шаге по оси X.
        /// </summary>
        public float XMM { get; set; }

        /// <summary>
        /// ММ в одном шаге по оси Y.
        /// </summary>
        public float YMM { get; set; }

        /// <summary>
        /// Желаемый размер изображения в ММ.
        /// </summary>
        public SizeF PrintSize { get; set; }

        /// <summary>
        /// Размер изображения (вектора) в пикселях.
        /// </summary>
        public Size ImageSize { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="PrintOptions"/>.
        /// </summary>
        /// <param name="xOffset">Смещение по оси Х в мм.</param>
        /// <param name="yOffset">Смещение по оси Y в мм.</param>
        /// <param name="xMm">ММ в одном шаге по оси X.</param>
        /// <param name="yMm">ММ в одном шаге по оси Y.</param>
        /// <param name="printSize">Желаемый размер изображения в ММ.</param>
        /// <param name="imageSize">Размер изображения (вектора) в пикселях.</param>
        public PrintOptions(float xOffset, float yOffset, float xMm, float yMm, SizeF printSize, Size imageSize)
        {
            YOffset = yOffset;
            YMM = yMm;
            PrintSize = printSize;
            ImageSize = imageSize;
            XOffset = xOffset;
            XMM = xMm;
        }
    }
}
