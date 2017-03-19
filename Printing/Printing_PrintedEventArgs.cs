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
using System.Drawing;

namespace CWA.Printing
{
    /// <summary>
    /// Параметры изменения статуса печати.
    /// </summary>
    public class PrintedEventArgs : EventArgs
    {
        /// <summary>
        /// Приватный параметр. Общее количество построений.
        /// </summary>
        private long _countTotal;

        /// <summary>
        /// Приватный параметр. Выполненно построений.
        /// </summary>
        private long _countDone;

        /// <summary>
        /// Приватный параметр. Обработанная точка.
        /// </summary>
        private Point _drawedPoint;

        /// <summary>
        /// Общее количество построений.
        /// </summary>
        public long CountTotal
        {
            get { return _countTotal;  }
            set { _countTotal = value; }
        }

        /// <summary>
        /// Выполненно построений.
        /// </summary>
        public long CountDone
        {
            get { return _countDone;  }
            set { _countDone = value; }
        }

        /// <summary>
        /// Обработанная точка.
        /// </summary>
        public Point DrawedPoint
        {
            get { return _drawedPoint;  }
            set { _drawedPoint = value; }
        }

        /// <summary>
        /// Создает новый экземпляр класса PrintedEventArgs.
        /// </summary>
        /// <param name="to">Общее кол-во построений.</param>
        /// <param name="done">Выолненно построений.</param>
        /// <param name="pnt">Обработанная точка.</param>
        internal PrintedEventArgs(int to, int done, Point pnt)
        {
            DrawedPoint = pnt;
            CountDone = done;
            CountTotal = to;
        }
    }
}
