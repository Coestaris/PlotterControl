/*=================================\
* CWA.Connection\BdRate.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:38
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;
using System.Linq;

namespace CWA.Connection
{
    /// <summary>
    /// Предоставляет информацию о скорости соеденения с платой.
    /// </summary>
    [Serializable]
    public class BdRate
    {
        /// <summary>
        /// Скорость соеденения.
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// Самые распространенные варианты скоростей.
        /// </summary>
        private static readonly string[] _names = { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "38400", "56000", "57600", "115200" };
        
        /// <summary>
        /// Преобразует экземпляр BdRate к соотвествующему <see cref="string"/>.
        /// </summary>
        public override string ToString()
        {
            return "bd" + Num;
        }

        /// <summary>
        /// Предоставляет список самых распространенных вариантов скоростей, в целочисленном формате.
        /// </summary>
        public static int[] GetNamesInt()
        {
            return _names.Cast<int>().ToArray();
        }

        /// <summary>
        /// Предоставляет список самых распространенных вариантов скоростей, в строковом формате.
        /// </summary>
        public static string[] GetNamesStrings()
        {
            return _names.Select(p => "bd" + p).ToArray();
        }

        /// <summary>
        /// Предоставляет список самых распространенных вариантов скоростей.
        /// </summary>
        public static BdRate[] GetNames()
        {
            return _names.Cast<BdRate>().ToArray();
        }

        /// <summary>
        /// Оператор явного приведения класса <see cref="BdRate"/> к <see cref="int"/>.
        /// </summary>
        /// <param name="a">Операнд для приведения.</param>
        public static implicit operator int(BdRate a)
        {
            return a.Num;
        }

        /// <summary>
        /// Оператор явного приведения класса <see cref="BdRate"/> к <see cref="string"/>.
        /// </summary>
        /// <param name="a">Операнд для приведения.</param>
        public static implicit operator string(BdRate a)
        {
            return a.ToString();
        }

        /// <summary>
        /// Оператор явного приведения класса string к <see cref="BdRate"/>.
        /// </summary>
        /// <param name="a">Операнд для приведения.</param>
        public static implicit operator BdRate(string a)
        {
            return new BdRate(a);
        }

        /// <summary>
        /// Создает новый езмемпляр класса <see cref="BdRate"/>.
        /// </summary>
        /// <param name="num">Скорость соеденения.</param>
        public BdRate(int num)
        {
            Num = num;
        }

        /// <summary>
        /// Создает новый езмемпляр класса <see cref="BdRate"/>.
        /// </summary>
        public BdRate() { }
        
        /// <summary>
        /// Создает новый езмемпляр класса <see cref="BdRate"/>.
        /// </summary>
        /// <param name="num">Скорость соеденения в строковом формате.</param>
        public BdRate(string num)
        {
            if (!num.ToLower().StartsWith("bd")) throw new ArgumentException("Чтото не так с именем скорости", nameof(num));
            Num = int.Parse(num.ToLower().Remove(0, 2));
        }
    }
}
