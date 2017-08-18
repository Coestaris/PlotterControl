/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:


	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.


	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.Vectors \ PrStausChangedParameters.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:23:26
*
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
