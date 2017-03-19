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
        /// Приватный параметр. Основные данные о точке. Координаты Х и Y.
        /// </summary>
        private VPoint _pnt;

        /// <summary>
        /// Приватный параметр. Параметр указывающий на то, с каким контуром граничит точка.
        /// </summary>
        private int _bordWith;

        /// <summary>
        /// Основные данные о точке. Координаты Х и Y.
        /// </summary>
        public VPoint Pnt
        {
            get { return _pnt;  }
            set { _pnt = value; }
        }

        /// <summary>
        /// Параметр указывающий на то, с каким контуром граничит точка.
        /// </summary>
        public int BordWith
        {
            get { return _bordWith;  }
            set { _bordWith = value; }
        }

        /// <summary>
        /// Нулевая точка, с координатами (0;0), цветом Color.Empty и BordWith равным 0.
        /// </summary>
        public static readonly VPointEx ZeroPoint = new VPointEx(0, 0, 0, Color.Empty);

        /// <summary>
        /// Создает новый екземпляр объекта VPointEx. С координатами (Х,Y) параметром n и цветом С.
        /// </summary>
        /// <param name="x">Х точки.</param>
        /// <param name="y">Y точки.</param>
        /// <param name="n">Параметр точки.</param>
        /// <param name="c">Цвет точки (нигде не используется).</param>
        public VPointEx(double x, double y, double n, Color c)
        {
            Pnt = new VPoint(x, y, c);
            BordWith = (int)n;
        }

        /// <summary>
        /// Создает новый екземпляр объекта VPointEx.
        /// </summary>
        public VPointEx()
        {
        }

        /// <summary>
        /// Возвращает информацию о точке в строковом виде.
        /// </summary>
        public override string ToString()
        {
            return string.Format("[{0}x{1}.{2}]", this.Pnt.X, this.Pnt.Y, this.BordWith);
        }

        /// <summary>
        /// Приведение экземпляра VPointEx к классу Point.
        /// </summary>
        public static explicit operator Point(VPointEx c)
        {
            return new Point((int)(c.Pnt.X), (int)(c.Pnt.Y));
        }

        /// <summary>
        /// Приведение экземпляра PointF к классу VPointEx.
        /// </summary>
        public static explicit operator VPointEx(PointF c)
        {
            return new VPointEx((c.X), (c.Y), 0, Color.Empty);
        }

        /// <summary>
        /// Приведение экземпляра VPointEx к классу PointF.
        /// </summary>
        public static explicit operator PointF(VPointEx c)
        {
            return new PointF((float)c.Pnt.X, (float)c.Pnt.Y);
        }


        /// <summary>
        /// Приведение экземпляра VPointEx к классу VPoint.
        /// </summary>
        public static explicit operator VPoint(VPointEx c)
        {
            return c.Pnt;
        }

        /// <summary>
        /// Оператор сравнения точек.
        /// </summary>
        public static bool operator ==(VPointEx a, VPointEx b)
        {
            return a.Pnt == b.Pnt && a.BordWith == b.BordWith;
        }

        /// <summary>
        /// Оператор неравенства точек.
        /// </summary>
        public static bool operator !=(VPointEx a, VPointEx b)
        {
            return a.Pnt != b.Pnt || a.BordWith != b.BordWith;
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
