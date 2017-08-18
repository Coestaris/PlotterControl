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
* CWA.Connection \ Connection_ComPortName.cs
*
* Created: 17.06.2017 21:03
* Last Edited: 18.08.2017 20:23:24
*
*=================================*/

using System;
using System.IO.Ports;
using System.Linq;

namespace CWA.Connection
{
    /// <summary>
    /// Предоставляет информацию о имени порта.
    /// </summary>   
    [Serializable]
    public class ComPortName
    {
        /// <summary>
        /// Возвращает имена портов, подключенные в данный момент, в стоковом формате.
        /// </summary>
        public static string[] GetNamesStrings()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// Возвращает имена портов, подключенные в данный момент.
        /// </summary>
        public static ComPortName[] GetNames()
        {
            return SerialPort.GetPortNames().Cast<ComPortName>().ToArray();
        }

        /// <summary>
        /// Номер порта.
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// Оператор явного приведения класса <see cref="ComPortName"/> к <see cref="string"/>.
        /// </summary>
        /// <param name="a">Операнд приведения.</param>
        public static implicit operator string(ComPortName a)
        {
            return "COM" + a.Num;
        }

        /// <summary>
        /// Преобразует экземпляр <see cref="ComPortName"/> к <see cref="string"/>.
        /// </summary>
        public override string ToString()
        {
            return "COM" + Num;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ComPortName"/>. 
        /// </summary>
        /// <param name="s">Имя порта в строковом представлении.</param>
        public ComPortName(string s)
        {
            if (!s.ToLower().StartsWith("com"))
                throw new ArgumentException("Чтото не так с именем порта", nameof(s));
            var d = s.ToLower().Remove(0, 3);
            Num = int.Parse(d);
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ComPortName"/>. 
        /// </summary>
        /// <param name="s">Номер порта.</param>
        public ComPortName(int s)
        {
            Num = s;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="ComPortName"/>. 
        /// </summary>
        /// <param name="s">Номер порта.</param>
        public ComPortName() { }
    }
}
