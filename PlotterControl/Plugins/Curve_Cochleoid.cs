/*=================================\
* PlotterControl\Curve_Cochleoid.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:26:46
*=================================*/

using CnC_WFA;
using CWA.Vectors;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

/*ASSEMBLY INFO*/
namespace Plugins
{
    static class CurvePlugin
    {
        static private CurveInfo _info;

        public static void Init()
        {
            _info = new CurveInfo();
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D1%85%D0%BB%D0%B5%D0%BE%D0%B8%D0%B4%D0%B0";
            _info.Name = "Кохлеоида";
            _info.Discription =
@"   Кохлео́ида — плоская трансцендентная кривая. Возможны несколько способов
определить кохлеоиду геометрически. Рассмотрим всевозможные дуги данной
окружности, имеющие начало в одной и той же точке A. Тогда центры тяжести
таких дуг образуют кохлеоиду. Рассмотрим всевозможные окружности, касающиеся
данной прямой в одной и той же точке M. Отложим на каждой окружности от
точки M дугу заданной длины a. Тогда концы дуг образуют кохлеоиду.";
            _info.Creator = "";
            _info.Usage = "";
            _info.MathematicalBasis = "p = k * phi";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Кохлеоида при k = 50", image = PreviewImage(new Size(300, 300), 50, null, 20) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Кохлеоида при k = -500", image = PreviewImage(new Size(300, 300), -500, null, 5) };
        }

        public static Image PreviewImage(Size size, double k, object ob, double CountOfCls)
        {
            var a = new Bitmap(size.Height, size.Width);
            using (Graphics gr = Graphics.FromImage(a))
            {
                DrawCurve(gr, size, k, k, false, ob, CountOfCls);
            }
            return a;
        }

        public static Image PreviewImage_(Size size, double k1, double k2, bool useneg, object ob, double CountOfCls)
        {
            var a = new Bitmap(size.Height, size.Width);
            using (Graphics gr = Graphics.FromImage(a))
            {
                DrawCurve(gr, size, k1, k2, useneg, ob, CountOfCls);
            }
            return a;
        }

        public static GifImage PreviewImageGif()
        {
            return null;
        }

        public static Vector GetVector(ToVectorParams param)
        {
            return null;
        }

        public static CurveInfo GetInfo()
        {
            return _info;
        }

        private static void DrawCurve(Graphics graphics, Size size, double kpositive, double knegative, bool usenegative, object ob, double CountOfCls)
        {
            double TwoPi = 2 * Math.PI;
            double Step = TwoPi / 360;
            double Scale = 1;
            var pen = new Pen(Color.Green);
            int centerX = size.Width / 2, centerY = size.Height / 2;
            graphics.Clear(Color.White);
            graphics.DrawLine(pen, 0, centerY, centerX * 2, centerY);
            graphics.DrawLine(pen, centerX, 0, centerX, centerY * 2);
            int oldX = int.MaxValue, oldY = int.MaxValue;
            for (double i = usenegative ? -(CountOfCls * TwoPi) : 0; i < CountOfCls * TwoPi; i += Step)
            {
                double p = 0;
                double alpha = Scale * i / TwoPi;
                double k = (i < 0) ? knegative : kpositive;
                if (i == 0) p = double.MaxValue;
                else

                    p = (k * Math.Sin(alpha)) / alpha;

                var x = (int)(p * Math.Cos(i)) + centerX;
                var y = -(int)(p * Math.Sin(i)) + centerY;
                try { graphics.DrawLine(pen, oldX, oldY, x, y); } catch { };
                oldX = x;
                oldY = y;
            }
        }
    }
}