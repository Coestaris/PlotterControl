/*=================================\
* PlotterControl\Form_Dialog_MacroAddImage.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

using System.Drawing.Imaging;

namespace CnC_WFA
{
    partial class Form_Dialog_MacroAddImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.button_ok = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.textBox_width = new System.Windows.Forms.TextBox();
            this.textBox_height = new System.Windows.Forms.TextBox();
            this.label_path = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.label_width = new System.Windows.Forms.Label();
            this.button_pick = new System.Windows.Forms.Button();
            this.label_width_mm = new System.Windows.Forms.Label();
            this.label_height_mm = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_ok.FlatAppearance.BorderSize = 2;
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ok.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_ok.Location = new System.Drawing.Point(344, 158);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 30);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(10, 11);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(183, 177);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_cancel.FlatAppearance.BorderSize = 2;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_cancel.Location = new System.Drawing.Point(263, 158);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 30);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_path.Location = new System.Drawing.Point(263, 23);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(120, 25);
            this.textBox_path.TabIndex = 3;
            // 
            // textBox_width
            // 
            this.textBox_width.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_width.Location = new System.Drawing.Point(263, 71);
            this.textBox_width.Name = "textBox_width";
            this.textBox_width.Size = new System.Drawing.Size(120, 25);
            this.textBox_width.TabIndex = 4;
            this.textBox_width.Text = "30";
            // 
            // textBox_height
            // 
            this.textBox_height.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_height.Location = new System.Drawing.Point(263, 119);
            this.textBox_height.Name = "textBox_height";
            this.textBox_height.Size = new System.Drawing.Size(120, 25);
            this.textBox_height.TabIndex = 5;
            this.textBox_height.Text = "30";
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_path.Location = new System.Drawing.Point(199, 26);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(42, 17);
            this.label_path.TabIndex = 6;
            this.label_path.Text = "Путь";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_height.Location = new System.Drawing.Point(199, 122);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(58, 17);
            this.label_height.TabIndex = 7;
            this.label_height.Text = "Высота";
            // 
            // label_width
            // 
            this.label_width.AutoSize = true;
            this.label_width.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_width.Location = new System.Drawing.Point(199, 74);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(64, 17);
            this.label_width.TabIndex = 8;
            this.label_width.Text = "Ширина";
            // 
            // button_pick
            // 
            this.button_pick.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_pick.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pick.FlatAppearance.BorderSize = 2;
            this.button_pick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pick.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_pick.Location = new System.Drawing.Point(396, 23);
            this.button_pick.Name = "button_pick";
            this.button_pick.Size = new System.Drawing.Size(23, 25);
            this.button_pick.TabIndex = 9;
            this.button_pick.Text = " ";
            this.button_pick.UseVisualStyleBackColor = false;
            this.button_pick.Click += new System.EventHandler(this.button_pick_Click);
            // 
            // label_width_mm
            // 
            this.label_width_mm.AutoSize = true;
            this.label_width_mm.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_width_mm.Location = new System.Drawing.Point(393, 74);
            this.label_width_mm.Name = "label_width_mm";
            this.label_width_mm.Size = new System.Drawing.Size(28, 17);
            this.label_width_mm.TabIndex = 10;
            this.label_width_mm.Text = "мм";
            // 
            // label_height_mm
            // 
            this.label_height_mm.AutoSize = true;
            this.label_height_mm.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_height_mm.Location = new System.Drawing.Point(393, 122);
            this.label_height_mm.Name = "label_height_mm";
            this.label_height_mm.Size = new System.Drawing.Size(28, 17);
            this.label_height_mm.TabIndex = 11;
            this.label_height_mm.Text = "мм";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form_Dialog_MacroAddImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(431, 200);
            this.Controls.Add(this.label_height_mm);
            this.Controls.Add(this.label_width_mm);
            this.Controls.Add(this.button_pick);
            this.Controls.Add(this.label_width);
            this.Controls.Add(this.label_height);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.textBox_height);
            this.Controls.Add(this.textBox_width);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_ok);
            this.Name = "Form_Dialog_MacroAddImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Dialog_MacroAddImage";
            this.Load += new System.EventHandler(this.Form_Dialog_MacroAddImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button_ok;
        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.Button button_cancel;
        public System.Windows.Forms.TextBox textBox_path;
        public System.Windows.Forms.TextBox textBox_width;
        public System.Windows.Forms.TextBox textBox_height;
        public System.Windows.Forms.Label label_path;
        public System.Windows.Forms.Label label_height;
        public System.Windows.Forms.Label label_width;
        public System.Windows.Forms.Button button_pick;
        public System.Windows.Forms.Label label_width_mm;
        public System.Windows.Forms.Label label_height_mm;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
