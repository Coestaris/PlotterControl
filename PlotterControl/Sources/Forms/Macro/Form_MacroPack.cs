/*=================================\
* PlotterControl\Form_MacroPack.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 25.08.2017 22:27
* Last Edited: 27.08.2017 13:38:33
*=================================*/

using CWA.Connection;
using CWA.DTP;
using CWA.Printing.Macro;
using System;
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

        private void button_main_device_col_Click(object sender, EventArgs e)
        {
            new Form_Dialog_MacroPackEdit().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                tabControl1.SelectedIndex = 1;
                Main = MacroPack.Load(openFileDialog2.FileName);

                comboBox_presets.Items.Clear();
                comboBox_presets.Items.Add(Main.Samples);

                comboBox_bd.Items.Clear();
                comboBox_bd.Items.AddRange(BdRate.GetNamesInt().Select(p=>p.ToString()).ToArray());
                comboBox_port.Items.Clear();
                comboBox_port.Items.AddRange(SerialPort.GetPortNames());

                comboBox_bd.SelectedItem = Main.PortBD.Num.ToString();
                comboBox_port.SelectedItem = Main.PortName.ToString();

                groupBox_presets.Enabled = false;
                groupBox_macro.Enabled = false;

                richTextBox_discr.Text = Main.Discr;
                label_caption.Text = Main.Caption;
                label_name.Text = Main.Name;
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

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (button_connect.Text == "Отключить")
            {
                Master.CloseConnection();
                groupBox_presets.Enabled = false;
                groupBox_macro.Enabled = false;
                button_connect.Text = "Подключится";
            }
            else
            {
                if (comboBox_bd.Text == "")
                {
                    MessageBox.Show("Укажите скорость соеденения", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Master.CloseConnection();

                groupBox_presets.Enabled = false;
                groupBox_macro.Enabled = false;

                SerialPort port = new SerialPort(comboBox_port.Text, int.Parse(comboBox_bd.Text));
                try
                {
                    port.Open();
                }
                catch
                {
                    MessageBox.Show(string.Format("Не удалось открыть порт {0}", comboBox_port.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Master = new DTPMaster(
                    new SerialPacketReader(port),
                    new SerialPacketWriter(port));
                try
                {
                    if (!Master.Device.Test())
                    {
                        MessageBox.Show("Устройство не ответило на первичный опрос", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Устройство не ответило на первичный опрос", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                groupBox_presets.Enabled = true;
                groupBox_macro.Enabled = false;

                comboBox_bd.Enabled = false;
                comboBox_port.Enabled = false;

                button_connect.Text = "Отключить";
            }
        }
    }
}
