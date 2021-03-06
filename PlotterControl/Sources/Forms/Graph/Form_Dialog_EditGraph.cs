/*=================================\
* PlotterControl\Form_Dialog_EditGraph.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_Dialog_EditGraph : Form
    {
        public Form_Dialog_EditGraph()
        {
            InitializeComponent();
        }

        private Graph Object;

        private List<string> GlobalErrors, GlobalErrorsLims, GlobalErrorsPeriod;

        private string CurrentCompString;

        private DateTime startTime, endTime, startTimePeriod, endTimePeriod;

        private string CurrentCompStringLow, CurrentCompStringHigh;

        public Form_Graph FormParent { get; internal set; }

        private Button[] Buttons;

        private Color SelectedButtonColor = Color.FromArgb(5, 92, 199);

        private Color DefaultButtonColor = Color.FromArgb(4, 60, 130);

        public Form_Dialog_EditGraph(Graph editing)
        {
            InitializeComponent();
            Object = editing;
            Text = string.Format(TB.L.Phrase["Form_Graph.Editing"], Object.Name);
        }

        private void Form_Dialog_EditGraph_Load(object sender, EventArgs e)
        {
            Buttons = new Button[]
            {
                button_data,
                button_display,
                button_markers
            };

            textBox_name.Text = Object.Name;
            if (Object.DataSource.GetType() == typeof(FormulaDataSource))
            {
                radioButton_data_formula.Checked = true;
                var ds = Object.DataSource as FormulaDataSource;
                textBox_data_formula_formula.Text = ds.Formula;
                textBox_data_formula_start.Text = ds.LowLimFormula;
                textBox_data_formula_end.Text = ds.HighLimFormula;
                CurrentCompString = ds.Formula;
                CurrentCompStringHigh = ds.HighLimFormula;
                CurrentCompStringLow = ds.LowLimFormula;
            }

            comboBox_display_penstyle.Items.AddRange(Enum.GetNames(typeof(PenStyles)));
            comboBox_display_penstyle.Text = Object.PStyle.ToString();
            checkBox_display_display.Checked = Object.Display;
            textBox_display_width.Text = Object.MainPen.Width.ToString();
            colorDialog1.Color = Object.MainPen.Color;

            checkBox_markers_use.Checked = Object.Markers.Use;
            radioButton_markers_period.Checked = Object.Markers.UsePeriodic;
            radioButton_markers_inpoints.Checked = !Object.Markers.UsePeriodic;

            comboBox_markers_type.Items.AddRange(Enum.GetNames(typeof(MarkerType)));
            comboBox_markers_type.Text = Object.Markers.Type.ToString();
            colorDialog2.Color = Object.Markers.Color;
            textBox_markers_size.Text = Object.Markers.Size.ToString();
            checkBox_markers_period.Checked = Object.Markers.AutoLims;

            textBox_markers_period.Text = Object.Markers.PeriodFormula;
            textBox_markers_period_start.Text = Object.Markers.LowLimFormula;
            textBox_markers_period_end.Text = Object.Markers.HighLimFormula;

            colorDialog1.Color = Object.MainPen.Color;
            SetDisplayColorProbe();
            SetMarkerColorProbe();

            if (!checkBox_markers_period.Checked)
            {
                textBox_markers_period_start.Text = textBox_data_formula_start.Text;
                textBox_markers_period_end.Text = textBox_data_formula_end.Text;
            }
        }

        private void SetDisplayColorProbe()
        {
            Bitmap bmp = new Bitmap(50, 50);
            using (Graphics gr = Graphics.FromImage(bmp)) gr.FillRectangle(new SolidBrush(colorDialog1.Color), new RectangleF(0, 0, 50, 50));
            Image img = pictureBox_display_color.Image;
            pictureBox_display_color.Image = bmp;
            if (img != null) img.Dispose();
        }

        private void SetMarkerColorProbe()
        {
            Bitmap bmp = new Bitmap(50, 50);
            using (Graphics gr = Graphics.FromImage(bmp)) gr.FillRectangle(new SolidBrush(colorDialog2.Color), new RectangleF(0, 0, 50, 50));
            Image img = pictureBox_markers_color.Image;
            pictureBox_markers_color.Image = bmp;
            if (img != null) img.Dispose();
        }

        private void button_data_formula_compile_Click(object sender, EventArgs e)
        {
            var ds = Object.DataSource as FormulaDataSource;
            string LastCompString = ds.Formula;
            string LastCompStringLow = ds.LowLimFormula;
            string LastCompStringHigh = ds.HighLimFormula;

            ds.Formula = CurrentCompString;
            ds.HighLimFormula = CurrentCompStringHigh;
            ds.LowLimFormula = CurrentCompStringLow;
            startTime = DateTime.Now;
            GlobalErrors = ds.Compile();
            GlobalErrorsLims = ds.CompileRange();
            if (GlobalErrorsLims !=null || GlobalErrors != null)
            {
                panel_data_formula_status.Visible = true;
                panel_data_formula_status.BackColor = Color.FromArgb(255, 74, 74);
                label_data_formula_status.Text = string.Format(TB.L.Phrase["Form_Dialog_EditElement.FoundErrors"], (GlobalErrors?.Count == null ? 0 : GlobalErrors?.Count) + (GlobalErrorsLims?.Count == null ? 0 : GlobalErrorsLims?.Count));
                button_data_formula_status_more.Visible = true;
                ds.Formula = LastCompString;
                ds.Formula = LastCompString;
                ds.LowLimFormula = LastCompStringLow;
                ds.HighLimFormula = LastCompStringHigh;
                ds.Compile();
                ds.CompileRange();
                endTime = DateTime.Now;
            }
            else
            {
                panel_data_formula_status.Visible = true;
                panel_data_formula_status.BackColor = Color.FromArgb(0, 255, 0);
                label_data_formula_status.Text = string.Format(TB.L.Phrase["Form_Dialog_EditElement.OKBuiltIn"], (DateTime.Now - startTime).TotalMilliseconds);
                button_data_formula_status_more.Visible = false;
                Object.ResetPreRender();
                if (Object.Markers.UsePeriodic && Object.Markers.AutoLims)
                {
                    Object.Markers.LowLimFormula = ds.LowLimFormula;
                    Object.Markers.HighLimFormula = ds.HighLimFormula;
                    textBox_markers_period.Text = Object.Markers.PeriodFormula;
                    textBox_markers_period_start.Text = Object.Markers.LowLimFormula;
                }
            }
            timer_data_forumla_expire.Enabled = true;
            Object.DataSource = ds;
        }

        private void button_data_formula_status_more_Click(object sender, EventArgs e)
        {
            var ds = Object.DataSource as FormulaDataSource;
            string[] messages = new string[] {
                TB.L.Phrase["Form_Graph.Log.1"],
                TB.L.Phrase["Form_Graph.Log.2"],
                TB.L.Phrase["Form_Graph.Log.3"],
                TB.L.Phrase["Form_Graph.Log.4"],
                TB.L.Phrase["Form_Graph.Log.5"]
            }; ;
            string res = "";
            res += string.Format(messages[0], startTime, endTime, (endTime - startTime).TotalSeconds, (GlobalErrors?.Count == null ? 0 : GlobalErrors?.Count) + (GlobalErrorsLims?.Count == null ? 0 : GlobalErrorsLims?.Count));
            if (GlobalErrors == null) res += messages[1];
            else res += string.Format(messages[2], GlobalErrors.Count, CurrentCompString, string.Join("\n", GlobalErrors.Select(p => "   - " + p)), ds.Formula);

            if (GlobalErrorsLims == null)
            {
                res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Word.Bottom"], 2);
                res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Word.Upper"], 3);
            }
            else
            {
                if (GlobalErrorsLims.FindAll(p => p.StartsWith("/")).Count() == 0) res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Word.Bottom"], 2);
                else
                {
                    var a = GlobalErrorsLims.FindAll(p => p.StartsWith("/")).ToArray();
                    res += string.Format(messages[4], a.Length, TB.L.Phrase["Form_Dialog_EditElement.Word.Bottom"], CurrentCompStringLow, string.Join("\n", a.Select(p => "   - " + p.Trim('/'))), ds.LowLimFormula, 2);
                }
                if (GlobalErrorsLims.FindAll(p => p.StartsWith("\\")).Count() == 0) res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Word.Upper"], 3);
                else
                {
                    var a = GlobalErrorsLims.FindAll(p => p.StartsWith("\\")).ToArray();
                    res += string.Format(messages[4], a.Length, TB.L.Phrase["Form_Dialog_EditElement.Word.Upper"], CurrentCompStringLow, string.Join("\n", a.Select(p => "   - " + p.Trim('\\'))), ds.HighLimFormula, 3);
                }
            }
            MessageBox.Show(res, TB.L.Phrase["Form_Dialog_EditElement.Report"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer_data_forumla_expire_Tick(object sender, EventArgs e)
        {
            timer_data_forumla_expire.Enabled = false;
            panel_data_formula_status.Visible = false;
            button_data_formula_status_more.Visible = false;
        }

        private void button_data_formula_expand_Click(object sender, EventArgs e)
        {
            if (!richTextBox_data_formula_add.Visible)
            {
                richTextBox_data_formula_add.Visible = true;
                richTextBox_data_formula_add.Text = textBox_data_formula_formula.Text;
            } else
            {
                richTextBox_data_formula_add.Visible = false;
                textBox_data_formula_formula.Text = richTextBox_data_formula_add.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e) => Close();

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            Object.Name = textBox_name.Text;
            Text = string.Format(TB.L.Phrase["Form_Graph.Editing"], Object.Name);
        }

        private void HighLightButton(int index)
        {
            for (int i = 0; i < Buttons.Length; i++)
                Buttons[i].BackColor = i == index ? SelectedButtonColor : DefaultButtonColor;
            tabControl_main.SelectedIndex = index;
        }

        private void Form_Dialog_EditGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Object.DataSource.GetType() == typeof(FormulaDataSource))
            {
                var ds = Object.DataSource as FormulaDataSource;
                string res = "";
                if (CurrentCompString != ds.Formula) res += string.Format(TB.L.Phrase["Form_Graph.ExitLog.1"], CurrentCompString, ds.Formula);
                if (CurrentCompStringHigh != ds.HighLimFormula) res += string.Format(TB.L.Phrase["Form_Graph.ExitLog.2"], CurrentCompStringLow, ds.HighLimFormula);
                if (CurrentCompStringLow != ds.LowLimFormula) res += string.Format(TB.L.Phrase["Form_Graph.ExitLog.3"], CurrentCompStringHigh, ds.LowLimFormula);
                if (textBox_markers_period.Text != Object.Markers.PeriodFormula) res += string.Format(TB.L.Phrase["Form_Graph.ExitLog.4"], textBox_markers_period.Text, Object.Markers.PeriodFormula);
                if (textBox_markers_period_start.Text != Object.Markers.LowLimFormula) res += string.Format(TB.L.Phrase["Form_Graph.ExitLog.5"], textBox_markers_period_start.Text, Object.Markers.LowLimFormula);
                if (textBox_markers_period_end.Text != Object.Markers.HighLimFormula) res += string.Format(TB.L.Phrase["Form_Graph.ExitLog.6"], textBox_markers_period_end.Text, Object.Markers.HighLimFormula);
                if(res.Length != 0) MessageBox.Show(res, TB.L.Phrase["Form_Graph.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                Object.DataSource = ds;
            }
            Object.MainPen = new Pen(colorDialog1.Color, float.Parse(textBox_display_width.Text));
            Object.Display = checkBox_display_display.Checked;
            Object.PStyle = (PenStyles)Enum.Parse(typeof(PenStyles), comboBox_display_penstyle.Text);
            
            Object.ResetPreRender();
            Object.Markers.GetPoints();
           
        }

        private void button_display_color_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SetDisplayColorProbe();
                label_display_color_rgb.Text = string.Format(TB.L.Phrase["Form_Dialog_EditElement.RGB"], colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
            }
        }

        private void checkBox_markers_period_CheckedChanged(object sender, EventArgs e)
        {
            Object.Markers.AutoLims = checkBox_markers_period.Checked;
            textBox_markers_period_start.Enabled = !checkBox_markers_period.Checked;
            textBox_markers_period_end.Enabled = !checkBox_markers_period.Checked;
            if(!checkBox_markers_period.Checked)
            {
                textBox_markers_period_start.Text = textBox_data_formula_start.Text;
                textBox_markers_period_end.Text = textBox_data_formula_end.Text;
            }
        }

        private void checkBox_markers_use_CheckedChanged(object sender, EventArgs e)
        {
            Object.Markers.Use = checkBox_markers_use.Checked;
            groupBox_markers_display.Enabled = checkBox_markers_use.Checked;
            groupBox_markers_params.Enabled = checkBox_markers_use.Checked;
        }

        private void button_markers_status_Click(object sender, EventArgs e)
        {
            var periodErrors = GlobalErrorsPeriod.FindAll(p => p.StartsWith("|"));
            var highErrors = GlobalErrorsPeriod.FindAll(p => p.StartsWith("\\"));
            var lowErrors = GlobalErrorsPeriod.FindAll(p => p.StartsWith("/"));

            var ds = Object.DataSource as FormulaDataSource;
            string[] messages = new string[] {
                TB.L.Phrase["Form_Graph.Log1.1"],
                TB.L.Phrase["Form_Graph.Log1.2"],
                TB.L.Phrase["Form_Graph.Log1.3"],
                TB.L.Phrase["Form_Graph.Log1.4"],
                TB.L.Phrase["Form_Graph.Log1.5"]
            };
            string res = "";
            res += string.Format(messages[0], startTimePeriod, endTimePeriod, (endTimePeriod - startTimePeriod).TotalSeconds, GlobalErrorsPeriod.Count);

            if (periodErrors.Count == 0) res += messages[1];
            else res += string.Format(messages[2], periodErrors.Count, textBox_markers_period.Text, string.Join("\n", periodErrors.Select(p => "   - " + p.Trim('|'))), Object.Markers.PeriodFormula);

            if (lowErrors.Count == 0) res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Word.Bottom"], 2);
            else res += string.Format(messages[4], lowErrors.Count, TB.L.Phrase["Form_Dialog_EditElement.Word.Bottom"], textBox_markers_period_end.Text, string.Join("\n", lowErrors.Select(p => "   - " + p.Trim('/'))), Object.Markers.LowLimFormula, 2);

            if (highErrors.Count == 0) res += string.Format(messages[3], TB.L.Phrase["Form_Dialog_EditElement.Word.Upper"], 3);
            else res += string.Format(messages[4], highErrors.Count, TB.L.Phrase["Form_Dialog_EditElement.Word.Upper"], textBox_markers_period_start.Text, string.Join("\n", highErrors.Select(p => "   - " + p.Trim('\\'))), Object.Markers.HighLimFormula, 3);

            MessageBox.Show(res, TB.L.Phrase["Form_Dialog_EditElement.Report"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer_markers_expire_Tick(object sender, EventArgs e)
        {
            panel_markers_status.Visible = false;
            timer_markers_expire.Enabled = false;
        }

        private void radioButton_markers_period_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_period.Enabled = radioButton_markers_period.Checked;
            groupBox_points.Enabled = !radioButton_markers_period.Checked;
        }

        private void button_markers_compile_Click(object sender, EventArgs e)
        {
            startTimePeriod = DateTime.Now;

            if (Object.Markers.UsePeriodic)
            {
                string LowCompString = Object.Markers.LowLimFormula;
                string HighCompString = Object.Markers.HighLimFormula;
                string PeriodCompString = Object.Markers.PeriodFormula;
                Object.Markers.LowLimFormula = textBox_markers_period_start.Text;
                Object.Markers.HighLimFormula = textBox_markers_period_end.Text;
                Object.Markers.PeriodFormula = textBox_markers_period.Text;
                GlobalErrorsPeriod = Object.Markers.CompilePeriod();
                if (GlobalErrorsPeriod != null)
                {
                    panel_markers_status.Visible = true;
                    panel_markers_status.BackColor = Color.FromArgb(255, 74, 74);
                    label_markers_status.Text = string.Format(TB.L.Phrase["Form_Dialog_EditElement.FoundErrors"], (GlobalErrorsPeriod?.Count == null ? 0 : GlobalErrorsPeriod?.Count));
                    button_markers_status.Visible = true;
                    Object.Markers.LowLimFormula = LowCompString;
                    Object.Markers.HighLimFormula = HighCompString;
                    Object.Markers.PeriodFormula = PeriodCompString;
                    Object.Markers.CompilePeriod();
                    endTimePeriod = DateTime.Now;
                }
                else
                {
                    panel_markers_status.Visible = true;
                    panel_markers_status.BackColor = Color.FromArgb(0, 255, 0);
                    label_markers_status.Text = string.Format(TB.L.Phrase["Form_Dialog_EditElement.OKBuiltIn"], (DateTime.Now - startTimePeriod).TotalMilliseconds);
                    button_markers_status.Visible = false;
                    Object.Markers.CompilePeriod();
                }
                timer_markers_expire.Enabled = true;
            }
        }

        private void button_data_Click(object sender, EventArgs e) => HighLightButton(0);

        private void button_display_Click(object sender, EventArgs e) => HighLightButton(1);

        private void button_markers_Click(object sender, EventArgs e) => HighLightButton(2);

        private void textBox_markers_period_TextChanged(object sender, EventArgs e) => Object.Markers.PeriodFormula = textBox_markers_period.Text;

        private void textBox_markers_end_TextChanged(object sender, EventArgs e) => Object.Markers.HighLimFormula = textBox_markers_period_end.Text;

        private void textBox_markers_period_start_TextChanged(object sender, EventArgs e) => Object.Markers.LowLimFormula = textBox_markers_period_start.Text;

        private void checkBox_display_display_CheckedChanged(object sender, EventArgs e) => groupBox1.Enabled = checkBox_display_display.Checked;

        private void textBox_data_formula_start_TextChanged(object sender, EventArgs e) => CurrentCompStringLow = textBox_data_formula_start.Text;

        private void textBox_data_formula_end_TextChanged(object sender, EventArgs e) => CurrentCompStringHigh = textBox_data_formula_end.Text;

        private void textBox_data_formula_formula_TextChanged(object sender, EventArgs e) => CurrentCompString = textBox_data_formula_formula.Text;

        private void richTextBox_data_formula_add_TextChanged(object sender, EventArgs e) => CurrentCompString = richTextBox_data_formula_add.Text;
    }
}
