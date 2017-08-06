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
using System.Drawing.Drawing2D;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Описывает объект вектора, который наследуется от <see cref="DocumentItem"/>.
    /// </summary>
    public class DocumentData : DocumentItem
    {
        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentData"/>.
        /// </summary>
        /// <param name="position">Позиция объекта.</param>
        /// <param name="d">Данные о векторе.</param>
        public DocumentData(PointF position, Vector d)
        {
            BaseData = d;
            Position = position;
            Size = d.SizeF;
        }

        /// <summary>
        /// Информация о векторе.
        /// </summary>
        public Vector BaseData { get; set; }

        /// <summary>
        /// Перерисовует объект.
        /// </summary>
        public override void PreRenderPath()
        {
            GrPath = new GraphicsPath(FillMode.Winding);
            for (var i = 0; i <= BaseData.RawData.Length - 1; i++)
                try { GrPath.AddPolygon(Vector.PointexToPoint(BaseData.RawData[i])); }
                catch {
                    //ignored
                }
        }
    }
}