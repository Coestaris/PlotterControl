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
* CWA.Vectors.Document \ VEditor_DocumentCirlce.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System.Drawing;
using System.Drawing.Drawing2D;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// ��������� ������ �������, ������� ����������� �� <see cref="DocumentItem"/>.
    /// </summary>
    public class DocumentCirlce : DocumentItem
    {
        /// <summary>
        /// ����� �����.
        /// </summary>
        public PointF Center { get; internal set; }

        /// <summary>
        /// ������ �����.
        /// </summary>
        public float Radius { get; internal set; }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="DocumentCirlce"/>.
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
