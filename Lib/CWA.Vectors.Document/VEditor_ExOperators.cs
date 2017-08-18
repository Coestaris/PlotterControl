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
* CWA.Vectors.Document \ VEditor_ExOperators.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:23:27
*
*=================================*/

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// ������������� �������������� ������ ��� ���������� <see cref="Document"/>.
    /// </summary>
    public class ExOperators
    {
        /// <summary>
        /// ������� PictureBox �� ������ ���������� ��������.
        /// </summary>
        /// <param name="pb">PictureBox ��� ��������.</param>
        /// <param name="img">����������� ��� ��������� � PictureBox.</param>
        /// <param name="angle">���� ��������.</param>
        public static void RotatePB(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null) return;
            var oldImage = pb.Image;
            pb.Image = RotateImage(img, angle);
            if (oldImage != null)
                oldImage.Dispose();
        }

        /// <summary>
        /// ������� ����������� ������������ ������.
        /// </summary>
        /// <param name="image">����������� ��� ��������.</param>
        /// <param name="angle">���� ��������.</param>
        private static Bitmap RotateImage(Image image, float angle)
        {
            return RotateImage(image, new PointF((float) image.Width / 2, (float) image.Height / 2), angle);
        }

        /// <summary>
        /// ������� �����������.
        /// </summary>
        /// <param name="image">����������� ��� ��������.</param>
        /// <param name="offset">�������� �� ������.</param>
        /// <param name="angle">���� ��������.</param>
        private static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            var rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            var g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));
            return rotatedBmp;
        }

        /// <summary>
        /// �������� ������ �� ��������� �������, ���� ��� ������, �� � ����� ��������� "...".
        /// </summary>
        /// <param name="s">������ ��� �������</param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(string s, int length)
        {
            if (s.Length > length) return new string(s.ToList().GetRange(0, length).ToArray()) + "...";
            return s;
        }

        /// <summary>
        /// ���������� �������������� ������� ������������ �� ������.
        /// </summary>
        /// <typeparam name="T">��� ������������.</typeparam>
        /// <param name="source">��� �������� � ��������� �������������.</param>
        public static T GetEnum<T>(string source)
        {
            return (T) Enum.Parse(typeof(T), source);
        }

        /// <summary>
        /// �������� ���������� ����� �� �����������.
        /// </summary>
        /// <param name="p">����� ��� ���������.</param>
        /// <param name="num">����������� ���������.</param>
        /// <returns>����� � ����������� ������������.</returns>
        public static PointF multPoint(PointF p, float num)
        {
            return new PointF(p.X * num, p.Y * num);
        }
    }
}
