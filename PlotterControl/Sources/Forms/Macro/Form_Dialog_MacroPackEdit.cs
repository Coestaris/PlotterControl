/*=================================\
* PlotterControl\Form_Dialog_MacroPackEdit.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:12:27
*=================================*/

using CWA.Connection;
using CWA.Printing.Macro;
using CWA.Vectors.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using TsudaKageyu;

namespace CnC_WFA
{
    public partial class Form_Dialog_MacroPackEdit : Form
    {
        public Form_Dialog_MacroPackEdit()
        {
            InitializeComponent();
        }

        private MacroPack main;

        private void UpDateListbox()
        {
            listBox_macroses.Items.Clear();
            listBox_macroses.Items.AddRange(main.Elems.Select(p =>
                 p.GetMacro() == null ? new ImageListBox.ImageListBoxItem(0, Color.Red, string.Format(TB.L.Phrase["Form_MacroPack.UnableToLoadMacro"], new FileInfo(p.Path).Directory.Name + "\\" + new FileInfo(p.Path).Name)) :
                 p.Options.Hidden ? new ImageListBox.ImageListBoxItem(0, Color.Gray, string.Format(TB.L.Phrase["Form_MacroPack.Hidden"], p.GetMacro().Name)) :
                 new ImageListBox.ImageListBoxItem(0, Color.Black, p.GetMacro().Name)).ToArray());
        }

        private void UpDateMacrosettings(int i)
        {
            var a = main.Elems[i];
            if (a.GetMacro() == null)
            {
                int height = pictureBox1.Height;
                int width = pictureBox1.Width;
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.FillRectangle(new SolidBrush(Color.FromArgb(224, 224, 224)), new RectangleF(0, 0, width, height));
                    var font = new Font("Cambria", 15f, FontStyle.Regular);
                    var size = gr.MeasureString(TB.L.Phrase["Form_MacroPack.NothingToPreview"], font);
                    gr.DrawString(TB.L.Phrase["Form_MacroPack.NothingToPreview"], font, Brushes.Red, new Point((int)(width / 2 - size.Width / 2), (int)(height / 2 - size.Height / 2)));
                }
                Image img = pictureBox1.Image;
                pictureBox1.Image = bmp;
                img?.Dispose();
                return;
            }
            label_macro_name.Text = TB.L.Phrase["Form_MacroPack.Name"] + ExOperators.CutString(a.GetMacro().Name, 15);
            label_macro_path.Text = TB.L.Phrase["Form_MacroPack.Path"] + new FileInfo(a.Path).Directory.Name + "\\" + new FileInfo(a.Path).Name;
            label_macro_discr.Text = TB.L.Phrase["Form_MacroPack.Discr"] + ExOperators.CutString(a.GetMacro().Discr, 15);
            textBox_macro_caption.Text = a.Options.Caption;
            comboBox_macro_keybind.SelectedItem = a.Options.KeyBind.ToString();
            comboBox_macro_charbind.Text = a.Options.CharBind.ToString();
            label_macro_elemcount.Text = TB.L.Phrase["Form_MacroPack.Elements"] + a.GetMacro().Elems.Count;
            checkBox_isHidden.Checked = a.Options.Hidden;
            RenderGR(i);
            Render();
        }

        private void UpDateGeneralSettings()
        {
            Text = string.Format(TB.L.Phrase["Form_MacroPack.MacroPack"], main.Name);
            textBox_caption.Text = main.Caption;
            textBox_name.Text = main.Name;
            richTextBox_discr.Text = main.Discr;
            comboBox_portname.SelectedItem = main.PortName.ToString();
            comboBox_bdrate.SelectedItem = main.PortBD.ToString();
            label_samples.Text = string.Format(TB.L.Phrase["Form_MacroPack.Samples"], main.Samples.Count);
            listBox_samples.Items.AddRange(main.Samples.ToArray());
        }

        private void Dialog_MacroPackEdit_Load(object sender, EventArgs e)
        {
            IconExtractor ie = new IconExtractor("Lib\\IconSet.dll");
            ImageList il = new ImageList();
            il.Images.Add(ie.GetIcon((int)FileAssociation.IconIndex.Icon_Macros).ToBitmap());
            listBox_macroses.ImageList = il;
            comboBox_bdrate.Items.AddRange(BdRate.GetNamesStrings());
            comboBox_portname.Items.AddRange(ComPortName.GetNamesStrings());
            comboBox_macro_keybind.Items.AddRange(Enum.GetNames(typeof(Key)));
            for (int i = 30; i <= 256; i++) comboBox_macro_charbind.Items.Add((char)i);
            main = new MacroPack(
                TB.L.Phrase["Form_MacroPack.NoName"],
                TB.L.Phrase["Form_MacroPack.NoDiscr"], 
                TB.L.Phrase["Form_MacroPack.NoName"]);
            UpDateGeneralSettings();
        }

