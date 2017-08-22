/*=================================\
* CWA.Vectors\VectorFileFormat.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;

namespace CWA.Vectors
{
    /// <summary>
    /// Форматы, доступные для сохранения вектора.
    /// </summary>
    public enum VectorFileFormat
    {
        /// <summary>
        /// Старый формат векторов. Отличается простотой чтения и быстротой работы программ с ним, но занимает много дискового пространства. Не имеет возможности к расширению. 
        /// </summary>
        [Obsolete]
        PRRES = 2,

        /// <summary>
        /// Более оптимизированный формат чем <see cref="VectorFileFormat.PRRES"/>, занимает меньше дискового пространства, но медленее обрабатывается программами. Не имеет возможности к расширению. 
        /// </summary>
        [Obsolete]
        PCV = 1,

        /// <summary>
        /// Рекомендованный формат. Имеет гибкую структуру и возможность к расширению. Занимает меньше всего места на диске и обрабатывается приемлемо быстро.
        /// </summary>
        OPCV = 0
    }
}
