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
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace CWA.Connection
{
    /// <summary>
    /// Предоставляет методы для работы с памятью устройства.
    /// </summary>
    public partial class DeviceMemorySetup
    {
        /// <summary>
        /// Исключение, которое выбрасывается при превышении времени ожидания ответа от устройства.
        /// </summary>
        public class MemorySetupTimeoutException : Exception
        {
            /// <summary>
            /// Время, сколько прошло спустя запроса.
            /// </summary>
            public int Time { get; internal set; }

            /// <summary>
            /// Команда, котороя была отправленна последняя и скорее всего она привела к ошибке.
            /// </summary>
            public string Command { get; internal set; }

            /// <summary>
            /// Создает новый экземпляр класса <see cref="MemorySetupTimeoutException"/>.
            /// </summary>
            /// <param name="command">Команда, котороя была отправленна последняя и скорее всего она привела к ошибке.</param>
            /// <param name="time">Время, сколько прошло спустя запроса.</param>
            public MemorySetupTimeoutException(string command, int time)
            {
                Command = command;
                Time = time;
            }
        }

        /// <summary>
        /// Исключение, которое выбрасывается при неверном или пустом ответе с устройства.
        /// </summary>
        public class MemorySetupBadRespondException : Exception
        {
            /// <summary>
            /// Значение, что ожидалось.
            /// </summary>
            public string Excepted { get; internal set; }

            /// <summary>
            /// Значение, что было полученно.
            /// </summary>
            public string Recived { get; internal set; }

            /// <summary>
            /// Команда, котороя была отправленна последняя и скорее всего она привела к ошибке.
            /// </summary>
            public string Command { get; internal set; }

            /// <summary>
            /// Создает новый экземпляр класса <see cref="MemorySetupBadRespondException"/>.
            /// </summary>
            /// <param name="excepted">Значение, что ожидалось.</param>
            /// <param name="recived">Значение, что было полученно.</param>
            /// <param name="command">Команда, котороя была отправленна последняя и скорее всего она привела к ошибке.</param>
            public MemorySetupBadRespondException(string excepted, string recived, string command)
            {
                Excepted = excepted;
                Recived = recived;
                Command = command;
            }
        }

        /// <summary>
        /// Порт для взаемодействия с устройством.
        /// </summary>
        private SerialPort _sp;

        /// <summary>
        /// Получен ли ответ.
        /// </summary>
        private bool _getRespond;

        /// <summary>
        /// Ожидает ли ответа.
        /// </summary>
        private bool _waitForRespond;

        /// <summary>
        /// Ответ с устройства.
        /// </summary>
        private string _Respond;

        /// <summary>
        /// Бинд пина направления по оси Х или №00.
        /// </summary>
        public int XDir
        {
            get { return int.Parse(GetVal(Get_Pin_00, null)); }
            set { _qnToSend.Add(string.Format(Set_Pin_00, value)); }
        }

        /// <summary>
        /// Показания потонциометра.
        /// </summary>
        public int Speed
        {
            get { return int.Parse(GetVal(Get_Speed, null)); }
        }

        /// <summary>
        /// Бинд пина шага по оси Х или №01.
        /// </summary>
        public int XStep
        {
            get { return int.Parse(GetVal(Get_Pin_01, null)); }
            set { _qnToSend.Add(string.Format(Set_Pin_01, value)); }
        }

        /// <summary>
        /// Бинд пина направления по оси Y или №10.
        /// </summary>
        public int YDir
        {
            get { return int.Parse(GetVal(Get_Pin_10, null)); }
            set { _qnToSend.Add(string.Format(Set_Pin_10, value)); }
        }

        /// <summary>
        /// Бинд пина шага по оси Y или №11.
        /// </summary>
        public int YStep
        {
            get { return int.Parse(GetVal(Get_Pin_11, null)); }
            set { _qnToSend.Add(string.Format(Set_Pin_11, value)); }
        }


        /// <summary>
        /// Бинд пина направления по оси Z или №20.
        /// </summary>
        public int ZDir
        {
            get { return int.Parse(GetVal(Get_Pin_20, null)); }
            set { _qnToSend.Add(string.Format(Set_Pin_20, value)); }
        }

        /// <summary>
        /// Бинд пина шага по оси Z или №21.
        /// </summary>
        public int ZStep
        {
            get { return int.Parse(GetVal(Get_Pin_21, null)); }
            set { _qnToSend.Add(string.Format(Set_Pin_21, value)); }
        }

        /// <summary>
        /// Задержка в МС между шагами при рабочем ходе.
        /// </summary>
        public int WorkDelay
        {
            get { return int.Parse(GetVal(Get_Work, null)); }
            set { _qnToSend.Add(string.Format(Set_Work, value)); }
        }

        /// <summary>
        /// Задержка в МС между шагами при холостом ходе.
        /// </summary>
        public int IdleDelay
        {
            get { return int.Parse(GetVal(Get_Idle, null)); }
            set { _qnToSend.Add(string.Format(Set_Idle, value)); }
        }

        /// <summary>
        /// Параметр Pause или горит ли светодиод "Pause".
        /// </summary>
        public bool Pause
        {
            get { return int.Parse(GetVal(Get_Pause, null)) != 0; }
            set { _qnToSend.Add(string.Format(Set_Pause, value ? 1 : 0)); }
        }

        /// <summary>
        /// Без очереди, сразу задает значеине <see cref="Pause"/> на устройстве.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        public void PauseVal(bool value)
        {
            var s = GetVal(Set_Pause, value ? "1" : "0");
            if (s != "done" + '\r') throw new MemorySetupBadRespondException("done", s, string.Format(Set_Pause, value ? "1" : "0"));
        }


        /// <summary>
        /// Указывает на то, открыто ли соеденение в данный момент.
        /// </summary>
        public bool IsWorking
        {
            get { return _sp.IsOpen; }
        }

        /// <summary>
        /// Без очереди, сразу задает значеине <see cref="Com"/> на устройстве.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        public void ComVal(bool value)
        {
            var s = GetVal(Set_Com, value ? "1" : "0");
            if (s != "done" + '\r') throw new MemorySetupBadRespondException("done", s, string.Format(Set_Com, value ? "1" : "0"));
        }

        /// <summary>
        /// Параметр Com или горит ли светодиод "Command".
        /// </summary>
        public bool Com
        {
            get { return int.Parse(GetVal(Get_Com, null)) != 0; }
            set { _qnToSend.Add(string.Format(Set_Com, value ? 1 : 0)); }
        }

        /// <summary>
        /// Очередь (список) для отправки на устройство.
        /// </summary>
        private List<string> _qnToSend;

        /// <summary>
        /// Создает новый экземпляр класса <see cref="DeviceMemorySetup"/>.
        /// </summary>
        /// <param name="pname">Имя порта.</param>
        /// <param name="bdtate">Скорость соеденения.</param>
        public DeviceMemorySetup(string pname, int bdtate)
        {
            _qnToSend = new List<string>();
            if (_sp?.IsOpen == true) _sp.Close();
            _sp = new SerialPort(pname, bdtate);
            _sp.Open();
            var s = GetVal(Check, null);
            if (s != "OK" + '\r') throw new MemorySetupBadRespondException("Ok", s, string.Format(Check, null));
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="DeviceMemorySetup"/>.
        /// </summary>
        /// <param name="ss">Порт для подключения.</param>
        public DeviceMemorySetup(SerialPort ss)
        {
            _qnToSend = new List<string>();
            _sp = ss;
            var s = GetVal(Check, null);
            if (s != "OK" + '\r') throw new MemorySetupBadRespondException("Ok", s, string.Format(Check, null));
        }

        /// <summary>
        /// Получить с устройства актуальные данные.
        /// </summary>
        public void Load()
        {
            foreach (var a in _qnToSend)
            {
                string s = GetVal(a, null);
                if (s != "done" + '\r') throw new MemorySetupBadRespondException("done", s, string.Format(a, null));
            }
            _qnToSend = new List<string>();
        }

        /// <summary>
        /// Сбрасывает и перезагружает Ардуино (может оборвать соеденение).
        /// </summary>
        public void Reset()
        {
            _sp.Write(ResetArduino);
        }

        /// <summary>
        /// Закрывает подключение.
        /// </summary>
        public void Stop()
        {
            _sp.Close();
        }

        /// <summary>
        /// Сбрасывает данные на устройстве.
        /// </summary>
        public void ResetData()
        {
            _sp.Write(ResetToDefault);
        }

        /// <summary>
        /// Отправляет команду и ожидает ответа от устройства.
        /// </summary>
        /// <param name="command">Имя команды в формате "command{0}" или "command", если параметра нет.</param>
        /// <param name="val">Значение для команды (нужно, если у команды есть параметр).</param>
        /// <returns></returns>
        private string GetVal(string command, string val)
        {
            try { _sp.DataReceived -= SubWait; } catch { };
            _sp.DataReceived += SubWait;
            _getRespond = false;
            _waitForRespond = true;
            if (command.Contains('{')) _sp.Write(string.Format(command, val));
            else _sp.Write(command);
            int i = 0;
            while (!_getRespond)
            {
                System.Threading.Thread.Sleep(10);
                i += 10;
                if (i > 2000)
                {
                    throw new MemorySetupTimeoutException(string.Format(command, val), 2000);
                }
            }
            return _Respond;
        }

        /// <summary>
        /// Принимает ответ от устройства, каким бы он ни был.
        /// </summary>
        private void SubWait(object sender, SerialDataReceivedEventArgs e)
        {
            if (_waitForRespond)
            { 
                _Respond = _sp.ReadLine();
                _getRespond = true;
                _waitForRespond = false;
            }
        }
    }
}