        private void button_addnew_Click(object sender, EventArgs e)
        {
            if (openFileDialog_macro.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in openFileDialog_macro.FileNames)
                {
                    var b = new Macro(s);
                    main.Elems.Add(new MacroPackElem(s, b.Name));
                    main.Elems.Last().SetMacro(b);
                }
            }
            UpDateListbox();
        }

        private GraphicsPath[] GrUpped, GrNormal;

        private void RenderGR(int index)
        {
            var item = main.Elems[index].GetMacro();
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
                b = item.Elems.FindAll(a => a.Type == MacroElemType.MoveToPoint || a.Type == MacroElemType.MoveToPointAndDelay)[0];
            }
            catch (ArgumentOutOfRangeException) { return; }
            if (b == null) return;
            CurXPos = b.MoveToPoint.X;
            CurYPos = b.MoveToPoint.Y;
            bool isUpped = true;
            grUpped.Add(new GraphicsPath());
            foreach (var a in item.Elems)
            {
                if (a.Type == MacroElemType.Tool || a.Type == MacroElemType.ToolAndDelay)
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
            GrUpped = grUpped.ToArray();
            GrNormal = grNormal.ToArray();
        }

        private float Zoom = 221f / 1180; //TODO!!!!!!!
        private int LastListBoxIndex;

        private void Render()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            Bitmap bmp = new Bitmap(width, height);
            List<GraphicsPath> grUp = new List<GraphicsPath>();
            GrUpped.ToList().ForEach(p => grUp.Add((GraphicsPath)p.Clone()));
            List<GraphicsPath> grNo = new List<GraphicsPath>();
            GrNormal.ToList().ForEach(p => grNo.Add((GraphicsPath)p.Clone()));
            var Matrix = new Matrix();
            Matrix.Scale(Zoom, Zoom);
            foreach (var item in grUp) item.Transform(Matrix);
            foreach (var item in grNo) item.Transform(Matrix);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.FillRectangle(Brushes.White, new RectangleF(0, 0, width, height));
                gr.DrawRectangle(new Pen(Color.Black, 1) { DashStyle = DashStyle.Dot }, 2, 2, width - 4, height - 4);
                foreach (var item in grUp) gr.DrawPath(new Pen(Color.Gray, 1) { DashStyle = DashStyle.Dash }, item);
                foreach (var item in grNo) gr.DrawPath(new Pen(Color.Black, 1), item);
            }
            Image img = pictureBox1.Image;
            pictureBox1.Image = bmp;
            if (img != null) img.Dispose();
        }

        private void listBox_macroses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isExists = main.Elems[listBox_macroses.SelectedIndex].GetMacro() != null;
            bool isNNS = listBox_macroses.SelectedIndex != -1;

            textBox_macro_caption.Enabled = isNNS && isExists;
            comboBox_macro_charbind.Enabled = isNNS && isExists;
            comboBox_macro_keybind.Enabled = isNNS && isExists;
            checkBox_isHidden.Enabled = isNNS && isExists;
            button_openineditor.Enabled = isNNS && isExists;
            button_remove.Enabled = isNNS;
            button_repickpath.Enabled = isNNS;
            if (isNNS)
            {
                LastListBoxIndex = listBox_macroses.SelectedIndex;
                UpDateMacrosettings(listBox_macroses.SelectedIndex);
            }
        }

        private void comboBox_portname_SelectedIndexChanged(object sender, EventArgs e)
        {
            main.PortName = new ComPortName(comboBox_portname.Text);
        }

        private void comboBox_bdrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            main.PortBD = new BdRate(comboBox_bdrate.Text);
        }

        private void richTextBox_discr_TextChanged(object sender, EventArgs e)
        {
            main.Discr = richTextBox_discr.Text;
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            main.Name = textBox_name.Text;
            Text = string.Format(TB.L.Phrase["Form_MacroPack.MacroPack"], main.Name);
        }

        private void textBox_caption_TextChanged(object sender, EventArgs e)
        {
            main.Caption = textBox_caption.Text;
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                main.Elems.RemoveAt(listBox_macroses.SelectedIndex);
                listBox_macroses.Items.RemoveAt(listBox_macroses.SelectedIndex);
            }
            else MessageBox.Show(
                TB.L.Phrase["Form_MacroPack.SelectMacro"], 
                TB.L.Phrase["Form_MacroPack.Error"],
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_openineditor_Click(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                FormTranslator.Translate(new Form_Macro(main.Elems[listBox_macroses.SelectedIndex].Path)).Show();
            }
            else MessageBox.Show(
                TB.L.Phrase["Form_MacroPack.SelectMacro"], 
                TB.L.Phrase["Form_MacroPack.Error"],
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_sample_value_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_samples_add_Click(object sender, EventArgs e)
        {
            listBox_samples.Items.Add(textBox_sample_value.Text);
            main.Samples.Add(textBox_sample_value.Text);
            textBox_sample_value.Text = "";
            label_samples.Text = string.Format(TB.L.Phrase["Form_MacroPack.Samples"], main.Samples.Count);
        }

        private void button_samples_remove_Click(object sender, EventArgs e)
        {
            if (listBox_samples.SelectedIndex != -1)
            {
                main.Samples.RemoveAt(listBox_samples.SelectedIndex);
                listBox_samples.Items.RemoveAt(listBox_samples.SelectedIndex);
            }
        }

        private void textBox_macro_caption_TextChanged(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                var a = main.Elems[listBox_macroses.SelectedIndex];
                main.Elems[listBox_macroses.SelectedIndex] = new MacroPackElem() { Options = new MacroPackElemOption { Caption = textBox_caption.Text, CharBind = a.Options.CharBind, KeyBind = a.Options.KeyBind }, Path = a.Path };
                main.Elems[listBox_macroses.SelectedIndex].SetMacro(a.GetMacro());
            }
        }

        private void comboBox_macro_keybind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                var a = main.Elems[listBox_macroses.SelectedIndex];
                main.Elems[listBox_macroses.SelectedIndex] = new MacroPackElem() { Options = new MacroPackElemOption { Caption = a.Options.Caption, CharBind = a.Options.CharBind, KeyBind = ExOperators.GetEnum<Key>(comboBox_macro_keybind.Text) }, Path = a.Path };
                main.Elems[listBox_macroses.SelectedIndex].SetMacro(a.GetMacro());
            }
        }

        private void comboBox_macro_charbind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                main.Elems[listBox_macroses.SelectedIndex].Options.CharBind = comboBox_macro_charbind.Text.First();
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            saveFileDialog_mpack.InitialDirectory = new FileInfo(Application.ExecutablePath).Directory + "\\Data\\Macros";
            saveFileDialog_mpack.FileName = "test.pcmpack";
            if (saveFileDialog_mpack.ShowDialog() == DialogResult.OK)
            {
                main.Save(saveFileDialog_mpack.FileName);
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            openFileDialog_mpack.InitialDirectory = new FileInfo(Application.ExecutablePath).Directory + "\\Data\\Macros";
            openFileDialog_mpack.FileName = "test.pcmpack";
            if (openFileDialog_mpack.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    main = MacroPack.Load(openFileDialog_mpack.FileName);
                }
                catch
                {
                    MessageBox.Show(
                        TB.L.Phrase["Form_MacroPack.ErrorWhileLoading"],
                        TB.L.Phrase["Form_MacroPack.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    main = new MacroPack(
                        TB.L.Phrase["Form_MacroPack.NoName"],
                        TB.L.Phrase["Form_MacroPack.NoDiscr"],
                        TB.L.Phrase["Form_MacroPack.NoName"]);
                }
                UpDateGeneralSettings();
                UpDateListbox();
            }
        }

        private void button_repickpath_Click(object sender, EventArgs e)
        {
            if (openFileDialog_macro2.ShowDialog() == DialogResult.OK)
            {
                main.Elems[listBox_macroses.SelectedIndex] = new MacroPackElem() { Options = main.Elems[listBox_macroses.SelectedIndex].Options, Path = openFileDialog_macro2.FileName };
                main.Elems[listBox_macroses.SelectedIndex].SetMacro(new Macro(openFileDialog_macro2.FileName));
                UpDateMacrosettings(listBox_macroses.SelectedIndex);
                UpDateListbox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_main_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            button_main.BackColor = Color.FromArgb(5, 92, 199);
            button_conn.BackColor = Color.FromArgb(4, 60, 130);
            button_macro.BackColor = Color.FromArgb(4, 60, 130);
            button_preset.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_conn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            button_main.BackColor = Color.FromArgb(4, 60, 130);
            button_conn.BackColor = Color.FromArgb(5, 92, 199);
            button_macro.BackColor = Color.FromArgb(4, 60, 130);
            button_preset.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_macro_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            button_main.BackColor = Color.FromArgb(4, 60, 130);
            button_conn.BackColor = Color.FromArgb(4, 60, 130);
            button_macro.BackColor = Color.FromArgb(5, 92, 199);
            button_preset.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_preset_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            button_main.BackColor = Color.FromArgb(4, 60, 130);
            button_conn.BackColor = Color.FromArgb(4, 60, 130);
            button_macro.BackColor = Color.FromArgb(4, 60, 130);
            button_preset.BackColor = Color.FromArgb(5, 92, 199);
        }

        private void checkBox_isHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                main.Elems[listBox_macroses.SelectedIndex].Options.Hidden = checkBox_isHidden.Checked;
                UpDateListbox();
                listBox_macroses.SelectedIndex = LastListBoxIndex;
            }
        }

        private void listBox_samples_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_sample_value.Text = (string)listBox_samples.SelectedItem;
        }
    }
}
