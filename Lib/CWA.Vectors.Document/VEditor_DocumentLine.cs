/*=================================\
* CWA.Vectors.Document\VEditor_DocumentLine.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 01.07.2017 13:09:58
*=================================*/

using System.Drawing;
using System.Drawing.Drawing2D;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Описывает объект прямой, который наследуется от <see cref="DocumentItem"/>.
    /// </summary>
    public class DocumentLine : DocumentItem
    {
        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentLine"/>.
        /// </summary>
        /// <param name="position">Позиция объекта.</param>
        /// <param name="p1">Первая точка прямой.</param>
        /// <param name="p2">Вторая точка прямой.</param>
        public DocumentLine(PointF position, PointF p1, PointF p2)
        {
            Position = position;
            Pos1 = p1;
            Pos2 = p2;
            Type = DocumentItemType.Shape;
        }

        /// <summary>
        /// Первая точка прямой.
        /// </summary>
        public PointF Pos1 { get; internal set; }

        /// <summary>
        /// Вторая точка прямой.
        /// </summary>
        public PointF Pos2 { get; internal set; }

        /// <summary>
        /// Перерисовует объект.
        /// </summary>
        public override void PreRenderPath()
        {
            GrPath = new GraphicsPath(FillMode.Winding);
            GrPath.AddLine(Pos1, Pos1);
        }
    }
}
