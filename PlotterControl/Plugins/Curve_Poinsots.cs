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

	public struct Param
	{
	  public bool useCshc;
	  public double n;
	}

        public static void Init()
        {
            _info = new CurveInfo();
            _info.Name = "Спирали Пуансо";
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D0%BB%D0%B8_%D0%9F%D1%83%D0%B0%D0%BD%D1%81%D0%BE";
            _info.Discription =
@"   Спирали Пуансо (англ. Poinsot's spirals) — два типа спиралей, задаваемых
уравнениями:

   r = a * csch(n * phi)

   r = a * sech(n * phi)

где csch обозначает гиперболический косеканс, sech обозначает гиперболический
секанс. Спирали названы в честь французского математика Луи Пуансо.";
            _info.Creator = "";
            _info.Usage = "";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Спираль Пуансо r=csch(θ/3).", image = PreviewImage_(new Size(300, 300),10, 10,true, new Param(){ useCshc = true, n = (double)1/2}, 1.75) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Спираль Пуансо r=sech(θ/3).", image = PreviewImage_(new Size(300, 300), 100, 100, true, new Param(){ useCshc = false, n = (double)2}, 2) };
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
            int oldX = centerX, oldY = centerY;
            for (double i = usenegative ? (-(CountOfCls * TwoPi)) : 0; i < CountOfCls * TwoPi; i += Step)
            {
		Param param = (Param)ob;
                double p = 0;
                double alpha = Scale * i / TwoPi;
                double k = (i < 0)?knegative: kpositive;
                if (i == 0) p = double.MaxValue;
                else
		{
		     if(param.useCshc) p = k * csch(alpha * param.n);
		     else p = k * sech(alpha * param.n);
		}
                var x = (int)(p * Math.Cos(i)) + centerX;
                var y = -(int)(p * Math.Sin(i)) + centerY;
                try { graphics.DrawLine(pen, oldX, oldY, x, y); } catch { };
                oldX = x;
                oldY = y;
            }
        }

	private static double csch(double x)
	{
	   return (double)1/Math.Sinh(x);
	}

	private static double sech(double x)
	{
	   return (double)1/Math.Cosh(x);
	}
    }
}
