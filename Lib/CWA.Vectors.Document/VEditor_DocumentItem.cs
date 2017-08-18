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
* CWA.Vectors.Document \ VEditor_DocumentItem.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:23:27
*
*=================================*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// ����������� ����� �������� ��������� ����������.
    /// </summary>
    public abstract class DocumentItem : ICloneable
    {
        /// <summary>
        /// ���� ������� ������� ������������ ������ � ��������.
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// ���� ����������� � ���������.
        /// </summary>
        public Color DispColor { get; set; }

        /// <summary>
        /// ������������� ������� � ���� ������ <see cref="GraphicsPath"/>.
        /// </summary>
        public GraphicsPath GrPath { get; set; }

        /// <summary>
        /// ��� �������. � ��������� ������� ���� ���������!
        /// ��� ��� �� ��� �� ���� �� ������ (�� ����� �����), �� ������ �����������.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ������� ������� � ���������.
        /// </summary>
        public PointF Position { get; set; }

        /// <summary>
        /// ������ ������� (� ���������� ������� ��������������� ���).
        /// </summary>
        public SizeF Size { get; set; }

        /// <summary>
        /// ��� �������.
        /// </summary>
        public DocumentItemType Type { get; set; }

        /// <summary>
        /// �������� �� � ��������� ������ ������ ������ <see cref="DispColor"/>.
        /// </summary>
        public bool UseDispColor { get; set; }

        /// <summary>
        /// ��������� ������.
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// �������� ������. ����� ������������ � ����������, ����� �������� ���������.
        /// </summary>
        public virtual void PreRender()
        {
            PreRenderPath();
            var m = new Matrix();
            m.RotateAt(Angle / 2, new PointF(Size.Width / 2 + Position.X, Size.Height / 2 + Position.Y));
            GrPath.Transform(m);
        }

        /// <summary>
        /// �������� ������ � ���� <see cref="GraphicsPath"/>.
        /// </summary>
        public virtual void PreRenderPath()
        {
            GrPath = null;
        }

        /// <summary>
        /// ���������� ������������� 
        /// </summary>
        /// <returns></returns>
        public virtual GraphicsPath Render()
        {
            return GrPath;
        }

        /// <summary>
        /// ���������� ������ � ������.
        /// </summary>
        /// <param name="obj">������ ������ ��� ���������.</param>
        /// <returns>true ���� ��� ���������.</returns>
        public override bool Equals(object obj)
        {
            var item = obj as DocumentItem;
            if (Name == item.Name && Position == item.Position && Type == item.Type && Size == item.Size &&
                Angle == item.Angle) return true;
            return false;
        }

        /// <summary>
        /// ���������� ���-��� ����.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
