/*=================================\
* CWA.Vectors\VectorIncludeFile.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;
using System.Collections.Generic;

namespace CWA.Vectors
{
    /// <summary>
    /// Класс-оболочка для сериализации файла.
    /// Хранит основную информацию о файлах данного архива.
    /// </summary>
    [Serializable]
    internal class VectorIncludeFile
    {
        /// <summary>
        /// Коллекция файлов.
        /// </summary>
        public List<VectorIncludeFileItem> Items;

        /// <summary>
        /// Создает новый экзепляр класса <see cref="VectorIncludeFile"/>.
        /// </summary>
        public VectorIncludeFile() { }
    }
}
