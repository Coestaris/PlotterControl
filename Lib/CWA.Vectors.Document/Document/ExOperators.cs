/*=================================\
* CWA.Vectors.Document\ExOperators.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:39
* Last Edited: 01.07.2017 13:09:58
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
