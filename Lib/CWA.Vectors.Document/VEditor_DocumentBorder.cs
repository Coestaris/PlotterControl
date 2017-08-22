/*=================================\
* CWA.Vectors.Document\VEditor_DocumentBorder.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 01.07.2017 13:09:58
*=================================*/

using System;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Предоставляет информацию о границе документа.
    /// </summary>
    public class DocumentBorder : ICloneable
    {
        /// <summary>
        /// Сдвиг границы от края документа.
        /// </summary>
        public float Offset { get; set; }

        /// <summary>
        /// Стиль границы.
        /// </summary>
        public DocumentBorderStyle Style { get; set; }

        /// <summary>
        /// Использовать ли границу.
        /// </summary>
        public bool Use { get; set; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentBorder"/>.
        /// </summary>
        /// <param name="offset">Сдвиг границы от краев документа.</param>
        /// <param name="style"> Стиль границы.</param>
        /// <param name="use">Использовать ли границу.</param>
        public DocumentBorder(float offset, DocumentBorderStyle style, bool use)
        {
            Offset = offset;
            Style = style;
            Use = use;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="DocumentBorder"/>.
        /// </summary>
        public DocumentBorder() { }

        /// <summary>
        /// Клонирует данный экземпляр.
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
