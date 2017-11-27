/*=================================\
* PlotterControl\Form_Dialog_EditElement.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
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

            Buttons = new Button[]
            {
                button_axis,
                button_axisCaption,
                button_docCaption,
                button_grid,
                button_legend,
                button_addPoints
            };

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
                label_axis_color_info.Text = string.Format(TB.L.Phrase["orm_Dialog_EditElement.RGB"], colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
                SetAxisColorProbe();
            }
        }

        private void button_exit_Click(object sender, EventArgs e) => Close();

        private void Form_Dialog_EditElement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Object.AxisParams.Width = float.Parse(textBox_axis_width.Text, CultureInfo.InvariantCulture);
            Object.AxisParams.XOffset = float.Parse(textBox_axis_offset_x.Text, CultureInfo.InvariantCulture);
            Object.AxisParams.YOffset = float.Parse(textBox_axis_offset_y.Text, CultureInfo.InvariantCulture);

        }

        private Button[] Buttons; 
        private Color SelectedButtonColor = Color.FromArgb(5, 92, 199);
        private Color DefaultButtonColor = Color.FromArgb(4, 60, 130);
        private DateTime startTimePeriod;
        private DateTime endTimePeriod;

        public List<string> GlobalErrorsPeriod { get; private set; }

        private void HighLightButton(int index)
        {
            for (int i = 0; i < Buttons.Length; i++)
                Buttons[i].BackColor = i == index ? SelectedButtonColor : DefaultButtonColor;
            tabControl1.SelectedIndex = index;
        }

        private void button_axis_Click(object sender, EventArgs e) => HighLightButton(0);

        private void button_axisCaption_Click(object sender, EventArgs e) => HighLightButton(1);

        private void button_docCaption_Click(object sender, EventArgs e) => HighLightButton(2);

        private void button_grid_Click(object sender, EventArgs e) => HighLightButton(3);

        private void button_legend_Click(object sender, EventArgs e) => HighLightButton(4);

        private void button_addPoints_Click(object sender, EventArgs e) => HighLightButton(5);

        private void button_markers_compile_Click(object sender, EventArgs e)
        {
            startTimePeriod = DateTime.Now;
            string LowCompString = Object.AxisCaptionParams.LowLimFormula;
            string HighCompString = Object.AxisCaptionParams.HighLimFormula;
            string PeriodCompString = Object.AxisCaptionParams.PeriodFormula;
            Object.AxisCaptionParams.LowLimFormula = textBox_markers_period_start.Text;
            Object.AxisCaptionParams.HighLimFormula = textBox_markers_period_end.Text;
            Object.AxisCaptionParams.PeriodFormula = textBox_markers_period.Text;
            GlobalErrorsPeriod = Object.AxisCaptionParams.CompilePeriod();
            if (GlobalErrorsPeriod != null)
            {
                panel_markers_status.Visible = true;
                panel_markers_status.BackColor = Color.FromArgb(255, 74, 74);
                label_markers_status.Text = string.Format(TB.L.Phrase["Form_Dialog_EditElement.FoundErrors"], (GlobalErrorsPeriod?.Count == null ? 0 : GlobalErrorsPeriod?.Count));
                button_markers_status.Visible = true;
                Object.AxisCaptionParams.LowLimFormula = LowCompString;
                Object.AxisCaptionParams.HighLimFormula = HighCompString;
                Object.AxisCaptionParams.PeriodFormula = PeriodCompString;
                Object.AxisCaptionParams.CompilePeriod();
                endTimePeriod = DateTime.Now;
            }
            else
            {
                panel_markers_status.Visible = true;
                panel_markers_status.BackColor = Color.FromArgb(0, 255, 0);
                label_markers_status.Text = string.Format(TB.L.Phrase["Form_Dialog_EditElement.OKBuiltIn"], (DateTime.Now - startTimePeriod).TotalMilliseconds);
                button_markers_status.Visible = false;
                Object.AxisCaptionParams.CompilePeriod();
            }
            timer_markers_expire.Enabled = true;

        }

        private void checkBox_markers_period_CheckedChanged(object sender, EventArgs e)
        {
            Object.AxisCaptionParams.AutoRange = !Object.AxisCaptionParams.AutoRange;
            if(!Object.AxisCaptionParams.AutoRange)
            {
                textBox_markers_period_end.Enabled = false;
                textBox_markers_period_start.Enabled = false;
            }
        }

        private void radioButton_independence_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_inde.Enabled = radioButton_independence.Checked;
        }

        private void checkBox_addPoints_displ_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_markers.Enabled = checkBox_addPoints_displ.Checked;
            groupBox_names.Enabled = checkBox_addPoints_displ.Checked;
            Object.AxisCaptionParams.Display = checkBox_addPoints_displ.Checked;
        }

        private void button_markers_status_Click(object sender, EventArgs e)
        {
            var periodErrors = GlobalErrorsPeriod.FindAll(p => p.StartsWith("|"));
            var highErrors = GlobalErrorsPeriod.FindAll(p => p.StartsWith("\\"));
            var lowErrors = GlobalErrorsPeriod.FindAll(p => p.StartsWith("/"));
            string[] messages = new string[] {
                TB.L.Phrase["Form_Dialog_EditElement.Log.1"],
                TB.L.Phrase["Form_Dialog_EditElement.Log.2"],
                TB.L.Phrase["Form_Dialog_EditElement.Log.3"],
                TB.L.Phrase["Form_Dialog_EditElement.Log.4"],
                TB.L.Phrase["Form_Dialog_EditElement.Log.5"]
            };
            string res = "";
            res += string.Format(messages[0], startTimePeriod, endTimePeriod, (endTimePeriod - startTimePeriod).TotalSeconds, GlobalErrorsPeriod.Count);

            if (periodErrors.Count == 0) res += messages[1];
            else res += string.Format(messages[2], periodErrors.Count, textBox_markers_period.Text, string.Join("\n", periodErrors.Select(p => "   - " + p.Trim('|'))), Object.AxisCaptionParams.PeriodFormula);

            if (lowErrors.Count == 0) res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Bottom"], 2);
            else res += string.Format(messages[4], lowErrors.Count, TB.L.Phrase["Form_Dialog_EditElement.Bottom"], textBox_markers_period_end.Text, string.Join("\n", lowErrors.Select(p => "   - " + p.Trim('/'))), Object.AxisCaptionParams.LowLimFormula, 2);

            if (highErrors.Count == 0) res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Upper"], 3);
            else res += string.Format(messages[4], highErrors.Count, TB.L.Phrase["Form_Dialog_EditElement.Upper"], textBox_markers_period_start.Text, string.Join("\n", highErrors.Select(p => "   - " + p.Trim('\\'))), Object.AxisCaptionParams.HighLimFormula, 3);

            MessageBox.Show(res, TB.L.Phrase["Form_Dialog_EditElement.Report"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
