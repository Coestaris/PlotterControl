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

using CWA;
using CWA.Vectors;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_fromvector : Form
    {
        public Form_fromvector()
        {
            InitializeComponent();
        }

        private void Form_fromvector_Load(object sender, EventArgs e)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            openFileDialog1.Filter = string.Format("All image files ({1})|{1}|{0}| All files|*",
                string.Join("|", codecs.Select(codec =>
                string.Format("{0} ({1})|{1}", codec.CodecName, codec.FilenameExtension)).ToArray()),
                string.Join(";", codecs.Select(codec => codec.FilenameExtension).ToArray()));
        }

        Bitmap bmp;
        int xsize;
        int ysize;
        int max_x_size;
        int max_y_size;
        byte state;
        VectLib vl;

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                state = 1;
                xsize = int.Parse(textBox1.Text);
                ysize = int.Parse(textBox2.Text);
                max_x_size = int.Parse(textBox3.Text);
                max_y_size = int.Parse(textBox4.Text);
                vl = new VectLib();
            }
        }

        byte[][] values;

        private byte GetRectValue(Rectangle rec)
        {
            int result = 0; 
            int count = rec.Width * rec.Height;
            for(int x = rec.X; x<=rec.X + rec.Width-1; x++)
                for (int y = rec.Y; y <= rec.Y + rec.Height-1; y++)
                {
                    result += Helper.Helper.GetAverageColor(bmp.GetPixel(x, y));
                }
            return (byte)(result / count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case (1):
                    bmp = new Bitmap(vl.ToGrayMultStream(bmp, 4));
                    pictureBox1.Image = bmp;
                    state++;
                    break;
                case (2):
                    bmp = new Bitmap(bmp, new Size((int)Math.Truncate((float)bmp.Width / xsize) * xsize, (int)Math.Truncate((float)bmp.Height / ysize) * ysize));
                    pictureBox1.Image = bmp;
                    state++;
                    break;
                case (3):
                    values = new byte[bmp.Width / xsize][];
                    for (int x = 0; x <= bmp.Width / xsize - 1; x++)
                        values[x] = new byte[bmp.Height / ysize];

                    for (int x = 0; x <= bmp.Width / xsize - 1; x++)
                        for (int y = 0; y <= bmp.Height / ysize - 1; y++)
                        {
                            values[x][y] = GetRectValue(new Rectangle(x * xsize, y * ysize, xsize, ysize));
                        }
                    using (Graphics gr = Graphics.FromImage(bmp))
                    {
                        for (int x = 0; x <= bmp.Width / xsize - 1; x++)
                            for (int y = 0; y <= bmp.Height / ysize - 1; y++)
                            {
                                gr.FillRectangle(new SolidBrush(Helper.Helper.NewOneChColor(values[x][y])), new Rectangle(x * xsize, y * ysize, xsize, ysize));
                            }
                    }
                    pictureBox1.Image = bmp;
                    state++;
                    break;
                case (4):
                    var a = new GraphicsPath(FillMode.Winding);
                    for (int x = 0; x <= bmp.Width / xsize - 1; x++)
                        for (int y = 0; y <= bmp.Height / ysize - 1; y++)
                        {
                            a.AddEllipse((x + 0.5f) * xsize, (y + 0.5f) * ysize, (float)(255 - values[x][y]) * (float)max_x_size / (float)xsize, (float)(255 - values[x][y]) * (float)max_y_size / (float)ysize);
                        }
                    using (Graphics gr = Graphics.FromImage(bmp))
                    {
                        gr.FillRectangle(Brushes.White, new RectangleF(0, 0, bmp.Width, bmp.Height));
                        gr.DrawPath(Pens.Black, a);
                    }
                    pictureBox1.Image = bmp;
                    state++;
                    break;
            }
        }
    }
}
