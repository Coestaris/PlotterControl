/*=================================\
* CWA.Vectors.Document\VEditor_DocumentText.cs
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
    /// Описывает объект текстовой строки или абзаца, который наследуется от <see cref="DocumentItem"/>.
    /// </summary>
    public class DocumentText : DocumentItem
    {
        /// <summary>
        /// Шрифт текста.
        /// </summary>
        public Font Font { get; internal set; }

        /// <summary>
        /// Значение текста (сам текст).
        /// </summary>
        public string Caption { get; internal set; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentText"/>.
        /// </summary>
        /// <param name="position">Позиция объекта.</param>
        /// <param name="size">Размер объекта.</param>
        /// <param name="text">Содержимое строки.</param>
        /// <param name="f">Шрифт объекта.</param>
        public DocumentText(PointF position, SizeF size, string text, Font f)
        {
            Position = position;
            Size = size;
            Caption = text;
            Font = f;
            Type = DocumentItemType.Text;
        }

        /// <summary>
        /// Перерисовует объект.
        /// </summary>
        public override void PreRenderPath()
        {
            GrPath = new GraphicsPath(FillMode.Winding);
            GrPath.AddString(Caption, Font.FontFamily, (int) Font.Style, Font.Size, Position, new StringFormat());
        }
    }
}
