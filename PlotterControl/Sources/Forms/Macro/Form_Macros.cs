/*=================================\
* PlotterControl\Form_Macros.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

using CWA;
using CWA.Printing.Macro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_Macro : Form
    {
        private const int scrw = 1180;
        private const int scrh = 720;

        private PointF LastPoint;
        private bool IsUpped;
        private bool ForcePaint;
        private PointF ForcePaintPoint;
        private Macro main;
        private Pen PenRectangle;
        private GraphicsPath[] GrUpped, GrNormal;
        private Matrix Matrix;
        private float Zoom;

        private bool IsLoad;
        private string LastFilePath;


        public Form_Macro(string filename)
        {
            InitializeComponent();
            main = new Macro(filename);
            if (main.CreatedVersion < new Version(GlobalOptions.Ver))
            {
                var h = MessageBox.Show(
                    TB.L.Phrase["Form_Macro.OlderVersionOfFile"],
                    TB.L.Phrase["Form_Macro.Warning"],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (h == DialogResult.Yes)
                {
                    main.CreatedVersion = new Version(GlobalOptions.Ver);
                    main.Save(filename);
                }
            }
            radioButton_elt_none.Checked = true;
            Form_macroses_Resize(null, null);
            PenRectangle = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Dash
            };
            Zoom = (float)trackBar_zoom.Value / 100;
            label_zoom.Text = trackBar_zoom.Value + "%";
            IsLoad = true;
            LastFilePath = filename;
            RenderGR();
            Render();
            UpDateListBox();
        }

        public Form_Macro()
        {
            InitializeComponent();
            main = new Macro(TB.L.Phrase["Form_MacroPack.NoName"], TB.L.Phrase["Form_MacroPack.NoDiscr"]);
        }

        private void RenderGR()
        {
            List<GraphicsPath> grUpped = new List<GraphicsPath>();
            List<GraphicsPath> grNormal = new List<GraphicsPath>();
            if (main.Elems.Count == 0)
            {
                GrUpped = new GraphicsPath[0];
                GrNormal = new GraphicsPath[0];
                return;
            }
            float CurXPos = 0, CurYPos = 0;
            MacroElem b;
            try
            {
              b = main.Elems.FindAll(a => a.Type == MacroElemType.MoveToPoint || a.Type == MacroElemType.MoveToPointAndDelay)[0];
            } catch(ArgumentOutOfRangeException) { return; }
            if (b == null) return;
            CurXPos = b.MoveToPoint.X;
            CurYPos = b.MoveToPoint.Y;
            bool isUpped = true;
            grUpped.Add(new GraphicsPath());
            foreach (var a in main.Elems)
            {
                if(a.Type == MacroElemType.Tool || a.Type == MacroElemType.ToolAndDelay)
                {
                    if (a.ToolMove > 50)
                    {
                        isUpped = true;
                        grUpped.Add(new GraphicsPath());
                    }
                    if (a.ToolMove < -50)
                    {
                        grNormal.Add(new GraphicsPath());
                        isUpped = false;
                    }
                }
                if (a.Type == MacroElemType.MoveRelative || a.Type == MacroElemType.MoveRelativeAndDelay)
                {
                    if (isUpped) grUpped.Last().AddLine(CurXPos, CurYPos, CurXPos + a.MoveRelative.X, CurYPos + a.MoveRelative.Y);
                    else grNormal.Last().AddLine(CurXPos, CurYPos, CurXPos + a.MoveRelative.X, CurYPos + a.MoveRelative.Y);
                    CurXPos += a.MoveRelative.X;
                    CurYPos += a.MoveRelative.Y;
                }
                if (a.Type == MacroElemType.MoveToPoint || a.Type == MacroElemType.MoveToPointAndDelay)
                {
                    if (isUpped) grUpped.Last().AddLine(CurXPos, CurYPos, a.MoveToPoint.X, a.MoveToPoint.Y);
                    else grNormal.Last().AddLine(CurXPos, CurYPos, a.MoveToPoint.X, a.MoveToPoint.Y);
                    CurXPos = a.MoveToPoint.X;
                    CurYPos = a.MoveToPoint.Y;
                }
            }
            LastPoint = new PointF(CurXPos, CurYPos);
            GrUpped = grUpped.ToArray();
            GrNormal = grNormal.ToArray();
        }

        private Bitmap MacroBmp;

        private void Render()
        {
            float height = scrh * Zoom;
            float wight = scrw * Zoom;
            Bitmap bmp = new Bitmap((int)(scrw * Zoom), (int)(scrh * Zoom));
            Matrix = new Matrix();
            Matrix.Scale(Zoom, Zoom);
            List<GraphicsPath> grUp = new List<GraphicsPath>();
            GrUpped.ToList().ForEach(p=> grUp.Add((GraphicsPath)p.Clone()));
            List<GraphicsPath> grNo = new List<GraphicsPath>();
            GrNormal.ToList().ForEach(p => grNo.Add((GraphicsPath)p.Clone()));
            foreach (var item in grUp) item.Transform(Matrix);
            foreach (var item in grNo) item.Transform(Matrix);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.FillRectangle(Brushes.White, new RectangleF(0, 0, wight, height));
                if(MacroBmp != null)
                   
                    gr.DrawImage(MacroBmp, 0, 0,
                        main.PicSize.Width * Zoom / .013f,
                        main.PicSize.Height * Zoom  / .013f);
                gr.DrawRectangle(PenRectangle, 2, 2, wight - 4, height - 4);
                foreach (var item in grUp) gr.DrawPath(new Pen(Color.Gray, 1 * Zoom) { DashStyle = DashStyle.Dash }, item);
                foreach (var item in grNo) gr.DrawPath(new Pen(Color.Black, 1 * Zoom), item);
            }
            Image img = pictureBox1.Image;
            pictureBox1.Image = bmp;
            if (img != null) img.Dispose();
        }

        private void UpDateListBox()
        {
            if (IsLoad) toolStripMenuItem_saveas.Enabled = true;
            Text = string.Format(TB.L.Phrase["Form_Macro.Macro"], main.Name);
            listBox_elements.Items.Clear();
            toolStripTextBox_discr.Text = main.Discr;
            toolStripTextBox_name.Text = main.Name;
            foreach (var a in main.Elems) listBox_elements.Items.Add(a.StringType);
            label_elements.Text = string.Format(TB.L.Phrase["Form_MacroPack.Elements"], listBox_elements.Items.Count);
        }

        private void Form_macroses_Load(object sender, EventArgs e)
        {
            radioButton_move_vetr.Checked = true;
            radioButton_elt_none.Checked = true;
            Form_macroses_Resize(null, null);
            PenRectangle = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Dash
            };
            Zoom = 1;
            RenderGR();
            Render();
            UpDateListBox();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Zoom = (float)trackBar_zoom.Value / 100;
            Render();
            label_zoom.Text = trackBar_zoom.Value + "%";
        }

        private void button_addel_Click(object sender, EventArgs e)
        {
            IsUpped = CheckIsUpped();
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
                    float locx = (x / Zoom);
                    float locy = (y / Zoom);
                    if (LastPoint.X == 0&& LastPoint.Y == 0)
                    {
                        if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPoint, MoveToPoint = new PointF(locx, locy) });
                        else if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPointAndDelay, MoveToPoint = new PointF(locx, locy) , Delay = (float)numericUpDown_delay.Value});
                    } else
                    {
                        if (!radioButton_move_hor.Checked)
                        {
                            if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPoint, MoveToPoint = new PointF(LastPoint.X - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture), LastPoint.Y) });
                            else if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPointAndDelay, MoveToPoint = new PointF(LastPoint.X - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture), LastPoint.Y), Delay = (float)numericUpDown_delay.Value });
                        }
                        else
                        {
                            if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPoint, MoveToPoint = new PointF(LastPoint.X, LastPoint.Y - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture)) });
                            else if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.MoveToPointAndDelay, MoveToPoint = new PointF(LastPoint.X, LastPoint.Y - float.Parse(textBox_move_offhorvertlength.Text, CultureInfo.InvariantCulture)), Delay = (float)numericUpDown_delay.Value });
                        }
                    }   
                }
            } else if(radioButton_elt_none.Checked)
            {
                if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.None });
                else main.Elems.Add(new MacroElem() { Type = MacroElemType.Delay, Delay = (float)numericUpDown_delay.Value });
            } else if(radioButton_elt_tup.Checked)
            {
                if(IsUpped)
                {
                    MessageBox.Show(
                        TB.L.Phrase["Form_Macro.AlreadyUpped"],
                        TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IsUpped = false;
                if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.Tool, ToolMove = GlobalOptions.StepHeightConst });
                else main.Elems.Add(new MacroElem() { Type = MacroElemType.ToolAndDelay, ToolMove = GlobalOptions.StepHeightConst , Delay = (float)numericUpDown_delay.Value});
            } else if(radioButton_elt_tdown.Checked)
            {
                if(!IsUpped)
                {
                    MessageBox.Show(
                        TB.L.Phrase["Form_Macro.AlreadyDown"],
                        TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IsUpped = true;
                if (numericUpDown_delay.Value == 0) main.Elems.Add(new MacroElem() { Type = MacroElemType.Tool, ToolMove = - GlobalOptions.StepHeightConst });
                else main.Elems.Add(new MacroElem() { Type = MacroElemType.ToolAndDelay, ToolMove = - GlobalOptions.StepHeightConst, Delay = (float)numericUpDown_delay.Value });
            }
            RenderGR();
            Render();
            UpDateListBox();
        }

        private bool CheckIsUpped()
        {
            bool isUpped = true;
            foreach (var a in main.Elems)
            {
                if (a.Type == MacroElemType.Tool || a.Type == MacroElemType.ToolAndDelay)
                {
                    if (a.ToolMove > 50) isUpped = true;
                    if (a.ToolMove < -50) isUpped = false;
                }
            }
            return isUpped;
        }

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
            string s = TB.L.Phrase["Form_Macro.Status"];
            float locx = (pictureBox1.PointToClient(MousePosition).X / Zoom);
            float locy = (pictureBox1.PointToClient(MousePosition).Y / Zoom);
            float xmm = locx * GlobalOptions.MaxHeightSteps / scrw;
            float ymm = locy * GlobalOptions.MaxWidthSteps / scrh;
            toolStripStatusLabel_xglobal.Text = string.Format(s, (e == null ? "-" : e.X.ToString()), (e == null ? "-" : e.Y.ToString()), locx,  locy, xmm * 0.01323f,  ymm * 0.01323f, xmm, ymm);
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(ForcePaint)
            {
                e.Graphics.DrawLine(Pens.Gray, LastPoint.X * Zoom, LastPoint.Y * Zoom, ForcePaintPoint.X, ForcePaintPoint.Y);
            } else if (PointToClient(MousePosition).X < Width - 240)
            {
                if (radioButton_elt_move.Checked)
                {
                    int x = pictureBox1.PointToClient(MousePosition).X;
                    int y = pictureBox1.PointToClient(MousePosition).Y;
                    float locx = (x / Zoom);
                    float locy = (y / Zoom);
                    if(tabControl1.SelectedIndex == 3)
                    {
                        if (LastPoint.X != 0 && LastPoint.Y != 0)
                        {
                            if (radioButton_move_vetr.Checked)
                            {
                                textBox_move_offhorvertlength.Text = (LastPoint.X - locx).ToString(CultureInfo.InvariantCulture);
                                e.Graphics.DrawLine(Pens.Gray, LastPoint.X * Zoom, LastPoint.Y * Zoom, x, LastPoint.Y * Zoom);
                            }
                            else
                            {
                                textBox_move_offhorvertlength.Text = (LastPoint.Y - locy).ToString(CultureInfo.InvariantCulture);
                                e.Graphics.DrawLine(Pens.Gray, LastPoint.X * Zoom, LastPoint.Y * Zoom, LastPoint.X * Zoom, y);
                            }
                        }
                    } else
                    if (tabControl1.SelectedIndex == 0)
                    {
                        textBox_move_topointx.Text = locx.ToString(CultureInfo.InvariantCulture);
                        textBox_move_topointy.Text = locy.ToString(CultureInfo.InvariantCulture);
                        if (LastPoint.X != 0 && LastPoint.Y != 0)
                        {
                            if(IsUpped) e.Graphics.DrawLine(new Pen(Color.Blue, 1) { DashStyle = DashStyle.Dash }, LastPoint.X * Zoom, LastPoint.Y * Zoom, x, y);
                            else e.Graphics.DrawLine(new Pen(Color.Blue, 1), LastPoint.X * Zoom, LastPoint.Y * Zoom, x, y);
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button_addel_Click(null, null);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if(IsLoad)
            {
                main.Save(LastFilePath);
            } else
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
                    var h = MessageBox.Show(
                        TB.L.Phrase["Form_Macro.OlderVersionOfFile"],
                        TB.L.Phrase["Form_Macro.Warning"],
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (h == DialogResult.Yes)
                    {
                        main.CreatedVersion = new Version(GlobalOptions.Ver);
                        main.Save(openFileDialog1.FileName);
                    }
                }
                radioButton_elt_none.Checked = true;
                Form_macroses_Resize(null, null);
                MacroBmp = new Bitmap(main.PicFileName);
                PenRectangle = new Pen(Color.Black, 1)
                {
                    DashStyle = DashStyle.Dash
                };
                Zoom = 1;
                IsLoad = true;
                LastFilePath = openFileDialog1.FileName;
                Zoom = (float)trackBar_zoom.Value / 100;
                label_zoom.Text = trackBar_zoom.Value + "%";
                RenderGR();
                Render();
                UpDateListBox();
            }
        }

        private void listBox_elements_MouseClick(object sender, MouseEventArgs e)
        {
            string strTip = "";
            int nIdx = listBox_elements.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < listBox_elements.Items.Count))
                strTip = listBox_elements.Items[nIdx].ToString();
            toolTip1.SetToolTip(listBox_elements, strTip);
        }

        private void ToCorner()
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
                ForcePaint = true;
                float a, b;
                string s1 = textBox_move_topointx.Text;
                if (!float.TryParse(s1, out a)) MessageBox.Show(
                    "'" + s1 + TB.L.Phrase["Connection.WrongFloatInput"], 
                    TB.L.Phrase["Connection.Error"], 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                string s2 = textBox_move_topointy.Text;
                if (!float.TryParse(s2, out b)) MessageBox.Show(
                    "'" + s2 + TB.L.Phrase["Connection.WrongFloatInput"],
                    TB.L.Phrase["Connection.Error"], 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ForcePaintPoint = new PointF(a, b);
                pictureBox1.Refresh();
            }
        }

        private void textBox_move_topointy_TextChanged(object sender, EventArgs e)
        {
            if (PointToClient(MousePosition).X > Width - 240)
            {
                ForcePaint = true;
                float a, b;
                string s1 = textBox_move_topointx.Text;
                if (!float.TryParse(s1, out a)) MessageBox.Show(
                    "'" + s1 + TB.L.Phrase["Connection.WrongFloatInput"],
                    TB.L.Phrase["Connection.Error"],
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                string s2 = textBox_move_topointy.Text;
                if (!float.TryParse(s2, out b)) MessageBox.Show(
                    "'" + s2 + TB.L.Phrase["Connection.WrongFloatInput"],
                    TB.L.Phrase["Connection.Error"],
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ForcePaintPoint = new PointF(a, b);
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ForcePaint = false;
        }

        private void tabControl1_MouseEnter(object sender, EventArgs e)
        {
            ForcePaint = true;
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
                radioButton_move_vetr.Checked = !radioButton_move_vetr.Checked;
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
            main.Elems = new List<MacroElem>();
            UpDateListBox();
            radioButton_elt_none.Checked = true;
            Form_macroses_Resize(null, null);
            PenRectangle = new Pen(Color.Black, 1);
            PenRectangle.DashStyle = DashStyle.Dash;
            Zoom = 1;
            Zoom = (float)trackBar_zoom.Value / 100;
            label_zoom.Text = trackBar_zoom.Value + "%";
            RenderGR();
            Render();
            UpDateListBox();
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            main.Name = toolStripTextBox_name.Text;
            Text = string.Format(TB.L.Phrase["Form_Macro.Macro"], main.Name);
        }

        private void textBox_descr_TextChanged(object sender, EventArgs e)
        {
            main.Discr = toolStripTextBox_discr.Text;
            Text = string.Format(TB.L.Phrase["Form_Macro.Macro"], main.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem_saveas_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                main.Save(saveFileDialog1.FileName);
            }
        }

        private void toolStripMenuItem_tocorner_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_addimg_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(main.PicFileName))
            {
                var f = FormTranslator.Translate(new Form_Dialog_MacroAddImage());
                if (f.ShowDialog() == DialogResult.OK)
                {
                    main.PicFileName = f.Path;
                    main.PicSize = new SizeF(f.XSize, f.YSize);
                    MacroBmp = new Bitmap(f.Path);
                };
            } else
            {
                var f = FormTranslator.Translate(new Form_Dialog_MacroAddImage()
                {
                    Path = main.PicFileName,
                    XSize = main.PicSize.Width,
                    YSize = main.PicSize.Height
                });
                if (f.ShowDialog() == DialogResult.OK)
                {
                    main.PicFileName = f.Path;
                    main.PicSize = new SizeF(f.XSize, f.YSize);
                    MacroBmp = new Bitmap(f.Path);
                };
            }
        }

        private void button_100percent_Click(object sender, EventArgs e)
        {
            trackBar_zoom.Value = 100;
            trackBar1_Scroll(null, null);
        }
    }
}
