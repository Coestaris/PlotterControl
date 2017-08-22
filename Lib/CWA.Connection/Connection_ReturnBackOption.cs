/*=================================\
* CWA.Connection\Connection_ReturnBackOption.cs
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
    /// Определяет действие в конце печати (после конца).
    /// </summary>
    public enum ReturnBackOption
    {
        /// <summary>
        /// Вернуть перо в нулевую точку (та, с которой началась печать).
        /// </summary>
        ReturnToZero,

        /// <summary>
        /// Оставить перо там, где она стояло.
        /// </summary>
        StayAtEnd
    }
}
