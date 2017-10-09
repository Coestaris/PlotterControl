/*=================================\
* CWA.DTP\ValidateForm.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.10.2017 20:19
* Last Edited: 08.10.2017 18:22:30
*=================================*/

using System;
using System.Windows.Forms;

namespace CWA.DTP
{
    public partial class ValidateForm : Form
    {
        DTPMaster Master; 

        public ValidateForm(DTPMaster master)
        {
            Master = master;
            InitializeComponent();
            Master.Device.Test();
            label1.Text = $"Устройство {master.Device.DeviceSender.Name} требует валидацию для продолжения работы. Пожалуйста, введите секретный ключ в данное поле.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Master.SecurityManager.Validate(new SecurityKey(textBox1.Text)))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Не удалось провести валидацию с данным ключем", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void ValidateForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void ValidateForm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("После нажатия на ОК, нажмите на любую кнопку на устройстве для сброса пароля.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Master.SecurityManager.ResetKey())
            {
                MessageBox.Show("Пароль был сброшен. Необходимость авторизации была снята.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show("Не удалось сбросить пароль.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
