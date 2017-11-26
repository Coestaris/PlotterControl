/*=================================\
* PlotterControl\Form_Dialog_Lang.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.08.2017 19:55
* Last Edited: 27.08.2017 14:30:46
*=================================*/

namespace CnC_WFA
{
    partial class Form_Dialog_Lang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dialog_Lang));
            this.button_exit = new System.Windows.Forms.Button();
            this.button_select = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(331, 134);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(83, 35);
            this.button_exit.TabIndex = 118;
            this.button_exit.Text = "Выйти";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_select
            // 
            this.button_select.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_select.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_select.FlatAppearance.BorderSize = 2;
            this.button_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_select.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_select.Location = new System.Drawing.Point(215, 134);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(110, 35);
            this.button_select.TabIndex = 120;
            this.button_select.Text = "Выбрать";
            this.button_select.UseVisualStyleBackColor = false;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_edit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_edit.FlatAppearance.BorderSize = 2;
            this.button_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_edit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_edit.Location = new System.Drawing.Point(12, 134);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(126, 35);
            this.button_edit.TabIndex = 121;
            this.button_edit.Text = "Редактировать";
            this.button_edit.UseVisualStyleBackColor = false;
            // 
            // Form_Dialog_Lang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(426, 177);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.button_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Dialog_Lang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор языка";
            this.Load += new System.EventHandler(this.Form_Dialog_Lang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button button_exit;
        internal System.Windows.Forms.Button button_select;
        internal System.Windows.Forms.Button button_edit;
    }
}
