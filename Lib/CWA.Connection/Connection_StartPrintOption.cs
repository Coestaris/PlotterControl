/*=================================\
* CWA.Connection\Connection_StartPrintOption.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

namespace CWA.Printing
{
    /// <summary>
    /// Определяет действие в начале печати (до начала).
    /// </summary>
    public enum StartPrintOption
    {
        /// <summary>
        /// Ничего не делать.
        /// </summary>
        None,

        /// <summary>
        /// Поднять перо.
        /// </summary>
        ToolUp,

        /// <summary>
        /// Опустить перо.
        /// </summary>
        ToolDown,

        /// <summary>
        /// Поднять потом опустить перо.
        /// </summary>
        ToolUpDown,

        /// <summary>
        /// Опустить потом поднять перо.
        /// </summary>
        ToolDownUp
    }
}
