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
        /// ��������� ��������. ���� ������� ������� ������������ ������ � ��������.
        /// </summary>
        private float _angle;

        /// <summary>
        /// ��������� ��������. ���� ����������� � ���������.
        /// </summary>
        private Color _dispcolor;

        /// <summary>
        /// ��������� ��������. ������������� ������� � ���� ������ GraphicsPath.
        /// </summary>
        private GraphicsPath _grPath;

        /// <summary>
        /// ��������� ��������.  ��� �������. � ��������� ������� ���� ���������!
        /// ��� ��� �� ��� �� ���� �� ������ (�� ����� �����), �� ������ �����������.
        /// </summary>
        private string _name;

        /// <summary>
        /// ��������� ��������.  ������� ������� � ���������.
        /// </summary>
        private PointF _position;

        /// <summary>
        /// ��������� ��������. ������ ������� (� ���������� ������� ��������������� ���).
        /// </summary>
        private SizeF _size;

        /// <summary>
        /// ��������� ��������.  ������ ������� (� ���������� ������� ��������������� ���).
        /// </summary>
        private DocumentItemType _type;

        /// <summary>
        /// ��������� ��������.  �������� �� � ��������� ������ ������ ������ DispColor.
        /// </summary>
        private bool _usecdispcolor = false;

        /// <summary>
        /// ���� ������� ������� ������������ ������ � ��������.
        /// </summary>
        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        /// <summary>
        /// ���� ����������� � ���������.
        /// </summary>
        public Color DispColor
        {
            get { return _dispcolor; }
            set { _dispcolor = value; }
        }

        /// <summary>
        /// ������������� ������� � ���� ������ GraphicsPath.
        /// </summary>
        public GraphicsPath GrPath
        {
            get { return _grPath; }
            set { _grPath = value; }
        }

        /// <summary>
        /// ��� �������. � ��������� ������� ���� ���������!
        /// ��� ��� �� ��� �� ���� �� ������ (�� ����� �����), �� ������ �����������.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// ������� ������� � ���������.
        /// </summary>
        public PointF Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// ������ ������� (� ���������� ������� ��������������� ���).
        /// </summary>
        public SizeF Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// ��� �������.
        /// </summary>
        public DocumentItemType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// �������� �� � ��������� ������ ������ ������ DispColor.
        /// </summary>
        public bool UseDispColor
        {
            get { return _usecdispcolor; }
            set { _usecdispcolor = value; }
        }

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
            _grPath.Transform(m);
        }

        /// <summary>
        /// �������� ������ � ���� GraphicsPath.
        /// </summary>
        public virtual void PreRenderPath()
        {
            _grPath = null;
        }

        /// <summary>
        /// ���������� ������������� 
        /// </summary>
        /// <returns></returns>
        public virtual GraphicsPath Render()
        {
            return _grPath;
        }

        /// <summary>
        /// ���������� ������ � ������.
        /// </summary>
        /// <param name="obj">������ ������ ��� ���������.</param>
        /// <returns>true ���� ��� ���������.</returns>
        public override bool Equals(object obj)
        {
            var item = obj as DocumentItem;
            if (_name == item._name && Position == item.Position && Type == item.Type && Size == item.Size &&
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