/*=================================\
* CWA.Connection\Connection_LogPolitics.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using CWA.Connection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CWA
{
    /// <summary>
    /// Предоставляет и обслуживает параметры ведения логов всех библиотек пространства имен CWA.
    /// </summary>
    public abstract class GlobalOptionsLogPolitics
    {
        /// <summary>
        /// Имя рабочего файла с опциями.
        /// </summary>
        public static string Filename;

        /// <summary>
        /// Имя выходной папки, куда будут складыватся все логи.
        /// </summary>
        public static string OutPutDir;

        /// <summary>
        /// Форматирует строку заданного формата соответсвующим экземяром DateTime.
        /// {y} - год, {m} - месяц, {d} - день, {h} - час, {min} - минута. Пример строки "MacroLog_{y}.{m}.{d}_{h}.{min}.log".
        /// </summary>
        /// <returns></returns>
        public static string CorrectInsert(DateTime dt, string s)
        {
            s = s.Replace("{y}", dt.Year.ToString());
            s = s.Replace("{m}", dt.Month.ToString());
            s = s.Replace("{d}", dt.Day.ToString());
            s = s.Replace("{h}", dt.Hour.ToString());
            s = s.Replace("{min}", dt.Minute.ToString());
            return s;
        }

        /// <summary>
        /// Указывает на то, будут вестись логи печати.
        /// </summary>
        public static bool SavePrintLog { get; set; }

        /// <summary>
        /// Указывает на то, будут вестись логи сериал монитора.
        /// </summary>
        public static bool SaveSerialMonitorLog { get; set; }

        /// <summary>
        /// Указывает на то, будут вестись логи ручного управления.
        /// </summary>
        public static bool SaveManualControlLog { get; set; }

        /// <summary>
        /// Указывает на то, будут вестись логи макросов.
        /// </summary>
        public static bool SaveMacroLog { get; set; }

        /// <summary>
        /// Указывает на то, будут вестись глобальные логи печати (1 сборный файл с общей информацие про каждую печать).
        /// </summary>
        public static bool SaveGlobalPrintLog { get; set; }
        
        /// <summary>
        /// Указывает на то, будут вестись глобальные логи векторизации (1 сборный файл с общей информацие про каждую векторизацию).
        /// </summary>
        public static bool SaveGlobalVectLog { get; set; }

        /// <summary>
        /// Формат имени лога печати.
        /// </summary>
        public static string PrintLogNameFormat { get; set; } = "PrintLog_{y}.{m}.{d}_{h}.{min}.log";

        /// <summary>
        /// Формат имени лога сриал монитора.
        /// </summary>
        public static string SerialMonitorLogNameFormat { get; set; } = "SerialMonitorLog_{y}.{m}.{d}_{h}.{min}.log";

        /// <summary>
        /// Формат имени лога ручного управления.
        /// </summary>
        public static string ManualControlLogNameFormat { get; set; } = "ManualControlLog_{y}.{m}.{d}_{h}.{min}.log";

        /// <summary>
        /// Формат имени лога печати.
        /// </summary>
        public static string MacroLogNameFormat { get; set; } = "MacroLog_{y}.{m}.{d}_{h}.{min}.log";

        /// <summary>
        /// Формат имени глобального лога печати.
        /// </summary>
        public static string GlobalPrintLogNameFormat { get; set; } = "PrintLog.log";

        /// <summary>
        /// Формат имени глобального лога векторизации.
        /// </summary>
        public static string GlobalVectLogNameFormat { get; set; } = "VectLog.log";

        /// <summary>
        /// Удалить все логи в папке OutPutDir.
        /// </summary>
        public static void DeleteLogs()
        {
        }

        /// <summary>
        /// Установить все параметры по умаолчанию.
        /// </summary>
        public static void Reset()
        {
        }

        /// <summary>
        /// Загрузить параметры с файла.
        /// </summary>
        public static void Load()
        {
            if (!File.Exists(Filename))
            {
                MessageBox.Show("Can`t find logPolitics file.\n'" + Filename + "' not found\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    Reset();
                    Save();
                }
                catch
                {
                    MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                MessageBox.Show("Done", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var data = ExOperators.Load(Filename);
            SavePrintLog = bool.Parse(data["SavePrintLog"]);
            SaveSerialMonitorLog = bool.Parse(data["SaveSerialMonitorLog"]);
            SaveManualControlLog = bool.Parse(data["SaveManualControlLog"]);
            SaveGlobalPrintLog = bool.Parse(data["SaveGlobalPrintLog"]);
            SaveGlobalVectLog = bool.Parse(data["SaveGlobalVectLog"]);
            PrintLogNameFormat = data["PrintLogNameFormat"];
            SerialMonitorLogNameFormat = data["SerialMonitorLogNameFormat"];
            ManualControlLogNameFormat = data["ManualControlLogNameFormat"];
            MacroLogNameFormat = data["MacroLogNameFormat"];
            GlobalPrintLogNameFormat = data["GlobalPrintLogNameFormat"];
            GlobalVectLogNameFormat = data["GlobalVectLogNameFormat"];
        }

        /// <summary>
        /// Сохранить параметры в файл.
        /// </summary>
        public static void Save()
        {
            var a = new Dictionary<string, string>
            {
                { "SavePrintLog", SavePrintLog.ToString() },
                { "SaveSerialMonitorLog", SaveSerialMonitorLog.ToString() },
                { "SaveManualControlLog", SaveManualControlLog.ToString() },
                { "SaveMacroLog", SaveMacroLog.ToString() },
                { "SaveGlobalPrintLog", SaveGlobalPrintLog.ToString() },
                { "SaveGlobalVectLog", SaveGlobalVectLog.ToString() },
                { "PrintLogNameFormat", PrintLogNameFormat },
                { "SerialMonitorLogNameFormat", SerialMonitorLogNameFormat },
                { "ManualControlLogNameFormat", ManualControlLogNameFormat },
                { "MacroLogNameFormat", MacroLogNameFormat },
                { "GlobalPrintLogNameFormat", GlobalPrintLogNameFormat },
                { "GlobalVectLogNameFormat", GlobalVectLogNameFormat }
            };
            ExOperators.Save(Filename, a, "Don`t EDIT this FILE!");
        }
    }
}
