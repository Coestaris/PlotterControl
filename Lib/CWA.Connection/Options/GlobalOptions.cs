/*=================================\
* CWA.Connection\GlobalOptions.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:38
* Last Edited: 19.08.2017 7:38:22
*=================================*/

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
    /// Предоставляет и обслуживает параметры для всех библиотек пространства имен CWA.
    /// </summary>
    public static class GlobalOptions
    {
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
        public static string PathToArduino { get; set; }

        /// <summary>
        /// Количество шагов по оси Z, которое будет выполнятся при поднятии\опускании пера.
        /// </summary>
        public static int StepHeightConst { get; set; }

        /// <summary>
        /// Константа разрыва вектора.
        /// </summary>
        public static int MaxDisConst { get; set; }

        /// <summary>
        /// Скорость соеденения по умолчанию.
        /// </summary>
        public static int Mainbd { get; set; }

        /// <summary>
        /// Имя порта по умолчанию.
        /// </summary>
        public static string Mainport { get; set; }

        /// <summary>
        /// Количество шагов (всего) по высоте.
        /// </summary>
        public static int MaxHeightSteps { get; set; }

        /// <summary>
        /// Количество шагов (всего) по ширине.
        /// </summary>
        public static int MaxWidthSteps { get; set; }

        /// <summary>
        /// Определяет, будут ли загружатся плагины при старте программы.
        /// </summary>
        public static bool PreloadPlugins { get; set; }

        /// <summary>
        /// Автоматически устанавливать задержки, в зависимости от значения потенциометра.
        /// </summary>
        public static bool UseAutoSpeed { get; set; }

        /// <summary>
        /// Цвет фона превью мастера печати.
        /// </summary>
        public static Color DefPrintBack { get; set; }

        /// <summary>
        /// Цвет линий превью мастера печати.
        /// </summary>
        public static Color DefPrintDraw { get; set; }

        /// <summary>
        /// Цвет фона просмотрщика.
        /// </summary>
        public static Color DefViewBack { get; set; }

        /// <summary>
        /// Цвет линий превью просмотрщика.
        /// </summary>
        public static Color DefViewDraw { get; set; }

        /// <summary>
        /// Действие при начале печати.
        /// </summary>
        public static StartPrintOption DefSpo { get; set; }

        /// <summary>
        /// Действие при конце печати.
        /// </summary>
        public static ReturnBackOption DefRbo { get; set; }

        /// <summary>
        /// Миллиметров в одном шаге по оси Х.
        /// </summary>
        public static float XMM { get; set; }

        /// <summary>
        /// Миллиметров в одном шаге по оси Y.
        /// </summary>
        public static float YMM { get; set; }

        /// <summary>
        /// Игнорировать не зарегистрированные разширения.
        /// </summary>
        public static bool IgnoreRegisterExtentions { get; set; }

        /// <summary>
        /// Версия программы.
        /// </summary>
        public static string Ver { get; set; }

        /// <summary>
        /// Сборка программы.
        /// </summary>
        public static int Build { get; set; }

        /// <summary>
        /// Плата Arduino по умолчанию.
        /// </summary>
        public static ArduinoBoard DefBoard { get; set; }

        /// <summary>
        /// Количество дополнительных шагов, которые будут выполнятся при поднятии пера (может быть и отрицательным).
        /// </summary>
        public static int UpKoof { get; set; }

        /// <summary>
        /// Язык приложения поумолчанию.
        /// </summary>
        public static string Lang { get; set; }

        /// <summary>
        /// Останавливает значения переменным по умолчанию.
        /// </summary>
        public static void Reset()
        {
            PathToArduino = "";
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
            DefRbo = ReturnBackOption.ReturnToZero;
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
                File.WriteAllText(BuildFilename, "<!--Don`t EDIT this FILE!-->\n" + ++Build);
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
            StepHeightConst = int.Parse(data["StepHeightConst"]);
            MaxDisConst = int.Parse(data["MaxDisConst"]);
            UseAutoSpeed = bool.Parse(data["UseAutoSpeed"]);
            XMM = float.Parse(data["XMM"], CultureInfo.InvariantCulture);
            YMM = float.Parse(data["YMM"], CultureInfo.InvariantCulture);
            Mainbd = int.Parse(data["Mainbd"]);
            Mainport = data["Mainport"];
            DefSpo = ExOperators.GetEnum<StartPrintOption>(data["Def_SPO"]);
            DefRbo = ExOperators.GetEnum<ReturnBackOption>(data["Def_RBO"]);
            DefPrintBack = ExOperators.ColorFromHex(data["Def_print_back"]);
            DefPrintDraw = ExOperators.ColorFromHex(data["Def_print_draw"]);
            DefViewBack = ExOperators.ColorFromHex(data["Def_view_back"]);
            DefViewDraw = ExOperators.ColorFromHex(data["Def_view_draw"]);
            MaxHeightSteps = int.Parse(data["MaxHeightSteps"]);
            MaxWidthSteps = int.Parse(data["MaxWidthSteps"]);
            IgnoreRegisterExtentions = bool.Parse(data["ignoreRegisterExtentions"]);
            PathToArduino = data["PathToArduino"];
            DefBoard = ArduinoBoard.Boards.ToList().Find(p => p.ProgramName == data["def_board"]); 
            UpKoof = int.Parse(data["UpKoof"]);
            Lang = data["Language"];
            PreloadPlugins = bool.Parse(data["PreloadPlugins"]);
        }

        /// <summary>
        /// Сохраняет параметры в файл опций.
        /// </summary>
        public static void Save()
        {
            var a = new Dictionary<string, string>
            {
                { "StepHeightConst", StepHeightConst.ToString() },
                { "MaxDisConst", MaxDisConst.ToString() },
                { "UseAutoSpeed", UseAutoSpeed.ToString() },
                { "XMM", XMM.ToString(CultureInfo.InvariantCulture) },
                { "YMM", YMM.ToString(CultureInfo.InvariantCulture) },
                { "Mainbd", Mainbd.ToString() },
                { "Mainport", Mainport },
                { "Def_SPO", DefSpo.ToString() },
                { "Def_RBO", DefRbo.ToString() },
                { "Def_print_back", ExOperators.ColorToHex(DefPrintBack) },
                { "Def_print_draw", ExOperators.ColorToHex(DefPrintDraw) },
                { "Def_view_back", ExOperators.ColorToHex(DefViewBack) },
                { "Def_view_draw", ExOperators.ColorToHex(DefViewDraw) },
                { "MaxWidthSteps", MaxWidthSteps.ToString() },
                { "MaxHeightSteps", MaxHeightSteps.ToString() },
                { "ignoreRegisterExtentions", IgnoreRegisterExtentions.ToString() },
                { "PathToArduino", PathToArduino},
                { "def_board", DefBoard.ToString() },
                { "UpKoof", UpKoof.ToString() },
                { "Language", Lang.ToString() },
                { "PreloadPlugins", PreloadPlugins.ToString() }
            };
            ExOperators.Save(Filename, a, "Don`t EDIT this FILE!");
        }
    }

}
