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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CWA.Vectors
{
    /// <summary>
    /// Описывает дополнительные методы для обработки и работы с векторами.
    /// </summary>
    public class VectProcessor
    {
        /// <summary>
        /// Количество точек (коофициент) контура, при котором он будет считатся вертикальной линией. 
        /// По умолчанию 0,66 (или 2/3). То есть, если более чем 2/3 точек контура имеют одинаковую координату X и
        /// не значительно изменяющууся координату Y, то этот контур будет удален методом SMDelete().
        /// </summary>
        public static float SMDeleteCof { get; set; } = 0.66f;
        
        /// <summary>
        /// Отражает вектор по оси X.
        /// </summary>
        /// <param name="v">Вектор для выполнения операции.</param>
        public static Vector FlipX(Vector v)
        {
            for (int i = 0; i <= v.RawData.Length - 1; i++)
                for (int ii = 0; ii <= v.RawData[i].Length - 1; ii++)
                {
                    v.RawData[i][ii] = new VPointEx(v.Header.Height - v.RawData[i][ii].BasePoint.X, v.RawData[i][ii].BasePoint.Y, 0, Color.Empty);
                }
            return v;
        }

        /// <summary>
        /// Отражает вектор по оси Y.
        /// </summary>
        /// <param name="v">Вектор для выполнения операции.</param>
        public static Vector FlipY(Vector v)
        {
            for (int i = 0; i <= v.RawData.Length - 1; i++)
                for (int ii = 0; ii <= v.RawData[i].Length - 1; ii++)
                {
                    v.RawData[i][ii] = new VPointEx(v.RawData[i][ii].BasePoint.X, v.Header.Width - v.RawData[i][ii].BasePoint.Y, 0, Color.Empty);
                }
            return v;
        }

        /// <summary>
        /// Масштабирует вектор к заданному размеру.
        /// </summary>
        /// <param name="v">Вектор для выполнения операции.</param>
        /// <param name="newsize">Новый размер вектора.</param>
        public static Vector Resize(Vector v, SizeF newsize)
        {
            double kx = v.Header.Width / newsize.Width;
            double ky = v.Header.Height / newsize.Height;
            for (int i = 0; i <= v.RawData.Length - 1; i++)
                for (int ii = 0; ii <= v.RawData[i].Length - 1; ii++)
                {
                    v.RawData[i][ii] = new VPointEx(v.RawData[i][ii].BasePoint.X * kx, v.RawData[i][ii].BasePoint.Y * ky, 0, Color.Empty);
                }
            v = new Vector(newsize, v.RawData);
            return v;
        }

        /// <summary>
        /// Поворачивает вектор на 90°, 180° или 270°.
        /// </summary>
        /// <param name="v">Вектор для выполнения операции.</param>
        /// <param name="deg">Количество градусов для поворота. Может принемать значения: 0°, 90°, 180°, 270° или 360°.
        /// остальные будут игнорироватся. Для поворота на любой другой угол используйте метод RotateByCAngle.</param>
        public static Vector RotateBy(Vector v, int deg)
        {
            //TODO: WRITE DAT METHOD!
            /*for (int i = 0; i <= v.RawData.Length - 1; i++)
                for (int ii = 0; ii <= v.RawData[i].Length - 1; ii++)
                {
                    v.RawData[i][ii] = new VPointEx(v.Header.Width - v.RawData[i][ii].Pnt.y, v.RawData[i][ii].Pnt.x, 0, Color.Empty);
                } - 270 */
            return v;
        }

        /// <summary>
        /// Поворачивает вектор на заданный угол относительно заданной точки.
        /// </summary>
        /// <param name="v">Вектор для выполнения операции.</param>
        /// <param name="angle">Угол поворота (в градусах).</param>
        /// <param name="RC">Относительная точка поворота (не обязательно в пределах вектора).</param>
        public static Vector RotateByCAngle(Vector v, double angle, PointF RC)
        {
            double Xp = RC.X;
            double Yp = RC.Y;
            for (int i = 0; i <= v.RawData.Length - 1; i++)
                for (int ii = 0; ii <= v.RawData[i].Length - 1; ii++)
                {
                    double X = v.RawData[i][ii].BasePoint.X;
                    double Y = v.RawData[i][ii].BasePoint.Y;
                    double r = Math.Sqrt((X - Xp) * (X - Xp) + (Y - Yp) * (Y - Yp));
                    X = Xp + r * Math.Cos(angle);
                    Y = Yp + r * Math.Sin(angle);
                    double newX = Xp + (X - Xp) * Math.Cos(angle) - (Y - Yp) * Math.Sin(angle);
                    double newY = Yp + (Y - Yp) * Math.Cos(angle) + (X - Xp) * Math.Sin(angle);
                    v.RawData[i][ii] = new VPointEx(newX, newY, 0, Color.Empty);
                }
            return v;
        }

        /// <summary>
        /// Удаляет из вектора монолитные вертикальные линии (дефект векторизации) и удаляет контура,
        /// с количеством точек, меньшем указанного параметра.
        /// </summary>
        /// <param name="v">Вектор для выполнения операции.</param>
        /// <param name="threshold">Порог удаления контуров.</param>
        public static Vector SMDelete(Vector v, int threshold)
        {
            List<VPointEx[]> tm = new List<VPointEx[]>();
            tm = v.RawData.ToList();
            for (int i = tm.Count - 1; i > 0; i--) if (tm[i].Length < threshold) tm.RemoveAt(i);
            v.RawData = tm.ToArray();
            int ind = -1;
            for (int i = 0; i <= v.RawData.Length - 1; i++)
            {
                int b = 0;
                for (int ii = 0; ii <= v.RawData[i].Length - 1; ii++)
                    if (v.RawData[i][ii].BasePoint.Y == 2) b++;
                if (b > SMDeleteCof * v.RawData[i].Length)
                {
                    ind = i;
                    break;
                }
            }
            if (ind != -1)
            {
                var h = v.RawData.ToList();
                h.RemoveAt(ind);
                v.RawData = h.ToArray();
            }
            for (int i = 0; i <= v.RawData.Length - 1; i++)
            {
                var h = v.RawData[i].ToList();
                h.RemoveAt(h.Count - 1);
                v.RawData[i] = h.ToArray();
            }
            var l = v.RawData.ToList();
            for (int i = v.RawData.Length - 1; i >= 0; i--)
            {
                if (l[i].Length == 0) l.RemoveAt(i);
            }
            v.RawData = l.ToArray();
            return v;
        }
    }
}
