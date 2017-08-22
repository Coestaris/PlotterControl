/*=================================\
* CWA.Vectors.Document\DocumentCirlce.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:32
* Last Edited: 22.08.2017 20:27:23
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
