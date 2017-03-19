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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CWA.Printing;
using CWA.Connection;

namespace CWA
{
    /// <summary>
    /// Предоставляет и обслуживает параметры для всех библиотек пространства имен CNCWFA_API.
    /// </summary>
    public static class GlobalOptions
    {
        private static int _stepHeightConst, _maxDisConst, _maxHeightSteps, _maxWidthSteps, _build, _mainbd, _upKoof;
        private static string _mainport = "", _pathToArduino, _ver;
        private static Color _defPrintBack, _defViewDraw, _defPrintDraw, _defViewBack;
        private static bool _ignoreRegisterExtentions, _useAutoSpeed, _preloadPlugins;
        private static StartPrintOption _defSpo;
        private static ReturnBackOption _defRbo;
        private static ArduinoBoard _defBoard;
        private static float _yMm, _xMm;
        private static string _lang;
        
        /// <summary>
        /// Имя Рабочего файла опций.
        /// </summary>
        public static string Filename = "none";

        /// <summary>
        /// Имя файла с номером сборки.
        /// </summary>
        public static string BuildFilename = "none";

        /// <summary>
        /// Путь к Arduino IDE.
        /// </summary>
        public static string PathToArduino
        {
            get { return _pathToArduino; }
            set { _pathToArduino = value; }
        }

        /// <summary>
        /// Количество шагов по оси Z, которое будет выполнятся при поднятии\опускании пера.
        /// </summary>
        public static int StepHeightConst
        {
            get { return _stepHeightConst; }
            set { _stepHeightConst = value; }
        }

        /// <summary>
        /// Константа разрыва вектора.
        /// </summary>
        public static int MaxDisConst
        {
            get { return _maxDisConst; }
            set { _maxDisConst = value; }
        }

        /// <summary>
        /// Скорость соеденения по умолчанию.
        /// </summary>
        public static int Mainbd
        {
            get { return _mainbd; }
            set { _mainbd = value; }
        }

        /// <summary>
        /// Имя порта по умолчанию.
        /// </summary>
        public static string Mainport
        {
            get { return _mainport; }
            set { _mainport = value; }
        }

        /// <summary>
        /// Количество шагов (всего) по высоте.
        /// </summary>
        public static int MaxHeightSteps
        {
            get { return _maxHeightSteps; }
            set { _maxHeightSteps = value; }
        }

        /// <summary>
        /// Количество шагов (всего) по ширине.
        /// </summary>
        public static int MaxWidthSteps
        {
            get { return _maxWidthSteps; }
            set { _maxWidthSteps = value; }
        }

        /// <summary>
        /// Определяет, будут ли загружатся плагины при старте программы.
        /// </summary>
        public static bool PreloadPlugins
        {
            get { return _preloadPlugins; }
            set { _preloadPlugins = value; }
        }

        /// <summary>
        /// Автоматически устанавливать задержки, в зависимости от значения потенциометра.
        /// </summary>
        public static bool UseAutoSpeed
        {
            get { return _useAutoSpeed; }
            set { _useAutoSpeed = value; }
        }

        /// <summary>
        /// Цвет фона превью мастера печати.
        /// </summary>
        public static Color DefPrintBack
        {
            get { return _defPrintBack; }
            set { _defPrintBack = value; }
        }

        /// <summary>
        /// Цвет линий превью мастера печати.
        /// </summary>
        public static Color DefPrintDraw
        {
            get { return _defPrintDraw; }
            set { _defPrintDraw = value; }
        }

        /// <summary>
        /// Цвет фона просмотрщика.
        /// </summary>
        public static Color DefViewBack
        {
            get { return _defViewBack; }
            set { _defViewBack = value; }
        }

        /// <summary>
        /// Цвет линий превью просмотрщика.
        /// </summary>
        public static Color DefViewDraw
        {
            get { return _defViewDraw; }
            set { _defViewDraw = value; }
        }

        /// <summary>
        /// Действие при начале печати.
        /// </summary>
        public static StartPrintOption DefSpo
        {
            get { return _defSpo; }
            set { _defSpo = value; }
        }

        /// <summary>
        /// Действие при конце печати.
        /// </summary>
        public static ReturnBackOption DefRbo
        {
            get { return _defRbo; }
            set { _defRbo = value; }
        }

        /// <summary>
        /// Миллиметров в одном шаге по оси Х.
        /// </summary>
        public static float XMM
        {
            get { return _xMm; }
            set { _xMm = value; }
        }

        /// <summary>
        /// Миллиметров в одном шаге по оси Y.
        /// </summary>
        public static float YMM
        {
            get { return _yMm; }
            set { _yMm = value; }
        }

        /// <summary>
        /// Игнорировать не зарегистрированные разширения.
        /// </summary>
        public static bool IgnoreRegisterExtentions
        {
            get { return _ignoreRegisterExtentions; }
            set { _ignoreRegisterExtentions = value; }
        }

        /// <summary>
        /// Версия программы.
        /// </summary>
        public static string Ver
        {
            get { return _ver; }
            set { _ver = value; }
        }

        /// <summary>
        /// Сборка программы.
        /// </summary>
        public static int Build
        {
            get { return _build; }
            set { _build = value; }
        }

        /// <summary>
        /// Плата Arduino по умолчанию.
        /// </summary>
        public static ArduinoBoard DefBoard
        {
            get { return _defBoard; }
            set { _defBoard = value; }
        }

