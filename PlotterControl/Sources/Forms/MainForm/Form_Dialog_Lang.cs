/*=================================\
* PlotterControl\Form_Dialog_Lang.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.10.2017 20:19
* Last Edited: 06.10.2017 21:50:16
*=================================*/

using System;
using System.Drawing;
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
                if(TranslateBase.CurrentLang.Name == item.Name) glb.Items.Add(new ImageListBox.ImageListBoxItem(i++, Color.Green, item.Name));
                else glb.Items.Add(new ImageListBox.ImageListBoxItem(i++, Color.Black, item.Name));
            }
            glb.ImageList = il;
            glb.SelectedIndexChanged += Glb_SelectedIndexChanged;
            Controls.Add(glb);
        }

        private void Glb_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_edit.Enabled = glb.SelectedIndex != -1;
            button_select.Enabled = glb.SelectedIndex != -1 && ((ImageListBox.ImageListBoxItem)glb.SelectedItem).Item.ToString() != TranslateBase.CurrentLangName;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
