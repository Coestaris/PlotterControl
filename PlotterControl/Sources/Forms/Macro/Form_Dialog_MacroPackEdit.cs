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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace CnC_WFA
{
    public partial class Form_Dialog_MacroPackEdit : Form
    {
        public Form_Dialog_MacroPackEdit()
        {
            InitializeComponent();
        }

        MacroPack main;

        private void UpDateListbox()
        {
            listBox_macroses.Items.Clear();
            listBox_macroses.Items.AddRange(main.Elems.Select( p => p.Macros.Name).ToArray());
        }

        private void UpDateMacrosettings(int i)
        {
            var a = main.Elems[i];
            label_macro_name.Text = "Name: " + ExOperators.CutString(a.Macros.Name, 15);
            label_macro_path.Text = "Path: " + new FileInfo(a.Path).Directory.Name + "\\"+ new FileInfo(a.Path).Name;
            label_macro_discr.Text = "Discr: " + ExOperators.CutString(a.Macros.Discr, 15);
            textBox_macro_caption.Text = a.Options.Caption;
            comboBox_macro_keybind.SelectedItem = a.Options.KeyBind.ToString();
            comboBox_macro_charbind.SelectedItem = a.Options.CharBind.ToString();
            label_macro_elemcount.Text = "Elements: " + a.Macros.Elems.Count;
        }

        private void UpDateGeneralSettings()
        {
            textBox_caption.Text = main.Caption;
            textBox_name.Text = main.Name;
            richTextBox_discr.Text = main.Discr;
            comboBox_portname.SelectedItem = main.PortName.ToString();
            comboBox_bdrate.SelectedItem = main.PortBD.ToString();
        }

        private void Dialog_MacroPackEdit_Load(object sender, EventArgs e)
        {
            comboBox_bdrate.Items.AddRange(BdRate.GetNamesStrings());
            comboBox_portname.Items.AddRange(ComPortName.GetNamesStrings());
            comboBox_macro_keybind.Items.AddRange(Enum.GetNames(typeof(Key)));
            for (int i = 30; i <= 256; i++) comboBox_macro_charbind.Items.Add((char)i);
            main = new MacroPack("NoName","NoDiscr","NoName");
            UpDateGeneralSettings();
        }

        private void button_addnew_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in openFileDialog1.FileNames)
                {
                    main.Elems.Add(new MacroPackElem(s));
                }
            }
            UpDateListbox();
        }

        private void listBox_macroses_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                main.Elems[listBox_macroses.SelectedIndex] = new MacroPackElem() { Options = new MacroPackElemOption { Caption = textBox_caption.Text, CharBind = a.Options.CharBind, KeyBind = a.Options.KeyBind } , Macros = a.Macros, Path = a.Path };
            }
        }

        private void comboBox_macro_keybind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                var a = main.Elems[listBox_macroses.SelectedIndex];
                main.Elems[listBox_macroses.SelectedIndex] = new MacroPackElem() { Options = new MacroPackElemOption { Caption = a.Options.Caption, CharBind = a.Options.CharBind, KeyBind = ExOperators.GetEnum<Key>(comboBox_macro_keybind.Text) }, Macros = a.Macros, Path = a.Path };
            }
        }

        private void comboBox_macro_charbind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_macroses.SelectedIndex != -1)
            {
                var a = main.Elems[listBox_macroses.SelectedIndex];
                main.Elems[listBox_macroses.SelectedIndex] = new MacroPackElem() { Options = new MacroPackElemOption { Caption = a.Options.Caption, CharBind = comboBox_macro_charbind.Text[0], KeyBind = a.Options.KeyBind }, Macros = a.Macros, Path = a.Path };
            }
        }
    }
}