        /// <summary>
        /// Количество дополнительных шагов, которые будут выполнятся при поднятии пера (может быть и отрицательным).
        /// </summary>
        public static int UpKoof
        {
            get { return _upKoof; }
            set { _upKoof = value; }
        }

        public static string Lang
        {
            get { return _lang; }
            set { _lang = value; }
        }

        /// <summary>
        /// Останавливает значения переменным по умолчанию.
        /// </summary>
        public static void Reset()
        {
            _pathToArduino = "";
            XMM = 0.013f;
            YMM = 0.013f;
            DefBoard = ArduinoBoard.Boards.ToList().Find(p => p.ProgramName == "arduino:avr:mega");
            StepHeightConst = 2000;
            MaxDisConst = 100;
            UseAutoSpeed = false;
            IgnoreRegisterExtentions = false;
            Mainbd = 115200;
            Mainport = "COM0";
            DefPrintBack = Color.White;
            DefPrintDraw = Color.Black;
            DefViewBack = Color.Black;
            DefViewDraw = Color.White;
            MaxHeightSteps = 22100;
            MaxWidthSteps = 15500;
            _defRbo = ReturnBackOption.ReturnToZero;
            DefSpo = StartPrintOption.None;
            Lang = "";
        }

        /// <summary>
        /// Загружает параметры с файла опций.
        /// </summary>
        public static void Load()
        {
            Ver = Application.ProductVersion;
            try
            {
                Build = int.Parse(File.ReadAllLines(BuildFilename)[1]);
                File.WriteAllText(BuildFilename, "<!--Don`t EDIT this FILE!-->\n" + ++_build);
            }
            catch { MessageBox.Show("Can`t find build file.\n'" + BuildFilename + "' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); };
            if (!File.Exists(Filename))
            {
                MessageBox.Show("Can`t find options file.\n'" + Filename + "' not found\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try { Reset(); Save(); }
                catch { MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Environment.Exit(1); }
                MessageBox.Show("Done", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var data = ExOperators.Load(Filename);
            _stepHeightConst = int.Parse(data["StepHeightConst"]);
            _maxDisConst = int.Parse(data["MaxDisConst"]);
            _useAutoSpeed = bool.Parse(data["UseAutoSpeed"]);
            _xMm = float.Parse(data["XMM"], CultureInfo.InvariantCulture);
            _yMm = float.Parse(data["YMM"], CultureInfo.InvariantCulture);
            _mainbd = int.Parse(data["Mainbd"]);
            _mainport = data["Mainport"];
            _defSpo = ExOperators.GetEnum<StartPrintOption>(data["Def_SPO"]);
            _defRbo = ExOperators.GetEnum<ReturnBackOption>(data["Def_RBO"]);
            _defPrintBack = ExOperators.ColorFromHex(data["Def_print_back"]);
            _defPrintDraw = ExOperators.ColorFromHex(data["Def_print_draw"]);
            _defViewBack = ExOperators.ColorFromHex(data["Def_view_back"]);
            _defViewDraw = ExOperators.ColorFromHex(data["Def_view_draw"]);
            _maxHeightSteps = int.Parse(data["MaxHeightSteps"]);
            _maxWidthSteps = int.Parse(data["MaxWidthSteps"]);
            _ignoreRegisterExtentions = bool.Parse(data["ignoreRegisterExtentions"]);
            _pathToArduino = data["PathToArduino"];
            _defBoard = ArduinoBoard.Boards.ToList().Find(p => p.ProgramName == data["def_board"]); 
            _upKoof = int.Parse(data["UpKoof"]);
            _lang = data["Language"];
            _preloadPlugins = bool.Parse(data["PreloadPlugins"]);
        }

        /// <summary>
        /// Сохраняет параметры в файл опций.
        /// </summary>
        public static void Save()
        {
            var a = new Dictionary<string, string>
            {
                { "StepHeightConst", _stepHeightConst.ToString() },
                { "MaxDisConst", _maxDisConst.ToString() },
                { "UseAutoSpeed", _useAutoSpeed.ToString() },
                { "XMM", _xMm.ToString(CultureInfo.InvariantCulture) },
                { "YMM", _yMm.ToString(CultureInfo.InvariantCulture) },
                { "Mainbd", _mainbd.ToString() },
                { "Mainport", _mainport },
                { "Def_SPO", _defSpo.ToString() },
                { "Def_RBO", _defRbo.ToString() },
                { "Def_print_back", ExOperators.ColorToHex(_defPrintBack) },
                { "Def_print_draw", ExOperators.ColorToHex(_defPrintDraw) },
                { "Def_view_back", ExOperators.ColorToHex(_defViewBack) },
                { "Def_view_draw", ExOperators.ColorToHex(_defViewDraw) },
                { "MaxWidthSteps", _maxWidthSteps.ToString() },
                { "MaxHeightSteps", _maxHeightSteps.ToString() },
                { "ignoreRegisterExtentions", _ignoreRegisterExtentions.ToString() },
                { "PathToArduino", _pathToArduino},
                { "def_board", _defBoard.ToString() },
                { "UpKoof", _upKoof.ToString() },
                { "Language", _lang.ToString() },
                { "PreloadPlugins", _preloadPlugins.ToString() }
            };
            ExOperators.Save(Filename, a, "Don`t EDIT this FILE!");
        }
    }

}
