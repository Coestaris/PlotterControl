﻿namespace FileBrowser
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
            this.progressBar1.Size = new System.Drawing.Size(449, 33);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // button_abort
            // 
            this.button_abort.Location = new System.Drawing.Point(367, 90);
            this.button_abort.Name = "button_abort";
            this.button_abort.Size = new System.Drawing.Size(104, 33);
            this.button_abort.TabIndex = 1;
            this.button_abort.Text = "Прервать";
            this.button_abort.UseVisualStyleBackColor = true;
            this.button_abort.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(13, 13);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(10, 13);
            this.label_name.TabIndex = 2;
            this.label_name.Text = " ";
            // 
            // label_percentage
            // 
            this.label_percentage.AutoSize = true;
            this.label_percentage.Location = new System.Drawing.Point(13, 32);
            this.label_percentage.Name = "label_percentage";
            this.label_percentage.Size = new System.Drawing.Size(10, 13);
            this.label_percentage.TabIndex = 3;
            this.label_percentage.Text = " ";
            // 
            // label_timeleft
            // 
            this.label_timeleft.AutoSize = true;
            this.label_timeleft.Location = new System.Drawing.Point(13, 94);
            this.label_timeleft.Name = "label_timeleft";
            this.label_timeleft.Size = new System.Drawing.Size(10, 13);
            this.label_timeleft.TabIndex = 4;
            this.label_timeleft.Text = " ";
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Location = new System.Drawing.Point(13, 114);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(10, 13);
            this.label_speed.TabIndex = 5;
            this.label_speed.Text = " ";
            // 
            // textBox_pcName
            // 
            this.textBox_pcName.Location = new System.Drawing.Point(106, 15);
            this.textBox_pcName.Name = "textBox_pcName";
            this.textBox_pcName.Size = new System.Drawing.Size(310, 20);
            this.textBox_pcName.TabIndex = 6;
            // 
            // button_pick
            // 
            this.button_pick.Location = new System.Drawing.Point(422, 15);
            this.button_pick.Name = "button_pick";
            this.button_pick.Size = new System.Drawing.Size(48, 23);
            this.button_pick.TabIndex = 7;
            this.button_pick.Text = "Выбр";
            this.button_pick.UseVisualStyleBackColor = true;
            this.button_pick.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_deviceName
            // 
            this.textBox_deviceName.Location = new System.Drawing.Point(106, 52);
            this.textBox_deviceName.Name = "textBox_deviceName";
            this.textBox_deviceName.Size = new System.Drawing.Size(364, 20);
            this.textBox_deviceName.TabIndex = 8;
            // 
            // button_receive
            // 
            this.button_receive.Location = new System.Drawing.Point(366, 78);
            this.button_receive.Name = "button_receive";
            this.button_receive.Size = new System.Drawing.Size(104, 33);
            this.button_receive.TabIndex = 10;
            this.button_receive.Text = "Получить";
            this.button_receive.UseVisualStyleBackColor = true;
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
            // 
            // label_newName
            // 
            this.label_newName.Location = new System.Drawing.Point(12, 47);
            this.label_newName.Name = "label_newName";
            this.label_newName.Size = new System.Drawing.Size(88, 35);
            this.label_newName.TabIndex = 11;
            this.label_newName.Text = "Имя файла\r\nна утсройстве";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "file.file";
            this.saveFileDialog.Filter = "Any File|*.*";
            // 
            // ReceiveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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