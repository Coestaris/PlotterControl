/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:


	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.


	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* PlotterControl \ Form_VectorMaster.Designer.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 01.07.2017 13:09:58
*
*=================================*/

namespace CnC_WFA
{
    partial class Form_VectorMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VectorMaster));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_back_img = new System.Windows.Forms.Button();
            this.scroll_down = new System.Windows.Forms.PictureBox();
            this.scroll_up = new System.Windows.Forms.PictureBox();
            this.scroll_left = new System.Windows.Forms.PictureBox();
            this.scroll_right = new System.Windows.Forms.PictureBox();
            this.label_size = new System.Windows.Forms.Label();
            this.label_resolution = new System.Windows.Forms.Label();
            this.groupBox_rotate = new System.Windows.Forms.GroupBox();
            this.radioButton_270deg = new System.Windows.Forms.RadioButton();
            this.radioButton_90deg = new System.Windows.Forms.RadioButton();
            this.radioButton_180deg = new System.Windows.Forms.RadioButton();
            this.radioButton_0deg = new System.Windows.Forms.RadioButton();
            this.groupBox_flip = new System.Windows.Forms.GroupBox();
            this.checkBox_useflip = new System.Windows.Forms.CheckBox();
            this.radioButton_flipy = new System.Windows.Forms.RadioButton();
            this.radioButton_flipx = new System.Windows.Forms.RadioButton();
            this.pictureBox_tab1 = new System.Windows.Forms.PictureBox();
            this.label_path = new System.Windows.Forms.Label();
            this.button_next = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox_grayform = new System.Windows.Forms.GroupBox();
            this.label_colormod = new System.Windows.Forms.Label();
            this.comboBox_grayform = new System.Windows.Forms.ComboBox();
            this.groupBox_colormod = new System.Windows.Forms.GroupBox();
            this.trackBar_hardbwthreshold = new System.Windows.Forms.TrackBar();
            this.label_harbw = new System.Windows.Forms.Label();
            this.button_update_tab2 = new System.Windows.Forms.Button();
            this.radioButton_hardbw = new System.Windows.Forms.RadioButton();
            this.loadingCircle_tab2 = new MRG.Controls.UI.LoadingCircle();
            this.radioButton_grayform = new System.Windows.Forms.RadioButton();
            this.button_next_tab2 = new System.Windows.Forms.Button();
            this.pictureBox_tab2 = new System.Windows.Forms.PictureBox();
            this.button_back_tab2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button_update_tab3 = new System.Windows.Forms.Button();
            this.loadingCircle_tab3 = new MRG.Controls.UI.LoadingCircle();
            this.groupBox_gauss = new System.Windows.Forms.GroupBox();
            this.label_gauss_scale = new System.Windows.Forms.Label();
            this.label_gauss_sigma = new System.Windows.Forms.Label();
            this.trackBar_gauss_scale = new System.Windows.Forms.TrackBar();
            this.trackBar_gauss_sigma = new System.Windows.Forms.TrackBar();
            this.groupBox_sobel = new System.Windows.Forms.GroupBox();
            this.label_sobel = new System.Windows.Forms.Label();
            this.trackBar_sobelthreshold = new System.Windows.Forms.TrackBar();
            this.button_next_tab3 = new System.Windows.Forms.Button();
            this.button_back_tab3 = new System.Windows.Forms.Button();
            this.pictureBox_tab3 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button_back_pr = new System.Windows.Forms.Button();
            this.label_imgname = new System.Windows.Forms.Label();
            this.label_resolution_ = new System.Windows.Forms.Label();
            this.label_strcount = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_tab4 = new System.Windows.Forms.PictureBox();
            this.button_pr = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label_img_dpi = new System.Windows.Forms.Label();
            this.label_img_pixelformat = new System.Windows.Forms.Label();
            this.label_img_resol = new System.Windows.Forms.Label();
            this.label_img_size = new System.Windows.Forms.Label();
            this.label_img_name = new System.Windows.Forms.Label();
            this.button_exit_tab0 = new System.Windows.Forms.Button();
            this.button_openfolder = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox_tab0 = new System.Windows.Forms.PictureBox();
            this.button_next_tab0 = new System.Windows.Forms.Button();
            this.button_loadimage = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.loadingCircle_tab4 = new MRG.Controls.UI.LoadingCircle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_savepr = new System.Windows.Forms.Button();
            this.groupBox_prinfo = new System.Windows.Forms.GroupBox();
            this.label_percentage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_timespend = new System.Windows.Forms.Label();
            this.button_back_tab4 = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.button_show = new System.Windows.Forms.Button();
            this.button_next_tab4 = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_next1 = new System.Windows.Forms.Button();
            this.label_instr = new System.Windows.Forms.Label();
            this.label_titlle1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_peview = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_help = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label_1 = new System.Windows.Forms.Label();
            this.label_2 = new System.Windows.Forms.Label();
            this.label_3 = new System.Windows.Forms.Label();
            this.label_4 = new System.Windows.Forms.Label();
            this.label_5 = new System.Windows.Forms.Label();
            this.label_6 = new System.Windows.Forms.Label();
            this.label_7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_right)).BeginInit();
            this.groupBox_rotate.SuspendLayout();
            this.groupBox_flip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox_grayform.SuspendLayout();
            this.groupBox_colormod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_hardbwthreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox_gauss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_gauss_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_gauss_sigma)).BeginInit();
            this.groupBox_sobel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_sobelthreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab4)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab0)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_prinfo.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(161, -19);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 468);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage1.Controls.Add(this.button_back_img);
            this.tabPage1.Controls.Add(this.scroll_down);
            this.tabPage1.Controls.Add(this.scroll_up);
            this.tabPage1.Controls.Add(this.scroll_left);
            this.tabPage1.Controls.Add(this.scroll_right);
            this.tabPage1.Controls.Add(this.label_size);
            this.tabPage1.Controls.Add(this.label_resolution);
            this.tabPage1.Controls.Add(this.groupBox_rotate);
            this.tabPage1.Controls.Add(this.groupBox_flip);
            this.tabPage1.Controls.Add(this.pictureBox_tab1);
            this.tabPage1.Controls.Add(this.label_path);
            this.tabPage1.Controls.Add(this.button_next);
            this.tabPage1.Font = new System.Drawing.Font("Cambria", 12F);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(528, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabPage1_MouseUp);
            // 
            // button_back_img
            // 
            this.button_back_img.BackColor = System.Drawing.Color.White;
            this.button_back_img.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_back_img.FlatAppearance.BorderSize = 2;
            this.button_back_img.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back_img.Location = new System.Drawing.Point(355, 401);
            this.button_back_img.Name = "button_back_img";
            this.button_back_img.Size = new System.Drawing.Size(78, 31);
            this.button_back_img.TabIndex = 21;
            this.button_back_img.Text = "Назад";
            this.button_back_img.UseVisualStyleBackColor = false;
            this.button_back_img.Click += new System.EventHandler(this.button2_Click);
            // 
            // scroll_down
            // 
            this.scroll_down.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.scroll_down.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.scroll_down.Location = new System.Drawing.Point(420, 49);
            this.scroll_down.Name = "scroll_down";
            this.scroll_down.Size = new System.Drawing.Size(50, 10);
            this.scroll_down.TabIndex = 20;
            this.scroll_down.TabStop = false;
            this.scroll_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scroll_down_MouseDown);
            this.scroll_down.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_down_MouseMove);
            this.scroll_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_down_MouseUp);
            // 
            // scroll_up
            // 
            this.scroll_up.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.scroll_up.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.scroll_up.InitialImage = null;
            this.scroll_up.Location = new System.Drawing.Point(420, 33);
            this.scroll_up.Name = "scroll_up";
            this.scroll_up.Size = new System.Drawing.Size(50, 10);
            this.scroll_up.TabIndex = 19;
            this.scroll_up.TabStop = false;
            this.scroll_up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scroll_up_MouseDown);
            this.scroll_up.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_up_MouseMove);
            this.scroll_up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_up_MouseUp);
            // 
            // scroll_left
            // 
            this.scroll_left.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.scroll_left.Cursor = System.Windows.Forms.Cursors.Default;
            this.scroll_left.Location = new System.Drawing.Point(460, 65);
            this.scroll_left.Name = "scroll_left";
            this.scroll_left.Size = new System.Drawing.Size(10, 50);
            this.scroll_left.TabIndex = 18;
            this.scroll_left.TabStop = false;
            this.scroll_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scroll_left_MouseDown);
            this.scroll_left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_left_MouseMove);
            this.scroll_left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_left_MouseUp);
            // 
            // scroll_right
            // 
            this.scroll_right.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.scroll_right.Cursor = System.Windows.Forms.Cursors.Default;
            this.scroll_right.Location = new System.Drawing.Point(444, 65);
            this.scroll_right.Name = "scroll_right";
            this.scroll_right.Size = new System.Drawing.Size(10, 50);
            this.scroll_right.TabIndex = 17;
            this.scroll_right.TabStop = false;
            this.scroll_right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scroll_right_MouseDown);
            this.scroll_right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_right_MouseMove);
            this.scroll_right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_right_MouseUp);
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Location = new System.Drawing.Point(269, 354);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(116, 19);
            this.label_size.TabIndex = 15;
            this.label_size.Text = "Размер: not set";
            // 
            // label_resolution
            // 
            this.label_resolution.AutoSize = true;
            this.label_resolution.Location = new System.Drawing.Point(269, 332);
            this.label_resolution.Name = "label_resolution";
            this.label_resolution.Size = new System.Drawing.Size(152, 19);
            this.label_resolution.TabIndex = 14;
            this.label_resolution.Text = "Разрешение: not set";
            // 
            // groupBox_rotate
            // 
            this.groupBox_rotate.Controls.Add(this.radioButton_270deg);
            this.groupBox_rotate.Controls.Add(this.radioButton_90deg);
            this.groupBox_rotate.Controls.Add(this.radioButton_180deg);
            this.groupBox_rotate.Controls.Add(this.radioButton_0deg);
            this.groupBox_rotate.Enabled = false;
            this.groupBox_rotate.Location = new System.Drawing.Point(6, 304);
            this.groupBox_rotate.Name = "groupBox_rotate";
            this.groupBox_rotate.Size = new System.Drawing.Size(107, 122);
            this.groupBox_rotate.TabIndex = 12;
            this.groupBox_rotate.TabStop = false;
            this.groupBox_rotate.Text = "Поворот";
            // 
            // radioButton_270deg
            // 
            this.radioButton_270deg.AutoSize = true;
            this.radioButton_270deg.Location = new System.Drawing.Point(12, 97);
            this.radioButton_270deg.Name = "radioButton_270deg";
            this.radioButton_270deg.Size = new System.Drawing.Size(54, 23);
            this.radioButton_270deg.TabIndex = 10;
            this.radioButton_270deg.TabStop = true;
            this.radioButton_270deg.Text = "270";
            this.radioButton_270deg.UseVisualStyleBackColor = true;
            this.radioButton_270deg.CheckedChanged += new System.EventHandler(this.radioButton_270deg_CheckedChanged);
            // 
            // radioButton_90deg
            // 
            this.radioButton_90deg.AutoSize = true;
            this.radioButton_90deg.Location = new System.Drawing.Point(12, 45);
            this.radioButton_90deg.Name = "radioButton_90deg";
            this.radioButton_90deg.Size = new System.Drawing.Size(45, 23);
            this.radioButton_90deg.TabIndex = 9;
            this.radioButton_90deg.TabStop = true;
            this.radioButton_90deg.Text = "90";
            this.radioButton_90deg.UseVisualStyleBackColor = true;
            this.radioButton_90deg.CheckedChanged += new System.EventHandler(this.radioButton_90deg_CheckedChanged);
            // 
            // radioButton_180deg
            // 
            this.radioButton_180deg.AutoSize = true;
            this.radioButton_180deg.Location = new System.Drawing.Point(12, 71);
            this.radioButton_180deg.Name = "radioButton_180deg";
            this.radioButton_180deg.Size = new System.Drawing.Size(54, 23);
            this.radioButton_180deg.TabIndex = 8;
            this.radioButton_180deg.TabStop = true;
            this.radioButton_180deg.Text = "180";
            this.radioButton_180deg.UseVisualStyleBackColor = true;
            this.radioButton_180deg.CheckedChanged += new System.EventHandler(this.radioButton_180deg_CheckedChanged);
            // 
            // radioButton_0deg
            // 
            this.radioButton_0deg.AutoSize = true;
            this.radioButton_0deg.Location = new System.Drawing.Point(12, 19);
            this.radioButton_0deg.Name = "radioButton_0deg";
            this.radioButton_0deg.Size = new System.Drawing.Size(36, 23);
            this.radioButton_0deg.TabIndex = 7;
            this.radioButton_0deg.TabStop = true;
            this.radioButton_0deg.Text = "0";
            this.radioButton_0deg.UseVisualStyleBackColor = true;
            this.radioButton_0deg.CheckedChanged += new System.EventHandler(this.radioButton_0deg_CheckedChanged);
            // 
            // groupBox_flip
            // 
            this.groupBox_flip.Controls.Add(this.checkBox_useflip);
            this.groupBox_flip.Controls.Add(this.radioButton_flipy);
            this.groupBox_flip.Controls.Add(this.radioButton_flipx);
            this.groupBox_flip.Enabled = false;
            this.groupBox_flip.Location = new System.Drawing.Point(119, 302);
            this.groupBox_flip.Name = "groupBox_flip";
            this.groupBox_flip.Size = new System.Drawing.Size(144, 124);
            this.groupBox_flip.TabIndex = 11;
            this.groupBox_flip.TabStop = false;
            this.groupBox_flip.Text = "Отражение";
            // 
            // checkBox_useflip
            // 
            this.checkBox_useflip.AutoSize = true;
            this.checkBox_useflip.Location = new System.Drawing.Point(9, 26);
            this.checkBox_useflip.Name = "checkBox_useflip";
            this.checkBox_useflip.Size = new System.Drawing.Size(129, 23);
            this.checkBox_useflip.TabIndex = 7;
            this.checkBox_useflip.Text = "Использовать\r\n";
            this.checkBox_useflip.UseVisualStyleBackColor = true;
            this.checkBox_useflip.CheckedChanged += new System.EventHandler(this.checkBox_useflip_CheckedChanged);
            // 
            // radioButton_flipy
            // 
            this.radioButton_flipy.AutoSize = true;
            this.radioButton_flipy.Enabled = false;
            this.radioButton_flipy.Location = new System.Drawing.Point(12, 99);
            this.radioButton_flipy.Name = "radioButton_flipy";
            this.radioButton_flipy.Size = new System.Drawing.Size(89, 23);
            this.radioButton_flipy.TabIndex = 6;
            this.radioButton_flipy.TabStop = true;
            this.radioButton_flipy.Text = "По оси Y";
            this.radioButton_flipy.UseVisualStyleBackColor = true;
            this.radioButton_flipy.CheckedChanged += new System.EventHandler(this.radioButton_flipy_CheckedChanged);
            // 
            // radioButton_flipx
            // 
            this.radioButton_flipx.AutoSize = true;
            this.radioButton_flipx.Enabled = false;
            this.radioButton_flipx.Location = new System.Drawing.Point(12, 70);
            this.radioButton_flipx.Name = "radioButton_flipx";
            this.radioButton_flipx.Size = new System.Drawing.Size(89, 23);
            this.radioButton_flipx.TabIndex = 5;
            this.radioButton_flipx.TabStop = true;
            this.radioButton_flipx.Text = "По оси Х";
            this.radioButton_flipx.UseVisualStyleBackColor = true;
            this.radioButton_flipx.CheckedChanged += new System.EventHandler(this.radioButton_flipx_CheckedChanged);
            // 
            // pictureBox_tab1
            // 
            this.pictureBox_tab1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_tab1.Location = new System.Drawing.Point(0, 9);
            this.pictureBox_tab1.Name = "pictureBox_tab1";
            this.pictureBox_tab1.Size = new System.Drawing.Size(511, 290);
            this.pictureBox_tab1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tab1.TabIndex = 4;
            this.pictureBox_tab1.TabStop = false;
            this.pictureBox_tab1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(269, 310);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(162, 19);
            this.label_path.TabIndex = 3;
            this.label_path.Text = "Изображение: not set";
            // 
            // button_next
            // 
            this.button_next.BackColor = System.Drawing.Color.White;
            this.button_next.Enabled = false;
            this.button_next.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_next.FlatAppearance.BorderSize = 2;
            this.button_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next.Location = new System.Drawing.Point(439, 401);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(78, 31);
            this.button_next.TabIndex = 1;
            this.button_next.Text = "Далее";
            this.button_next.UseVisualStyleBackColor = false;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage2.Controls.Add(this.groupBox_grayform);
            this.tabPage2.Controls.Add(this.groupBox_colormod);
            this.tabPage2.Controls.Add(this.button_update_tab2);
            this.tabPage2.Controls.Add(this.radioButton_hardbw);
            this.tabPage2.Controls.Add(this.loadingCircle_tab2);
            this.tabPage2.Controls.Add(this.radioButton_grayform);
            this.tabPage2.Controls.Add(this.button_next_tab2);
            this.tabPage2.Controls.Add(this.pictureBox_tab2);
            this.tabPage2.Controls.Add(this.button_back_tab2);
            this.tabPage2.Font = new System.Drawing.Font("Cambria", 12F);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(528, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "v";
            // 
            // groupBox_grayform
            // 
            this.groupBox_grayform.Controls.Add(this.label_colormod);
            this.groupBox_grayform.Controls.Add(this.comboBox_grayform);
            this.groupBox_grayform.Location = new System.Drawing.Point(6, 305);
            this.groupBox_grayform.Name = "groupBox_grayform";
            this.groupBox_grayform.Size = new System.Drawing.Size(216, 70);
            this.groupBox_grayform.TabIndex = 34;
            this.groupBox_grayform.TabStop = false;
            this.groupBox_grayform.Text = "Оттенки серого";
            // 
            // label_colormod
            // 
            this.label_colormod.AutoSize = true;
            this.label_colormod.Location = new System.Drawing.Point(6, 25);
            this.label_colormod.Name = "label_colormod";
            this.label_colormod.Size = new System.Drawing.Size(108, 19);
            this.label_colormod.TabIndex = 15;
            this.label_colormod.Text = "Цвет. модель:";
            // 
            // comboBox_grayform
            // 
            this.comboBox_grayform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_grayform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_grayform.FormattingEnabled = true;
            this.comboBox_grayform.Items.AddRange(new object[] {
            "1nd color model",
            "2nd color model",
            "Hard gray format"});
            this.comboBox_grayform.Location = new System.Drawing.Point(120, 22);
            this.comboBox_grayform.Name = "comboBox_grayform";
            this.comboBox_grayform.Size = new System.Drawing.Size(90, 27);
            this.comboBox_grayform.TabIndex = 14;
            this.comboBox_grayform.SelectedIndexChanged += new System.EventHandler(this.comboBox_grayform_SelectedIndexChanged);
            // 
            // groupBox_colormod
            // 
            this.groupBox_colormod.Controls.Add(this.trackBar_hardbwthreshold);
            this.groupBox_colormod.Controls.Add(this.label_harbw);
            this.groupBox_colormod.Location = new System.Drawing.Point(227, 305);
            this.groupBox_colormod.Name = "groupBox_colormod";
            this.groupBox_colormod.Size = new System.Drawing.Size(290, 90);
            this.groupBox_colormod.TabIndex = 33;
            this.groupBox_colormod.TabStop = false;
            this.groupBox_colormod.Text = "2х цветный формат";
            // 
            // trackBar_hardbwthreshold
            // 
            this.trackBar_hardbwthreshold.Enabled = false;
            this.trackBar_hardbwthreshold.Location = new System.Drawing.Point(6, 25);
            this.trackBar_hardbwthreshold.Maximum = 255;
            this.trackBar_hardbwthreshold.Name = "trackBar_hardbwthreshold";
            this.trackBar_hardbwthreshold.Size = new System.Drawing.Size(278, 45);
            this.trackBar_hardbwthreshold.TabIndex = 13;
            this.trackBar_hardbwthreshold.TickFrequency = 8;
            this.trackBar_hardbwthreshold.Value = 128;
            this.trackBar_hardbwthreshold.Scroll += new System.EventHandler(this.trackBar_hardbwthreshold_Scroll);
            // 
            // label_harbw
            // 
            this.label_harbw.AutoSize = true;
            this.label_harbw.Enabled = false;
            this.label_harbw.Location = new System.Drawing.Point(6, 68);
            this.label_harbw.Name = "label_harbw";
            this.label_harbw.Size = new System.Drawing.Size(89, 19);
            this.label_harbw.TabIndex = 15;
            this.label_harbw.Text = "Порог: 128";
            // 
            // button_update_tab2
            // 
            this.button_update_tab2.BackColor = System.Drawing.Color.White;
            this.button_update_tab2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_update_tab2.FlatAppearance.BorderSize = 2;
            this.button_update_tab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_update_tab2.Location = new System.Drawing.Point(254, 401);
            this.button_update_tab2.Name = "button_update_tab2";
            this.button_update_tab2.Size = new System.Drawing.Size(95, 31);
            this.button_update_tab2.TabIndex = 32;
            this.button_update_tab2.Text = "Обновить";
            this.button_update_tab2.UseVisualStyleBackColor = false;
            this.button_update_tab2.Click += new System.EventHandler(this.button_update_tab2_Click);
            // 
            // radioButton_hardbw
            // 
            this.radioButton_hardbw.AutoSize = true;
            this.radioButton_hardbw.Location = new System.Drawing.Point(12, 381);
            this.radioButton_hardbw.Name = "radioButton_hardbw";
            this.radioButton_hardbw.Size = new System.Drawing.Size(171, 23);
            this.radioButton_hardbw.TabIndex = 12;
            this.radioButton_hardbw.TabStop = true;
            this.radioButton_hardbw.Text = "2х цветный формат";
            this.radioButton_hardbw.UseVisualStyleBackColor = true;
            this.radioButton_hardbw.CheckedChanged += new System.EventHandler(this.radioButton_hardbw_CheckedChanged);
            // 
            // loadingCircle_tab2
            // 
            this.loadingCircle_tab2.Active = false;
            this.loadingCircle_tab2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle_tab2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle_tab2.BackgroundImage")));
            this.loadingCircle_tab2.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle_tab2.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle_tab2.InnerCircleRadius = 5;
            this.loadingCircle_tab2.Location = new System.Drawing.Point(227, 107);
            this.loadingCircle_tab2.Name = "loadingCircle_tab2";
            this.loadingCircle_tab2.NumberSpoke = 12;
            this.loadingCircle_tab2.OuterCircleRadius = 11;
            this.loadingCircle_tab2.RotationSpeed = 100;
            this.loadingCircle_tab2.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle_tab2.SpokeThickness = 2;
            this.loadingCircle_tab2.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle_tab2.TabIndex = 29;
            this.loadingCircle_tab2.Text = "loadingCircle2";
            this.loadingCircle_tab2.UseWaitCursor = true;
            this.loadingCircle_tab2.Visible = false;
            // 
            // radioButton_grayform
            // 
            this.radioButton_grayform.AutoSize = true;
            this.radioButton_grayform.Location = new System.Drawing.Point(12, 406);
            this.radioButton_grayform.Name = "radioButton_grayform";
            this.radioButton_grayform.Size = new System.Drawing.Size(141, 23);
            this.radioButton_grayform.TabIndex = 11;
            this.radioButton_grayform.TabStop = true;
            this.radioButton_grayform.Text = "Оттенки серого";
            this.radioButton_grayform.UseVisualStyleBackColor = true;
            this.radioButton_grayform.CheckedChanged += new System.EventHandler(this.radioButton_grayform_CheckedChanged_1);
            // 
            // button_next_tab2
            // 
            this.button_next_tab2.BackColor = System.Drawing.Color.White;
            this.button_next_tab2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_next_tab2.FlatAppearance.BorderSize = 2;
            this.button_next_tab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next_tab2.Location = new System.Drawing.Point(439, 401);
            this.button_next_tab2.Name = "button_next_tab2";
            this.button_next_tab2.Size = new System.Drawing.Size(78, 31);
            this.button_next_tab2.TabIndex = 23;
            this.button_next_tab2.Text = "Далее";
            this.button_next_tab2.UseVisualStyleBackColor = false;
            this.button_next_tab2.Click += new System.EventHandler(this.button_next_tab2_Click);
            // 
            // pictureBox_tab2
            // 
            this.pictureBox_tab2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_tab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_tab2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox_tab2.Name = "pictureBox_tab2";
            this.pictureBox_tab2.Size = new System.Drawing.Size(511, 290);
            this.pictureBox_tab2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tab2.TabIndex = 22;
            this.pictureBox_tab2.TabStop = false;
            // 
            // button_back_tab2
            // 
            this.button_back_tab2.BackColor = System.Drawing.Color.White;
            this.button_back_tab2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_back_tab2.FlatAppearance.BorderSize = 2;
            this.button_back_tab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back_tab2.Location = new System.Drawing.Point(355, 401);
            this.button_back_tab2.Name = "button_back_tab2";
            this.button_back_tab2.Size = new System.Drawing.Size(78, 31);
            this.button_back_tab2.TabIndex = 3;
            this.button_back_tab2.Text = "Назад";
            this.button_back_tab2.UseVisualStyleBackColor = false;
            this.button_back_tab2.Click += new System.EventHandler(this.button_back_tab2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage3.Controls.Add(this.button_update_tab3);
            this.tabPage3.Controls.Add(this.loadingCircle_tab3);
            this.tabPage3.Controls.Add(this.groupBox_gauss);
            this.tabPage3.Controls.Add(this.groupBox_sobel);
            this.tabPage3.Controls.Add(this.button_next_tab3);
            this.tabPage3.Controls.Add(this.button_back_tab3);
            this.tabPage3.Controls.Add(this.pictureBox_tab3);
            this.tabPage3.Font = new System.Drawing.Font("Cambria", 12F);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(528, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // button_update_tab3
            // 
            this.button_update_tab3.BackColor = System.Drawing.Color.White;
            this.button_update_tab3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_update_tab3.FlatAppearance.BorderSize = 2;
            this.button_update_tab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_update_tab3.Location = new System.Drawing.Point(254, 401);
            this.button_update_tab3.Name = "button_update_tab3";
            this.button_update_tab3.Size = new System.Drawing.Size(95, 31);
            this.button_update_tab3.TabIndex = 31;
            this.button_update_tab3.Text = "Обновить";
            this.button_update_tab3.UseVisualStyleBackColor = false;
            this.button_update_tab3.Click += new System.EventHandler(this.button_update_tab3_Click);
            // 
            // loadingCircle_tab3
            // 
            this.loadingCircle_tab3.Active = false;
            this.loadingCircle_tab3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle_tab3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle_tab3.BackgroundImage")));
            this.loadingCircle_tab3.Color = System.Drawing.SystemColors.Highlight;
            this.loadingCircle_tab3.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle_tab3.InnerCircleRadius = 5;
            this.loadingCircle_tab3.Location = new System.Drawing.Point(238, 102);
            this.loadingCircle_tab3.Name = "loadingCircle_tab3";
            this.loadingCircle_tab3.NumberSpoke = 12;
            this.loadingCircle_tab3.OuterCircleRadius = 11;
            this.loadingCircle_tab3.RotationSpeed = 100;
            this.loadingCircle_tab3.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle_tab3.SpokeThickness = 2;
            this.loadingCircle_tab3.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle_tab3.TabIndex = 28;
            this.loadingCircle_tab3.Text = "loadingCircle1";
            this.loadingCircle_tab3.UseWaitCursor = true;
            // 
            // groupBox_gauss
            // 
            this.groupBox_gauss.Controls.Add(this.label_gauss_scale);
            this.groupBox_gauss.Controls.Add(this.label_gauss_sigma);
            this.groupBox_gauss.Controls.Add(this.trackBar_gauss_scale);
            this.groupBox_gauss.Controls.Add(this.trackBar_gauss_sigma);
            this.groupBox_gauss.Location = new System.Drawing.Point(3, 302);
            this.groupBox_gauss.Name = "groupBox_gauss";
            this.groupBox_gauss.Size = new System.Drawing.Size(298, 93);
            this.groupBox_gauss.TabIndex = 26;
            this.groupBox_gauss.TabStop = false;
            this.groupBox_gauss.Text = "Размытие по Гауссу";
            // 
            // label_gauss_scale
            // 
            this.label_gauss_scale.AutoSize = true;
            this.label_gauss_scale.Location = new System.Drawing.Point(192, 71);
            this.label_gauss_scale.Name = "label_gauss_scale";
            this.label_gauss_scale.Size = new System.Drawing.Size(65, 19);
            this.label_gauss_scale.TabIndex = 3;
            this.label_gauss_scale.Text = "Scale:  7";
            // 
            // label_gauss_sigma
            // 
            this.label_gauss_sigma.AutoSize = true;
            this.label_gauss_sigma.Location = new System.Drawing.Point(6, 71);
            this.label_gauss_sigma.Name = "label_gauss_sigma";
            this.label_gauss_sigma.Size = new System.Drawing.Size(82, 19);
            this.label_gauss_sigma.TabIndex = 2;
            this.label_gauss_sigma.Text = "Сигма: 1.2";
            // 
            // trackBar_gauss_scale
            // 
            this.trackBar_gauss_scale.CausesValidation = false;
            this.trackBar_gauss_scale.Location = new System.Drawing.Point(196, 25);
            this.trackBar_gauss_scale.Maximum = 20;
            this.trackBar_gauss_scale.Name = "trackBar_gauss_scale";
            this.trackBar_gauss_scale.Size = new System.Drawing.Size(96, 45);
            this.trackBar_gauss_scale.TabIndex = 1;
            this.trackBar_gauss_scale.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_gauss_scale.Value = 7;
            this.trackBar_gauss_scale.Scroll += new System.EventHandler(this.trackBar_gauss_scale_Scroll);
            // 
            // trackBar_gauss_sigma
            // 
            this.trackBar_gauss_sigma.Location = new System.Drawing.Point(6, 25);
            this.trackBar_gauss_sigma.Maximum = 100;
            this.trackBar_gauss_sigma.Name = "trackBar_gauss_sigma";
            this.trackBar_gauss_sigma.Size = new System.Drawing.Size(184, 45);
            this.trackBar_gauss_sigma.TabIndex = 0;
            this.trackBar_gauss_sigma.TickFrequency = 5;
            this.trackBar_gauss_sigma.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_gauss_sigma.Value = 12;
            this.trackBar_gauss_sigma.Scroll += new System.EventHandler(this.trackBar_gauss_sigma_Scroll);
            // 
            // groupBox_sobel
            // 
            this.groupBox_sobel.Controls.Add(this.label_sobel);
            this.groupBox_sobel.Controls.Add(this.trackBar_sobelthreshold);
            this.groupBox_sobel.Location = new System.Drawing.Point(307, 302);
            this.groupBox_sobel.Name = "groupBox_sobel";
            this.groupBox_sobel.Size = new System.Drawing.Size(210, 93);
            this.groupBox_sobel.TabIndex = 27;
            this.groupBox_sobel.TabStop = false;
            this.groupBox_sobel.Text = "Оператор Собеля";
            // 
            // label_sobel
            // 
            this.label_sobel.AutoSize = true;
            this.label_sobel.Location = new System.Drawing.Point(11, 71);
            this.label_sobel.Name = "label_sobel";
            this.label_sobel.Size = new System.Drawing.Size(89, 19);
            this.label_sobel.TabIndex = 4;
            this.label_sobel.Text = "Порог: 125";
            // 
            // trackBar_sobelthreshold
            // 
            this.trackBar_sobelthreshold.CausesValidation = false;
            this.trackBar_sobelthreshold.Location = new System.Drawing.Point(6, 25);
            this.trackBar_sobelthreshold.Maximum = 256;
            this.trackBar_sobelthreshold.Name = "trackBar_sobelthreshold";
            this.trackBar_sobelthreshold.Size = new System.Drawing.Size(201, 45);
            this.trackBar_sobelthreshold.TabIndex = 2;
            this.trackBar_sobelthreshold.TickFrequency = 4;
            this.trackBar_sobelthreshold.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_sobelthreshold.Value = 125;
            this.trackBar_sobelthreshold.Scroll += new System.EventHandler(this.trackBar_sobelthreshold_Scroll);
            // 
            // button_next_tab3
            // 
            this.button_next_tab3.BackColor = System.Drawing.Color.White;
            this.button_next_tab3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_next_tab3.FlatAppearance.BorderSize = 2;
            this.button_next_tab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next_tab3.Location = new System.Drawing.Point(439, 401);
            this.button_next_tab3.Name = "button_next_tab3";
            this.button_next_tab3.Size = new System.Drawing.Size(78, 31);
            this.button_next_tab3.TabIndex = 25;
            this.button_next_tab3.Text = "Далее";
            this.button_next_tab3.UseVisualStyleBackColor = false;
            this.button_next_tab3.Click += new System.EventHandler(this.button_next_tab3_Click);
            // 
            // button_back_tab3
            // 
            this.button_back_tab3.BackColor = System.Drawing.Color.White;
            this.button_back_tab3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_back_tab3.FlatAppearance.BorderSize = 2;
            this.button_back_tab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back_tab3.Location = new System.Drawing.Point(355, 401);
            this.button_back_tab3.Name = "button_back_tab3";
            this.button_back_tab3.Size = new System.Drawing.Size(78, 31);
            this.button_back_tab3.TabIndex = 24;
            this.button_back_tab3.Text = "Назад";
            this.button_back_tab3.UseVisualStyleBackColor = false;
            this.button_back_tab3.Click += new System.EventHandler(this.button_back_tab3_Click);
            // 
            // pictureBox_tab3
            // 
            this.pictureBox_tab3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_tab3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_tab3.Location = new System.Drawing.Point(6, 6);
            this.pictureBox_tab3.Name = "pictureBox_tab3";
            this.pictureBox_tab3.Size = new System.Drawing.Size(511, 290);
            this.pictureBox_tab3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tab3.TabIndex = 23;
            this.pictureBox_tab3.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage4.Controls.Add(this.button_back_pr);
            this.tabPage4.Controls.Add(this.label_imgname);
            this.tabPage4.Controls.Add(this.label_resolution_);
            this.tabPage4.Controls.Add(this.label_strcount);
            this.tabPage4.Controls.Add(this.numericUpDown1);
            this.tabPage4.Controls.Add(this.pictureBox_tab4);
            this.tabPage4.Controls.Add(this.button_pr);
            this.tabPage4.Font = new System.Drawing.Font("Cambria", 12F);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(528, 439);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // button_back_pr
            // 
            this.button_back_pr.BackColor = System.Drawing.Color.White;
            this.button_back_pr.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_back_pr.FlatAppearance.BorderSize = 2;
            this.button_back_pr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back_pr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back_pr.Location = new System.Drawing.Point(282, 402);
            this.button_back_pr.Name = "button_back_pr";
            this.button_back_pr.Size = new System.Drawing.Size(78, 31);
            this.button_back_pr.TabIndex = 34;
            this.button_back_pr.Text = "Назад";
            this.button_back_pr.UseVisualStyleBackColor = false;
            this.button_back_pr.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label_imgname
            // 
            this.label_imgname.AutoSize = true;
            this.label_imgname.Location = new System.Drawing.Point(6, 364);
            this.label_imgname.Name = "label_imgname";
            this.label_imgname.Size = new System.Drawing.Size(48, 19);
            this.label_imgname.TabIndex = 32;
            this.label_imgname.Text = "Имя: ";
            // 
            // label_resolution_
            // 
            this.label_resolution_.AutoSize = true;
            this.label_resolution_.Location = new System.Drawing.Point(6, 383);
            this.label_resolution_.Name = "label_resolution_";
            this.label_resolution_.Size = new System.Drawing.Size(105, 19);
            this.label_resolution_.TabIndex = 33;
            this.label_resolution_.Text = "Разрешение: ";
            // 
            // label_strcount
            // 
            this.label_strcount.AutoSize = true;
            this.label_strcount.Location = new System.Drawing.Point(6, 408);
            this.label_strcount.Name = "label_strcount";
            this.label_strcount.Size = new System.Drawing.Size(128, 19);
            this.label_strcount.TabIndex = 36;
            this.label_strcount.Text = "Кол-во потоков:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(140, 407);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 26);
            this.numericUpDown1.TabIndex = 35;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox_tab4
            // 
            this.pictureBox_tab4.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_tab4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_tab4.Location = new System.Drawing.Point(6, 6);
            this.pictureBox_tab4.Name = "pictureBox_tab4";
            this.pictureBox_tab4.Size = new System.Drawing.Size(511, 355);
            this.pictureBox_tab4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tab4.TabIndex = 24;
            this.pictureBox_tab4.TabStop = false;
            // 
            // button_pr
            // 
            this.button_pr.BackColor = System.Drawing.Color.White;
            this.button_pr.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pr.FlatAppearance.BorderSize = 2;
            this.button_pr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pr.Location = new System.Drawing.Point(366, 383);
            this.button_pr.Name = "button_pr";
            this.button_pr.Size = new System.Drawing.Size(151, 50);
            this.button_pr.TabIndex = 31;
            this.button_pr.Text = "Векторизировать";
            this.button_pr.UseVisualStyleBackColor = false;
            this.button_pr.Click += new System.EventHandler(this.button_pr_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage5.Controls.Add(this.label_img_dpi);
            this.tabPage5.Controls.Add(this.label_img_pixelformat);
            this.tabPage5.Controls.Add(this.label_img_resol);
            this.tabPage5.Controls.Add(this.label_img_size);
            this.tabPage5.Controls.Add(this.label_img_name);
            this.tabPage5.Controls.Add(this.button_exit_tab0);
            this.tabPage5.Controls.Add(this.button_openfolder);
            this.tabPage5.Controls.Add(this.button_remove);
            this.tabPage5.Controls.Add(this.button_update);
            this.tabPage5.Controls.Add(this.listBox1);
            this.tabPage5.Controls.Add(this.pictureBox_tab0);
            this.tabPage5.Controls.Add(this.button_next_tab0);
            this.tabPage5.Controls.Add(this.button_loadimage);
            this.tabPage5.Font = new System.Drawing.Font("Cambria", 12F);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(528, 439);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            // 
            // label_img_dpi
            // 
            this.label_img_dpi.AutoSize = true;
            this.label_img_dpi.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_img_dpi.Location = new System.Drawing.Point(259, 303);
            this.label_img_dpi.Name = "label_img_dpi";
            this.label_img_dpi.Size = new System.Drawing.Size(0, 19);
            this.label_img_dpi.TabIndex = 33;
            // 
            // label_img_pixelformat
            // 
            this.label_img_pixelformat.AutoSize = true;
            this.label_img_pixelformat.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_img_pixelformat.Location = new System.Drawing.Point(259, 283);
            this.label_img_pixelformat.Name = "label_img_pixelformat";
            this.label_img_pixelformat.Size = new System.Drawing.Size(0, 19);
            this.label_img_pixelformat.TabIndex = 32;
            // 
            // label_img_resol
            // 
            this.label_img_resol.AutoSize = true;
            this.label_img_resol.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_img_resol.Location = new System.Drawing.Point(259, 263);
            this.label_img_resol.Name = "label_img_resol";
            this.label_img_resol.Size = new System.Drawing.Size(0, 19);
            this.label_img_resol.TabIndex = 31;
            // 
            // label_img_size
            // 
            this.label_img_size.AutoSize = true;
            this.label_img_size.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_img_size.Location = new System.Drawing.Point(259, 243);
            this.label_img_size.Name = "label_img_size";
            this.label_img_size.Size = new System.Drawing.Size(0, 19);
            this.label_img_size.TabIndex = 30;
            // 
            // label_img_name
            // 
            this.label_img_name.AutoSize = true;
            this.label_img_name.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_img_name.Location = new System.Drawing.Point(259, 223);
            this.label_img_name.Name = "label_img_name";
            this.label_img_name.Size = new System.Drawing.Size(0, 19);
            this.label_img_name.TabIndex = 29;
            // 
            // button_exit_tab0
            // 
            this.button_exit_tab0.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_exit_tab0.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_exit_tab0.FlatAppearance.BorderSize = 2;
            this.button_exit_tab0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit_tab0.Location = new System.Drawing.Point(355, 401);
            this.button_exit_tab0.Name = "button_exit_tab0";
            this.button_exit_tab0.Size = new System.Drawing.Size(78, 31);
            this.button_exit_tab0.TabIndex = 28;
            this.button_exit_tab0.Text = "Назад";
            this.button_exit_tab0.UseVisualStyleBackColor = false;
            this.button_exit_tab0.Click += new System.EventHandler(this.button_exit_tab0_Click);
            // 
            // button_openfolder
            // 
            this.button_openfolder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_openfolder.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_openfolder.FlatAppearance.BorderSize = 2;
            this.button_openfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_openfolder.Location = new System.Drawing.Point(102, 378);
            this.button_openfolder.Name = "button_openfolder";
            this.button_openfolder.Size = new System.Drawing.Size(86, 54);
            this.button_openfolder.TabIndex = 27;
            this.button_openfolder.Text = "Открыть папку";
            this.button_openfolder.UseVisualStyleBackColor = false;
            this.button_openfolder.Click += new System.EventHandler(this.button_openfolder_Click);
            // 
            // button_remove
            // 
            this.button_remove.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_remove.Enabled = false;
            this.button_remove.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_remove.FlatAppearance.BorderSize = 2;
            this.button_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove.Location = new System.Drawing.Point(194, 378);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(86, 54);
            this.button_remove.TabIndex = 26;
            this.button_remove.Text = "Удалить";
            this.button_remove.UseVisualStyleBackColor = false;
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_update.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_update.FlatAppearance.BorderSize = 2;
            this.button_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_update.Location = new System.Drawing.Point(412, 364);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(105, 31);
            this.button_update.TabIndex = 25;
            this.button_update.Text = "Обновить";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(7, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(246, 365);
            this.listBox1.TabIndex = 24;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox_tab0
            // 
            this.pictureBox_tab0.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_tab0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_tab0.Location = new System.Drawing.Point(260, 7);
            this.pictureBox_tab0.Name = "pictureBox_tab0";
            this.pictureBox_tab0.Size = new System.Drawing.Size(257, 192);
            this.pictureBox_tab0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tab0.TabIndex = 23;
            this.pictureBox_tab0.TabStop = false;
            // 
            // button_next_tab0
            // 
            this.button_next_tab0.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_next_tab0.Enabled = false;
            this.button_next_tab0.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_next_tab0.FlatAppearance.BorderSize = 2;
            this.button_next_tab0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next_tab0.Location = new System.Drawing.Point(439, 401);
            this.button_next_tab0.Name = "button_next_tab0";
            this.button_next_tab0.Size = new System.Drawing.Size(78, 31);
            this.button_next_tab0.TabIndex = 22;
            this.button_next_tab0.Text = "Далее";
            this.button_next_tab0.UseVisualStyleBackColor = false;
            this.button_next_tab0.Click += new System.EventHandler(this.button_next_tab0_Click);
            // 
            // button_loadimage
            // 
            this.button_loadimage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_loadimage.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_loadimage.FlatAppearance.BorderSize = 2;
            this.button_loadimage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_loadimage.Location = new System.Drawing.Point(7, 378);
            this.button_loadimage.Name = "button_loadimage";
            this.button_loadimage.Size = new System.Drawing.Size(89, 54);
            this.button_loadimage.TabIndex = 21;
            this.button_loadimage.Text = "Открыть";
            this.button_loadimage.UseVisualStyleBackColor = false;
            this.button_loadimage.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage6.Controls.Add(this.loadingCircle_tab4);
            this.tabPage6.Controls.Add(this.pictureBox1);
            this.tabPage6.Controls.Add(this.button_savepr);
            this.tabPage6.Controls.Add(this.groupBox_prinfo);
            this.tabPage6.Controls.Add(this.button_back_tab4);
            this.tabPage6.Controls.Add(this.button_print);
            this.tabPage6.Controls.Add(this.button_show);
            this.tabPage6.Controls.Add(this.button_next_tab4);
            this.tabPage6.Font = new System.Drawing.Font("Cambria", 12F);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(528, 439);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            // 
            // loadingCircle_tab4
            // 
            this.loadingCircle_tab4.Active = false;
            this.loadingCircle_tab4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle_tab4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle_tab4.BackgroundImage")));
            this.loadingCircle_tab4.Color = System.Drawing.SystemColors.Highlight;
            this.loadingCircle_tab4.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle_tab4.InnerCircleRadius = 5;
            this.loadingCircle_tab4.Location = new System.Drawing.Point(214, 100);
            this.loadingCircle_tab4.Name = "loadingCircle_tab4";
            this.loadingCircle_tab4.NumberSpoke = 12;
            this.loadingCircle_tab4.OuterCircleRadius = 11;
            this.loadingCircle_tab4.RotationSpeed = 100;
            this.loadingCircle_tab4.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle_tab4.SpokeThickness = 2;
            this.loadingCircle_tab4.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle_tab4.TabIndex = 29;
            this.loadingCircle_tab4.Text = "loadingCircle1";
            this.loadingCircle_tab4.UseWaitCursor = true;
            this.loadingCircle_tab4.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(511, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // button_savepr
            // 
            this.button_savepr.BackColor = System.Drawing.Color.White;
            this.button_savepr.Enabled = false;
            this.button_savepr.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_savepr.FlatAppearance.BorderSize = 2;
            this.button_savepr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_savepr.ForeColor = System.Drawing.Color.Black;
            this.button_savepr.Location = new System.Drawing.Point(413, 402);
            this.button_savepr.Name = "button_savepr";
            this.button_savepr.Size = new System.Drawing.Size(106, 31);
            this.button_savepr.TabIndex = 42;
            this.button_savepr.Text = "Сохранить";
            this.button_savepr.UseVisualStyleBackColor = false;
            this.button_savepr.Click += new System.EventHandler(this.button_savepr_Click_1);
            // 
            // groupBox_prinfo
            // 
            this.groupBox_prinfo.Controls.Add(this.label_percentage);
            this.groupBox_prinfo.Controls.Add(this.progressBar1);
            this.groupBox_prinfo.Controls.Add(this.label_timespend);
            this.groupBox_prinfo.Location = new System.Drawing.Point(6, 302);
            this.groupBox_prinfo.Name = "groupBox_prinfo";
            this.groupBox_prinfo.Size = new System.Drawing.Size(511, 94);
            this.groupBox_prinfo.TabIndex = 41;
            this.groupBox_prinfo.TabStop = false;
            this.groupBox_prinfo.Text = "Инфо";
            // 
            // label_percentage
            // 
            this.label_percentage.AutoSize = true;
            this.label_percentage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_percentage.Location = new System.Drawing.Point(412, 65);
            this.label_percentage.Name = "label_percentage";
            this.label_percentage.Size = new System.Drawing.Size(19, 19);
            this.label_percentage.TabIndex = 34;
            this.label_percentage.Text = "--";
            this.label_percentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(495, 42);
            this.progressBar1.TabIndex = 33;
            // 
            // label_timespend
            // 
            this.label_timespend.AutoSize = true;
            this.label_timespend.Location = new System.Drawing.Point(6, 65);
            this.label_timespend.Name = "label_timespend";
            this.label_timespend.Size = new System.Drawing.Size(47, 19);
            this.label_timespend.TabIndex = 35;
            this.label_timespend.Text = "Time:";
            // 
            // button_back_tab4
            // 
            this.button_back_tab4.BackColor = System.Drawing.Color.White;
            this.button_back_tab4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_back_tab4.FlatAppearance.BorderSize = 2;
            this.button_back_tab4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back_tab4.ForeColor = System.Drawing.Color.Black;
            this.button_back_tab4.Location = new System.Drawing.Point(130, 402);
            this.button_back_tab4.Name = "button_back_tab4";
            this.button_back_tab4.Size = new System.Drawing.Size(78, 31);
            this.button_back_tab4.TabIndex = 37;
            this.button_back_tab4.Text = "Назад";
            this.button_back_tab4.UseVisualStyleBackColor = false;
            this.button_back_tab4.Click += new System.EventHandler(this.button_back_tab4_Click_1);
            // 
            // button_print
            // 
            this.button_print.BackColor = System.Drawing.Color.White;
            this.button_print.Enabled = false;
            this.button_print.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_print.FlatAppearance.BorderSize = 2;
            this.button_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_print.ForeColor = System.Drawing.Color.Black;
            this.button_print.Location = new System.Drawing.Point(309, 402);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(98, 31);
            this.button_print.TabIndex = 39;
            this.button_print.Text = "На печать";
            this.button_print.UseVisualStyleBackColor = false;
            this.button_print.Click += new System.EventHandler(this.button_print_Click_1);
            // 
            // button_show
            // 
            this.button_show.BackColor = System.Drawing.Color.White;
            this.button_show.Enabled = false;
            this.button_show.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_show.FlatAppearance.BorderSize = 2;
            this.button_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_show.ForeColor = System.Drawing.Color.Black;
            this.button_show.Location = new System.Drawing.Point(214, 402);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(91, 31);
            this.button_show.TabIndex = 40;
            this.button_show.Text = "Показать";
            this.button_show.UseVisualStyleBackColor = false;
            this.button_show.Click += new System.EventHandler(this.button_show_Click_1);
            // 
            // button_next_tab4
            // 
            this.button_next_tab4.BackColor = System.Drawing.Color.White;
            this.button_next_tab4.Enabled = false;
            this.button_next_tab4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_next_tab4.FlatAppearance.BorderSize = 2;
            this.button_next_tab4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next_tab4.ForeColor = System.Drawing.Color.Black;
            this.button_next_tab4.Location = new System.Drawing.Point(46, 402);
            this.button_next_tab4.Name = "button_next_tab4";
            this.button_next_tab4.Size = new System.Drawing.Size(78, 31);
            this.button_next_tab4.TabIndex = 38;
            this.button_next_tab4.Text = "Выйти";
            this.button_next_tab4.UseVisualStyleBackColor = false;
            this.button_next_tab4.Click += new System.EventHandler(this.button_next_tab4_Click_1);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage7.Controls.Add(this.button_exit);
            this.tabPage7.Controls.Add(this.button_next1);
            this.tabPage7.Controls.Add(this.label_instr);
            this.tabPage7.Controls.Add(this.label_titlle1);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(528, 439);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.White;
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(355, 401);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(78, 31);
            this.button_exit.TabIndex = 40;
            this.button_exit.Text = "Выйти";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_next1
            // 
            this.button_next1.BackColor = System.Drawing.Color.White;
            this.button_next1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_next1.FlatAppearance.BorderSize = 2;
            this.button_next1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_next1.Location = new System.Drawing.Point(439, 401);
            this.button_next1.Name = "button_next1";
            this.button_next1.Size = new System.Drawing.Size(78, 31);
            this.button_next1.TabIndex = 39;
            this.button_next1.Text = "Далее";
            this.button_next1.UseVisualStyleBackColor = false;
            this.button_next1.Click += new System.EventHandler(this.button5_Click);
            // 
            // label_instr
            // 
            this.label_instr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_instr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_instr.Location = new System.Drawing.Point(26, 69);
            this.label_instr.Name = "label_instr";
            this.label_instr.Size = new System.Drawing.Size(491, 94);
            this.label_instr.TabIndex = 39;
            this.label_instr.Text = "Следуйте интрукциям...\r\n";
            // 
            // label_titlle1
            // 
            this.label_titlle1.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_titlle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_titlle1.Location = new System.Drawing.Point(3, 9);
            this.label_titlle1.Name = "label_titlle1";
            this.label_titlle1.Size = new System.Drawing.Size(490, 60);
            this.label_titlle1.TabIndex = 39;
            this.label_titlle1.Text = "Вас приветствует векторизации изображений\r\n";
            this.label_titlle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Image";
            // 
            // button_peview
            // 
            this.button_peview.BackColor = System.Drawing.Color.White;
            this.button_peview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_peview.Enabled = false;
            this.button_peview.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_peview.FlatAppearance.BorderSize = 2;
            this.button_peview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_peview.Font = new System.Drawing.Font("Cambria", 12F);
            this.button_peview.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_peview.Location = new System.Drawing.Point(664, 5);
            this.button_peview.Name = "button_peview";
            this.button_peview.Size = new System.Drawing.Size(29, 28);
            this.button_peview.TabIndex = 32;
            this.button_peview.Text = "+";
            this.button_peview.UseVisualStyleBackColor = false;
            this.button_peview.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // button_help
            // 
            this.button_help.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_help.FlatAppearance.BorderSize = 2;
            this.button_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_help.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_help.Location = new System.Drawing.Point(4, 408);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(86, 31);
            this.button_help.TabIndex = 35;
            this.button_help.Text = "Справка";
            this.button_help.UseVisualStyleBackColor = true;
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title.Location = new System.Drawing.Point(4, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(151, 55);
            this.label_title.TabIndex = 35;
            this.label_title.Text = "Векторизация\r\nрастра";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.panel1.Location = new System.Drawing.Point(162, -33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 42);
            this.panel1.TabIndex = 36;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Vect Files|*.pcv|Old Vect Format|*.prres";
            // 
            // label_1
            // 
            this.label_1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_1.ForeColor = System.Drawing.Color.White;
            this.label_1.Image = ((System.Drawing.Image)(resources.GetObject("label_1.Image")));
            this.label_1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_1.Location = new System.Drawing.Point(8, 70);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(142, 42);
            this.label_1.TabIndex = 35;
            this.label_1.Text = " Приветствие";
            this.label_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_2
            // 
            this.label_2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_2.ForeColor = System.Drawing.Color.White;
            this.label_2.Image = ((System.Drawing.Image)(resources.GetObject("label_2.Image")));
            this.label_2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_2.Location = new System.Drawing.Point(8, 106);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(142, 42);
            this.label_2.TabIndex = 37;
            this.label_2.Text = "  Выбор файла";
            this.label_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_3
            // 
            this.label_3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_3.ForeColor = System.Drawing.Color.White;
            this.label_3.Image = ((System.Drawing.Image)(resources.GetObject("label_3.Image")));
            this.label_3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_3.Location = new System.Drawing.Point(8, 142);
            this.label_3.Name = "label_3";
            this.label_3.Size = new System.Drawing.Size(147, 54);
            this.label_3.TabIndex = 38;
            this.label_3.Text = "     Первичная\r\n     обработка";
            this.label_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_4
            // 
            this.label_4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_4.ForeColor = System.Drawing.Color.White;
            this.label_4.Image = ((System.Drawing.Image)(resources.GetObject("label_4.Image")));
            this.label_4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_4.Location = new System.Drawing.Point(8, 190);
            this.label_4.Name = "label_4";
            this.label_4.Size = new System.Drawing.Size(147, 53);
            this.label_4.TabIndex = 39;
            this.label_4.Text = "     Черно-белый \r\n     формат";
            this.label_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_5
            // 
            this.label_5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_5.ForeColor = System.Drawing.Color.White;
            this.label_5.Image = ((System.Drawing.Image)(resources.GetObject("label_5.Image")));
            this.label_5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_5.Location = new System.Drawing.Point(8, 237);
            this.label_5.Name = "label_5";
            this.label_5.Size = new System.Drawing.Size(151, 37);
            this.label_5.TabIndex = 40;
            this.label_5.Text = "    Детектор границ";
            this.label_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_6
            // 
            this.label_6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_6.ForeColor = System.Drawing.Color.White;
            this.label_6.Image = ((System.Drawing.Image)(resources.GetObject("label_6.Image")));
            this.label_6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_6.Location = new System.Drawing.Point(8, 268);
            this.label_6.Name = "label_6";
            this.label_6.Size = new System.Drawing.Size(132, 37);
            this.label_6.TabIndex = 41;
            this.label_6.Text = " Подготовка";
            this.label_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_7
            // 
            this.label_7.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_7.ForeColor = System.Drawing.Color.White;
            this.label_7.Image = ((System.Drawing.Image)(resources.GetObject("label_7.Image")));
            this.label_7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_7.Location = new System.Drawing.Point(8, 299);
            this.label_7.Name = "label_7";
            this.label_7.Size = new System.Drawing.Size(147, 37);
            this.label_7.TabIndex = 42;
            this.label_7.Text = "     Векторизация   ";
            this.label_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_VectorMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(694, 444);
            this.Controls.Add(this.label_7);
            this.Controls.Add(this.label_6);
            this.Controls.Add(this.label_5);
            this.Controls.Add(this.label_3);
            this.Controls.Add(this.label_4);
            this.Controls.Add(this.label_2);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.button_peview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form_VectorMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get Vector From Image";
            this.Load += new System.EventHandler(this.Form_rastermaster_Load);
            this.Shown += new System.EventHandler(this.Form_rastermaster_Shown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_rastermaster_MouseUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_right)).EndInit();
            this.groupBox_rotate.ResumeLayout(false);
            this.groupBox_rotate.PerformLayout();
            this.groupBox_flip.ResumeLayout(false);
            this.groupBox_flip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox_grayform.ResumeLayout(false);
            this.groupBox_grayform.PerformLayout();
            this.groupBox_colormod.ResumeLayout(false);
            this.groupBox_colormod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_hardbwthreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox_gauss.ResumeLayout(false);
            this.groupBox_gauss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_gauss_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_gauss_sigma)).EndInit();
            this.groupBox_sobel.ResumeLayout(false);
            this.groupBox_sobel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_sobelthreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab4)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tab0)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_prinfo.ResumeLayout(false);
            this.groupBox_prinfo.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.GroupBox groupBox_rotate;
        internal System.Windows.Forms.RadioButton radioButton_270deg;
        internal System.Windows.Forms.RadioButton radioButton_90deg;
        internal System.Windows.Forms.RadioButton radioButton_180deg;
        internal System.Windows.Forms.RadioButton radioButton_0deg;
        internal System.Windows.Forms.GroupBox groupBox_flip;
        internal System.Windows.Forms.CheckBox checkBox_useflip;
        internal System.Windows.Forms.RadioButton radioButton_flipy;
        internal System.Windows.Forms.RadioButton radioButton_flipx;
        internal System.Windows.Forms.PictureBox pictureBox_tab1;
        internal System.Windows.Forms.Label label_path;
        internal System.Windows.Forms.Button button_next;
        internal System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.Button button_back_tab2;
        internal System.Windows.Forms.Label label_size;
        internal System.Windows.Forms.Label label_resolution;
        internal System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.Label label_harbw;
        internal System.Windows.Forms.ComboBox comboBox_grayform;
        internal System.Windows.Forms.TrackBar trackBar_hardbwthreshold;
        internal System.Windows.Forms.RadioButton radioButton_hardbw;
        internal System.Windows.Forms.RadioButton radioButton_grayform;
        internal System.Windows.Forms.PictureBox scroll_right;
        internal System.Windows.Forms.PictureBox scroll_down;
        internal System.Windows.Forms.PictureBox scroll_up;
        internal System.Windows.Forms.PictureBox scroll_left;
        internal System.Windows.Forms.Button button_next_tab2;
        internal System.Windows.Forms.PictureBox pictureBox_tab2;
        internal System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.GroupBox groupBox_gauss;
        internal System.Windows.Forms.Label label_gauss_scale;
        internal System.Windows.Forms.Label label_gauss_sigma;
        internal System.Windows.Forms.TrackBar trackBar_gauss_scale;
        internal System.Windows.Forms.TrackBar trackBar_gauss_sigma;
        internal System.Windows.Forms.GroupBox groupBox_sobel;
        internal System.Windows.Forms.Label label_sobel;
        internal System.Windows.Forms.TrackBar trackBar_sobelthreshold;
        internal System.Windows.Forms.Button button_next_tab3;
        internal System.Windows.Forms.Button button_back_tab3;
        internal System.Windows.Forms.PictureBox pictureBox_tab3;
        internal MRG.Controls.UI.LoadingCircle loadingCircle_tab3;
        internal MRG.Controls.UI.LoadingCircle loadingCircle_tab2;
        internal System.Windows.Forms.Button button_update_tab2;
        internal System.Windows.Forms.Button button_update_tab3;
        internal System.Windows.Forms.Button button_peview;
        internal System.Windows.Forms.Button button_loadimage;
        internal System.Windows.Forms.TabPage tabPage4;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        internal System.Windows.Forms.Label label_strcount;
        internal System.Windows.Forms.Label label_resolution_;
        internal System.Windows.Forms.Label label_imgname;
        internal System.Windows.Forms.Button button_pr;
        internal MRG.Controls.UI.LoadingCircle loadingCircle_tab4;
        internal System.Windows.Forms.PictureBox pictureBox_tab4;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.TabPage tabPage5;
        internal System.Windows.Forms.Label label_img_size;
        internal System.Windows.Forms.Label label_img_name;
        internal System.Windows.Forms.Button button_exit_tab0;
        internal System.Windows.Forms.Button button_openfolder;
        internal System.Windows.Forms.Button button_remove;
        internal System.Windows.Forms.Button button_update;
        internal System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.PictureBox pictureBox_tab0;
        internal System.Windows.Forms.Button button_next_tab0;
        internal System.Windows.Forms.Label label_img_dpi;
        internal System.Windows.Forms.Label label_img_pixelformat;
        internal System.Windows.Forms.Label label_img_resol;
        internal System.Windows.Forms.Button button_help;
        internal System.Windows.Forms.Label label_title;
        internal System.Windows.Forms.Button button_back_img;
        internal System.Windows.Forms.GroupBox groupBox_grayform;
        internal System.Windows.Forms.Label label_colormod;
        internal System.Windows.Forms.GroupBox groupBox_colormod;
        internal System.Windows.Forms.TabPage tabPage6;
        internal System.Windows.Forms.Button button_savepr;
        internal System.Windows.Forms.GroupBox groupBox_prinfo;
        internal System.Windows.Forms.Label label_timespend;
        internal System.Windows.Forms.Label label_percentage;
        internal System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.Button button_print;
        internal System.Windows.Forms.Button button_show;
        internal System.Windows.Forms.Button button_next_tab4;
        internal System.Windows.Forms.Button button_back_tab4;
        internal System.Windows.Forms.Button button_back_pr;
        internal System.Windows.Forms.TabPage tabPage7;
        internal System.Windows.Forms.Label label_titlle1;
        internal System.Windows.Forms.Label label_instr;
        internal System.Windows.Forms.Button button_exit;
        internal System.Windows.Forms.Button button_next1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal System.Windows.Forms.Label label_1;
        internal System.Windows.Forms.Label label_2;
        internal System.Windows.Forms.Label label_3;
        internal System.Windows.Forms.Label label_4;
        internal System.Windows.Forms.Label label_5;
        internal System.Windows.Forms.Label label_6;
        internal System.Windows.Forms.Label label_7;
    }
}
