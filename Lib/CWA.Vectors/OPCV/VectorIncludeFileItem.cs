/*=================================\
* CWA.Vectors\VectorIncludeFileItem.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:30
* Last Edited: 26.08.2017 16:44:00
*=================================*/

using System;

namespace CWA.Vectors
{ 
    /// <summary>
    /// Класс-оболочка для сериализации файла.
    /// Хранит основную информацию файле архива.
    /// </summary>
    [Serializable]
    public class VectorIncludeFileItem
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        public string FileName;

        /// <summary>
        /// Тип файла.
        /// </summary>
        public VectorFileType Type;

        /// <summary>
        /// Создает новый экзепляр класса <see cref="VectorIncludeFileItem"/>.
        /// </summary>
        public VectorIncludeFileItem() { }
    }
}
