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

namespace CWA.Printing
{
    /// <summary>
    /// Параметры содержащие информацию о изменении статуса обработки данных.
    /// </summary>
    public class TimeEventArgs : EventArgs
    {
        /// <summary>
        /// Приватный параметр. Времени прошло с начала печати.
        /// </summary>
        private float _timeSpend;

        /// <summary>
        /// Приватный параметр. Примерно осталось времени до конца печати.
        /// </summary>
        private float _timeLeft;

        /// <summary>
        /// Приватный параметр. Время начала печати.
        /// </summary>
        private DateTime _startTime;
        
        /// <summary>
        /// Времени прошло с начала печати.
        /// </summary>
        public float TimeSpend
        {
            get { return _timeSpend; }
            set { _timeSpend = value; }
        }

        /// <summary>
        /// Примерно осталось времени до конца печати.
        /// </summary>
        public float TimeLeft
        {
            get { return _timeLeft; }
            set { _timeLeft = value; }
        }

        /// <summary>
        /// Время начала печати.
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// Создает новый экземпляр класса TimeEventArgs.
        /// </summary>
        /// <param name="timeLeft">Прошло времени с начала печати.</param>
        /// <param name="timeSpend">Осталось времени до конца печати.</param>
        /// <param name="startTime">Начало печати.</param>
        public TimeEventArgs(float timeLeft, float timeSpend, DateTime startTime)
        {
            TimeLeft = timeLeft;
            TimeSpend = timeSpend;
            StartTime = startTime;
        }
    }
}
