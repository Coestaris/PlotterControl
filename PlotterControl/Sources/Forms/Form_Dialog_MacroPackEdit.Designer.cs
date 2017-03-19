namespace CnC_WFA
{
    partial class Form_Dialog_MacroPackEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dialog_MacroPackEdit));
            this.button_save = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.listBox_macroses = new System.Windows.Forms.ListBox();
            this.button_addnew = new System.Windows.Forms.Button();
            this.button_repickpath = new System.Windows.Forms.Button();
            this.label_macro_name = new System.Windows.Forms.Label();
            this.label_macro_discr = new System.Windows.Forms.Label();
            this.textBox_macro_caption = new System.Windows.Forms.TextBox();
            this.comboBox_macro_charbind = new System.Windows.Forms.ComboBox();
            this.comboBox_macro_keybind = new System.Windows.Forms.ComboBox();
            this.label_macro_caption = new System.Windows.Forms.Label();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_openineditor = new System.Windows.Forms.Button();
            this.label_macro_keybind = new System.Windows.Forms.Label();
            this.label_macro_charbind = new System.Windows.Forms.Label();
            this.textBox_caption = new System.Windows.Forms.TextBox();
            this.comboBox_bdrate = new System.Windows.Forms.ComboBox();
            this.comboBox_portname = new System.Windows.Forms.ComboBox();
            this.label_caption = new System.Windows.Forms.Label();
            this.groupBox_elements = new System.Windows.Forms.GroupBox();
            this.label_macro_elemcount = new System.Windows.Forms.Label();
            this.label_macro_path = new System.Windows.Forms.Label();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.label_discr = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.richTextBox_discr = new System.Windows.Forms.RichTextBox();
            this.label_portname = new System.Windows.Forms.Label();
            this.groupBox_connection = new System.Windows.Forms.GroupBox();
            this.label_bdrate = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox_samples = new System.Windows.Forms.GroupBox();
            this.label_samples = new System.Windows.Forms.Label();
            this.label_samplesvalue = new System.Windows.Forms.Label();
            this.button_samples_add = new System.Windows.Forms.Button();
            this.textBox_sample_value = new System.Windows.Forms.TextBox();
            this.button_samples_remove = new System.Windows.Forms.Button();
            this.listBox_samples = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_elements.SuspendLayout();
            this.groupBox_main.SuspendLayout();
            this.groupBox_connection.SuspendLayout();
            this.groupBox_samples.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(6, 19);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(85, 23);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(97, 19);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(85, 23);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            // 
            // listBox_macroses
            // 
            this.listBox_macroses.FormattingEnabled = true;
            this.listBox_macroses.Location = new System.Drawing.Point(11, 20);
            this.listBox_macroses.Name = "listBox_macroses";
            this.listBox_macroses.Size = new System.Drawing.Size(234, 160);
            this.listBox_macroses.TabIndex = 2;
            this.listBox_macroses.SelectedIndexChanged += new System.EventHandler(this.listBox_macroses_SelectedIndexChanged);
            // 
            // button_addnew
            // 
            this.button_addnew.Location = new System.Drawing.Point(170, 186);
            this.button_addnew.Name = "button_addnew";
            this.button_addnew.Size = new System.Drawing.Size(75, 23);
            this.button_addnew.TabIndex = 3;
            this.button_addnew.Text = "Add new";
            this.button_addnew.UseVisualStyleBackColor = true;
            this.button_addnew.Click += new System.EventHandler(this.button_addnew_Click);
            // 
            // button_repickpath
            // 
            this.button_repickpath.Location = new System.Drawing.Point(11, 186);
            this.button_repickpath.Name = "button_repickpath";
            this.button_repickpath.Size = new System.Drawing.Size(75, 23);
            this.button_repickpath.TabIndex = 4;
            this.button_repickpath.Text = "Pick again";
            this.button_repickpath.UseVisualStyleBackColor = true;
            // 
            // label_macro_name
            // 
            this.label_macro_name.AutoSize = true;
            this.label_macro_name.Location = new System.Drawing.Point(8, 212);
            this.label_macro_name.Name = "label_macro_name";
            this.label_macro_name.Size = new System.Drawing.Size(41, 13);
            this.label_macro_name.TabIndex = 5;
            this.label_macro_name.Text = "Name: ";
            // 
            // label_macro_discr
            // 
            this.label_macro_discr.AutoSize = true;
            this.label_macro_discr.Location = new System.Drawing.Point(8, 225);
            this.label_macro_discr.Name = "label_macro_discr";
            this.label_macro_discr.Size = new System.Drawing.Size(31, 13);
            this.label_macro_discr.TabIndex = 6;
            this.label_macro_discr.Text = "Discr";
            // 
            // textBox_macro_caption
            // 
            this.textBox_macro_caption.Location = new System.Drawing.Point(63, 267);
            this.textBox_macro_caption.Name = "textBox_macro_caption";
            this.textBox_macro_caption.Size = new System.Drawing.Size(182, 20);
            this.textBox_macro_caption.TabIndex = 8;
            this.textBox_macro_caption.TextChanged += new System.EventHandler(this.textBox_macro_caption_TextChanged);
            // 
            // comboBox_macro_charbind
            // 
            this.comboBox_macro_charbind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_macro_charbind.FormattingEnabled = true;
            this.comboBox_macro_charbind.Location = new System.Drawing.Point(207, 293);
            this.comboBox_macro_charbind.Name = "comboBox_macro_charbind";
            this.comboBox_macro_charbind.Size = new System.Drawing.Size(38, 21);
            this.comboBox_macro_charbind.TabIndex = 9;
            this.comboBox_macro_charbind.SelectedIndexChanged += new System.EventHandler(this.comboBox_macro_charbind_SelectedIndexChanged);
            // 
            // comboBox_macro_keybind
            // 
            this.comboBox_macro_keybind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_macro_keybind.FormattingEnabled = true;
            this.comboBox_macro_keybind.Location = new System.Drawing.Point(63, 293);
            this.comboBox_macro_keybind.Name = "comboBox_macro_keybind";
            this.comboBox_macro_keybind.Size = new System.Drawing.Size(81, 21);
            this.comboBox_macro_keybind.TabIndex = 10;
            this.comboBox_macro_keybind.SelectedIndexChanged += new System.EventHandler(this.comboBox_macro_keybind_SelectedIndexChanged);
            // 
            // label_macro_caption
            // 
            this.label_macro_caption.AutoSize = true;
            this.label_macro_caption.Location = new System.Drawing.Point(8, 270);
            this.label_macro_caption.Name = "label_macro_caption";
            this.label_macro_caption.Size = new System.Drawing.Size(49, 13);
            this.label_macro_caption.TabIndex = 11;
            this.label_macro_caption.Text = "Caption: ";
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(92, 186);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 13;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_openineditor
            // 
            this.button_openineditor.Location = new System.Drawing.Point(154, 215);
            this.button_openineditor.Name = "button_openineditor";
            this.button_openineditor.Size = new System.Drawing.Size(91, 23);
            this.button_openineditor.TabIndex = 14;
            this.button_openineditor.Text = "Open in editor";
            this.button_openineditor.UseVisualStyleBackColor = true;
            this.button_openineditor.Click += new System.EventHandler(this.button_openineditor_Click);
            // 
            // label_macro_keybind
            // 
            this.label_macro_keybind.AutoSize = true;
            this.label_macro_keybind.Location = new System.Drawing.Point(6, 299);
            this.label_macro_keybind.Name = "label_macro_keybind";
            this.label_macro_keybind.Size = new System.Drawing.Size(55, 13);
            this.label_macro_keybind.TabIndex = 15;
            this.label_macro_keybind.Text = "Key Bind: ";
            // 
            // label_macro_charbind
            // 
            this.label_macro_charbind.AutoSize = true;
            this.label_macro_charbind.Location = new System.Drawing.Point(147, 298);
            this.label_macro_charbind.Name = "label_macro_charbind";
            this.label_macro_charbind.Size = new System.Drawing.Size(59, 13);
            this.label_macro_charbind.TabIndex = 16;
            this.label_macro_charbind.Text = "Char Bind: ";
            // 
            // textBox_caption
            // 
            this.textBox_caption.Location = new System.Drawing.Point(72, 48);
            this.textBox_caption.Name = "textBox_caption";
            this.textBox_caption.Size = new System.Drawing.Size(110, 20);
            this.textBox_caption.TabIndex = 17;
            this.textBox_caption.TextChanged += new System.EventHandler(this.textBox_caption_TextChanged);
            // 
            // comboBox_bdrate
            // 
            this.comboBox_bdrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bdrate.FormattingEnabled = true;
            this.comboBox_bdrate.Location = new System.Drawing.Point(77, 56);
            this.comboBox_bdrate.Name = "comboBox_bdrate";
            this.comboBox_bdrate.Size = new System.Drawing.Size(102, 21);
            this.comboBox_bdrate.TabIndex = 19;
            this.comboBox_bdrate.SelectedIndexChanged += new System.EventHandler(this.comboBox_bdrate_SelectedIndexChanged);
            // 
            // comboBox_portname
            // 
            this.comboBox_portname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_portname.FormattingEnabled = true;
            this.comboBox_portname.Location = new System.Drawing.Point(77, 29);
            this.comboBox_portname.Name = "comboBox_portname";
            this.comboBox_portname.Size = new System.Drawing.Size(102, 21);
            this.comboBox_portname.TabIndex = 20;
            this.comboBox_portname.SelectedIndexChanged += new System.EventHandler(this.comboBox_portname_SelectedIndexChanged);
            // 
            // label_caption
            // 
            this.label_caption.AutoSize = true;
            this.label_caption.Location = new System.Drawing.Point(6, 51);
            this.label_caption.Name = "label_caption";
            this.label_caption.Size = new System.Drawing.Size(49, 13);
            this.label_caption.TabIndex = 21;
            this.label_caption.Text = "Caption: ";
            // 
            // groupBox_elements
            // 
            this.groupBox_elements.Controls.Add(this.label_macro_elemcount);
            this.groupBox_elements.Controls.Add(this.label_macro_path);
            this.groupBox_elements.Controls.Add(this.label_macro_charbind);
            this.groupBox_elements.Controls.Add(this.label_macro_keybind);
            this.groupBox_elements.Controls.Add(this.button_openineditor);
            this.groupBox_elements.Controls.Add(this.button_remove);
            this.groupBox_elements.Controls.Add(this.label_macro_caption);
            this.groupBox_elements.Controls.Add(this.comboBox_macro_keybind);
            this.groupBox_elements.Controls.Add(this.comboBox_macro_charbind);
            this.groupBox_elements.Controls.Add(this.textBox_macro_caption);
            this.groupBox_elements.Controls.Add(this.label_macro_discr);
            this.groupBox_elements.Controls.Add(this.label_macro_name);
            this.groupBox_elements.Controls.Add(this.button_repickpath);
            this.groupBox_elements.Controls.Add(this.button_addnew);
            this.groupBox_elements.Controls.Add(this.listBox_macroses);
            this.groupBox_elements.Location = new System.Drawing.Point(202, 8);
            this.groupBox_elements.Name = "groupBox_elements";
            this.groupBox_elements.Size = new System.Drawing.Size(258, 321);
            this.groupBox_elements.TabIndex = 22;
            this.groupBox_elements.TabStop = false;
            this.groupBox_elements.Text = "Macros in Pack";
            // 
            // label_macro_elemcount
            // 
            this.label_macro_elemcount.AutoSize = true;
            this.label_macro_elemcount.Location = new System.Drawing.Point(8, 251);
            this.label_macro_elemcount.Name = "label_macro_elemcount";
            this.label_macro_elemcount.Size = new System.Drawing.Size(56, 13);
            this.label_macro_elemcount.TabIndex = 18;
            this.label_macro_elemcount.Text = "Elements: ";
            // 
            // label_macro_path
            // 
            this.label_macro_path.AutoSize = true;
            this.label_macro_path.Location = new System.Drawing.Point(8, 238);
            this.label_macro_path.Name = "label_macro_path";
            this.label_macro_path.Size = new System.Drawing.Size(35, 13);
            this.label_macro_path.TabIndex = 17;
            this.label_macro_path.Text = "Path: ";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.label_discr);
            this.groupBox_main.Controls.Add(this.textBox_name);
            this.groupBox_main.Controls.Add(this.label_name);
            this.groupBox_main.Controls.Add(this.richTextBox_discr);
            this.groupBox_main.Controls.Add(this.label_caption);
            this.groupBox_main.Controls.Add(this.textBox_caption);
            this.groupBox_main.Controls.Add(this.button_load);
            this.groupBox_main.Controls.Add(this.button_save);
            this.groupBox_main.Location = new System.Drawing.Point(8, 9);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(188, 224);
            this.groupBox_main.TabIndex = 23;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "Pack Settings";
            // 
            // label_discr
            // 
            this.label_discr.AutoSize = true;
            this.label_discr.Location = new System.Drawing.Point(6, 96);
            this.label_discr.Name = "label_discr";
            this.label_discr.Size = new System.Drawing.Size(62, 13);
            this.label_discr.TabIndex = 25;
            this.label_discr.Text = "Discription: ";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(47, 74);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(135, 20);
            this.textBox_name.TabIndex = 24;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(6, 77);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 13);
            this.label_name.TabIndex = 23;
            this.label_name.Text = "Name: ";
            // 
            // richTextBox_discr
            // 
            this.richTextBox_discr.Location = new System.Drawing.Point(11, 114);
            this.richTextBox_discr.Name = "richTextBox_discr";
            this.richTextBox_discr.Size = new System.Drawing.Size(171, 94);
            this.richTextBox_discr.TabIndex = 22;
            this.richTextBox_discr.Text = "";
            this.richTextBox_discr.TextChanged += new System.EventHandler(this.richTextBox_discr_TextChanged);
            // 
            // label_portname
            // 
            this.label_portname.AutoSize = true;
            this.label_portname.Location = new System.Drawing.Point(10, 32);
            this.label_portname.Name = "label_portname";
            this.label_portname.Size = new System.Drawing.Size(63, 13);
            this.label_portname.TabIndex = 17;
            this.label_portname.Text = "Port Name: ";
            // 
            // groupBox_connection
            // 
            this.groupBox_connection.Controls.Add(this.label_bdrate);
            this.groupBox_connection.Controls.Add(this.label_portname);
            this.groupBox_connection.Controls.Add(this.comboBox_bdrate);
            this.groupBox_connection.Controls.Add(this.comboBox_portname);
            this.groupBox_connection.Location = new System.Drawing.Point(4, 239);
            this.groupBox_connection.Name = "groupBox_connection";
            this.groupBox_connection.Size = new System.Drawing.Size(192, 90);
            this.groupBox_connection.TabIndex = 24;
            this.groupBox_connection.TabStop = false;
            this.groupBox_connection.Text = "Default Pack Connection Settings";
            // 
            // label_bdrate
            // 
            this.label_bdrate.AutoSize = true;
            this.label_bdrate.Location = new System.Drawing.Point(10, 59);
            this.label_bdrate.Name = "label_bdrate";
            this.label_bdrate.Size = new System.Drawing.Size(52, 13);
            this.label_bdrate.TabIndex = 21;
            this.label_bdrate.Text = "Bd Rate: ";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(567, 290);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(91, 36);
            this.button_exit.TabIndex = 25;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            // 
            // groupBox_samples
            // 
            this.groupBox_samples.Controls.Add(this.label_samples);
            this.groupBox_samples.Controls.Add(this.label_samplesvalue);
            this.groupBox_samples.Controls.Add(this.button_samples_add);
            this.groupBox_samples.Controls.Add(this.textBox_sample_value);
            this.groupBox_samples.Controls.Add(this.button_samples_remove);
            this.groupBox_samples.Controls.Add(this.listBox_samples);
            this.groupBox_samples.Location = new System.Drawing.Point(465, 9);
            this.groupBox_samples.Name = "groupBox_samples";
            this.groupBox_samples.Size = new System.Drawing.Size(193, 271);
            this.groupBox_samples.TabIndex = 26;
            this.groupBox_samples.TabStop = false;
            this.groupBox_samples.Text = "Smples";
            // 
            // label_samples
            // 
            this.label_samples.AutoSize = true;
            this.label_samples.Location = new System.Drawing.Point(8, 185);
            this.label_samples.Name = "label_samples";
            this.label_samples.Size = new System.Drawing.Size(53, 13);
            this.label_samples.TabIndex = 21;
            this.label_samples.Text = "Samples: ";
            // 
            // label_samplesvalue
            // 
            this.label_samplesvalue.AutoSize = true;
            this.label_samplesvalue.Location = new System.Drawing.Point(8, 201);
            this.label_samplesvalue.Name = "label_samplesvalue";
            this.label_samplesvalue.Size = new System.Drawing.Size(40, 13);
            this.label_samplesvalue.TabIndex = 19;
            this.label_samplesvalue.Text = "Value: ";
            // 
            // button_samples_add
            // 
            this.button_samples_add.Location = new System.Drawing.Point(29, 242);
            this.button_samples_add.Name = "button_samples_add";
            this.button_samples_add.Size = new System.Drawing.Size(75, 23);
            this.button_samples_add.TabIndex = 20;
            this.button_samples_add.Text = "Add";
            this.button_samples_add.UseVisualStyleBackColor = true;
            this.button_samples_add.Click += new System.EventHandler(this.button_samples_add_Click);
            // 
            // textBox_sample_value
            // 
            this.textBox_sample_value.Location = new System.Drawing.Point(11, 217);
            this.textBox_sample_value.Name = "textBox_sample_value";
            this.textBox_sample_value.Size = new System.Drawing.Size(173, 20);
            this.textBox_sample_value.TabIndex = 19;
            this.textBox_sample_value.TextChanged += new System.EventHandler(this.textBox_sample_value_TextChanged);
            // 
            // button_samples_remove
            // 
            this.button_samples_remove.Location = new System.Drawing.Point(110, 242);
            this.button_samples_remove.Name = "button_samples_remove";
            this.button_samples_remove.Size = new System.Drawing.Size(75, 23);
            this.button_samples_remove.TabIndex = 19;
            this.button_samples_remove.Text = "Remove";
            this.button_samples_remove.UseVisualStyleBackColor = true;
            this.button_samples_remove.Click += new System.EventHandler(this.button_samples_remove_Click);
            // 
            // listBox_samples
            // 
            this.listBox_samples.FormattingEnabled = true;
            this.listBox_samples.Location = new System.Drawing.Point(8, 19);
            this.listBox_samples.Name = "listBox_samples";
            this.listBox_samples.Size = new System.Drawing.Size(176, 160);
            this.listBox_samples.TabIndex = 19;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "macros";
            this.openFileDialog1.Filter = "PC Macros | *.pcmacros";
            this.openFileDialog1.InitialDirectory = "macros\\";
            this.openFileDialog1.Multiselect = true;
            // 
            // Dialog_MacroPackEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 333);
            this.Controls.Add(this.groupBox_samples);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.groupBox_connection);
            this.Controls.Add(this.groupBox_main);
            this.Controls.Add(this.groupBox_elements);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_MacroPackEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Macro-Pack";
            this.Load += new System.EventHandler(this.Dialog_MacroPackEdit_Load);
            this.groupBox_elements.ResumeLayout(false);
            this.groupBox_elements.PerformLayout();
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            this.groupBox_connection.ResumeLayout(false);
            this.groupBox_connection.PerformLayout();
            this.groupBox_samples.ResumeLayout(false);
            this.groupBox_samples.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.ListBox listBox_macroses;
        private System.Windows.Forms.Button button_addnew;
        private System.Windows.Forms.Button button_repickpath;
        private System.Windows.Forms.Label label_macro_name;
        private System.Windows.Forms.Label label_macro_discr;
        private System.Windows.Forms.TextBox textBox_macro_caption;
        private System.Windows.Forms.ComboBox comboBox_macro_charbind;
        private System.Windows.Forms.ComboBox comboBox_macro_keybind;
        private System.Windows.Forms.Label label_macro_caption;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_openineditor;
        private System.Windows.Forms.Label label_macro_keybind;
        private System.Windows.Forms.Label label_macro_charbind;
        private System.Windows.Forms.TextBox textBox_caption;
        private System.Windows.Forms.ComboBox comboBox_bdrate;
        private System.Windows.Forms.ComboBox comboBox_portname;
        private System.Windows.Forms.Label label_caption;
        private System.Windows.Forms.GroupBox groupBox_elements;
        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.RichTextBox richTextBox_discr;
        private System.Windows.Forms.Label label_discr;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_portname;
        private System.Windows.Forms.GroupBox groupBox_connection;
        private System.Windows.Forms.Label label_bdrate;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label_macro_elemcount;
        private System.Windows.Forms.GroupBox groupBox_samples;
        private System.Windows.Forms.Label label_samples;
        private System.Windows.Forms.Label label_samplesvalue;
        private System.Windows.Forms.Button button_samples_add;
        private System.Windows.Forms.Button button_samples_remove;
        private System.Windows.Forms.ListBox listBox_samples;
        private System.Windows.Forms.TextBox textBox_sample_value;
        private System.Windows.Forms.Label label_macro_path;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}