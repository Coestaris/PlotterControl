/*=================================\
* PlotterControl\Form_SerialMonitor.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 26.08.2017 16:30:54
*=================================*/

using CWA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_SerialMonitor : Form
    {
        private string[] items = { "getidle", "getcom", "getwork", "getpause", "getp99", "getp91", "getp19", "getp11", "getp29" , "getp21", "setidle{X}", "setpause{X}", "setcom{X}", "setwork{X}", "setp99{X}", "setp91{X}", "setp19{X}", "setp11{X}", "setp29{X}", "setp21{X}", "testcc", "resetd", "getspeed", "resets", "gethelp", "getpin", "getdata"};
        private delegate void Main_port_DataReceived_(string s);
        private int get = 0, set = 0;
        private SerialPort main_port;
        private Button[] buttons;
        private int selButton;
        private bool firstLog = true;
        private DateTime crdate;

        private void LOG(string s)
        {
            if (GlobalOptionsLogPolitics.SaveSerialMonitorLog)
            {
                if (firstLog)
                {
                    crdate = DateTime.Now;
                    firstLog = false;
                    File.Create(GlobalOptionsLogPolitics.CorrectInsert(crdate, GlobalOptionsLogPolitics.OutPutDir + GlobalOptionsLogPolitics.SerialMonitorLogNameFormat)).Close();
                }
                s = s.Replace("\n", string.Empty);
                s = s.Replace("\r", string.Empty);
                File.AppendAllLines(GlobalOptionsLogPolitics.CorrectInsert(crdate, GlobalOptionsLogPolitics.OutPutDir + GlobalOptionsLogPolitics.SerialMonitorLogNameFormat), new string[1] { DateTime.Now + "   :   " + s });
            }
        }

        public Form_SerialMonitor()
        {
            InitializeComponent();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if(button_open.Text == TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Disconnect"])
            {
                main_port.Close();
                button_send.Enabled = false;
                textBox_commandline.Enabled = false;
                comboBox_bd.Enabled = true;
                comboBox_ports.Enabled = true;
                button_open.Text = TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Connect"];
                listBox_log.Items.Add("[CNCWFA]: "+ TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Disconnected"]);
                LOG(TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Disconnected"]);
                return;
            }
            try
            {
                int bd = int.Parse(comboBox_bd.Text);
                main_port = new SerialPort(comboBox_ports.Text, bd);
                main_port.Open();
                listBox_log.Items.Add("[CNCWFA]: " + TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Connected"]);
                LOG(TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Connected"]);
                int visibleItems = listBox_log.ClientSize.Height / listBox_log.ItemHeight;
                listBox_log.TopIndex = Math.Max(listBox_log.Items.Count - visibleItems + 1, 0);
                button_send.Enabled = true;
                textBox_commandline.Enabled = true;
                main_port.DataReceived += Main_port_DataReceived;
                comboBox_bd.Enabled = false;
                comboBox_ports.Enabled = false;
                button_open.Text = TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Disconnect"];
            }
            catch(Exception ee)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["Form_SerialMonitor.ContConnectOrOpenTo"] + " \"" + comboBox_ports.Text + "\"!", TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                listBox_log.Items.Add("[CNCWFA]: " + TranslateBase.CurrentLang.Error["Form_SerialMonitor.Word.ContConnectOrOpenTo"] + " \"" + comboBox_ports.Text + "\"!");
                LOG(TranslateBase.CurrentLang.Error["Form_SerialMonitor.Word.ContConnectOrOpenTo"] + " \"" + comboBox_ports.Text + "\"!. ERR - " +  ee.Message);
                int visibleItems = listBox_log.ClientSize.Height / listBox_log.ItemHeight;
                listBox_log.TopIndex = Math.Max(listBox_log.Items.Count - visibleItems + 1, 0);
            }

        }

        private void comboBox_ports_Click(object sender, EventArgs e)
        {
            comboBox_ports.Items.Clear();
            comboBox_ports.Items.AddRange(SerialPort.GetPortNames());
        }

        private void comboBox_bd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_bd.SelectedIndex!=-1 && comboBox_ports.SelectedIndex != -1) button_open.Enabled = true;
            listBox_log.Items.Add("[CNCWFA]: "+ TranslateBase.CurrentLang.Message["Form_SerialMonitor.BDRateWasSetAs"] + " " + comboBox_bd.Text);
            LOG(TranslateBase.CurrentLang.Message["Form_SerialMonitor.BDRateWasSetAs"] +" " + comboBox_bd.Text);
            int visibleItems = listBox_log.ClientSize.Height / listBox_log.ItemHeight;
            listBox_log.TopIndex = Math.Max(listBox_log.Items.Count - visibleItems + 1, 0);
        }

        private void comboBox_ports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_bd.SelectedIndex != -1 && comboBox_ports.SelectedIndex != -1) button_open.Enabled = true;
            listBox_log.Items.Add("[CNCWFA]: "+ TranslateBase.CurrentLang.Message["Form_SerialMonitor.ComPortWasSetAs"] + " " + comboBox_ports.Text);
            LOG(TranslateBase.CurrentLang.Message["Form_SerialMonitor.ComPortWasSetAs"] + " "+ comboBox_ports.Text);
            int visibleItems = listBox_log.ClientSize.Height / listBox_log.ItemHeight;
            listBox_log.TopIndex = Math.Max(listBox_log.Items.Count - visibleItems + 1, 0);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if(textBox_commandline.Text.Trim() == "")
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["Form_SerialMonitor.EnterCommand"], TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                LOG(TranslateBase.CurrentLang.Error["Form_SerialMonitor.EnterCommand"]);
                return;
            }
            panel_sug.Visible = false;
            listBox_log.Items.Add("["+ TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.You"] + "]" + ": "+ textBox_commandline.Text);
            LOG(TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.MessageSend"] + ": " + textBox_commandline.Text);
            set += 1;
            main_port.Write(textBox_commandline.Text);
            textBox_commandline.Text = "";
            int visibleItems = listBox_log.ClientSize.Height / listBox_log.ItemHeight;
            listBox_log.TopIndex = Math.Max(listBox_log.Items.Count - visibleItems + 1, 0);
        }

        private void Print_PrintChanged_(string a)
        {
            if (InvokeRequired)
            {
                Main_port_DataReceived_ d = new Main_port_DataReceived_(Print_PrintChanged_);
                Invoke(d, new object[] { a });
            }
            else
            {
                var s = main_port.ReadLine();
                listBox_log.Items.Add(string.Format("[{0}]: {1}", comboBox_ports.Text, s));
                LOG(TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.MessageRecive"] + ": " + s.Trim('\n', ' '));
                get += 1;
                int visibleItems = listBox_log.ClientSize.Height / listBox_log.ItemHeight;
                listBox_log.TopIndex = Math.Max(listBox_log.Items.Count - visibleItems + 1, 0);
            }
        }

        private void Main_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Print_PrintChanged_("");
        }

        private void Form_serialmonitor_Load(object sender, EventArgs e)
        {
            checkBox_usehelper.Checked = true;
            listBox_log.IntegralHeight = true;
            listBox_log.HorizontalScrollbar = true;
            comboBox_ports.Items.Clear();
            comboBox_ports.Items.AddRange(SerialPort.GetPortNames());
            comboBox_bd.Text = GlobalOptions.Mainbd.ToString();
            comboBox_ports.Text = GlobalOptions.Mainport;
            LOG(TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.SuccsessInit"]);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox_usehelper.Checked)
            {
                if (!textBox_commandline.Text.Trim().EndsWith(";") && textBox_commandline.Text.Trim() != "")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        textBox_commandline.Text = items[selButton] + ';';
                        if (textBox_commandline.Text.Contains("{X}"))
                        {
                            int a = items[selButton].LastIndexOf("{X}");
                            textBox_commandline.SelectionStart = a;
                            textBox_commandline.SelectionLength = 3;
                            panel_sug.Visible = false;
                            e.SuppressKeyPress = true;
                            return;
                        }
                        panel_sug.Visible = false;
                        e.SuppressKeyPress = true;
                        return;
                    } else if (e.KeyCode == Keys.Up)
                    {
                        if (selButton != 0) selButton -= 1;
                        UpdateSug();
                    } else if (e.KeyCode == Keys.Down)
                    {
                        if (selButton != items.Length - 1) selButton += 1;
                        UpdateSug();
                    } else if (e.KeyCode == Keys.OemSemicolon) panel_sug.Visible = false;
                }
                if (e.KeyCode == Keys.Enter) if (textBox_commandline.Text.EndsWith(";"))
                    {
                        e.SuppressKeyPress = true;
                        button_send.PerformClick();
                    }
            } else if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    button_send.PerformClick();
                }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int Bound(int a)
        {
            if (a >= panel_sug.VerticalScroll.Maximum) return panel_sug.VerticalScroll.Maximum;
            else if (a <= panel_sug.VerticalScroll.Minimum) return panel_sug.VerticalScroll.Minimum;
            else return a; 
        }

        private void UpdateSug()
        {
            for (int i = 0; i <= items.Length - 1; i++)
            {
                if (i == selButton)
                {
                    buttons[i].BackColor = Color.Silver;
                    panel_sug.VerticalScroll.Value = Bound(i * 30 - 40);
                }
                else buttons[i].BackColor = Color.FromArgb(232, 237, 245);
            }
        }

        private void RedrawSug()
        {
            buttons = new Button[items.Length];
            for (int i = 0; i <= items.Length - 1; i++) buttons[i] = null;
            panel_sug.Controls.Clear();
            for (int i = 0; i <= items.Length - 1; i++)
            {
                buttons[i] = new Button();
                panel_sug.Controls.Add(buttons[i]);
                buttons[i].Location = new Point(0, i * 30);
                buttons[i].Size = new Size(150, 30);
                if (i == selButton) buttons[i].BackColor = Color.Silver;
                buttons[i].Text = items[i];
                buttons[i].TextAlign = ContentAlignment.MiddleLeft;
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 0;
                buttons[i].Click += Form_SerialMonitor_Click1;
                buttons[i].Name = i.ToString();
            }
        }

        private void KnowClick(int a)
        {
            textBox_commandline.SelectionStart = textBox_commandline.Text.Length;
            selButton = a;
            UpdateSug();
            textBox_commandline.Focus();
            textBox_commandline.Select();
        }

        private void Form_SerialMonitor_Click1(object sender, EventArgs e)
        {
            KnowClick(int.Parse(((Button)sender).Name));
        }

        private float GetTaminoto(string b)
        {
            var a = textBox_commandline.Text.ToArray();
            var c = a.Intersect(b.ToArray()).ToArray();
            float result = c.Length / ((float)a.Length + b.Length - c.Length);
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox_usehelper.Checked) if (!textBox_commandline.Text.Trim().EndsWith(";") && textBox_commandline.Text.Trim() != "")
                {
                    items = items.OrderByDescending(p => GetTaminoto(p)).ToArray();
                    RedrawSug();
                    UpdateSug();
                    panel_sug.Visible = true;
                    Graphics g = textBox_commandline.CreateGraphics();
                    int hzSize = (int)g.MeasureString(textBox_commandline.Text, textBox_commandline.Font).Width;
                    panel_sug.Location = new Point(textBox_commandline.Location.X + hzSize, panel_sug.Location.Y);
                }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_sug.Visible = false;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            panel_sug.Visible = false;
        }

        private void Form_SerialMonitor_Click(object sender, EventArgs e)
        {
            panel_sug.Visible = false;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            Color c = Color.Black;
            if (listBox_log.Items[e.Index].ToString().StartsWith("[COM"))  c = Color.Red;
            else if (listBox_log.Items[e.Index].ToString().StartsWith("[CNC")) c = Color.Green;
            else if (listBox_log.Items[e.Index].ToString().StartsWith("[" + TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.You"])) c = Color.Blue;
            e.Graphics.DrawString(listBox_log.Items[e.Index].ToString(), new Font("Cambria", 11, FontStyle.Regular), new SolidBrush(c), e.Bounds);
        }

        private void Form_SerialMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(main_port == null) { return; }
            if (main_port.IsOpen)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["Form_SerialMonitor.ExitAndCloseConnection"], TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Error"], MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) { try { main_port.Close(); LOG(TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.Exit"]); } catch { }; }
                
                else e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) if (new FileInfo(saveFileDialog1.FileName).Extension == ".html")
                {
                    LOG(TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.LogSavedAsHTML"] + saveFileDialog1.FileName);
                    List<string> a = new List<string>();
                    a.Add("<!DOCTYPE html>");
                    a.Add("<html lang=\"en\">");
                    a.Add("<head>");
                    a.Add("<title>" + TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.LogFrom"] + ": " + DateTime.Now.ToString() + "</title> ");
                    a.Add("<meta charset=\"utf-8\">");
                    a.Add("<style>");
                    a.Add("p {");
                    a.Add("font-family: Cambria, Calibri, Calibri; font-weight: normal; font-style: normal; text-decoration: none; font-size: 12pt;");
                    a.Add("line-height: 10px;");
                    a.Add("}");
                    a.Add("</style>");
                    a.Add("</head>");
                    a.Add("<body>");
                    a.Add("<div style=\"font-family: Cambria, Calibri, Calibri; line-height: 100%; font-size: 16pt; font-weight:bold; text-align:center;\"><b>" + TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.LogFrom"] + ": " + DateTime.Now.ToString() + " </b></div><br>");
                    a.Add("<div style=\"font-family: Cambria, Calibri, Calibri; line-height: 100%; font-size: 12pt;\">" + TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.PortName"] + ": " + comboBox_ports.Text + "</div> ");
                    a.Add("<div style=\"font-family: Cambria, Calibri, Calibri; line-height: 100%; font-size: 12pt;\">" + TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.BDRate"] + ": " +  comboBox_bd.Text + " </div>");
                    a.Add("<div style=\"font-family: Cambria, Calibri, Calibri; line-height: 100%; font-size: 12pt;\">" + TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.MessageRecived"] + ": " + get + " </div>");
                    a.Add("<div style=\"font-family: Cambria, Calibri, Calibri; line-height: 100%; font-size: 12pt;\">" + TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.MessageSended"] + ": " + set + "</div><br>");
                    a.Add("<p style=\"color:black;\">----------------------</p>");
                    int i = 0;
                    foreach (string b in listBox_log.Items.Cast<string>())
                    {
                        string color = "";
                        if (b.StartsWith("[COM")) color = "red;";
                        else if (b.StartsWith("[CNC")) color = "green;";
                        else if (b.StartsWith("[" + TranslateBase.CurrentLang.Phrase["Form_SerialMonitor.Word.You"])) color = "blue;";
                        var k = b.Split(':');
                        a.Add("<p>" + (i++) + ".    &nbsp;<span style=\"color:" + color + "\"><b>" + k[0] + "</b>:" + k[1] + "</span></p>");
                    }
                    a.Add("<p style=\"color:black;\">----------------------</p>");
                    a.Add("<br><p style=\"text-align:right; color:black;\">"+ TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.AutoGeneratedFile"] + ".</p>");
                    a.Add("<p style=\"text-align:right; color:black;\">Plotter Control (CNCWFA).</p>");
                    a.Add("</body>");
                    a.Add("</html>");
                    File.WriteAllLines(saveFileDialog1.FileName, a.ToArray());
                }
                else
                {
                    File.WriteAllLines(saveFileDialog1.FileName, listBox_log.Items.Cast<string>().ToArray());
                    LOG(TranslateBase.CurrentLang.Message["Form_SerialMonitor.Log.LogSavedAsTXT"] + saveFileDialog1.FileName);
                }
            }
    }
}
