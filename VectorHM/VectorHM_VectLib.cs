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
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CWA.Vectors
{
    /// <summary>
    /// Предостовляет дополнительные методы для работы с векторами.
    /// </summary>
    public class VectLib
    {
        /// <summary>
        /// Приватный параметр опций.
        /// </summary>
        private VectLibOptions _options = new VectLibOptions();

        /// <summary>
        /// Опции для методов данного экземпляра.
        /// </summary>
        public VectLibOptions Options
        {
            get { return _options; }
        }

        /// <summary>
        /// Переводит экземпляр к 2й цветовой модели преобразования.
        /// </summary>
        public void ToSecondColorModel()
        {
            Options.GrayConvertRCof = 0.2125f;
            Options.GrayConvertGCof = 0.7154f;
            Options.GrayConvertBCof = 0.0721f;
        }

        /// <summary>
        /// Применяет оператор Собеля к изображению.
        /// </summary>
        /// <param name="bmp">Изображение для выполнени операций.</param>
        public void Sobel(ref Bitmap bmp)
        {
            Bitmap b = bmp;
            Bitmap bb = bmp;
            int width = b.Width;
            int height = b.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];
            int limit = Options.SobelOperatorLimFonf * Options.SobelOperatorLimFonf;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = b.GetPixel(i, j).R;
                    allPixG[i, j] = b.GetPixel(i, j).G;
                    allPixB[i, j] = b.GetPixel(i, j).B;
                }
            }
            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            for (int i = 1; i < b.Width - 1; i++)
            {
                for (int j = 1; j < b.Height - 1; j++)
                {
                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;
                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixR[i + hw, j + wi];
                            new_rx += gx[wi + 1, hw + 1] * rc;
                            new_ry += gy[wi + 1, hw + 1] * rc;
                            gc = allPixG[i + hw, j + wi];
                            new_gx += gx[wi + 1, hw + 1] * gc;
                            new_gy += gy[wi + 1, hw + 1] * gc;
                            bc = allPixB[i + hw, j + wi];
                            new_bx += gx[wi + 1, hw + 1] * bc;
                            new_by += gy[wi + 1, hw + 1] * bc;
                        }
                    }
                    if (new_rx * new_rx + new_ry * new_ry > limit || new_gx * new_gx + new_gy * new_gy > limit || new_bx * new_bx + new_by * new_by > limit) bb.SetPixel(i, j, Color.Black);
                    else bb.SetPixel(i, j, Color.Transparent);
                }
            }
            bmp = bb;
        }

        /// <summary>
        /// Применяет размытие по Гаусу к изображению.
        /// </summary>
        /// <param name="bmp">Изображение для выполнени операций.</param>
        public void Gauss(ref Bitmap bmp)
        {
            double sigma = Options.GaussBlurSigma;
            short k = Options.GaussBlurKCof;
            int kk;
            int x, y, u, v;
            double p;
            byte[,] M;
            double[,] H;
            Color cl;
            kk = 2 * k;
            sigma *= sigma;
            H = new double[kk + 1, kk + 1];
            M = new byte[bmp.Width + kk, bmp.Height + kk];
            for (x = 0; x <= kk; x++)
                for (y = 0; y <= kk; y++)
                {
                    p = -((x - k - 1) * (x - k - 1) + (y - k - 1) * (y - k - 1));
                    H[x, y] = (1.0 / (2.0 * Math.PI * sigma) * Math.Exp(p / (2.0 * sigma)));
                }
            for (x = 0; x < bmp.Width + kk; x++)
                for (y = 0; y < bmp.Height + kk; y++)
                {
                    if (y <= k)
                    {
                        if (x < k) cl = bmp.GetPixel(0, 0);
                        else if (x >= (bmp.Width + k)) cl = bmp.GetPixel(bmp.Width - 1, 0);
                        else cl = bmp.GetPixel(x - k, 0);
                    }
                    else if (y >= (bmp.Height + k))
                    {
                        if (x < k) cl = bmp.GetPixel(0, bmp.Height - 1);
                        else if (x >= (bmp.Width + k)) cl = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
                        else cl = bmp.GetPixel(x - k, bmp.Height - 1);
                    }
                    else
                    {
                        if (x < k) cl = bmp.GetPixel(0, y - k);
                        else if (x >= (bmp.Width + k)) cl = bmp.GetPixel(bmp.Width - 1, y - k);
                        else cl = bmp.GetPixel(x - k, y - k);
                    }
                    M[x, y] = cl.R;
                }
            for (x = 0; x < bmp.Width; x++)
                for (y = 0; y < bmp.Height; y++)
                {
                    p = 0.0;
                    for (u = 0; u <= kk; u++)
                        for (v = 0; v <= kk; v++)
                            p += H[u, v] * M[u + x, v + y];
                    bmp.SetPixel(x, y, Color.FromArgb((byte)p, (byte)p, (byte)p));
                }
        }

        /// <summary>
        /// Урезает и округляет значение к пределам типа byte.
        /// </summary>
        private byte Border(float x)
        {
            return x > 255 ? (byte)255 : (byte)x;
        }

        /// <summary>
        /// Преобразовует изображение к формату "оттенков серого" методом среднего цвета.
        /// </summary>
        /// <param name="bmp">Изображение для выполнени операций.</param>
        public Bitmap AverageGrayForm(Bitmap bmp)
        {
            for (int x = 0; x <= bmp.Width - 1; x++)
                for (int y = 0; y <= bmp.Height - 1; y++)
                {
                    bmp.SetPixel(x, y, Helper.NewOneChColor(Helper.GetAverageColor(bmp.GetPixel(x, y))));
                }
            return bmp;
        }

        /// <summary>
        /// Преобразовует изображение к формату "черно-белого" (2х цветного) методом среднего цвета.
        /// </summary>
        /// <param name="bmp">Изображение для выполнени операций.</param>
        public Bitmap HardBW(Bitmap bmp, int threshold)
        {
            for (int x = 0; x <= bmp.Width - 1; x++)
                for (int y = 0; y <= bmp.Height - 1; y++)
                {
                    bmp.SetPixel(x, y, (Helper.GetAverageColor(bmp.GetPixel(x, y)) > threshold ? Color.White : Color.Black));
                }
            return bmp;
        }

        /// <summary>
        /// Многопоточно преобразовует изображение к формату "оттенков серого" методом коофициентов.
        /// </summary>
        /// <param name="bmp">Изображение для выполнени операций.</param>
        /// <param name="strcnt">Количество потоков выполнения операции.</param>
        public Image ToGrayMultStream(Image bmp, int strcnt)
        {
            Thread[] strs = new Thread[strcnt];
            Dictionary<int, Bitmap> res = new Dictionary<int, Bitmap>();
            for (int i = 0; i <= strs.Length - 1; i++) strs[i] = new Thread(ToGray);
            for (int i = 0; i <= strs.Length - 1; i++) res.Add(strs[i].ManagedThreadId, null);
            var parts = GetVertCutImage(new Bitmap(bmp), strcnt);
            for (int i = 0; i <= strs.Length - 1; i++) strs[i].Start(new ToGrayParam(new Bitmap(parts[i]), @res));
            while (true)
            {
                Task.Delay(100);
                bool b = true;
                for (int i = 0; i <= strs.Length - 1; i++)
                    if (strs[i].ThreadState != ThreadState.Stopped)
                    {
                        b = false;
                    }
                if (b)
                {
                    return GetConcatImage(res.Values.ToArray());
                }
            }
        }

        /*
        private void GaussMultStream(Image bmp, int strcnt)
        {
            //TODO ToGrayMultiStream
        }

        private void SobelMultStream(Image bmp, int strcnt)
        {
            //TODO ToGrayMultiStream
        }
        */

        /// <summary>
        /// Многопоточная операция. Выполняет преобразование в формат "оттенки серого".
        /// </summary>
        /// <param name="ob">Данные для выполнения операции (класса ToGrayParam).</param>
        private void ToGray(object ob)
        {
            Bitmap a = (ob as ToGrayParam).Bmp;
            @Dictionary<int, Bitmap> res = (ob as ToGrayParam).Res;
            for (int i = 0; i <= a.Width - 1; i++)
                for (int ii = 0; ii <= a.Height - 1; ii++)
                {
                    Color c = a.GetPixel(i, ii);
                    byte y = Border(Options.GrayConvertRCof * c.R + Options.GrayConvertGCof * c.B + Options.GrayConvertBCof * c.G);
                    c = Color.FromArgb(y, y, y);
                    a.SetPixel(i, ii, c);
                }
            res[Thread.CurrentThread.ManagedThreadId] = a;
        }

        /// <summary>
        /// Делит изображение на вертикальные части.
        /// </summary>
        /// <param name="bmp">Изобрадение для разделения</param>
        /// <param name="num">Количество частей.</param>
        private Image[] GetVertCutImage(Bitmap bmp, int num)
        {
            int w = bmp.Width / num;
            Bitmap[] Result = new Bitmap[num];
            Result[0] = new Bitmap(w, bmp.Height, PixelFormat.Format24bppRgb);
            for (var i = 0; i <= num - 1; i++)
            {
                if (i == num - 1)
                    Result[i] = bmp.Clone(new Rectangle(new Point(i * w, 0), new Size((bmp.Width - i * w), bmp.Height)), PixelFormat.DontCare);
                else Result[i] = bmp.Clone(new Rectangle(new Point(i * w, 0), new Size(w, bmp.Height)), PixelFormat.DontCare);
            }
            return Result;
        }

        /// <summary>
        /// Объеденяет части изображения (полученные методом GetVertCutImage()) в одно.
        /// </summary>
        /// <param name="bmps">Массив частей.</param>
        private Image GetConcatImage(Image[] bmps)
        {
            int w = 0;
            foreach (var i in bmps)
            {
                w += i.Width;
            }
            Bitmap Result = new Bitmap(w, bmps[0].Height);
            int x = 0;
            int c = 0;
            Graphics a = Graphics.FromImage(Result);
            foreach (var i in bmps)
            {
                a.DrawImage(new Bitmap(i).Clone(new Rectangle(new Point(0, 0), new Size(bmps[c].Width, bmps[c].Height)), PixelFormat.DontCare), new Point(x, 0));
                x += bmps[c].Width;
                c++;
            }
            return Result;
        }

        /// <summary>
        /// Векторизирует изображение с заданными параметрами.
        /// </summary>
        /// <param name="bmp">Изображение для векторизации.</param>
        public Vect GetVector(Bitmap bmp)
        {
            {
                Vect e = new Vect();
                Bitmap k = bmp;
                /*
                switch (Options.Hqx_Scale)
                {
                   case 2: k = hqx.HqxSharp.Scale2(k); break;
                   case 3: k = hqx.HqxSharp.Scale3(k); break;
                   case 4: k = hqx.HqxSharp.Scale4(k); break;
                }
                */
                if (Options.DebugSavePrticalResults || Options.DebugSaveMergedResult) k.Save("1.png");
                k = new Bitmap(ToGrayMultStream(k, 4));
                if (Options.DebugSavePrticalResults || Options.DebugSaveMergedResult) k.Save("2.png");
                if (Options.UseGaussBlur) Gauss(ref k);
                if (Options.DebugSavePrticalResults || Options.DebugSaveMergedResult) k.Save("3.png");
                Sobel(ref k);
                if (Options.DebugSavePrticalResults || Options.DebugSaveMergedResult) k.Save("4.png");
                e = new Vectorizer().Proceed(k, Options.DebugPrSay, Options.PrStreamsCount);
                if (Options.DebugSavePrticalResults || Options.DebugSaveMergedResult)  e.ToBitmap().Save("5.png");
                if (Options.DebugSaveMergedResult) new Bitmap(GetConcatImage(new Bitmap[5] { new Bitmap("1.png"), new Bitmap("2.png"), new Bitmap("3.png"), new Bitmap("4.png"), new Bitmap("5.png") })).
                Save(string.Format("Sc{0}GSigma{1}GKof{2}SobelCof{3}_AllRes.png", Options.HqxScaleMult, Options.GaussBlurSigma, Options.GaussBlurKCof, Options.SobelOperatorLimFonf));
                if (Options.DebugSaveMergedResult && !Options.DebugSavePrticalResults)
                {
                    File.Delete("1.png");
                    File.Delete("2.png");
                    File.Delete("3.png");
                    File.Delete("4.png");
                    File.Delete("5.png");
                }
                return e;
            }
        }
    }
}
