/*=================================\
* PlotterControl\Form_ViewVect.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 26.08.2017 16:30:54
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
        private Vector pr;
        private Color backcolor;
        private Color drawcolor;
        private Thread draw_th;
        private Bitmap bmp_fb;
        private Thread DrawThr;
        private int Num = 0;
        private List<VPoint> points;
        private delegate void ChangeImgFeedback(Bitmap s);
        private int lastsi;
        private Bitmap colorprobe_back, colorprobe_draw;
        private delegate void ChangeLabelTextFeedback(string s);
        private Bitmap bmp;
        public string filename;

        public Form_ViewVect()
        {
            InitializeComponent();
            loadingCircle1.InnerCircleRadius = 25;
            loadingCircle1.OuterCircleRadius = 26;
            loadingCircle1.NumberSpoke = 100;
        }

        public Form_ViewVect(string fn, bool ignore)
        {
            if (!ignore)
            {
                var fi = new FileInfo(Application.ExecutablePath);
                GlobalOptions.Filename = fi.DirectoryName + "\\Options\\options.xml";
                GlobalOptionsLogPolitics.Filename = fi.DirectoryName + "\\Options\\logPolitics.xml";
                GlobalOptions.Load();
            }
            InitializeComponent();
            loadingCircle1.InnerCircleRadius = 25;
            loadingCircle1.OuterCircleRadius = 26;
            loadingCircle1.NumberSpoke = 100;
            proceed(fn);
            FillListBox();
        }

        private void FillListBox()
        {
            int i = 0;
            listBox1.Items.Clear();
            foreach (var a in pr.RawData) listBox1.Items.Add(string.Format(TranslateBase.CurrentLang.Phrase["VectorViewer.ContourDiscr"], i++, a.Length));
        }

        private void proceed(string fn)
        {
            lastsi = 0;
            filename = fn;
            checkBox_randomcolor.Enabled = true;
            pictureBox2.Width = pictureBox1.Width;
            pictureBox2.Height = pictureBox1.Height;
            colorprobe_back = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            colorprobe_draw = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            //label_cont_points.Enabled = true;
            label_pathtofile.Enabled = true;
            //label_resolution.Enabled = true;
            //label_resname.Enabled = true;
            //label_prtime.Enabled = true;
            listBox1.Enabled = true;
            button_begindraw.Enabled = true;
            button_pickcolor.Enabled = true;
            button_redraw.Enabled = true;
            button_print.Enabled = true;
            button_pick2ndcolor.Enabled = true;
            button_outter.Enabled = true;
            loadingCircle1.Visible = true;
            loadingCircle1.Active = true;
            label_status.Visible = true;
            label_status.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Loading"];
            path = fn;
            pr = new Vector(path);
            label_pathtofile.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.PathToFile"] + ": " + new FileInfo(path).Directory.Name + '\\' + path.Split('\\')[path.Split('\\').Length-1] ;
            toolStripStatusLabel_filename.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Filename"] + ": " + new FileInfo(path).Directory.Name + '\\' + path.Split('\\')[path.Split('\\').Length - 1];
            toolStripStatusLabel_resolution.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Resolution"] + ": " + pr.Header.Width + "x" + pr.Header.Height;
            toolStripStatusLabel1.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Contours"] + ": " + pr.ContorurCount + "; " + TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Points"] + ": " + pr.Points.ToString();
            pr.RawData = pr.RawData.ToList().OrderByDescending(p => p.Length).ToArray();
            Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Label"] + " \"" + new FileInfo(path).Directory.Name + '\\' + path.Split('\\')[path.Split('\\').Length - 1] + '\"';
            drawcolor = GlobalOptions.DefViewDraw;
            backcolor = GlobalOptions.DefViewBack;
            label_status.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.Word.Drawing"];
            if (new FileInfo(filename).Extension == ".prres") toolStripStatusLabel_oldprstyle.Text = TranslateBase.CurrentLang.Phrase["VectorViewer.OldVectorFormat"];
            else toolStripStatusLabel_oldprstyle.Text = "";
            draw_th?.Abort();
            draw_th = new Thread(ChangeLabelTextProcAsync);
            setcolorprobe();
            draw_th.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            path = openFileDialog1.FileName;
            proceed(path);
            FillListBox();
        }

        private void setcolorprobe()
        {
            Rectangle rect = new Rectangle(0, 0,(int) pr.Header.Width, (int)pr.Header.Height);
            using (Graphics gr = Graphics.FromImage(colorprobe_back))
            {
                gr.FillRectangle(new SolidBrush(backcolor), rect);
            }
            using (Graphics gr = Graphics.FromImage(colorprobe_draw))
            {
                gr.FillRectangle(new SolidBrush(drawcolor), rect);
            }
            pictureBox1.Image = colorprobe_draw;
            pictureBox2.Image = colorprobe_back;
        }

        private void Form_viewvect_Load(object sender, EventArgs e)
        {
            //listBox2.Items.Clear();
            //string[] paths = Directory.GetFiles("prres\\", "*.prres");
            //listBox2.Items.AddRange(paths);
            //paths = Directory.GetFiles("prres\\", "*.pcv");
            //listBox2.Items.AddRange(paths);
        }
        private void ChangeLabelTextProc(string s)
        {
            if (InvokeRequired)
            {
                ChangeLabelTextFeedback d = new ChangeLabelTextFeedback(ChangeLabelTextProc);
                Invoke(d, new object[] { s });
            }
            else
            {
                loadingCircle1.Visible = false;
                loadingCircle1.Active = false;
                label_status.Visible = false;
                //label_status.Text = "Loading...";
            }
        }

        private void ChangeLabelTextProcAsync()
        {
            bmp = new Bitmap((int)pr.Header.Width, (int)pr.Header.Height);
            Random rnd = new Random();
            Rectangle rect = new Rectangle(0, 0,(int) pr.Header.Width, (int)pr.Header.Height);
            using (Graphics gr = Graphics.FromImage(bmp)) gr.FillRectangle(new SolidBrush(backcolor), rect);
            for (int i = 0; i <= pr.RawData.Length - 1; i++)
            {
                Color c;
                if (!checkBox_randomcolor.Checked) c = drawcolor;
                else c = Color.FromArgb(255, rnd.Next(100,255), rnd.Next(100,255), rnd.Next(100,255));
                for (var ii = 0; ii <= pr.RawData[i].Length - 1; ii++)
                    try { bmp.SetPixel((int)pr.RawData[i][ii].BasePoint.Y, (int)pr.RawData[i][ii].BasePoint.X, c); }
                    catch { }
            }
            pictureBox_main.Image = bmp;
            ChangeLabelTextProc("");
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
                if (!checkBox_randomcolor.Checked) c = drawcolor;
                else c = Color.FromArgb(255, rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255));
                for (var ii = 0; ii <= pr.RawData[lastsi].Length - 1; ii++)
                    try { bmp.SetPixel((int)pr.RawData[lastsi][ii].BasePoint.Y, (int)pr.RawData[lastsi][ii].BasePoint.X, c); }
                    catch { }
                int nowsel = listBox1.SelectedIndex;
                c = Color.Yellow;
                for (var ii = 0; ii <= pr.RawData[nowsel].Length - 1; ii++)
                    try { bmp.SetPixel((int)pr.RawData[nowsel][ii].BasePoint.Y, (int)pr.RawData[nowsel][ii].BasePoint.X, c); }
                    catch { }
                pictureBox_main.Image = bmp;
                lastsi = nowsel;
            }
        }

        
        private void ChangeImgProc(Bitmap s)
        {
            if (InvokeRequired)
            {
                ChangeImgFeedback d = new ChangeImgFeedback(ChangeImgProc);
                Invoke(d, new object[] { s });
            }
            else
            {
                trackBar1.Value = Num;
                var a = pictureBox_main.Image;
                pictureBox_main.Image = (Image)bmp_fb.Clone();
                a.Dispose();
            }
        }

        private void Draw()
        {
            while(true)
            {
                lock(bmp) bmp_fb.SetPixel((int)points[Num].X, (int)points[Num].Y, GlobalOptions.DefViewDraw);
                Num += 1;
                ChangeImgProc(bmp);
            }
        }

        private void Form_viewvect_DragDropEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void statusStrip1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fn =  (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(fn[0].EndsWith(".pcv")) proceed(fn[0]);
            FillListBox();
        }

        private void button_redraw_Click(object sender, EventArgs e)
        {
            loadingCircle1.Visible = true;
            loadingCircle1.Active = true;
            label_status.Visible = true;
            draw_th?.Abort();
            draw_th = new Thread(ChangeLabelTextProcAsync);
            setcolorprobe();
            draw_th.Start();
            listBox1.SelectedIndex = -1;
        }

        private void button_pick2ndcolor_Click(object sender, EventArgs e)
        {
            var a = colorDialog1.ShowDialog();
            if( a== DialogResult.OK) backcolor = colorDialog1.Color;
            setcolorprobe();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button_pickcolor.Enabled = !checkBox_randomcolor.Checked;
            pictureBox1.Enabled = !checkBox_randomcolor.Checked;
        }

        private void button_pickcolor_Click(object sender, EventArgs e)
        {
            var a = colorDialog2.ShowDialog();
            if (a == DialogResult.OK) drawcolor = colorDialog2.Color;
            setcolorprobe();
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            Form_PrintMaster fpr = new Form_PrintMaster(filename,true);
            fpr.Show();
        }

        private void Form_viewvect_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrawThr?.Abort();
        }

        private void button_begindraw_Click(object sender, EventArgs e)
        {
            bmp_fb = new Bitmap((int)pr.Header.Width, (int)pr.Header.Height);
            using (Graphics g = Graphics.FromImage(bmp_fb)) g.FillRectangle(new SolidBrush(GlobalOptions.DefViewBack), new Rectangle(0, 0, (int)pr.Header.Width, (int)pr.Header.Height));
            points = new List<VPoint>();
            for (int i = 0; i <= pr.RawData.Length - 1; i++)
                for (var ii = 0; ii <= pr.RawData[i].Length - 1; ii++)
                    points.Add(pr.RawData[i][ii].BasePoint);
            trackBar1.Maximum = points.Count;
            DrawThr = new Thread(Draw);
            DrawThr.Start();
        }
    }
}
