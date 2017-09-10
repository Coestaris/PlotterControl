/*=================================\
* ArduinoFileBrowser\EnterNameDialog.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:41
* Last Edited: 10.09.2017 18:25:31
*=================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class EnterNameDialog : Form
    {
        public EnterNameDialog()
        {
            InitializeComponent();
        }

        public string Value { get; set; }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Value = textBox_name.Text;
            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EnterNameDialog_Load(object sender, EventArgs e)
        {
            textBox_name.Focus();
        }

        private void EnterNameDialog_Shown(object sender, EventArgs e)
        {
            textBox_name.Focus();
        }

        private void textBox_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_ok.PerformClick();
        }
    }
}
