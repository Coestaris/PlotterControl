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
* CWA.Vectors.Document \ VEditor_DocumentBorderRender.cs
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
    /// ������������� ������ ��� ��������� ������ ���������.
    /// </summary>
    public static class DocumentBorderRender
    {
        //TODO peredelat`
        /// <summary>
        /// ��������� ����������� �������. 
        /// </summary>
        private static GraphicsPath _lastRenderResult;

        /// <summary>
        /// ��������� ����������� �������. ���������� ����� ����������, ����� �� ��������� �������� ��� ���.
        /// </summary>
        private static DocumentBorder _lastRenderBorder;

        /// <summary>
        /// ������ ����������� �������. ���������� ����� ����������, ����� �� ��������� �������� ��� ���.
        /// </summary>
        private static SizeF _lastRenderSizeF;

        /// <summary>
        /// ������������ ������� c ��������� �����������.
        /// </summary>
        /// <param name="b">��������� �������.</param>
        /// <param name="size">������ (��� ������� ���������, � ������� �������� �������).</param>
        /// <returns></returns>
        public static GraphicsPath Render(DocumentBorder b, SizeF size)
        {
            if (b == _lastRenderBorder && size == _lastRenderSizeF)
                return (GraphicsPath) _lastRenderResult.Clone();
            var result = new GraphicsPath(FillMode.Winding);
            switch (b.Style)
            {
                case DocumentBorderStyle.Default:
                    var r = new RectangleF(b.Offset, b.Offset, size.Width - b.Offset * 2, size.Height - b.Offset * 2);
                    result.AddRectangle(r);
                    break;
                case DocumentBorderStyle.DoubleLine:
                {
                    var r1 = new RectangleF(b.Offset, b.Offset, size.Width - b.Offset * 2, size.Height - b.Offset * 2);
                    var r2 = new RectangleF(b.Offset + 5, b.Offset + 5, size.Width - (b.Offset + 5) * 2,
                        size.Height - (b.Offset + 5) * 2);
                    result.AddRectangle(r1);
                    result.AddRectangle(r2);
                }
                    break;
                case DocumentBorderStyle.TripleLine:
                {
                    var r1 = new RectangleF(b.Offset, b.Offset, size.Width - b.Offset * 2, size.Height - b.Offset * 2);
                    var r2 = new RectangleF(b.Offset + 5, b.Offset + 5, size.Width - (b.Offset + 5) * 2,
                        size.Height - (b.Offset + 5) * 2);
                    var r3 = new RectangleF(b.Offset + 10, b.Offset + 10, size.Width - (b.Offset + 10) * 2,
                        size.Height - (b.Offset + 10) * 2);
                    result.AddRectangle(r1);
                    result.AddRectangle(r2);
                    result.AddRectangle(r3);
                }
                    break;
                case DocumentBorderStyle.Triangle:
                {
                    var LeftUpCorner = new PointF(b.Offset, b.Offset);
                    var RightUpCorner = new PointF(size.Width - b.Offset, b.Offset);
                    var LeftDownCorner = new PointF(b.Offset, size.Height - b.Offset);
                    var RightDownCorner = new PointF(size.Width - b.Offset, size.Height - b.Offset);
                    result.StartFigure();
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X + 10, LeftUpCorner.Y));
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X, LeftUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X - 10, RightUpCorner.Y));
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X, RightUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X + 10, LeftDownCorner.Y));
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X, LeftDownCorner.Y - 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X - 10, RightDownCorner.Y));
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X, RightDownCorner.Y - 10));
                    result.CloseFigure();
                }
                    break;
                case DocumentBorderStyle.DoubleTriangle:
                {
                    var LeftUpCorner = new PointF(b.Offset, b.Offset);
                    var RightUpCorner = new PointF(size.Width - b.Offset, b.Offset);
                    var LeftDownCorner = new PointF(b.Offset, size.Height - b.Offset);
                    var RightDownCorner = new PointF(size.Width - b.Offset, size.Height - b.Offset);
                    var _LeftUpCorner = new PointF(b.Offset + 10, b.Offset + 10);
                    var _RightUpCorner = new PointF(size.Width - b.Offset - 10, b.Offset + 10);
                    var _LeftDownCorner = new PointF(b.Offset + 10, size.Height - b.Offset - 10);
                    var _RightDownCorner = new PointF(size.Width - b.Offset - 10, size.Height - b.Offset - 10);
                    result.StartFigure();
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X + 40, LeftUpCorner.Y));
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X, LeftUpCorner.Y + 40));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X - 40, RightUpCorner.Y));
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X, RightUpCorner.Y + 40));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X + 40, LeftDownCorner.Y));
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X, LeftDownCorner.Y - 40));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X - 40, RightDownCorner.Y));
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X, RightDownCorner.Y - 40));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(_LeftUpCorner, new PointF(_LeftUpCorner.X + 20, _LeftUpCorner.Y));
                    result.AddLine(_LeftUpCorner, new PointF(_LeftUpCorner.X, _LeftUpCorner.Y + 20));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(_RightUpCorner, new PointF(_RightUpCorner.X - 20, _RightUpCorner.Y));
                    result.AddLine(_RightUpCorner, new PointF(_RightUpCorner.X, _RightUpCorner.Y + 20));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(_LeftDownCorner, new PointF(_LeftDownCorner.X + 20, _LeftDownCorner.Y));
                    result.AddLine(_LeftDownCorner, new PointF(_LeftDownCorner.X, _LeftDownCorner.Y - 20));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(_RightDownCorner, new PointF(_RightDownCorner.X - 20, _RightDownCorner.Y));
                    result.AddLine(_RightDownCorner, new PointF(_RightDownCorner.X, _RightDownCorner.Y - 20));
                    result.CloseFigure();
                }
                    break;
                case DocumentBorderStyle.Dash:
                {
                    var wcount = (int) ((size.Width - b.Offset * 2) / 20);
                    var hcount = (int) ((size.Height - b.Offset * 2) / 20);
                    var LeftUpCorner = new PointF(b.Offset, b.Offset);
                    var RightUpCorner = new PointF(size.Width - b.Offset, b.Offset);
                    var LeftDownCorner = new PointF(b.Offset, size.Height - b.Offset);
                    var RightDownCorner = new PointF(size.Width - b.Offset, size.Height - b.Offset);
                    result.StartFigure();
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X + 10, LeftUpCorner.Y));
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X, LeftUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X - 10, RightUpCorner.Y));
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X, RightUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X + 10, LeftDownCorner.Y));
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X, LeftDownCorner.Y - 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X - 10, RightDownCorner.Y));
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X, RightDownCorner.Y - 10));
                    result.CloseFigure();
                    float w = 0;
                    float h = 0;
                    for (var i = 1; i <= wcount; i++)
                    {
                        w += 20;
                        result.StartFigure();
                        result.AddLine(w, b.Offset, w + 10, b.Offset);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(w, size.Height - b.Offset, w + 10, size.Height - b.Offset);
                        result.CloseFigure();
                    }
                    for (var i = 1; i <= hcount; i++)
                    {
                        h += 20;
                        result.StartFigure();
                        result.AddLine(b.Offset, h, b.Offset, h + 10);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(size.Width - b.Offset, h, size.Width - b.Offset, h + 10);
                        result.CloseFigure();
                    }
                }
                    break;
                case DocumentBorderStyle.Dot:
                {
                    var wcount = (int) ((size.Width - b.Offset * 2) / 10);
                    var hcount = (int) ((size.Height - b.Offset * 2) / 10);
                    var LeftUpCorner = new PointF(b.Offset, b.Offset);
                    var RightUpCorner = new PointF(size.Width - b.Offset, b.Offset);
                    var LeftDownCorner = new PointF(b.Offset, size.Height - b.Offset);
                    var RightDownCorner = new PointF(size.Width - b.Offset, size.Height - b.Offset);
                    result.StartFigure();
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X + 10, LeftUpCorner.Y));
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X, LeftUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X - 10, RightUpCorner.Y));
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X, RightUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X + 10, LeftDownCorner.Y));
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X, LeftDownCorner.Y - 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X - 10, RightDownCorner.Y));
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X, RightDownCorner.Y - 10));
                    result.CloseFigure();
                    float w = 0;
                    float h = 0;
                    for (var i = 1; i <= wcount; i++)
                    {
                        w += 10;
                        result.StartFigure();
                        result.AddLine(w, b.Offset, w + 2, b.Offset);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(w, size.Height - b.Offset, w + 2, size.Height - b.Offset);
                        result.CloseFigure();
                    }
                    for (var i = 1; i <= hcount; i++)
                    {
                        h += 10;
                        result.StartFigure();
                        result.AddLine(b.Offset, h, b.Offset, h + 2);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(size.Width - b.Offset, h, size.Width - b.Offset, h + 2);
                        result.CloseFigure();
                    }
                }
                    break;
                case DocumentBorderStyle.DashDot:
                {
                    var wcount = (int) ((size.Width - b.Offset * 2) / 22);
                    var hcount = (int) ((size.Height - b.Offset * 2) / 22);
                    var LeftUpCorner = new PointF(b.Offset, b.Offset);
                    var RightUpCorner = new PointF(size.Width - b.Offset, b.Offset);
                    var LeftDownCorner = new PointF(b.Offset, size.Height - b.Offset);
                    var RightDownCorner = new PointF(size.Width - b.Offset, size.Height - b.Offset);
                    result.StartFigure();
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X + 10, LeftUpCorner.Y));
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X, LeftUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X - 10, RightUpCorner.Y));
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X, RightUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X + 10, LeftDownCorner.Y));
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X, LeftDownCorner.Y - 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X - 10, RightDownCorner.Y));
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X, RightDownCorner.Y - 10));
                    result.CloseFigure();
                    float w = 0;
                    float h = 0;
                    for (var i = 1; i <= wcount; i++)
                    {
                        w += 22;
                        result.StartFigure();
                        result.AddLine(w, b.Offset, w + 10, b.Offset);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(w, size.Height - b.Offset, w + 10, size.Height - b.Offset);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(w + 15, b.Offset, w + 2 + 15, b.Offset);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(w + 15, size.Height - b.Offset, w + 2 + 15, size.Height - b.Offset);
                        result.CloseFigure();
                    }
                    for (var i = 1; i <= hcount; i++)
                    {
                        h += 22;
                        result.StartFigure();
                        result.AddLine(b.Offset, h, b.Offset, h + 10);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(size.Width - b.Offset, h, size.Width - b.Offset, h + 10);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(b.Offset, h + 15, b.Offset, h + 2 + 15);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(size.Width - b.Offset, h + 15, size.Width - b.Offset, h + 2 + 15);
                        result.CloseFigure();
                    }
                }
                    break;
                case DocumentBorderStyle.LongDash:
                {
                    var wcount = (int) ((size.Width - b.Offset * 2) / 40);
                    var hcount = (int) ((size.Height - b.Offset * 2) / 40);
                    var LeftUpCorner = new PointF(b.Offset, b.Offset);
                    var RightUpCorner = new PointF(size.Width - b.Offset, b.Offset);
                    var LeftDownCorner = new PointF(b.Offset, size.Height - b.Offset);
                    var RightDownCorner = new PointF(size.Width - b.Offset, size.Height - b.Offset);
                    result.StartFigure();
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X + 10, LeftUpCorner.Y));
                    result.AddLine(LeftUpCorner, new PointF(LeftUpCorner.X, LeftUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X - 10, RightUpCorner.Y));
                    result.AddLine(RightUpCorner, new PointF(RightUpCorner.X, RightUpCorner.Y + 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X + 10, LeftDownCorner.Y));
                    result.AddLine(LeftDownCorner, new PointF(LeftDownCorner.X, LeftDownCorner.Y - 10));
                    result.CloseFigure();
                    result.StartFigure();
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X - 10, RightDownCorner.Y));
                    result.AddLine(RightDownCorner, new PointF(RightDownCorner.X, RightDownCorner.Y - 10));
                    result.CloseFigure();
                    float w = 0;
                    float h = 0;
                    for (var i = 1; i <= wcount; i++)
                    {
                        w += 40;
                        result.StartFigure();
                        result.AddLine(w, b.Offset, w + 20, b.Offset);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(w, size.Height - b.Offset, w + 20, size.Height - b.Offset);
                        result.CloseFigure();
                    }
                    for (var i = 1; i <= hcount; i++)
                    {
                        h += 40;
                        result.StartFigure();
                        result.AddLine(b.Offset, h, b.Offset, h + 20);
                        result.CloseFigure();
                        result.StartFigure();
                        result.AddLine(size.Width - b.Offset, h, size.Width - b.Offset, h + 20);
                        result.CloseFigure();
                    }
                }
                    break;
            }
            _lastRenderResult = result;
            _lastRenderSizeF = size;
            _lastRenderBorder = b;
            return result;
        }
    }
}
