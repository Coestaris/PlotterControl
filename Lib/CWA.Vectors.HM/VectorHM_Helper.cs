/*=================================\
* CWA.Vectors.HM\VectorHM_Helper.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System.Drawing;

namespace CWA.Vectors
{
    /// <summary>
    /// Описывает дополнительные методы для библиотеки VectorHM.
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// Получает среднее значение каждого канала цвета.
        /// </summary>
        /// <param name="c">Цвет для выполнения операции.</param>
        public static byte GetAverageColor(Color c)
        {
            return (byte)((c.R + c.B + c.G) / 3);
        }

        /// <summary>
        /// Получает новый цвет с равными значениями по каждому каналу.
        /// </summary>
        /// <param name="b">Значение для выполнения операции.</param>
        public static Color NewOneChColor(byte b)
        {
            return Color.FromArgb(b, b, b);
        }
    }
}
