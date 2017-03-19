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
    /// ќписывает тип макроса, в сокращенном виде, удобном дл€ хранени€ в файле. 
    /// ¬се варианты - эквиваленты вариантам перечислени€ MacroElemType.
    /// </summary>
    public enum MacroElemTypeShorted
    {
        /// <summary>
        /// Ёквивалент: MacroElemType.Tool. “олько перемещение пера (вверх/вниз).
        /// </summary>
        T,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveToPoint. ѕеремещение инструмента в конкретную точку.
        /// </summary>
        MTP,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveRelative. —мещение инструмента на заданную дельту.
        /// </summary>
        MR,

        /// <summary>
        /// Ёквивалент: MacroElemType.Delay. “олько задержка.
        /// </summary>
        D,

        /// <summary>
        /// Ёквивалент: MacroElemType.None. Ќичего не делать.
        /// </summary>
        N,

        /// <summary>
        /// Ёквивалент: MacroElemType.ToolAndDelay. ѕеремещение пера (вверх/вниз) с задержкой после.
        /// </summary>
        TAD,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveToPointAndDelay. ѕеремещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MTPAD,

        /// <summary>
        /// Ёквивалент: MacroElemType.MoveRelativeAndDelay. ѕеремещение инструмента в конкретную точку с задержкой после.
        /// </summary>
        MRAD
    }
}
