using System;
using CWA.Vectors;
using System.Drawing;
using CnC_WFA;

namespace Plugins
{
    static class CurvePlugin
    {
        static private CurveInfo _info;

        public static void Init()
        {
            _info = new CurveInfo();
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%96%D0%B5%D0%B7%D0%BB_(%D0%BF%D0%BB%D0%BE%D1%81%D0%BA%D0%B0%D1%8F_%D0%BA%D1%80%D0%B8%D0%B2%D0%B0%D1%8F)";
            _info.Name = "Кривая: Жезл";
            _info.Discription =
@"   Жезл — плоская трансцендентная кривая, определяемая уравнением (в 
полярной системе) p = a / sqrt(phi). ривая стремится из бесконечности
(где она асимптотически приближается к горизонтальной оси) к точке (0;0),
закручиваясь вокруг неё по спирали против часовой стрелки. Размер спирали 
определяется коэффициентом a. Имеет одну точку перегиба — (1/2; a*sqrt(2))";
            _info.Creator = "";
            _info.Usage = "";
            _info.MathematicalBasis = "p = k * phi";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Гиперболическая Спираль при k = 30", image = PreviewImage(new Size(300, 300), 30, null,  25) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Гиперболическая Спираль при k = -20", image = PreviewImage(new Size(300, 300), -20, null,  25) };
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

        public static Vect GetVector(ToVectorParams param)
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
                double k = (i < 0)?knegative: kpositive;
                if (i == 0) p = double.MaxValue;
                else

                    p = k / Math.Sqrt(alpha);

                var x = (int)(p * Math.Cos(i)) + centerX;
                var y = -(int)(p * Math.Sin(i)) + centerY;
                try { graphics.DrawLine(pen, oldX, oldY, x, y); } catch { };
                oldX = x;
                oldY = y;
            }
        }
    }
}
