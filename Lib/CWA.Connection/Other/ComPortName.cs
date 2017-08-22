/*=================================\
* CWA.Connection\ComPortName.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:38
* Last Edited: 19.08.2017 7:38:22
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
