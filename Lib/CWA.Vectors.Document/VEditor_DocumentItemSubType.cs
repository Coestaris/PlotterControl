/*=================================\
* CWA.Vectors.Document\VEditor_DocumentItemSubType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 01.07.2017 13:09:58
*=================================*/

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Описывает подтип объектов.
    /// </summary>
    public enum DocumentItemSubType
    {
        /// <summary>
        /// Прямая (отрезок).
        /// </summary>
        Line,

        /// <summary>
        /// Эллипс (в большенстве случаев круг).
        /// </summary>
        Circle,

        /// <summary>
        /// Квадрат (4х угольник).
        /// </summary>
        Square
    }
}
