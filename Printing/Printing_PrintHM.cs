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

using CWA.Vectors;
using System;
using System.Drawing;

namespace CWA.Printing
{
    /// <summary>
    /// Предоставляет дополнительные методы для библиотеки.
    /// </summary>
    public class PrintHm
    {
        /// <summary>
        /// Получает размер по высоте из размера по ширине (сохраняя пропорцию).
        /// </summary>
        /// <param name="imgWidth">Ширина изображения.</param>
        /// <param name="imgHeight">Высота изображения.</param>
        /// <param name="xSize">Размер по ширине.</param>
        public static float GetYsize(float imgWidth, float imgHeight, float xSize)
        {
            return xSize * imgHeight / imgWidth;
        }

        /// <summary>
        /// Получает размер по ширине из размера по высоте (сохраняя пропорцию).
        /// </summary>
        /// <param name="imgWidth">Ширина изображения.</param>
        /// <param name="imgHeight">Высота изображения.</param>
        /// <param name="ySize">Размер по высоте.</param>
        public static float GetXsize(float imgWidth, float imgHeight, float ySize)
        {
            return ySize * imgWidth / imgHeight;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pn1"></param>
        /// <param name="pn2"></param>
        /// <returns></returns>
        internal static string GetDc(VPoint pn1, VPoint pn2)
        {
            var dx = pn2.X - pn1.X;
            var dy = pn2.Y - pn1.Y;
            return $"{(int) dx},{(int) dy},0;";
        }

        /// <summary>
        /// Преобразует точку в шаги с заданными параметрами.
        /// </summary>
        /// <param name="a">Точка для преобразования.</param>
        /// <param name="xmm">ММ в 1м шаге по оси Х.</param>
        /// <param name="ymm">ММ в 1м шаге по оси У.</param>
        /// <param name="imageSize">Размеры изображения (в пикселях).</param>
        /// <param name="printSize">Размер результирующего изображения (в мм).</param>
        /// <returns></returns>
        internal static Point toStep(Point a, float xmm, float ymm, Size imageSize, SizeF printSize)
        {
            return new Point((int)(a.X * (printSize.Width / xmm / imageSize.Width)), (int)(a.Y * (printSize.Height / ymm / imageSize.Height)));
        }

        /// <summary>
        /// Преобразует точку в шаги с заданными параметрами.
        /// </summary>
        /// <param name="a">Точка для преобразования.</param>
        /// <param name="op">Параметры печати.</param>
        internal static Point toStep(Point a, PrintOptions op)
        {
            return new Point((int)(a.X * (op.PrintSize.Height / op.XMM / op.ImageSize.Width)), (int)(a.Y * (op.PrintSize.Width / op.YMM / op.ImageSize.Height)));
        }

        /// <summary>
        /// Назодит растояние между 2мя точками.
        /// </summary>
        /// <param name="pn1">Первая точка.</param>
        /// <param name="pn2">Вторая точка.</param>
        internal static float Distance(VPoint pn1, VPoint pn2)
        {
            return (float)Math.Sqrt((pn2.X - pn1.X) * (pn2.X - pn1.X) + (pn2.X - pn1.Y) * (pn2.Y - pn1.X));
        }
    }
}
