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

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Описывает тип визуальной границы документа.
    /// </summary>
    public enum DocumentBorderStyle
    {
        /// <summary>
        /// Пустая (не отображать).
        /// </summary>
        None,
        
        /// <summary>
        /// Прямая из последовательных точек.
        /// </summary>
        Dot,

        /// <summary>
        /// Прямая из последовательных тире.
        /// </summary>
        Dash,

        /// <summary>
        /// Прямая из последовательных, удлененных тире.
        /// </summary>
        LongDash,

        /// <summary>
        /// Прямая из последовательных, чередующихся тире и точек.
        /// </summary>
        DashDot,

        /// <summary>
        /// Монолитная прямая линия.
        /// </summary>
        Default,

        /// <summary>
        /// Монолитная двойная прямая линия.
        /// </summary>
        DoubleLine,

        /// <summary>
        /// Монолитная тройная прямая линия.
        /// </summary>
        TripleLine,

        /// <summary>
        /// Монолитная волнистая линия.
        /// </summary>
        Wave,

        /// <summary>
        /// Монолитная двойная волнистая линия.
        /// </summary>
        DoubleWave,

        /// <summary>
        /// Небольшые четыре триугольника(угла) в углах документа.
        /// </summary>
        Triangle,

        /// <summary>
        /// Небольшые четыре сдвоенные триугольника(угла) в углах документа.
        /// </summary>
        DoubleTriangle
    }
}