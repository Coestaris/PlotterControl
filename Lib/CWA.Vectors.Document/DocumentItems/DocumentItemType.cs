/*=================================\
* CWA.Vectors.Document\DocumentItemType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:32
* Last Edited: 01.07.2017 13:09:58
*=================================*/

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Описывает тип объекта.
    /// </summary>
    public enum DocumentItemType
    {
        /// <summary>
        /// Изображение (вектор).
        /// </summary>
        Image,

        /// <summary>
        /// Фигура. Если тип объекта фигура, то свойство класса SubType описывает что это за фигура.
        /// </summary>
        Shape,

        /// <summary>
        /// Текстовая строка или абзац.
        /// </summary>
        Text
    }
}
