/*=================================\
* PlotterControl\Form_ManualControl.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 12.09.2017 22:22:11
*=================================*/

using CWA;
using CWA.DTP;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_ManualControl : Form
    {
        //private ManualControl mc;

        public Form_ManualControl()
        {
            InitializeComponent();
        }

        private DTPMaster master;

        private void combobox_com_Click(object sender, EventArgs e)
        {
            combobox_com.Items.Clear();
            foreach (var a in SerialPort.GetPortNames()) combobox_com.Items.Add(a);
            button_mc.Enabled = false;
        }

        private void combobox_bdrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_bdrate.SelectedIndex != -1 && combobox_com.SelectedIndex != -1 && combobox_bdrate.Text != "" && combobox_com.Text != "") button_mc.Enabled = true;
            else button_mc.Enabled = false;
        }

        private void button_mc_Click(object sender, EventArgs e)
        {
            if (button_mc.Text == "����.")
            {
                combobox_bdrate.Enabled = true;
                combobox_com.Enabled = true;
                Control.Enabled = false;
                //mc.Close();
                button_mc.Text = "�����.";
                return;
            }
            try
            {
                var port = new SerialPort(combobox_com.Text, int.Parse(combobox_bdrate.Text.Remove(0, 2)));
                port.Open();
                var Listener = new PacketListener(new SerialPacketReader(port, 3000), new SerialPacketWriter(port));
                master = new DTPMaster(new Sender("Coestar"), Listener);

                Control.Enabled = true;
                combobox_bdrate.Enabled = false;
                combobox_com.Enabled = false;
                button_mc.Text = "����.";
            }
            catch { MessageBox.Show(string.Format("Can`t open port {0} on {1}", combobox_com.Text, int.Parse(combobox_bdrate.Text))); }
        }

        private void button_dmove_Click(object sender, EventArgs e)
        {

            int dx = 0;
            if (!int.TryParse(textBox_xmove.Text, out dx))
            {
                MessageBox.Show("Invalid X value");
                return;
            }
            int dy = 0;
            if (!int.TryParse(textBox_ymove.Text, out dy))
            {
                MessageBox.Show("Invalid Y value");
                return;
            }
            int dz = 0;
            if (!int.TryParse(textBox_zmove.Text, out dz))
            {
                MessageBox.Show("Invalid Z value");
                return;
            }
            ///asldkjaslkjdasd
        }

        private void button_startmc_Click(object sender, EventArgs e)
        {
            button_dmove.Enabled = false;
            textBox_xmove.Enabled = false;
            textBox_ymove.Enabled = false;
            textBox_zmove.Enabled = false;
            checkBox_savemove.Enabled = false;
            button_down.Enabled = false;
            button_up.Enabled = false;
            label_x.Enabled = false;
            label_y.Enabled = false;
            label_z.Enabled = false;
            textBox_step.Enabled = false;
            //try { mc.Close(); } catch { }
            //var a = Process.Start("McClient.exe", string.Format("{0},{1},{2},{3}", combobox_com.Text, combobox_bdrate.Text, textBox_step.Text, "6fb9a28a-d2f1-49db-8a43-8023f6eab1d2"));
            //a.WaitForExit();
            //mc.ReOpen();
            button_dmove.Enabled = true;
            textBox_xmove.Enabled = true;
            textBox_ymove.Enabled = true;
            textBox_zmove.Enabled = true;
            checkBox_savemove.Enabled = true;
            button_down.Enabled = true;
            button_up.Enabled = true;
            label_x.Enabled = true;
            label_y.Enabled = true;
            label_z.Enabled = true;
            textBox_step.Enabled = true;
        }

        private void Form_ManualControl_Load(object sender, EventArgs e)
        {
            combobox_com.Items.Clear();
            foreach (var a in SerialPort.GetPortNames()) combobox_com.Items.Add(a);
            button_mc.Enabled = false;
            combobox_com.Text = GlobalOptions.Mainport;
            combobox_bdrate.Text = GlobalOptions.Mainbd.ToString();
        }

        private void button_down_Click(object sender, EventArgs e)
        {
            //mc.ToolDown();
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            //mc.ToolUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void combobox_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_bdrate.SelectedIndex != -1 && combobox_com.SelectedIndex != -1 && combobox_bdrate.Text != "" && combobox_com.Text != "") button_mc.Enabled = true;
            else button_mc.Enabled = false;
        }

        private void Form_ManualControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try { mc.Close(); } catch { };
        }
    }
}
