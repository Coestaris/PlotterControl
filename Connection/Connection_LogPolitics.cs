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
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CWA
{
    /// <summary>
    /// Предоставляет и обслуживает параметры ведения логов всех библиотек пространства имен CNCWFA_API.
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

        private static bool _savePrintLog, _saveSerialMonitorLog, _saveManualControlLog, _saveMacroLog;
        private static bool _saveGlobalPrintLog, _saveGlobalVectLog;
        private static string _printLogNameFormat = "PrintLog_{y}.{m}.{d}_{h}.{min}.log";
        private static string _serialMonitorLogNameFormat = "SerialMonitorLog_{y}.{m}.{d}_{h}.{min}.log";
        private static string _manualControlLogNameFormat = "ManualControlLog_{y}.{m}.{d}_{h}.{min}.log";
        private static string _macroLogNameFormat = "MacroLog_{y}.{m}.{d}_{h}.{min}.log";
        private static string _globalPrintLogNameFormat = "PrintLog.log";
        private static string _globalVectLogNameFormat = "VectLog.log";

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
        public static bool SavePrintLog
        {
            get { return _savePrintLog; }
            set { _savePrintLog = value; }
        }

        /// <summary>
        /// Указывает на то, будут вестись логи сериал монитора.
        /// </summary>
        public static bool SaveSerialMonitorLog
        {
            get { return _saveSerialMonitorLog; }
            set { _saveSerialMonitorLog = value; }
        }

        /// <summary>
        /// Указывает на то, будут вестись логи ручного управления.
        /// </summary>
        public static bool SaveManualControlLog
        {
            get { return _saveManualControlLog; }
            set { _saveManualControlLog = value; }
        }

        /// <summary>
        /// Указывает на то, будут вестись логи макросов.
        /// </summary>
        public static bool SaveMacroLog
        {
            get { return _saveMacroLog; }
            set { _saveMacroLog = value; }
        }

        /// <summary>
        /// Указывает на то, будут вестись глобальные логи печати (1 сборный файл с общей информацие про каждую печать).
        /// </summary>
        public static bool SaveGlobalPrintLog
        {
            get { return _saveGlobalPrintLog; }
            set { _saveGlobalPrintLog = value; }
        }

        /// <summary>
        /// Указывает на то, будут вестись глобальные логи векторизации (1 сборный файл с общей информацие про каждую векторизацию).
        /// </summary>
        public static bool SaveGlobalVectLog
        {
            get { return _saveGlobalVectLog; }
            set { _saveGlobalVectLog = value; }
        }

        /// <summary>
        /// Формат имени лога печати.
        /// </summary>
        public static string PrintLogNameFormat
        {
            get { return _printLogNameFormat; }
            set { _printLogNameFormat = value; }
        }

        /// <summary>
        /// Формат имени лога сриал монитора.
        /// </summary>
        public static string SerialMonitorLogNameFormat
        {
            get { return _serialMonitorLogNameFormat; }
            set { _serialMonitorLogNameFormat = value; }
        }

        /// <summary>
        /// Формат имени лога ручного управления.
        /// </summary>
        public static string ManualControlLogNameFormat
        {
            get { return _manualControlLogNameFormat; }
            set { _manualControlLogNameFormat = value; }
        }

        /// <summary>
        /// Формат имени лога печати.
        /// </summary>
        public static string MacroLogNameFormat
        {
            get { return _macroLogNameFormat; }
            set { _macroLogNameFormat = value; }
        }

        /// <summary>
        /// Формат имени глобального лога печати.
        /// </summary>
        public static string GlobalPrintLogNameFormat
        {
            get { return _globalPrintLogNameFormat; }
            set { _globalPrintLogNameFormat = value; }
        }

        /// <summary>
        /// Формат имени глобального лога векторизации.
        /// </summary>
        public static string GlobalVectLogNameFormat
        {
            get { return _globalVectLogNameFormat; }
            set { _globalVectLogNameFormat = value; }
        }

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