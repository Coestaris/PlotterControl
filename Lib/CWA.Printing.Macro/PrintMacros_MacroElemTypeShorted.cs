/*=================================\
* CWA.Printing.Macro\PrintMacros_MacroElemTypeShorted.cs
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
    /// ќписывает тип макроса, в сокращенном виде, удобном дл€ хранени€ в файле. 
    /// ¬се варианты - эквиваленты вариантам перечислени€ MacroElemType.
    /// </summary>
    public enum MacroElemTypeShorted
    {
        /// <summary>
        /// Ёквивалент: MacroElemType.Tool. “олько перемещение пера (вверх/вниз).
        /// </summary>
        T,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveToPoint. ѕеремещение инструмента в конкретную точку.
        /// </summary>
        MTP,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveRelative. —мещение инструмента на заданную дельту.
        /// </summary>
        MR,

        /// <summary>
        /// Ёквивалент: MacroElemType.Delay. “олько задержка.
        /// </summary>
        D,

        /// <summary>
        /// Ёквивалент: MacroElemType.None. Ќичего не делать.
        /// </summary>
        N,

        /// <summary>
        /// Ёквивалент: MacroElemType.ToolAndDelay. ѕеремещение пера (вверх/вниз) с задержкой после.
        /// </summary>
        TAD,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveToPointAndDelay. ѕеремещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MTPAD,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveRelativeAndDelay. ѕеремещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MRAD
    }
}
