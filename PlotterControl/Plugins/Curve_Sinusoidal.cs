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
            _info.Name = "Синусоидальная спираль";
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%A1%D0%B8%D0%BD%D1%83%D1%81%D0%BE%D0%B8%D0%B4%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F_%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D0%BB%D1%8C";
            _info.Discription =
@"   Синусоида́льная спира́ль — семейство плоских кривых, определяемых классом
уравнений в полярных координатах r^n = a^n * sin(phi * n),где a — ненулевая
константа и n — рациональное число, не равное нулю. С учётом возможности
поворота кривой относительно начала координат уравнение также может быть
записано в виде r^n = a^n * cos(phi * n). Использование термина «спираль» в
данном случае не является точным, так как получаемые кривые по форме скорее
напоминают цветок.";
            _info.Creator = "";
            _info.Usage = "";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Синусоидальная спираль при a = 147,\nn = 1.66 или \"Лемниската Бернулли\"", image = PreviewImage(new Size(300, 300), 147, (double)1.66, 18) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Синусоидальная спираль при a = 20,\nn = -1/2 или \"Кардиоида\"", image = PreviewImage(new Size(300, 300), 20, (double)-1/2, 44) };
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
            double Scale = 4;
            var pen = new Pen(Color.Green);
            int centerX = size.Width / 2, centerY = size.Height / 2;
            graphics.Clear(Color.White);
            graphics.DrawLine(pen, 0, centerY, centerX * 2, centerY);
            graphics.DrawLine(pen, centerX, 0, centerX, centerY * 2);
            int oldX = centerX, oldY = centerY;
            for (double i = usenegative ? (-(CountOfCls * TwoPi)) : 0; i < CountOfCls * TwoPi; i += Step)
            {
                double p = 0;
                double alpha = Scale * i / TwoPi;
                double k = (i < 0)?knegative: kpositive;
                if (i == 0) p = double.MaxValue;
                else
		{
		     if(Math.Sin(alpha * (double)ob) < 0)  p = - k * Math.Pow(Math.Sin(alpha * (double)ob), 1/(double)ob);
                     else p = k * Math.Pow(Math.Sin(alpha * (double)ob), 1/(double)ob);
		}
                var x = (int)(p * Math.Cos(i)) + centerX;
                var y = -(int)(p * Math.Sin(i)) + centerY;
                try { graphics.DrawLine(pen, oldX, oldY, x, y); } catch { };
                oldX = x;
                oldY = y;
            }
        }
    }
}
