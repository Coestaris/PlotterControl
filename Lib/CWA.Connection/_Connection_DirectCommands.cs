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

namespace CWA.Connection
{
    public partial class DeviceMemorySetup
    {
        /// <summary>
        /// Прямая команда. Получить параметр "холостой ход".
        /// </summary>
        private readonly string Get_Idle = "getidle;";

        /// <summary>
        /// Прямая команда. Получить холостой параметр COM.
        /// </summary>
        private readonly string Get_Com = "getcom;";

        /// <summary>
        /// Прямая команда. Получить параметр "рабочий ход". 
        /// </summary>
        private readonly string Get_Work = "getwork;";

        /// <summary>
        /// Прямая команда. Получить параметр "pause".
        /// </summary>
        private readonly string Get_Pause = "getpause;";

        /// <summary>
        /// Прямая команда. Получить бинд пина №00.
        /// </summary>
        private readonly string Get_Pin_00 = "getp99;";

        /// <summary>
        /// Прямая команда. Получить бинд пина №01.
        /// </summary>
        private readonly string Get_Pin_01 = "getp91;";

        /// <summary>
        /// Прямая команда. Получить бинд пина №10.
        /// </summary>
        private readonly string Get_Pin_10 = "getp19;";

        /// <summary>
        /// Прямая команда. Получить бинд пина №11.
        /// </summary>
        private readonly string Get_Pin_11 = "getp11;";

        /// <summary>
        /// Прямая команда. Получить бинд пина №20.
        /// </summary>
        private readonly string Get_Pin_20 = "getp29;";

        /// <summary>
        /// Прямая команда. Получить бинд пина №21.
        /// </summary>
        private readonly string Get_Pin_21 = "getp21;";

        /// <summary>
        /// Прямая команда. Записать параметр "холостой ход".
        /// </summary>
        private readonly string Set_Idle = "setidle{0};";

        /// <summary>
        /// Прямая команда. Задать параметр "pause".
        /// </summary>
        private readonly string Set_Pause = "setpause{0};";

        /// <summary>
        /// Прямая команда. Записать параметр "com".
        /// </summary>
        private readonly string Set_Com = "setcom{0};";

        /// <summary>
        /// Прямая команда. Записать параметр "рабочий ход".
        /// </summary>
        private readonly string Set_Work = "setwork{0};";

        /// <summary>
        /// Прямая команда. Назначить бинд пину №00.
        /// </summary>
        private readonly string Set_Pin_00 = "setp99{0};";

        /// <summary>
        /// Прямая команда. Назначить бинд пину №01.
        /// </summary>
        private readonly string Set_Pin_01 = "setp91{0};";

        /// <summary>
        /// Прямая команда. Назначить бинд пину №10.
        /// </summary>
        private readonly string Set_Pin_10 = "setp19{0};";

        /// <summary>
        /// Прямая команда. Назначить бинд пину №11.
        /// </summary>
        private readonly string Set_Pin_11 = "setp11{0};";

        /// <summary>
        /// Прямая команда. Назначить бинд пину №20.
        /// </summary>
        private readonly string Set_Pin_20 = "setp29{0};";

        /// <summary>
        /// Прямая команда. Назначить бинд пину №21.
        /// </summary>
        private readonly string Set_Pin_21 = "setp21{0};";

        /// <summary>
        /// Прямая команда. Проверить на доступность.
        /// </summary>
        private readonly string Check = "testcc;";

        /// <summary>
        /// Прямая команда. Сбросить данные на устройстве.
        /// </summary>
        private readonly string ResetToDefault = "resetd;";

        /// <summary>
        /// Прямая команда. Получить данные с потенциометра.
        /// </summary>
        private readonly string Get_Speed = "getspeed;";

        /// <summary>
        /// Прямая команда. Ресет Ардуины.
        /// </summary>
        private readonly string ResetArduino = "resets;";
    }
}
