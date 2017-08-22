/*=================================\
* CWA.Vectors\VectType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:31
* Last Edited: 19.08.2017 7:38:22
*=================================*/

namespace CWA.Vectors
{
    /// <summary>
    /// Предоставляет информацию о происхождении вектора
    /// </summary>
    public enum VectType
    {
        /// <summary>
        /// Получен, как результат векторизации
        /// </summary>
        Rastr,

        /// <summary>
        /// Получен с мат. функции или выражения
        /// </summary>
        Func,

        /// <summary>
        /// Заданая (заранее) кривая или фигура
        /// </summary>
        Curve,

        /// <summary>
        /// Импортированный с .SVG вектор
        /// </summary>
        SvgVector
    }
}
