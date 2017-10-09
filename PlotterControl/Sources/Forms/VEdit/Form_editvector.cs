/*=================================\
* PlotterControl\Form_editvector.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.10.2017 20:19
* Last Edited: 06.10.2017 20:19:53
*=================================*/

using CWA_Resources.Properties;
using CWA;
using CWA.Vectors;
using CWA.Vectors.Document;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{

    public partial class Form_EditVector : Form
    {
        char[] num = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',' ,'.'};
        private int tc;
        private Bitmap samplecolorprobe;
        private int datacount;
        private Color remember_text_color;
        private string remember_text_name;
        private float remember_text_angle;
        private bool cntr_pressed;
        private Point scrpoint;
        public bool globalsel;
        private Point realpos;
        private Point pos;
        public float zoom;
        public Document main;
        private float SampleX, SampleY, SampleW, SampleH;
        private string l1, l2, l3, l4;
        private Bitmap prbitmap;
        int mode;
        Point lp;

        public Form_EditVector()
        {
            InitializeComponent();
        }

        public Form_EditVector(string Filename)
        {
            InitializeComponent();
            main = Document.Load(Filename);
            if (main == null)
            {
                return;
            }
            if (main.CreatedVersion < new Version(GlobalOptions.Ver))
            {
                var h = MessageBox.Show(TB.L.Message["VectorEditor.OldPCVdocVersion"], TB.L.Phrase["VectorEditor.Word.Warning"], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (h == DialogResult.Yes)
                {
                    main.CreatedVersion = new Version(GlobalOptions.Ver);
                    main.Save(Filename);
                }
            }
            labelHint.Visible = false;
            for (int i = 0; i <= main.Items.Count - 1; i++) main.Items[i].PreRender();
            UpdateListbox();
            Render();
            panel_zoom.Enabled = true;
            panel_newdoc.Visible = false;
            toolStripButton_save.Enabled = true;
            button_dideprop.Enabled = true;
            button_dideprop.Size = new Size(63, 23);
            panel_properties.Visible = true;
            button_dideprop.Text = TB.L.Phrase["VectorEditor.Word.Hide"];
            button_hidezoom.Enabled = true;
            Form_editvector_SizeChanged(null, null);
            toolStripStatusLabel1.Text = TB.L.Phrase["VectorEditor.Word.Name"] + ": " + main.Name;
            toolStripStatusLabel3.Text = string.Format("| "+ TB.L.Phrase["VectorEditor.Word.Resolution"] + ": {0}x{1}", main.Size.Width, main.Size.Height);
            Form_editvector_SizeChanged(null, null);
            panel_zoom.Visible = true;
            statusStrip1.Visible = true;
            button_dideprop.Visible = true;
            button_hidezoom.Visible = true;
            toolStripButton_docopts_.Enabled = true;
            toolStripButton_render_.Enabled = true;
            toolStripButton_save_.Enabled = true;
            toolStripSplitButton_additems.Enabled = true;
            toolStripStatusLabel_fileversion.Text = "| "+ TB.L.Phrase["VectorEditor.UsedDocumentVersion"] + ": " + main.CreatedVersion.ToString();
            trackBar1_Scroll(null, null);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_zoom.Text = (trackBar_zoom.Value - 50).ToString() + '%';
            zoom = (trackBar_zoom.Value - 50f) / 100f;
            pos = new Point((int)(realpos.X * zoom), (int)(realpos.Y * zoom));
            pictureBox2.Location = pos;
            if (!globalsel) Render();
            else RenderEX(Color.Magenta, (GraphicsPath)main.Items[listBox1.SelectedIndex].GrPath.Clone());
            RenderSample();
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (new Bitmap(imgToResize, size));
        }

        private void RenderSample()
        {
            switch (mode)
            {
                case 0:
                    RenderSampleText();
                    break;
                case 1:
                    RenderSampleData();
                    break;
            }
        }

        private void RenderSampleData()
        {
            if (main != null)
            {
                Pen p = new Pen(Color.Black, 1);
                p.DashStyle = DashStyle.Dash;
                Rectangle rec = new Rectangle(0, 0, (int)((SampleW - 1) * zoom), (int)((SampleH - 1) * zoom));
                pictureBox2.Size = new Size((int)(SampleW * zoom), (int)(SampleH * zoom));
                Bitmap bmp = new Bitmap((int)(SampleW * zoom) + 1, (int)(SampleH * zoom) + 1);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.DrawImage(prbitmap, rec);
                    gr.DrawRectangle(p, rec);
                }
                Image img = pictureBox2.Image;
                pictureBox2.Image = bmp;
                if (img != null) img.Dispose();
            }
        }

        private void RenderSampleText()
        {
            if (main != null)
            {
                string text = richTextBox_texteditor_text.Text;
                Pen p = new Pen(Color.Black, 1);
                p.DashStyle = DashStyle.Dash;
                Rectangle rec = new Rectangle(0, 0, (int)((SampleW - 1) * zoom), (int)((SampleH - 1) * zoom));
                Bitmap bmp = new Bitmap((int)(SampleW * zoom) + 1, (int)(SampleH * zoom) + 1);
                Font ff = fontDialog1.Font;
                Font f = new Font(ff.FontFamily, ff.Size * zoom, FontStyle.Regular, GraphicsUnit.Pixel, ff.GdiCharSet, ff.GdiVerticalFont);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.DrawString(text, f,  Brushes.Black, new PointF(0, 0));
                    gr.DrawRectangle(p, rec);
                }
                //panel2.BackColor = Color.FromArgb(25, Color);
                pictureBox2.Size = new Size((int)(SampleW * zoom), (int)(SampleH * zoom));
                Image img = pictureBox2.Image;
                pictureBox2.Image = bmp;
                if (img != null) img.Dispose();
            }
        }

        public void RenderEX(Color c, GraphicsPath gr)
        {
            Bitmap im;
            main.RenderEX(zoom, out im, c, gr);
            Image img = pictureBox1.Image;
            pictureBox1.Image = im;
            if (img != null) img.Dispose();
        }

        public void Render()
        {
            Bitmap im;
            main.Render(zoom, out im);
            Image img = pictureBox1.Image;
            pictureBox1.Image = im;
            if (img != null) img.Dispose();
        }

        private void Form_editvector_Load(object sender, EventArgs e)
        {
            //toolStripButton_theme.PerformClick();
            comboBox_bordstyle.Items.AddRange(Enum.GetNames(typeof(DocumentBorderStyle)));
            MouseWheel += new MouseEventHandler(Form4_MouseWheel);
            pictureBox1.MouseWheel += new MouseEventHandler(Form4_MouseWheel);
            zoom = 1;
            SampleW = 200;
            SampleH = 150;
            textBox_text_height.Text = "150";
            textBox_text_posy.Text = "0";
            textBox_text_xpos.Text = "0";
            textBox_text_width.Text = "200";
            panel4.AutoScroll = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.BackColor = Color.Transparent;
            label_zoom.Text = (trackBar_zoom.Value - 50).ToString() + '%';
            zoom = (trackBar_zoom.Value - 50) / 100;
            radioButton_newdoc_usesize.Checked = true;
            button_dideprop.Size = new Size(27, 30);
            button_dideprop.Text = "";
            Form_editvector_SizeChanged(null, null);
        }

        private void Form4_MouseWheel(object sender, MouseEventArgs e)
        {
            if(cntr_pressed)
            {
                trackBar_zoom.Value += e.Delta/50;
                trackBar1_Scroll(null, null);
                panel4.AutoScrollPosition = scrpoint;
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 0;
            RenderSample();
            pictureBox2.Visible = true;
            panel_text.Visible = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            lp = new Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point temp = Control.MousePosition;
                Point rs = new Point(lp.X - temp.X, lp.Y - temp.Y);
                int x = pictureBox2.Location.X - rs.X;
                int y = pictureBox2.Location.Y - rs.Y;
                //int maxx = pictureBox1.Image.Width;
                //int maxy = pictureBox1.Image.Height;
                if(x < 0) x = 0;
                //else if(x + (int)SampleW > maxx) x = maxx - (int)SampleW;
                if (y < 0) y = 0;
                //else if (y + (int)SampleH > maxy) y = maxy - (int)SampleH;
                pictureBox2.Location = new Point(x,y);
                realpos = pictureBox2.Location;
                if (mode == 0)
                {
                    textBox_text_xpos.Text = (pictureBox2.Location.X / zoom).ToString(CultureInfo.InvariantCulture);
                    textBox_text_posy.Text = (pictureBox2.Location.Y / zoom).ToString(CultureInfo.InvariantCulture);
                } else
                if( mode == 1)
                {
                    textBox_loaddata_x.Text = (pictureBox2.Location.X / zoom).ToString(CultureInfo.InvariantCulture);
                    textBox_loaddata_y.Text = (pictureBox2.Location.Y / zoom).ToString(CultureInfo.InvariantCulture);
                }
                lp = temp;
            }
            if(mode == 1)
            {
                toolStripStatusLabel4.Text = string.Format("| X: {0:0.##}", e.X / zoom);
                toolStripStatusLabel5.Text = string.Format("| Y: {0:0.##}", e.Y / zoom);
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lp = MousePosition;
            }
        }

        private void button_hidezoom_Click(object sender, EventArgs e)
        {
            if (panel_zoom.Visible)
            {
                panel_zoom.Visible = false;
                button_hidezoom.Size = new Size(27, 30);
                button_hidezoom.Text = "";
            }
            else
            {
                panel_zoom.Visible = true;
                button_hidezoom.Size = new Size(83, 30);
                button_hidezoom.Text = TB.L.Phrase["VectorEditor.Word.Hide"];
            }
            Form_editvector_SizeChanged(null, null);
        }


        private void textBox_text_xpos_TextChanged(object sender, EventArgs e)
        {
            bool err = false;
            foreach (char a in textBox_text_xpos.Text)
            {
                if (!num.Contains(a))
                {
                    MessageBox.Show(string.Format(TB.L.Error["VectorEditor.FloatInputError"], a), TB.L.Phrase["VectorEditor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_text_xpos.Text = l1;
                    err = true;
                    return;
                }
            }
            if(!err)
            {
                l1 = textBox_text_xpos.Text;
                try { SampleX = float.Parse(l1, CultureInfo.InvariantCulture); }
                catch { SampleX = 0; }
                if (mode == 0) RenderSampleText();
                //pictureBox2.Location = new Point((int)(SampleX * zoom), (int)(SampleY * zoom));
            }
        }

        private void textBox_text_width_TextChanged(object sender, EventArgs e)
        {
            bool err = false;
            foreach (char a in textBox_text_width.Text)
            {
                if (!num.Contains(a))
                {
                    MessageBox.Show(string.Format(TB.L.Error["VectorEditor.FloatInputError"], a), TB.L.Phrase["VectorEditor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_text_width.Text = l3;
                    err = true;
                    return;
                }
            }
            if (!err)
            {
                l3 = textBox_text_width.Text;
                try { SampleW = float.Parse(l3, CultureInfo.InvariantCulture); }
                catch { SampleW = 1; }
                if (SampleW == 0) SampleW = 1;
                if(mode==0) RenderSampleText();
            }
        }

        private void textBox_text_posy_TextChanged(object sender, EventArgs e)
        {
            bool err = false;
            foreach (char a in textBox_text_posy.Text)
            {
                if (!num.Contains(a))
                {
                    MessageBox.Show(string.Format(TB.L.Error["VectorEditor.FloatInputError"], a), TB.L.Phrase["VectorEditor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_text_posy.Text = l2;
                    err = true;
                    return;
                }
            }
            if (!err)
            {
                l2 = textBox_text_posy.Text;
                try { SampleY = float.Parse(l2, CultureInfo.InvariantCulture); }
                catch { SampleY = 0; }
                if (mode == 0)  RenderSampleText();
                //pictureBox2.Location = new Point((int)(SampleX * zoom), (int)(SampleY  * zoom));
            }
        }

        private void textBox_text_height_TextChanged(object sender, EventArgs e)
        {
            bool err = false;
            foreach (char a in textBox_text_height.Text)
            {
                if (!num.Contains(a))
                {
                    MessageBox.Show(string.Format(TB.L.Error["VectorEditor.FloatInputError"], a), TB.L.Phrase["VectorEditor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_text_height.Text = l4;
                    err = true;
                    return;
                }
            }
            if (!err)
            {
                l4 = textBox_text_height.Text;
                try { SampleH = float.Parse(l4, CultureInfo.InvariantCulture); }
                catch { SampleH = 1; }
                if (SampleH == 0) SampleH = 1;
                if (mode == 0) RenderSampleText();
            }
        }

        private void button_break_Click(object sender, EventArgs e)
        {
            SampleW = 200;
            SampleH = 150;
            textBox_text_height.Text = "150";
            textBox_text_posy.Text = "0";
            textBox_text_xpos.Text = "0";
            textBox_text_width.Text = "200";
            pictureBox2.Visible = false;
            panel_text.ResetText();
            panel_text.Visible = false;
            pictureBox2.Location = new Point(3, 3);
        }

        private void toolStripButton_new_Click(object sender, EventArgs e)
        {
            panel_newdoc.Visible = true;
            labelHint.Visible = false;
        }

        private void radioButton_newdoc_usesize_CheckedChanged(object sender, EventArgs e)
        {
            bool a = radioButton_newdoc_usesize.Checked;
            textBox_newdoc_height.Enabled = a;
            textBox_newdoc_width.Enabled = a;
            label_newdoc_height.Enabled = a;
            label_newdoc_width.Enabled = a;
            button_newdoc_brouse.Enabled = !a;
            label_newdoc_path.Enabled = !a;
        }

        private void button_newdoc_cancel_Click(object sender, EventArgs e)
        {
            if(main == null) labelHint.Visible = true;
            panel_newdoc.Visible = false;
        }

        private void button_newdoc_ok_Click(object sender, EventArgs e)
        {
            globalsel = false;
            if(textBox_newdoc_name.Text.Trim() == "")
            {
                MessageBox.Show(TB.L.Message["VectorEditor.EnterTheNameOfDocument"], TB.L.Phrase["VectorEditor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton_newdoc_usesize.Checked)
            {
                int width, height;
                if (!int.TryParse(textBox_newdoc_width.Text, out width))
                {
                    MessageBox.Show(TB.L.Error["VectorEditor.WrongWidthValue"], TB.L.Phrase["VectorEditor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(textBox_newdoc_height.Text, out height))
                {
                    MessageBox.Show(TB.L.Error["VectorEditor.WrongHeightValue"], TB.L.Phrase["VectorEditor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                main = new Document(new SizeF(width, height));
                main.Name = textBox_newdoc_name.Text;
                Render();
                panel_zoom.Enabled = true;
                panel_newdoc.Visible = false;
                toolStripButton_save.Enabled = true;
                button_dideprop.Enabled = true;
                button_dideprop.Size = new Size(83, 30);
                panel_properties.Visible = true;
                button_dideprop.Text = TB.L.Phrase["VectorEditor.Word.Hide"];
                button_hidezoom.Enabled = true;
            }
            else
            {
                tmpv = new Vector(path);
                main = new Document(new SizeF((float)tmpv.Header.Width,( float) tmpv.Header.Height));
                main.Name = textBox_newdoc_name.Text;
                panel_zoom.Enabled = true;
                panel_newdoc.Visible = false;
                toolStripButton_save.Enabled = true;
                button_dideprop.Enabled = true;
                button_dideprop.Size = new Size(83, 30);
                panel_properties.Visible = true;
                button_dideprop.Text = TB.L.Phrase["VectorEditor.Word.Hide"];
                button_hidezoom.Enabled = true;
                prbitmap = tmpv.ToBitmap(Color.White, Color.Black);
                pictureBox_loaddata_preview.Image = prbitmap;
                panel_dataload.Visible = true;
                pictureBox2.Visible = true;
                mode = 1;
                label_loaddata_path.Text = TB.L.Phrase["VectorEditor.Word.Path"] + ':' + new FileInfo(openFileDialog1.FileName).Directory.Name + '\\' + new FileInfo(openFileDialog1.FileName).Name;
                label_loaddata_resolution.Text = string.Format("{2}: {0}x{1}", tmpv.Header.Width, tmpv.Header.Height, TB.L.Phrase["VectorEditor.Word.Resolution"]);
                label_loaddata_cont.Text = string.Format("{2}: {0}, {3}: {1}", tmpv.RawData.Length, tmpv.Points, TB.L.Phrase["VectorEditor.Word.Contours"], TB.L.Phrase["VectorEditor.Word.Points"]);
                SampleH = (int)tmpv.Header.Height;
                SampleW = (int)tmpv.Header.Width;
                RenderSampleData();
                Render();
            }
            button_hidezoom.Visible = true;
            button_dideprop.Visible = true;
            listBox1.Items.Clear();
            Form_editvector_SizeChanged(null, null);
            toolStripStatusLabel1.Text = TB.L.Phrase["VectorEditor.Word.Name"] + ": " + main.Name;
            toolStripStatusLabel3.Text = string.Format("| {2}: {0}x{1}", main.Size.Width, main.Size.Height, TB.L.Phrase["VectorEditor.Word.Resolution"]);
            toolStripButton_docopts_.Enabled = true;
            toolStripButton_render_.Enabled = true;
            toolStripButton_save_.Enabled = true;
            panel_zoom.Visible = true;
            statusStrip1.Visible = true;
            toolStripSplitButton_additems.Enabled = true;
            toolStripStatusLabel_fileversion.Text = "| "+ TB.L.Phrase["VectorEditor.UsedDocumentVersion"] + ": " + main.CreatedVersion.ToString();
        }


        private void button_done_Click(object sender, EventArgs e)
        {
            if (remember_text_name != "")
            {
                panel_properties.Enabled = true;
                main.AddItem(new DocumentText(new PointF(float.Parse(textBox_text_xpos.Text, CultureInfo.InvariantCulture),
                                              float.Parse(textBox_text_posy.Text, CultureInfo.InvariantCulture)),
                                              new SizeF(float.Parse(textBox_text_width.Text, CultureInfo.InvariantCulture), float.Parse(textBox_text_height.Text, CultureInfo.InvariantCulture)), 
                                              richTextBox_texteditor_text.Text, fontDialog1.Font), 
                              remember_text_name);
                button_break_Click(null, null);
                UpdateListbox();
                main.Items[main.Items.Count - 1].DispColor = remember_text_color;
                main.Items[main.Items.Count - 1].Angle = remember_text_angle;
                main.Items[main.Items.Count - 1].PreRender();
                Matrix m = new Matrix();
                m.RotateAt(remember_text_angle, new PointF(main.Items[main.Items.Count - 1].Size.Width / 2 + main.Items[main.Items.Count - 1].Position.X, main.Items[main.Items.Count - 1].Size.Height / 2 + main.Items[main.Items.Count - 1].Position.Y));
                main.Items[main.Items.Count - 1].GrPath.Transform(m);
                Render();
                globalsel = false;
                remember_text_name = "";
                remember_text_angle = 0;
            }
            else
            {
                main.AddItem(new DocumentText(new PointF(float.Parse(textBox_text_xpos.Text, CultureInfo.InvariantCulture),
                    float.Parse(textBox_text_posy.Text, CultureInfo.InvariantCulture)), 
                    new SizeF(float.Parse(textBox_text_width.Text, CultureInfo.InvariantCulture), float.Parse(textBox_text_height.Text, CultureInfo.InvariantCulture)),
                    richTextBox_texteditor_text.Text, fontDialog1.Font),
                    "text0" + (++tc).ToString());
                button_break_Click(null, null);
                UpdateListbox();
                main.Items[main.Items.Count - 1].PreRender();
                Render();
            }
        }

        private void button_dideprop_Click(object sender, EventArgs e)
        {
            panel_properties.Visible = !panel_properties.Visible;
            if(panel_properties.Visible)
            {
                button_dideprop.Location = new Point(Width - button_dideprop.Width - 27 - 83 + 15, button_dideprop.Location.Y);
                button_dideprop.Size = new Size(83, 30);
                button_dideprop.Text = TB.L.Phrase["VectorEditor.Word.Hide"];
            }
            else
            {
                button_dideprop.Location = new Point(Width - button_dideprop.Width + 15, button_dideprop.Location.Y);
                button_dideprop.Size = new Size(27, 30);
                button_dideprop.Text = "";
            }
        }

        private void UpdateListbox()
        {
            label_obcount.Text = TB.L.Phrase["VectorEditor.Word.Objects"] + ": " + main.Items.Count;
            listBox1.Items.Clear();
            foreach(var a in main.Items)
            {
                listBox1.Items.Add(string.Format("{0} - {1}", a.Type, a.Name));
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DocumentItem selitem = main.Items[listBox1.SelectedIndex];
                samplecolorprobe = new Bitmap(55, 23);
                Rectangle rec = new Rectangle(0, 0, 55, 23);
                var b = new SolidBrush(selitem.DispColor);
                using (Graphics gr = Graphics.FromImage(samplecolorprobe))
                {
                    gr.FillRectangle(b, rec);
                }
                pictureBox_drawcolor.Image = samplecolorprobe;
                label_type.Text = TB.L.Phrase["VectorEditor.Word.Type"] + ": " + selitem.Type.ToString();
                if (selitem.Type != DocumentItemType.Text)
                {

                } else
                {
                    label_subtype.Text = TB.L.Phrase["VectorEditor.Word.SubType"] + ": " + TB.L.Phrase["VectorEditor.Word.None"];
                }
                textBox_editname.Text = selitem.Name;
                RenderEX(Color.Magenta, (GraphicsPath) main.Items[listBox1.SelectedIndex].GrPath.Clone());
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form_VectorMaster().Show();
        }

        private Vector tmpv;

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = openFileDialog1.ShowDialog();
            if (a == DialogResult.OK)
            {
                tmpv = new Vector(openFileDialog1.FileName);
                prbitmap = tmpv.ToBitmap(Color.White, Color.Black);

                pictureBox_loaddata_preview.Image = prbitmap;
                panel_dataload.Visible = true;
                pictureBox2.Visible = true;
                mode = 1;
                label_loaddata_path.Text = TB.L.Phrase["VectorEditor.Word.Path"] + ": " + new FileInfo(openFileDialog1.FileName).Directory.Name + '\\' + new FileInfo(openFileDialog1.FileName).Name;
                label_loaddata_resolution.Text = string.Format("{2}: {0}x{1}", tmpv.Header.Width, tmpv.Header.Height, TB.L.Phrase["VectorEditor.Word.Resolution"]);
                label_loaddata_cont.Text = string.Format("{2}: {0}, {3}: {1}", tmpv.RawData.Length, tmpv.Points, TB.L.Phrase["VectorEditor.Word.Contours"], TB.L.Phrase["VectorEditor.Word.Points"]);
                SampleH = (float)tmpv.Header.Height;
                SampleW = (float)tmpv.Header.Width;
                RenderSampleData();
            }
        }


        private void button_loaddata_ok_Click(object sender, EventArgs e)
        {
            main.AddItem(new DocumentData(new PointF(float.Parse(textBox_loaddata_x.Text, CultureInfo.InvariantCulture),
                                          float.Parse(textBox_loaddata_y.Text, CultureInfo.InvariantCulture)), tmpv),
                                          "data0" + (++datacount).ToString());
            button_loaddata_break_Click(null, null);
            UpdateListbox();
            main.Items[main.Items.Count - 1].PreRender();
            Render();
        }

        string path;

        private void button_newdoc_brouse_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = new FileInfo(Application.ExecutablePath).Directory.FullName + "\\Data\\Vect";
            var a = openFileDialog1.ShowDialog();
            if(a == DialogResult.OK)
            {
                label_newdoc_path.Text = TB.L.Phrase["VectorEditor.Word.Path"] + ": " + new FileInfo(openFileDialog1.FileName).Directory.Name + '\\' + new FileInfo(openFileDialog1.FileName).Name;
                path = openFileDialog1.FileName;
            }
        }
        
        /* Sdelyal` do etogo :/*/

        private void button_loaddata_break_Click(object sender, EventArgs e)
        {
            SampleW = 200;
            SampleH = 150;
            textBox_loaddata_x.Text = "0";
            textBox_loaddata_y.Text = "0";
            pictureBox2.Visible = false;
            panel_dataload.ResetText();
            panel_dataload.Visible = false;
            pictureBox2.Location = new Point(3, 3);
        }

        private void button_drcolor_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                colorDialog1.Color = main.Items[listBox1.SelectedIndex].DispColor;
                var a = colorDialog1.ShowDialog();
                if (a == DialogResult.OK)
                {
                    main.Items[listBox1.SelectedIndex].DispColor = colorDialog1.Color;
                    main.Items[listBox1.SelectedIndex].UseDispColor = true;
                    samplecolorprobe = new Bitmap(55, 23);
                    Rectangle rec = new Rectangle(0, 0, 55, 23);
                    var b = new SolidBrush(main.Items[listBox1.SelectedIndex].DispColor);
                    using (Graphics gr = Graphics.FromImage(samplecolorprobe))
                    {
                        gr.FillRectangle(b, rec);
                    }
                    pictureBox_drawcolor.Image = samplecolorprobe;
                    Render();

                }
            }
        }

        private void Form_editvector_SizeChanged(object sender, EventArgs e)
        {
            labelHint.Location = new Point(Width / 2 - labelHint.Width / 2, Height / 2 - labelHint.Height / 2 - 60);
            panel_newdoc.Location = new Point(Width/2 - panel_newdoc.Width/2, Height/2 - panel_newdoc.Height/2 - 100);
            panel_zoom.Location = new Point(Width - panel_zoom.Width - 30, Height - panel_zoom.Height - 75);
            panel_properties.Location = new Point(Width - panel_properties.Width - 30, panel_properties.Location.Y);
            panel_angle.Location = new Point(panel_angle.Location.X, Height - panel_angle.Height - 80);
            panel_dataload.Location = new Point(Width - panel_dataload.Width - 30, 331);
            panel_text.Location = new Point(Width - panel_text.Width - 30, panel_text.Location.Y);
            if (button_dideprop.Text == "") button_dideprop.Location = new Point(Width - button_dideprop.Width - 39 -2 , button_dideprop.Location.Y);
            else button_dideprop.Location = new Point(Width - button_dideprop.Width - 36 - 3, button_dideprop.Location.Y);
            if (button_hidezoom.Text == "") button_hidezoom.Location = new Point(Width - button_hidezoom.Width - 39 - 2, Height - button_hidezoom.Height - 80);
            else button_hidezoom.Location = new Point(Width - button_hidezoom.Width - 36 - 3, Height - button_hidezoom.Height - 80);
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (main.Items[listBox1.SelectedIndex].Type == DocumentItemType.Image)
                {
                    var a = new Form_Dialog_Edit(main.Items[listBox1.SelectedIndex]);
                    a.parent = this;
                    //if(main.UseDarkTheme) a.ToTheme(Color.FromArgb(45, 45, 48), Color.FromArgb(255, 255, 255), Color.FromArgb(30, 30, 30), Color.FromArgb(30, 30, 30));
                    //else a.ToTheme(Color.FromKnownColor(KnownColor.Control), Color.FromKnownColor(KnownColor.ControlText), Color.FromKnownColor(KnownColor.Window), Color.FromKnownColor(KnownColor.Control));
                    a.Show();
                }
                else
                {
                    panel_properties.Enabled = false;
                    var a = (DocumentText)main.Items[listBox1.SelectedIndex];
                    pictureBox2.Visible = true;
                    textBox_text_height.Text = a.Size.Height.ToString(CultureInfo.InvariantCulture);
                    textBox_text_width.Text = a.Size.Width.ToString(CultureInfo.InvariantCulture);
                    pictureBox2.Width = (int)a.Size.Width;
                    pictureBox2.Height = (int)a.Size.Height;
                    textBox_text_posy.Text = a.Position.Y.ToString(CultureInfo.InvariantCulture);
                    textBox_text_xpos.Text = a.Position.X.ToString(CultureInfo.InvariantCulture);
                    pictureBox2.Location = new Point((int)(a.Position.X*zoom),(int)(a.Position.Y*zoom));
                    fontDialog1.Font = a.Font;
                    main.Items.RemoveAt(listBox1.SelectedIndex);
                    panel_text.Visible = true;
                    richTextBox_texteditor_text.Text = a.Caption;
                    remember_text_angle = a.Angle;
                    remember_text_color = a.DispColor;
                    remember_text_name = a.Name;
                    listBox1.SelectedIndex = -1;
                    Render();
                    RenderSample();
                }
            }
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                textBox_editname.ReadOnly = !textBox_editname.ReadOnly;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "Data\\VDocs";
            saveFileDialog1.FileName = main.Name + ".pcvdoc";
            var a = saveFileDialog1.ShowDialog();
            if (a == DialogResult.OK)
            {
                main.Save(new FileInfo(saveFileDialog1.FileName).Name);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "Data\\VDocs";
            var a = openFileDialog2.ShowDialog();
            if (a == DialogResult.OK)
            {
                main = Document.Load(new FileInfo(openFileDialog2.FileName).Name);
                if(main == null)
                {
                    return;
                }
                if(main.CreatedVersion < new Version(GlobalOptions.Ver))
                {
                    var h = MessageBox.Show(TB.L.Message["VectorEditor.OldPCVdocVersion"], TB.L.Phrase["VectorEditor.Word.Warning"], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(h == DialogResult.Yes)
                    {
                        main.CreatedVersion = new Version(GlobalOptions.Ver);
                        main.Save(new FileInfo(openFileDialog2.FileName).Name);
                    }
                }
                labelHint.Visible = false;
                for (int i = 0; i <= main.Items.Count - 1; i++) main.Items[i].PreRender();
                UpdateListbox();
                Render();
                panel_zoom.Enabled = true;
                panel_newdoc.Visible = false;
                toolStripButton_save.Enabled = true;
                button_dideprop.Enabled = true;
                button_dideprop.Size = new Size(63, 23);
                panel_properties.Visible = true;
                button_dideprop.Text = TB.L.Phrase["VectorEditor.Word.Hide"];
                button_hidezoom.Enabled = true;
                Form_editvector_SizeChanged(null, null);
                toolStripStatusLabel1.Text = TB.L.Phrase["VectorEditor.Word.Name"] + ": " + main.Name;
                toolStripStatusLabel3.Text = string.Format("| "+ TB.L.Phrase["VectorEditor.Word.Resolution"] + ": {0}x{1}", main.Size.Width, main.Size.Height);
                Form_editvector_SizeChanged(null, null);
                panel_zoom.Visible = true;
                statusStrip1.Visible = true;
                button_dideprop.Visible = true;
                button_hidezoom.Visible = true;
                toolStripButton_docopts_.Enabled = true;
                toolStripButton_render_.Enabled = true;
                toolStripButton_save_.Enabled = true;
                toolStripSplitButton_additems.Enabled = true;
                toolStripStatusLabel_fileversion.Text = "| "+ TB.L.Phrase["VectorEditor.UsedDocumentVersion"] + ": " + main.CreatedVersion.ToString();
            }
        }

        private void textBox_editname_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (textBox_editname.ReadOnly == false)
                {
                    main.Items[listBox1.SelectedIndex].Name = textBox_editname.Text;
                    listBox1.Items[listBox1.SelectedIndex] =  string.Format("{0} - {1}", main.Items[listBox1.SelectedIndex].Type, textBox_editname.Text);
                    int c = main.Items.FindAll(p => p.Name == textBox_editname.Text.Trim()).Count;
                    if (c >= 2)
                    {
                        MessageBox.Show(string.Format(TB.L.Error["VectorEditor.FoundObjectWithSameName"], c,textBox_editname.Text), TB.L.Phrase["VectorEditor.Word.Warning"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                main.Items.RemoveAt(listBox1.SelectedIndex);
                UpdateListbox();
                Render();
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (main != null)
                {
                    var a = pictureBox1.PointToClient(MousePosition);
                    Pen p = new Pen(Color.Black, 10);
                    for (int i = 0; i <= main.Items.Count - 1; i++)
                    {
                        if (main.Items[i].GrPath.IsOutlineVisible(a.X / zoom, a.Y / zoom, p))
                        {
                            globalsel = false;
                            button_edit_Click(null, null);
                            panel_angle.Visible = false;
                            return;
                        }
                    }
                    if (DocumentBorderRender.Render(main.Border, main.Size).IsOutlineVisible(a.X / zoom, a.Y / zoom, p))
                    {
                        textBox_fileinfo.Text = main.FileName;
                        textBox_fileautor.Text = main.FileAutor;
                        richTextBox_filediscr.Text = main.FileDescr;
                        checkBox_useborder.Checked = main.Border.Use;
                        comboBox_bordstyle.Text = main.Border.Style.ToString();
                        textBox_bordoffset.Text = main.Border.Offset.ToString(CultureInfo.InvariantCulture);
                        panel_docsettings.Visible = true;
                    }
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel4.Text = string.Format("|  X: {0:0.##}", e.X / zoom);
            toolStripStatusLabel5.Text = string.Format("|  Y: {0:0.##}", e.Y / zoom);
        }

        private void toolStripButton_docopts__Click(object sender, EventArgs e)
        {
            panel_docsettings.Visible = !panel_docsettings.Visible;
            if(panel_docsettings.Visible)
            {
                textBox_fileinfo.Text = main.FileName;
                textBox_fileautor.Text = main.FileAutor;
                richTextBox_filediscr.Text = main.FileDescr;
                checkBox_useborder.Checked = main.Border.Use;
                comboBox_bordstyle.Text = main.Border.Style.ToString();
                textBox_bordoffset.Text = main.Border.Offset.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void checkBox_useborder_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_bordstyle.Enabled = checkBox_useborder.Checked;
            textBox_bordoffset.Enabled = checkBox_useborder.Checked;
            main.Border.Use = checkBox_useborder.Checked;
            Render();
        }

        private void textBox_fileinfo_TextChanged(object sender, EventArgs e)
        {
            main.FileName = textBox_fileinfo.Text;
        }

        private void textBox_fileautor_TextChanged(object sender, EventArgs e)
        {
            main.FileAutor = textBox_fileautor.Text;
        }

        private void richTextBox_filediscr_TextChanged(object sender, EventArgs e)
        {
            main.FileDescr = richTextBox_filediscr.Text;
        }

        private void textBox_bordoffset_TextChanged(object sender, EventArgs e)
        {
            float offset = 0.0f;
            bool b = float.TryParse(textBox_bordoffset.Text, out offset);
            if(!b)
            {
                MessageBox.Show(TB.L.Error["VectorEditor.WrongBordOffsetInput"]);
                return;
            }
            main.Border.Offset = offset;
            Render();
        }

        private void comboBox_bordstyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            main.Border.Style = ExOperators.GetEnum<DocumentBorderStyle>(comboBox_bordstyle.Text);
            Render();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (main != null)
            {
                if(remember_text_name != "" && pictureBox2.Visible == true)
                {
                    button_done_Click(null, null);
                }
                var a = pictureBox1.PointToClient(MousePosition);
                Pen p = new Pen(Color.Black, 10);
                if (DocumentBorderRender.Render(main.Border, main.Size).IsOutlineVisible(a.X / zoom, a.Y / zoom, p))
                {
                    main.BorderPen = Pens.Magenta;
                    if (e.Button == MouseButtons.Right)
                    {
                        contextMenuStrip_object_edit.Items.Clear();
                        contextMenuStrip_object_edit.Items.Add(TB.L.Phrase["VectorEditor.Word.Edit"], Resources.edit);
                        contextMenuStrip_object_edit.Items.Add(TB.L.Phrase["VectorEditor.Word.Delete"], Resources.delete);
                        for (int ii = 0; ii <= contextMenuStrip_object_edit.Items.Count - 1; ii++)
                        {
                            contextMenuStrip_object_edit.Items[ii].ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                            contextMenuStrip_object_edit.Items[ii].BackColor = Color.FromKnownColor(KnownColor.MenuHighlight);
                        }
                        contextMenuStrip_object_edit.Show(pictureBox1, a);
                    }
                    Render();
                }
                else
                {
                    main.BorderPen = Pens.Black;
                    panel_docsettings.Visible = false;
                }
                for (int i = 0; i <= main.Items.Count - 1; i++)
                {
                    if (main.Items[i].GrPath.IsOutlineVisible(a.X / zoom, a.Y / zoom, p))
                    {
                        globalsel = true;
                        listBox1.SelectedItem = listBox1.Items[i];
                        panel_angle.Visible = true;
                        trackBar_angle.Value = (int)main.Items[i].Angle;
                        label_text_anglevalue.Text = trackBar_angle.Value.ToString() + ".";
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStrip_object_edit.Items.Clear();
                            contextMenuStrip_object_edit.Items.Add(TB.L.Phrase["VectorEditor.Word.Edit"], Resources.edit);
                            contextMenuStrip_object_edit.Items.Add(TB.L.Phrase["VectorEditor.Word.Clone"], Resources.add);
                            contextMenuStrip_object_edit.Items.Add(TB.L.Phrase["VectorEditor.Word.Delete"], Resources.delete);
                            for (int ii = 0; ii <= contextMenuStrip_object_edit.Items.Count-1; ii++) 
                            {
                                contextMenuStrip_object_edit.Items[ii].ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                                contextMenuStrip_object_edit.Items[ii].BackColor = Color.FromKnownColor(KnownColor.MenuHighlight);
                            }
                            contextMenuStrip_object_edit.Show(pictureBox1, a);
                        }
                        return;
                    }
                }
                panel_angle.Visible = false;
                listBox1.SelectedIndex = -1;
                if (main != null) Render();
                globalsel = false;
            }
        }

        private void contextMenuStrip_object_edit_Click(object sender, EventArgs e)
        {
            int selindex = -1;
            for (int i = 0; i <= contextMenuStrip_object_edit.Items.Count - 1; i++)
            {
                if(contextMenuStrip_object_edit.Items[i].Selected)
                {
                    selindex = i;
                    break;
                }
            }
            if (selindex != -1)
            {
                if (contextMenuStrip_object_edit.Items.Count == 3)
                {
                    switch (selindex)
                    {
                        case (0):
                            button_edit_Click(null, null);
                            break;
                        case (1):
                            break;
                        case (2):
                            button1_Click(null, null);
                            break;
                    }
                }
                else
                {
                    switch (selindex)
                    {
                        case (0):
                            textBox_fileinfo.Text = main.FileName;
                            textBox_fileautor.Text = main.FileAutor;
                            richTextBox_filediscr.Text = main.FileDescr;
                            checkBox_useborder.Checked = main.Border.Use;
                            comboBox_bordstyle.Text = main.Border.Style.ToString();
                            textBox_bordoffset.Text = main.Border.Offset.ToString(CultureInfo.InvariantCulture);
                            panel_docsettings.Visible = true;
                            break;
                        case (1):
                            main.Border.Use = false;
                            Render();
                            break;
                    }
                }
            }
        }

        private void button_angle_0deg_Click(object sender, EventArgs e)
        {
            trackBar_angle.Value = 0;
            trackBar1_Scroll_1(null, null);
        }

        private void button_angle_p90deg_Click(object sender, EventArgs e)
        {
            int a = trackBar_angle.Value;
            if (-180 <= a && a < -90) trackBar_angle.Value = -90;
            else if (-90 <= a && a < 0) trackBar_angle.Value = 0;
            else if (0 <= a && a < 90) trackBar_angle.Value = 90;
            else if (90 <= a && a < 180) trackBar_angle.Value = 180;
            else if (a == 180) trackBar_angle.Value = -90;
            trackBar1_Scroll_1(null, null);
        }

        private void button_angle_m90deg_Click(object sender, EventArgs e)
        {
            int a = trackBar_angle.Value;
            if (-180 < a && a <= -90) trackBar_angle.Value = -180;
            else if (-90 < a && a <= 0) trackBar_angle.Value = -90;
            else if (0 < a && a <= 90) trackBar_angle.Value = 0;
            else if (90 < a && a <= 180) trackBar_angle.Value = 90;
            else if (a == -180) trackBar_angle.Value = 90;
            trackBar1_Scroll_1(null, null);
        }

        private void button_loaddata_load_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label_text_anglevalue.Text = trackBar_angle.Value.ToString() + ".";
            main.Items[listBox1.SelectedIndex].Angle = trackBar_angle.Value;
            main.Items[listBox1.SelectedIndex].PreRender();
            Matrix m = new Matrix();
            m.RotateAt(main.Items[listBox1.SelectedIndex].Angle/2, new PointF(main.Items[listBox1.SelectedIndex].Size.Width / 2 + main.Items[listBox1.SelectedIndex].Position.X, main.Items[listBox1.SelectedIndex].Size.Height / 2 + main.Items[listBox1.SelectedIndex].Position.Y));
            main.Items[listBox1.SelectedIndex].GrPath.Transform(m);
            Render();

        }

        private void Form_editvector_KeyDown(object sender, KeyEventArgs e)
        {
            cntr_pressed = e.Control;
            if (cntr_pressed)
            {
                scrpoint = panel4.AutoScrollPosition;
            }
        }


        private void Form_editvector_KeyUp(object sender, KeyEventArgs e)
        {
            cntr_pressed = e.Control;
        }

        private void richTextBox_texteditor_text_TextChanged(object sender, EventArgs e)
        {
            SizeF size =Graphics.FromImage(pictureBox1.Image).MeasureString(richTextBox_texteditor_text.Text, fontDialog1.Font);
            textBox_text_width.Text = (size.Width*0.75 - 5).ToString(CultureInfo.InvariantCulture);
            textBox_text_height.Text = size.Height.ToString(CultureInfo.InvariantCulture);
            RenderSampleText();
        }

        private void button_pickfont_Click(object sender, EventArgs e)
        {
            var a = fontDialog1.ShowDialog();
            if(a == DialogResult.OK)
            {
                RenderSampleText();
            }
        }
    }
}
