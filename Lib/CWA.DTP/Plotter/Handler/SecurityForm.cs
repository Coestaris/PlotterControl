/*=================================\
* CWA.DTP\SecurityForm.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 08.10.2017 19:30
* Last Edited: 08.10.2017 20:51:01
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

namespace CWA.DTP
{
    public partial class SecurityForm : Form
    {
        DTPMaster Master;

        public SecurityForm(DTPMaster master)
        {
            InitializeComponent();
            Master = master;
            radioButton1.Checked = !master.SecurityManager.IsValidationRequired;
            // radioButton2.Checked = master.SecurityManager.IsValidationRequired;

            if (master.SecurityManager.IsValidationRequired)
                radioButton2.Checked = true;

            button2.Enabled = !radioButton1.Checked;
            button3.Enabled = !radioButton1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("????? ??????? ?? ??, ??????? ?? ????? ?????? ?? ?????????? ??? ?????? ??????.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Master.SecurityManager.ResetKey())
                MessageBox.Show("?????? ??? ???????. ????????????? ??????????? ???? ?????.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("?? ??????? ???????? ??????.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private bool usePass = true;

        private void button6_Click(object sender, EventArgs e)
        {
            usePass = !usePass;
            textBox1.Enabled = usePass;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(Master.SecurityManager.ChangeKey(usePass ? new SecurityKey(textBox1.Text) : SecurityKey.DefaultKey, new SecurityKey(textBox2.Text)))
            {
                MessageBox.Show("?????? ??? ??????.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("?? ??????? ??????? ??????.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Master.SecurityManager.SetValidation(radioButton2.Checked);
            button2.Enabled = !radioButton1.Checked;
            button3.Enabled = !radioButton1.Checked;
        }
    }
}
