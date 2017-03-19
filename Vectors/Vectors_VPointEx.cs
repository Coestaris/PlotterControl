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

using System.Drawing;

namespace CWA.Vectors
{
    /// <summary>
    /// Предоставляет класс точки с дополнительным параметром, который используется при векторизации.
    /// </summary>
    public class VPointEx
    {
        /// <summary>
        /// Основные данные о точке. Координаты Х и Y.
        /// </summary>
        public VPoint BasePoint { get; set; }

        /// <summary>
        /// Параметр указывающий на то, с каким контуром граничит точка.
        /// </summary>
        public int BordWith { get; set; }

        /// <summary>
        /// Нулевая точка, с координатами (0;0), цветом <see cref="Color.Empty"/> и <see cref="BordWith"/> равным 0.
        /// </summary>
        public static readonly VPointEx ZeroPoint = new VPointEx(0, 0, 0, Color.Empty);

        /// <summary>
        /// Создает новый екземпляр объекта <see cref="VPointEx"/>. С координатами (Х,Y) параметром n и цветом С.
        /// </summary>
        /// <param name="x">Х точки.</param>
        /// <param name="y">Y точки.</param>
        /// <param name="n">Параметр точки.</param>
        /// <param name="c">Цвет точки (нигде не используется).</param>
        public VPointEx(double x, double y, double n, Color c)
        {
            BasePoint = new VPoint(x, y, c);
            BordWith = (int)n;
        }

        /// <summary>
        /// Создает новый екземпляр объекта <see cref="VPointEx"/>.
        /// </summary>
        public VPointEx()
        {
        }

        /// <summary>
        /// Возвращает информацию о точке в строковом виде.
        /// </summary>
        public override string ToString()
        {
            return string.Format("[{0}x{1}.{2}]", this.BasePoint.X, this.BasePoint.Y, this.BordWith);
        }

        /// <summary>
        /// Приведение экземпляра <see cref="VPointEx"/> к классу <see cref="Point"/>.
        /// </summary>
        public static explicit operator Point(VPointEx c)
        {
            return new Point((int)(c.BasePoint.X), (int)(c.BasePoint.Y));
        }

        /// <summary>
        /// Приведение экземпляра <see cref="PointF"/> к классу <see cref="VPointEx"/>.
        /// </summary>
        public static explicit operator VPointEx(PointF c)
        {
            return new VPointEx((c.X), (c.Y), 0, Color.Empty);
        }

        /// <summary>
        /// Приведение экземпляра <see cref="VPointEx"/> к классу <see cref="PointF"/>.
        /// </summary>
        public static explicit operator PointF(VPointEx c)
        {
            return new PointF((float)c.BasePoint.X, (float)c.BasePoint.Y);
        }


        /// <summary>
        /// Приведение экземпляра <see cref="VPointEx"/> к классу <see cref="VPoint"/>.
        /// </summary>
        public static explicit operator VPoint(VPointEx c)
        {
            return c.BasePoint;
        }

        /// <summary>
        /// Оператор сравнения точек.
        /// </summary>
        public static bool operator ==(VPointEx a, VPointEx b)
        {
            return a.BasePoint == b.BasePoint && a.BordWith == b.BordWith;
        }

        /// <summary>
        /// Оператор неравенства точек.
        /// </summary>
        public static bool operator !=(VPointEx a, VPointEx b)
        {
            return a.BasePoint != b.BasePoint || a.BordWith != b.BordWith;
        }

        /// <summary>
        /// Сравнивает данную точку с obj.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this == (VPointEx)obj;
        }

        /// <summary>
        /// Возвращает хеш-код класса.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
