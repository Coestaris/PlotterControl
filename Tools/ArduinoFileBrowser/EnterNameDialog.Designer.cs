namespace FileBrowser
{
    partial class EnterNameDialog
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
            this.button_ok = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(343, 39);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(82, 30);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(13, 13);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(412, 20);
            this.textBox_name.TabIndex = 1;
            this.textBox_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_name_KeyDown);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(255, 39);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(82, 30);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // EnterNameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 80);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_ok);
            this.Name = "EnterNameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EnterNameDialog";
            this.Load += new System.EventHandler(this.EnterNameDialog_Load);
            this.Shown += new System.EventHandler(this.EnterNameDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_cancel;
    }
}