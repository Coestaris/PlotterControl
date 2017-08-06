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

namespace CWA.Printing.Macro
{
    /// <summary>
    /// Описывает тип макроса.
    /// </summary>
    public enum MacroElemType
    {
        /// <summary>
        /// Только перемещение пера (вверх/вниз).
        /// </summary>
        Tool,

        /// <summary>
        /// Перемещение инструмента в конкретную точку.
        /// </summary>
        MoveToPoint,

        /// <summary>
        /// Смещение инструмента на заданную дельту.
        /// </summary>
        MoveRelative,

        /// <summary>
        /// Только задержка.
        /// </summary>
        Delay,

        /// <summary>
        /// Ничего не делать.
        /// </summary>
        None,

        /// <summary>
        /// Перемещение пера (вверх/вниз) с задержкой после.
        /// </summary>
        ToolAndDelay,

        /// <summary>
        /// Перемещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MoveToPointAndDelay,

        /// <summary>
        /// Перемещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MoveRelativeAndDelay
    }
}