namespace CnC_WFA
{
    partial class Form_MacroPack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MacroPack));
            this.button_main_device_col = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_main_device_col
            // 
            this.button_main_device_col.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_main_device_col.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_main_device_col.FlatAppearance.BorderSize = 2;
            this.button_main_device_col.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_main_device_col.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_main_device_col.Location = new System.Drawing.Point(201, 130);
            this.button_main_device_col.Name = "button_main_device_col";
            this.button_main_device_col.Size = new System.Drawing.Size(160, 57);
            this.button_main_device_col.TabIndex = 1;
            this.button_main_device_col.Text = "Создать новый пак\r\n";
            this.button_main_device_col.UseVisualStyleBackColor = false;
            this.button_main_device_col.Click += new System.EventHandler(this.button_main_device_col_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(201, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить существующий пак\r\n\r\n\r\n";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form_MacroPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(567, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_main_device_col);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MacroPack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_fromvector";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button button_main_device_col;
        internal System.Windows.Forms.Button button1;
    }
}