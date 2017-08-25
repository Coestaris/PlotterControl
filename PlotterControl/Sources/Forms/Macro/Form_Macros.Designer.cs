/*=================================\
* PlotterControl\Form_Macros.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 25.08.2017 22:27
* Last Edited: 19.08.2017 7:38:22
*=================================*/

namespace CnC_WFA
{
    partial class Form_Macro
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Macro));
            this.listBox_elements = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.label_elements = new System.Windows.Forms.Label();
            this.groupBox_addel = new System.Windows.Forms.GroupBox();
            this.label_delay = new System.Windows.Forms.Label();
            this.groupBox_eltype = new System.Windows.Forms.GroupBox();
            this.radioButton_elt_none = new System.Windows.Forms.RadioButton();
            this.radioButton_elt_tdown = new System.Windows.Forms.RadioButton();
            this.radioButton_elt_move = new System.Windows.Forms.RadioButton();
            this.radioButton_elt_tup = new System.Windows.Forms.RadioButton();
            this.numericUpDown_delay = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button_addel = new System.Windows.Forms.Button();
            this.label_addstatus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_move_topointy = new System.Windows.Forms.TextBox();
            this.textBox_move_topointx = new System.Windows.Forms.TextBox();
            this.label_move_topointy = new System.Windows.Forms.Label();
            this.label_move_topointx = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox_move_offcoory = new System.Windows.Forms.TextBox();
            this.textBox_move_offcoorx = new System.Windows.Forms.TextBox();
            this.label_move_offcoory = new System.Windows.Forms.Label();
            this.label_move_offcoorx = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox_move_offanglelength = new System.Windows.Forms.TextBox();
            this.textBox_move_offangleangle = new System.Windows.Forms.TextBox();
            this.label_move_offanglelength = new System.Windows.Forms.Label();
            this.label_move_offangleangle = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label_move_horvertlen = new System.Windows.Forms.Label();
            this.textBox_move_offhorvertlength = new System.Windows.Forms.TextBox();
            this.radioButton_move_hor = new System.Windows.Forms.RadioButton();
            this.radioButton_move_vetr = new System.Windows.Forms.RadioButton();
            this.trackBar_zoom = new System.Windows.Forms.TrackBar();
            this.label_zoom = new System.Windows.Forms.Label();
            this.groupBox_zoom = new System.Windows.Forms.GroupBox();
            this.button_100percent = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_xglobal = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_new = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_load = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_macro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_name = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox_discr = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_tocorner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_addimg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_saveas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_main.SuspendLayout();
            this.groupBox_addel.SuspendLayout();
            this.groupBox_eltype.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoom)).BeginInit();
            this.groupBox_zoom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_elements
            // 
            this.listBox_elements.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_elements.FormattingEnabled = true;
            this.listBox_elements.ItemHeight = 15;
            this.listBox_elements.Location = new System.Drawing.Point(6, 24);
            this.listBox_elements.Name = "listBox_elements";
            this.listBox_elements.Size = new System.Drawing.Size(222, 139);
            this.listBox_elements.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(771, 595);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox1_PreviewKeyDown);
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.label_elements);
            this.groupBox_main.Controls.Add(this.listBox_elements);
            this.groupBox_main.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_main.Location = new System.Drawing.Point(832, 24);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(239, 193);
            this.groupBox_main.TabIndex = 4;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "Macros";
            // 
            // label_elements
            // 
            this.label_elements.AutoSize = true;
            this.label_elements.Location = new System.Drawing.Point(6, 166);
            this.label_elements.Name = "label_elements";
            this.label_elements.Size = new System.Drawing.Size(73, 17);
            this.label_elements.TabIndex = 5;
            this.label_elements.Text = "Elements: ";
            // 
            // groupBox_addel
            // 
            this.groupBox_addel.Controls.Add(this.label_delay);
            this.groupBox_addel.Controls.Add(this.groupBox_eltype);
            this.groupBox_addel.Controls.Add(this.numericUpDown_delay);
            this.groupBox_addel.Controls.Add(this.button1);
            this.groupBox_addel.Controls.Add(this.button_addel);
            this.groupBox_addel.Controls.Add(this.label_addstatus);
            this.groupBox_addel.Controls.Add(this.tabControl1);
            this.groupBox_addel.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_addel.Location = new System.Drawing.Point(832, 221);
            this.groupBox_addel.Name = "groupBox_addel";
            this.groupBox_addel.Size = new System.Drawing.Size(239, 365);
            this.groupBox_addel.TabIndex = 5;
            this.groupBox_addel.TabStop = false;
            this.groupBox_addel.Text = "Add Element";
            // 
            // label_delay
            // 
            this.label_delay.AutoSize = true;
            this.label_delay.Location = new System.Drawing.Point(17, 336);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(48, 17);
            this.label_delay.TabIndex = 10;
            this.label_delay.Text = "Delay:";
            // 
            // groupBox_eltype
            // 
            this.groupBox_eltype.Controls.Add(this.radioButton_elt_none);
            this.groupBox_eltype.Controls.Add(this.radioButton_elt_tdown);
            this.groupBox_eltype.Controls.Add(this.radioButton_elt_move);
            this.groupBox_eltype.Controls.Add(this.radioButton_elt_tup);
            this.groupBox_eltype.Location = new System.Drawing.Point(6, 89);
            this.groupBox_eltype.Name = "groupBox_eltype";
            this.groupBox_eltype.Size = new System.Drawing.Size(222, 69);
            this.groupBox_eltype.TabIndex = 7;
            this.groupBox_eltype.TabStop = false;
            this.groupBox_eltype.Text = "Element Type";
            // 
            // radioButton_elt_none
            // 
            this.radioButton_elt_none.AutoSize = true;
            this.radioButton_elt_none.Location = new System.Drawing.Point(127, 43);
            this.radioButton_elt_none.Name = "radioButton_elt_none";
            this.radioButton_elt_none.Size = new System.Drawing.Size(59, 21);
            this.radioButton_elt_none.TabIndex = 3;
            this.radioButton_elt_none.TabStop = true;
            this.radioButton_elt_none.Text = "None";
            this.radioButton_elt_none.UseVisualStyleBackColor = true;
            // 
            // radioButton_elt_tdown
            // 
            this.radioButton_elt_tdown.AutoSize = true;
            this.radioButton_elt_tdown.Location = new System.Drawing.Point(14, 43);
            this.radioButton_elt_tdown.Name = "radioButton_elt_tdown";
            this.radioButton_elt_tdown.Size = new System.Drawing.Size(95, 21);
            this.radioButton_elt_tdown.TabIndex = 2;
            this.radioButton_elt_tdown.TabStop = true;
            this.radioButton_elt_tdown.Text = "Tool Down";
            this.radioButton_elt_tdown.UseVisualStyleBackColor = true;
            // 
            // radioButton_elt_move
            // 
            this.radioButton_elt_move.AutoSize = true;
            this.radioButton_elt_move.Location = new System.Drawing.Point(126, 20);
            this.radioButton_elt_move.Name = "radioButton_elt_move";
            this.radioButton_elt_move.Size = new System.Drawing.Size(61, 21);
            this.radioButton_elt_move.TabIndex = 1;
            this.radioButton_elt_move.TabStop = true;
            this.radioButton_elt_move.Text = "Move";
            this.radioButton_elt_move.UseVisualStyleBackColor = true;
            this.radioButton_elt_move.CheckedChanged += new System.EventHandler(this.radioButton_elt_move_CheckedChanged);
            // 
            // radioButton_elt_tup
            // 
            this.radioButton_elt_tup.AutoSize = true;
            this.radioButton_elt_tup.Location = new System.Drawing.Point(14, 20);
            this.radioButton_elt_tup.Name = "radioButton_elt_tup";
            this.radioButton_elt_tup.Size = new System.Drawing.Size(75, 21);
            this.radioButton_elt_tup.TabIndex = 0;
            this.radioButton_elt_tup.TabStop = true;
            this.radioButton_elt_tup.Text = "Tool Up";
            this.radioButton_elt_tup.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_delay
            // 
            this.numericUpDown_delay.Location = new System.Drawing.Point(142, 334);
            this.numericUpDown_delay.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown_delay.Name = "numericUpDown_delay";
            this.numericUpDown_delay.Size = new System.Drawing.Size(86, 25);
            this.numericUpDown_delay.TabIndex = 11;
            this.numericUpDown_delay.ThousandsSeparator = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(147, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button_addel
            // 
            this.button_addel.BackColor = System.Drawing.Color.White;
            this.button_addel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_addel.FlatAppearance.BorderSize = 2;
            this.button_addel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addel.Location = new System.Drawing.Point(9, 24);
            this.button_addel.Name = "button_addel";
            this.button_addel.Size = new System.Drawing.Size(132, 33);
            this.button_addel.TabIndex = 4;
            this.button_addel.Text = "Add New Element";
            this.button_addel.UseVisualStyleBackColor = false;
            this.button_addel.Click += new System.EventHandler(this.button_addel_Click);
            // 
            // label_addstatus
            // 
            this.label_addstatus.AutoSize = true;
            this.label_addstatus.Location = new System.Drawing.Point(12, 65);
            this.label_addstatus.Name = "label_addstatus";
            this.label_addstatus.Size = new System.Drawing.Size(109, 17);
            this.label_addstatus.TabIndex = 3;
            this.label_addstatus.Text = "Result Element: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(15, 164);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(213, 164);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            this.tabControl1.MouseEnter += new System.EventHandler(this.tabControl1_MouseEnter);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.textBox_move_topointy);
            this.tabPage1.Controls.Add(this.textBox_move_topointx);
            this.tabPage1.Controls.Add(this.label_move_topointy);
            this.tabPage1.Controls.Add(this.label_move_topointx);
            this.tabPage1.Location = new System.Drawing.Point(4, 92);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(205, 68);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "To Point";
            // 
            // textBox_move_topointy
            // 
            this.textBox_move_topointy.Location = new System.Drawing.Point(66, 34);
            this.textBox_move_topointy.Name = "textBox_move_topointy";
            this.textBox_move_topointy.Size = new System.Drawing.Size(134, 25);
            this.textBox_move_topointy.TabIndex = 3;
            this.textBox_move_topointy.Text = "0";
            this.textBox_move_topointy.TextChanged += new System.EventHandler(this.textBox_move_topointy_TextChanged);
            this.textBox_move_topointy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_move_topointy_KeyDown);
            // 
            // textBox_move_topointx
            // 
            this.textBox_move_topointx.Location = new System.Drawing.Point(66, 5);
            this.textBox_move_topointx.Name = "textBox_move_topointx";
            this.textBox_move_topointx.Size = new System.Drawing.Size(134, 25);
            this.textBox_move_topointx.TabIndex = 2;
            this.textBox_move_topointx.Text = "0";
            this.textBox_move_topointx.TextChanged += new System.EventHandler(this.textBox_move_topointx_TextChanged);
            this.textBox_move_topointx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_move_topointx_KeyDown);
            // 
            // label_move_topointy
            // 
            this.label_move_topointy.AutoSize = true;
            this.label_move_topointy.Location = new System.Drawing.Point(6, 37);
            this.label_move_topointy.Name = "label_move_topointy";
            this.label_move_topointy.Size = new System.Drawing.Size(60, 17);
            this.label_move_topointy.TabIndex = 1;
            this.label_move_topointy.Text = "Point Y: ";
            // 
            // label_move_topointx
            // 
            this.label_move_topointx.AutoSize = true;
            this.label_move_topointx.Location = new System.Drawing.Point(6, 8);
            this.label_move_topointx.Name = "label_move_topointx";
            this.label_move_topointx.Size = new System.Drawing.Size(61, 17);
            this.label_move_topointx.TabIndex = 0;
            this.label_move_topointx.Text = "Point X: ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.textBox_move_offcoory);
            this.tabPage2.Controls.Add(this.textBox_move_offcoorx);
            this.tabPage2.Controls.Add(this.label_move_offcoory);
            this.tabPage2.Controls.Add(this.label_move_offcoorx);
            this.tabPage2.Location = new System.Drawing.Point(4, 92);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(205, 68);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Offset Tool Coordinats";
            // 
            // textBox_move_offcoory
            // 
            this.textBox_move_offcoory.Location = new System.Drawing.Point(66, 34);
            this.textBox_move_offcoory.Name = "textBox_move_offcoory";
            this.textBox_move_offcoory.Size = new System.Drawing.Size(134, 25);
            this.textBox_move_offcoory.TabIndex = 7;
            // 
            // textBox_move_offcoorx
            // 
            this.textBox_move_offcoorx.Location = new System.Drawing.Point(66, 5);
            this.textBox_move_offcoorx.Name = "textBox_move_offcoorx";
            this.textBox_move_offcoorx.Size = new System.Drawing.Size(134, 25);
            this.textBox_move_offcoorx.TabIndex = 6;
            // 
            // label_move_offcoory
            // 
            this.label_move_offcoory.AutoSize = true;
            this.label_move_offcoory.Location = new System.Drawing.Point(6, 37);
            this.label_move_offcoory.Name = "label_move_offcoory";
            this.label_move_offcoory.Size = new System.Drawing.Size(65, 17);
            this.label_move_offcoory.TabIndex = 5;
            this.label_move_offcoory.Text = "Y Offset: ";
            // 
            // label_move_offcoorx
            // 
            this.label_move_offcoorx.AutoSize = true;
            this.label_move_offcoorx.Location = new System.Drawing.Point(6, 8);
            this.label_move_offcoorx.Name = "label_move_offcoorx";
            this.label_move_offcoorx.Size = new System.Drawing.Size(65, 17);
            this.label_move_offcoorx.TabIndex = 4;
            this.label_move_offcoorx.Text = "X Offset: ";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.textBox_move_offanglelength);
            this.tabPage3.Controls.Add(this.textBox_move_offangleangle);
            this.tabPage3.Controls.Add(this.label_move_offanglelength);
            this.tabPage3.Controls.Add(this.label_move_offangleangle);
            this.tabPage3.Location = new System.Drawing.Point(4, 92);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(205, 68);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Offset Tool Angle";
            // 
            // textBox_move_offanglelength
            // 
            this.textBox_move_offanglelength.Location = new System.Drawing.Point(66, 34);
            this.textBox_move_offanglelength.Name = "textBox_move_offanglelength";
            this.textBox_move_offanglelength.Size = new System.Drawing.Size(134, 25);
            this.textBox_move_offanglelength.TabIndex = 7;
            // 
            // textBox_move_offangleangle
            // 
            this.textBox_move_offangleangle.Location = new System.Drawing.Point(66, 5);
            this.textBox_move_offangleangle.Name = "textBox_move_offangleangle";
            this.textBox_move_offangleangle.Size = new System.Drawing.Size(134, 25);
            this.textBox_move_offangleangle.TabIndex = 6;
            // 
            // label_move_offanglelength
            // 
            this.label_move_offanglelength.AutoSize = true;
            this.label_move_offanglelength.Location = new System.Drawing.Point(10, 37);
            this.label_move_offanglelength.Name = "label_move_offanglelength";
            this.label_move_offanglelength.Size = new System.Drawing.Size(58, 17);
            this.label_move_offanglelength.TabIndex = 5;
            this.label_move_offanglelength.Text = "Length: ";
            // 
            // label_move_offangleangle
            // 
            this.label_move_offangleangle.AutoSize = true;
            this.label_move_offangleangle.Location = new System.Drawing.Point(10, 8);
            this.label_move_offangleangle.Name = "label_move_offangleangle";
            this.label_move_offangleangle.Size = new System.Drawing.Size(50, 17);
            this.label_move_offangleangle.TabIndex = 4;
            this.label_move_offangleangle.Text = "Angle: ";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.label_move_horvertlen);
            this.tabPage4.Controls.Add(this.textBox_move_offhorvertlength);
            this.tabPage4.Controls.Add(this.radioButton_move_hor);
            this.tabPage4.Controls.Add(this.radioButton_move_vetr);
            this.tabPage4.Location = new System.Drawing.Point(4, 92);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(205, 68);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Offset Tool Hor\\Vert";
            // 
            // label_move_horvertlen
            // 
            this.label_move_horvertlen.AutoSize = true;
            this.label_move_horvertlen.Location = new System.Drawing.Point(6, 39);
            this.label_move_horvertlen.Name = "label_move_horvertlen";
            this.label_move_horvertlen.Size = new System.Drawing.Size(58, 17);
            this.label_move_horvertlen.TabIndex = 3;
            this.label_move_horvertlen.Text = "Length: ";
            // 
            // textBox_move_offhorvertlength
            // 
            this.textBox_move_offhorvertlength.Location = new System.Drawing.Point(66, 36);
            this.textBox_move_offhorvertlength.Name = "textBox_move_offhorvertlength";
            this.textBox_move_offhorvertlength.Size = new System.Drawing.Size(133, 25);
            this.textBox_move_offhorvertlength.TabIndex = 2;
            // 
            // radioButton_move_hor
            // 
            this.radioButton_move_hor.AutoSize = true;
            this.radioButton_move_hor.Location = new System.Drawing.Point(106, 11);
            this.radioButton_move_hor.Name = "radioButton_move_hor";
            this.radioButton_move_hor.Size = new System.Drawing.Size(93, 21);
            this.radioButton_move_hor.TabIndex = 1;
            this.radioButton_move_hor.TabStop = true;
            this.radioButton_move_hor.Text = "Horizontal";
            this.radioButton_move_hor.UseVisualStyleBackColor = true;
            // 
            // radioButton_move_vetr
            // 
            this.radioButton_move_vetr.AutoSize = true;
            this.radioButton_move_vetr.Location = new System.Drawing.Point(9, 11);
            this.radioButton_move_vetr.Name = "radioButton_move_vetr";
            this.radioButton_move_vetr.Size = new System.Drawing.Size(74, 21);
            this.radioButton_move_vetr.TabIndex = 0;
            this.radioButton_move_vetr.TabStop = true;
            this.radioButton_move_vetr.Text = "Veritcal";
            this.radioButton_move_vetr.UseVisualStyleBackColor = true;
            // 
            // trackBar_zoom
            // 
            this.trackBar_zoom.LargeChange = 15;
            this.trackBar_zoom.Location = new System.Drawing.Point(6, 20);
            this.trackBar_zoom.Maximum = 400;
            this.trackBar_zoom.Minimum = 10;
            this.trackBar_zoom.Name = "trackBar_zoom";
            this.trackBar_zoom.Size = new System.Drawing.Size(166, 45);
            this.trackBar_zoom.SmallChange = 10;
            this.trackBar_zoom.TabIndex = 0;
            this.trackBar_zoom.TickFrequency = 5;
            this.trackBar_zoom.Value = 100;
            this.trackBar_zoom.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label_zoom
            // 
            this.label_zoom.AutoSize = true;
            this.label_zoom.Location = new System.Drawing.Point(6, 51);
            this.label_zoom.Name = "label_zoom";
            this.label_zoom.Size = new System.Drawing.Size(48, 17);
            this.label_zoom.TabIndex = 1;
            this.label_zoom.Text = "100 %";
            // 
            // groupBox_zoom
            // 
            this.groupBox_zoom.Controls.Add(this.button_100percent);
            this.groupBox_zoom.Controls.Add(this.label_zoom);
            this.groupBox_zoom.Controls.Add(this.trackBar_zoom);
            this.groupBox_zoom.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_zoom.Location = new System.Drawing.Point(832, 592);
            this.groupBox_zoom.Name = "groupBox_zoom";
            this.groupBox_zoom.Size = new System.Drawing.Size(239, 71);
            this.groupBox_zoom.TabIndex = 7;
            this.groupBox_zoom.TabStop = false;
            this.groupBox_zoom.Text = "Zoom";
            // 
            // button_100percent
            // 
            this.button_100percent.BackColor = System.Drawing.Color.White;
            this.button_100percent.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_100percent.FlatAppearance.BorderSize = 2;
            this.button_100percent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_100percent.Location = new System.Drawing.Point(168, 19);
            this.button_100percent.Name = "button_100percent";
            this.button_100percent.Size = new System.Drawing.Size(60, 33);
            this.button_100percent.TabIndex = 2;
            this.button_100percent.Text = "100%";
            this.button_100percent.UseVisualStyleBackColor = false;
            this.button_100percent.Click += new System.EventHandler(this.button_100percent_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_xglobal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 666);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1083, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_xglobal
            // 
            this.toolStripStatusLabel_xglobal.Name = "toolStripStatusLabel_xglobal";
            this.toolStripStatusLabel_xglobal.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel_xglobal.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(5, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 639);
            this.panel1.TabIndex = 9;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PC Macros | *.pcmacros";
            this.saveFileDialog1.InitialDirectory = "macros\\";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "macros";
            this.openFileDialog1.Filter = "PC Macros | *.pcmacros";
            this.openFileDialog1.InitialDirectory = "macros\\";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_file,
            this.toolStripMenuItem_macro});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1083, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "Файл";
            // 
            // toolStripMenuItem_file
            // 
            this.toolStripMenuItem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_new,
            this.toolStripMenuItem_load,
            this.toolStripSeparator3,
            this.toolStripMenuItem_saveas,
            this.toolStripMenuItem_save,
            this.toolStripSeparator1,
            this.toolStripMenuItem_close});
            this.toolStripMenuItem_file.Name = "toolStripMenuItem_file";
            this.toolStripMenuItem_file.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem_file.Text = "Файл";
            // 
            // toolStripMenuItem_new
            // 
            this.toolStripMenuItem_new.Name = "toolStripMenuItem_new";
            this.toolStripMenuItem_new.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_new.Text = "Новый";
            this.toolStripMenuItem_new.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // toolStripMenuItem_save
            // 
            this.toolStripMenuItem_save.Name = "toolStripMenuItem_save";
            this.toolStripMenuItem_save.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_save.Text = "Сохранить";
            this.toolStripMenuItem_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // toolStripMenuItem_load
            // 
            this.toolStripMenuItem_load.Name = "toolStripMenuItem_load";
            this.toolStripMenuItem_load.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_load.Text = "Загрузить";
            this.toolStripMenuItem_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripMenuItem_close
            // 
            this.toolStripMenuItem_close.Name = "toolStripMenuItem_close";
            this.toolStripMenuItem_close.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_close.Text = "Закрыть";
            this.toolStripMenuItem_close.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStripMenuItem_macro
            // 
            this.toolStripMenuItem_macro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_name,
            this.toolStripTextBox_discr,
            this.toolStripSeparator2,
            this.toolStripMenuItem_tocorner,
            this.toolStripMenuItem_addimg});
            this.toolStripMenuItem_macro.Name = "toolStripMenuItem_macro";
            this.toolStripMenuItem_macro.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem_macro.Text = "Макрос";
            // 
            // toolStripTextBox_name
            // 
            this.toolStripTextBox_name.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripTextBox_name.Name = "toolStripTextBox_name";
            this.toolStripTextBox_name.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_name.Text = "Имя";
            this.toolStripTextBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // toolStripTextBox_discr
            // 
            this.toolStripTextBox_discr.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripTextBox_discr.Name = "toolStripTextBox_discr";
            this.toolStripTextBox_discr.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_discr.Text = "Описание";
            this.toolStripTextBox_discr.TextChanged += new System.EventHandler(this.textBox_descr_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // toolStripMenuItem_tocorner
            // 
            this.toolStripMenuItem_tocorner.Name = "toolStripMenuItem_tocorner";
            this.toolStripMenuItem_tocorner.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem_tocorner.Text = "Переместить";
            // 
            // toolStripMenuItem_addimg
            // 
            this.toolStripMenuItem_addimg.Name = "toolStripMenuItem_addimg";
            this.toolStripMenuItem_addimg.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem_addimg.Text = "Добавить изобр.";
            // 
            // toolStripMenuItem_saveas
            // 
            this.toolStripMenuItem_saveas.Enabled = false;
            this.toolStripMenuItem_saveas.Name = "toolStripMenuItem_saveas";
            this.toolStripMenuItem_saveas.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_saveas.Text = "Сохранить как";
            this.toolStripMenuItem_saveas.Click += new System.EventHandler(this.toolStripMenuItem_saveas_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // Form_Macro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1083, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox_zoom);
            this.Controls.Add(this.groupBox_addel);
            this.Controls.Add(this.groupBox_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1099, 726);
            this.Name = "Form_Macro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_macroses";
            this.Load += new System.EventHandler(this.Form_macroses_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_macroses_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_macroses_MouseMove);
            this.Resize += new System.EventHandler(this.Form_macroses_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            this.groupBox_addel.ResumeLayout(false);
            this.groupBox_addel.PerformLayout();
            this.groupBox_eltype.ResumeLayout(false);
            this.groupBox_eltype.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoom)).EndInit();
            this.groupBox_zoom.ResumeLayout(false);
            this.groupBox_zoom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_elements;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.Label label_elements;
        private System.Windows.Forms.GroupBox groupBox_addel;
        private System.Windows.Forms.Button button_addel;
        private System.Windows.Forms.Label label_addstatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TrackBar trackBar_zoom;
        private System.Windows.Forms.Label label_zoom;
        private System.Windows.Forms.GroupBox groupBox_zoom;
        private System.Windows.Forms.Button button_100percent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.NumericUpDown numericUpDown_delay;
        private System.Windows.Forms.GroupBox groupBox_eltype;
        private System.Windows.Forms.RadioButton radioButton_elt_none;
        private System.Windows.Forms.RadioButton radioButton_elt_tdown;
        private System.Windows.Forms.RadioButton radioButton_elt_move;
        private System.Windows.Forms.RadioButton radioButton_elt_tup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_xglobal;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox_move_topointy;
        private System.Windows.Forms.TextBox textBox_move_topointx;
        private System.Windows.Forms.Label label_move_topointy;
        private System.Windows.Forms.Label label_move_topointx;
        private System.Windows.Forms.TextBox textBox_move_offcoory;
        private System.Windows.Forms.TextBox textBox_move_offcoorx;
        private System.Windows.Forms.Label label_move_offcoory;
        private System.Windows.Forms.Label label_move_offcoorx;
        private System.Windows.Forms.TextBox textBox_move_offanglelength;
        private System.Windows.Forms.TextBox textBox_move_offangleangle;
        private System.Windows.Forms.Label label_move_offanglelength;
        private System.Windows.Forms.Label label_move_offangleangle;
        private System.Windows.Forms.TextBox textBox_move_offhorvertlength;
        private System.Windows.Forms.RadioButton radioButton_move_hor;
        private System.Windows.Forms.RadioButton radioButton_move_vetr;
        private System.Windows.Forms.Label label_move_horvertlen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_new;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_save;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_load;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_close;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_macro;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_name;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_discr;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_tocorner;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_addimg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_saveas;
    }
}
