/*=================================\
* PlotterControl\Form_DeviceInfo.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

namespace CnC_WFA
{
    partial class Form_DeviceInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DeviceInfo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_tab2_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Cambria", 12F);
            this.richTextBox1.Location = new System.Drawing.Point(319, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(423, 300);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Red - Free Space, Blue - Used Space";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_tab2_back
            // 
            this.button_tab2_back.BackColor = System.Drawing.Color.White;
            this.button_tab2_back.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab2_back.FlatAppearance.BorderSize = 2;
            this.button_tab2_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab2_back.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab2_back.Location = new System.Drawing.Point(664, 318);
            this.button_tab2_back.Name = "button_tab2_back";
            this.button_tab2_back.Size = new System.Drawing.Size(78, 31);
            this.button_tab2_back.TabIndex = 41;
            this.button_tab2_back.Text = "Назад";
            this.button_tab2_back.UseVisualStyleBackColor = false;
            this.button_tab2_back.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_DeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(754, 354);
            this.Controls.Add(this.button_tab2_back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DeviceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация об устройстве";
            this.Load += new System.EventHandler(this.Form_DeviceInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.RichTextBox richTextBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button button_tab2_back;
    }
}
