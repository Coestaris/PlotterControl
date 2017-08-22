/*=================================\
* PlotterControl\Form_ViewVect.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:26:46
*=================================*/

namespace CnC_WFA
{
    partial class Form_ViewVect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ViewVect));
            this.button_exit = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_pick2ndcolor = new System.Windows.Forms.Button();
            this.button_pickcolor = new System.Windows.Forms.Button();
            this.button_outter = new System.Windows.Forms.Button();
            this.button_redraw = new System.Windows.Forms.Button();
            this.label_pathtofile = new System.Windows.Forms.Label();
            this.checkBox_onecolor = new System.Windows.Forms.CheckBox();
            this.button_pick_onecolordraw = new System.Windows.Forms.Button();
            this.textBox_latency = new System.Windows.Forms.TextBox();
            this.label_latency = new System.Windows.Forms.Label();
            this.button_pause = new System.Windows.Forms.Button();
            this.label_counters = new System.Windows.Forms.Label();
            this.button_begindraw = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.label_status = new System.Windows.Forms.Label();
            this.button_print = new System.Windows.Forms.Button();
            this.groupBox_contours = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_filename = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_resolution = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_oldprstyle = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_realtime = new System.Windows.Forms.GroupBox();
            this.label_ms = new System.Windows.Forms.Label();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.checkBox_randomcolor = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            this.groupBox_contours.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox_realtime.SuspendLayout();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_exit
            // 
            this.button_exit.AllowDrop = true;
            this.button_exit.BackColor = System.Drawing.Color.White;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_exit.Location = new System.Drawing.Point(826, 611);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(78, 36);
            this.button_exit.TabIndex = 18;
            this.button_exit.Text = "??????????";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            this.button_exit.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_exit.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_load
            // 
            this.button_load.AllowDrop = true;
            this.button_load.BackColor = System.Drawing.Color.White;
            this.button_load.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_load.FlatAppearance.BorderSize = 2;
            this.button_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_load.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_load.Location = new System.Drawing.Point(722, 611);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(98, 36);
            this.button_load.TabIndex = 14;
            this.button_load.Text = "??????????????????";
            this.button_load.UseVisualStyleBackColor = false;
            this.button_load.Click += new System.EventHandler(this.button4_Click);
            this.button_load.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_load.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Items.AddRange(new object[] {
            "contours"});
            this.listBox1.Location = new System.Drawing.Point(7, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(253, 259);
            this.listBox1.TabIndex = 13;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_pick2ndcolor
            // 
            this.button_pick2ndcolor.AllowDrop = true;
            this.button_pick2ndcolor.BackColor = System.Drawing.Color.White;
            this.button_pick2ndcolor.Enabled = false;
            this.button_pick2ndcolor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pick2ndcolor.FlatAppearance.BorderSize = 2;
            this.button_pick2ndcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pick2ndcolor.Location = new System.Drawing.Point(125, 48);
            this.button_pick2ndcolor.Name = "button_pick2ndcolor";
            this.button_pick2ndcolor.Size = new System.Drawing.Size(75, 36);
            this.button_pick2ndcolor.TabIndex = 18;
            this.button_pick2ndcolor.Text = "??????";
            this.button_pick2ndcolor.UseVisualStyleBackColor = false;
            this.button_pick2ndcolor.Click += new System.EventHandler(this.button_pick2ndcolor_Click);
            this.button_pick2ndcolor.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_pick2ndcolor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_pickcolor
            // 
            this.button_pickcolor.AllowDrop = true;
            this.button_pickcolor.BackColor = System.Drawing.Color.White;
            this.button_pickcolor.Enabled = false;
            this.button_pickcolor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pickcolor.FlatAppearance.BorderSize = 2;
            this.button_pickcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pickcolor.Location = new System.Drawing.Point(125, 90);
            this.button_pickcolor.Name = "button_pickcolor";
            this.button_pickcolor.Size = new System.Drawing.Size(75, 38);
            this.button_pickcolor.TabIndex = 17;
            this.button_pickcolor.Text = "??????????";
            this.button_pickcolor.UseVisualStyleBackColor = false;
            this.button_pickcolor.Click += new System.EventHandler(this.button_pickcolor_Click);
            this.button_pickcolor.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_pickcolor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_outter
            // 
            this.button_outter.AllowDrop = true;
            this.button_outter.BackColor = System.Drawing.Color.White;
            this.button_outter.Enabled = false;
            this.button_outter.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_outter.FlatAppearance.BorderSize = 2;
            this.button_outter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_outter.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_outter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_outter.Location = new System.Drawing.Point(6, 90);
            this.button_outter.Name = "button_outter";
            this.button_outter.Size = new System.Drawing.Size(116, 38);
            this.button_outter.TabIndex = 16;
            this.button_outter.Text = "????. ????????????????";
            this.button_outter.UseVisualStyleBackColor = false;
            this.button_outter.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_outter.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_redraw
            // 
            this.button_redraw.AllowDrop = true;
            this.button_redraw.BackColor = System.Drawing.Color.White;
            this.button_redraw.Enabled = false;
            this.button_redraw.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_redraw.FlatAppearance.BorderSize = 2;
            this.button_redraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_redraw.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_redraw.Location = new System.Drawing.Point(6, 48);
            this.button_redraw.Name = "button_redraw";
            this.button_redraw.Size = new System.Drawing.Size(116, 36);
            this.button_redraw.TabIndex = 12;
            this.button_redraw.Text = "????????????????????????";
            this.button_redraw.UseVisualStyleBackColor = false;
            this.button_redraw.Click += new System.EventHandler(this.button_redraw_Click);
            this.button_redraw.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_redraw.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // label_pathtofile
            // 
            this.label_pathtofile.AllowDrop = true;
            this.label_pathtofile.Enabled = false;
            this.label_pathtofile.Location = new System.Drawing.Point(7, 20);
            this.label_pathtofile.Name = "label_pathtofile";
            this.label_pathtofile.Size = new System.Drawing.Size(242, 18);
            this.label_pathtofile.TabIndex = 1;
            this.label_pathtofile.Text = "???????? ?? ??????????: ";
            this.label_pathtofile.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.label_pathtofile.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // checkBox_onecolor
            // 
            this.checkBox_onecolor.AllowDrop = true;
            this.checkBox_onecolor.Enabled = false;
            this.checkBox_onecolor.Location = new System.Drawing.Point(12, 33);
            this.checkBox_onecolor.Name = "checkBox_onecolor";
            this.checkBox_onecolor.Size = new System.Drawing.Size(123, 22);
            this.checkBox_onecolor.TabIndex = 10;
            this.checkBox_onecolor.Text = "????????-??????????????";
            this.checkBox_onecolor.UseVisualStyleBackColor = true;
            this.checkBox_onecolor.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.checkBox_onecolor.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_pick_onecolordraw
            // 
            this.button_pick_onecolordraw.AllowDrop = true;
            this.button_pick_onecolordraw.BackColor = System.Drawing.Color.White;
            this.button_pick_onecolordraw.Enabled = false;
            this.button_pick_onecolordraw.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pick_onecolordraw.FlatAppearance.BorderSize = 2;
            this.button_pick_onecolordraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pick_onecolordraw.Location = new System.Drawing.Point(133, 27);
            this.button_pick_onecolordraw.Name = "button_pick_onecolordraw";
            this.button_pick_onecolordraw.Size = new System.Drawing.Size(32, 31);
            this.button_pick_onecolordraw.TabIndex = 11;
            this.button_pick_onecolordraw.Text = "...";
            this.button_pick_onecolordraw.UseVisualStyleBackColor = false;
            this.button_pick_onecolordraw.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_pick_onecolordraw.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // textBox_latency
            // 
            this.textBox_latency.AllowDrop = true;
            this.textBox_latency.Enabled = false;
            this.textBox_latency.Location = new System.Drawing.Point(84, 72);
            this.textBox_latency.Name = "textBox_latency";
            this.textBox_latency.Size = new System.Drawing.Size(49, 25);
            this.textBox_latency.TabIndex = 2;
            this.textBox_latency.Text = "1";
            this.textBox_latency.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.textBox_latency.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // label_latency
            // 
            this.label_latency.AllowDrop = true;
            this.label_latency.Enabled = false;
            this.label_latency.Location = new System.Drawing.Point(10, 75);
            this.label_latency.Name = "label_latency";
            this.label_latency.Size = new System.Drawing.Size(78, 20);
            this.label_latency.TabIndex = 8;
            this.label_latency.Text = "????????????????: ";
            this.label_latency.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.label_latency.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_pause
            // 
            this.button_pause.AllowDrop = true;
            this.button_pause.BackColor = System.Drawing.Color.White;
            this.button_pause.Enabled = false;
            this.button_pause.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pause.FlatAppearance.BorderSize = 2;
            this.button_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pause.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_pause.Location = new System.Drawing.Point(171, 66);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(91, 34);
            this.button_pause.TabIndex = 6;
            this.button_pause.Text = "??????????";
            this.button_pause.UseVisualStyleBackColor = false;
            this.button_pause.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_pause.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // label_counters
            // 
            this.label_counters.AllowDrop = true;
            this.label_counters.Enabled = false;
            this.label_counters.Location = new System.Drawing.Point(216, 119);
            this.label_counters.Name = "label_counters";
            this.label_counters.Size = new System.Drawing.Size(44, 19);
            this.label_counters.TabIndex = 9;
            this.label_counters.Text = "0/0";
            this.label_counters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_counters.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.label_counters.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // button_begindraw
            // 
            this.button_begindraw.AllowDrop = true;
            this.button_begindraw.BackColor = System.Drawing.Color.White;
            this.button_begindraw.Enabled = false;
            this.button_begindraw.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_begindraw.FlatAppearance.BorderSize = 2;
            this.button_begindraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_begindraw.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_begindraw.Location = new System.Drawing.Point(171, 24);
            this.button_begindraw.Name = "button_begindraw";
            this.button_begindraw.Size = new System.Drawing.Size(91, 36);
            this.button_begindraw.TabIndex = 1;
            this.button_begindraw.Text = "????????????";
            this.button_begindraw.UseVisualStyleBackColor = false;
            this.button_begindraw.Click += new System.EventHandler(this.button_begindraw_Click);
            this.button_begindraw.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_begindraw.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // trackBar1
            // 
            this.trackBar1.AllowDrop = true;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(6, 90);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(254, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.trackBar1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_main.Location = new System.Drawing.Point(9, 8);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(623, 637);
            this.pictureBox_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_main.TabIndex = 16;
            this.pictureBox_main.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "VectFile.pcv";
            this.openFileDialog1.Filter = "PrRes Files(*.pcv)|*.pcv|PrRes Files(*.prres)|*.prres";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = false;
            this.loadingCircle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle1.BackgroundImage")));
            this.loadingCircle1.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle1.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle1.InnerCircleRadius = 5;
            this.loadingCircle1.Location = new System.Drawing.Point(283, 274);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 12;
            this.loadingCircle1.OuterCircleRadius = 11;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle1.SpokeThickness = 2;
            this.loadingCircle1.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle1.TabIndex = 32;
            this.loadingCircle1.Text = "loadingCircle2";
            this.loadingCircle1.UseWaitCursor = true;
            this.loadingCircle1.Visible = false;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label_status.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_status.Location = new System.Drawing.Point(280, 317);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(90, 17);
            this.label_status.TabIndex = 33;
            this.label_status.Text = "??????????????????...";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_status.Visible = false;
            // 
            // button_print
            // 
            this.button_print.AllowDrop = true;
            this.button_print.BackColor = System.Drawing.Color.White;
            this.button_print.Enabled = false;
            this.button_print.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_print.FlatAppearance.BorderSize = 2;
            this.button_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_print.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_print.Location = new System.Drawing.Point(638, 611);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(78, 36);
            this.button_print.TabIndex = 19;
            this.button_print.Text = "????????????";
            this.button_print.UseVisualStyleBackColor = false;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            this.button_print.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.button_print.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // groupBox_contours
            // 
            this.groupBox_contours.Controls.Add(this.listBox1);
            this.groupBox_contours.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_contours.Location = new System.Drawing.Point(638, 317);
            this.groupBox_contours.Name = "groupBox_contours";
            this.groupBox_contours.Size = new System.Drawing.Size(266, 291);
            this.groupBox_contours.TabIndex = 34;
            this.groupBox_contours.TabStop = false;
            this.groupBox_contours.Text = "??????????????";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowDrop = true;
            this.statusStrip1.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_filename,
            this.toolStripStatusLabel_resolution,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_oldprstyle});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(912, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.statusStrip1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // toolStripStatusLabel_filename
            // 
            this.toolStripStatusLabel_filename.Name = "toolStripStatusLabel_filename";
            this.toolStripStatusLabel_filename.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel_resolution
            // 
            this.toolStripStatusLabel_resolution.Name = "toolStripStatusLabel_resolution";
            this.toolStripStatusLabel_resolution.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel_oldprstyle
            // 
            this.toolStripStatusLabel_oldprstyle.Name = "toolStripStatusLabel_oldprstyle";
            this.toolStripStatusLabel_oldprstyle.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox_realtime
            // 
            this.groupBox_realtime.Controls.Add(this.label_counters);
            this.groupBox_realtime.Controls.Add(this.button_pause);
            this.groupBox_realtime.Controls.Add(this.button_pick_onecolordraw);
            this.groupBox_realtime.Controls.Add(this.label_ms);
            this.groupBox_realtime.Controls.Add(this.checkBox_onecolor);
            this.groupBox_realtime.Controls.Add(this.textBox_latency);
            this.groupBox_realtime.Controls.Add(this.trackBar1);
            this.groupBox_realtime.Controls.Add(this.label_latency);
            this.groupBox_realtime.Controls.Add(this.button_begindraw);
            this.groupBox_realtime.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_realtime.Location = new System.Drawing.Point(638, 170);
            this.groupBox_realtime.Name = "groupBox_realtime";
            this.groupBox_realtime.Size = new System.Drawing.Size(266, 141);
            this.groupBox_realtime.TabIndex = 36;
            this.groupBox_realtime.TabStop = false;
            this.groupBox_realtime.Text = "?????????????????? ?? ???????????????? ??????????????";
            // 
            // label1
            // 
            this.label_ms.AllowDrop = true;
            this.label_ms.Enabled = false;
            this.label_ms.Location = new System.Drawing.Point(135, 75);
            this.label_ms.Name = "label1";
            this.label_ms.Size = new System.Drawing.Size(31, 20);
            this.label_ms.TabIndex = 12;
            this.label_ms.Text = "????.";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.checkBox_randomcolor);
            this.groupBox_main.Controls.Add(this.pictureBox2);
            this.groupBox_main.Controls.Add(this.pictureBox1);
            this.groupBox_main.Controls.Add(this.button_pick2ndcolor);
            this.groupBox_main.Controls.Add(this.label_pathtofile);
            this.groupBox_main.Controls.Add(this.button_redraw);
            this.groupBox_main.Controls.Add(this.button_outter);
            this.groupBox_main.Controls.Add(this.button_pickcolor);
            this.groupBox_main.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_main.Location = new System.Drawing.Point(638, 3);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(266, 161);
            this.groupBox_main.TabIndex = 37;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "??????????????????";
            // 
            // checkBox1
            // 
            this.checkBox_randomcolor.AutoSize = true;
            this.checkBox_randomcolor.Enabled = false;
            this.checkBox_randomcolor.Location = new System.Drawing.Point(6, 134);
            this.checkBox_randomcolor.Name = "checkBox1";
            this.checkBox_randomcolor.Size = new System.Drawing.Size(186, 21);
            this.checkBox_randomcolor.TabIndex = 21;
            this.checkBox_randomcolor.Text = "?????????????????? ???????? ??????????";
            this.checkBox_randomcolor.UseVisualStyleBackColor = true;
            this.checkBox_randomcolor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(204, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(204, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // Form_ViewVect
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(912, 672);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.groupBox_main);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.groupBox_realtime);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox_contours);
            this.Controls.Add(this.loadingCircle1);
            this.Controls.Add(this.pictureBox_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_ViewVect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View vector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_viewvect_FormClosing);
            this.Load += new System.EventHandler(this.Form_viewvect_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            this.groupBox_contours.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox_realtime.ResumeLayout(false);
            this.groupBox_realtime.PerformLayout();
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button button_exit;
        public System.Windows.Forms.Button button_load;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Button button_pick2ndcolor;
        public System.Windows.Forms.Button button_pickcolor;
        public System.Windows.Forms.Button button_outter;
        public System.Windows.Forms.Button button_redraw;
        public System.Windows.Forms.Label label_pathtofile;
        public System.Windows.Forms.CheckBox checkBox_onecolor;
        public System.Windows.Forms.Button button_pick_onecolordraw;
        public System.Windows.Forms.TextBox textBox_latency;
        public System.Windows.Forms.Label label_latency;
        public System.Windows.Forms.Button button_pause;
        public System.Windows.Forms.Label label_counters;
        public System.Windows.Forms.Button button_begindraw;
        public System.Windows.Forms.TrackBar trackBar1;
        public System.Windows.Forms.PictureBox pictureBox_main;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public MRG.Controls.UI.LoadingCircle loadingCircle1;
        public System.Windows.Forms.Label label_status;
        public System.Windows.Forms.Button button_print;
        public System.Windows.Forms.GroupBox groupBox_contours;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_filename;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_resolution;
        public System.Windows.Forms.GroupBox groupBox_realtime;
        public System.Windows.Forms.GroupBox groupBox_main;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.ColorDialog colorDialog2;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.CheckBox checkBox_randomcolor;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_oldprstyle;
        public System.Windows.Forms.Label label_ms;
    }
}
