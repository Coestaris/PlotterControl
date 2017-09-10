/*=================================\
* ArduinoFileBrowser\ReceiveDialog.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:41
* Last Edited: 10.09.2017 18:27:20
*=================================*/

namespace FileBrowser
{
    partial class ReceiveDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_abort = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.label_percentage = new System.Windows.Forms.Label();
            this.label_timeleft = new System.Windows.Forms.Label();
            this.label_speed = new System.Windows.Forms.Label();
            this.textBox_pcName = new System.Windows.Forms.TextBox();
            this.button_pick = new System.Windows.Forms.Button();
            this.textBox_deviceName = new System.Windows.Forms.TextBox();
            this.button_receive = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_oldName = new System.Windows.Forms.Label();
            this.label_newName = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 51);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(459, 33);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button_abort
            // 
            this.button_abort.BackColor = System.Drawing.Color.White;
            this.button_abort.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_abort.FlatAppearance.BorderSize = 2;
            this.button_abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_abort.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_abort.Location = new System.Drawing.Point(367, 90);
            this.button_abort.Name = "button_abort";
            this.button_abort.Size = new System.Drawing.Size(104, 33);
            this.button_abort.TabIndex = 1;
            this.button_abort.Text = "Прервать";
            this.button_abort.UseVisualStyleBackColor = false;
            this.button_abort.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_name.Location = new System.Drawing.Point(13, 13);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(10, 14);
            this.label_name.TabIndex = 2;
            this.label_name.Text = " ";
            this.label_name.Click += new System.EventHandler(this.label_name_Click);
            // 
            // label_percentage
            // 
            this.label_percentage.AutoSize = true;
            this.label_percentage.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_percentage.Location = new System.Drawing.Point(13, 32);
            this.label_percentage.Name = "label_percentage";
            this.label_percentage.Size = new System.Drawing.Size(10, 14);
            this.label_percentage.TabIndex = 3;
            this.label_percentage.Text = " ";
            this.label_percentage.Click += new System.EventHandler(this.label_percentage_Click);
            // 
            // label_timeleft
            // 
            this.label_timeleft.AutoSize = true;
            this.label_timeleft.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_timeleft.Location = new System.Drawing.Point(13, 94);
            this.label_timeleft.Name = "label_timeleft";
            this.label_timeleft.Size = new System.Drawing.Size(10, 14);
            this.label_timeleft.TabIndex = 4;
            this.label_timeleft.Text = " ";
            this.label_timeleft.Click += new System.EventHandler(this.label_timeleft_Click);
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_speed.Location = new System.Drawing.Point(13, 114);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(10, 14);
            this.label_speed.TabIndex = 5;
            this.label_speed.Text = " ";
            this.label_speed.Click += new System.EventHandler(this.label_speed_Click);
            // 
            // textBox_pcName
            // 
            this.textBox_pcName.Location = new System.Drawing.Point(106, 15);
            this.textBox_pcName.Name = "textBox_pcName";
            this.textBox_pcName.Size = new System.Drawing.Size(310, 22);
            this.textBox_pcName.TabIndex = 6;
            this.textBox_pcName.TextChanged += new System.EventHandler(this.textBox_pcName_TextChanged);
            // 
            // button_pick
            // 
            this.button_pick.BackColor = System.Drawing.Color.White;
            this.button_pick.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pick.FlatAppearance.BorderSize = 2;
            this.button_pick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pick.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_pick.Location = new System.Drawing.Point(422, 15);
            this.button_pick.Name = "button_pick";
            this.button_pick.Size = new System.Drawing.Size(48, 23);
            this.button_pick.TabIndex = 7;
            this.button_pick.Text = "Выбр";
            this.button_pick.UseVisualStyleBackColor = false;
            this.button_pick.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_deviceName
            // 
            this.textBox_deviceName.Location = new System.Drawing.Point(106, 52);
            this.textBox_deviceName.Name = "textBox_deviceName";
            this.textBox_deviceName.Size = new System.Drawing.Size(364, 22);
            this.textBox_deviceName.TabIndex = 8;
            this.textBox_deviceName.TextChanged += new System.EventHandler(this.textBox_deviceName_TextChanged);
            // 
            // button_receive
            // 
            this.button_receive.BackColor = System.Drawing.Color.White;
            this.button_receive.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_receive.FlatAppearance.BorderSize = 2;
            this.button_receive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_receive.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_receive.Location = new System.Drawing.Point(366, 78);
            this.button_receive.Name = "button_receive";
            this.button_receive.Size = new System.Drawing.Size(104, 33);
            this.button_receive.TabIndex = 10;
            this.button_receive.Text = "Получить";
            this.button_receive.UseVisualStyleBackColor = false;
            this.button_receive.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_oldName);
            this.panel1.Controls.Add(this.label_newName);
            this.panel1.Controls.Add(this.button_receive);
            this.panel1.Controls.Add(this.textBox_deviceName);
            this.panel1.Controls.Add(this.button_pick);
            this.panel1.Controls.Add(this.textBox_pcName);
            this.panel1.Font = new System.Drawing.Font("Cambria", 9F);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 123);
            this.panel1.TabIndex = 11;
            // 
            // label_oldName
            // 
            this.label_oldName.Location = new System.Drawing.Point(12, 14);
            this.label_oldName.Name = "label_oldName";
            this.label_oldName.Size = new System.Drawing.Size(88, 35);
            this.label_oldName.TabIndex = 12;
            this.label_oldName.Text = "Новое имя\r\nна ПК";
            this.label_oldName.Click += new System.EventHandler(this.label_oldName_Click);
            // 
            // label_newName
            // 
            this.label_newName.Location = new System.Drawing.Point(12, 47);
            this.label_newName.Name = "label_newName";
            this.label_newName.Size = new System.Drawing.Size(88, 35);
            this.label_newName.TabIndex = 11;
            this.label_newName.Text = "Имя файла\r\nна утсройстве";
            this.label_newName.Click += new System.EventHandler(this.label_newName_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "file.file";
            this.saveFileDialog.Filter = "Any File|*.*";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // ReceiveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(483, 149);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_speed);
            this.Controls.Add(this.label_timeleft);
            this.Controls.Add(this.label_percentage);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_abort);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReceiveDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Диалог получения файлов";
            this.Load += new System.EventHandler(this.ReceiveDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_abort;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_percentage;
        private System.Windows.Forms.Label label_timeleft;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.TextBox textBox_pcName;
        private System.Windows.Forms.Button button_pick;
        public System.Windows.Forms.TextBox textBox_deviceName;
        private System.Windows.Forms.Button button_receive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label_oldName;
        private System.Windows.Forms.Label label_newName;
    }
}
