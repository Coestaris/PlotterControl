/*=================================\
* PlotterControl\Curve_HyperbolicSpiral.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 19.08.2017 22:43:20
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
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%93%D0%B8%D0%BF%D0%B5%D1%80%D0%B1%D0%BE%D0%BB%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B0%D1%8F_%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D0%BB%D1%8C";
            _info.Name = "Гиперболическая Спираль";
            _info.Discription =
@"   Гиперболическая спираль — плоская трансцендентная кривая. Уравнение
гиперболической спирали в полярной систем координат является обратным 
для уравнения Архимедовой спирали. Кривая состоит из двух ветвей, симметричных
относительно прямой d. Начало координат является асимптотической 
точкой. Асимптота - прямая, параллельная полярной оси и отстоящая от нее на 
расстоянии a. Гиперболическая спираль получается при движении точки по
вращающейся прямой таким образом, что ее расстояние от центра вращения 
всегда будет обратно пропорционально углу поворота прямой, измеренному от
начального положения.";
            _info.Creator = "";
            _info.Usage = "";
            _info.MathematicalBasis = "p = k * phi";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Гиперболическая Спираль при k = 30", image = PreviewImage(new Size(300, 300), 30, null, 25) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Гиперболическая Спираль при k = 45,\nесли phi > 0 и k = 45, если phi < 0", image = PreviewImage_(new Size(300, 300), 40, -40, true, null, 7) };
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

                    p = k / alpha;

                var x = (int)(p * Math.Cos(i)) + centerX;
                var y = -(int)(p * Math.Sin(i)) + centerY;
                try { graphics.DrawLine(pen, oldX, oldY, x, y); } catch { };
                oldX = x;
                oldY = y;
            }
        }
    }
}
