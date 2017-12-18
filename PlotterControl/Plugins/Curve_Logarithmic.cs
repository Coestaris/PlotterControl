/*=================================\
* PlotterControl\Curve_Logarithmic.cs
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
            _info.Name = "Логарифмическая спираль";
            _info.LearnMore = "https://ru.wikipedia.org/wiki/%D0%9B%D0%BE%D0%B3%D0%B0%D1%80%D0%B8%D1%84%D0%BC%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B0%D1%8F_%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D0%BB%D1%8C";
            _info.Discription =
@"   Логарифми́ческая спира́ль или изогональная спираль — особый вид спирали, 
часто встречающийся в природе.";
            _info.Creator =
@"   Логарифмическая спираль была впервые описана Декартом и позже 
интенсивно исследована Бернулли, который называл её Spira mirabilis —
«удивительная спираль». Декарт искал кривую, обладающую свойством,
подобным свойству окружности, так чтобы касательная в каждой точке 
образовывала с радиус-вектором в каждой точке один и тот же угол. Он
показал, что это условие равносильно тому, что полярные углы для точек 
кривой пропорциональны логарифмам радиус-векторов.";
            _info.Usage =
@"   Логарифмическая спираль, несомненно, является спиралью, которая 
наиболее часто встречается в природе. Царство животных предоставляет нам 
примеры спиралей раковин улиток и моллюсков. Все эти формы указывают на 
природное явление: процесс накручивания связан с процессом роста. В самом
деле, раковина улитки – это не больше, не меньше, чем конус, накрученный
на себя. Рога жвачных животных тоже, но они к тому же витые. И хотя физические
законы роста у разных видов различны, математические законы, которые управляют 
ими, одинаковы: все они имеют в основе геометрическую спираль, самоподобную
кривую. Если мы внимательно посмотрим на рост раковин и рогов, то заметим
еще одно любопытное свойство: рост происходит только на одном конце. И это
свойство сохраняет форму полностью уникальную среди кривых в математике, форму 
логарифмической, или равноугольной спирали.";
        }

        public static CurveExample Exmpl1()
        {
            return new CurveExample() { Discr = "\"Золотая\" спираль", image = PreviewImage(new Size(300, 300), 1, 1.61803, 25) };
        }

        public static CurveExample Exmpl2()
        {
            return new CurveExample() { Discr = "Логарифмическая Спираль при k = 1 и b = 0.2", image = PreviewImage(new Size(300, 300), 1, 0.2, 24) };
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
            double ob_ = (double)ob;
            for (double i = usenegative ? (-(CountOfCls * TwoPi)) : 0; i < CountOfCls * TwoPi; i += Step)
            {
                double p = 0;
                double alpha = Scale * i / TwoPi;
                double k = (i < 0) ? knegative : kpositive;
                if (i == 0) p = 0;
                else

                    p = k * Math.Log(alpha * ob_, Math.E);

                var x = (int)(p * Math.Cos(i)) + centerX;
                var y = -(int)(p * Math.Sin(i)) + centerY;
                try { graphics.DrawLine(pen, oldX, oldY, x, y); } catch(Exception e)
                {
                    //Console.WriteLine("Err{0}. {1}", e.GetType().FullName, e.Message);
                };
                oldX = x;
                oldY = y;
            }
        }
    }
}