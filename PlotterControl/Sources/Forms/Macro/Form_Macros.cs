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
using CWA.Connection;
using CWA.Printing.Macro;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_macroses : Form
    {
        public Form_macroses(string filename)
        {
            InitializeComponent();
            main = new Macro(filename);
            if (main.CreatedVersion < new Version(GlobalOptions.Ver))
            {
                var h = MessageBox.Show("File Was created in old version of the program.\nIt may cause some errors or problems. Resave now?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (h == DialogResult.Yes)
                {
                    main.CreatedVersion = new Version(GlobalOptions.Ver);
                    main.Save(filename);
                }
            }
            radioButton_elt_none.Checked = true;
            Form_macroses_Resize(null, null);
            p = new Pen(Color.Black, 2);
            p1 = new Pen(Color.Black, 1);
            p1.DashStyle = DashStyle.Dash;
            zoom = (float)trackBar_zoom.Value / 100;
            label_zoom.Text = trackBar_zoom.Value + "%";
            RenderGR();
            Render();
            UpDateListBox();
        }

        public Form_macroses()
        {
            InitializeComponent();
            main = new Macro("NoName", "NoName");
        }

        private Macro main;

        const int scrw = 1180;
        const int scrh = 720;

        Pen p, p1;

        GraphicsPath grUPPED;
        Matrix m;

        private void RenderGR()
        {
            GraphicsPath gr_ = new GraphicsPath(FillMode.Winding);
            if (main.Elems.Count == 0)
            {
                grUPPED = new GraphicsPath();
                return;
            }
            float curxpos = 0, curypos = 0;
            curxpos = main.Elems[0].MoveToPoint.X;
            curypos = main.Elems[0].MoveToPoint.Y;
            foreach (var a in main.Elems)
            {
                if (a.Type == MacroElemType.MoveRelative || a.Type == MacroElemType.MoveRelativeAndDelay)
                {
                    gr_.AddLine(curxpos, curypos, curxpos + a.MoveRelative.X, curypos + a.MoveRelative.Y);
                    curxpos += a.MoveRelative.X;
                    curypos += a.MoveRelative.Y;
                }
                if (a.Type == MacroElemType.MoveToPoint || a.Type == MacroElemType.MoveToPointAndDelay)
                {
                    gr_.AddLine(curxpos, curypos, a.MoveToPoint.X, a.MoveToPoint.Y);
                    curxpos = a.MoveToPoint.X;
                    curypos = a.MoveToPoint.Y;
                }
            }
           lastpoint = new PointF(curxpos, curypos);
           grUPPED = (GraphicsPath)gr_.Clone();
        }

        float zoom;

        private void Render()
        {
            float height = scrh * zoom;
            float wight = scrw * zoom;

            Bitmap bmp = new Bitmap((int)(scrw * zoom), (int)(scrh * zoom));
            m = new Matrix();
            m.Scale(zoom, zoom);
            var j = (GraphicsPath)grUPPED.Clone();
            j.Transform(m);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.FillRectangle(Brushes.White, new RectangleF(0, 0, wight, height));
                gr.DrawRectangle(p1, 2,2, wight-4, height-4);
                gr.DrawPath(new Pen(Color.Black, 1 * zoom), j);
            }
            Image img = pictureBox1.Image;
            pictureBox1.Image = bmp;
            if (img != null) img.Dispose();
        }

        private void UpDateListBox()
        {
            listBox_elements.Items.Clear();
            textBox_descr.Text = main.Discr;
            textBox_name.Text = main.Name;
            foreach (var a in main.Elems) listBox_elements.Items.Add(a.StringType);
        }

        private void Form_macroses_Load(object sender, EventArgs e)
        {
            radioButton_move_vetr.Checked = true;
            radioButton_elt_none.Checked = true;
            Form_macroses_Resize(null, null);
            p = new Pen(Color.Black, 2);
            p1 = new Pen(Color.Black, 1);
            p1.DashStyle = DashStyle.Dash;
            zoom = 1;
            RenderGR();
            Render();
            UpDateListBox();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            zoom = (float)trackBar_zoom.Value / 100;
            Render();
            label_zoom.Text = trackBar_zoom.Value + "%";
        }

        private void button_addel_Click(object sender, EventArgs e)
        {
            if (radioButton_elt_move.Checked)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPoint, MoveToPoint = new PointF(float.Parse(textBox_move_topointx.Text, CultureInfo.InvariantCulture), float.Parse(textBox_move_topointy.Text, CultureInfo.InvariantCulture)) });
                    else main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPointAndDelay, Delay = (float)numericUpDown_delay.Value ,MoveToPoint = new PointF(float.Parse(textBox_move_topointx.Text, CultureInfo.InvariantCulture), float.Parse(textBox_move_topointy.Text, CultureInfo.InvariantCulture)) });
                }
                if(tabControl1.SelectedIndex == 3)
                {
                    int x = pictureBox1.PointToClient(MousePosition).X;
                    int y = pictureBox1.PointToClient(MousePosition).Y;
                    float locx = (x / zoom);
                    float locy = (y / zoom);
                    if (lastpoint.X == 0&& lastpoint.Y == 0)
                    {
                        if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPoint, MoveToPoint = new PointF(locx, locy) });
                        else if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPointAndDelay, MoveToPoint = new PointF(locx, locy) , Delay = (float)numericUpDown_delay.Value});
                    } else
                    {
                        if (!radioButton_move_hor.Checked)
                        {
                            if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPoint, MoveToPoint = new PointF(lastpoint.X - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture), lastpoint.Y) });
                            else if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPointAndDelay, MoveToPoint = new PointF(lastpoint.X - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture), lastpoint.Y), Delay = (float)numericUpDown_delay.Value });
                        }
                        else
                        {
                            if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPoint, MoveToPoint = new PointF(lastpoint.X, lastpoint.Y - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture)) });
                            else if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPointAndDelay, MoveToPoint = new PointF(lastpoint.X, lastpoint.Y - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture)), Delay = (float)numericUpDown_delay.Value });
                        }
                    }   
                }
            } else if(radioButton_elt_none.Checked)
            {
                if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.None });
                else main.Elems.Add(new MacroElem() { Type = MacroElemType.Delay, Delay = (float)numericUpDown_delay.Value });
            } else if(radioButton_elt_tup.Checked)
            {
                if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.Tool, ToolMove = GlobalOptions.StepHeightConst });
                else main.Elems.Add(new MacroElem() { Type = MacroElemType.ToolAndDelay, ToolMove = GlobalOptions.StepHeightConst , Delay = (float)numericUpDown_delay.Value});
            } else if(radioButton_elt_tdown.Checked)
            {
                if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.Tool, ToolMove = - GlobalOptions.StepHeightConst });
                else main.Elems.Add(new MacroElem() { Type = MacroElemType.ToolAndDelay, ToolMove = - GlobalOptions.StepHeightConst, Delay = (float)numericUpDown_delay.Value });
            }
            RenderGR();
            Render();
            UpDateListBox();
        }

        PointF lastpoint;

        private void Form_macroses_Resize(object sender, EventArgs e)
        {
            groupBox_addel.Location = new Point(Width - groupBox_addel.Width - 30, groupBox_addel.Location.Y);
            groupBox_main.Location = new Point(Width - groupBox_main.Width - 30, groupBox_main.Location.Y);
            groupBox_zoom.Location = new Point(Width - groupBox_zoom.Width - 30, groupBox_zoom.Location.Y);
            panel1.Width = Width - groupBox_zoom.Width - 30 - 20;
            panel1.Height = Height - 80;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (radioButton_elt_move.Checked)
            {
                pictureBox1.Refresh();
            }
            //pictureBox1.Controls.Add(pictureBox2);
            string s = "GLobalX: {0}, GlobalY: {1};   LocalX: {2:0.##}, LocalY: {3:0.##};   XMM: {4:0.###}, YMM: {5:0.###};   XSteps: {6:0.##}, YSteps: {7:0.##};";
            float locx = (pictureBox1.PointToClient(MousePosition).X / zoom);
            float locy = (pictureBox1.PointToClient(MousePosition).Y / zoom);
            float xmm = locx * GlobalOptions.MaxWidthSteps / scrw;
            float ymm = locy * GlobalOptions.MaxHeightSteps / scrh;
            toolStripStatusLabel_xglobal.Text = string.Format(s, (e == null ? "-" : e.X.ToString()), (e == null ? "-" : e.X.ToString()), locx,  locy, xmm * 0.01323f,  ymm * 0.01323f, xmm, ymm);
        }

        private void Form_macroses_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1_MouseMove(null, null);
        }

        private void radioButton_elt_move_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Enabled = radioButton_elt_move.Checked;
            Render();

        }

        private void textBox_move_offangleangle_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_move_offanglelength_TextChanged(object sender, EventArgs e)
        {

        }

        bool forcepaint;
        PointF forcepaintpoint;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(forcepaint)
            {
                e.Graphics.DrawLine(Pens.Gray, lastpoint.X * zoom, lastpoint.Y * zoom, forcepaintpoint.X, forcepaintpoint.Y);
            } else if (PointToClient(MousePosition).X < Width - 240)
            {
                if (radioButton_elt_move.Checked)
                {
                    int x = pictureBox1.PointToClient(MousePosition).X;
                    int y = pictureBox1.PointToClient(MousePosition).Y;

                    float locx = (x / zoom);
                    float locy = (y / zoom);
                    if(tabControl1.SelectedIndex == 3)
                    {
                        if (lastpoint.X != 0 && lastpoint.Y != 0)
                        {
                            if (radioButton_move_vetr.Checked)
                            {
                                textBox_move_offhorvertlength.Text = (lastpoint.X - locx).ToString(CultureInfo.InvariantCulture);
                                e.Graphics.DrawLine(Pens.Gray, lastpoint.X * zoom, lastpoint.Y * zoom, x, lastpoint.Y * zoom);
                            }
                            else
                            {
                                textBox_move_offhorvertlength.Text = (lastpoint.Y - locy).ToString(CultureInfo.InvariantCulture);
                                e.Graphics.DrawLine(Pens.Gray, lastpoint.X * zoom, lastpoint.Y * zoom, lastpoint.X * zoom, y);
                            }
                        }
                    } else
                    if (tabControl1.SelectedIndex == 0)
                    {
                        textBox_move_topointx.Text = locx.ToString(CultureInfo.InvariantCulture);
                        textBox_move_topointy.Text = locy.ToString(CultureInfo.InvariantCulture);
                        if (lastpoint.X != 0 && lastpoint.Y != 0) e.Graphics.DrawLine(Pens.Gray, lastpoint.X * zoom, lastpoint.Y * zoom, x, y);
                    }
                }
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
        
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_addel_Click(null, null);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                main.Save(saveFileDialog1.FileName);
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                main = new Macro(openFileDialog1.FileName);
                if (main.CreatedVersion < new Version(GlobalOptions.Ver))
                {
                    var h = MessageBox.Show("File Was created in old version of the program.\nIt may cause some errors or problems. Resave now?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (h == DialogResult.Yes)
                    {
                        main.CreatedVersion = new Version(GlobalOptions.Ver);
                        main.Save(openFileDialog1.FileName);
                    }
                }
                radioButton_elt_none.Checked = true;
                Form_macroses_Resize(null, null);
                p = new Pen(Color.Black, 2);
                p1 = new Pen(Color.Black, 1);
                p1.DashStyle = DashStyle.Dash;
                zoom = 1;
                zoom = (float)trackBar_zoom.Value / 100;
                label_zoom.Text = trackBar_zoom.Value + "%";
                RenderGR();
                Render();
                UpDateListBox();
            }
        }

        private void toolStripStatusLabel_xglobal_Click(object sender, EventArgs e)
        {

        }

        private void listBox_elements_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void listBox_elements_MouseClick(object sender, MouseEventArgs e)
        {
            string strTip = "";
            int nIdx = listBox_elements.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < listBox_elements.Items.Count))
                strTip = listBox_elements.Items[nIdx].ToString();
            toolTip1.SetToolTip(listBox_elements, strTip);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float minx = scrw;
            float miny = scrh;
            foreach (var a in main.Elems)
            {
                if(a.Type == MacroElemType.MoveToPoint || a.Type == MacroElemType.MoveToPointAndDelay)
                {
                    minx = Math.Min(minx, a.MoveToPoint.X);
                    miny = Math.Min(miny, a.MoveToPoint.Y);
                }
            }
            for (int i = 0; i <= main.Elems.Count - 1; i++) 
            {
                if (main.Elems[i].Type == MacroElemType.MoveToPoint || main.Elems[i].Type == MacroElemType.MoveToPointAndDelay)
                {
                    main.Elems[i] = new MacroElem() { Type = main.Elems[i].Type, Delay = main.Elems[i].Delay, MoveToPoint = new PointF(main.Elems[i].MoveToPoint.X - minx, main.Elems[i].MoveToPoint.Y - miny) };
                }
            }
            RenderGR();
            Render();
            UpDateListBox();
        }

        private void button_100percent_Click_1(object sender, EventArgs e)
        {
            button_100percent_Click(null, null);
        }

        private void textBox_move_topointx_TextChanged(object sender, EventArgs e)
        {
            if (PointToClient(MousePosition).X > Width - 240)
            {
                forcepaint = true;
                float a, b;
                string s1 = textBox_move_topointx.Text;
                if (!float.TryParse(s1, out a)) MessageBox.Show("'" + s1 + "' its wrong float number input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string s2 = textBox_move_topointy.Text;
                if (!float.TryParse(s2, out b)) MessageBox.Show("'" + s2 + "' its wrong float number input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                forcepaintpoint = new PointF(a, b);
                pictureBox1.Refresh();
            }
        }

        private void textBox_move_topointy_TextChanged(object sender, EventArgs e)
        {
            if (PointToClient(MousePosition).X > Width - 240)
            {
                forcepaint = true;
                float a, b;
                string s1 = textBox_move_topointx.Text;
                if (!float.TryParse(s1, out a)) MessageBox.Show("'" + s1 + "' its wrong float number input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string s2 = textBox_move_topointy.Text;
                if (!float.TryParse(s2, out b)) MessageBox.Show("'" + s2 + "' its wrong float number input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                forcepaintpoint = new PointF(a, b);
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            forcepaint = false;
        }

        private void tabControl1_MouseEnter(object sender, EventArgs e)
        {
            forcepaint = true;
        }

        private void textBox_move_topointx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) button_addel_Click(null, null);
        }

        private void textBox_move_topointy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) button_addel_Click(null, null);
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Shift &&  PointToClient(MousePosition).X < Width - 240 && radioButton_elt_move.Checked && tabControl1.SelectedIndex == 3)
            {
                radioButton_move_vetr.Checked = !radioButton_move_vetr.Checked;
            }
        }

        private void Form_macroses_KeyDown(object sender, KeyEventArgs e)
        {
            pictureBox1_PreviewKeyDown(null, null);
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && PointToClient(MousePosition).X < Width - 240 && radioButton_elt_move.Checked && tabControl1.SelectedIndex == 3)
            {
                radioButton_move_vetr.Checked = !radioButton_move_vetr.Checked;
                radioButton_move_hor.Checked = !radioButton_move_vetr.Checked;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            main = new Macro("noname", "nodiscr");
            main.Elems = new System.Collections.Generic.List<MacroElem>();
            UpDateListBox();
            radioButton_elt_none.Checked = true;
            Form_macroses_Resize(null, null);
            p = new Pen(Color.Black, 2);
            p1 = new Pen(Color.Black, 1);
            p1.DashStyle = DashStyle.Dash;
            zoom = 1;
            zoom = (float)trackBar_zoom.Value / 100;
            label_zoom.Text = trackBar_zoom.Value + "%";
            RenderGR();
            Render();
            UpDateListBox();
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            main.Name = textBox_name.Text;
        }

        private void textBox_descr_TextChanged(object sender, EventArgs e)
        {
            main.Discr = textBox_descr.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_100percent_Click(object sender, EventArgs e)
        {
            trackBar_zoom.Value = 100;
            trackBar1_Scroll(null, null);
        }
    }
}
