/*=================================\
* PlotterControl\Form_MacroPack.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

using CWA.Connection;
using CWA.DTP;
using CWA.DTP.Plotter;
using CWA.Printing.Macro;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_MacroPack : Form
    {
        public Form_MacroPack()
        {
            InitializeComponent();
        }

        public MacroPack Main;
        public DTPMaster Master;
        public PlotterContent ContentMaster; 

        private void button_main_device_col_Click(object sender, EventArgs e)
        {
            FormTranslator.Translate(new Form_Dialog_MacroPackEdit()).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Main = MacroPack.Load(openFileDialog2.FileName);

                if (!Main.IsEveryMacroCorrect)
                {
                    MessageBox.Show(
                        TB.L.Phrase["Form_MacroPack.UnableToLoadSomeMacro"], 
                        TB.L.Phrase["Form_MacroPack.Error"], 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tabControl1.SelectedIndex = 1;
                comboBox_presets.Items.Clear();
                comboBox_presets.Items.AddRange(Main.Samples.ToArray());
                comboBox_bd.Items.Clear();
                comboBox_bd.Items.AddRange(BdRate.GetNamesInt().Select(p => p.ToString()).ToArray());
                comboBox_port.Items.Clear();
                comboBox_port.Items.AddRange(SerialPort.GetPortNames());
                comboBox_bd.SelectedItem = Main.PortBD.Num.ToString();
                comboBox_port.SelectedItem = Main.PortName.ToString();
                groupBox_presets.Enabled = false;
                groupBox_macro.Enabled = false;
                richTextBox_discr.Text = Main.Discr;
                label_caption.Text = Main.Caption;
                label_name.Text = Main.Name;
                CreateButtons();
            }
        }

        private void comboBox_port_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_port_Click(object sender, EventArgs e)
        {
            comboBox_port.Items.Clear();
            comboBox_port.Items.AddRange(SerialPort.GetPortNames());
            comboBox_port.SelectedItem = Main.PortName.ToString();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            int index = (int)(sender as Button).Tag;
            MessageBox.Show(Main.Elems[index].Path);
        }

        private void CreateButtons()
        {
            Font f = new Font("Cambria", 8.25f);
            int x = 0, y = 0, i = 0;
            panel1.Controls.Clear();
            foreach (var item in Main.Elems)
            {
                var btn = new Button()
                {
                    Size = new Size(71, 57),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Text = item.Options.Caption,
                    Location = new Point(15 + x * 106, 14 + y * 85),
                    Font = f,
                    Tag = i
                };
                btn.Click += OnButtonClick;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.BorderColor = Color.Silver;
                var LabelcharBind = new Label
                {
                    Location = new Point(15 + x * 106, 74 + y * 85),
                    AutoSize = true,
                    Font = f,
                    Text = item.Options.CharBind.ToString()
                };
                var LabelKeyBind = new Label
                {
                    Location = new Point(15 + x * 106, 82 + y * 85),
                    Font = f,
                    AutoSize = true,
                    Text = item.Options.KeyBind.ToString()
                };
                panel1.Controls.AddRange(new Control[] { btn, LabelcharBind, LabelKeyBind });
                if (x % 4 == 0 && x != 0)
                {
                    y++;
                    x = 0;
                } else x++;
                i++;
            }
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (button_connect.Text == TB.L.Phrase["Connection.Disconnect"])
            {
                Master?.CloseConnection();
                groupBox_presets.Enabled = false;
                groupBox_macro.Enabled = false;
                button_connect.Text = TB.L.Phrase["Connection.Connect"];
                comboBox_bd.Enabled = true;
                comboBox_port.Enabled = true;

            }
            else
            {
                if (comboBox_bd.Text == "")
                {
                    MessageBox.Show(
                        TB.L.Phrase["Connection.EnterBDRate"], 
                        TB.L.Phrase["Connection.Error"], 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Master?.CloseConnection();
                groupBox_presets.Enabled = false;
                groupBox_macro.Enabled = false;
                SerialPort port = new SerialPort(comboBox_port.Text, int.Parse(comboBox_bd.Text));
                try
                {
                    port.Open();
                }
                catch
                {
                    MessageBox.Show(
                        string.Format(TB.L.Phrase["Connection.UnableToOpenPort"], comboBox_port.Text),
                        TB.L.Phrase["Connection.Error"], 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Master = new DTPMaster(
                    new SerialPacketReader(port),
                    new SerialPacketWriter(port));
                try
                {
                    if (!Master.Device.Test())
                    {
                        MessageBox.Show(
                            TB.L.Phrase["Connection.DeviceNotAnswered"],
                            TB.L.Phrase["Connection.Error"],
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show(
                        TB.L.Phrase["Connection.DeviceNotAnswered"],
                        TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                groupBox_presets.Enabled = true;
                groupBox_macro.Enabled = true;
                comboBox_bd.Enabled = false;
                comboBox_port.Enabled = false;
                button_connect.Text = TB.L.Phrase["Connection.Disconnect"];
                ContentMaster = new PlotterContent(Master);
                tabControl1.Enabled = false;
                loadingCircle_previewLoad.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button_exit_3_Click(object sender, EventArgs e)
        {
            if (groupBox_presets.Enabled)
                if(MessageBox.Show(
                    TB.L.Phrase["Form_MacroPack.SessianAlreadyActive"],
                    TB.L.Phrase["Form_MacroPack.Exit"],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Master.CloseConnection();
                    Close();
                }

        }

        private void Form_MacroPack_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (groupBox_presets.Enabled)
                if (MessageBox.Show(
                    TB.L.Phrase["Form_MacroPack.SessianAlreadyActive"],
                    TB.L.Phrase["Form_MacroPack.Exit"],
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Master.CloseConnection();
                else e.Cancel = true;
        }

        private void button_reopen_Click(object sender, EventArgs e)
        {
            if (groupBox_presets.Enabled)
                if (MessageBox.Show(
                    TB.L.Phrase["Form_MacroPack.SessianAlreadyActive"],
                    TB.L.Phrase["Form_MacroPack.Exit"],
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Master.CloseConnection();
                    button_connect_Click(null, null);
                }
            button1_Click(null, null);
        }

        private delegate void BackGroundWorkerEndedHandler();

        private void BackGroundWorkerEnded()
        {
            if(InvokeRequired)
            {
                var d = new BackGroundWorkerEndedHandler(BackGroundWorkerEnded);
                Invoke(d);
            }
            else
            {
                loadingCircle_previewLoad.Visible = false;
                tabControl1.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ContentMaster.UploadFlFormatFiles(Main.Elems.Select(p => p.GetMacro().ToFlFormat()).ToArray(), true);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}
