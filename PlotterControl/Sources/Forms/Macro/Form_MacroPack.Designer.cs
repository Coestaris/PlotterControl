/*=================================\
* PlotterControl\Form_MacroPack.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 25.08.2017 22:27
* Last Edited: 27.08.2017 13:35:31
*=================================*/

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
            this.button_create = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_info = new System.Windows.Forms.Button();
            this.label_caption = new System.Windows.Forms.Label();
            this.groupBox_macro = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox_presets = new System.Windows.Forms.GroupBox();
            this.comboBox_presets = new System.Windows.Forms.ComboBox();
            this.button_preset_run = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox_connection = new System.Windows.Forms.GroupBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.comboBox_bd = new System.Windows.Forms.ComboBox();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.groupBox_info = new System.Windows.Forms.GroupBox();
            this.richTextBox_discr = new System.Windows.Forms.RichTextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox_macro.SuspendLayout();
            this.groupBox_presets.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox_connection.SuspendLayout();
            this.groupBox_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_create.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_create.FlatAppearance.BorderSize = 2;
            this.button_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_create.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_create.Location = new System.Drawing.Point(185, 103);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(160, 57);
            this.button_create.TabIndex = 1;
            this.button_create.Text = "Создать новый пак\r\n";
            this.button_create.UseVisualStyleBackColor = false;
            this.button_create.Click += new System.EventHandler(this.button_main_device_col_Click);
            // 
            // button_load
            // 
            this.button_load.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_load.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_load.FlatAppearance.BorderSize = 2;
            this.button_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_load.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_load.Location = new System.Drawing.Point(185, 179);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(160, 57);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Загрузить существующий пак\r\n\r\n\r\n";
            this.button_load.UseVisualStyleBackColor = false;
            this.button_load.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 365);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_create);
            this.tabPage1.Controls.Add(this.button_load);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_info);
            this.tabPage2.Controls.Add(this.label_caption);
            this.tabPage2.Controls.Add(this.groupBox_macro);
            this.tabPage2.Controls.Add(this.groupBox_presets);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(549, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_info
            // 
            this.button_info.Location = new System.Drawing.Point(449, 8);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(90, 34);
            this.button_info.TabIndex = 5;
            this.button_info.Text = "Информация";
            this.button_info.UseVisualStyleBackColor = true;
            this.button_info.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_caption
            // 
            this.label_caption.AutoSize = true;
            this.label_caption.Location = new System.Drawing.Point(14, 19);
            this.label_caption.Name = "label_caption";
            this.label_caption.Size = new System.Drawing.Size(50, 13);
            this.label_caption.TabIndex = 4;
            this.label_caption.Text = "{caption}";
            // 
            // groupBox_macro
            // 
            this.groupBox_macro.Controls.Add(this.label3);
            this.groupBox_macro.Controls.Add(this.label2);
            this.groupBox_macro.Controls.Add(this.button4);
            this.groupBox_macro.Location = new System.Drawing.Point(17, 134);
            this.groupBox_macro.Name = "groupBox_macro";
            this.groupBox_macro.Size = new System.Drawing.Size(526, 196);
            this.groupBox_macro.TabIndex = 3;
            this.groupBox_macro.TabStop = false;
            this.groupBox_macro.Text = "groupBox2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(25, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 57);
            this.button4.TabIndex = 0;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox_presets
            // 
            this.groupBox_presets.Controls.Add(this.comboBox_presets);
            this.groupBox_presets.Controls.Add(this.button_preset_run);
            this.groupBox_presets.Location = new System.Drawing.Point(17, 48);
            this.groupBox_presets.Name = "groupBox_presets";
            this.groupBox_presets.Size = new System.Drawing.Size(526, 80);
            this.groupBox_presets.TabIndex = 2;
            this.groupBox_presets.TabStop = false;
            this.groupBox_presets.Text = "Пресэты";
            // 
            // comboBox_presets
            // 
            this.comboBox_presets.FormattingEnabled = true;
            this.comboBox_presets.Location = new System.Drawing.Point(19, 34);
            this.comboBox_presets.Name = "comboBox_presets";
            this.comboBox_presets.Size = new System.Drawing.Size(411, 21);
            this.comboBox_presets.TabIndex = 2;
            // 
            // button_preset_run
            // 
            this.button_preset_run.Location = new System.Drawing.Point(436, 27);
            this.button_preset_run.Name = "button_preset_run";
            this.button_preset_run.Size = new System.Drawing.Size(75, 32);
            this.button_preset_run.TabIndex = 1;
            this.button_preset_run.Text = "Выполнить";
            this.button_preset_run.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox_connection);
            this.tabPage3.Controls.Add(this.groupBox_info);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(549, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox_connection
            // 
            this.groupBox_connection.Controls.Add(this.button_connect);
            this.groupBox_connection.Controls.Add(this.comboBox_bd);
            this.groupBox_connection.Controls.Add(this.comboBox_port);
            this.groupBox_connection.Location = new System.Drawing.Point(23, 198);
            this.groupBox_connection.Name = "groupBox_connection";
            this.groupBox_connection.Size = new System.Drawing.Size(408, 106);
            this.groupBox_connection.TabIndex = 7;
            this.groupBox_connection.TabStop = false;
            this.groupBox_connection.Text = "Connection";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(254, 33);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(95, 49);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "Подключится";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // comboBox_bd
            // 
            this.comboBox_bd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bd.FormattingEnabled = true;
            this.comboBox_bd.Location = new System.Drawing.Point(44, 61);
            this.comboBox_bd.Name = "comboBox_bd";
            this.comboBox_bd.Size = new System.Drawing.Size(200, 21);
            this.comboBox_bd.TabIndex = 4;
            // 
            // comboBox_port
            // 
            this.comboBox_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(44, 33);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(200, 21);
            this.comboBox_port.TabIndex = 3;
            this.comboBox_port.SelectedIndexChanged += new System.EventHandler(this.comboBox_port_SelectedIndexChanged);
            this.comboBox_port.Click += new System.EventHandler(this.comboBox_port_Click);
            // 
            // groupBox_info
            // 
            this.groupBox_info.Controls.Add(this.richTextBox_discr);
            this.groupBox_info.Controls.Add(this.label_name);
            this.groupBox_info.Location = new System.Drawing.Point(23, 20);
            this.groupBox_info.Name = "groupBox_info";
            this.groupBox_info.Size = new System.Drawing.Size(470, 172);
            this.groupBox_info.TabIndex = 6;
            this.groupBox_info.TabStop = false;
            this.groupBox_info.Text = "Info";
            // 
            // richTextBox_discr
            // 
            this.richTextBox_discr.Location = new System.Drawing.Point(20, 61);
            this.richTextBox_discr.Name = "richTextBox_discr";
            this.richTextBox_discr.ReadOnly = true;
            this.richTextBox_discr.Size = new System.Drawing.Size(415, 95);
            this.richTextBox_discr.TabIndex = 2;
            this.richTextBox_discr.Text = "";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(17, 29);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 13);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "{name}";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "PC Macro Pack|*.pcmpack";
            // 
            // Form_MacroPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(567, 376);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MacroPack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_fromvector";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox_macro.ResumeLayout(false);
            this.groupBox_macro.PerformLayout();
            this.groupBox_presets.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox_connection.ResumeLayout(false);
            this.groupBox_info.ResumeLayout(false);
            this.groupBox_info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button button_create;
        internal System.Windows.Forms.Button button_load;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox_macro;
        private System.Windows.Forms.GroupBox groupBox_presets;
        private System.Windows.Forms.ComboBox comboBox_presets;
        private System.Windows.Forms.Button button_preset_run;
        private System.Windows.Forms.Button button_info;
        private System.Windows.Forms.Label label_caption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.GroupBox groupBox_connection;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.ComboBox comboBox_bd;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.GroupBox groupBox_info;
        private System.Windows.Forms.RichTextBox richTextBox_discr;
        private System.Windows.Forms.Label label_name;
    }
}
