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
* CWA.Vectors.Document \ VEditor_DocumentLine.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:23:27
*
*=================================*/

using System.Drawing;
using System.Drawing.Drawing2D;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// ��������� ������ ������, ������� ����������� �� <see cref="DocumentItem"/>.
    /// </summary>
    public class DocumentLine : DocumentItem
    {
        /// <summary>
        /// ������� ����� ��������� ������ <see cref="DocumentLine"/>.
        /// </summary>
        /// <param name="position">������� �������.</param>
        /// <param name="p1">������ ����� ������.</param>
        /// <param name="p2">������ ����� ������.</param>
        public DocumentLine(PointF position, PointF p1, PointF p2)
        {
            Position = position;
            Pos1 = p1;
            Pos2 = p2;
            Type = DocumentItemType.Shape;
        }

        /// <summary>
        /// ������ ����� ������.
        /// </summary>
        public PointF Pos1 { get; internal set; }

        /// <summary>
        /// ������ ����� ������.
        /// </summary>
        public PointF Pos2 { get; internal set; }

        /// <summary>
        /// ������������ ������.
        /// </summary>
        public override void PreRenderPath()
        {
            GrPath = new GraphicsPath(FillMode.Winding);
            GrPath.AddLine(Pos1, Pos1);
        }
    }
}
