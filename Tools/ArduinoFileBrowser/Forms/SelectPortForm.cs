using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class SelectPortForm : Form
    {
        public SelectPortForm()
        {
            InitializeComponent();
        }

        private void UpdateCombobox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox1.Items.Count != 0)
                comboBox1.SelectedIndex = 0;
        }
        private void SelectPortForm_Load(object sender, EventArgs e)
        {
            UpdateCombobox();
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new MainForm() { portName = comboBox1.Text }.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
