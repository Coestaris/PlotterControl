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
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%90%D1%80%D1%85%D0%B8%D0%BC%D0%B5%D0%B4%D0%BE%D0%B2%D0%B0_%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D0%BB%D1%8C";
            _info.Name = "Спираль Архимеда";
            _info.Discription =
@"   Архимедова спираль — спираль, плоская кривая, траектория точки M, которая
равномерно движется вдоль луча OV сначалом в O, в то время как сам луч
OV равномерно вращается вокруг O. Другими словами, расстояние ρ = OM
пропорционально углу поворота φ луча OV. Повороту луча OV на один и тот же
угол соответствует одно и то же приращение ρ.";
            _info.Creator =
@"   Архимедова спираль была открыта Архимедом. Это произошло в III веке до н.э.,
когда он экспериментировал с компасом.Он тянул стрелку компаса с постоянной 
скоростью, вращая сам компас по часовой стрелке. Получившаяся кривая была c
пиралью, которая сдвигались на ту же величину, на которую поворачивался компас, 
и между витками спирали сохранялось одно и то же расстояние.";
            _info.Usage =
@"   В III веке да нашей эры Архимед на основе своей спирали изобрёл винт, который
успешно применяли для передачи воды в оросительные каналы из водоёмов, 
расположенных ниже. Позже на основе винта Архимеда создали шнек («улитку»). Его
очень известная разновидность – винтовой ротор в мясорубке. Шнек используют
в механизмах для перемешивания материалов различной консистенции. В технике 
нашли применение антенны в виде спирали Архимеда.Самоцентрирующийся патрон 
выполнен по спирали Архимеда. Звуковые дорожки на CD и DVD дисках также имеют 
форму спирали Архимеда. Спираль Архимеда нашла практическое применение в математике,
технике, архитектуре, машиностроении.";
            _info.MathematicalBasis = "p = k * phi";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "Спираль Архимеда при k = 1", image = PreviewImage(new Size(300, 300), 1, null,  25) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Спираль Архимеда при k = 3,\nесли phi > 0 и k = -4, если phi < 0", image = PreviewImage_(new Size(300, 300), 3, -4, true, null,  7) };
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

        private static void DrawCurve(Graphics graphics, Size size, double kpositive, double knegative, bool usenegative,  object ob, double CountOfCls)
        {
            double TwoPi = 2 * Math.PI;
            double Step = TwoPi / 360;
            int Scale = 10;
            var pen = new Pen(Color.Black);
            int centerX = size.Width / 2, centerY = size.Height / 2;
            graphics.Clear(Color.White);
            graphics.DrawLine(pen, 0, centerY, centerX * 2, centerY);
            graphics.DrawLine(pen, centerX, 0, centerX, centerY * 2);
            pen = new Pen(Color.Green);
            int oldX = centerX, oldY = centerY;
            for (double i = usenegative ? -(CountOfCls * TwoPi) : 0; i < CountOfCls * TwoPi; i += Step)
            {
                double p = 0;
                double alpha = Scale * i / TwoPi;

                if (i < 0) p = knegative * alpha;
                else p = kpositive * alpha;

                var x = (int)(p * Math.Cos(i)) + centerX;
                var y = (int)(p * Math.Sin(i)) + centerY;
                graphics.DrawLine(pen, oldX, oldY, x, y);
                oldX = x;
                oldY = y;
            }
        }
    }
}
