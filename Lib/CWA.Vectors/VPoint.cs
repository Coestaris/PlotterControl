/*=================================\
* CWA.Vectors\VPoint.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
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
