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
* PlotterControl \ Form_VectorMaster.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 16.08.2017 23:25:03
*
*=================================*/

using CWA;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using CWA_Resources.Properties;
using CWA.Vectors;
using System.Globalization;

namespace CnC_WFA
{
    public partial class Form_VectorMaster : Form
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Form_PrintMaster));

        private Bitmap buffimg, resof_1_stage, res_uit2, uit_res;
        private Point scroll_right_relativepoint, scroll_left_relativepoint, scroll_up_relativepoint, scroll_down_relativepoint;
        private Vector pr = new Vector();
        private string path;
        private bool scroll_right_down, scroll_left_down, scroll_up_down, scroll_down_down,  AllowScroll = false, ui2t_a, allow_uit2, allow_uit, Repeat;
        private int ui2t_b, ui2t_c, uit_c, num, c;
        private float uit_b;
        private short uit_a;
        private Thread pr_t, uit3;

        int process_status;

        private void CheckStatus()
        {
            var a = ((Image)(resources.GetObject("label_1.Image")));
            switch (process_status)
            {
                case (0):
                    label_1.Image = a;
                    label_2.Image = a;
                    label_3.Image = a;
                    label_4.Image = a;
                    label_5.Image = a;
                    label_6.Image = a;
                    label_7.Image = a;
                    break;
                case (1):
                    label_1.Image = Resources.ok1;
                    label_2.Image = a;
                    label_3.Image = a;
                    label_4.Image = a;
                    label_5.Image = a;
                    label_6.Image = a;
                    label_7.Image = a;
                    break;
                case (2):
                    label_1.Image = Resources.ok1;
                    label_2.Image = Resources.ok1;
                    label_3.Image = a;
                    label_4.Image = a;
                    label_5.Image = a;
                    label_6.Image = a;
                    label_7.Image = a;
                    break;
                case (3):
                    label_1.Image = Resources.ok1;
                    label_2.Image = Resources.ok1;
                    label_3.Image = Resources.ok1;
                    label_4.Image = a;
                    label_5.Image = a;
                    label_6.Image = a;
                    label_7.Image = a;
                    break;
                case (4):
                    label_1.Image = Resources.ok1;
                    label_2.Image = Resources.ok1;
                    label_3.Image = Resources.ok1;
                    label_4.Image = Resources.ok1;
                    label_5.Image = a;
                    label_6.Image = a;
                    label_7.Image = a;
                    break;
                case (5):
                    label_1.Image = Resources.ok1;
                    label_2.Image = Resources.ok1;
                    label_3.Image = Resources.ok1;
                    label_4.Image = Resources.ok1;
                    label_5.Image = Resources.ok1;
                    label_6.Image = a;
                    label_7.Image = a;
                    break;
                case (6):
                    label_1.Image = Resources.ok1;
                    label_2.Image = Resources.ok1;
                    label_3.Image = Resources.ok1;
                    label_4.Image = Resources.ok1;
                    label_5.Image = Resources.ok1;
                    label_6.Image = Resources.ok1;
                    label_7.Image = a;
                    break;
                case (7):
                    label_1.Image = Resources.ok1;
                    label_2.Image = Resources.ok1;
                    label_3.Image = Resources.ok1;
                    label_4.Image = Resources.ok1;
                    label_5.Image = Resources.ok1;
                    label_6.Image = Resources.ok1;
                    label_7.Image = Resources.ok1;
                    break;
            }

        }

        private delegate void SetStringVal(string s);
        private delegate void SetProgressBarVal(int val, int val_);
        private delegate void SetVisibleCallback(bool val);

        public Form_VectorMaster()
        {
            InitializeComponent();
        }

        private void checkBox_useflip_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_flipx.Enabled = checkBox_useflip.Checked;
            radioButton_flipy.Enabled = checkBox_useflip.Checked;
            UpdateImage_tab1();
        }

        private void radioButton_grayform_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_grayform.Enabled = radioButton_grayform.Checked;
            trackBar_hardbwthreshold.Enabled = !radioButton_grayform.Checked;
            label_harbw.Enabled = !radioButton_grayform.Checked;
        }

        private void Form_rastermaster_Load(object sender, EventArgs e)
        {
            button_back_tab4.Enabled = false;
            button_next_tab4.Enabled = false;
            button_savepr.Enabled = false;
            button_print.Enabled = false;
            button_peview.Enabled = false;
            process_status = 0;
            CheckStatus();
            button_peview.Visible = false;
            radioButton_flipx.Checked = true;
            tabControl1.SelectedIndex = 6;
            radioButton_0deg.Checked = true;
            radioButton_grayform.Checked = true;
            comboBox_grayform.SelectedIndex = 0;
            var b = (Bitmap)Resources.scroll.Clone();
            b.RotateFlip(RotateFlipType.Rotate90FlipX);
            scroll_right.Image = b;
            var c = (Bitmap)Resources.scroll.Clone();
            c.RotateFlip(RotateFlipType.Rotate90FlipNone);
            scroll_left.Image = c;
            var d = (Bitmap)Resources.scroll.Clone();
            d.RotateFlip(RotateFlipType.RotateNoneFlipY);
            scroll_down.Image = d;
            button_next_tab2.Enabled = false;
            scroll_up.Image = (Bitmap)Resources.scroll.Clone();
            scroll_left.Left = pictureBox_tab1.Left + pictureBox_tab1.Width - scroll_left.Width / 2;
            scroll_left.Top = pictureBox_tab1.Top + pictureBox_tab1.Height / 2 - scroll_left.Height / 2;
            scroll_right.Left = pictureBox_tab1.Left - scroll_right.Width / 2;
            scroll_right.Top = pictureBox_tab1.Top + pictureBox_tab1.Height / 2 - scroll_right.Height / 2;
            scroll_up.Left = pictureBox_tab1.Left + pictureBox_tab1.Width / 2 - scroll_up.Width / 2;
            scroll_up.Top = pictureBox_tab1.Top - scroll_up.Height / 2;
            scroll_down.Left = pictureBox_tab1.Left + pictureBox_tab1.Width / 2 - scroll_up.Width / 2;
            scroll_down.Top = pictureBox_tab1.Top + pictureBox_tab1.Height - scroll_down.Height / 2;
            loadingCircle_tab2.Top = pictureBox_tab2.Top + pictureBox_tab2.Height / 2 - loadingCircle_tab2.Height / 2;
            loadingCircle_tab2.Left = pictureBox_tab2.Left + pictureBox_tab2.Width / 2 - loadingCircle_tab2.Width / 2;
            loadingCircle_tab4.Top = pictureBox_tab4.Top + pictureBox_tab4.Height / 2 - loadingCircle_tab4.Height / 2;
            loadingCircle_tab4.Left = pictureBox_tab4.Left + pictureBox_tab4.Width / 2 - loadingCircle_tab4.Width / 2;
            loadingCircle_tab2.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Custom;
            loadingCircle_tab2.InnerCircleRadius = 25;
            loadingCircle_tab2.OuterCircleRadius = 26;
            loadingCircle_tab2.NumberSpoke = 100;
            loadingCircle_tab3.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Custom;
            loadingCircle_tab3.InnerCircleRadius = 25;
            loadingCircle_tab3.OuterCircleRadius = 26;
            loadingCircle_tab3.NumberSpoke = 100;
            loadingCircle_tab4.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Custom;
            loadingCircle_tab4.InnerCircleRadius = 25;
            loadingCircle_tab4.OuterCircleRadius = 26;
            loadingCircle_tab4.NumberSpoke = 100;
            allow_uit2 = true;
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            openFileDialog1.Filter = string.Format(TranslateBase.CurrentLang.Phrase["VectorMaster.AllImageFiles"] + "({1})|{1}|{0}|" + TranslateBase.CurrentLang.Phrase["VectorMaster.AllFiles"] +"|*", string.Join("|", codecs.Select(codec =>string.Format("{0} ({1})|{1}", codec.CodecName, codec.FilenameExtension)).ToArray()),string.Join(";", codecs.Select(codec => codec.FilenameExtension).ToArray()));
        }

        private void UpdateImage_tab1()
        {
            if (buffimg != null)
            {
                Bitmap k = new Bitmap(path);
                RotateFlipType a = new RotateFlipType();
                if (radioButton_0deg.Checked)
                {
                    if (checkBox_useflip.Checked)
                    {
                        if (radioButton_flipx.Checked) a = RotateFlipType.RotateNoneFlipX;
                        if (radioButton_flipy.Checked) a = RotateFlipType.RotateNoneFlipY;
                    }
                    else a = RotateFlipType.RotateNoneFlipNone;
                }
                if (radioButton_90deg.Checked)
                {
                    if (checkBox_useflip.Checked)
                    {
                        if (radioButton_flipx.Checked) a = RotateFlipType.Rotate90FlipX;
                        if (radioButton_flipy.Checked) a = RotateFlipType.Rotate90FlipY;
                    }
                    else a = RotateFlipType.Rotate90FlipNone;
                }
                if (radioButton_180deg.Checked)
                {
                    if (checkBox_useflip.Checked)
                    {
                        if (radioButton_flipx.Checked) a = RotateFlipType.Rotate180FlipX;
                        if (radioButton_flipy.Checked) a = RotateFlipType.Rotate180FlipY;
                    }
                    else a = RotateFlipType.Rotate180FlipNone;
                }
                if (radioButton_270deg.Checked)
                {
                    if (checkBox_useflip.Checked)
                    {
                        if (radioButton_flipx.Checked) a = RotateFlipType.Rotate270FlipX;
                        if (radioButton_flipy.Checked) a = RotateFlipType.Rotate270FlipY;
                    }
                    else a = RotateFlipType.Rotate270FlipNone;
                }
                k.RotateFlip(a);
                pictureBox_tab1.Image = k;
            }
        }

        private void ReCalcPos()
        {
            //TODO : Recalc pos.
        }

        private void scroll_right_MouseDown(object sender, MouseEventArgs e)
        {
            scroll_right_down = true;
            scroll_right_relativepoint = new Point(PointToClient(MousePosition).X, e.Y);
            ReCalcPos();
        }

        private void scroll_left_MouseDown(object sender, MouseEventArgs e)
        {
            scroll_left_down = true;
            scroll_left_relativepoint = new Point(PointToClient(MousePosition).X, e.Y);
            ReCalcPos();
        }

        private void scroll_down_MouseDown(object sender, MouseEventArgs e)
        {
            scroll_down_down = true;
            scroll_down_relativepoint = new Point(e.X, PointToClient(MousePosition).Y);
            ReCalcPos();
        }

        private void scroll_up_MouseDown(object sender, MouseEventArgs e)
        {
            scroll_up_down = true;
            scroll_up_relativepoint = new Point(e.X, PointToClient(MousePosition).Y);
            ReCalcPos();
        }

        private void scroll_right_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_right_down = false;
        }

        private void scroll_down_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_down_down = false;
        }

        private void scroll_left_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_left_down = false;
        }

        private void scroll_up_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_up_down = false;
        }

        private void scroll_left_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowScroll)
            {
                Control c = sender as Control;
                if (scroll_left_down) scroll_left.Left = PointToClient(MousePosition).X - scroll_right_relativepoint.X;
            }
        }

        private void scroll_up_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowScroll)
            {
                Control c = sender as Control;
                if (scroll_up_down) scroll_up.Top = PointToClient(MousePosition).Y - scroll_up_relativepoint.Y;
            }
        }

        private void scroll_down_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowScroll)
            {
                Control c = sender as Control;
                if (scroll_down_down) scroll_down.Top = PointToClient(MousePosition).Y - scroll_down_relativepoint.Y;
            }
        }

        private void scroll_right_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowScroll)
            {
                Control c = sender as Control;
                if (scroll_right_down) scroll_right.Left = PointToClient(MousePosition).X - scroll_right_relativepoint.X;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_right_down = false;
            scroll_left_down = false;
            scroll_up_down = false;
            scroll_down_down = false;
        }

        private void tabPage1_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_right_down = false;
            scroll_left_down = false;
            scroll_up_down = false;
            scroll_down_down = false;
        }

        private void Form_rastermaster_MouseUp(object sender, MouseEventArgs e)
        {
            scroll_right_down = false;
            scroll_left_down = false;
            scroll_up_down = false;
            scroll_down_down = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scroll_right_down = scroll_right.Enabled;
        }

        private void radioButton_0deg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage_tab1();
        }

        private void radioButton_90deg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage_tab1();
        }

        private void radioButton_180deg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage_tab1();
        }

        private void radioButton_270deg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage_tab1();
        }

        private void radioButton_flipx_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage_tab1();
        }

        private void radioButton_flipy_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage_tab1();
        }

        int TEMP_NUM;

        private void button_next_Click(object sender, EventArgs e)
        {
            process_status = 3;
            CheckStatus();
            resof_1_stage = new Bitmap(pictureBox_tab1.Image);
            TEMP_NUM++;
            try
            {
                resof_1_stage.Save("Temp\\tmp"+TEMP_NUM+".png");
            }
            catch { }
            UpdateImage_tab2();
            tabControl1.SelectTab(1);
        }

        private void UpdateImage_tab2_end_set(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(UpdateImage_tab2_end_set);
                Invoke(d, new object[] { a });
            }
            else
            {
                button_peview.Enabled = true;
                loadingCircle_tab2.Active = false;
                loadingCircle_tab2.Visible = false;
                button_next_tab2.Enabled = true;
                button_back_tab2.Enabled = true;
            }
        }

        private void UpdateImage_tab2_end()
        {
            pictureBox_tab2.Image = res_uit2;
            allow_uit2 = true;
            UpdateImage_tab2_end_set(false);
        }

        private void UpdateImage_tab2_()
        {
            if (resof_1_stage != null)
            {
                Bitmap bmp = new Bitmap("Temp\\tmp"+ TEMP_NUM + ".png");
                VectLib a = new VectLib();
                if (ui2t_a)
                {
                    switch (ui2t_b)
                    {
                        case 0:
                            bmp = new Bitmap(a.ToGrayMultStream(bmp, 4));
                            break;
                        case 1:
                            a.ToSecondColorModel();
                            bmp = new Bitmap(a.ToGrayMultStream(bmp, 4));
                            break;
                        case 2:
                            bmp = a.AverageGrayForm(bmp);
                            break;
                    }
                }
                else bmp = a.HardBW(bmp, ui2t_c);
                res_uit2 = bmp;
                bmp = null;
                UpdateImage_tab2_end();
            }
        }

        private void UpdateImage_tab2()
        {
            if (allow_uit2)
            {
                button_peview.Enabled = false;
                button_next_tab2.Enabled = false;
                button_back_tab2.Enabled = false;
                loadingCircle_tab2.Visible = true;
                loadingCircle_tab2.Active = true;
                allow_uit2 = false;
                ui2t_a = radioButton_grayform.Checked;
                ui2t_b = comboBox_grayform.SelectedIndex;
                ui2t_c = trackBar_hardbwthreshold.Value;
                Thread a = new Thread(UpdateImage_tab2_);
                a.Start();
            }
        }

        private void radioButton_grayform_CheckedChanged_1(object sender, EventArgs e)
        {
            trackBar_hardbwthreshold.Enabled = !radioButton_grayform.Checked;
            label_harbw.Enabled = !radioButton_grayform.Checked;
            comboBox_grayform.Enabled = radioButton_grayform.Checked;
            UpdateImage_tab2();
        }

        private void comboBox_grayform_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateImage_tab2();
        }

        private void radioButton_hardbw_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage_tab2();
        }

        private void trackBar_hardbwthreshold_Scroll(object sender, EventArgs e)
        {
            label_harbw.Text = "Порог: " + trackBar_hardbwthreshold.Value;
            UpdateImage_tab2();
        }

        private void button_back_tab2_Click(object sender, EventArgs e)
        {
            process_status = 2;
            CheckStatus();
            tabControl1.SelectedIndex = 0;
        }

        private void button_next_tab2_Click(object sender, EventArgs e)
        {
            TEMP_NUM++;
            new Bitmap(pictureBox_tab2.Image).Save("Temp\\tmp" + TEMP_NUM+".png");
            if (radioButton_grayform.Checked)
            {
                process_status = 4;
                CheckStatus();
                loadingCircle_tab3.Top = pictureBox_tab3.Top + pictureBox_tab3.Height / 2 - loadingCircle_tab3.Height / 2;
                loadingCircle_tab3.Left = pictureBox_tab3.Left + pictureBox_tab3.Width / 2 - loadingCircle_tab3.Width / 2;
                tabControl1.SelectTab(2);
                allow_uit = true;
                UpdateImage_tab3();
            }
            else
            {
                Setup3dTab();
                tabControl1.SelectedIndex = 3;

                process_status = 5;
                CheckStatus();

            }
        }

        private void button_back_tab3_Click(object sender, EventArgs e)
        {
            process_status = 3;
            CheckStatus();
            tabControl1.SelectedIndex=1;
        }

        private void Form_rastermaster_Shown(object sender, EventArgs e)
        {
            var l = Directory.GetFiles("Data\\Images\\");
            foreach (var a in l)
            {
                try
                {
                    Bitmap bmp = new Bitmap(a);
                    listBox1.Items.Add(a);
                    bmp = null;
                }
                catch { }
            }
        }

        private void UpdateImage_tab3_end_set(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(UpdateImage_tab3_end_set);
                Invoke(d, new object[] { a });
            }
            else
            {
                button_peview.Enabled = true;
                loadingCircle_tab3.Active = false;
                loadingCircle_tab3.Visible = false;
                button_next_tab3.Enabled = true;
                button_back_tab3.Enabled = true;
                button_update_tab3.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Update"];
            }
        }

        private void UpdateImage_tab3_end()
        {
            pictureBox_tab3.Image = uit_res;
            allow_uit = true;
            Repeat = false;
            UpdateImage_tab3_end_set(false);
        }

        private void UpdateImage_tab3_()
        {
            Bitmap bmp = (Bitmap)new Bitmap("Temp\\tmp"+TEMP_NUM+".png").Clone();
            VectLib a = new VectLib();
            a.Options.GaussBlurKCof = uit_a;
            a.Options.GaussBlurSigma = uit_b;
            a.Gauss(ref bmp);
            a.Options.SobelOperatorLimFonf = uit_c;
            a.Sobel(ref bmp);
            uit_res = bmp;
            UpdateImage_tab3_end();
        }

        private void UpdateImage_tab3()
        {
            label_gauss_scale.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Scale"] +": " + trackBar_gauss_scale.Value;
            label_gauss_sigma.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Sigma"] + ": " + (trackBar_gauss_sigma.Value / 10f).ToString(CultureInfo.InvariantCulture);
            label_sobel.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Threshold"] + ": " + trackBar_sobelthreshold.Value; 
            if (allow_uit)
            {
                button_peview.Enabled = false;
                button_next_tab3.Enabled = false;
                button_update_tab3.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Stop"];
                button_back_tab3.Enabled = false;
                if (!Repeat) Repeat = true;
                loadingCircle_tab3.Visible = true;
                loadingCircle_tab3.Active = true;
                allow_uit = false;
                uit_a = (short)trackBar_gauss_scale.Value;
                uit_b = trackBar_gauss_sigma.Value / 10;
                uit_c = trackBar_sobelthreshold.Value;
                uit3 = new Thread(UpdateImage_tab3_);
                uit3.Start();
            }
        }

        private void trackBar_gauss_sigma_Scroll(object sender, EventArgs e)
        {
            UpdateImage_tab3();
        }

        private void trackBar_gauss_scale_Scroll(object sender, EventArgs e)
        {
            UpdateImage_tab3();
        }

        private void trackBar_sobelthreshold_Scroll(object sender, EventArgs e)
        {
            UpdateImage_tab3();
        }

        private void button_update_tab3_Click(object sender, EventArgs e)
        {
            if(button_update_tab3.Text == TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Stop"])
            {
                loadingCircle_tab3.Visible = false;
                loadingCircle_tab3.Active = false;
                allow_uit = true;
                uit3.Abort();
                button_update_tab3.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Update"];
            } else UpdateImage_tab3();
        }

        private void button_update_tab2_Click(object sender, EventArgs e)
        {
            UpdateImage_tab2();
        }

        int OP_COUNT;

        private void button1_Click_1(object sender, EventArgs e)
        {
            OP_COUNT++;
            var a = OP_COUNT.ToString();
            try {
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        System.Diagnostics.Process.Start(path);
                        break;
                    case 1:
                        new Bitmap(pictureBox_tab2.Image).Save("Temp\\tmp_"+a+".png");
                        System.Diagnostics.Process.Start("Temp\\tmp_"+a+".png");
                        break;
                    case 2:
                        new Bitmap(pictureBox_tab3.Image).Save("Temp\\tmp_"+a+".png");
                        System.Diagnostics.Process.Start("Temp\\tmp_" + a + ".png");
                        break;
                    case 3:
                        new Bitmap(pictureBox_tab4.Image).Save("Temp\\tmp_" + a + ".png");
                        System.Diagnostics.Process.Start("Temp\\tmp_" + a + ".png");
                        break;
                }
            }
            catch { }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button_peview.Enabled = true;
                buffimg = new Bitmap(openFileDialog1.FileName);
                path = openFileDialog1.FileName;
                pictureBox_tab1.Image = @buffimg;
                groupBox_rotate.Enabled = true;
                groupBox_flip.Enabled = true;
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                label_path.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Name"] + ": " + fi.Directory.Name + "/" + fi.Name;
                label_resolution.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Resolution"] +": " + buffimg.Width + "x" + buffimg.Height;
                string len = "";
                if (fi.Length < 1024) len = fi.Length + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Bytes"];
                else if (fi.Length < 1024 * 1024 && fi.Length > 1024) len = ((float)fi.Length / 1024) + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.KBytes"];
                else len = ((float)fi.Length / 1024 / 1024) + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.MBytes"];
                label_size.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Size"] + ": " + len;
                button_next.Enabled = true;
                var b = (Bitmap)Resources.scroll.Clone();
                b.RotateFlip(RotateFlipType.Rotate90FlipX);
                scroll_right.Image = b;
                var c = (Bitmap)Resources.scroll.Clone();
                c.RotateFlip(RotateFlipType.Rotate90FlipNone);
                scroll_left.Image = c;
                var d = (Bitmap)Resources.scroll.Clone();
                d.RotateFlip(RotateFlipType.RotateNoneFlipY);
                scroll_down.Image = d;
                scroll_up.Image = (Bitmap)Resources.scroll.Clone();
                scroll_up.Cursor = Cursors.SizeNS;
                scroll_down.Cursor = Cursors.SizeNS;
                scroll_right.Cursor = Cursors.SizeWE;
                scroll_left.Cursor = Cursors.SizeWE;
                AllowScroll = true;
            tabControl1.SelectedIndex = 0;
            button_peview.Enabled = true;
            };
        }

        private void button_next_tab3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            Bitmap bmp = new Bitmap(pictureBox_tab3.Image);
            for (int x = 0; x <= bmp.Width - 1; x++)
                for (int y = 0; y <= bmp.Height - 1; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, c.A == 0? Color.White : Color.Black); //(Helper.Helper.GetAverageColor(bmp.GetPixel(x, y)) > 125 ? Color.Black : Color.White));
                }
            TEMP_NUM++;
            bmp.Save("Temp\\tmp" + TEMP_NUM + ".png");
            label_resolution_.Text = string.Format(TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Resolution"] + ": {0}x{1}", bmp.Width, bmp.Height);
            label_imgname.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Name"] + ": " + path;
            pictureBox_tab2.Image = bmp;
            pictureBox_tab4.Image = bmp;
            process_status = 5;
            CheckStatus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            process_status = 1;
            CheckStatus();
            button_peview.Visible = true;
            tabControl1.SelectedIndex = 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            process_status = 1;
            CheckStatus();
            tabControl1.SelectedIndex = 4;
        }

        private void button_savepr_Click_1(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (new FileInfo(saveFileDialog1.FileName).Extension == ".pcv") pr.Save(saveFileDialog1.FileName);
                else pr.SavePRRES(saveFileDialog1.FileName, path);
            }
        }

        private void button_back_tab4_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            process_status = 5;
            CheckStatus();
        }

        int vect_saved;

        private void button_show_Click_1(object sender, EventArgs e)
        {
            vect_saved++;
            pr.Save("Temp\\" + vect_saved + ".pcv");
            FormTranslator.Translate(new Form_ViewVect("Temp\\" + vect_saved + ".pcv", true)).Show(); ;
        }

        private void button_print_Click_1(object sender, EventArgs e)
        {
            vect_saved++;
            pr.Save("Temp\\" + vect_saved + ".pcv");
            new Form_PrintMaster("Temp\\" + vect_saved + ".pcv", true).Show();
        }

        private void button_next_tab4_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            process_status = 3;
            CheckStatus();
        }

        private void UpdateImage_tab4_end_set(bool a)
        {
            if (InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(UpdateImage_tab4_end_set);
                Invoke(d, new object[] { a });
            }
            else
            {
                loadingCircle_tab4.Visible = false;
                loadingCircle_tab4.Active = false;
                button_back_tab4.Enabled = true;
                button_next_tab4.Enabled = true;
                button_savepr.Enabled = true;
                button_pr.Enabled = true;
                button_show.Enabled = true;
                button_print.Enabled = true;
                numericUpDown1.Enabled = true;
                button_peview.Enabled = true;
                label_percentage.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Complete"];
                progressBar1.Value = 0;
                timer1.Stop();
                process_status = 7;
                CheckStatus();
            }
        }

        Vectorizer vectizer = new Vectorizer();

        private void Pr_tr_proc()
        {
            pr = vectizer.Proceed(new Bitmap(pictureBox_tab2.Image), false, num);
            pictureBox1.Image =pr.ToBitmap();
            UpdateImage_tab4_end_set(false);
        }

        private void button_pr_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
            c = 0;
            button_peview.Enabled = false; ;
            pr = new Vector();
            numericUpDown1.Enabled = false;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            button_next_tab4.Enabled = false;
            button_back_tab4.Enabled = false;
            button_pr.Enabled = false;
            button_savepr.Enabled = false;
            num = (int)numericUpDown1.Value;
            loadingCircle_tab4.Visible = true;
            loadingCircle_tab4.Active = true;
            vectizer.PrStatusChanged += Pr_PrresChanged;
            process_status = 6;
            CheckStatus();
            pr_t = new Thread(Pr_tr_proc);
            pr_t.Start();
        }

        private void SetStringVal_proc(string s)
        {
            if (InvokeRequired)
            {
                SetStringVal d = new SetStringVal(SetStringVal_proc);
                Invoke(d, new object[] { s });
            }
            else label_timespend.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.TimeSpend"] + ": " + s;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            SetStringVal_proc(string.Format("{0}s ({1:0.##}m)", c++, ((float)c/60)));
        }

        private void SetProgressBarVal_proc(int val, int val_)
        {
            if (InvokeRequired)
            {
                SetProgressBarVal d = new SetProgressBarVal(SetProgressBarVal_proc);
                Invoke(d, new object[] { val, val_ });
            }
            else
            {
                progressBar1.Maximum = val;
                progressBar1.Value = val_;
                label_percentage.Text = string.Format("{0}/{1}, {2:0.##}%", val_,val, (val_ / val * 100).ToString(CultureInfo.InvariantCulture));
            }
        }

        private void Setup3dTab()
        {
            label_imgname.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Name"] + ": " + new FileInfo(path).Directory.Name + '\\' + new FileInfo(path).Name;
            label_resolution_.Text = string.Format(TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Resolution"] +": {0}x{1}",pictureBox_tab2.Image.Width, pictureBox_tab2.Image.Height);
            var a = pictureBox_tab4.Image;
            pictureBox_tab4.Image = (Image)new Bitmap("Temp\\tmp"+TEMP_NUM+".png").Clone();
        }

        private void Pr_PrresChanged(PrStausChangedParameters a)
       {
            SetProgressBarVal_proc(a.MaxValue, a.Value);
       }

        private void button_savepr_Click(object sender, EventArgs e)
        {
            /* textBox_prresname.Text = ((string)listBox1.Items[listBox1.SelectedIndex]).Split('.')[0].Split('\\')[1];
             if (button_savepr.Text == "Accept")
             {
                 pr.SaveVect_new("Data\\Vect\\" + textBox_prresname.Text + ".pcv");
                 Compresser.Compresser.Compress("Data\\Vect\\" + textBox_prresname.Text + ".pcv", false,"vectarch");
                 button_savepr.Text = "Save";
                 textBox_prresname.Visible = false;
                 textBox_prresname.Clear();
                 return;
             }
             textBox_prresname.Visible = true;
             button_savepr.Text = "Accept";*/
        }

        private void button_next_tab4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_back_tab4_Click(object sender, EventArgs e)
        {
            tabControl1.TabIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            button_peview.Enabled = false;
            var l = Directory.GetFiles("Data\\Images\\");
            foreach (var a in l)
            {
                try
                {
                    Bitmap bmp = new Bitmap(a);
                    listBox1.Items.Add(a);
                    bmp = null;
                }
                catch { }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                FileInfo fi = new FileInfo((string)listBox1.Items[listBox1.SelectedIndex]);
                string len;
                string fn = (string)listBox1.Items[listBox1.SelectedIndex];
                if (fi.Length < 1024) len = fi.Length + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Bytes"];
                else if (fi.Length < 1024 * 1024 && fi.Length > 1024) len = ((float)fi.Length / 1024) + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.KBytes"];
                else len = ((float)fi.Length / 1024 / 1024) + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.MBytes"];
                fi = null;
                label_img_size.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Size"] +": " + len;
                Bitmap bmp = new Bitmap(fn);
                label_img_name.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Name"] + ": " + fn;
                label_img_resol.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Resolution"] + ": " + bmp.Width + "x" + bmp.Height;
                label_img_pixelformat.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.PixelFormat"] + ": " + bmp.PixelFormat;
                try
                {
                    label_img_dpi.Text = string.Format(TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Dpi"] + ": {0}x{1}", Graphics.FromImage(bmp).DpiX, Graphics.FromImage(bmp).DpiY);
                }
                catch { label_img_dpi.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Dpi"] + ':' +  TranslateBase.CurrentLang.Phrase["VectorMaster.CantCalculateDPI"]; }
                pictureBox_tab0.Image = bmp;
                button_next_tab0.Enabled = true;
            }
        }

        private void button_openfolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Data\\images\\");
        }

        private void button_exit_tab0_Click(object sender, EventArgs e)
        {
            process_status = 1;
            CheckStatus();
            tabControl1.SelectedIndex = 6;
        }

        private void button_next_tab0_Click(object sender, EventArgs e)
        {
            process_status = 2;
            CheckStatus();
            path = (string)listBox1.Items[listBox1.SelectedIndex];
            button_peview.Enabled = true;
            buffimg = new Bitmap(path);
            pictureBox_tab1.Image = @buffimg;
            groupBox_rotate.Enabled = true;
            groupBox_flip.Enabled = true;
            FileInfo fi = new FileInfo(path);
            label_path.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Name"] + ": " + fi.Directory.Name + "/" + fi.Name;
            label_resolution.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Resolution"] + ": " + buffimg.Width + "x" + buffimg.Height;
            string len = "";
            if (fi.Length < 1024) len = fi.Length + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Bytes"];
            else if (fi.Length < 1024 * 1024 && fi.Length > 1024) len = ((float)fi.Length / 1024) + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.KBytes"];
            else len = ((float)fi.Length / 1024 / 1024) + TranslateBase.CurrentLang.Phrase["VectorMaster.Word.MBytes"];
            label_size.Text = TranslateBase.CurrentLang.Phrase["VectorMaster.Word.Size"] + ": " + len;
            button_next.Enabled = true;
            var b = (Bitmap)Resources.scroll.Clone();
            b.RotateFlip(RotateFlipType.Rotate90FlipX);
            scroll_right.Image = b;
            var c = (Bitmap)Resources.scroll.Clone();
            c.RotateFlip(RotateFlipType.Rotate90FlipNone);
            scroll_left.Image = c;
            var d = (Bitmap)Resources.scroll.Clone();
            d.RotateFlip(RotateFlipType.RotateNoneFlipY);
            scroll_down.Image = d;
            scroll_up.Image = (Bitmap)Resources.scroll.Clone();
            scroll_up.Cursor = Cursors.SizeNS;
            scroll_down.Cursor = Cursors.SizeNS;
            scroll_right.Cursor = Cursors.SizeWE;
            scroll_left.Cursor = Cursors.SizeWE;
            AllowScroll = true;
            tabControl1.SelectedIndex = 0;
            button_peview.Enabled = true;
        }
    }
}
