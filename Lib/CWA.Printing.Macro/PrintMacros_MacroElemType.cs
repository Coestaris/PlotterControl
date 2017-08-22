/*=================================\
* CWA.Printing.Macro\PrintMacros_MacroElemType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 01.07.2017 13:09:58
*=================================*/

namespace CWA.Printing.Macro
{
    /// <summary>
    /// Описывает тип макроса.
    /// </summary>
    public enum MacroElemType
    {
        /// <summary>
        /// Только перемещение пера (вверх/вниз).
        /// </summary>
        Tool,

        /// <summary>
        /// Перемещение инструмента в конкретную точку.
        /// </summary>
        MoveToPoint,

        /// <summary>
        /// Смещение инструмента на заданную дельту.
        /// </summary>
        MoveRelative,

        /// <summary>
        /// Только задержка.
        /// </summary>
        Delay,

        /// <summary>
        /// Ничего не делать.
        /// </summary>
        None,

        /// <summary>
        /// Перемещение пера (вверх/вниз) с задержкой после.
        /// </summary>
        ToolAndDelay,

        /// <summary>
        /// Перемещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MoveToPointAndDelay,

        /// <summary>
        /// Перемещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MoveRelativeAndDelay
    }
}
