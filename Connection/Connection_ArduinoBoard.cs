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
    /// <summary>
    /// Представляет информацию о плате Arduino. 
    /// </summary>
    public struct ArduinoBoard
    {
        /// <summary>
        /// Список плат, доступных в Arduino IDE.
        /// </summary>
        public static readonly ArduinoBoard[] Boards =
        {
            new ArduinoBoard() { DisplayName="Arduino Yún", ProgramName= "arduino:avr:yun" },
            new ArduinoBoard() { DisplayName="Arduino Uno", ProgramName= "arduino:avr:uno" },
            new ArduinoBoard() { DisplayName="Arduino Decimila", ProgramName= "arduino:avr:diecimila" },
            new ArduinoBoard() { DisplayName="Arduino Esplora", ProgramName= "arduino:avr:esplora" },
            new ArduinoBoard() { DisplayName="Arduino Mega", ProgramName= "arduino:avr:mega" },
            new ArduinoBoard() { DisplayName="Arduino Leonardo", ProgramName= "arduino:avr:leonardo" },
            new ArduinoBoard() { DisplayName="Arduino Micro", ProgramName= "arduino:avr:micro" },
            new ArduinoBoard() { DisplayName="Arduino Mini", ProgramName= "arduino:avr:mini" },
            new ArduinoBoard() { DisplayName="Arduino Nano", ProgramName= "arduino:avr:nano" },
            new ArduinoBoard() { DisplayName="Arduino Ethernet", ProgramName= "arduino:avr:ethernet" },
            new ArduinoBoard() { DisplayName="Arduino Fio", ProgramName= "arduino:avr:fio" },
            new ArduinoBoard() { DisplayName="Arduino BT", ProgramName= "arduino:avr:bt" },
            new ArduinoBoard() { DisplayName="LilyPad Arduino USB", ProgramName= "arduino:avr:LilyPadUSB" },
            new ArduinoBoard() { DisplayName="LilyPad Arduino", ProgramName= "arduino:avr:lilypad" },
            new ArduinoBoard() { DisplayName="Arduino Pro or Pro Mini", ProgramName= "arduino:avr:pro" },
            new ArduinoBoard() { DisplayName="Arduino NG or older", ProgramName= "arduino:avr:atmegang" },
            new ArduinoBoard() { DisplayName="Arduino Robot Control", ProgramName= "arduino:avr:robotControl" },
            new ArduinoBoard() { DisplayName="Arduino Robot Motor", ProgramName= "arduino:avr:robotMotor" },
            new ArduinoBoard() { DisplayName="Arduino Gemma", ProgramName= "arduino:avr:gemma" },
            new ArduinoBoard() { DisplayName="Arduino Yún Mini", ProgramName= "arduino:avr:yunmini" },
            new ArduinoBoard() { DisplayName="Arduino Industrial 101", ProgramName= "arduino:avr:chiwawa" },
            new ArduinoBoard() { DisplayName="Linino One", ProgramName= "arduino:avr:one" },
            new ArduinoBoard() { DisplayName="Arduino Uno WiFi", ProgramName= "arduino:avr:unowifi" },
        };
        
        /// <summary>
        /// Отображаеммое имя платы.
        /// </summary>
        public string DisplayName { get; internal set; }

        /// <summary>
        /// Программное имя платы.
        /// </summary>
        public string ProgramName { get; internal set; }

        /// <summary>
        /// Преобразует экземпляр <see cref="ArduinoBoard"/> к соотвествующему <see cref="string"/>.
        /// </summary>
        public override string ToString()
        {
            return ProgramName;
        }
    }
}
