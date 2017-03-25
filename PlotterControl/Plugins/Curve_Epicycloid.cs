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
            _info.Name = "Эпициклоида";
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%AD%D0%BF%D0%B8%D1%86%D0%B8%D0%BA%D0%BB%D0%BE%D0%B8%D0%B4%D0%B0";
            _info.Discription =
@"   Эпицикло́ида (от греч. ὲπί — на, над, при и κυκλος — круг, окружность) —
плоская кривая, образуемая фиксированной точкой окружности, катящейся по
внешней стороне другой окружности без скольжения.
    Величина k определяет форму эпициклоиды. При k=1 эпициклоида образует
кардиоиду, а при k=2 — нефроиду. Если k — несократимая дробь вида m/n,
то m — это количество каспов данной эпициклоиды, а n — количество полных
вращений катящейся окружности. Если k иррациональное число, то кривая
является незамкнутой и имеет бесконечное множество несовпадающих каспов.";
            _info.Creator ="";             
	    _info.Usage = "";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Эпициклоида при k = 3/4", image = PreviewImage(new Size(300, 300), (double)3/4, (double)36.0, 10) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Эпициклоида при k = 21/10", image = PreviewImage(new Size(300, 300), (double)21/10, (double)28.0, 20) };
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
            double oldX = centerX, oldY = centerY;
            for (double i = usenegative ? (-(CountOfCls * TwoPi)) : 0; i < CountOfCls * TwoPi; i += Step)
            {
                double alpha = Scale * i / TwoPi;
                double k = (i < 0)?knegative: kpositive;
                var x =  (double)ob * (k+1) * (Math.Cos(alpha) - Math.Cos((k+1)*alpha)/(k+1)) + centerX;
                var y = -(double)ob * (k+1) * (Math.Sin(alpha) - Math.Sin((k+1)*alpha)/(k+1)) + centerY;
                try { graphics.DrawLine(pen, (float)oldX, (float)oldY, (float)x, (float)y); } catch { };
                oldX = x;
                oldY = y;
            }
        }
    }
}
