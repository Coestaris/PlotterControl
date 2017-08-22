/*=================================\
* CWA.Vectors.Document\VEditor_DocumentItem.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 22.08.2017 20:22:36
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
