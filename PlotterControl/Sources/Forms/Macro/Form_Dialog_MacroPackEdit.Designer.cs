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
            this.label_macro_elemcount = new System.Windows.Forms.Label();
            this.label_macro_path = new System.Windows.Forms.Label();
            this.label_discr = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.richTextBox_discr = new System.Windows.Forms.RichTextBox();
            this.label_portname = new System.Windows.Forms.Label();
            this.label_bdrate = new System.Windows.Forms.Label();
            this.label_samples = new System.Windows.Forms.Label();
            this.button_samples_add = new System.Windows.Forms.Button();
            this.textBox_sample_value = new System.Windows.Forms.TextBox();
            this.button_samples_remove = new System.Windows.Forms.Button();
            this.listBox_samples = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.label_main_title = new System.Windows.Forms.Label();
            this.tabPage_connection = new System.Windows.Forms.TabPage();
            this.label_conn_title = new System.Windows.Forms.Label();
            this.tabPage_macro = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_macroMain = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label_macro_title = new System.Windows.Forms.Label();
            this.tabPage_sample = new System.Windows.Forms.TabPage();
            this.label_sample_title = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_preset = new System.Windows.Forms.Button();
            this.button_macro = new System.Windows.Forms.Button();
            this.button_conn = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.button_main = new System.Windows.Forms.Button();
            this.listBox_macroses = new CnC_WFA.ImageListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.tabPage_connection.SuspendLayout();
            this.tabPage_macro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_macroMain.SuspendLayout();
            this.tabPage_sample.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_save.FlatAppearance.BorderSize = 2;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(18, 268);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(122, 36);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_load
            // 
            this.button_load.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_load.FlatAppearance.BorderSize = 2;
            this.button_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_load.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_load.ForeColor = System.Drawing.Color.White;
            this.button_load.Location = new System.Drawing.Point(18, 226);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(122, 36);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Загрузить";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_addnew
            // 
            this.button_addnew.BackColor = System.Drawing.Color.White;
            this.button_addnew.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_addnew.FlatAppearance.BorderSize = 2;
            this.button_addnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addnew.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_addnew.Location = new System.Drawing.Point(11, 18);
            this.button_addnew.Name = "button_addnew";
            this.button_addnew.Size = new System.Drawing.Size(89, 36);
            this.button_addnew.TabIndex = 3;
            this.button_addnew.Text = "Add new";
            this.button_addnew.UseVisualStyleBackColor = false;
            this.button_addnew.Click += new System.EventHandler(this.button_addnew_Click);
            // 
            // button_repickpath
            // 
            this.button_repickpath.BackColor = System.Drawing.Color.White;
            this.button_repickpath.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_repickpath.FlatAppearance.BorderSize = 2;
            this.button_repickpath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_repickpath.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_repickpath.Location = new System.Drawing.Point(203, 18);
            this.button_repickpath.Name = "button_repickpath";
            this.button_repickpath.Size = new System.Drawing.Size(89, 36);
            this.button_repickpath.TabIndex = 4;
            this.button_repickpath.Text = "Pick again";
            this.button_repickpath.UseVisualStyleBackColor = false;
            this.button_repickpath.Click += new System.EventHandler(this.button_repickpath_Click);
            // 
            // label_macro_name
            // 
            this.label_macro_name.AutoSize = true;
            this.label_macro_name.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_macro_name.Location = new System.Drawing.Point(8, 64);
            this.label_macro_name.Name = "label_macro_name";
            this.label_macro_name.Size = new System.Drawing.Size(51, 17);
            this.label_macro_name.TabIndex = 5;
            this.label_macro_name.Text = "Name: ";
            // 
            // label_macro_discr
            // 
            this.label_macro_discr.AutoSize = true;
            this.label_macro_discr.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_macro_discr.Location = new System.Drawing.Point(8, 89);
            this.label_macro_discr.Name = "label_macro_discr";
            this.label_macro_discr.Size = new System.Drawing.Size(41, 17);
            this.label_macro_discr.TabIndex = 6;
            this.label_macro_discr.Text = "Discr";
            // 
            // textBox_macro_caption
            // 
            this.textBox_macro_caption.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_macro_caption.Location = new System.Drawing.Point(309, 61);
            this.textBox_macro_caption.Name = "textBox_macro_caption";
            this.textBox_macro_caption.Size = new System.Drawing.Size(182, 25);
            this.textBox_macro_caption.TabIndex = 8;
            this.textBox_macro_caption.TextChanged += new System.EventHandler(this.textBox_macro_caption_TextChanged);
            // 
            // comboBox_macro_charbind
            // 
            this.comboBox_macro_charbind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_macro_charbind.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.comboBox_macro_charbind.FormattingEnabled = true;
            this.comboBox_macro_charbind.Location = new System.Drawing.Point(309, 135);
            this.comboBox_macro_charbind.Name = "comboBox_macro_charbind";
            this.comboBox_macro_charbind.Size = new System.Drawing.Size(81, 25);
            this.comboBox_macro_charbind.TabIndex = 9;
            this.comboBox_macro_charbind.SelectedIndexChanged += new System.EventHandler(this.comboBox_macro_charbind_SelectedIndexChanged);
            // 
            // comboBox_macro_keybind
            // 
            this.comboBox_macro_keybind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_macro_keybind.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.comboBox_macro_keybind.FormattingEnabled = true;
            this.comboBox_macro_keybind.Location = new System.Drawing.Point(309, 98);
            this.comboBox_macro_keybind.Name = "comboBox_macro_keybind";
            this.comboBox_macro_keybind.Size = new System.Drawing.Size(81, 25);
            this.comboBox_macro_keybind.TabIndex = 10;
            this.comboBox_macro_keybind.SelectedIndexChanged += new System.EventHandler(this.comboBox_macro_keybind_SelectedIndexChanged);
            // 
            // label_macro_caption
            // 
            this.label_macro_caption.AutoSize = true;
            this.label_macro_caption.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_macro_caption.Location = new System.Drawing.Point(221, 64);
            this.label_macro_caption.Name = "label_macro_caption";
            this.label_macro_caption.Size = new System.Drawing.Size(63, 17);
            this.label_macro_caption.TabIndex = 11;
            this.label_macro_caption.Text = "Caption: ";
            // 
            // button_remove
            // 
            this.button_remove.BackColor = System.Drawing.Color.White;
            this.button_remove.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_remove.FlatAppearance.BorderSize = 2;
            this.button_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_remove.Location = new System.Drawing.Point(107, 18);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(89, 36);
            this.button_remove.TabIndex = 13;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = false;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_openineditor
            // 
            this.button_openineditor.BackColor = System.Drawing.Color.White;
            this.button_openineditor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_openineditor.FlatAppearance.BorderSize = 2;
            this.button_openineditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_openineditor.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_openineditor.Location = new System.Drawing.Point(298, 18);
            this.button_openineditor.Name = "button_openineditor";
            this.button_openineditor.Size = new System.Drawing.Size(109, 36);
            this.button_openineditor.TabIndex = 14;
            this.button_openineditor.Text = "Open in editor";
            this.button_openineditor.UseVisualStyleBackColor = false;
            this.button_openineditor.Click += new System.EventHandler(this.button_openineditor_Click);
            // 
            // label_macro_keybind
            // 
            this.label_macro_keybind.AutoSize = true;
            this.label_macro_keybind.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_macro_keybind.Location = new System.Drawing.Point(221, 101);
            this.label_macro_keybind.Name = "label_macro_keybind";
            this.label_macro_keybind.Size = new System.Drawing.Size(71, 17);
            this.label_macro_keybind.TabIndex = 15;
            this.label_macro_keybind.Text = "Key Bind: ";
            // 
            // label_macro_charbind
            // 
            this.label_macro_charbind.AutoSize = true;
            this.label_macro_charbind.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_macro_charbind.Location = new System.Drawing.Point(221, 138);
            this.label_macro_charbind.Name = "label_macro_charbind";
            this.label_macro_charbind.Size = new System.Drawing.Size(76, 17);
            this.label_macro_charbind.TabIndex = 16;
            this.label_macro_charbind.Text = "Char Bind: ";
            // 
            // textBox_caption
            // 
            this.textBox_caption.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_caption.Location = new System.Drawing.Point(115, 44);
            this.textBox_caption.Name = "textBox_caption";
            this.textBox_caption.Size = new System.Drawing.Size(376, 25);
            this.textBox_caption.TabIndex = 17;
            this.textBox_caption.TextChanged += new System.EventHandler(this.textBox_caption_TextChanged);
            // 
            // comboBox_bdrate
            // 
            this.comboBox_bdrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bdrate.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.comboBox_bdrate.FormattingEnabled = true;
            this.comboBox_bdrate.Location = new System.Drawing.Point(147, 93);
            this.comboBox_bdrate.Name = "comboBox_bdrate";
            this.comboBox_bdrate.Size = new System.Drawing.Size(153, 25);
            this.comboBox_bdrate.TabIndex = 19;
            this.comboBox_bdrate.SelectedIndexChanged += new System.EventHandler(this.comboBox_bdrate_SelectedIndexChanged);
            // 
            // comboBox_portname
            // 
            this.comboBox_portname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_portname.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.comboBox_portname.FormattingEnabled = true;
            this.comboBox_portname.Location = new System.Drawing.Point(147, 54);
            this.comboBox_portname.Name = "comboBox_portname";
            this.comboBox_portname.Size = new System.Drawing.Size(153, 25);
            this.comboBox_portname.TabIndex = 20;
            this.comboBox_portname.SelectedIndexChanged += new System.EventHandler(this.comboBox_portname_SelectedIndexChanged);
            // 
            // label_caption
            // 
            this.label_caption.AutoSize = true;
            this.label_caption.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_caption.Location = new System.Drawing.Point(24, 47);
            this.label_caption.Name = "label_caption";
            this.label_caption.Size = new System.Drawing.Size(63, 17);
            this.label_caption.TabIndex = 21;
            this.label_caption.Text = "Caption: ";
            // 
            // label_macro_elemcount
            // 
            this.label_macro_elemcount.AutoSize = true;
            this.label_macro_elemcount.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_macro_elemcount.Location = new System.Drawing.Point(8, 139);
            this.label_macro_elemcount.Name = "label_macro_elemcount";
            this.label_macro_elemcount.Size = new System.Drawing.Size(73, 17);
            this.label_macro_elemcount.TabIndex = 18;
            this.label_macro_elemcount.Text = "Elements: ";
            // 
            // label_macro_path
            // 
            this.label_macro_path.AutoSize = true;
            this.label_macro_path.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_macro_path.Location = new System.Drawing.Point(8, 114);
            this.label_macro_path.Name = "label_macro_path";
            this.label_macro_path.Size = new System.Drawing.Size(44, 17);
            this.label_macro_path.TabIndex = 17;
            this.label_macro_path.Text = "Path: ";
            // 
            // label_discr
            // 
            this.label_discr.AutoSize = true;
            this.label_discr.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_discr.Location = new System.Drawing.Point(24, 128);
            this.label_discr.Name = "label_discr";
            this.label_discr.Size = new System.Drawing.Size(85, 17);
            this.label_discr.TabIndex = 25;
            this.label_discr.Text = "Discription: ";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_name.Location = new System.Drawing.Point(115, 86);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(376, 25);
            this.textBox_name.TabIndex = 24;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_name.Location = new System.Drawing.Point(24, 89);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(51, 17);
            this.label_name.TabIndex = 23;
            this.label_name.Text = "Name: ";
            // 
            // richTextBox_discr
            // 
            this.richTextBox_discr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_discr.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.richTextBox_discr.Location = new System.Drawing.Point(115, 128);
            this.richTextBox_discr.Name = "richTextBox_discr";
            this.richTextBox_discr.Size = new System.Drawing.Size(376, 60);
            this.richTextBox_discr.TabIndex = 22;
            this.richTextBox_discr.Text = "";
            this.richTextBox_discr.TextChanged += new System.EventHandler(this.richTextBox_discr_TextChanged);
            // 
            // label_portname
            // 
            this.label_portname.AutoSize = true;
            this.label_portname.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_portname.Location = new System.Drawing.Point(46, 57);
            this.label_portname.Name = "label_portname";
            this.label_portname.Size = new System.Drawing.Size(82, 17);
            this.label_portname.TabIndex = 17;
            this.label_portname.Text = "Port Name: ";
            // 
            // label_bdrate
            // 
            this.label_bdrate.AutoSize = true;
            this.label_bdrate.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_bdrate.Location = new System.Drawing.Point(46, 96);
            this.label_bdrate.Name = "label_bdrate";
            this.label_bdrate.Size = new System.Drawing.Size(63, 17);
            this.label_bdrate.TabIndex = 21;
            this.label_bdrate.Text = "Bd Rate: ";
            // 
            // label_samples
            // 
            this.label_samples.AutoSize = true;
            this.label_samples.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_samples.Location = new System.Drawing.Point(89, 249);
            this.label_samples.Name = "label_samples";
            this.label_samples.Size = new System.Drawing.Size(66, 17);
            this.label_samples.TabIndex = 21;
            this.label_samples.Text = "Samples: ";
            // 
            // button_samples_add
            // 
            this.button_samples_add.BackColor = System.Drawing.Color.White;
            this.button_samples_add.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_samples_add.FlatAppearance.BorderSize = 2;
            this.button_samples_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_samples_add.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_samples_add.Location = new System.Drawing.Point(416, 209);
            this.button_samples_add.Name = "button_samples_add";
            this.button_samples_add.Size = new System.Drawing.Size(75, 38);
            this.button_samples_add.TabIndex = 20;
            this.button_samples_add.Text = "Add";
            this.button_samples_add.UseVisualStyleBackColor = false;
            this.button_samples_add.Click += new System.EventHandler(this.button_samples_add_Click);
            // 
            // textBox_sample_value
            // 
            this.textBox_sample_value.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_sample_value.Location = new System.Drawing.Point(8, 209);
            this.textBox_sample_value.Name = "textBox_sample_value";
            this.textBox_sample_value.Size = new System.Drawing.Size(402, 25);
            this.textBox_sample_value.TabIndex = 19;
            this.textBox_sample_value.TextChanged += new System.EventHandler(this.textBox_sample_value_TextChanged);
            // 
            // button_samples_remove
            // 
            this.button_samples_remove.BackColor = System.Drawing.Color.White;
            this.button_samples_remove.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_samples_remove.FlatAppearance.BorderSize = 2;
            this.button_samples_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_samples_remove.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_samples_remove.Location = new System.Drawing.Point(8, 240);
            this.button_samples_remove.Name = "button_samples_remove";
            this.button_samples_remove.Size = new System.Drawing.Size(75, 35);
            this.button_samples_remove.TabIndex = 19;
            this.button_samples_remove.Text = "Remove";
            this.button_samples_remove.UseVisualStyleBackColor = false;
            this.button_samples_remove.Click += new System.EventHandler(this.button_samples_remove_Click);
            // 
            // listBox_samples
            // 
            this.listBox_samples.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.listBox_samples.FormattingEnabled = true;
            this.listBox_samples.ItemHeight = 17;
            this.listBox_samples.Location = new System.Drawing.Point(8, 46);
            this.listBox_samples.Name = "listBox_samples";
            this.listBox_samples.Size = new System.Drawing.Size(481, 157);
            this.listBox_samples.TabIndex = 19;
            this.listBox_samples.SelectedIndexChanged += new System.EventHandler(this.listBox_samples_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "macros";
            this.openFileDialog1.Filter = "PC Macros | *.pcmacros";
            this.openFileDialog1.InitialDirectory = "macros\\";
            this.openFileDialog1.Multiselect = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "PC Macro Pack|*.pcmpack";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PC Macro Pack|*.pcmpack";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage_connection);
            this.tabControl1.Controls.Add(this.tabPage_macro);
            this.tabControl1.Controls.Add(this.tabPage_sample);
            this.tabControl1.Location = new System.Drawing.Point(141, -24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 379);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage_main
            // 
            this.tabPage_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_main.Controls.Add(this.label_main_title);
            this.tabPage_main.Controls.Add(this.label_discr);
            this.tabPage_main.Controls.Add(this.textBox_name);
            this.tabPage_main.Controls.Add(this.richTextBox_discr);
            this.tabPage_main.Controls.Add(this.label_name);
            this.tabPage_main.Controls.Add(this.label_caption);
            this.tabPage_main.Controls.Add(this.textBox_caption);
            this.tabPage_main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(509, 353);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "tabPage1";
            // 
            // label_main_title
            // 
            this.label_main_title.AutoSize = true;
            this.label_main_title.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_main_title.Location = new System.Drawing.Point(17, 11);
            this.label_main_title.Name = "label_main_title";
            this.label_main_title.Size = new System.Drawing.Size(196, 22);
            this.label_main_title.TabIndex = 26;
            this.label_main_title.Text = "Основные параметры";
            // 
            // tabPage_connection
            // 
            this.tabPage_connection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_connection.Controls.Add(this.label_conn_title);
            this.tabPage_connection.Controls.Add(this.label_bdrate);
            this.tabPage_connection.Controls.Add(this.label_portname);
            this.tabPage_connection.Controls.Add(this.comboBox_bdrate);
            this.tabPage_connection.Controls.Add(this.comboBox_portname);
            this.tabPage_connection.Location = new System.Drawing.Point(4, 22);
            this.tabPage_connection.Name = "tabPage_connection";
            this.tabPage_connection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_connection.Size = new System.Drawing.Size(509, 353);
            this.tabPage_connection.TabIndex = 1;
            this.tabPage_connection.Text = "tabPage2";
            // 
            // label_conn_title
            // 
            this.label_conn_title.AutoSize = true;
            this.label_conn_title.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_conn_title.Location = new System.Drawing.Point(17, 11);
            this.label_conn_title.Name = "label_conn_title";
            this.label_conn_title.Size = new System.Drawing.Size(212, 22);
            this.label_conn_title.TabIndex = 23;
            this.label_conn_title.Text = "Параметры соеденения";
            // 
            // tabPage_macro
            // 
            this.tabPage_macro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_macro.Controls.Add(this.listBox_macroses);
            this.tabPage_macro.Controls.Add(this.pictureBox1);
            this.tabPage_macro.Controls.Add(this.panel_macroMain);
            this.tabPage_macro.Controls.Add(this.label_macro_title);
            this.tabPage_macro.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.tabPage_macro.Location = new System.Drawing.Point(4, 22);
            this.tabPage_macro.Name = "tabPage_macro";
            this.tabPage_macro.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_macro.Size = new System.Drawing.Size(509, 353);
            this.tabPage_macro.TabIndex = 2;
            this.tabPage_macro.Text = "Макросы";
            this.tabPage_macro.Click += new System.EventHandler(this.tabPage_macro_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(273, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 147);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel_macroMain
            // 
            this.panel_macroMain.Controls.Add(this.checkBox1);
            this.panel_macroMain.Controls.Add(this.comboBox_macro_charbind);
            this.panel_macroMain.Controls.Add(this.label_macro_charbind);
            this.panel_macroMain.Controls.Add(this.label_macro_elemcount);
            this.panel_macroMain.Controls.Add(this.label_macro_keybind);
            this.panel_macroMain.Controls.Add(this.label_macro_caption);
            this.panel_macroMain.Controls.Add(this.label_macro_path);
            this.panel_macroMain.Controls.Add(this.comboBox_macro_keybind);
            this.panel_macroMain.Controls.Add(this.button_addnew);
            this.panel_macroMain.Controls.Add(this.textBox_macro_caption);
            this.panel_macroMain.Controls.Add(this.button_repickpath);
            this.panel_macroMain.Controls.Add(this.button_openineditor);
            this.panel_macroMain.Controls.Add(this.button_remove);
            this.panel_macroMain.Controls.Add(this.label_macro_discr);
            this.panel_macroMain.Controls.Add(this.label_macro_name);
            this.panel_macroMain.Enabled = false;
            this.panel_macroMain.Location = new System.Drawing.Point(0, 180);
            this.panel_macroMain.Name = "panel_macroMain";
            this.panel_macroMain.Size = new System.Drawing.Size(511, 193);
            this.panel_macroMain.TabIndex = 25;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(413, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 21);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Скрыть";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label_macro_title
            // 
            this.label_macro_title.AutoSize = true;
            this.label_macro_title.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_macro_title.Location = new System.Drawing.Point(17, 11);
            this.label_macro_title.Name = "label_macro_title";
            this.label_macro_title.Size = new System.Drawing.Size(194, 22);
            this.label_macro_title.TabIndex = 23;
            this.label_macro_title.Text = "Параметры макросов";
            // 
            // tabPage_sample
            // 
            this.tabPage_sample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_sample.Controls.Add(this.label_sample_title);
            this.tabPage_sample.Controls.Add(this.label_samples);
            this.tabPage_sample.Controls.Add(this.listBox_samples);
            this.tabPage_sample.Controls.Add(this.button_samples_add);
            this.tabPage_sample.Controls.Add(this.button_samples_remove);
            this.tabPage_sample.Controls.Add(this.textBox_sample_value);
            this.tabPage_sample.Location = new System.Drawing.Point(4, 22);
            this.tabPage_sample.Name = "tabPage_sample";
            this.tabPage_sample.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_sample.Size = new System.Drawing.Size(509, 353);
            this.tabPage_sample.TabIndex = 3;
            this.tabPage_sample.Text = "tabPage4";
            // 
            // label_sample_title
            // 
            this.label_sample_title.AutoSize = true;
            this.label_sample_title.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sample_title.Location = new System.Drawing.Point(17, 11);
            this.label_sample_title.Name = "label_sample_title";
            this.label_sample_title.Size = new System.Drawing.Size(185, 22);
            this.label_sample_title.TabIndex = 22;
            this.label_sample_title.Text = "Параметры сэмплов";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.panel3.Controls.Add(this.button_preset);
            this.panel3.Controls.Add(this.button_macro);
            this.panel3.Controls.Add(this.button_conn);
            this.panel3.Controls.Add(this.button_close);
            this.panel3.Controls.Add(this.button_save);
            this.panel3.Controls.Add(this.button_load);
            this.panel3.Controls.Add(this.button_main);
            this.panel3.Location = new System.Drawing.Point(-3, -13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 361);
            this.panel3.TabIndex = 28;
            // 
            // button_preset
            // 
            this.button_preset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_preset.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_preset.FlatAppearance.BorderSize = 2;
            this.button_preset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_preset.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_preset.ForeColor = System.Drawing.Color.White;
            this.button_preset.Location = new System.Drawing.Point(18, 163);
            this.button_preset.Name = "button_preset";
            this.button_preset.Size = new System.Drawing.Size(122, 36);
            this.button_preset.TabIndex = 39;
            this.button_preset.Text = "Пресеты";
            this.button_preset.UseVisualStyleBackColor = false;
            this.button_preset.Click += new System.EventHandler(this.button_preset_Click);
            // 
            // button_macro
            // 
            this.button_macro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_macro.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_macro.FlatAppearance.BorderSize = 2;
            this.button_macro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_macro.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_macro.ForeColor = System.Drawing.Color.White;
            this.button_macro.Location = new System.Drawing.Point(18, 121);
            this.button_macro.Name = "button_macro";
            this.button_macro.Size = new System.Drawing.Size(122, 36);
            this.button_macro.TabIndex = 38;
            this.button_macro.Text = "Макросы";
            this.button_macro.UseVisualStyleBackColor = false;
            this.button_macro.Click += new System.EventHandler(this.button_macro_Click);
            // 
            // button_conn
            // 
            this.button_conn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_conn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_conn.FlatAppearance.BorderSize = 2;
            this.button_conn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_conn.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_conn.ForeColor = System.Drawing.Color.White;
            this.button_conn.Location = new System.Drawing.Point(18, 79);
            this.button_conn.Name = "button_conn";
            this.button_conn.Size = new System.Drawing.Size(122, 36);
            this.button_conn.TabIndex = 37;
            this.button_conn.Text = "Соеденение";
            this.button_conn.UseVisualStyleBackColor = false;
            this.button_conn.Click += new System.EventHandler(this.button_conn_Click);
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_close.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_close.FlatAppearance.BorderSize = 2;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_close.ForeColor = System.Drawing.Color.White;
            this.button_close.Location = new System.Drawing.Point(18, 310);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(122, 36);
            this.button_close.TabIndex = 2;
            this.button_close.Text = "Закрыть";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_main
            // 
            this.button_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(92)))), ((int)(((byte)(199)))));
            this.button_main.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_main.FlatAppearance.BorderSize = 2;
            this.button_main.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_main.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_main.ForeColor = System.Drawing.Color.White;
            this.button_main.Location = new System.Drawing.Point(18, 25);
            this.button_main.Name = "button_main";
            this.button_main.Size = new System.Drawing.Size(122, 48);
            this.button_main.TabIndex = 1;
            this.button_main.Text = "Основные параметры";
            this.button_main.UseVisualStyleBackColor = false;
            this.button_main.Click += new System.EventHandler(this.button_main_Click);
            // 
            // listBox_macroses
            // 
            this.listBox_macroses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_macroses.FormattingEnabled = true;
            this.listBox_macroses.ImageList = null;
            this.listBox_macroses.Location = new System.Drawing.Point(11, 45);
            this.listBox_macroses.Name = "listBox_macroses";
            this.listBox_macroses.Size = new System.Drawing.Size(256, 147);
            this.listBox_macroses.TabIndex = 24;
            this.listBox_macroses.SelectedIndexChanged += new System.EventHandler(this.listBox_macroses_SelectedIndexChanged);
            // 
            // Form_Dialog_MacroPackEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 345);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Dialog_MacroPackEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Macro-Pack";
            this.Load += new System.EventHandler(this.Dialog_MacroPackEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_main.PerformLayout();
            this.tabPage_connection.ResumeLayout(false);
            this.tabPage_connection.PerformLayout();
            this.tabPage_macro.ResumeLayout(false);
            this.tabPage_macro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_macroMain.ResumeLayout(false);
            this.panel_macroMain.PerformLayout();
            this.tabPage_sample.ResumeLayout(false);
            this.tabPage_sample.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
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
        private System.Windows.Forms.RichTextBox richTextBox_discr;
        private System.Windows.Forms.Label label_discr;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_portname;
        private System.Windows.Forms.Label label_bdrate;
        private System.Windows.Forms.Label label_macro_elemcount;
        private System.Windows.Forms.Label label_samples;
        private System.Windows.Forms.Button button_samples_add;
        private System.Windows.Forms.Button button_samples_remove;
        private System.Windows.Forms.ListBox listBox_samples;
        private System.Windows.Forms.TextBox textBox_sample_value;
        private System.Windows.Forms.Label label_macro_path;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage_connection;
        private System.Windows.Forms.TabPage tabPage_macro;
        private System.Windows.Forms.TabPage tabPage_sample;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_preset;
        private System.Windows.Forms.Button button_macro;
        private System.Windows.Forms.Button button_conn;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_main;
        private System.Windows.Forms.Label label_sample_title;
        private System.Windows.Forms.Label label_main_title;
        private System.Windows.Forms.Label label_conn_title;
        private System.Windows.Forms.Label label_macro_title;
        private ImageListBox listBox_macroses;
        private System.Windows.Forms.Panel panel_macroMain;
    }
}