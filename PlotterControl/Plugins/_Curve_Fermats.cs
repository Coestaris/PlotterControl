/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

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
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* PlotterControl \ _Curve_Fermats.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 01.07.2017 13:09:58
*
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
            _info.Name = "Cпираль Ферма";
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D0%BB%D1%8C_%D0%A4%D0%B5%D1%80%D0%BC%D0%B0";
            _info.Discription =
@"   Спираль Ферма (иногда параболическая спираль) — спираль, задаваемая на
плоскости в полярных координатах уравнением r^2 = a^2 * phi. Является видом
Архимедовой спирали.";
            _info.Creator = "";
            _info.Usage = "";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Спираль Ферма при k = 20", image = PreviewImage(new Size(300, 300), 20, null, 10) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Симетричная Спираль Ферма при\nk = 30", image = PreviewImage_(new Size(300, 300), 30,30, true, null, 6) };
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
            for (double i = usenegative ? (-CountOfCls * TwoPi) : 0; i < CountOfCls * TwoPi; i += Step)
            {
                double p = 0;
                double alpha = Scale * i / TwoPi;
                double k = (i < 0)?knegative: kpositive;
                if (i == 0) p = double.MaxValue;
                else
		
		   p = k * Math.Sqrt(Math.Abs(alpha));
                
		var x = (int)(p * Math.Cos(i)) + centerX;
	        var y = -(int)(p * Math.Sin(i)) + centerY;
		if(i < 0 && usenegative) x = 300-x;        
	        try { graphics.DrawLine(pen, oldX, oldY, x, y); } catch { };
                oldX = x;
                oldY = y;
            }
        }
    }
}
