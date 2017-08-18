/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

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
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* PlotterControl \ Form_Dialog_Assoc.Designer.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 01.07.2017 13:09:58
*
*=================================*/

namespace CnC_WFA
{
    partial class Form_Dialog_Assoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dialog_Assoc));
            this.button_exit = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_selectAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_discr = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(333, 216);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(83, 35);
            this.button_exit.TabIndex = 117;
            this.button_exit.Text = "Выйти";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_save.Enabled = false;
            this.button_save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_save.FlatAppearance.BorderSize = 2;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Location = new System.Drawing.Point(216, 216);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(111, 35);
            this.button_save.TabIndex = 118;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_selectAll
            // 
            this.button_selectAll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_selectAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_selectAll.FlatAppearance.BorderSize = 2;
            this.button_selectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_selectAll.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_selectAll.Location = new System.Drawing.Point(14, 216);
            this.button_selectAll.Name = "button_selectAll";
            this.button_selectAll.Size = new System.Drawing.Size(163, 35);
            this.button_selectAll.TabIndex = 119;
            this.button_selectAll.Text = "Выделить все";
            this.button_selectAll.UseVisualStyleBackColor = false;
            this.button_selectAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_discr);
            this.panel1.Location = new System.Drawing.Point(12, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 69);
            this.panel1.TabIndex = 120;
            // 
            // label_discr
            // 
            this.label_discr.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_discr.Location = new System.Drawing.Point(0, 0);
            this.label_discr.Name = "label_discr";
            this.label_discr.Size = new System.Drawing.Size(401, 72);
            this.label_discr.TabIndex = 0;
            this.label_discr.Text = "Выделете элемент для просмотра описания";
            this.label_discr.Click += new System.EventHandler(this.label_discr_Click);
            // 
            // Form_Dialog_Assoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(426, 263);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_selectAll);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Dialog_Assoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мастер ассоциаций";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Dialog_Assoc_FormClosing);
            this.Load += new System.EventHandler(this.Form_Dialog_Assoc_Load);
            this.Click += new System.EventHandler(this.Form_Dialog_Assoc_Click);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button button_exit;
        internal System.Windows.Forms.Button button_save;
        internal System.Windows.Forms.Button button_selectAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_discr;
    }
}
