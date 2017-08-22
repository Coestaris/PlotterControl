/*=================================\
* CWA.Vectors.Document\VEditor_DocumentBorderStyle.cs
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
    /// Описывает тип визуальной границы документа.
    /// </summary>
    public enum DocumentBorderStyle
    {
        /// <summary>
        /// Пустая (не отображать).
        /// </summary>
        None,
        
        /// <summary>
        /// Прямая из последовательных точек.
        /// </summary>
        Dot,

        /// <summary>
        /// Прямая из последовательных тире.
        /// </summary>
        Dash,

        /// <summary>
        /// Прямая из последовательных, удлененных тире.
        /// </summary>
        LongDash,

        /// <summary>
        /// Прямая из последовательных, чередующихся тире и точек.
        /// </summary>
        DashDot,

        /// <summary>
        /// Монолитная прямая линия.
        /// </summary>
        Default,

        /// <summary>
        /// Монолитная двойная прямая линия.
        /// </summary>
        DoubleLine,

        /// <summary>
        /// Монолитная тройная прямая линия.
        /// </summary>
        TripleLine,

        /// <summary>
        /// Монолитная волнистая линия.
        /// </summary>
        Wave,

        /// <summary>
        /// Монолитная двойная волнистая линия.
        /// </summary>
        DoubleWave,

        /// <summary>
        /// Небольшые четыре триугольника(угла) в углах документа.
        /// </summary>
        Triangle,

        /// <summary>
        /// Небольшые четыре сдвоенные триугольника(угла) в углах документа.
        /// </summary>
        DoubleTriangle
    }
}
