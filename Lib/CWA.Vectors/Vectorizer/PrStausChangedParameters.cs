/*=================================\
* CWA.Vectors\PrStausChangedParameters.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:32
* Last Edited: 19.08.2017 7:38:22
*=================================*/

namespace CWA.Vectors
{
    /// <summary>
    /// Класс, сорержащий информацию о изменении статуса векторизации.
    /// </summary>
    public class PrStausChangedParameters
    {
        /// <summary>
        /// Общее количество операций.
        /// </summary>
        public int MaxValue { get; internal set; }

        /// <summary>
        /// Выполненное количество операций.
        /// </summary>
        public int Value { get; internal set; }

        /// <summary>
        /// Процент выполнения векторизации.
        /// </summary>
        public int Percentage
        {
            get { return (int)(MaxValue / 100.0 * Value); }
        }

        /// <summary>
        /// Создает новый екземпляр класса <see cref="PrStausChangedParameters"/>.
        /// </summary>
        /// <param name="maxvalue">Общее количество операций</param>
        /// <param name="value">Количество выполненных операций</param>
        internal PrStausChangedParameters(int maxvalue, int value)
        {
            MaxValue = maxvalue;
            Value = value;
        }
    }
}
