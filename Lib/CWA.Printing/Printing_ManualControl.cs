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

using System.IO.Ports;
using System;

namespace CWA.Connection
{
    /// <summary>
    /// Предоставляет методы для ручного управление устройством.
    /// </summary>
    public class ManualControl
    {
        /// <summary>
        /// Команда "n шагов в лево".
        /// </summary>
        private const string Left = "0,-{0},0;";

        /// <summary>
        /// Команда "n шагов в право".
        /// </summary>
        private const string Right = "0,{0},0;";

        /// <summary>
        /// Команда "n шагов в вверх".
        /// </summary>
        private const string toolDown = "0,0,{0};";

        /// <summary>
        /// Команда "n шагов в вниз".
        /// </summary>
        private const string toolUp = "0,0,-{0};";

        /// <summary>
        /// Команда "n шагов в перед".
        /// </summary>
        private const string Up = "{0},0,0;";

        /// <summary>
        /// Команда "n шагов в назад".
        /// </summary
        private const string Down = "-{0},0,0;";

        /// <summary>
        /// Приватный параметр. Количество шагов за одну операцию.
        /// </summary>
        private int _step;

        /// <summary>
        /// Порт для подключения к устройству.
        /// </summary>
        private SerialPort sp;

        /// <summary>
        /// Количество шагов за одну операцию.
        /// </summary>
        public int Step
        {
            get { return _step;  }
            set { _step = value; }
        }

        /// <summary>
        /// Создает новый экземпляр класса ManualControl.
        /// </summary>
        /// <param name="pname">Имя порта.</param>
        /// <param name="bd">Скорость соеденения.</param>
        public ManualControl(string pname, int bd)
        {
            sp = new SerialPort(pname, bd);
            sp.Open();
        }

        /// <summary>
        /// Поднять перо.
        /// </summary>
        public void ToolUp()
        {
            sp.Write(string.Format(toolUp, GlobalOptions.StepHeightConst + GlobalOptions.UpKoof));
        }

        /// <summary>
        /// Опустить перо.
        /// </summary>
        public void ToolDown()
        {
            sp.Write(string.Format(toolDown, GlobalOptions.StepHeightConst));
        }

        /// <summary>
        /// Прервать соеденение, закрыть порт.
        /// </summary>
        public void Close()
        {
            sp.Close();
        }

        /// <summary>
        /// Переоткрыть порт (в случае ошибки).
        /// </summary>
        public void ReOpen()
        {
            sp.Open();
        }

        /// <summary>
        /// Смемтить инструмент.
        /// </summary>
        /// <param name="x">Смещение по оси X.</param>
        /// <param name="y">Смещение по оси Y.</param>
        /// <param name="z">Смещение по оси Z.</param>
        public void ToolMove(int x, int y, int z)
        {
            sp.Write(string.Format("{0},{1},{2};", x, y, z));
        }

        /// <summary>
        /// Сделать шаг с экземпляра ConsoleKeyInfo. 
        /// DownArrow - шаг назад, LeftArrow - шаг влево, UpArrow - шаг в перед, RightArrow - шаг в паво, W - шаг вверх, S - шаг вниз.
        /// </summary>
        /// <param name="k"></param>
        public void MakeStep(ConsoleKeyInfo k)
        {
            string command = "";
            switch (k.Key)
            {
                case ConsoleKey.DownArrow:
                    command = string.Format(Down, _step);
                    break;
                case ConsoleKey.LeftArrow:
                    command = string.Format(Left, _step);
                    break;
                case ConsoleKey.UpArrow:
                    command = string.Format(Up, _step);
                    break;
                case ConsoleKey.RightArrow:
                    command = string.Format(Right, _step);
                    break;
                case ConsoleKey.W:
                    command = string.Format(toolUp, _step);
                    break;
                case ConsoleKey.S:
                    command = string.Format(toolDown, _step);
                    break;
            }
            sp.Write(command);
        }
    }
}
