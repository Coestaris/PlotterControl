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
* PlotterControl \ Form_Dialog_EditElement.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 01.07.2017 13:09:58
*
*=================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_Dialog_EditElement : Form
    {
        private GraphDoc Object;

        public Form_Dialog_EditElement()
        {
            InitializeComponent();
        }

        public Form_Dialog_EditElement(GraphDoc Object, int v)
        {
            InitializeComponent();
            this.Object = Object;
            tabControl1.SelectedIndex = v;

            checkBox_axis_show.Checked = Object.AxisParams.Show;
            textBox_axis_offset_x.Text = Object.AxisParams.XOffset.ToString();
            textBox_axis_offset_y.Text = Object.AxisParams.YOffset.ToString();
            textBox_axis_width.Text = Object.AxisParams.Width.ToString();
            radioButton_axis_limited.Checked = !Object.AxisParams.UseUnlimited;
            colorDialog1.Color = Object.AxisParams.Color;
            radioButton_axis_limited.Checked = !Object.AxisParams.UseUnlimited;
            radioButton_axis_unlimited.Checked = Object.AxisParams.UseUnlimited;
            radioButton_axis_limited_CheckedChanged(null, null);

            SetAxisColorProbe();

        }

        private void radioButton_axis_limited_CheckedChanged(object sender, EventArgs e)
        {
            Object.AxisParams.UseUnlimited =!radioButton_axis_limited.Checked;
            textBox_axis_offset_x.Enabled = radioButton_axis_limited.Checked;
            textBox_axis_offset_y.Enabled = radioButton_axis_limited.Checked;
            Object.AxisParams.UseUnlimited = !radioButton_axis_limited.Checked;
        }

        private void checkBox_axis_show_CheckedChanged(object sender, EventArgs e)
        {
            Object.AxisParams.Show = checkBox_axis_show.Checked;
            groupBox_axis_display.Enabled = checkBox_axis_show.Checked;
            groupBox_axis_param.Enabled = checkBox_axis_show.Checked;
        }

        private void SetAxisColorProbe()
        {
            Bitmap bmp = new Bitmap(50, 50);
            using (Graphics gr = Graphics.FromImage(bmp)) gr.FillRectangle(new SolidBrush(colorDialog1.Color), new RectangleF(0, 0, 50, 50));
            Image img = pictureBox_axis_color.Image;
            pictureBox_axis_color.Image = bmp;
            if (img != null) img.Dispose();
        }

        private void button_axis_color_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Object.AxisParams.Color = colorDialog1.Color;
                label_axis_color_info.Text = string.Format("RGB ({0}, {1}, {2})", colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
                SetAxisColorProbe();
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Dialog_EditElement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Object.AxisParams.Width = float.Parse(textBox_axis_width.Text, CultureInfo.InvariantCulture);
            Object.AxisParams.XOffset = float.Parse(textBox_axis_offset_x.Text, CultureInfo.InvariantCulture);
            Object.AxisParams.YOffset = float.Parse(textBox_axis_offset_y.Text, CultureInfo.InvariantCulture);

        }

        private void Form_Dialog_EditElement_Load(object sender, EventArgs e)
        {

        }
    }
}
