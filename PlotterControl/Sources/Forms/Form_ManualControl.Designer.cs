namespace CnC_WFA
{
    partial class Form_ManualControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ManualControl));
            this.combobox_com = new System.Windows.Forms.ComboBox();
            this.label_com = new System.Windows.Forms.Label();
            this.label_bdrate = new System.Windows.Forms.Label();
            this.combobox_bdrate = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_mc = new System.Windows.Forms.Button();
            this.Control = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_down = new System.Windows.Forms.Button();
            this.button_up = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_dmove = new System.Windows.Forms.Button();
            this.textBox_zmove = new System.Windows.Forms.TextBox();
            this.textBox_xmove = new System.Windows.Forms.TextBox();
            this.checkBox_savemove = new System.Windows.Forms.CheckBox();
            this.label_y = new System.Windows.Forms.Label();
            this.textBox_ymove = new System.Windows.Forms.TextBox();
            this.label_x = new System.Windows.Forms.Label();
            this.label_z = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_startmc = new System.Windows.Forms.Button();
            this.label_mcstep = new System.Windows.Forms.Label();
            this.textBox_step = new System.Windows.Forms.TextBox();
            this.label_mcinfo = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Control.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // combobox_com
            // 
            this.combobox_com.AllowDrop = true;
            this.combobox_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_com.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.combobox_com.FormattingEnabled = true;
            this.combobox_com.Location = new System.Drawing.Point(95, 23);
            this.combobox_com.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_com.Name = "combobox_com";
            this.combobox_com.Size = new System.Drawing.Size(105, 25);
            this.combobox_com.TabIndex = 0;
            this.combobox_com.SelectedIndexChanged += new System.EventHandler(this.combobox_com_SelectedIndexChanged);
            this.combobox_com.Click += new System.EventHandler(this.combobox_com_Click);
            // 
            // label_com
            // 
            this.label_com.AutoSize = true;
            this.label_com.Location = new System.Drawing.Point(8, 27);
            this.label_com.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_com.Name = "label_com";
            this.label_com.Size = new System.Drawing.Size(71, 17);
            this.label_com.TabIndex = 1;
            this.label_com.Text = "ComPort: ";
            // 
            // label_bdrate
            // 
            this.label_bdrate.AutoSize = true;
            this.label_bdrate.Location = new System.Drawing.Point(204, 27);
            this.label_bdrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_bdrate.Name = "label_bdrate";
            this.label_bdrate.Size = new System.Drawing.Size(57, 17);
            this.label_bdrate.TabIndex = 3;
            this.label_bdrate.Text = "Bdrate: ";
            // 
            // combobox_bdrate
            // 
            this.combobox_bdrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_bdrate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.combobox_bdrate.FormattingEnabled = true;
            this.combobox_bdrate.Items.AddRange(new object[] {
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
            this.combobox_bdrate.Location = new System.Drawing.Point(317, 24);
            this.combobox_bdrate.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_bdrate.Name = "combobox_bdrate";
            this.combobox_bdrate.Size = new System.Drawing.Size(115, 25);
            this.combobox_bdrate.TabIndex = 2;
            this.combobox_bdrate.SelectedIndexChanged += new System.EventHandler(this.combobox_bdrate_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_mc);
            this.groupBox1.Controls.Add(this.combobox_bdrate);
            this.groupBox1.Controls.Add(this.label_bdrate);
            this.groupBox1.Controls.Add(this.combobox_com);
            this.groupBox1.Controls.Add(this.label_com);
            this.groupBox1.Location = new System.Drawing.Point(12, 240);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(570, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // button_mc
            // 
            this.button_mc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_mc.Enabled = false;
            this.button_mc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_mc.FlatAppearance.BorderSize = 2;
            this.button_mc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_mc.Location = new System.Drawing.Point(443, 16);
            this.button_mc.Margin = new System.Windows.Forms.Padding(4);
            this.button_mc.Name = "button_mc";
            this.button_mc.Size = new System.Drawing.Size(119, 38);
            this.button_mc.TabIndex = 5;
            this.button_mc.Text = "Start";
            this.button_mc.UseVisualStyleBackColor = false;
            this.button_mc.Click += new System.EventHandler(this.button_mc_Click);
            // 
            // Control
            // 
            this.Control.Controls.Add(this.groupBox4);
            this.Control.Controls.Add(this.groupBox3);
            this.Control.Controls.Add(this.groupBox2);
            this.Control.Enabled = false;
            this.Control.Location = new System.Drawing.Point(13, 13);
            this.Control.Margin = new System.Windows.Forms.Padding(4);
            this.Control.Name = "Control";
            this.Control.Padding = new System.Windows.Forms.Padding(4);
            this.Control.Size = new System.Drawing.Size(682, 221);
            this.Control.TabIndex = 6;
            this.Control.TabStop = false;
            this.Control.Text = "Control";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_down);
            this.groupBox4.Controls.Add(this.button_up);
            this.groupBox4.Location = new System.Drawing.Point(500, 18);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(159, 191);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tool position";
            // 
            // button_down
            // 
            this.button_down.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_down.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_down.FlatAppearance.BorderSize = 2;
            this.button_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_down.Location = new System.Drawing.Point(30, 49);
            this.button_down.Margin = new System.Windows.Forms.Padding(4);
            this.button_down.Name = "button_down";
            this.button_down.Size = new System.Drawing.Size(111, 38);
            this.button_down.TabIndex = 9;
            this.button_down.Text = "Down";
            this.button_down.UseVisualStyleBackColor = false;
            this.button_down.Click += new System.EventHandler(this.button_down_Click);
            // 
            // button_up
            // 
            this.button_up.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_up.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_up.FlatAppearance.BorderSize = 2;
            this.button_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_up.Location = new System.Drawing.Point(30, 100);
            this.button_up.Margin = new System.Windows.Forms.Padding(4);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(111, 38);
            this.button_up.TabIndex = 6;
            this.button_up.Text = "Up";
            this.button_up.UseVisualStyleBackColor = false;
            this.button_up.Click += new System.EventHandler(this.button_up_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button_dmove);
            this.groupBox3.Controls.Add(this.textBox_zmove);
            this.groupBox3.Controls.Add(this.textBox_xmove);
            this.groupBox3.Controls.Add(this.checkBox_savemove);
            this.groupBox3.Controls.Add(this.label_y);
            this.groupBox3.Controls.Add(this.textBox_ymove);
            this.groupBox3.Controls.Add(this.label_x);
            this.groupBox3.Controls.Add(this.label_z);
            this.groupBox3.Location = new System.Drawing.Point(16, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(196, 191);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MN command";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "steps.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "steps.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "steps.";
            // 
            // button_dmove
            // 
            this.button_dmove.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_dmove.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_dmove.FlatAppearance.BorderSize = 2;
            this.button_dmove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dmove.Location = new System.Drawing.Point(25, 145);
            this.button_dmove.Margin = new System.Windows.Forms.Padding(4);
            this.button_dmove.Name = "button_dmove";
            this.button_dmove.Size = new System.Drawing.Size(111, 38);
            this.button_dmove.TabIndex = 3;
            this.button_dmove.Text = "Send";
            this.button_dmove.UseVisualStyleBackColor = false;
            this.button_dmove.Click += new System.EventHandler(this.button_dmove_Click);
            // 
            // textBox_zmove
            // 
            this.textBox_zmove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_zmove.Location = new System.Drawing.Point(38, 100);
            this.textBox_zmove.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_zmove.Name = "textBox_zmove";
            this.textBox_zmove.Size = new System.Drawing.Size(51, 25);
            this.textBox_zmove.TabIndex = 2;
            this.textBox_zmove.Text = "0";
            // 
            // textBox_xmove
            // 
            this.textBox_xmove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_xmove.Location = new System.Drawing.Point(38, 32);
            this.textBox_xmove.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_xmove.Name = "textBox_xmove";
            this.textBox_xmove.Size = new System.Drawing.Size(51, 25);
            this.textBox_xmove.TabIndex = 0;
            this.textBox_xmove.Text = "0";
            // 
            // checkBox_savemove
            // 
            this.checkBox_savemove.AutoSize = true;
            this.checkBox_savemove.Checked = true;
            this.checkBox_savemove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_savemove.Location = new System.Drawing.Point(15, 125);
            this.checkBox_savemove.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_savemove.Name = "checkBox_savemove";
            this.checkBox_savemove.Size = new System.Drawing.Size(56, 21);
            this.checkBox_savemove.TabIndex = 4;
            this.checkBox_savemove.Text = "Save";
            this.checkBox_savemove.UseVisualStyleBackColor = true;
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(11, 70);
            this.label_y.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(20, 17);
            this.label_y.TabIndex = 6;
            this.label_y.Text = "Y:";
            // 
            // textBox_ymove
            // 
            this.textBox_ymove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ymove.Location = new System.Drawing.Point(38, 66);
            this.textBox_ymove.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ymove.Name = "textBox_ymove";
            this.textBox_ymove.Size = new System.Drawing.Size(51, 25);
            this.textBox_ymove.TabIndex = 1;
            this.textBox_ymove.Text = "0";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(12, 34);
            this.label_x.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(21, 17);
            this.label_x.TabIndex = 5;
            this.label_x.Text = "X:";
            // 
            // label_z
            // 
            this.label_z.AutoSize = true;
            this.label_z.Location = new System.Drawing.Point(12, 104);
            this.label_z.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_z.Name = "label_z";
            this.label_z.Size = new System.Drawing.Size(20, 17);
            this.label_z.TabIndex = 7;
            this.label_z.Text = "Z:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button_startmc);
            this.groupBox2.Controls.Add(this.label_mcstep);
            this.groupBox2.Controls.Add(this.textBox_step);
            this.groupBox2.Controls.Add(this.label_mcinfo);
            this.groupBox2.Location = new System.Drawing.Point(220, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(272, 191);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MC Step control";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "steps.";
            // 
            // button_startmc
            // 
            this.button_startmc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_startmc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_startmc.FlatAppearance.BorderSize = 2;
            this.button_startmc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_startmc.Location = new System.Drawing.Point(153, 145);
            this.button_startmc.Margin = new System.Windows.Forms.Padding(4);
            this.button_startmc.Name = "button_startmc";
            this.button_startmc.Size = new System.Drawing.Size(111, 38);
            this.button_startmc.TabIndex = 10;
            this.button_startmc.Text = "Start";
            this.button_startmc.UseVisualStyleBackColor = false;
            this.button_startmc.Click += new System.EventHandler(this.button_startmc_Click);
            // 
            // label_mcstep
            // 
            this.label_mcstep.AutoSize = true;
            this.label_mcstep.Location = new System.Drawing.Point(10, 25);
            this.label_mcstep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mcstep.Name = "label_mcstep";
            this.label_mcstep.Size = new System.Drawing.Size(114, 17);
            this.label_mcstep.TabIndex = 2;
            this.label_mcstep.Text = "Steps per action: ";
            // 
            // textBox_step
            // 
            this.textBox_step.Location = new System.Drawing.Point(140, 49);
            this.textBox_step.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_step.Name = "textBox_step";
            this.textBox_step.Size = new System.Drawing.Size(38, 25);
            this.textBox_step.TabIndex = 1;
            this.textBox_step.Text = "50";
            // 
            // label_mcinfo
            // 
            this.label_mcinfo.AutoSize = true;
            this.label_mcinfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_mcinfo.Location = new System.Drawing.Point(8, 95);
            this.label_mcinfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mcinfo.Name = "label_mcinfo";
            this.label_mcinfo.Size = new System.Drawing.Size(129, 51);
            this.label_mcinfo.TabIndex = 0;
            this.label_mcinfo.Text = "Стрелки - XY\r\nW - поднять перо\r\n S - опустить перо\r\n";
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Location = new System.Drawing.Point(587, 255);
            this.button_exit.Margin = new System.Windows.Forms.Padding(4);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(111, 38);
            this.button_exit.TabIndex = 10;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_ManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(704, 311);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form_ManualControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ManualControl_FormClosing);
            this.Load += new System.EventHandler(this.Form_ManualControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Control.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox combobox_com;
        internal System.Windows.Forms.Label label_com;
        internal System.Windows.Forms.Label label_bdrate;
        internal System.Windows.Forms.ComboBox combobox_bdrate;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button button_mc;
        internal System.Windows.Forms.GroupBox Control;
        internal System.Windows.Forms.Label label_z;
        internal System.Windows.Forms.Label label_y;
        internal System.Windows.Forms.Label label_x;
        internal System.Windows.Forms.CheckBox checkBox_savemove;
        internal System.Windows.Forms.Button button_dmove;
        internal System.Windows.Forms.TextBox textBox_zmove;
        internal System.Windows.Forms.TextBox textBox_ymove;
        internal System.Windows.Forms.TextBox textBox_xmove;
        internal System.Windows.Forms.Button button_down;
        internal System.Windows.Forms.Button button_up;
        internal System.Windows.Forms.Label label_mcstep;
        internal System.Windows.Forms.TextBox textBox_step;
        internal System.Windows.Forms.Label label_mcinfo;
        internal System.Windows.Forms.Button button_startmc;
        internal System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button button_exit;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
    }
}