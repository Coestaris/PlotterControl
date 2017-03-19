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
    /// Описывает объект прямой, который наследуется от DocumentItem.
    /// </summary>
    public class DocumentLine : DocumentItem
    {
        /// <summary>
        /// Приватный параметр. Первая точка прямой.
        /// </summary>
        private PointF _pos1;

        /// <summary>
        /// Приватный параметр. Вторая точка прямой.
        /// </summary>
        private PointF _pos2;

        /// <summary>
        /// Создает новый экземпляр класса DocumentLine.
        /// </summary>
        /// <param name="position">Позиция объекта.</param>
        /// <param name="p1">Первая точка прямой.</param>
        /// <param name="p2">Вторая точка прямой.</param>
        public DocumentLine(PointF position, PointF p1, PointF p2)
        {
            Position = position;
            _pos2 = p1;
            _pos1 = p2;
            Type = DocumentItemType.Shape;
        }

        /// <summary>
        /// Первая точка прямой.
        /// </summary>
        public PointF Pos1
        {
            get { return _pos1; }
            set { _pos1 = value; }
        }

        /// <summary>
        /// Вторая точка прямой.
        /// </summary>
        public PointF Pos2
        {
            get { return _pos2; }
            set { _pos2 = value; }
        }

        /// <summary>
        /// Перерисовует объект.
        /// </summary>
        public override void PreRenderPath()
        {
            GrPath = new GraphicsPath(FillMode.Winding);
            GrPath.AddLine(_pos2, _pos1);
        }
    }
}