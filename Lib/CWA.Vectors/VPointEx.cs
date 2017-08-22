/*=================================\
* CWA.Vectors\VPointEx.cs
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
        /// Создает новый екземпляр объекта <see cref="VPointEx"/>. С координатами (Х,Y).
        /// </summary>
        /// <param name="x">Х точки.</param>
        /// <param name="y">Y точки.</param>
        public VPointEx(double x, double y)
        {
            BasePoint = new VPoint(x, y, Color.Black);
            BordWith = 0;
        }

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
