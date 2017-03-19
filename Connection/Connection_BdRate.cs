/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

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
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

using System;
using System.Linq;

namespace CWA.Connection
{
    /// <summary>
    /// Предоставляет информацию о скорости соеденения с платой.
    /// </summary>
    public struct BdRate
    {
        /// <summary>
        /// Скорость соеденения.
        /// </summary>
        private readonly int _num;

        /// <summary>
        /// Самые распространенные варианты скоростей.
        /// </summary>
        private static readonly string[] _names = { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "38400", "56000", "57600", "115200" };
        
        /// <summary>
        /// Преобразует экземпляр BdRate к соотвествующему string.
        /// </summary>
        public override string ToString()
        {
            return "bd" + _num;
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
        /// Оператор явного приведения класса BdRate к int.
        /// </summary>
        /// <param name="a">Операнд для приведения.</param>
        public static implicit operator int(BdRate a)
        {
            return a._num;
        }

        /// <summary>
        /// Оператор явного приведения класса BdRate к string.
        /// </summary>
        /// <param name="a">Операнд для приведения.</param>
        public static implicit operator string(BdRate a)
        {
            return a.ToString();
        }

        /// <summary>
        /// Оператор явного приведения класса string к BdRate.
        /// </summary>
        /// <param name="a">Операнд для приведения.</param>
        public static implicit operator BdRate(string a)
        {
            return new BdRate(a);
        }

        /// <summary>
        /// Создает новый езмемпляр класса BdRate.
        /// </summary>
        /// <param name="num">Скорость соеденения.</param>
        public BdRate(int num)
        {
            _num = num;
        }

        /// <summary>
        /// Создает новый езмемпляр класса BdRate.
        /// </summary>
        /// <param name="num">Скорость соеденения в строковом формате.</param>
        public BdRate(string num)
        {
            if (!num.ToLower().StartsWith("bd")) throw new ArgumentException("Чтото не так с именем скорости", nameof(num));
            _num = int.Parse(num.ToLower().Remove(0, 2));
        }
    }
}
