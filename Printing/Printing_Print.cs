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

using CWA.Connection;
using CWA.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace CWA.Printing
{
    /// <summary>
    /// Предоставляет методы для печати вектора на устройстве.
    /// </summary>
    public class Print
    {
        /// <summary>
        /// Событие, которое срабатывает, когда статус печати изменен.
        /// </summary>
        public event PrintedEventHandler PrintChanged;

        /// <summary>
        /// Событие, которое срабатывает каждую 1 секундо, во время печати и предоставляет информацию о времени 
        /// </summary>
        public event TimeEventHandler TimeChanged;

        /// <summary>
        /// Событие окочания печати.
        /// </summary>
        public event DoneEventHandler PrintingDone;

        /// <summary>
        /// Событие изменения статуса разбора данных.
        /// </summary>
        public event ProceedStatusChangedHandler ProceedStatusChanged;

        /// <summary>
        /// Событие окончания разбора данных.
        /// </summary>
        public event ProceedEndHandler ProceedEnd;

        /// <summary>
        /// Событие окончания печати.
        /// </summary>
        public event ErrorEventHandler PrintError;

        private Vect _data;
        private PrintOptions _opts;
        private List<string> _commands;
        private List<Point> _pntlist;
        private SerialPort _sp;
        private DateTime _dtn;
        private Color _drawColor, _backColor;
        private Bitmap _processBmp;
        private Thread _proceedTh;
        private System.Timers.Timer _tm;
        private StartPrintOption _spo;
        private ReturnBackOption _rbo;
        private int _prcounter, _totalcount, _s, _countOfPrData, _lProgress, _oneSProgress, _lastpr;
        private bool _end;
        private float _left, _penWidth;
        private bool _paused;
        private bool _firstLog = true;
        private DateTime _crdate;
        public bool IsCorrectEnd;
        private bool _isAborted;

        /// <summary>
        /// Создает новый экземпляр класса Print.
        /// </summary>
        /// <param name="data">Вектор для печати.</param>
        /// <param name="options">Опции для печати.</param>
        /// <param name="spo">Опция начала печати.</param>
        /// <param name="rbo">Опция конца печати.</param>
        /// <param name="sp">Порт для соеденения с устройством.</param>
        public Print(Vect data, PrintOptions options, StartPrintOption spo, ReturnBackOption rbo, SerialPort sp)
        {
            Log("Создан Экземпляр класса");
            Log("Устанока параметров");
            _backColor = Color.White;
            _drawColor = Color.Black;
            PenWidth = 2;
            sp.DataReceived += PrintData;
            _tm = new System.Timers.Timer(1000);
            _tm.Elapsed += Tm_Elapsed;
            _sp = sp;
            if (data == null)
            {
                Log("[ОШИБКА]. Нулевые данные");
                throw new ArgumentNullException(nameof(data));
            }
            if (Math.Abs(options.PrintSize.Width) <= 0 || Math.Abs(options.PrintSize.Height) <= 0)
            {
                Log("[ОШИБКА]. Нулевые размеры");
                throw new ArgumentNullException(nameof(options.PrintSize));
            }
            Log("Вектор:FileName:  "+ data.Filename);
            Log("Вектор:Resolution: " + data.Resolution);
            Log("Вектор:ContourCount: " + data.ContorurCount);
            Log("Вектор:Points: " + data.Points);
            Log("Печать:PrintSize: " + options.PrintSize.ToString());
            _data = data;
            _opts = options;
            _spo = spo;
            _rbo = rbo;
            _processBmp = new Bitmap((int)data.Header.Width, (int)data.Header.Height);
            Rectangle rect = new Rectangle(0, 0, (int)data.Header.Width, (int)data.Header.Height);
            using (Graphics g = Graphics.FromImage(_processBmp)) g.FillRectangle(new SolidBrush(_backColor), rect);
            Log("Инициализация оконченна");
        }

        /// <summary>
        /// Попытатся открыть порт.
        /// </summary>
        private void TryToRetry()
        {
            Log("Попытка начать заново");
            try
            {
                Log("Открытие порта");
                _sp.Open();
                Log("Писание актуальной команды");
                _sp.Write(_commands[_prcounter]);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(UnauthorizedAccessException))
                {
                    Log("[ОШИБКА]. Cant reach port");
                    if (MessageBox.Show("Cant reach port. Retry connect?", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Retry) TryToRetry();
                    else OnPrintError(PrintErrorEventArgs.UnAvailablePortError);
                }
                else
                {
                    Log("[ОШИБКА]. Sending data to arduino error");
                    if (MessageBox.Show("Sending data to arduino error. Retry connect?", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Retry) TryToRetry();
                    else
                    {
                        OnPrintError(PrintErrorEventArgs.UnAvailablePortError);
                        Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Записать в лог сообщение.
        /// </summary>
        /// <param name="s">Само сообщение.</param>
        private void Log(string s)
        {
            if (GlobalOptionsLogPolitics.SavePrintLog)
            {
                if (_firstLog)
                {
                    _crdate = DateTime.Now;
                    _firstLog = false;
                    File.Create(GlobalOptionsLogPolitics.CorrectInsert(_crdate, GlobalOptionsLogPolitics.OutPutDir + GlobalOptionsLogPolitics.PrintLogNameFormat)).Close();
                }
                File.AppendAllLines(GlobalOptionsLogPolitics.CorrectInsert(_crdate, GlobalOptionsLogPolitics.OutPutDir + GlobalOptionsLogPolitics.PrintLogNameFormat), new[] { DateTime.Now + "   :   " + s });
            }
        }

        /// <summary>
        /// Отправка следующей части вектора в порт. Срабатывает при ответе устройства.
        /// </summary>
        private void PrintData(object sender, SerialDataReceivedEventArgs e)
        {
            if (_paused) return;
            string rxstring;
            try
            {
                rxstring = _sp.ReadLine();
                if (rxstring != "" && !_end)
                {
                    if (rxstring[0] == 'O' && rxstring[1] == 'K')
                    {
                        try { _sp.Write(_commands[_prcounter]); }
                        catch (Exception ex)
                        {
                            if (ex.GetType() == typeof(ArgumentOutOfRangeException)) _end = true;
                            else
                            {
                                if (MessageBox.Show("Sending data to arduino error. Retry connect?", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Retry) TryToRetry();
                                else
                                {
                                    OnPrintError(PrintErrorEventArgs.SendDataError);
                                    Abort();
                                }
                            }
                        }
                        _prcounter += 1;
                    }
                }
            }
            catch {
                // ignored 
            }
        }

        /// <summary>
        /// Метод вызова ивента ProceedStatusChanged.
        /// </summary>
        /// <param name="e">Параметр вызова.</param>
        private void OnProceedStatusChanged(ProceedStatusChangedArgs e)
        {
            ProceedStatusChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Срабатывание таймера.
        /// </summary>
        private void Tm_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _oneSProgress = _prcounter - _lProgress;
                _lProgress = _prcounter;
                _countOfPrData += _oneSProgress;
                if (_oneSProgress == 0) _left = float.PositiveInfinity;
                else _left = (_commands.Count - _countOfPrData) / _oneSProgress;
                OnTimeChanged(new TimeEventArgs(_s++, _left, _dtn));
                OnPrintChanged(new PrintedEventArgs(_totalcount, _prcounter, _pntlist[_prcounter]));
            }
            catch { }
        }

        /// <summary>
        /// Метод вызова ивента PrintError.
        /// </summary>
        /// <param name="e">Параметр вызова.</param>
        private void OnPrintError(PrintErrorEventArgs e)
        {
            PrintError?.Invoke(this, e);
            Log("[ОШИБКА]. " + e);
        }

        /// <summary>
        /// Метод вызова ивента PrintChanged.
        /// </summary>
        /// <param name="e">Параметр вызова.</param>
        private void OnPrintChanged(PrintedEventArgs e)
        {
            PrintChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Метод вызова ивента TimeChanged.
        /// </summary>
        /// <param name="e">Параметр вызова.</param>
        private void OnTimeChanged(TimeEventArgs e)
        {
            TimeChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Метод вызова ивента PrintingDone.
        /// </summary>
        /// <param name="e">Параметр вызова.</param>
        private void OnPrintingDone(EventArgs e)
        {
            Log("Печать оконченна");
            IsCorrectEnd = true;
            PrintingDone?.Invoke(this, e);
        }

        /// <summary>
        /// Метод вызова ивента ProceedEnd.
        /// </summary>
        /// <param name="e">Параметр вызова.</param>
        private void OnProceedEnd(EventArgs e)
        {
            ProceedEnd?.Invoke(this, e);
            Log("Конец потока вычисления");
        }

        /// <summary>
        /// Вычесление комманд. Основной метод.
        /// </summary>
        private void ComputeCommandsAll()
        {
            Log("Начало вычесления команд");
            _pntlist = new List<Point>();
            _totalcount = 0;
            for (var i = 0; i <= _data.RawData.Length - 1; i++)
                for (var ii = 0; ii <= _data.RawData[i].Length - 1; ii++)
                {
                    _pntlist.Add(new Point((int)_data.RawData[i][ii].Pnt.Y, (int)_data.RawData[i][ii].Pnt.X));
                    _totalcount += 1;
                }
            Log("Количество расчитано");
            for (int i = 0; i <= _data.RawData.Length - 1; i++)
                for (int ii = 0; ii <= _data.RawData[i].Length - 1; ii++)
                {
                    var tm = PrintHm.toStep(new Point((int)_data.RawData[i][ii].Pnt.X + (int)_opts.XOffset, (int)_data.RawData[i][ii].Pnt.Y + (int)_opts.YOffset), _opts);
                    _data.RawData[i][ii] = new VPointEx(_data.Header.Width - tm.X, tm.Y, 0, Color.Black);
                }
            Log("Шаги преобразованны");
            _commands = new List<string>();
            switch (_spo)
            {
                case StartPrintOption.ToolUp:
                    _commands.Add("up");
                    break;
                case StartPrintOption.ToolDown:
                    _commands.Add("down");
                    break;
                case StartPrintOption.ToolDownUp:
                    _commands.Add("down");
                    _commands.Add("up");
                    break;
                case StartPrintOption.ToolUpDown:
                    _commands.Add("up");
                    _commands.Add("down");
                    break;
            }
            _commands.Add(PrintHm.GetDc(new VPoint(0, 0, Color.Black), _data.RawData[0][0].Pnt));
            for (var i = 0; i <= _data.RawData.Length - 1; i++)
            {
                if (i % 10 == 0) OnProceedStatusChanged(new ProceedStatusChangedArgs((((float)i + 1) / _data.RawData.Length) * 100));
                Thread.Sleep(2);
                _commands.Add("down");
                for (var ii = 0; ii <= _data.RawData[i].Length - 2; ii++)
                {
                    if (PrintHm.Distance(_data.RawData[i][ii].Pnt, _data.RawData[i][ii + 1].Pnt) >= GlobalOptions.MaxDisConst)
                    {
                        Log(string.Format("Разрыв. Номера [{0}]. Длина контура: {2}. Distance: {1}. Точка т.: ({3}:{4}). Точка сл.: ({5}:{6}).", i.ToString() +';'+ ii, PrintHm.Distance(_data.RawData[i][ii].Pnt, _data.RawData[i][ii + 1].Pnt), _data.RawData[i].Length, _data.RawData[i][ii].Pnt.X, _data.RawData[i][ii].Pnt.Y, _data.RawData[i][ii + 1].Pnt.X, _data.RawData[i][ii + 1].Pnt.Y));
                        _commands.Add("up");
                        _commands.Add(PrintHm.GetDc(_data.RawData[i][ii].Pnt, _data.RawData[i][ii + 1].Pnt));
                        _commands.Add("down");
                        continue;
                    }
                    _commands.Add(PrintHm.GetDc(_data.RawData[i][ii].Pnt, _data.RawData[i][ii + 1].Pnt));
                }
                _commands.Add("up");
                try
                {
                    _commands.Add(PrintHm.GetDc(_data.RawData[i][_data.RawData[i].Length - 1].Pnt,
                        _data.RawData[i + 1][0].Pnt));
                }
                catch
                {
                    // ignored
                }
            }
            Log("Разрывы обнаружены");
            if (_rbo == ReturnBackOption.ReturnToZero) _commands.Add(PrintHm.GetDc(_data.RawData[_data.RawData.Length - 1][_data.RawData[_data.RawData.Length - 1].Length - 1].Pnt, new VPoint(0, 0, Color.Black)));
            for (var i = 0; i <= _commands.Count - 1; i++)
                if (_commands[i] == "up")
                    _commands[i] = "0,0,-" + (GlobalOptions.StepHeightConst + GlobalOptions.UpKoof) + ';';
                else if (_commands[i] == "down")
                {
                    _commands[i] = "0,0," + GlobalOptions.StepHeightConst + ';';
                }
            for (var i = 0; i <= _pntlist.Count - 1; i++) try { _processBmp.SetPixel(_pntlist[i].X, _pntlist[i].Y, Color.DarkGray); }
                catch
                {
                    // ignored
                }
            Log("Вычисление оконченно");
            OnProceedEnd(EventArgs.Empty);
        }
        
        /// <summary>
        /// Преобразование вектора в команды, пригодные для печати. Обязательный метод для применения перед печатью.
        /// </summary>
        public void ComputeCommands()
        {
            Log("Старт потока вычисления");
            _proceedTh = new Thread(ComputeCommandsAll);
            _proceedTh.Start();
        }

        /// <summary>
        /// Напечатать (построить) вектор.
        /// </summary>
        public void PrintVector()
        {
            Log("Старт печати");
            _dtn = DateTime.Now;
            _tm.Start();
            Log("Устанока ком леда он");
            Log("-- Закрытие порта");
            _sp.Close();
            Log("-- Создание Экземпляра DeviceSetup");
            DeviceMemorySetup a = new DeviceMemorySetup(_sp.PortName, _sp.BaudRate);
            Log("-- Задача параметра");
            a.ComVal(true);
            Log("-- Закрытие порта");
            a.Stop();
            Log("-- Открытие порта");
            _sp.Open();
            Thread.Sleep(1000);
            Log("Отправка первой команды");
            try { _sp.Write(_commands[0]); }
            catch
            {
                Log("ОШИБКА");
                if (MessageBox.Show("Sending data to arduino error", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Retry) TryToRetry();
                else
                {
                    OnPrintError(PrintErrorEventArgs.FirstSendDataError);
                    Abort();
                }
            }
            while (true)
            {
                Thread.Sleep(300);
                if (_end) break;
            }
            Log("Конец печати");
            Log("Устанока ком и пауз леда офф");
            Log("-- Закрытие порта");
            _sp.Close();
            Log("-- Создание Экземпляра DeviceSetup");
            a = new DeviceMemorySetup(_sp.PortName, _sp.BaudRate);
            Log("-- Задача параметров");
            a.ComVal(false);
            a.PauseVal(false);
            Log("-- Закрытие порта");
            a.Stop();
            Log("-- Открытие порта");
            _sp.Open(); IsCorrectEnd = true;
            OnPrintingDone(EventArgs.Empty);
        }

        /// <summary>
        /// Прервать печать.
        /// </summary>
        public void Abort()
        {
            if (!_end) _isAborted = true;
            if (_tm.Enabled)
            {
                Log("Аборт печати");
                Log("-- Отсановка таймера");
                _tm.Stop();
                _end = true;
                Log("-- Остановка потока");
                _proceedTh.Abort();
                Log("-- Закрытие порта");
                _sp.Close();
                Log("Печать завершена (прервана) за: " + _s + "секунд, или " + ((float)_s / 60) + " мин!");
                if (GlobalOptionsLogPolitics.SaveGlobalVectLog)
                {
                    var filename = GlobalOptionsLogPolitics.CorrectInsert(DateTime.Now, GlobalOptionsLogPolitics.OutPutDir + GlobalOptionsLogPolitics.GlobalPrintLogNameFormat);
                    if (!File.Exists(filename)) File.Create(filename).Close();
                    var content = new List<string>();
                    content.Add("\n       --===========--     \n");
                    content.Add("Печать от: " + DateTime.Now);
                    if (GlobalOptionsLogPolitics.SavePrintLog) content.Add("Лог данной печати: " + GlobalOptionsLogPolitics.CorrectInsert(_crdate, GlobalOptionsLogPolitics.OutPutDir + GlobalOptionsLogPolitics.PrintLogNameFormat));
                    content.Add("Вектор: " + _data.Filename);
                    content.Add("Кол-во контуров вектора: " + _data.ContorurCount);
                    content.Add("Кол-во точек вектора: " + _data.Points);
                    content.Add("Разрешение вектора: " + _data.Resolution);
                    content.Add("Резуль. изображение: " + _opts.PrintSize);
                    content.Add("Причина окончания: " + (IsCorrectEnd ? "конец печати" : (_isAborted ? "прервано пользователем" : "ошибка")));
                    content.Add("Время работы: " + _s + "секунд, или " + ((float)_s / 60) + " мин!");
                    File.AppendAllLines(filename, content);
                }
            }
        }

        /// <summary>
        /// Приостановить печать.
        /// </summary>
        public void Pause()
        {
            _paused = !_paused;
            Log("Пауза печати, установленна как: "+ (_paused));
            Log("Установка пауз леда как: " + _paused);
            Log("-- Закрытие порта");
            _sp.Close();
            Log("-- Создание Экземпляра DeviceSetup");
            DeviceMemorySetup a = new DeviceMemorySetup(_sp.PortName, _sp.BaudRate);
            Log("-- Задача параметра");
            a.PauseVal(_paused);
            Log("-- Закрытие порта");
            a.Stop();
            Log("-- Открытие порта");
            _sp.Open();
            if (_paused) TryToRetry();
        }

        /// <summary>
        /// Приостановлена ли печать.
        /// </summary>
        public bool IsPaused
        {
            get { return _paused; }
        }

        /// <summary>
        /// Изображнеие вектора, на котором отображен текущий процесс печати.
        /// </summary>
        public Bitmap ProcessBmp
        {
            get
            {
                try
                {
                    var arr = _pntlist.GetRange(_lastpr, _prcounter).ToArray();
                    _lastpr = _prcounter;
                    for (var i = 0; i <= arr.Length - 1; i++)
                    {
                        _processBmp.SetPixel(arr[i].X, arr[i].Y, _drawColor);
                    }
                }
                catch { }
                return _processBmp;
            }
        }

        /// <summary>
        /// Цвет фона изображения ProcessBmp.
        /// </summary>
        public Color BackColor
        {
            get { return _backColor;  }
            set { _backColor = value; }
        }

        /// <summary>
        /// Цвет линий изображения ProcessBmp.
        /// </summary>
        public Color DrawColor
        {
            get { return _drawColor;  }
            set { _drawColor = value; }
        }

        /// <summary>
        /// Ширина линий изображения ProcessBmp.
        /// </summary>
        public float PenWidth
        {
            get { return _penWidth;  }
            set { _penWidth = value; }
        }
    }
}
