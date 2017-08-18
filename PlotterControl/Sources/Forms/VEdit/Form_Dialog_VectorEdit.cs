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
* PlotterControl \ Form_Dialog_VectorEdit.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 01.07.2017 13:09:58
*
*=================================*/

using CWA.Vectors;
using CWA.Vectors.Document;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_Dialog_Edit : Form
    {
        public Form_Dialog_Edit()
        {
            InitializeComponent();
            Width = 530;
        }

        public Form_EditVector parent;

        private DocumentData dat;
        private DocumentData bkp;

        int cc = 0;

        public Form_Dialog_Edit(DocumentItem ii)
        {
            InitializeComponent();
            if(ii.GetType() == typeof(DocumentData))
            {
            }
            DocumentData d = (DocumentData)ii;
            dat = (DocumentData)d.Clone();
            bkp = (DocumentData)d.Clone();
            Text = "Editing '" + dat.Name + "'";
            dat.BaseData.Save("Temp\\backup" + cc.ToString() + ".pcv");
            d.BaseData.RawData = d.BaseData.RawData.ToList().OrderByDescending(p => p.Length).ToArray();
            RefillTree();
            gr2 = dat.BaseData.GrPath;
            label_ndresol.Text = "Resolution: " + dat.BaseData.Resolution;
            label_2ndname.Text = "Name (Currect): " + new FileInfo(dat.BaseData.Filename).Directory.Name + "\\" + new FileInfo(dat.BaseData.Filename).Name;
        }

        private void RefillTree()
        {
            treeView_points.Nodes.Clear();
            for (int c = 0; c <= dat.BaseData.RawData.Length - 1; c++)
            {
                treeView_points.Nodes.Add(string.Format("Cnt#{0}, {1}pnts", c, dat.BaseData.RawData[c].Length));
                for (int i = 0; i <= dat.BaseData.RawData[c].Length - 1; i++)
                {
                    treeView_points.Nodes[c].Nodes.Add(string.Format("Pnt#{0}, X: {1}|Y: {2}", i, dat.BaseData.RawData[c][i].BasePoint.X, dat.BaseData.RawData[c][i].BasePoint.Y));
                }
            }
            treeView_points.CollapseAll();
        }

        private void Dialog_Edit_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            TopMost = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_openvector.Enabled = comboBox1.SelectedIndex == 1;
            treeView_pointsex.Nodes.Clear();
            SelectedContour1 = -1;
            if (!button_openvector.Enabled)
            {
                Width = 547;
                for (int c = 0; c <= dat.BaseData.RawData.Length - 1; c++)
                {
                    treeView_pointsex.Nodes.Add(string.Format("Cnt#{0}, {1}pnts", c, dat.BaseData.RawData[c].Length));
                    for (int i = 0; i <= dat.BaseData.RawData[c].Length - 1; i++) treeView_pointsex.Nodes[c].Nodes.Add(string.Format("Pnt#{0}, X: {1}|Y: {2}", i, dat.BaseData.RawData[c][i].BasePoint.X, dat.BaseData.RawData[c][i].BasePoint.Y));
                }
                treeView_pointsex.CollapseAll();
                gr2 = dat.BaseData.GrPath;
                sndvect = dat.BaseData;
                label_ndresol.Text = "Resolution: " + dat.BaseData.Resolution;
                label_2ndname.Text = "Name (Currect): " +  new FileInfo(dat.BaseData.Filename).Directory.Name + "\\" + new FileInfo(dat.BaseData.Filename).Name;
                pictureBox1.Image = Vector.ToBitmapByGrPath(dat.BaseData.Size, Color.White, Color.Black, Color.Blue, 0, gr2, dat.BaseData.RawData);

            } else { Width = 906; }
        }

        private void FillTreeView2()
        {
            treeView_pointsex.Nodes.Clear();
            for (int c = 0; c <= sndvect.RawData.Length - 1; c++)
            {
                treeView_pointsex.Nodes.Add(string.Format("Cnt#{0}, {1}pnts", c, sndvect.RawData[c].Length));
                for (int i = 0; i <= sndvect.RawData[c].Length - 1; i++) treeView_pointsex.Nodes[c].Nodes.Add(string.Format("Pnt#{0}, X: {1}|Y: {2}", i, sndvect.RawData[c][i].BasePoint.X, sndvect.RawData[c][i].BasePoint.Y));
            }
            treeView_pointsex.CollapseAll();
        }

        private void button_openvector_Click(object sender, EventArgs e)
        {
            var a = openFileDialog1.ShowDialog();
            if(a== DialogResult.OK)
            {
                sndvect = new Vector(openFileDialog1.FileName);
                sndvect.RawData = sndvect.RawData.ToList().OrderByDescending(p => p.Length).ToArray();
                loadingCircle1.Visible = true;
                label_ndresol.Text = "Resolution: " + sndvect.Resolution;
                label_2ndname.Text = "Name: " + new FileInfo(openFileDialog1.FileName).Directory.Name + "\\" + new FileInfo(openFileDialog1.FileName).Name;
                gr2 = (GraphicsPath)sndvect.GrPath.Clone();
                loadingCircle1.Active = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private Vector sndvect;

        private void button_ok_Click(object sender, EventArgs e)
        {
            Close();

        }

        int SelectedContour = -1;

        private void treeView_points_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Text.StartsWith("Cnt"))
                {
                    var a = new GraphicsPath(FillMode.Winding);
                    a.AddPolygon(Vector.PointexToPoint(dat.BaseData.RawData[e.Node.Index]));
                    SelectedContour = e.Node.Index;
                    parent.RenderEX(Color.Violet, a);
                }
                else
                {
                    SelectedContour = -1;
                    var a = new GraphicsPath(FillMode.Winding);
                    VPoint pnt = dat.BaseData.RawData[e.Node.Parent.Index][e.Node.Index].BasePoint;
                    a.AddEllipse((float)pnt.Y, (float)pnt.X, 5, 5);
                    parent.RenderEX(Color.Blue, a);
                }
            }
            catch { }
        }

        GraphicsPath gr2;

        private void button_delete_Click(object sender, EventArgs e)
        {
            if(SelectedContour == -1)
            {
                MessageBox.Show("Select Contour!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tm = dat.BaseData.RawData.ToList();
            tm.RemoveAt(SelectedContour);
            dat.BaseData.RawData = tm.ToArray();
            treeView_points.Nodes.RemoveAt(SelectedContour);
            //RefillTree();
            int li = parent.main.Items.FindIndex(p => p.Name == dat.Name);
            (parent.main.Items[li] as DocumentData).BaseData = dat.BaseData;
            parent.main.Items[li].PreRender();
            parent.Render();
            SelectedContour = -1;
            gr2 = (GraphicsPath) dat.BaseData.GrPath.Clone();
            pictureBox1.Image = Vector.ToBitmapByGrPath(dat.BaseData.Size, Color.White, Color.Black, Color.Blue, 0, gr2, dat.BaseData.RawData); 
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            int li = parent.main.Items.FindIndex(p => p.Name == dat.Name);
            (parent.main.Items[li] as DocumentData).BaseData = new Vector("Temp\\backup0.pcv");
            parent.main.Items[li].PreRender();
            parent.Render();
            Close();
        }

        delegate void FillTreeView2Delegate();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            { 
                BeginInvoke(new FillTreeView2Delegate(FillTreeView2));
            }
            catch ( Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            treeView_pointsex.Enabled = true;
            loadingCircle1.Visible = false;
            loadingCircle1.Active = false;
            pictureBox1.Image = sndvect.ToBitmapByGrPath(Color.White, Color.Black, gr2);
        }

        private int SelectedContour1 = -1;

        private void treeView_pointsex_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Text.StartsWith("Cnt"))
                {
                    var a = new GraphicsPath(FillMode.Winding);
                    SelectedContour1 = e.Node.Index;
                    pictureBox1.Image = Vector.ToBitmapByGrPath(sndvect.Size, Color.White, Color.Black, Color.Blue, SelectedContour1, gr2, sndvect.RawData);
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Width == 906) { Width = 547; return; }
            if (Width == 547) { Width = 906; return; }
        }

        private void button_flip_Click(object sender, EventArgs e)
        {
            panel_flip.Location = new Point(265, 26);
            panel_flip.Visible = !panel_flip.Visible;
            radioButton_xflip.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_resize.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button_flip_cancel_Click(object sender, EventArgs e)
        {
            panel_flip.Visible = false;
        }

        private int type_ = 0;
        private Vector res;
        private Vector data;

        private void ProceedVect(int type, params object[] parms)
        {
            loadingCircle1.Visible = true;
            loadingCircle1.Active = true;
            type_ = type;
            data = (Vector)dat.BaseData.Clone();
            backgroundWorker_proceed.RunWorkerAsync(parms);
        }

        private void button_flip_ok_Click(object sender, EventArgs e)
        {
            ProceedVect(0, radioButton_xflip.Checked == true);
            panel_flip.Visible = false;
        }

        private void backgroundWorker_proceed_DoWork(object sender, DoWorkEventArgs e)
        {
            if(type_ == 0)
            {
                if ((bool)((object[])(e.Argument))[0]) res = VectProcessor.FlipX(data);
                else res = VectProcessor.FlipY(data); 
            }else if(type_ == 1)
            {
                res = VectProcessor.SMDelete(data, ((int)((object[])(e.Argument))[0]));
            }
        }

        private void backgroundWorker_proceed_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dat.BaseData = res;
            int li = parent.main.Items.FindIndex(p => p.Name == dat.Name);
            (parent.main.Items[li] as DocumentData).BaseData = dat.BaseData;
            parent.main.Items[li].PreRender();
            parent.Render();
            RefillTree();
            
            loadingCircle1.Visible = false;
            loadingCircle1.Active = false;
        }

        private void button_resize_Click(object sender, EventArgs e)
        {
            panel_resize.Location = new Point(138, 77);
            panel_resize.Visible = true;
        }

        private void Dialog_Edit_MouseEnter(object sender, EventArgs e)
        {
            //Opacity = 1;
        }

        private void Dialog_Edit_MouseLeave(object sender, EventArgs e)
        {
            //Opacity = 0.5;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }        

        private void button_vectinfo_Click(object sender, EventArgs e)
        {

        }

        private void button_smdelete_Click(object sender, EventArgs e)
        {
            panel_sdelete.Location = new Point(264, 159);
            panel_sdelete.Visible = !panel_sdelete.Visible;
        }

        private void button_sd_ok_Click(object sender, EventArgs e)
        {
            if (textBox_sd_threshold.Text == "") textBox_sd_threshold.Text = "0";
            ProceedVect(1, int.Parse(textBox_sd_threshold.Text));
            panel_sdelete.Visible = false;
        }

        private void button_rotatec_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_rotatecenter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_sd_cancel_Click(object sender, EventArgs e)
        {
            panel_sdelete.Visible = false;
        }
    }
}
