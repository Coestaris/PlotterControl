/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

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
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.Vectors \ VPoint.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System.Drawing;

namespace CWA.Vectors
{
    /// <summary>
    /// Предоставляет класс точки, который используется библиотекой.
    /// </summary>
    public class VPoint
    {
        /// <summary>
        /// Х координата точки.
        /// </summary>
        public double X { set; get; }

        /// <summary>
        /// Y координата точки.
        /// </summary>
        public double Y { set; get; }


        /// <summary>
        /// Цвет точки.
        /// </summary>
        public Color Color { set; get; }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="VPoint"/>. Где (x,y) - координаты точки, с - ее цвет.
        /// </summary>
        /// <param name="x">Х точки.</param>
        /// <param name="y">Y точки.</param>
        /// <param name="c">Цвет точки.</param>
        public VPoint(double x, double y, Color c)
        {
            X = x;
            Y = y;
            Color = c;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="VPoint"/>.
        /// </summary>
        public VPoint()
        {
        }

        /// <summary>
        /// Оператор приведения к классу <see cref="Point"/>.
        /// </summary>
        public static explicit operator Point(VPoint c)
        {
            return new Point((int)c.X,(int)c.Y);
        }

        /// <summary>
        /// Оператор приведения к классу <see cref="VPointEx"/>.
        /// </summary>
        public static explicit operator VPointEx(VPoint c)
        {
            return new VPointEx(c.X, c.Y, 0, c.Color);
        }

        /// <summary>
        /// Оператор сравнения точек.
        /// </summary>
        public static bool operator ==(VPoint a, VPoint b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        /// <summary>
        /// Оператор неравенства точек.
        /// </summary>
        public static bool operator !=(VPoint a, VPoint b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        /// <summary>
        /// Сравнивает данную точку с obj.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this == (VPoint)obj;
        }

        /// <summary>
        /// Возвращает хеш-код класса.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Меняет коодринаты X и Y местами.
        /// </summary>
        public static VPoint SwapCoordinates(VPoint pn)
        {
            return new VPoint(pn.Y, pn.X, Color.Black);
        }

        /// <summary>
        /// Меняет коодринаты X и Y данной точки местами.
        /// </summary>
        public void SwapCoordinates()
        {
            double _x = X, _y = Y;
            Helper.Swap(ref _x, ref _y);
            X = _x; Y = _y;
        }

        /// <summary>
        /// Оператор приведения к классу PointF.
        /// </summary>
        public static explicit operator PointF(VPoint v)
        {
            return new PointF((float)v.X, (float)v.Y);
        }
    }
}
