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
    /// ��������� ������ �������, ������� ����������� �� DocumentItem.
    /// </summary>
    public class DocumentCirlce : DocumentItem
    {
        /// <summary>
        /// ��������� ��������. ����� �����.
        /// </summary>
        private PointF _center;

        /// <summary>
        /// ��������� ��������. ������ �����.
        /// </summary>
        private float _radius;

        /// <summary>
        /// ����� �����.
        /// </summary>
        public PointF Center
        {
            get { return _center; }
            set { _center = value; }
        }

        /// <summary>
        /// ������ �����.
        /// </summary>
        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        /// <summary>
        /// ������� ����� ��������� ������ DocumentCirlce.
        /// </summary>
        /// <param name="position">������� �������.</param>
        /// <param name="p1">����� �����.</param>
        /// <param name="r">������ �����.</param>
        public DocumentCirlce(PointF position, PointF p1, float r)
        {
            Center = p1;
            Position = position;
            Radius = r;
            Type = DocumentItemType.Shape;
        }

        /// <summary>
        /// ������������ ������.
        /// </summary>
        public override void PreRender()
        {
            GrPath = new GraphicsPath(FillMode.Winding);
            GrPath.AddEllipse(Center.X, Center.Y, Radius, Radius);
        }
    }
}