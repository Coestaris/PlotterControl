/*=================================\
* CWA.Vectors\VectorFileInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:30
* Last Edited: 26.08.2017 16:43:36
*=================================*/

using System;

namespace CWA.Vectors
{
    /// <summary>
    /// Класс-оболочка для сериализации файла.
    /// Хранит основную информацию о векторе.
    /// </summary>
    [Serializable]
    public class VectorFileInfo
    {
        /// <summary>
        /// Ширина вектора.
        /// </summary>
        public UInt16 Width;

        /// <summary>
        /// Высота вектора.
        /// </summary>
        public UInt16 Height;

        /// <summary>
        /// Тип вектора.
        /// </summary>
        public VectType VectType;

        /// <summary>
        /// Отображаемое имя вектора.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// Приведение данного экзепляра к <see cref="VectHeader"/>.
        /// </summary>
        public VectHeader ToHeader()
        {
            return new VectHeader()
            {
                CountOfCont = 0,
                Height = Height,
                Name = DisplayName,
                Width = Width
            };
        }

        /// <summary>
        /// Создает новый экзепляр класса <see cref="VectorFileInfo"/>.
        /// </summary>
        public VectorFileInfo() { }
    }
}
