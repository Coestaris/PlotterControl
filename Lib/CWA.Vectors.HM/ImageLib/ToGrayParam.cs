/*=================================\
* CWA.Vectors.HM\ToGrayParam.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:41
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System.Collections.Generic;
using System.Drawing;

namespace CWA.Vectors
{
    /// <summary>
    /// Описывает параметры для выполнения многопоточной операции преобразования в черно-белый формат.
    /// </summary>
    internal class ToGrayParam
    {
        /// <summary>
        /// Изображение для обработки.
        /// </summary>
        public Bitmap Bmp;

        /// <summary>
        /// Ссылка на словарь всех изображений.
        /// </summary>
        public @Dictionary<int, Bitmap> Res;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ToGrayParam"/>.
        /// </summary>
        /// <param name="b">Изображение для выполнения операций.</param>
        /// <param name="res">Ссылка на словарь остальных значений.</param>
        public ToGrayParam(Bitmap b, @Dictionary<int, Bitmap> res)
        {
            Bmp = b;
            Res = res;
        }
    }
}
