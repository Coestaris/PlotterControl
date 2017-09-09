/*=================================\
* ArduinoFileBrowser\FileDirInfo.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.09.2017 20:10
* Last Edited: 06.09.2017 20:52:41
*=================================*/

namespace FileBrowser.Forms
{
    partial class FileDirInfo
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
            this.label_type = new System.Windows.Forms.Label();
            this.label_path = new System.Windows.Forms.Label();
            this.label_size = new System.Windows.Forms.Label();
            this.label_created = new System.Windows.Forms.Label();
            this.groupBox_info = new System.Windows.Forms.GroupBox();
            this.label_hash = new System.Windows.Forms.Label();
            this.groupBox_attr = new System.Windows.Forms.GroupBox();
            this.label_isHidden = new System.Windows.Forms.Label();
            this.label_isSystem = new System.Windows.Forms.Label();
            this.label_isLfn = new System.Windows.Forms.Label();
            this.label_isRO = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.pictureBox_ico = new System.Windows.Forms.PictureBox();
            this.groupBox_info.SuspendLayout();
            this.groupBox_attr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ico)).BeginInit();
            this.SuspendLayout();
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(10, 18);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(26, 13);
            this.label_type.TabIndex = 2;
            this.label_type.Text = "Тип";
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(10, 42);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(31, 13);
            this.label_path.TabIndex = 3;
            this.label_path.Text = "Путь";
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Location = new System.Drawing.Point(10, 67);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(46, 13);
            this.label_size.TabIndex = 4;
            this.label_size.Text = "Размер";
            // 
            // label_created
            // 
            this.label_created.AutoSize = true;
            this.label_created.Location = new System.Drawing.Point(10, 90);
            this.label_created.Name = "label_created";
            this.label_created.Size = new System.Drawing.Size(44, 13);
            this.label_created.TabIndex = 5;
            this.label_created.Text = "Создан";
            // 
            // groupBox_info
            // 
            this.groupBox_info.Controls.Add(this.label_hash);
            this.groupBox_info.Controls.Add(this.label_created);
            this.groupBox_info.Controls.Add(this.label_size);
            this.groupBox_info.Controls.Add(this.label_path);
            this.groupBox_info.Controls.Add(this.label_type);
            this.groupBox_info.Location = new System.Drawing.Point(6, 69);
            this.groupBox_info.Name = "groupBox_info";
            this.groupBox_info.Size = new System.Drawing.Size(266, 134);
            this.groupBox_info.TabIndex = 6;
            this.groupBox_info.TabStop = false;
            this.groupBox_info.Text = "Информация";
            // 
            // label_hash
            // 
            this.label_hash.AutoSize = true;
            this.label_hash.Location = new System.Drawing.Point(10, 114);
            this.label_hash.Name = "label_hash";
            this.label_hash.Size = new System.Drawing.Size(41, 13);
            this.label_hash.TabIndex = 6;
            this.label_hash.Text = "CRC32";
            // 
            // groupBox_attr
            // 
            this.groupBox_attr.Controls.Add(this.label_isLfn);
            this.groupBox_attr.Controls.Add(this.label_isRO);
            this.groupBox_attr.Controls.Add(this.label_isSystem);
            this.groupBox_attr.Controls.Add(this.label_isHidden);
            this.groupBox_attr.Location = new System.Drawing.Point(6, 209);
            this.groupBox_attr.Name = "groupBox_attr";
            this.groupBox_attr.Size = new System.Drawing.Size(266, 86);
            this.groupBox_attr.TabIndex = 8;
            this.groupBox_attr.TabStop = false;
            this.groupBox_attr.Text = "Аттрибуты";
            // 
            // label_isHidden
            // 
            this.label_isHidden.AutoSize = true;
            this.label_isHidden.Location = new System.Drawing.Point(10, 29);
            this.label_isHidden.Name = "label_isHidden";
            this.label_isHidden.Size = new System.Drawing.Size(36, 13);
            this.label_isHidden.TabIndex = 0;
            this.label_isHidden.Text = "isHide";
            // 
            // label_isSystem
            // 
            this.label_isSystem.AutoSize = true;
            this.label_isSystem.Location = new System.Drawing.Point(10, 52);
            this.label_isSystem.Name = "label_isSystem";
            this.label_isSystem.Size = new System.Drawing.Size(48, 13);
            this.label_isSystem.TabIndex = 1;
            this.label_isSystem.Text = "isSystem";
            // 
            // label_isLfn
            // 
            this.label_isLfn.AutoSize = true;
            this.label_isLfn.Location = new System.Drawing.Point(132, 52);
            this.label_isLfn.Name = "label_isLfn";
            this.label_isLfn.Size = new System.Drawing.Size(34, 13);
            this.label_isLfn.TabIndex = 3;
            this.label_isLfn.Text = "isLFN";
            // 
            // label_isRO
            // 
            this.label_isRO.AutoSize = true;
            this.label_isRO.Location = new System.Drawing.Point(132, 29);
            this.label_isRO.Name = "label_isRO";
            this.label_isRO.Size = new System.Drawing.Size(30, 13);
            this.label_isRO.TabIndex = 2;
            this.label_isRO.Text = "isRO";
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(179, 301);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(93, 24);
            this.button_close.TabIndex = 9;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(69, 32);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(35, 13);
            this.label_name.TabIndex = 11;
            this.label_name.Text = "label1";
            // 
            // pictureBox_ico
            // 
            this.pictureBox_ico.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_ico.Name = "pictureBox_ico";
            this.pictureBox_ico.Size = new System.Drawing.Size(51, 51);
            this.pictureBox_ico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ico.TabIndex = 10;
            this.pictureBox_ico.TabStop = false;
            // 
            // FileDirInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.pictureBox_ico);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.groupBox_attr);
            this.Controls.Add(this.groupBox_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FileDirInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileDirInfo";
            this.groupBox_info.ResumeLayout(false);
            this.groupBox_info.PerformLayout();
            this.groupBox_attr.ResumeLayout(false);
            this.groupBox_attr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Label label_size;
        private System.Windows.Forms.Label label_created;
        private System.Windows.Forms.GroupBox groupBox_info;
        private System.Windows.Forms.Label label_hash;
        private System.Windows.Forms.GroupBox groupBox_attr;
        private System.Windows.Forms.Label label_isLfn;
        private System.Windows.Forms.Label label_isRO;
        private System.Windows.Forms.Label label_isSystem;
        private System.Windows.Forms.Label label_isHidden;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.PictureBox pictureBox_ico;
    }
}
