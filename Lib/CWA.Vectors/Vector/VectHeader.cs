/*=================================\
* CWA.Vectors\VectHeader.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:31
* Last Edited: 29.08.2017 16:39:54
*=================================*/

using System.Collections.Generic;

namespace CWA.Vectors
{
    /// <summary>
    /// Предоставляет информацию о векторе.
    /// </summary>
    public class VectHeader
    {
        /// <summary>
        /// Отображаемое имя вектора.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Ширина вектора.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота вектора.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Тип получения вектора.
        /// </summary>
        public VectType VectType { get; set; }

        /// <summary>
        /// Количество контуров вектора.
        /// </summary>
        public int CountOfCont { get; set; }

        /// <summary>
        /// Дополнительные параметеры вектора.
        /// </summary>
        public Dictionary<string, string> ExParams { get;  set; }

        /// <summary>
        /// Формат файла, который использовался при загруке. По умолчанию - <see cref="VectorFileFormat.OPCV"/>.
        /// </summary>
        public VectorFileFormat FileFormat { get; internal set; } = VectorFileFormat.OPCV;

        /// <summary>
        /// Оператор сравнения хедеров.
        /// </summary>
        public static bool operator ==(VectHeader a, VectHeader b)
        {
            return a.VectType == b.VectType 
                && a.Width == b.Width 
                && a.Height == b.Height
                && a.CountOfCont == b.CountOfCont
                && a.ExParams == b.ExParams
                && a.Name == b.Name;
        }

        /// <summary>
        /// Оператор неравенства хедеров.
        /// </summary>
        public static bool operator !=(VectHeader a, VectHeader b)
        {
            return a.VectType != b.VectType
                || a.Width != b.Width
                || a.Height != b.Height
                || a.CountOfCont != b.CountOfCont
                || a.ExParams != b.ExParams
                || a.Name != b.Name;
        }

        /// <summary>
        /// Сравнивает данный хедер с obj.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this == (VectHeader)obj;
        }

        /// <summary>
        /// Возвращает хеш-код класса.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
