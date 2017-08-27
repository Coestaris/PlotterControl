/*=================================\
* CWA.Vectors\VectorPenInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:30
* Last Edited: 26.08.2017 16:44:00
*=================================*/

using System;
using System.Collections.Generic;

namespace CWA.Vectors
{
    /// <summary>
    /// Класс-оболочка для сериализации файла.
    /// Хранит основную информацию о перьях, использованных в данном векторе.
    /// </summary>
    [Serializable]
    public class VectorPenInfo
    {
        /// <summary>
        /// Коллекция перьев данного вектора.
        /// </summary>
        public Dictionary<string, string> Pens;

        /// <summary>
        /// Создает новый экзепляр класса <see cref="VectorPenInfo"/>.
        /// </summary>
        public VectorPenInfo() { }
    }
}
