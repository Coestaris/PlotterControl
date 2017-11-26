/*=================================\
* PlotterControl\Form_SerialMonitor.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 11.09.2017 21:13:11
*=================================*/

namespace CnC_WFA
{
    partial class Form_SerialMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SerialMonitor));
            this.textBox_size_b1 = new System.Windows.Forms.TextBox();
            this.textBox_size_b2 = new System.Windows.Forms.TextBox();
            this.checkBox_size = new System.Windows.Forms.CheckBox();
            this.textBox_command_b1 = new System.Windows.Forms.TextBox();
            this.textBox_command_b2 = new System.Windows.Forms.TextBox();
            this.comboBox_command = new System.Windows.Forms.ComboBox();
            this.textBox_sender_b2 = new System.Windows.Forms.TextBox();
            this.textBox_sender_b1 = new System.Windows.Forms.TextBox();
            this.textBox_sender_b4 = new System.Windows.Forms.TextBox();
            this.textBox_sender_b3 = new System.Windows.Forms.TextBox();
            this.textBox_sender_b6 = new System.Windows.Forms.TextBox();
            this.textBox_sender_b5 = new System.Windows.Forms.TextBox();
            this.textBox_sender_b8 = new System.Windows.Forms.TextBox();
            this.textBox_sender_b7 = new System.Windows.Forms.TextBox();
            this.comboBox_sender = new System.Windows.Forms.ComboBox();
            this.textBox_fill = new System.Windows.Forms.TextBox();
            this.button_fill = new System.Windows.Forms.Button();
            this.textBox_data = new System.Windows.Forms.TextBox();
            this.label_data_sep = new System.Windows.Forms.Label();
            this.textBox_conv_input = new System.Windows.Forms.TextBox();
            this.comboBox_conv = new System.Windows.Forms.ComboBox();
            this.textBox_conv_output = new System.Windows.Forms.TextBox();
            this.checkBox_hash = new System.Windows.Forms.CheckBox();
            this.textBox_hash_b2 = new System.Windows.Forms.TextBox();
            this.textBox_hash_b1 = new System.Windows.Forms.TextBox();
            this.label_size = new System.Windows.Forms.Label();
            this.label_command = new System.Windows.Forms.Label();
            this.label_command_send = new System.Windows.Forms.Label();
            this.label_sender = new System.Windows.Forms.Label();
            this.label_sender_type = new System.Windows.Forms.Label();
            this.label_fill = new System.Windows.Forms.Label();
            this.label_data = new System.Windows.Forms.Label();
            this.label_conv = new System.Windows.Forms.Label();
            this.label_conv_arr = new System.Windows.Forms.Label();
            this.label_hash = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label_list = new System.Windows.Forms.Label();
            this.comboBox_bd = new System.Windows.Forms.ComboBox();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.button_conn = new System.Windows.Forms.Button();
            this.label_port = new System.Windows.Forms.Label();
            this.label_bd = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_err = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_size_b1
            // 
            this.textBox_size_b1.Enabled = false;
            this.textBox_size_b1.Location = new System.Drawing.Point(24, 33);
            this.textBox_size_b1.Name = "textBox_size_b1";
            this.textBox_size_b1.Size = new System.Drawing.Size(30, 20);
            this.textBox_size_b1.TabIndex = 0;
            // 
            // textBox_size_b2
            // 
            this.textBox_size_b2.Enabled = false;
            this.textBox_size_b2.Location = new System.Drawing.Point(60, 33);
            this.textBox_size_b2.Name = "textBox_size_b2";
            this.textBox_size_b2.Size = new System.Drawing.Size(30, 20);
            this.textBox_size_b2.TabIndex = 1;
            // 
            // checkBox_size
            // 
            this.checkBox_size.AutoSize = true;
            this.checkBox_size.Location = new System.Drawing.Point(24, 59);
            this.checkBox_size.Name = "checkBox_size";
            this.checkBox_size.Size = new System.Drawing.Size(142, 17);
            this.checkBox_size.TabIndex = 2;
            this.checkBox_size.Text = "Change (Cause an Error)";
            this.checkBox_size.UseVisualStyleBackColor = true;
            this.checkBox_size.CheckedChanged += new System.EventHandler(this.checkBox_size_CheckedChanged);
            // 
            // textBox_command_b1
            // 
            this.textBox_command_b1.Location = new System.Drawing.Point(22, 107);
            this.textBox_command_b1.Name = "textBox_command_b1";
            this.textBox_command_b1.Size = new System.Drawing.Size(30, 20);
            this.textBox_command_b1.TabIndex = 3;
            this.textBox_command_b1.TextChanged += new System.EventHandler(this.textBox_command_b1_TextChanged);
            // 
            // textBox_command_b2
            // 
            this.textBox_command_b2.Location = new System.Drawing.Point(58, 107);
            this.textBox_command_b2.Name = "textBox_command_b2";
            this.textBox_command_b2.Size = new System.Drawing.Size(30, 20);
            this.textBox_command_b2.TabIndex = 4;
            this.textBox_command_b2.TextChanged += new System.EventHandler(this.textBox_command_b2_TextChanged);
            // 
            // comboBox_command
            // 
            this.comboBox_command.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_command.FormattingEnabled = true;
            this.comboBox_command.Location = new System.Drawing.Point(112, 133);
            this.comboBox_command.Name = "comboBox_command";
            this.comboBox_command.Size = new System.Drawing.Size(192, 21);
            this.comboBox_command.TabIndex = 5;
            this.comboBox_command.SelectedIndexChanged += new System.EventHandler(this.comboBox_command_SelectedIndexChanged);
            // 
            // textBox_sender_b2
            // 
            this.textBox_sender_b2.Location = new System.Drawing.Point(58, 199);
            this.textBox_sender_b2.Name = "textBox_sender_b2";
            this.textBox_sender_b2.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b2.TabIndex = 7;
            this.textBox_sender_b2.TextChanged += new System.EventHandler(this.textBox_sender_b2_TextChanged);
            // 
            // textBox_sender_b1
            // 
            this.textBox_sender_b1.Enabled = false;
            this.textBox_sender_b1.Location = new System.Drawing.Point(22, 199);
            this.textBox_sender_b1.Name = "textBox_sender_b1";
            this.textBox_sender_b1.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b1.TabIndex = 6;
            this.textBox_sender_b1.TextChanged += new System.EventHandler(this.textBox_sender_b1_TextChanged);
            // 
            // textBox_sender_b4
            // 
            this.textBox_sender_b4.Location = new System.Drawing.Point(130, 199);
            this.textBox_sender_b4.Name = "textBox_sender_b4";
            this.textBox_sender_b4.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b4.TabIndex = 9;
            this.textBox_sender_b4.TextChanged += new System.EventHandler(this.textBox_sender_b4_TextChanged);
            // 
            // textBox_sender_b3
            // 
            this.textBox_sender_b3.Location = new System.Drawing.Point(94, 199);
            this.textBox_sender_b3.Name = "textBox_sender_b3";
            this.textBox_sender_b3.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b3.TabIndex = 8;
            this.textBox_sender_b3.TextChanged += new System.EventHandler(this.textBox_sender_b3_TextChanged);
            // 
            // textBox_sender_b6
            // 
            this.textBox_sender_b6.Location = new System.Drawing.Point(202, 199);
            this.textBox_sender_b6.Name = "textBox_sender_b6";
            this.textBox_sender_b6.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b6.TabIndex = 11;
            this.textBox_sender_b6.TextChanged += new System.EventHandler(this.textBox_sender_b6_TextChanged);
            // 
            // textBox_sender_b5
            // 
            this.textBox_sender_b5.Location = new System.Drawing.Point(166, 199);
            this.textBox_sender_b5.Name = "textBox_sender_b5";
            this.textBox_sender_b5.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b5.TabIndex = 10;
            this.textBox_sender_b5.TextChanged += new System.EventHandler(this.textBox_sender_b5_TextChanged);
            // 
            // textBox_sender_b8
            // 
            this.textBox_sender_b8.Location = new System.Drawing.Point(274, 199);
            this.textBox_sender_b8.Name = "textBox_sender_b8";
            this.textBox_sender_b8.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b8.TabIndex = 13;
            this.textBox_sender_b8.TextChanged += new System.EventHandler(this.textBox_sender_b8_TextChanged);
            // 
            // textBox_sender_b7
            // 
            this.textBox_sender_b7.Location = new System.Drawing.Point(238, 199);
            this.textBox_sender_b7.Name = "textBox_sender_b7";
            this.textBox_sender_b7.Size = new System.Drawing.Size(30, 20);
            this.textBox_sender_b7.TabIndex = 12;
            this.textBox_sender_b7.TextChanged += new System.EventHandler(this.textBox_sender_b7_TextChanged);
            // 
            // comboBox_sender
            // 
            this.comboBox_sender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sender.FormattingEnabled = true;
            this.comboBox_sender.Location = new System.Drawing.Point(60, 225);
            this.comboBox_sender.Name = "comboBox_sender";
            this.comboBox_sender.Size = new System.Drawing.Size(123, 21);
            this.comboBox_sender.TabIndex = 14;
            this.comboBox_sender.SelectedIndexChanged += new System.EventHandler(this.comboBox_sender_SelectedIndexChanged);
            // 
            // textBox_fill
            // 
            this.textBox_fill.Location = new System.Drawing.Point(189, 226);
            this.textBox_fill.Name = "textBox_fill";
            this.textBox_fill.Size = new System.Drawing.Size(55, 20);
            this.textBox_fill.TabIndex = 15;
            // 
            // button_fill
            // 
            this.button_fill.Location = new System.Drawing.Point(250, 224);
            this.button_fill.Name = "button_fill";
            this.button_fill.Size = new System.Drawing.Size(54, 22);
            this.button_fill.TabIndex = 16;
            this.button_fill.Text = "Fill";
            this.button_fill.UseVisualStyleBackColor = true;
            this.button_fill.Click += new System.EventHandler(this.button_fill_Click);
            // 
            // textBox_data
            // 
            this.textBox_data.Location = new System.Drawing.Point(23, 294);
            this.textBox_data.Name = "textBox_data";
            this.textBox_data.Size = new System.Drawing.Size(281, 20);
            this.textBox_data.TabIndex = 17;
            this.textBox_data.TextChanged += new System.EventHandler(this.textBox_data_TextChanged);
            // 
            // label_data_sep
            // 
            this.label_data_sep.AutoSize = true;
            this.label_data_sep.Location = new System.Drawing.Point(21, 317);
            this.label_data_sep.Name = "label_data_sep";
            this.label_data_sep.Size = new System.Drawing.Size(132, 13);
            this.label_data_sep.TabIndex = 18;
            this.label_data_sep.Text = "Separate bytes with space";
            // 
            // textBox_conv_input
            // 
            this.textBox_conv_input.Location = new System.Drawing.Point(78, 351);
            this.textBox_conv_input.Name = "textBox_conv_input";
            this.textBox_conv_input.Size = new System.Drawing.Size(82, 20);
            this.textBox_conv_input.TabIndex = 19;
            // 
            // comboBox_conv
            // 
            this.comboBox_conv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_conv.FormattingEnabled = true;
            this.comboBox_conv.Location = new System.Drawing.Point(166, 350);
            this.comboBox_conv.Name = "comboBox_conv";
            this.comboBox_conv.Size = new System.Drawing.Size(138, 21);
            this.comboBox_conv.TabIndex = 20;
            // 
            // textBox_conv_output
            // 
            this.textBox_conv_output.Location = new System.Drawing.Point(163, 381);
            this.textBox_conv_output.Name = "textBox_conv_output";
            this.textBox_conv_output.ReadOnly = true;
            this.textBox_conv_output.Size = new System.Drawing.Size(80, 20);
            this.textBox_conv_output.TabIndex = 21;
            // 
            // checkBox_hash
            // 
            this.checkBox_hash.AutoSize = true;
            this.checkBox_hash.Location = new System.Drawing.Point(23, 435);
            this.checkBox_hash.Name = "checkBox_hash";
            this.checkBox_hash.Size = new System.Drawing.Size(142, 17);
            this.checkBox_hash.TabIndex = 24;
            this.checkBox_hash.Text = "Change (Cause an Error)";
            this.checkBox_hash.UseVisualStyleBackColor = true;
            this.checkBox_hash.CheckedChanged += new System.EventHandler(this.checkBox_hash_CheckedChanged);
            // 
            // textBox_hash_b2
            // 
            this.textBox_hash_b2.Enabled = false;
            this.textBox_hash_b2.Location = new System.Drawing.Point(59, 409);
            this.textBox_hash_b2.Name = "textBox_hash_b2";
            this.textBox_hash_b2.Size = new System.Drawing.Size(30, 20);
            this.textBox_hash_b2.TabIndex = 23;
            // 
            // textBox_hash_b1
            // 
            this.textBox_hash_b1.Enabled = false;
            this.textBox_hash_b1.Location = new System.Drawing.Point(23, 409);
            this.textBox_hash_b1.Name = "textBox_hash_b1";
            this.textBox_hash_b1.Size = new System.Drawing.Size(30, 20);
            this.textBox_hash_b1.TabIndex = 22;
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Location = new System.Drawing.Point(21, 17);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(76, 13);
            this.label_size.TabIndex = 25;
            this.label_size.Text = "Size of Packet";
            // 
            // label_command
            // 
            this.label_command.AutoSize = true;
            this.label_command.Location = new System.Drawing.Point(21, 91);
            this.label_command.Name = "label_command";
            this.label_command.Size = new System.Drawing.Size(54, 13);
            this.label_command.TabIndex = 26;
            this.label_command.Text = "Command";
            // 
            // label_command_send
            // 
            this.label_command_send.AutoSize = true;
            this.label_command_send.Location = new System.Drawing.Point(20, 136);
            this.label_command_send.Name = "label_command_send";
            this.label_command_send.Size = new System.Drawing.Size(86, 13);
            this.label_command_send.TabIndex = 27;
            this.label_command_send.Text = "Set From Default";
            // 
            // label_sender
            // 
            this.label_sender.AutoSize = true;
            this.label_sender.Location = new System.Drawing.Point(21, 183);
            this.label_sender.Name = "label_sender";
            this.label_sender.Size = new System.Drawing.Size(41, 13);
            this.label_sender.TabIndex = 28;
            this.label_sender.Text = "Sender";
            // 
            // label_sender_type
            // 
            this.label_sender_type.AutoSize = true;
            this.label_sender_type.Location = new System.Drawing.Point(20, 229);
            this.label_sender_type.Name = "label_sender_type";
            this.label_sender_type.Size = new System.Drawing.Size(31, 13);
            this.label_sender_type.TabIndex = 29;
            this.label_sender_type.Text = "Type";
            // 
            // label_fill
            // 
            this.label_fill.AutoSize = true;
            this.label_fill.Location = new System.Drawing.Point(174, 249);
            this.label_fill.Name = "label_fill";
            this.label_fill.Size = new System.Drawing.Size(94, 13);
            this.label_fill.TabIndex = 30;
            this.label_fill.Text = "Fill by 7 char string";
            // 
            // label_data
            // 
            this.label_data.AutoSize = true;
            this.label_data.Location = new System.Drawing.Point(19, 278);
            this.label_data.Name = "label_data";
            this.label_data.Size = new System.Drawing.Size(30, 13);
            this.label_data.TabIndex = 31;
            this.label_data.Text = "Data";
            // 
            // label_conv
            // 
            this.label_conv.AutoSize = true;
            this.label_conv.Location = new System.Drawing.Point(21, 354);
            this.label_conv.Name = "label_conv";
            this.label_conv.Size = new System.Drawing.Size(53, 13);
            this.label_conv.TabIndex = 32;
            this.label_conv.Text = "Converter";
            // 
            // label_conv_arr
            // 
            this.label_conv_arr.AutoSize = true;
            this.label_conv_arr.Location = new System.Drawing.Point(144, 384);
            this.label_conv_arr.Name = "label_conv_arr";
            this.label_conv_arr.Size = new System.Drawing.Size(16, 13);
            this.label_conv_arr.TabIndex = 33;
            this.label_conv_arr.Text = "->";
            // 
            // label_hash
            // 
            this.label_hash.AutoSize = true;
            this.label_hash.Location = new System.Drawing.Point(20, 393);
            this.label_hash.Name = "label_hash";
            this.label_hash.Size = new System.Drawing.Size(32, 13);
            this.label_hash.TabIndex = 34;
            this.label_hash.Text = "Hash";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(315, 33);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(263, 407);
            this.listBox.TabIndex = 35;
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
            // 
            // label_list
            // 
            this.label_list.AutoSize = true;
            this.label_list.Location = new System.Drawing.Point(311, 12);
            this.label_list.Name = "label_list";
            this.label_list.Size = new System.Drawing.Size(136, 13);
            this.label_list.TabIndex = 36;
            this.label_list.Text = "Double click to view details";
            // 
            // comboBox_bd
            // 
            this.comboBox_bd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bd.FormattingEnabled = true;
            this.comboBox_bd.Location = new System.Drawing.Point(339, 472);
            this.comboBox_bd.Name = "comboBox_bd";
            this.comboBox_bd.Size = new System.Drawing.Size(88, 21);
            this.comboBox_bd.TabIndex = 37;
            // 
            // comboBox_port
            // 
            this.comboBox_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(339, 446);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(88, 21);
            this.comboBox_port.TabIndex = 38;
            this.comboBox_port.Click += new System.EventHandler(this.comboBox_port_SelectedIndexChanged);
            // 
            // button_conn
            // 
            this.button_conn.Location = new System.Drawing.Point(433, 457);
            this.button_conn.Name = "button_conn";
            this.button_conn.Size = new System.Drawing.Size(67, 33);
            this.button_conn.TabIndex = 39;
            this.button_conn.Text = "Connect";
            this.button_conn.UseVisualStyleBackColor = true;
            this.button_conn.Click += new System.EventHandler(this.button_conn_Click);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(307, 449);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(26, 13);
            this.label_port.TabIndex = 40;
            this.label_port.Text = "Port";
            // 
            // label_bd
            // 
            this.label_bd.AutoSize = true;
            this.label_bd.Location = new System.Drawing.Point(307, 475);
            this.label_bd.Name = "label_bd";
            this.label_bd.Size = new System.Drawing.Size(20, 13);
            this.label_bd.TabIndex = 41;
            this.label_bd.Text = "Bd";
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(22, 462);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(108, 31);
            this.button_send.TabIndex = 43;
            this.button_send.Text = "Combine and Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(506, 457);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(67, 33);
            this.button_exit.TabIndex = 44;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 24);
            this.button1.TabIndex = 45;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_err
            // 
            this.label_err.AutoSize = true;
            this.label_err.Location = new System.Drawing.Point(137, 474);
            this.label_err.Name = "label_err";
            this.label_err.Size = new System.Drawing.Size(0, 13);
            this.label_err.TabIndex = 46;
            // 
            // Form_SerialMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(588, 499);
            this.Controls.Add(this.label_err);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label_bd);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.button_conn);
            this.Controls.Add(this.comboBox_port);
            this.Controls.Add(this.comboBox_bd);
            this.Controls.Add(this.label_list);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label_hash);
            this.Controls.Add(this.label_conv_arr);
            this.Controls.Add(this.label_conv);
            this.Controls.Add(this.label_data);
            this.Controls.Add(this.label_fill);
            this.Controls.Add(this.label_sender_type);
            this.Controls.Add(this.label_sender);
            this.Controls.Add(this.label_command_send);
            this.Controls.Add(this.label_command);
            this.Controls.Add(this.label_size);
            this.Controls.Add(this.checkBox_hash);
            this.Controls.Add(this.textBox_hash_b2);
            this.Controls.Add(this.textBox_hash_b1);
            this.Controls.Add(this.textBox_conv_output);
            this.Controls.Add(this.comboBox_conv);
            this.Controls.Add(this.textBox_conv_input);
            this.Controls.Add(this.label_data_sep);
            this.Controls.Add(this.textBox_data);
            this.Controls.Add(this.button_fill);
            this.Controls.Add(this.textBox_fill);
            this.Controls.Add(this.comboBox_sender);
            this.Controls.Add(this.textBox_sender_b8);
            this.Controls.Add(this.textBox_sender_b7);
            this.Controls.Add(this.textBox_sender_b6);
            this.Controls.Add(this.textBox_sender_b5);
            this.Controls.Add(this.textBox_sender_b4);
            this.Controls.Add(this.textBox_sender_b3);
            this.Controls.Add(this.textBox_sender_b2);
            this.Controls.Add(this.textBox_sender_b1);
            this.Controls.Add(this.comboBox_command);
            this.Controls.Add(this.textBox_command_b2);
            this.Controls.Add(this.textBox_command_b1);
            this.Controls.Add(this.checkBox_size);
            this.Controls.Add(this.textBox_size_b2);
            this.Controls.Add(this.textBox_size_b1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_SerialMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Monitor";
            this.Load += new System.EventHandler(this.Form_SerialMonitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox_size_b1;
        public System.Windows.Forms.TextBox textBox_size_b2;
        public System.Windows.Forms.CheckBox checkBox_size;
        public System.Windows.Forms.TextBox textBox_command_b1;
        public System.Windows.Forms.TextBox textBox_command_b2;
        public System.Windows.Forms.ComboBox comboBox_command;
        public System.Windows.Forms.TextBox textBox_sender_b2;
        public System.Windows.Forms.TextBox textBox_sender_b1;
        public System.Windows.Forms.TextBox textBox_sender_b4;
        public System.Windows.Forms.TextBox textBox_sender_b3;
        public System.Windows.Forms.TextBox textBox_sender_b6;
        public System.Windows.Forms.TextBox textBox_sender_b5;
        public System.Windows.Forms.TextBox textBox_sender_b8;
        public System.Windows.Forms.TextBox textBox_sender_b7;
        public System.Windows.Forms.ComboBox comboBox_sender;
        public System.Windows.Forms.TextBox textBox_fill;
        public System.Windows.Forms.Button button_fill;
        public System.Windows.Forms.TextBox textBox_data;
        public System.Windows.Forms.Label label_data_sep;
        public System.Windows.Forms.TextBox textBox_conv_input;
        public System.Windows.Forms.ComboBox comboBox_conv;
        public System.Windows.Forms.TextBox textBox_conv_output;
        public System.Windows.Forms.CheckBox checkBox_hash;
        public System.Windows.Forms.TextBox textBox_hash_b2;
        public System.Windows.Forms.TextBox textBox_hash_b1;
        public System.Windows.Forms.Label label_size;
        public System.Windows.Forms.Label label_command;
        public System.Windows.Forms.Label label_command_send;
        public System.Windows.Forms.Label label_sender;
        public System.Windows.Forms.Label label_sender_type;
        public System.Windows.Forms.Label label_fill;
        public System.Windows.Forms.Label label_data;
        public System.Windows.Forms.Label label_conv;
        public System.Windows.Forms.Label label_conv_arr;
        public System.Windows.Forms.Label label_hash;
        public System.Windows.Forms.ListBox listBox;
        public System.Windows.Forms.Label label_list;
        public System.Windows.Forms.ComboBox comboBox_bd;
        public System.Windows.Forms.ComboBox comboBox_port;
        public System.Windows.Forms.Button button_conn;
        public System.Windows.Forms.Label label_port;
        public System.Windows.Forms.Label label_bd;
        public System.Windows.Forms.Button button_send;
        public System.Windows.Forms.Button button_exit;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label_err;
    }
}
