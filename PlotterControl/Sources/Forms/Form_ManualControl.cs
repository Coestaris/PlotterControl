﻿/*
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
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_ManualControl : Form
    {
        private ManualControl mc;

        public Form_ManualControl()
        {
            InitializeComponent();
        }

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
            if (button_mc.Text == "Отключится")
            {
                combobox_bdrate.Enabled = true;
                combobox_com.Enabled = true;
                Control.Enabled = false;
                mc.Close();
                button_mc.Text = "Подключится";
                return;
            }
            try
            {
                mc = new ManualControl(combobox_com.Text, int.Parse(combobox_bdrate.Text));
                Control.Enabled = true;
                combobox_bdrate.Enabled = false;
                combobox_com.Enabled = false;
                button_mc.Text = "Отключится";
            }
            catch { MessageBox.Show(string.Format("Can`t open port {0} on {1}", combobox_com.Text, int.Parse(combobox_bdrate.Text))); }
        }

        private void button_dmove_Click(object sender, EventArgs e)
        {
            string command= "";
            int xmove = 0;
            if(!int.TryParse(textBox_xmove.Text,out xmove))
            {
                MessageBox.Show("Invalid X value");
                return;
            }
            int ymove = 0;
            if (!int.TryParse(textBox_ymove.Text, out ymove))
            {
                MessageBox.Show("Invalid Y value");
                return;
            }
            int zmove = 0;
            if (!int.TryParse(textBox_zmove.Text, out zmove))
            {
                MessageBox.Show("Invalid Z value");
                return;
            }
            command = string.Format("{0},{1},{2};",xmove , ymove , zmove);
            try { mc.ToolMove(xmove, ymove, zmove);  }
            catch
            {
                MessageBox.Show("Can`t write Serial Port");
                Control.Enabled = false;
                groupBox1.Enabled = true;

            }
            if (!checkBox_savemove.Checked)
            {
                textBox_xmove.Text = "0";
                textBox_ymove.Text = "0";
                textBox_zmove.Text = "0";
            }
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
            try { mc.Close(); } catch { }
            var a = Process.Start("McClient.exe", string.Format("{0},{1},{2},{3}", combobox_com.Text, combobox_bdrate.Text, textBox_step.Text, "6fb9a28a-d2f1-49db-8a43-8023f6eab1d2"));
            a.WaitForExit();
            mc.ReOpen();
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
            mc.ToolDown();
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            mc.ToolUp();
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
            try { mc.Close(); } catch { };
        }
    }
}
