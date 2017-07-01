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
using CWA.Vectors.Document;
using System;
using System.Drawing;
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
                 p.GetMacro() == null ? new ImageListBox.ImageListBoxItem(0, Color.Red, string.Format("{0} -- Cant Load Macro", new FileInfo(p.Path).Directory.Name + "\\" + new FileInfo(p.Path).Name)) :
                                        new ImageListBox.ImageListBoxItem(0, Color.Black, p.GetMacro().Name)).ToArray());
        }

        private void UpDateMacrosettings(int i)
        {
            var a = main.Elems[i];
            panel_macroMain.Enabled = a.GetMacro() != null;
            if (a.GetMacro() == null) return;
            label_macro_name.Text = "Name: " + ExOperators.CutString(a.GetMacro().Name, 15);
            label_macro_path.Text = "Path: " + new FileInfo(a.Path).Directory.Name + "\\" + new FileInfo(a.Path).Name;
            label_macro_discr.Text = "Discr: " + ExOperators.CutString(a.GetMacro().Discr, 15);
            textBox_macro_caption.Text = a.Options.Caption;
            comboBox_macro_keybind.SelectedItem = a.Options.KeyBind.ToString();
            comboBox_macro_charbind.Text = a.Options.CharBind.ToString();
            label_macro_elemcount.Text = "Elements: " + a.GetMacro().Elems.Count;
        }

        private void UpDateGeneralSettings()
        {
            Text = string.Format("Пак макросов: \"{0}\"", main.Name);
            textBox_caption.Text = main.Caption;
            textBox_name.Text = main.Name;
            richTextBox_discr.Text = main.Discr;
            comboBox_portname.SelectedItem = main.PortName.ToString();
            comboBox_bdrate.SelectedItem = main.PortBD.ToString();
            label_samples.Text = string.Format("Сємплов: {0}", main.Samples.Count);
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
            main = new MacroPack("NoName", "NoDiscr", "NoName");
            UpDateGeneralSettings();
        }

        private void button_addnew_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in openFileDialog1.FileNames)
                {
                    var b = new Macro(s);
                    main.Elems.Add(new MacroPackElem(s, b.Name));
                    main.Elems.Last().SetMacro(b);
                }
            }
            UpDateListbox();
        }

        private void listBox_macroses_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_macroMain.Enabled = listBox_macroses.SelectedIndex != -1;
            if(listBox_macroses.SelectedIndex!=-1)
            {
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
            Text = string.Format("Пак макросов: \"{0}\"", main.Name);
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
            else MessageBox.Show("Select Macros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_openineditor_Click(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                new Form_Macro(main.Elems[listBox_macroses.SelectedIndex].Path).Show();
            }
            else MessageBox.Show("Select Macros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_sample_value_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_samples_add_Click(object sender, EventArgs e)
        {
            listBox_samples.Items.Add(textBox_sample_value.Text);
            main.Samples.Add(textBox_sample_value.Text);
            textBox_sample_value.Text = "";
            label_samples.Text = string.Format("Сємплов: {0}", main.Samples.Count);
        }

        private void button_samples_remove_Click(object sender, EventArgs e)
        {
            if(listBox_samples.SelectedIndex!=-1)
            {
                listBox_samples.Items.RemoveAt(listBox_samples.SelectedIndex);
                main.Samples.RemoveAt(listBox_samples.SelectedIndex);
            }
        }

        private void textBox_macro_caption_TextChanged(object sender, EventArgs e)
        {
            if(listBox_macroses.SelectedIndex!=-1)
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
            saveFileDialog1.FileName = "test.pcmpack";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                main.Save(saveFileDialog1.FileName);
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "test.pcmpack";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    main = MacroPack.Load(openFileDialog2.FileName);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке -_-");
                    main = new MacroPack("NoName", "NoDiscr", "NoName");
                }
                UpDateGeneralSettings();
                UpDateListbox();
            }
        }

        private void button_repickpath_Click(object sender, EventArgs e)
        {

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

        private void tabPage_macro_Click(object sender, EventArgs e)
        {

        }

        private void listBox_samples_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_sample_value.Text = (string)listBox_samples.SelectedItem;
        }
    }
}
