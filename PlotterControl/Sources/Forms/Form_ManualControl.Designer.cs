/*=================================\
* PlotterControl\Form_ManualControl.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 15.09.2017 22:51:18
*=================================*/

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
            this.button_mc = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_down = new System.Windows.Forms.Button();
            this.button_up = new System.Windows.Forms.Button();
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
            this.label4 = new System.Windows.Forms.Label();
            this.button_startmc = new System.Windows.Forms.Button();
            this.label_mcstep = new System.Windows.Forms.Label();
            this.textBox_step = new System.Windows.Forms.TextBox();
            this.label_mcinfo = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button_turnOff = new System.Windows.Forms.Button();
            this.button_turnOn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // combobox_com
            // 
            this.combobox_com.AllowDrop = true;
            this.combobox_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_com.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.combobox_com.FormattingEnabled = true;
            this.combobox_com.Location = new System.Drawing.Point(104, 22);
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
            this.label_com.Location = new System.Drawing.Point(17, 26);
            this.label_com.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_com.Name = "label_com";
            this.label_com.Size = new System.Drawing.Size(71, 17);
            this.label_com.TabIndex = 1;
            this.label_com.Text = "ComPort: ";
            // 
            // label_bdrate
            // 
            this.label_bdrate.AutoSize = true;
            this.label_bdrate.Location = new System.Drawing.Point(17, 58);
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
            this.combobox_bdrate.Location = new System.Drawing.Point(104, 55);
            this.combobox_bdrate.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_bdrate.Name = "combobox_bdrate";
            this.combobox_bdrate.Size = new System.Drawing.Size(105, 25);
            this.combobox_bdrate.TabIndex = 2;
            this.combobox_bdrate.SelectedIndexChanged += new System.EventHandler(this.combobox_bdrate_SelectedIndexChanged);
            // 
            // button_mc
            // 
            this.button_mc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_mc.Enabled = false;
            this.button_mc.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_mc.FlatAppearance.BorderSize = 2;
            this.button_mc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_mc.Location = new System.Drawing.Point(20, 102);
            this.button_mc.Margin = new System.Windows.Forms.Padding(4);
            this.button_mc.Name = "button_mc";
            this.button_mc.Size = new System.Drawing.Size(86, 36);
            this.button_mc.TabIndex = 5;
            this.button_mc.Text = "Start";
            this.button_mc.UseVisualStyleBackColor = false;
            this.button_mc.Click += new System.EventHandler(this.button_mc_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 25);
            this.comboBox1.TabIndex = 11;
            // 
            // button_down
            // 
            this.button_down.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_down.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_down.FlatAppearance.BorderSize = 2;
            this.button_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_down.Location = new System.Drawing.Point(169, 37);
            this.button_down.Margin = new System.Windows.Forms.Padding(4);
            this.button_down.Name = "button_down";
            this.button_down.Size = new System.Drawing.Size(86, 38);
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
            this.button_up.Location = new System.Drawing.Point(169, 83);
            this.button_up.Margin = new System.Windows.Forms.Padding(4);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(86, 36);
            this.button_up.TabIndex = 6;
            this.button_up.Text = "Up";
            this.button_up.UseVisualStyleBackColor = false;
            this.button_up.Click += new System.EventHandler(this.button_up_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "steps.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "steps.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 89);
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
            this.button_dmove.Location = new System.Drawing.Point(166, 79);
            this.button_dmove.Margin = new System.Windows.Forms.Padding(4);
            this.button_dmove.Name = "button_dmove";
            this.button_dmove.Size = new System.Drawing.Size(86, 36);
            this.button_dmove.TabIndex = 3;
            this.button_dmove.Text = "Send";
            this.button_dmove.UseVisualStyleBackColor = false;
            this.button_dmove.Click += new System.EventHandler(this.button_dmove_Click);
            // 
            // textBox_zmove
            // 
            this.textBox_zmove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_zmove.Location = new System.Drawing.Point(42, 85);
            this.textBox_zmove.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_zmove.Name = "textBox_zmove";
            this.textBox_zmove.Size = new System.Drawing.Size(51, 25);
            this.textBox_zmove.TabIndex = 2;
            this.textBox_zmove.Text = "0";
            // 
            // textBox_xmove
            // 
            this.textBox_xmove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_xmove.Location = new System.Drawing.Point(42, 17);
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
            this.checkBox_savemove.Location = new System.Drawing.Point(177, 21);
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
            this.label_y.Location = new System.Drawing.Point(15, 55);
            this.label_y.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(20, 17);
            this.label_y.TabIndex = 6;
            this.label_y.Text = "Y:";
            // 
            // textBox_ymove
            // 
            this.textBox_ymove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ymove.Location = new System.Drawing.Point(42, 51);
            this.textBox_ymove.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ymove.Name = "textBox_ymove";
            this.textBox_ymove.Size = new System.Drawing.Size(51, 25);
            this.textBox_ymove.TabIndex = 1;
            this.textBox_ymove.Text = "0";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(16, 19);
            this.label_x.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(21, 17);
            this.label_x.TabIndex = 5;
            this.label_x.Text = "X:";
            // 
            // label_z
            // 
            this.label_z.AutoSize = true;
            this.label_z.Location = new System.Drawing.Point(16, 89);
            this.label_z.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_z.Name = "label_z";
            this.label_z.Size = new System.Drawing.Size(20, 17);
            this.label_z.TabIndex = 7;
            this.label_z.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 36);
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
            this.button_startmc.Location = new System.Drawing.Point(196, 80);
            this.button_startmc.Margin = new System.Windows.Forms.Padding(4);
            this.button_startmc.Name = "button_startmc";
            this.button_startmc.Size = new System.Drawing.Size(86, 36);
            this.button_startmc.TabIndex = 10;
            this.button_startmc.Text = "Start";
            this.button_startmc.UseVisualStyleBackColor = false;
            this.button_startmc.Click += new System.EventHandler(this.button_startmc_Click);
            // 
            // label_mcstep
            // 
            this.label_mcstep.AutoSize = true;
            this.label_mcstep.Location = new System.Drawing.Point(33, 36);
            this.label_mcstep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mcstep.Name = "label_mcstep";
            this.label_mcstep.Size = new System.Drawing.Size(114, 17);
            this.label_mcstep.TabIndex = 2;
            this.label_mcstep.Text = "Steps per action: ";
            // 
            // textBox_step
            // 
            this.textBox_step.Location = new System.Drawing.Point(196, 33);
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
            this.label_mcinfo.Location = new System.Drawing.Point(34, 65);
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
            this.button_exit.Location = new System.Drawing.Point(261, 203);
            this.button_exit.Margin = new System.Windows.Forms.Padding(4);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(86, 36);
            this.button_exit.TabIndex = 10;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(340, 184);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button_dmove);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label_z);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label_x);
            this.tabPage1.Controls.Add(this.textBox_ymove);
            this.tabPage1.Controls.Add(this.textBox_zmove);
            this.tabPage1.Controls.Add(this.label_y);
            this.tabPage1.Controls.Add(this.textBox_xmove);
            this.tabPage1.Controls.Add(this.checkBox_savemove);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(332, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.button_up);
            this.tabPage2.Controls.Add(this.button_down);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(332, 154);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.button_startmc);
            this.tabPage3.Controls.Add(this.label_mcinfo);
            this.tabPage3.Controls.Add(this.label_mcstep);
            this.tabPage3.Controls.Add(this.textBox_step);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(332, 154);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage4.Controls.Add(this.button_turnOff);
            this.tabPage4.Controls.Add(this.button_turnOn);
            this.tabPage4.Controls.Add(this.button_mc);
            this.tabPage4.Controls.Add(this.combobox_bdrate);
            this.tabPage4.Controls.Add(this.label_com);
            this.tabPage4.Controls.Add(this.label_bdrate);
            this.tabPage4.Controls.Add(this.combobox_com);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(332, 154);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // button_turnOff
            // 
            this.button_turnOff.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_turnOff.Enabled = false;
            this.button_turnOff.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_turnOff.FlatAppearance.BorderSize = 2;
            this.button_turnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_turnOff.Location = new System.Drawing.Point(239, 70);
            this.button_turnOff.Margin = new System.Windows.Forms.Padding(4);
            this.button_turnOff.Name = "button_turnOff";
            this.button_turnOff.Size = new System.Drawing.Size(86, 36);
            this.button_turnOff.TabIndex = 7;
            this.button_turnOff.Text = "Turn off";
            this.button_turnOff.UseVisualStyleBackColor = false;
            this.button_turnOff.Click += new System.EventHandler(this.button_turnOff_Click);
            // 
            // button_turnOn
            // 
            this.button_turnOn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_turnOn.Enabled = false;
            this.button_turnOn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_turnOn.FlatAppearance.BorderSize = 2;
            this.button_turnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_turnOn.Location = new System.Drawing.Point(239, 26);
            this.button_turnOn.Margin = new System.Windows.Forms.Padding(4);
            this.button_turnOn.Name = "button_turnOn";
            this.button_turnOn.Size = new System.Drawing.Size(86, 36);
            this.button_turnOn.TabIndex = 6;
            this.button_turnOn.Text = "Turn on";
            this.button_turnOn.UseVisualStyleBackColor = false;
            this.button_turnOn.Click += new System.EventHandler(this.button_turnOn_Click);
            // 
            // Form_ManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(369, 249);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_exit);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox combobox_com;
        internal System.Windows.Forms.Label label_com;
        internal System.Windows.Forms.Label label_bdrate;
        internal System.Windows.Forms.ComboBox combobox_bdrate;
        internal System.Windows.Forms.Button button_mc;
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
        internal System.Windows.Forms.Button button_exit;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        internal System.Windows.Forms.Button button_turnOff;
        internal System.Windows.Forms.Button button_turnOn;
    }
}
