/*=================================\
* PlotterControl\Form_Graph.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using CWA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CnC_WFA
{
    public partial class Form_Graph : Form
    {
        public Form_Graph()
        {
            InitializeComponent();
        }

        private PointF ZeroPoint;

        public void DrawRaw(float dx, float dy, InterpolationMode iMmode, CompositingQuality cQuality, SmoothingMode sm)
        {
            if (Main.Graphs.Count == 0)
            {
                labelHint.Visible = true;
                Bitmap im = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics gr = Graphics.FromImage(im))
                {
                    gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
                }
                Image img = pictureBox1.Image;
                pictureBox1.Image = im;
                if (img != null) img.Dispose();
            }
            else
            {
                labelHint.Visible = false;
                Bitmap im = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics gr = Graphics.FromImage(im))
                {
                    gr.InterpolationMode = iMmode;
                    gr.CompositingQuality = cQuality;
                    gr.SmoothingMode = sm;
                    gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
                    Matrix mat = new Matrix();
                    mat.Translate(dx, dy);
                    mat.Scale(Zoom, Zoom);
                    foreach (var b in Main.Graphs)
                    {
                        var grP = b.Build();
                        grP.Transform(mat);
                        if (b.MainPen.Width != 1) gr.DrawPath(new Pen(b.MainPen.Color, b.MainPen.Width * Zoom / 100), grP);
                        else gr.DrawPath(b.MainPen, grP);

                        if (b.Display && b.Markers.Use)
                        {
                            foreach (var c in b.Markers.Points)
                            {
                                gr.FillEllipse(new SolidBrush(b.Markers.Color), Zoom * c + dx - b.Markers.Size / 2, (-Zoom) * (b.DataSource.GetValue(c)) + dy - b.Markers.Size / 2, b.Markers.Size, b.Markers.Size);
                            }
                        }
                    }

                    if (Main.AxisParams.Show)
                    {
                        var AxisPen = new Pen(Main.AxisParams.Color, Main.AxisParams.Width);

                        var xAxis = Main.GetXAxis();
                        var yAxis = Main.GetYAxis();
                        xAxis.Transform(mat);
                        yAxis.Transform(mat);

                        gr.DrawPath(AxisPen, xAxis);
                        gr.DrawPath(AxisPen, yAxis);
                    }
                }
                Image img = pictureBox1.Image;
                pictureBox1.Image = im;
                if (img != null) img.Dispose();

                ZeroPoint = new PointF(dx, dy);
            }
        }

        public void RedrawHigh(float dx, float dy)
        {
            DrawRaw(dx, dy, InterpolationMode.High, CompositingQuality.HighQuality, SmoothingMode.AntiAlias);
        }

        public void RedrawLow(float dx, float dy)
        {
            DrawRaw(dx, dy, InterpolationMode.NearestNeighbor, CompositingQuality.HighSpeed, SmoothingMode.None);
        }

        private float Zoom;
        private const int DefZoom = 15;

        private void UpdateListBox()
        {
            listBox_Main.Items.Clear();
            listBox_Main.Items.AddRange(Main.Graphs.Select(p => p.Name + (!p.Display ? "[hide]" : "")).ToArray());

            trackBar1.Enabled = Main.Graphs.Count != 0;
            panel1.Visible = Main.Graphs.Count != 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var el = new Graph()
            {
                DataSource = new FormulaDataSource()
                {
                    LowLim = -(float)Math.PI * 2,
                    HighLim = (float)Math.PI * 2,
                    Formula = "Math.Cos(x)",
                    HighLimFormula = "Math.PI * 2",
                    LowLimFormula = "-Math.PI * 2"

                },
                Markers = new GraphMarkers()
                {
                    UsePeriodic = true,
                    Use = true,
                    AutoLims = true,
                    PeriodFormula = "Math.PI",
                    LowLimFormula = "-Math.PI * 2",
                    HighLimFormula = "Math.PI * 2",
                    Type = MarkerType.Circle,
                    Size = 5,
                    Color = Color.Red
                }
            };

            el.Name = "graph" + Main.Graphs.Count;
            
            el.Markers.CompilePeriod();
            (el.DataSource as FormulaDataSource).Compile();

            new Form_Dialog_EditGraph(el) { FormParent = this }.ShowDialog();
            Main.Graphs.Add(el);
            UpdateListBox();
            Main.ResetPrerender();
            RedrawHigh(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
        }

        public Graph EditingObject;
        private GraphDoc Main;

        private void Form_Graph_Load(object sender, EventArgs e)
        {
            Main = new GraphDoc()
            {
                AxisParams = new GraphDocAxis()
                {
                    Color = Color.Green,
                    UseUnlimited = true,
                    Show = true,
                    Width = 1,
                    XOffset = 0,
                    YOffset = 0
                },
                LocalGraphDocVers = GraphDoc.GraphDocVers
            };
            Zoom = DefZoom;
            trackBar1.Value = DefZoom;
            MouseWheel += PictureBox1_MouseWheel;
            loadingCircle_tab1.Top = panel_wait.Height / 2 - loadingCircle_tab1.Height / 2 - 40;
            loadingCircle_tab1.Left = panel_wait.Width / 2 - loadingCircle_tab1.Width / 2;
            panel_wait.Top = Height / 2 - panel_wait.Height / 2 - 40;
            panel_wait.Left = Width / 2 - panel_wait.Width / 2;
            panel_loaderr.Top = Height / 2 - panel_loaderr.Height / 2 - 40;
            panel_loaderr.Left = Width / 2 - panel_loaderr.Width / 2;
        }

        private int Map(int value, int max, int min)
        {
            if (value >= max) return max;
            else if (value <= min) return min;
            else return value;
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Main.Graphs.Count != 0)
            {
                trackBar1.Value = Map(trackBar1.Value + e.Delta / 20, trackBar1.Maximum, trackBar1.Minimum);
                trackBar1_Scroll(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox_Main.SelectedIndex!=-1)
            {
                new Form_Dialog_EditGraph(Main.Graphs[listBox_Main.SelectedIndex]).ShowDialog();
                Main.ResetPrerender();
                UpdateListBox();
                RedrawHigh(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
            }
        }

        private int oldVal;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //oldDeltas = new Point((int)((float)oldDeltas.X / oldVal * trackBar1.Value), (int)((float)oldDeltas.X / oldVal * trackBar1.Value));
            dx = (int)((float)dx * oldVal / trackBar1.Value);
            dy = (int)((float)dy * oldVal / trackBar1.Value);

            Zoom = trackBar1.Value;
            label_zoom.Text = string.Format("Увеличение на {0}%", Zoom);
            RedrawLow(pictureBox1.Width / 2 - oldDeltas.X, pictureBox1.Height / 2 - oldDeltas.Y);
            
            timer_redraw.Stop();
            timer_redraw.Start();

            oldVal = trackBar1.Value;
        }

        private Point oldDeltas = new Point(0,0), startPoint;
        private int dx, dy;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Main.Graphs.Count != 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dx = startPoint.X - e.X;
                    dy = startPoint.Y - e.Y;
                    RedrawLow(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
                }
                label_x.Text = string.Format("MouseX: {0 : 0.####}", (e.X - ZeroPoint.X) / Zoom);
                label_y.Text = string.Format("MouseY: {0 : 0.####}", (e.Y - ZeroPoint.Y) / Zoom);
            }
        }

        private void checkBox_use_axis_CheckedChanged(object sender, EventArgs e)
        {
            Main.AxisParams.Show = (sender as CheckBox).Checked;
            button_setup_axis.Enabled = (sender as CheckBox).Checked;
            RedrawHigh(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
        }

        private void checkBox_use_axisNames_CheckedChanged(object sender, EventArgs e)
        {
            button_setup_axisNames.Enabled = (sender as CheckBox).Checked;
        }

        private void checkBox_use_docName_CheckedChanged(object sender, EventArgs e)
        {
            button_setup_docName.Enabled = (sender as CheckBox).Checked;
        }

        private void checkBox__use_Grid_CheckedChanged(object sender, EventArgs e)
        {
            button_setup_grid.Enabled = (sender as CheckBox).Checked;
        }

        private void checkBox_use_legend_CheckedChanged(object sender, EventArgs e)
        {
            button_setup_legend.Enabled = (sender as CheckBox).Checked;
        }

        private void checkBox_use_addPoints_CheckedChanged(object sender, EventArgs e)
        {
            button_setup_addPoints.Enabled = (sender as CheckBox).Checked;
        }

        private void timer_redraw_Tick(object sender, EventArgs e)
        {
           // RedrawHigh(pictureBox1.Width / 2 - oldDeltas.X + dx, pictureBox1.Height / 2 - oldDeltas.Y + dy);
            timer_redraw.Stop();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (Main.Graphs.Count != 0)
            {
                pictureBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox_Main.SelectedIndex != -1)
                if(MessageBox.Show(string.Format("Вы действительно хотите удалить график {0}?", Main.Graphs[listBox_Main.SelectedIndex].Name), "Удалeние", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Main.Graphs.RemoveAt(listBox_Main.SelectedIndex);
                    UpdateListBox();
                    
                    if(Main.Graphs.Count == 0)
                    {
                        RedrawHigh(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
                        oldDeltas = new Point(0, 0);
                        dx = 0; dy = 0;
                    }
                }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBox_Main.SelectedIndex != -1)
            {
                Main.Graphs.Add((Graph)Main.Graphs[listBox_Main.SelectedIndex].Clone());
                Main.Graphs[Main.Graphs.Count - 1].Name += "_Copy";
                UpdateListBox();
            }
        }

        private void Form_Graph_SizeChanged(object sender, EventArgs e)
        {
            panel_tools.Left = Width - 283;
            panel_tools.Top = 2;
            pictureBox1.Width = Width - 298;
            pictureBox1.Height = Height - 61;
            panel1.Top = Height - 48 - panel1.Height;
            panel_wait.Top = Height / 2 - panel_wait.Height / 2 - 40;
            panel_wait.Left = Width / 2 - panel_wait.Width / 2;
            panel_loaderr.Top = Height / 2 - panel_loaderr.Height / 2 - 40;
            panel_loaderr.Left = Width / 2 - panel_loaderr.Width / 2;

            RedrawHigh(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
        }

        private void listBox_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_edit.Enabled = listBox_Main.SelectedIndex != -1;
            button_del.Enabled = listBox_Main.SelectedIndex != -1;
            button_copy.Enabled = listBox_Main.SelectedIndex != -1;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            trackBar1.Value = 3;
            trackBar1_Scroll(null, null);
            oldDeltas = new Point(0, 0);
            dx = 0; dy = 0;
        }

        private void button_setup_axis_Click(object sender, EventArgs e)
        {
            new Form_Dialog_EditElement(Main, 0).ShowDialog();
            Main.ResetPrerender();
            RedrawHigh(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = new FileInfo(Application.ExecutablePath).DirectoryName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Main.Save(saveFileDialog1.FileName);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = new FileInfo(Application.ExecutablePath).DirectoryName;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;
                panel_wait.Visible = true;
                panel_tools.Enabled = false;
                pictureBox1.Visible = false;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        string FileName;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Main = GraphDoc.Load(FileName);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateListBox();
            dx = 0; dy = 0;
            oldDeltas = new Point(0, 0);
            Zoom = DefZoom;
            trackBar1.Value = DefZoom;
            RedrawHigh(pictureBox1.Width / 2, pictureBox1.Height / 2);
            panel_wait.Visible = false;
            panel_tools.Enabled = true;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Main.Graphs.Count != 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox1.Cursor = Cursors.Default;
                    oldDeltas = new Point(dx, dy);
                    RedrawHigh(pictureBox1.Width / 2 - dx, pictureBox1.Height / 2 - dy);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Main.Graphs.Count != 0)
            {
                pictureBox1.Focus();
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox1.Cursor = Cursors.Hand;
                    if (oldDeltas.X != 0 || oldDeltas.Y != 0)
                    {
                        startPoint = new Point(e.X + oldDeltas.X, e.Y + oldDeltas.Y);
                    }
                    else startPoint = e.Location;
                }
            }
        }
    }
}
