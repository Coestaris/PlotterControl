/*=================================\
* PlotterControl\Form_ViewVect.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 09.09.2017 12:34:47
*=================================*/

using CWA;
using CWA.Vectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_ViewVect : Form
    {
        private string path;
        private Vector vect;
        private Color backcolor;
        private Color drawcolor;
        public string filename;
        private Thread draw_th;
        private int lastsi;
        private Bitmap bmp;
        private Color selColor;
        private bool defaultView;

        private bool isToolStrip;
        private bool isZoom;
        private bool isList;

        public Form_ViewVect()
        {
            InitializeComponent();

            isToolStrip = true;
            isZoom = true;
            isList = false;

            SetIntr();

            panel_zoom.Visible = false;

            loadingCircle1.InnerCircleRadius = 25;
            loadingCircle1.OuterCircleRadius = 26;
            loadingCircle1.NumberSpoke = 100;
        }

        public Form_ViewVect(string fn, bool ignore)
        {
            InitializeComponent();

            isToolStrip = true;
            isZoom = true;
            isList = false;

            SetIntr();

            if (!ignore)
            {
                var fi = new FileInfo(Application.ExecutablePath);
                GlobalOptions.Filename = fi.DirectoryName + "\\Options\\options.xml";
                GlobalOptionsLogPolitics.Filename = fi.DirectoryName + "\\Options\\logPolitics.xml";
                GlobalOptions.Load();
            }
            loadingCircle1.InnerCircleRadius = 25;
            loadingCircle1.OuterCircleRadius = 26;
            loadingCircle1.NumberSpoke = 100;

            panel_zoom.Visible = false;

            Proceed(fn);
            FillListBox();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            Height = (int)vect.Header.Height + 100;
            Width = (int)vect.Header.Width + 40;

            double timesH = double.MaxValue, timesW = double.MaxValue;

            if (vect.Header.Height > resolution.Height - 100)
                timesH = (resolution.Height - 100) / vect.Header.Height;
            if (vect.Header.Width > resolution.Width - 40)
                timesW = (resolution.Width - 40) / vect.Header.Width;

            var minTimes = Math.Min(timesH, timesW);
            if (minTimes != double.MaxValue)
            {
                trackBar1.Value = (int)(minTimes * 100 - 10);
                if (timesH != double.MaxValue)
                    Height = resolution.Height - 100;
                else Height = (int)((Height - 100) * minTimes);
                if (timesW != double.MaxValue)
                    Width = resolution.Width - 40;
                else Width = (int)((Width - 40) * minTimes) - 50;
            }
            else
            {
                isZoom = false;
                SetIntr();
            }

        }

        private void FillListBox()
        {
            int i = 0;
            listBox1.Items.Clear();
            foreach (var a in vect.RawData) listBox1.Items.Add(string.Format(TranslateBase.CurrentLang.Phrase["VectorViewer.ContourDiscr"], i++, a.Length));
        }

        private void SetIntr()
        {
            toolStripMenuItem_defDisp.Image = !defaultView ? CWA_Resources.Properties.Resources.delete : CWA_Resources.Properties.Resources.ok1;
            contoursToolStripMenuItem.Image = !isList ? CWA_Resources.Properties.Resources.delete : CWA_Resources.Properties.Resources.ok1;
            infoStripToolStripMenuItem.Image = !isToolStrip ? CWA_Resources.Properties.Resources.delete : CWA_Resources.Properties.Resources.ok1;
            zoomToolStripMenuItem.Image = !isZoom ? CWA_Resources.Properties.Resources.delete : CWA_Resources.Properties.Resources.ok1;

            statusStrip1.Visible = isToolStrip;
            if (isList)
            {
                panel3.Location = new Point(276, 36);
                panel3.Size = new Size(Width - 304, Height - 110);
                panel_cont.Visible = true;
                if (isZoom)
                {
                    panel_zoom.Visible = true;
                    panel_zoom.Location = new Point(10, 288);
                }
                else panel_zoom.Visible = false;
            }
            else
            {
                panel_cont.Visible = false;
                panel3.Location = new Point(0, 24);
                panel3.Size = new Size(Width - 16, Height - 88);
                if (isZoom)
                {
                    panel_zoom.Visible = true;
                    panel_zoom.Location = new Point(4, Height - 139);
                }
                else panel_zoom.Visible = false;
            }
        }

        private void Proceed(string fn)
        {
            toolStripComboBox_dispType.SelectedIndex = 1;
            lastsi = 0;
            filename = fn;
            listBox1.Enabled = true;
            loadingCircle1.Visible = true;
            loadingCircle1.Active = true;
            label_status.Visible = true;
            label_status.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Loading"];
            path = fn;
            vect = new Vector(path);
            toolStripStatusLabel_filename.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Filename"] + ": " + new FileInfo(path).Directory.Name + '\\' + path.Split('\\')[path.Split('\\').Length - 1];
            toolStripStatusLabel_resolution.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Resolution"] + ": " + vect.Header.Width + "x" + vect.Header.Height;
            toolStripStatusLabel1.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Contours"] + ": " + vect.ContorurCount + "; " + TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Points"] + ": " + vect.Points.ToString();
            vect.RawData = vect.RawData.ToList().OrderByDescending(p => p.Length).ToArray();
            Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Label"] + " \"" + new FileInfo(path).Directory.Name + '\\' + path.Split('\\')[path.Split('\\').Length - 1] + '\"';
            drawcolor = GlobalOptions.DefViewDraw;
            backcolor = GlobalOptions.DefViewBack;
            selColor = Color.Blue;
            label_status.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Drawing"];
            if (new FileInfo(filename).Extension == ".prres") toolStripStatusLabel_oldprstyle.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.OldVectorFormat"];
            else toolStripStatusLabel_oldprstyle.Text = "";
            SetColorProbe();

            label.Visible = false;
            pictureBox_main.Visible = true;

            if (isZoom)
                panel_zoom.Visible = true;

            draw_th = new Thread(ChangeLabelTextProcAsync);
            draw_th.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            path = openFileDialog1.FileName;
            Proceed(path);
            FillListBox();
        }

        private void SetColorProbe()
        {
            Bitmap colorprobe_draw = new Bitmap(50, 50);
            Bitmap colorprobe_back = new Bitmap(50, 50);
            Bitmap colorprobe_sel = new Bitmap(50, 50);
            Rectangle rect = new Rectangle(0, 0, 50, 50);
            Rectangle rect1 = new Rectangle(5, 5, 40, 40);
            using (Graphics gr = Graphics.FromImage(colorprobe_back))
            {
                gr.FillRectangle(Brushes.Black, rect);
                gr.FillRectangle(new SolidBrush(backcolor), rect1);
            }
            using (Graphics gr = Graphics.FromImage(colorprobe_draw))
            {
                gr.FillRectangle(Brushes.Black, rect);
                gr.FillRectangle(new SolidBrush(drawcolor), rect1);
            }
            using (Graphics gr = Graphics.FromImage(colorprobe_sel))
            {
                gr.FillRectangle(Brushes.Black, rect);
                gr.FillRectangle(new SolidBrush(selColor), rect1);
            }
            toolStripMenuItem_color.Image?.Dispose();
            toolStripMenuItem_color.Image = colorprobe_draw;
            toolStripMenuItem_backgroundColor.Image?.Dispose();
            toolStripMenuItem_backgroundColor.Image = colorprobe_back;
            toolStripMenuItem_selectedColor.Image?.Dispose();
            toolStripMenuItem_selectedColor.Image = colorprobe_sel;
        }

        private delegate void EndOfRenderImageHandler();

        private void EndOfRenderImage()
        {
            if (InvokeRequired)
            {
                EndOfRenderImageHandler d = new EndOfRenderImageHandler(EndOfRenderImage);
                Invoke(d, new object[] {});
            }
            else
            {
                loadingCircle1.Visible = false;
                loadingCircle1.Active = false;
                label_status.Visible = false;
                float zoom = trackBar1.Value / 100f;
                pictureBox_main.Image?.Dispose();
                pictureBox_main.Image = new Bitmap(bmp, new Size((int)(bmp.Width * zoom), (int)(bmp.Height * zoom)));
            }
        }

        private void ChangeLabelTextProcAsync()
        {
            bmp = vect.ToBitmap(backcolor, drawcolor);
            EndOfRenderImage();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                Random rnd = new Random();
                Color c;
                var bmp_ = new Bitmap((Image)bmp.Clone());
                if (toolStripComboBox_dispType.SelectedIndex == 0)
                    c = Color.FromArgb(255, rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255));
                else c = drawcolor;

                for (var ii = 0; ii <= vect.RawData[lastsi].Length - 1; ii++)
                    bmp_.SetPixel((int)vect.RawData[lastsi][ii].BasePoint.Y, (int)vect.RawData[lastsi][ii].BasePoint.X, c);
                int nowsel = listBox1.SelectedIndex;
                c = selColor;
                for (var ii = 0; ii <= vect.RawData[nowsel].Length - 1; ii++)
                    bmp_.SetPixel((int)vect.RawData[nowsel][ii].BasePoint.Y, (int)vect.RawData[nowsel][ii].BasePoint.X, c);
                float zoom = trackBar1.Value / 100f;
                pictureBox_main.Image?.Dispose();
                pictureBox_main.Image = new Bitmap(bmp_, new Size((int)(bmp_.Width * zoom), (int)(bmp_.Height * zoom)));
                lastsi = nowsel;

            }
        }

        private void Form_viewvect_DragDropEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void statusStrip1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fn =  (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fn[0].EndsWith(".pcv") || fn[0].EndsWith(".prres")) Proceed(fn[0]);
            else MessageBox.Show("Wrong file format");
            FillListBox();
        }

        private void button_redraw_Click(object sender, EventArgs e)
        {
            loadingCircle1.Visible = true;
            loadingCircle1.Active = true;
            label_status.Visible = true;
            draw_th?.Abort();
            draw_th = new Thread(ChangeLabelTextProcAsync);
            SetColorProbe();
            draw_th.Start();
            listBox1.SelectedIndex = -1;
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            Form_PrintMaster fpr = new Form_PrintMaster(filename,true);
            fpr.Show();
        }

        private void toolStripMenuItem_color_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = drawcolor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                drawcolor = colorDialog1.Color;
                SetColorProbe();
                draw_th = new Thread(ChangeLabelTextProcAsync);
                draw_th.Start();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float zoom = trackBar1.Value / 100f;
            label3.Text = zoom.ToString("0.##");
            pictureBox_main.Image?.Dispose();
            pictureBox_main.Image = new Bitmap(bmp, new Size((int)(bmp.Width * zoom), (int)(bmp.Height * zoom)));
        }

        private void Form_ViewVect_Load(object sender, EventArgs e)
        {
            label_zoom_min.Text = trackBar1.Minimum.ToString();
            label_zoom_max.Text = trackBar1.Maximum.ToString();
            float zoom = trackBar1.Value / 100f;
            label3.Text = zoom.ToString("0.##");
        }

        private void toolStripMenuItem_backgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = backcolor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backcolor = colorDialog1.Color;
                SetColorProbe();
                draw_th = new Thread(ChangeLabelTextProcAsync);
                draw_th.Start();
            }
        }

        private void toolStripMenuItem_selectedColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = selColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selColor = colorDialog1.Color;
                SetColorProbe();
            }
        }

        private void toolStripComboBox_dispType_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_resetZoom_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 100;
        }

        private void Form_ViewVect_Resize(object sender, EventArgs e)
        {
            SetIntr();
        }

        private void contoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isList = !isList;
            SetIntr();
        }

        private void infoStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isToolStrip = !isToolStrip;
            SetIntr();
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isZoom = !isZoom;
            SetIntr();
        }
    }
}
