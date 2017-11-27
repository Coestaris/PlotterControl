/*=================================\
* PlotterControl\Form_MacroPack.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

namespace CnC_WFA
{
    partial class Form_MacroPack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MacroPack));
            this.button_create = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_exit1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_info = new System.Windows.Forms.Button();
            this.label_caption = new System.Windows.Forms.Label();
            this.groupBox_macro = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_presets = new System.Windows.Forms.GroupBox();
            this.comboBox_presets = new System.Windows.Forms.ComboBox();
            this.button_preset_run = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button_reopen = new System.Windows.Forms.Button();
            this.button_exit_3 = new System.Windows.Forms.Button();
            this.button_back_3 = new System.Windows.Forms.Button();
            this.groupBox_connection = new System.Windows.Forms.GroupBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.comboBox_bd = new System.Windows.Forms.ComboBox();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.groupBox_info = new System.Windows.Forms.GroupBox();
            this.richTextBox_discr = new System.Windows.Forms.RichTextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.loadingCircle_previewLoad = new MRG.Controls.UI.LoadingCircle();
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
            this.button_create.Location = new System.Drawing.Point(199, 111);
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
            this.button_load.Location = new System.Drawing.Point(199, 187);
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
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.tabControl1.Location = new System.Drawing.Point(-8, -25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 412);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage1.Controls.Add(this.button_exit1);
            this.tabPage1.Controls.Add(this.button_create);
            this.tabPage1.Controls.Add(this.button_load);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(580, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // button_exit1
            // 
            this.button_exit1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_exit1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_exit1.FlatAppearance.BorderSize = 2;
            this.button_exit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit1.Location = new System.Drawing.Point(467, 327);
            this.button_exit1.Name = "button_exit1";
            this.button_exit1.Size = new System.Drawing.Size(92, 38);
            this.button_exit1.TabIndex = 2;
            this.button_exit1.Text = "Выйти";
            this.button_exit1.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage2.Controls.Add(this.button_info);
            this.tabPage2.Controls.Add(this.label_caption);
            this.tabPage2.Controls.Add(this.groupBox_macro);
            this.tabPage2.Controls.Add(this.groupBox_presets);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(580, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // button_info
            // 
            this.button_info.BackColor = System.Drawing.Color.White;
            this.button_info.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_info.FlatAppearance.BorderSize = 2;
            this.button_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_info.Location = new System.Drawing.Point(424, 13);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(135, 34);
            this.button_info.TabIndex = 5;
            this.button_info.Text = "Информация";
            this.button_info.UseVisualStyleBackColor = false;
            this.button_info.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_caption
            // 
            this.label_caption.AutoSize = true;
            this.label_caption.Location = new System.Drawing.Point(20, 22);
            this.label_caption.Name = "label_caption";
            this.label_caption.Size = new System.Drawing.Size(67, 17);
            this.label_caption.TabIndex = 4;
            this.label_caption.Text = "{caption}";
            // 
            // groupBox_macro
            // 
            this.groupBox_macro.Controls.Add(this.panel1);
            this.groupBox_macro.Controls.Add(this.label1);
            this.groupBox_macro.Enabled = false;
            this.groupBox_macro.Location = new System.Drawing.Point(16, 139);
            this.groupBox_macro.Name = "groupBox_macro";
            this.groupBox_macro.Size = new System.Drawing.Size(543, 226);
            this.groupBox_macro.TabIndex = 3;
            this.groupBox_macro.TabStop = false;
            this.groupBox_macro.Text = "groupBox2";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 202);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // groupBox_presets
            // 
            this.groupBox_presets.Controls.Add(this.comboBox_presets);
            this.groupBox_presets.Controls.Add(this.button_preset_run);
            this.groupBox_presets.Enabled = false;
            this.groupBox_presets.Location = new System.Drawing.Point(16, 53);
            this.groupBox_presets.Name = "groupBox_presets";
            this.groupBox_presets.Size = new System.Drawing.Size(543, 80);
            this.groupBox_presets.TabIndex = 2;
            this.groupBox_presets.TabStop = false;
            this.groupBox_presets.Text = "Пресеты";
            // 
            // comboBox_presets
            // 
            this.comboBox_presets.FormattingEnabled = true;
            this.comboBox_presets.Location = new System.Drawing.Point(19, 34);
            this.comboBox_presets.Name = "comboBox_presets";
            this.comboBox_presets.Size = new System.Drawing.Size(407, 25);
            this.comboBox_presets.TabIndex = 2;
            // 
            // button_preset_run
            // 
            this.button_preset_run.BackColor = System.Drawing.Color.White;
            this.button_preset_run.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_preset_run.FlatAppearance.BorderSize = 2;
            this.button_preset_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_preset_run.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_preset_run.Location = new System.Drawing.Point(432, 29);
            this.button_preset_run.Name = "button_preset_run";
            this.button_preset_run.Size = new System.Drawing.Size(105, 32);
            this.button_preset_run.TabIndex = 1;
            this.button_preset_run.Text = "Выполнить";
            this.button_preset_run.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage3.Controls.Add(this.button_reopen);
            this.tabPage3.Controls.Add(this.button_exit_3);
            this.tabPage3.Controls.Add(this.button_back_3);
            this.tabPage3.Controls.Add(this.groupBox_connection);
            this.tabPage3.Controls.Add(this.groupBox_info);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(580, 382);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // button_reopen
            // 
            this.button_reopen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_reopen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_reopen.FlatAppearance.BorderSize = 2;
            this.button_reopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_reopen.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_reopen.Location = new System.Drawing.Point(293, 327);
            this.button_reopen.Name = "button_reopen";
            this.button_reopen.Size = new System.Drawing.Size(168, 40);
            this.button_reopen.TabIndex = 10;
            this.button_reopen.Text = "Открыть другой пак";
            this.button_reopen.UseVisualStyleBackColor = false;
            this.button_reopen.Click += new System.EventHandler(this.button_reopen_Click);
            // 
            // button_exit_3
            // 
            this.button_exit_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_exit_3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_exit_3.FlatAppearance.BorderSize = 2;
            this.button_exit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit_3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit_3.Location = new System.Drawing.Point(467, 281);
            this.button_exit_3.Name = "button_exit_3";
            this.button_exit_3.Size = new System.Drawing.Size(92, 40);
            this.button_exit_3.TabIndex = 9;
            this.button_exit_3.Text = "Выйти";
            this.button_exit_3.UseVisualStyleBackColor = false;
            this.button_exit_3.Click += new System.EventHandler(this.button_exit_3_Click);
            // 
            // button_back_3
            // 
            this.button_back_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_back_3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_back_3.FlatAppearance.BorderSize = 2;
            this.button_back_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back_3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back_3.Location = new System.Drawing.Point(467, 327);
            this.button_back_3.Name = "button_back_3";
            this.button_back_3.Size = new System.Drawing.Size(92, 40);
            this.button_back_3.TabIndex = 8;
            this.button_back_3.Text = "Назад";
            this.button_back_3.UseVisualStyleBackColor = false;
            this.button_back_3.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox_connection
            // 
            this.groupBox_connection.Controls.Add(this.button_connect);
            this.groupBox_connection.Controls.Add(this.comboBox_bd);
            this.groupBox_connection.Controls.Add(this.comboBox_port);
            this.groupBox_connection.Location = new System.Drawing.Point(78, 167);
            this.groupBox_connection.Name = "groupBox_connection";
            this.groupBox_connection.Size = new System.Drawing.Size(398, 106);
            this.groupBox_connection.TabIndex = 7;
            this.groupBox_connection.TabStop = false;
            this.groupBox_connection.Text = "Подключение";
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.Color.White;
            this.button_connect.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_connect.FlatAppearance.BorderSize = 2;
            this.button_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_connect.Location = new System.Drawing.Point(251, 35);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(129, 49);
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
            this.comboBox_bd.Size = new System.Drawing.Size(200, 25);
            this.comboBox_bd.TabIndex = 4;
            // 
            // comboBox_port
            // 
            this.comboBox_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(44, 33);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(200, 25);
            this.comboBox_port.TabIndex = 3;
            this.comboBox_port.SelectedIndexChanged += new System.EventHandler(this.comboBox_port_SelectedIndexChanged);
            this.comboBox_port.Click += new System.EventHandler(this.comboBox_port_Click);
            // 
            // groupBox_info
            // 
            this.groupBox_info.Controls.Add(this.richTextBox_discr);
            this.groupBox_info.Controls.Add(this.label_name);
            this.groupBox_info.Location = new System.Drawing.Point(78, 23);
            this.groupBox_info.Name = "groupBox_info";
            this.groupBox_info.Size = new System.Drawing.Size(398, 133);
            this.groupBox_info.TabIndex = 6;
            this.groupBox_info.TabStop = false;
            this.groupBox_info.Text = "Информация";
            // 
            // richTextBox_discr
            // 
            this.richTextBox_discr.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox_discr.Location = new System.Drawing.Point(20, 61);
            this.richTextBox_discr.Name = "richTextBox_discr";
            this.richTextBox_discr.ReadOnly = true;
            this.richTextBox_discr.Size = new System.Drawing.Size(363, 60);
            this.richTextBox_discr.TabIndex = 2;
            this.richTextBox_discr.Text = "";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(17, 29);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(54, 17);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "{name}";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "PC Macro Pack|*.pcmpack";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // loadingCircle_previewLoad
            // 
            this.loadingCircle_previewLoad.Active = true;
            this.loadingCircle_previewLoad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle_previewLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle_previewLoad.BackgroundImage")));
            this.loadingCircle_previewLoad.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle_previewLoad.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle_previewLoad.InnerCircleRadius = 5;
            this.loadingCircle_previewLoad.Location = new System.Drawing.Point(243, 129);
            this.loadingCircle_previewLoad.Name = "loadingCircle_previewLoad";
            this.loadingCircle_previewLoad.NumberSpoke = 12;
            this.loadingCircle_previewLoad.OuterCircleRadius = 11;
            this.loadingCircle_previewLoad.RotationSpeed = 100;
            this.loadingCircle_previewLoad.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle_previewLoad.SpokeThickness = 2;
            this.loadingCircle_previewLoad.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle_previewLoad.TabIndex = 33;
            this.loadingCircle_previewLoad.Text = "loadingCircle2";
            this.loadingCircle_previewLoad.UseWaitCursor = true;
            this.loadingCircle_previewLoad.Visible = false;
            // 
            // Form_MacroPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(567, 376);
            this.Controls.Add(this.loadingCircle_previewLoad);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MacroPack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_fromvector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MacroPack_FormClosing);
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

        public System.Windows.Forms.Button button_create;
        public System.Windows.Forms.Button button_load;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.GroupBox groupBox_macro;
        public System.Windows.Forms.GroupBox groupBox_presets;
        public System.Windows.Forms.ComboBox comboBox_presets;
        public System.Windows.Forms.Button button_preset_run;
        public System.Windows.Forms.Button button_info;
        public System.Windows.Forms.Label label_caption;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.OpenFileDialog openFileDialog2;
        public System.Windows.Forms.GroupBox groupBox_connection;
        public System.Windows.Forms.Button button_connect;
        public System.Windows.Forms.ComboBox comboBox_bd;
        public System.Windows.Forms.ComboBox comboBox_port;
        public System.Windows.Forms.GroupBox groupBox_info;
        public System.Windows.Forms.RichTextBox richTextBox_discr;
        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Button button_exit1;
        public System.Windows.Forms.Button button_exit_3;
        public System.Windows.Forms.Button button_back_3;
        public System.Windows.Forms.Button button_reopen;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public MRG.Controls.UI.LoadingCircle loadingCircle_previewLoad;
    }
}
