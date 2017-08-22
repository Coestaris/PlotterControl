/*=================================\
* CWA.Vectors.Document\VEditor_DocumentData.cs
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
    /// Описывает объект вектора, который наследуется от <see cref="DocumentItem"/>.
    /// </summary>
    public class DocumentData : DocumentItem
    {
        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentData"/>.
        /// </summary>
        /// <param name="position">Позиция объекта.</param>
        /// <param name="d">Данные о векторе.</param>
        public DocumentData(PointF position, Vector d)
        {
            BaseData = d;
            Position = position;
            Size = d.SizeF;
        }

        /// <summary>
        /// Информация о векторе.
        /// </summary>
        public Vector BaseData { get; set; }

        /// <summary>
        /// Перерисовует объект.
        /// </summary>
        public override void PreRenderPath()
        {
            GrPath = new GraphicsPath(FillMode.Winding);
            for (var i = 0; i <= BaseData.RawData.Length - 1; i++)
                try { GrPath.AddPolygon(Vector.PointexToPoint(BaseData.RawData[i])); }
                catch {
                    //ignored
                }
        }
    }
}
