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

using CnCWFA_Resources.Properties;
using CWA;
using CWA.Printing;
using CWA.Vectors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_PrintMaster : Form
    {
        int Index;
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Form_PrintMaster));
        private Vector buffpr, pr;
        private VectHeader main_header;
        private SerialPort main_port;
        private Print print;
        private Bitmap bmp_, bmp;
        private Thread prt;
        private string path, textBox_xsize_laststring, textBox_ysize_laststring, textbox_xoffset_laststring, textbox_yoffset_laststring, textBox_penwidth_laststring;
        private int state;
        private bool ignoreload;
        private char[] num = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',' , '.'};
        private float xsize, ysize, xoffest, yoffest, time;
        private PrintErrorEventArgs errorarg;

        private delegate void SetVisibleCallback(bool val);
        private delegate void Print_TimeChanged_(TimeEventArgs val);
        private delegate void SetLabelTextFeedBack_(PrintedEventArgs val);
        private delegate void SetLabelTextFeedBack(string val);

        public Form_PrintMaster(string fn, bool ignr)
        {
            ignoreload = ignr;
            InitializeComponent();
            Form_print_Load(null, null);
            listBox_prlist.Enabled = false;
            button_preview.Enabled = false;
            path = fn;
            button_tab2_back.Enabled = true;
            loadingCircle1.Visible = true;
            button_openfolder.Enabled = false;
            button_refreshlist.Enabled = false;
            button_removepr.Enabled = false;
            loadingCircle1.Active = true;
            new Thread(button_next_tab1_Click_th).Start();
            button_next_tab1.Enabled = false;
            button_exit.Enabled = false;
            state = 2;
            button_tab2_back.Text = "Выйти";
            CheckState();
        }

        public Form_PrintMaster(string fn, bool ignr, string port, int bdrate, SizeF size, bool auto)
        {
            ignoreload = ignr;
            InitializeComponent();
            Form_print_Load(null, null);
            listBox_prlist.Enabled = false;
            button_preview.Enabled = false;
            path = fn;
            button_tab2_back.Enabled = true;
            loadingCircle1.Visible = true;
            button_openfolder.Enabled = false;
            button_refreshlist.Enabled = false;
            button_removepr.Enabled = false;
            loadingCircle1.Active = true;
            new Thread(button_next_tab1_Click_th).Start();
            button_next_tab1.Enabled = false;
            button_exit.Enabled = false;
            state = 2;
            button_tab2_back.Text = "Выйти";
            CheckState();
        }

        public Form_PrintMaster()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 4;
            CheckState();
        }

        private void CheckState()
        {
            if(state==0)
            {
                label_1.Image = ((Image)(resources.GetObject("label_1.Image"))); label_2.Image = ((Image)(resources.GetObject("label_1.Image"))); label_3.Image = ((Image)(resources.GetObject("label_1.Image"))); label_4.Image = ((Image)(resources.GetObject("label_1.Image"))); label_5.Image = ((Image)(resources.GetObject("label_1.Image")));
            } else if(state==1)
            {
                label_1.Image = Resources.ok1; label_2.Image = ((Image)(resources.GetObject("label_1.Image"))); label_3.Image = ((Image)(resources.GetObject("label_1.Image")));label_4.Image = ((Image)(resources.GetObject("label_1.Image")));label_5.Image = ((Image)(resources.GetObject("label_1.Image")));

            } else if (state == 2)
            {
                label_1.Image = Resources.ok1; label_2.Image = Resources.ok1; label_3.Image = ((Image)(resources.GetObject("label_1.Image"))); label_4.Image = ((Image)(resources.GetObject("label_1.Image"))); label_5.Image = ((Image)(resources.GetObject("label_1.Image")));

            } else if (state == 3)
            {
                label_1.Image = Resources.ok1; label_2.Image = Resources.ok1; label_3.Image = Resources.ok1; label_4.Image = ((Image)(resources.GetObject("label_1.Image")));label_5.Image = ((Image)(resources.GetObject("label_1.Image")));

            } else if (state == 4)
            {
                label_1.Image = Resources.ok1; label_2.Image = Resources.ok1; label_3.Image = Resources.ok1; label_4.Image = Resources.ok1; label_5.Image = ((Image)(resources.GetObject("label_1.Image")));
            } else
            {
                label_1.Image = Resources.ok1; label_2.Image = Resources.ok1; label_3.Image = Resources.ok1; label_4.Image = Resources.ok1; label_5.Image = Resources.ok1;
            }
        }

        private void Form_print_Load(object sender, EventArgs e)
        {
            loadingCircle_tab1.InnerCircleRadius = 25;
            loadingCircle_tab1.OuterCircleRadius = 26;
            loadingCircle_tab1.NumberSpoke = 100;
            loadingCircle_tab1.Top = pictureBox_prpreview.Top + pictureBox_prpreview.Height / 2 - loadingCircle1.Height / 2;
            loadingCircle_tab1.Left = pictureBox_prpreview.Left + pictureBox_prpreview.Width / 2 - loadingCircle1.Width / 2;
            loadingCircle1.InnerCircleRadius = 25;
            loadingCircle1.OuterCircleRadius = 26;
            loadingCircle1.NumberSpoke = 100;
            loadingCircle2.InnerCircleRadius = 25;
            loadingCircle2.OuterCircleRadius = 26;
            loadingCircle2.NumberSpoke = 100;
            comboBox_com.Items.Clear();
            comboBox_com.Items.AddRange(SerialPort.GetPortNames());
            comboBox_com.Text = GlobalOptions.Mainport;
            comboBox_bdrate.Text = GlobalOptions.Mainbd.ToString();
            radioButton_xsize.Checked = true;
            if (!ignoreload)
            {
                listBox_prlist.Items.Clear();
                string[] paths = Directory.GetFiles("Data\\Vect\\", "*.prres");
                listBox_prlist.Items.AddRange(paths);
                paths = Directory.GetFiles("Data\\Vect\\", "*.pcv");
                listBox_prlist.Items.AddRange(paths);
            } else
            {

            }
            prt = new Thread(ImgPr);
        }

        private void ImgPr_end_set(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(ImgPr_end_set);
                Invoke(d, new object[] { a });
            }
            else
            {
                loadingCircle_tab1.Visible = false;
                loadingCircle_tab1.Active = false;
                button_next_tab1.Enabled = true;
                button_refreshlist.Enabled = true;
                button_removepr.Enabled = true;
                button_preview.Enabled = true;
            }
        }

        private void ImgPr_end_set_text(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(ImgPr_end_set_text);
                Invoke(d, new object[] { a });
            }
            else
            {
                label_pr_name.Text = "Имя: " + (string)listBox_prlist.Items[Index];
                label_resolution.Text = "Разрешение: " + buffpr.Header.Width + "x" + buffpr.Header.Height;
                label_pr_connum.Text = "Кол-во контуров: " + buffpr.RawData.Length;
                label_pr_points.Text = "Кол-во точек: " + buffpr.Points;
                label_source.Text = "Тип: " + buffpr.Header.VectType;
            }
        }

        private void ImgPr()
        {
            buffpr = new Vector((string)listBox_prlist.Items[Index]);
            ImgPr_end_set_text(false);
            pictureBox_prpreview.Image = buffpr.ToBitmap(Color.White,Color.Black);
            ImgPr_end_set(false);
        }

       
        private void listBox_prlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            prt.Abort();
            if (listBox_prlist.SelectedIndex != -1)
            {
                loadingCircle_tab1.Visible = false;
                loadingCircle_tab1.Active = false;
                button_next_tab1.Enabled = true;
                Index = listBox_prlist.SelectedIndex;
                button_next_tab1.Enabled = false;
                button_refreshlist.Enabled = false;
                button_removepr.Enabled = false;
                loadingCircle_tab1.Visible = true;
                loadingCircle_tab1.Active = true;
                prt = new Thread(ImgPr);
                prt.Start();
            }
        }

        private void button_refreshlist_Click(object sender, EventArgs e)
        {
            if (!ignoreload)
            {
                listBox_prlist.Items.Clear();
                string[] paths = Directory.GetFiles("Data\\Vect\\", "*.prres");
                listBox_prlist.Items.AddRange(paths);
                paths = Directory.GetFiles("Data\\Vect\\", "*.pcv");
                listBox_prlist.Items.AddRange(paths);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            state = 0;
            CheckState();
            tabControl1.SelectedIndex = 4;
        }

        private void button_removepr_Click(object sender, EventArgs e)
        {
            if (listBox_prlist.SelectedIndex != -1)
            {
                File.Delete((string)listBox_prlist.Items[listBox_prlist.SelectedIndex]);
                button_refreshlist_Click(null, null);
            }
            else MessageBox.Show("Selet Item!");
        }

        private void button_openfolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Data\\Vect\\");
        }

        private void button_next_tab1_Click_set(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(button_next_tab1_Click_set);
                Invoke(d, new object[] { a });
            }
            else
            {
                radioButton_xsize.Checked = true;
                comboBox_com.Items.AddRange(SerialPort.GetPortNames());
                comboBox_bdrate.SelectedItem = GlobalOptions.Mainbd.ToString();
                comboBox_com.SelectedItem = GlobalOptions.Mainport;
                main_header = pr.Header;
                bmp = new Bitmap(297, 210);
                long gdc = Helper.Helper.GCD((int)main_header.Width, (int)main_header.Height);
                label_ratio.Text = "Соотн. сторон: " + main_header.Height / gdc + '/' + main_header.Width / gdc;
                textBox_xsize.Text = "50";
                loadingCircle1.Visible = false;
                loadingCircle1.Active = false;
                bmp = new Bitmap(210, 297);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = new Rectangle(0, 0, (int)ysize, (int)xsize);
                    gr.FillRectangle(Brushes.White, rect);
                    using (Pen thick_pen = new Pen(Color.Red, 0.2f))
                    {
                        Bitmap tm = new Bitmap(pictureBox_prpreview.Image);
                        //tm.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        gr.DrawRectangle(thick_pen, rect);
                        gr.DrawImage(tm, rect);
                    }
                }
                pictureBox1.Image = bmp;
                pr = null;
                tabControl1.SelectedIndex = 1;
                button2.Enabled = true;
            }
        }

        private void button_next_tab1_Click_th()
        {
            pr = new Vector(path);
            pictureBox_prpreview.Image = pr.ToBitmap(2, Color.Black);
            button_next_tab1_Click_set(false);
        }

        private void button_next_tab1_Click(object sender, EventArgs e)
        {
            if (listBox_prlist.SelectedIndex != -1)
            {
                state = 2;
                CheckState();
                listBox_prlist.Enabled = false;
                button_preview.Enabled = false;
                path = (string)listBox_prlist.Items[listBox_prlist.SelectedIndex];
                loadingCircle1.Visible = true;
                button_openfolder.Enabled = false;
                button_refreshlist.Enabled = false;
                button_removepr.Enabled = false;
                loadingCircle1.Active = true;
                new Thread(button_next_tab1_Click_th).Start();
                button_next_tab1.Enabled = false;
                button_exit.Enabled = false;
            }
            else MessageBox.Show("Select Item!");
        }

        private void radioButton_xsize_CheckedChanged(object sender, EventArgs e)
        {
            textBox_xsize.Enabled = true;
            textBox_ysize.Enabled = false;
        }

        private void radioButton_ysize_CheckedChanged(object sender, EventArgs e)
        {
            textBox_xsize.Enabled = false;
            textBox_ysize.Enabled = true;
        }
        
        private void textBox_xsize_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_xsize.Checked)
            {
                bool err = false;
                foreach (char a in textBox_xsize.Text)
                {
                    if (!num.Contains(a))
                    {
                        MessageBox.Show("It`s float number. It can not contain '" + a + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_xsize.Text = textBox_xsize_laststring;
                        err = true;
                        return;
                    }
                }
                if (textBox_xsize.Text != "")
                {
                    if (float.Parse(textBox_xsize.Text, CultureInfo.InvariantCulture) + xoffest > 297)
                    {
                        MessageBox.Show((int.Parse(textBox_xsize.Text) +xoffest)+ " (xsize + xoffset) more than the allowable size. XSize can`t be more than 297 (А4)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_xsize.Text = textBox_xsize_laststring;
                        err = true;
                        return;
                    }
                }
                if (!err)
                {
                    
                    if (textBox_xsize.Text != "")
                    {
                        xsize = float.Parse(textBox_xsize.Text, CultureInfo.InvariantCulture);
                        textBox_ysize.Text = PrintHm.GetXsize((float)main_header.Width, (float)main_header.Height, xsize).ToString(CultureInfo.InvariantCulture);
                        if (textBox_ysize.Text != "")
                        {
                            ysize = float.Parse(textBox_ysize.Text, CultureInfo.InvariantCulture);
                        }

                        if (ysize > 210)
                        {
                            MessageBox.Show(ysize + " more than the allowable size. YSize can`t be more than 210 (А4)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox_ysize.Text = textBox_ysize_laststring;
                            textBox_xsize.Text = textBox_xsize_laststring;
                            err = true;
                            return;
                        }
                        textBox_xsize_laststring = textBox_xsize.Text;
                        bmp = new Bitmap(210, 297);
                        using (Graphics gr = Graphics.FromImage(bmp))
                        {
                            gr.SmoothingMode = SmoothingMode.AntiAlias;
                            Rectangle rect = new Rectangle((int)yoffest, (int)xoffest, (int)ysize, (int)xsize);
                            gr.FillRectangle(Brushes.White, rect);
                            using (Pen thick_pen = new Pen(Color.Red, 0.2f))
                            {
                                Bitmap tm = new Bitmap(pictureBox_prpreview.Image);
                                gr.DrawRectangle(thick_pen, rect);
                                gr.DrawImage(tm, rect);
                            }
                        }
                        pictureBox1.Image = bmp;
                    }
                }
            }
        }

        private void textBox_ysize_TextChanged(object sender, EventArgs e)
        {
            if (radioButton_ysize.Checked)
            {
                bool err = false;
                foreach (char a in textBox_ysize.Text)
                {
                    if (!num.Contains(a))
                    {
                        MessageBox.Show("It`s float number. It can not contain '" + a + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_ysize.Text = textBox_ysize_laststring;
                        err = true;
                    }
                }
                if (textBox_ysize.Text != "")
                {
                    if (float.Parse(textBox_ysize.Text, CultureInfo.InvariantCulture) + yoffest> 210)
                    {
                        MessageBox.Show((int.Parse(textBox_ysize.Text) + xoffest) + " (ysize + yoffset) more than the allowable size. YSize can`t be more than 210 (А4)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_ysize.Text = textBox_ysize_laststring;
                        err = true;
                        return;
                    }
                }
                if (!err)
                {
                    textBox_ysize_laststring = textBox_ysize.Text;
                    if (textBox_ysize_laststring != "")
                    {
                        ysize = float.Parse(textBox_ysize_laststring, CultureInfo.InvariantCulture);
                        textBox_xsize.Text = PrintHm.GetYsize((float)main_header.Width, (float)main_header.Height, ysize).ToString(CultureInfo.InvariantCulture);
                        if (textBox_xsize.Text != "")
                        {
                            xsize = float.Parse(textBox_xsize.Text, CultureInfo.InvariantCulture);
                        }
                        textBox_ysize_laststring = textBox_ysize.Text;
                        bmp = new Bitmap(210, 297);
                        using (Graphics gr = Graphics.FromImage(bmp))
                        {
                            gr.SmoothingMode = SmoothingMode.AntiAlias;
                            Rectangle rect = new Rectangle((int)yoffest, (int)xoffest, (int)ysize, (int)xsize);
                            gr.FillRectangle(Brushes.White, rect);
                            using (Pen thick_pen = new Pen(Color.Red, 0.2f))
                            {
                                Bitmap tm = new Bitmap(pictureBox_prpreview.Image);
                                gr.DrawRectangle(thick_pen, rect);
                                gr.DrawImage(tm, rect);
                            }
                        }
                        pictureBox1.Image = bmp;
                    }
                }
            }
        }

        private void button_preview_Click(object sender, EventArgs e)
        {
            new Bitmap(pictureBox_prpreview.Image).Save("Temp\\tmp1_.png");
            System.Diagnostics.Process.Start("Temp\\tmp1_.png");
        }

        private void checkBox_useoffset_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkBox_useoffset.Checked)
            {
                xoffest = 0;
                yoffest = 0;
            } else
            {
                float.TryParse(textBox_xoffset.Text, out xoffest);
                float.TryParse(textBox_yoffset.Text, out yoffest);
            }
             textBox_xoffset.Enabled = checkBox_useoffset.Checked;
             textBox_yoffset.Enabled = checkBox_useoffset.Checked;
        }

        private void textBox_xoffset_TextChanged(object sender, EventArgs e)
        {
            bool err = false;
            foreach (char a in textBox_xoffset.Text)
            {
                if (!num.Contains(a))
                {
                    MessageBox.Show("It`s float number. It can not contain '" + a + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_xoffset.Text = textbox_xoffset_laststring;
                    err = true;
                }
            }
            float.TryParse(textBox_xoffset.Text, out xoffest);
            float.TryParse(textBox_yoffset.Text, out yoffest);
            if (textBox_xoffset.Text != "")
            {
                if (float.Parse(textBox_xoffset.Text, CultureInfo.InvariantCulture) + xoffest > 297)
                {
                    MessageBox.Show((int.Parse(textBox_xsize.Text) + xoffest) + " (xsize + xoffset) more than the allowable size. XSize can`t be more than 297 (А4)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_xoffset.Text = textbox_xoffset_laststring;
                    err = true;
                    return;
                }
            }
            if (!err)
            {
                if (textBox_xoffset.Text != "") xoffest = float.Parse(textBox_xoffset.Text, CultureInfo.InvariantCulture);
                else xoffest = 0;
                if (textBox_yoffset.Text != "") yoffest = float.Parse(textBox_yoffset.Text, CultureInfo.InvariantCulture);
                else yoffest = 0;
                textbox_xoffset_laststring = textBox_xoffset.Text;
                bmp = new Bitmap(210, 297);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = new Rectangle((int)yoffest, (int)xoffest, (int)ysize, (int)xsize);
                    gr.FillRectangle(Brushes.White, rect);
                    using (Pen thick_pen = new Pen(Color.Red, 0.2f))
                    {
                        Bitmap tm = new Bitmap(pictureBox_prpreview.Image);
                        gr.DrawRectangle(thick_pen, rect);
                        gr.DrawImage(tm, rect);
                    }
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void textBox_yoffset_TextChanged(object sender, EventArgs e)
        {
            bool err = false;
            foreach (char a in textBox_yoffset.Text)
            {
                if (!num.Contains(a))
                {
                    MessageBox.Show("It`s float number. It can not contain '" + a + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_yoffset.Text = textbox_yoffset_laststring;
                    err = true;
                }
            }
            float.TryParse(textBox_xoffset.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out xoffest);
            float.TryParse(textBox_yoffset.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out yoffest);
            if (textBox_yoffset.Text != "")
            {
                if (float.Parse(textBox_ysize.Text, CultureInfo.InvariantCulture) + yoffest > 210)
                {
                    MessageBox.Show((int.Parse(textBox_ysize.Text) + yoffest) + " (ysize + yoffset) more than the allowable size. YSize can`t be more than 210 (А4)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_yoffset.Text = textbox_yoffset_laststring;
                    err = true;
                    return;
                }
            }
            if (!err)
            {
                if (textBox_yoffset.Text != "") yoffest = float.Parse(textBox_yoffset.Text, CultureInfo.InvariantCulture);
                else yoffest = 0;
                if (textBox_xoffset.Text != "") xoffest = float.Parse(textBox_xoffset.Text, CultureInfo.InvariantCulture);
                else xoffest = 0;
                textbox_yoffset_laststring = textBox_yoffset.Text;
                bmp = new Bitmap(210, 297);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = new Rectangle((int)yoffest, (int)xoffest, (int)ysize, (int)xsize);
                    gr.FillRectangle(Brushes.White, rect);
                    using (Pen thick_pen = new Pen(Color.Red, 0.2f))
                    {
                        Bitmap tm = new Bitmap(pictureBox_prpreview.Image);
                        gr.DrawRectangle(thick_pen, rect);
                        gr.DrawImage(tm, rect);
                    }
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void comboBox_com_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox_com.Items.Clear();
            comboBox_com.Items.AddRange(SerialPort.GetPortNames());
        }

        private void comboBox_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_com.SelectedIndex!=-1 && comboBox_bdrate.SelectedIndex!=-1)
            {
                button_open.Enabled = true;
            }
        }

        private void comboBox_bdrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_com.SelectedIndex != -1 && comboBox_bdrate.SelectedIndex != -1)
            {
                button_open.Enabled = true;
            }
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if(main_port!=null && main_port.IsOpen)
            {
                MessageBox.Show("Данный порт уже октрыт", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int bd = int.Parse(comboBox_bdrate.Text);
                main_port = new SerialPort(comboBox_com.Text, bd);
                main_port.Open();
                MessageBox.Show("Порт \" " + comboBox_com.Text + "\" открыт", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_print.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Невозможно открыть порт \" " + comboBox_com.Text + "\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_tab2_back_Click(object sender, EventArgs e)
        {
            if (button_tab2_back.Text == "Выйти") Close();
            button_refreshlist.PerformClick();
            state = 1;
            CheckState();
            listBox_prlist.Enabled = true;
            button_preview.Enabled = true;
            loadingCircle1.Visible = false;
            button_openfolder.Enabled = true;
            button_refreshlist.Enabled = true;
            button_removepr.Enabled = true;
            loadingCircle1.Active = false;
            button_next_tab1.Enabled = true;
            button_exit.Enabled = true;
            tabControl1.SelectedIndex = 0;
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            state = 3;
            CheckState();
            tabControl1.SelectedIndex = 2;
            PrintOptions op = new PrintOptions();
            op.YOffset = yoffest;
            op.XOffset = xoffest;
            op.XMM = GlobalOptions.XMM;
            op.YMM = GlobalOptions.YMM;
            op.PrintSize = new SizeF(xsize, ysize);
            pr = new Vector(path);
            op.ImageSize = new Size((int)pr.Header.Width, (int)pr.Header.Height);
            print = new Print(pr, op, GlobalOptions.DefSpo, GlobalOptions.DefRbo, main_port);
            print.ProceedStatusChanged += Print_ProceedStatusChanged;
            print.PrintError += Print_PrintError;
            print.PrintChanged += Print_PrintChanged;
            print.ProceedEnd += Print_ProceedEnd;
            print.TimeChanged += Print_TimeChanged;
            print.PrintingDone += Print_PrintingDone;
            print.ComputeCommands();
            
        }

        private void Print_PrintingDone(object sender, EventArgs e)
        {
            End(false);
        }

        private void End(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(End);
                Invoke(d, new object[] { a });
            }
            else
            {
                print.Abort();
                Thread.Sleep(1000);
                label2.Text = string.Format("За {0:0.##} сек. или {1:0.##} мин.",time,time/60);
                state = 5;
                CheckState();
                tabControl1.SelectedIndex = 5;
            }
        }

        private void OnError(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(OnError);
                Invoke(d, new object[] { a });
            } else
            {
                MessageBox.Show("Печать окончена с кодом ошибки:\" " + errorarg + "\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedIndex = 1;
            }
        }

        private void Print_PrintError(object sender, PrintErrorEventArgs e)
        {
            errorarg = e;
            OnError(false);
        }

        private void Print_TimeChanged__(TimeEventArgs a)
        {
            if (InvokeRequired)
            {
                Print_TimeChanged_ d = new Print_TimeChanged_(Print_TimeChanged__);
                Invoke(d, new object[] { a });
            }
            else
            {
                time = a.TimeSpend;
                label_spendtime.Text = string.Format("Затрачено: {0:0.##}s({1:0.##}m)", (a.TimeSpend), (a.TimeSpend /60));
                label_lefttime.Text = string.Format("Осталось: {0:0.##}s({1:0.##}m)", (a.TimeLeft), (a.TimeLeft / 60));
            }
        }

        private void Print_TimeChanged(object sender, TimeEventArgs e)
        {
            Print_TimeChanged__(e);
        }

        private void Print_PrintChanged(object sender, PrintedEventArgs e)
        {
            Print_PrintChanged_(e);
        }

        private void Print_PrintChanged_(PrintedEventArgs a)
        {
            if (InvokeRequired)
            {
                SetLabelTextFeedBack_ d = new SetLabelTextFeedBack_(Print_PrintChanged_);
                Invoke(d, new object[] { a });
            }
            else
            {
                progressBar1.Maximum = (int)a.CountTotal;
                progressBar1.Value = (int)a.CountDone;
                label_complete_percentage.Text = string.Format("Завершено: {0:0.##}%", ((float)a.CountDone / (float)a.CountTotal * 100));
                label_complete_number.Text = "Контуров: " + a.CountDone + '\\' + a.CountTotal;

                pictureBox2.Image = print.ProcessBmp;
            }
        }

        private void SetLabelText(string a)
        {
            if (InvokeRequired)
            {
                SetLabelTextFeedBack d = new SetLabelTextFeedBack(SetLabelText);
                Invoke(d, new object[] { a });
            }
            else
            {
                label_complete.Text = "Завершено: " + a + '%';
            }
        }

        private void SetLabelText_(string a)
        {
            if (InvokeRequired)
            {
                SetLabelTextFeedBack d = new SetLabelTextFeedBack(SetLabelText_);
                Invoke(d, new object[] { a });
            }
            else
            {
                state = 4;
                CheckState();
                bmp_ = new Bitmap((int)pr.Header.Width, (int)pr.Header.Height);
                label_prtime_print.Text = label_prtime.Text;
                label_resolution_print.Text = label_resolution.Text;
                label_type_print.Text = label_source.Text;
                label_num_of_cont.Text = "Кол-во контуров: " + pr.ContorurCount;
                tabControl1.SelectedIndex = 3;
            }
        }

        private void Print_ProceedEnd(object sender, EventArgs e)
        {
            SetLabelText_("23");
            print.PrintVector();
        }

        private void Print_ProceedStatusChanged(object sender, ProceedStatusChangedArgs e)
        {
            SetLabelText(e.Percentage.ToString(CultureInfo.InvariantCulture));
        }

        private void Form_print_FormClosing(object sender, FormClosingEventArgs e)
        {
            print?.Abort();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            radioButton_xsize.Checked = true;
            textBox_xsize.Text = "100";
            textBox_xoffset.Text= "0";
            textBox_yoffset.Text = "0";
            checkBox_useoffset.Checked = false;
        }

        private void label_source_Click(object sender, EventArgs e)
        {

        }

        private void button_abort_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Прервать печать?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                print.Abort();
                Thread.Sleep(1000);
                label2.Text = string.Format("За {0:0.##} сек. или {1:0.##} мин.", time, time / 60);
                state = 5;
                CheckState();
                tabControl1.SelectedIndex = 5;

            }
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
           print.Pause();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            SetProbe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = colorDialog1.ShowDialog();
            if(a== DialogResult.OK)
            {
                print.DrawColor = colorDialog1.Color;
            }
            SetProbe();
        }

        private void SetProbe()
        {
            Bitmap colorprobe_back = new Bitmap(pictureBox_backcolor.Width, pictureBox_backcolor.Height);
            Bitmap colorprobe_draw = new Bitmap(pictureBox_backcolor.Width, pictureBox_backcolor.Height);
            Rectangle rect = new Rectangle(0, 0, pictureBox_backcolor.Width, pictureBox_backcolor.Height);
            using (Graphics gr = Graphics.FromImage(colorprobe_back))
            {
                gr.FillRectangle(new SolidBrush(print.BackColor), rect);
            }
            using (Graphics gr = Graphics.FromImage(colorprobe_draw))
            {
                gr.FillRectangle(new SolidBrush(print.DrawColor), rect);
            }
            pictureBox_drawcolor.Image = colorprobe_draw;
            pictureBox_backcolor.Image = colorprobe_back;
        }

        private void button_backcolor_Click(object sender, EventArgs e)
        {
            var a = colorDialog2.ShowDialog();
            if (a == DialogResult.OK)
            {
                print.BackColor = colorDialog2.Color;
            }
            SetProbe();
        }

        private void textBox_penwidth_TextChanged(object sender, EventArgs e)
        {
            bool err = false;
            foreach (char a in textBox_penwidth.Text)
            {
                if (!num.Contains(a))
                {
                    MessageBox.Show("It`s float number. It can not contain '" + a + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_penwidth.Text = textBox_penwidth_laststring;
                    err = true;
                }
            }
            if(!err)
            {
                print.PenWidth = float.Parse(textBox_penwidth.Text, CultureInfo.InvariantCulture);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            state = 1;
            CheckState();
            tabControl1.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try { File.Copy(openFileDialog1.FileName, "Data\\Vect\\" + new FileInfo(openFileDialog1.FileName).Name); } catch { }
                state = 2;
                CheckState();
                listBox_prlist.Enabled = false;
                button_preview.Enabled = false;
                path = openFileDialog1.FileName;
                loadingCircle1.Visible = true;
                button_openfolder.Enabled = false;
                button_refreshlist.Enabled = false;
                button_removepr.Enabled = false;
                loadingCircle1.Active = true;
                new Thread(button_next_tab1_Click_th).Start();
                button_next_tab1.Enabled = false;
                button_exit.Enabled = false;
            }
        }
    }
}
