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
* PlotterControl \ Form_Dialog_Lang.cs
*
* Created: 06.08.2017 19:55
* Last Edited: 01.07.2017 13:09:58
*
*=================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_Dialog_Lang : Form
    {
        public Form_Dialog_Lang()
        {
            InitializeComponent();
        }

        ImageListBox glb;

        private void Form_Dialog_Lang_Load(object sender, EventArgs e)
        {
            glb = new ImageListBox()
            {
                Location = new Point(12, 12),
                Size = new Size(404, 124),
                Font = new Font("Arial", 11, FontStyle.Regular),
                BackColor = Color.White,
                ItemHeight = 15
            };
            int i = 0;
            ImageList il = new ImageList();
            foreach (var item in TranslateBase.LoadedLangs)
            {
                il.Images.Add(item.Icon);
                if(TranslateBase.CurrentLangName == item.Name) glb.Items.Add(new ImageListBox.ImageListBoxItem(i++, Color.Green, item.Name));
                else glb.Items.Add(new ImageListBox.ImageListBoxItem(i++, Color.Black, item.Name));
            }
            glb.ImageList = il;
            glb.SelectedIndexChanged += Glb_SelectedIndexChanged;
            Controls.Add(glb);
        }

        private void Glb_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_edit.Enabled = glb.SelectedIndex != -1;
            button_select.Enabled = glb.SelectedIndex != -1 && ((ImageListBox.ImageListBoxItem)glb.SelectedItem).Item.ToString() != TranslateBase.CurrentLang.Name;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
