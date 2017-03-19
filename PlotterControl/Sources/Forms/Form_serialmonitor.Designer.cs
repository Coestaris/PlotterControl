namespace CnC_WFA
{
    partial class Form_SerialMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SerialMonitor));
            this.textBox_commandline = new System.Windows.Forms.TextBox();
            this.comboBox_ports = new System.Windows.Forms.ComboBox();
            this.comboBox_bd = new System.Windows.Forms.ComboBox();
            this.button_open = new System.Windows.Forms.Button();
            this.groupBox_setup = new System.Windows.Forms.GroupBox();
            this.label_portname = new System.Windows.Forms.Label();
            this.label_bdrate = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.listBox_log = new System.Windows.Forms.ListBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.panel_sug = new System.Windows.Forms.Panel();
            this.button_savelog = new System.Windows.Forms.Button();
            this.checkBox_usehelper = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox_setup.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_commandline
            // 
            this.textBox_commandline.Enabled = false;
            this.textBox_commandline.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_commandline.HideSelection = false;
            this.textBox_commandline.Location = new System.Drawing.Point(118, 19);
            this.textBox_commandline.Name = "textBox_commandline";
            this.textBox_commandline.Size = new System.Drawing.Size(452, 25);
            this.textBox_commandline.TabIndex = 1;
            this.textBox_commandline.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox_commandline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // comboBox_ports
            // 
            this.comboBox_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ports.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_ports.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_ports.FormattingEnabled = true;
            this.comboBox_ports.Location = new System.Drawing.Point(512, 25);
            this.comboBox_ports.Name = "comboBox_ports";
            this.comboBox_ports.Size = new System.Drawing.Size(121, 25);
            this.comboBox_ports.TabIndex = 2;
            this.comboBox_ports.SelectedIndexChanged += new System.EventHandler(this.comboBox_ports_SelectedIndexChanged);
            this.comboBox_ports.Click += new System.EventHandler(this.comboBox_ports_Click);
            // 
            // comboBox_bd
            // 
            this.comboBox_bd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_bd.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_bd.FormattingEnabled = true;
            this.comboBox_bd.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.comboBox_bd.Location = new System.Drawing.Point(293, 25);
            this.comboBox_bd.Name = "comboBox_bd";
            this.comboBox_bd.Size = new System.Drawing.Size(121, 25);
            this.comboBox_bd.TabIndex = 3;
            this.comboBox_bd.SelectedIndexChanged += new System.EventHandler(this.comboBox_bd_SelectedIndexChanged);
            // 
            // button_open
            // 
            this.button_open.BackColor = System.Drawing.Color.White;
            this.button_open.Enabled = false;
            this.button_open.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_open.FlatAppearance.BorderSize = 2;
            this.button_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_open.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_open.Location = new System.Drawing.Point(9, 21);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(115, 30);
            this.button_open.TabIndex = 4;
            this.button_open.Text = "Подключится";
            this.button_open.UseVisualStyleBackColor = false;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // groupBox_setup
            // 
            this.groupBox_setup.Controls.Add(this.label_portname);
            this.groupBox_setup.Controls.Add(this.label_bdrate);
            this.groupBox_setup.Controls.Add(this.button_open);
            this.groupBox_setup.Controls.Add(this.comboBox_bd);
            this.groupBox_setup.Controls.Add(this.comboBox_ports);
            this.groupBox_setup.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_setup.Location = new System.Drawing.Point(12, 318);
            this.groupBox_setup.Name = "groupBox_setup";
            this.groupBox_setup.Size = new System.Drawing.Size(649, 62);
            this.groupBox_setup.TabIndex = 5;
            this.groupBox_setup.TabStop = false;
            this.groupBox_setup.Text = "Настройки";
            // 
            // label_portname
            // 
            this.label_portname.AutoSize = true;
            this.label_portname.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_portname.Location = new System.Drawing.Point(420, 28);
            this.label_portname.Name = "label_portname";
            this.label_portname.Size = new System.Drawing.Size(86, 17);
            this.label_portname.TabIndex = 9;
            this.label_portname.Text = "Имя порта: ";
            // 
            // label_bdrate
            // 
            this.label_bdrate.AutoSize = true;
            this.label_bdrate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_bdrate.Location = new System.Drawing.Point(130, 28);
            this.label_bdrate.Name = "label_bdrate";
            this.label_bdrate.Size = new System.Drawing.Size(157, 17);
            this.label_bdrate.TabIndex = 8;
            this.label_bdrate.Text = "Скорость соеденения:";
            // 
            // button_send
            // 
            this.button_send.BackColor = System.Drawing.Color.White;
            this.button_send.Enabled = false;
            this.button_send.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_send.FlatAppearance.BorderSize = 2;
            this.button_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_send.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_send.Location = new System.Drawing.Point(12, 10);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(100, 40);
            this.button_send.TabIndex = 5;
            this.button_send.Text = "Отправить";
            this.button_send.UseVisualStyleBackColor = false;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // listBox_log
            // 
            this.listBox_log.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox_log.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.ItemHeight = 17;
            this.listBox_log.Location = new System.Drawing.Point(12, 56);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_log.Size = new System.Drawing.Size(822, 259);
            this.listBox_log.TabIndex = 6;
            this.listBox_log.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox_log.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox_log.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.White;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(732, 335);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(94, 38);
            this.button_exit.TabIndex = 7;
            this.button_exit.Text = "Выход";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_sug
            // 
            this.panel_sug.AutoScroll = true;
            this.panel_sug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.panel_sug.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_sug.Location = new System.Drawing.Point(118, 43);
            this.panel_sug.Name = "panel_sug";
            this.panel_sug.Size = new System.Drawing.Size(181, 144);
            this.panel_sug.TabIndex = 8;
            this.panel_sug.Visible = false;
            // 
            // button_savelog
            // 
            this.button_savelog.BackColor = System.Drawing.Color.White;
            this.button_savelog.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_savelog.FlatAppearance.BorderSize = 2;
            this.button_savelog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_savelog.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_savelog.Location = new System.Drawing.Point(576, 14);
            this.button_savelog.Name = "button_savelog";
            this.button_savelog.Size = new System.Drawing.Size(126, 32);
            this.button_savelog.TabIndex = 9;
            this.button_savelog.Text = "Сохранить лог";
            this.button_savelog.UseVisualStyleBackColor = false;
            this.button_savelog.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_usehelper
            // 
            this.checkBox_usehelper.AutoSize = true;
            this.checkBox_usehelper.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_usehelper.Location = new System.Drawing.Point(708, 12);
            this.checkBox_usehelper.Name = "checkBox_usehelper";
            this.checkBox_usehelper.Size = new System.Drawing.Size(126, 38);
            this.checkBox_usehelper.TabIndex = 10;
            this.checkBox_usehelper.Text = "Использовать \r\nпомощник";
            this.checkBox_usehelper.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text Files|*.txt|HTML Document|*.html";
            // 
            // Form_SerialMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(838, 383);
            this.Controls.Add(this.checkBox_usehelper);
            this.Controls.Add(this.button_savelog);
            this.Controls.Add(this.panel_sug);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.listBox_log);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.groupBox_setup);
            this.Controls.Add(this.textBox_commandline);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_SerialMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SerialMonitor_FormClosing);
            this.Load += new System.EventHandler(this.Form_serialmonitor_Load);
            this.Click += new System.EventHandler(this.Form_SerialMonitor_Click);
            this.groupBox_setup.ResumeLayout(false);
            this.groupBox_setup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox textBox_commandline;
        internal System.Windows.Forms.ComboBox comboBox_ports;
        internal System.Windows.Forms.ComboBox comboBox_bd;
        internal System.Windows.Forms.Button button_open;
        internal System.Windows.Forms.GroupBox groupBox_setup;
        internal System.Windows.Forms.Button button_send;
        internal System.Windows.Forms.ListBox listBox_log;
        internal System.Windows.Forms.Button button_exit;
        internal System.Windows.Forms.Label label_portname;
        internal System.Windows.Forms.Label label_bdrate;
        internal System.Windows.Forms.Panel panel_sug;
        internal System.Windows.Forms.Button button_savelog;
        internal System.Windows.Forms.CheckBox checkBox_usehelper;
        internal System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}