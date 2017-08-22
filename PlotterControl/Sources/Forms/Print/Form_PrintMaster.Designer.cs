/*=================================\
* PlotterControl\Form_PrintMaster.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 09.08.2017 14:57
* Last Edited: 19.08.2017 22:27:02
*=================================*/

namespace CnC_WFA
{
    partial class Form_PrintMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PrintMaster));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.label_title_2 = new System.Windows.Forms.Label();
            this.label_5 = new System.Windows.Forms.Label();
            this.label_4 = new System.Windows.Forms.Label();
            this.label_3 = new System.Windows.Forms.Label();
            this.label_2 = new System.Windows.Forms.Label();
            this.label_1 = new System.Windows.Forms.Label();
            this.button_help = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_bd = new System.Windows.Forms.Label();
            this.label_com = new System.Windows.Forms.Label();
            this.button_open = new System.Windows.Forms.Button();
            this.comboBox_bdrate = new System.Windows.Forms.ComboBox();
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.button_tab1_exit = new System.Windows.Forms.Button();
            this.button_tab1_next = new System.Windows.Forms.Button();
            this.label_discr = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_pickVect = new System.Windows.Forms.TabPage();
            this.button_deviceInfo = new System.Windows.Forms.Button();
            this.loadingCircle_previewLoad = new MRG.Controls.UI.LoadingCircle();
            this.label_type = new System.Windows.Forms.Label();
            this.label_resol = new System.Windows.Forms.Label();
            this.button_tab2_back = new System.Windows.Forms.Button();
            this.button_tab2_next = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_upload = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.listBox_fileList = new System.Windows.Forms.ListBox();
            this.pictureBox_preview = new System.Windows.Forms.PictureBox();
            this.tabPage_opts = new System.Windows.Forms.TabPage();
            this.groupBox_pens = new System.Windows.Forms.GroupBox();
            this.pictureBox_color = new System.Windows.Forms.PictureBox();
            this.label_color = new System.Windows.Forms.Label();
            this.comboBox_pens = new System.Windows.Forms.ComboBox();
            this.textBox_elev_corr = new System.Windows.Forms.TextBox();
            this.label_elev_corr_1 = new System.Windows.Forms.Label();
            this.label_elev_corr = new System.Windows.Forms.Label();
            this.textBox_elev_delta = new System.Windows.Forms.TextBox();
            this.label_elev_delta_1 = new System.Windows.Forms.Label();
            this.label_elev_delta = new System.Windows.Forms.Label();
            this.button_tab3_back = new System.Windows.Forms.Button();
            this.groupBox_size = new System.Windows.Forms.GroupBox();
            this.textBox_xsize = new System.Windows.Forms.TextBox();
            this.label_measure_xsize = new System.Windows.Forms.Label();
            this.textBox_ysize = new System.Windows.Forms.TextBox();
            this.label_measure_ysize = new System.Windows.Forms.Label();
            this.label_maxx = new System.Windows.Forms.Label();
            this.label_maxy = new System.Windows.Forms.Label();
            this.label_ysize = new System.Windows.Forms.Label();
            this.label_xsize = new System.Windows.Forms.Label();
            this.radioButton_ysize = new System.Windows.Forms.RadioButton();
            this.radioButton_xsize = new System.Windows.Forms.RadioButton();
            this.button_tab3_next = new System.Windows.Forms.Button();
            this.tabPage_print = new System.Windows.Forms.TabPage();
            this.label_percentage = new System.Windows.Forms.Label();
            this.label_progress = new System.Windows.Forms.Label();
            this.label_speed = new System.Windows.Forms.Label();
            this.label_leftTime = new System.Windows.Forms.Label();
            this.label_spendTme = new System.Windows.Forms.Label();
            this.button_abort = new System.Windows.Forms.Button();
            this.button_pause = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabPage_end = new System.Windows.Forms.TabPage();
            this.button_tab5_exit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage_main.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_pickVect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
            this.tabPage_opts.SuspendLayout();
            this.groupBox_pens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_color)).BeginInit();
            this.groupBox_size.SuspendLayout();
            this.tabPage_print.SuspendLayout();
            this.tabPage_end.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title_2
            // 
            this.label_title_2.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title_2.ForeColor = System.Drawing.Color.White;
            this.label_title_2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title_2.Location = new System.Drawing.Point(-1, 9);
            this.label_title_2.Name = "label_title_2";
            this.label_title_2.Size = new System.Drawing.Size(151, 36);
            this.label_title_2.TabIndex = 17;
            this.label_title_2.Text = "???????????? ??????????????";
            this.label_title_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_5
            // 
            this.label_5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_5.ForeColor = System.Drawing.Color.White;
            this.label_5.Image = ((System.Drawing.Image)(resources.GetObject("label_5.Image")));
            this.label_5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_5.Location = new System.Drawing.Point(8, 229);
            this.label_5.Name = "label_5";
            this.label_5.Size = new System.Drawing.Size(142, 36);
            this.label_5.TabIndex = 18;
            this.label_5.Text = "        ????????????????????";
            this.label_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_4
            // 
            this.label_4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_4.ForeColor = System.Drawing.Color.White;
            this.label_4.Image = ((System.Drawing.Image)(resources.GetObject("label_4.Image")));
            this.label_4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_4.Location = new System.Drawing.Point(8, 192);
            this.label_4.Name = "label_4";
            this.label_4.Size = new System.Drawing.Size(142, 36);
            this.label_4.TabIndex = 16;
            this.label_4.Text = "        ????????????";
            this.label_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_3
            // 
            this.label_3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_3.ForeColor = System.Drawing.Color.White;
            this.label_3.Image = ((System.Drawing.Image)(resources.GetObject("label_3.Image")));
            this.label_3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_3.Location = new System.Drawing.Point(8, 142);
            this.label_3.Name = "label_3";
            this.label_3.Size = new System.Drawing.Size(142, 43);
            this.label_3.TabIndex = 15;
            this.label_3.Text = "        ??????????????????\r\n        ????????????";
            this.label_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_2
            // 
            this.label_2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_2.ForeColor = System.Drawing.Color.White;
            this.label_2.Image = ((System.Drawing.Image)(resources.GetObject("label_2.Image")));
            this.label_2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_2.Location = new System.Drawing.Point(8, 106);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(151, 36);
            this.label_2.TabIndex = 14;
            this.label_2.Text = "     ?????????? ??????????";
            this.label_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_1
            // 
            this.label_1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_1.ForeColor = System.Drawing.Color.White;
            this.label_1.Image = ((System.Drawing.Image)(resources.GetObject("label_1.Image")));
            this.label_1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_1.Location = new System.Drawing.Point(8, 70);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(142, 36);
            this.label_1.TabIndex = 13;
            this.label_1.Text = "      ??????????????????????";
            this.label_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_help
            // 
            this.button_help.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_help.FlatAppearance.BorderSize = 2;
            this.button_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_help.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_help.Location = new System.Drawing.Point(8, 408);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(86, 31);
            this.button_help.TabIndex = 34;
            this.button_help.Text = "??????????????";
            this.button_help.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "VectFile.pcv";
            this.openFileDialog1.Filter = "PrRes Files(*.pcv)|*.pcv|PrRes Files(*.prres)|*.prres";
            // 
            // tabPage_main
            // 
            this.tabPage_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_main.Controls.Add(this.label1);
            this.tabPage_main.Controls.Add(this.groupBox4);
            this.tabPage_main.Controls.Add(this.button_tab1_exit);
            this.tabPage_main.Controls.Add(this.button_tab1_next);
            this.tabPage_main.Controls.Add(this.label_discr);
            this.tabPage_main.Controls.Add(this.label_title);
            this.tabPage_main.Location = new System.Drawing.Point(4, 31);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Size = new System.Drawing.Size(531, 444);
            this.tabPage_main.TabIndex = 4;
            this.tabPage_main.Text = "tabPage_main";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_bd);
            this.groupBox4.Controls.Add(this.label_com);
            this.groupBox4.Controls.Add(this.button_open);
            this.groupBox4.Controls.Add(this.comboBox_bdrate);
            this.groupBox4.Controls.Add(this.comboBox_com);
            this.groupBox4.Font = new System.Drawing.Font("Cambria", 12F);
            this.groupBox4.Location = new System.Drawing.Point(169, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 105);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "????????????????????";
            // 
            // label_bd
            // 
            this.label_bd.AutoSize = true;
            this.label_bd.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_bd.Location = new System.Drawing.Point(5, 64);
            this.label_bd.Name = "label_bd";
            this.label_bd.Size = new System.Drawing.Size(125, 19);
            this.label_bd.TabIndex = 24;
            this.label_bd.Text = "???????????????? ????????.: ";
            // 
            // label_com
            // 
            this.label_com.AutoSize = true;
            this.label_com.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_com.Location = new System.Drawing.Point(5, 31);
            this.label_com.Name = "label_com";
            this.label_com.Size = new System.Drawing.Size(91, 19);
            this.label_com.TabIndex = 15;
            this.label_com.Text = "?????? ??????????:";
            // 
            // button_open
            // 
            this.button_open.BackColor = System.Drawing.Color.White;
            this.button_open.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_open.FlatAppearance.BorderSize = 2;
            this.button_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_open.Font = new System.Drawing.Font("Cambria", 12F);
            this.button_open.Location = new System.Drawing.Point(270, 45);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(72, 38);
            this.button_open.TabIndex = 23;
            this.button_open.Text = "??????????.";
            this.button_open.UseVisualStyleBackColor = false;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // comboBox_bdrate
            // 
            this.comboBox_bdrate.BackColor = System.Drawing.Color.White;
            this.comboBox_bdrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bdrate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_bdrate.Font = new System.Drawing.Font("Cambria", 12F);
            this.comboBox_bdrate.FormattingEnabled = true;
            this.comboBox_bdrate.Items.AddRange(new object[] {
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
            this.comboBox_bdrate.Location = new System.Drawing.Point(136, 61);
            this.comboBox_bdrate.Name = "comboBox_bdrate";
            this.comboBox_bdrate.Size = new System.Drawing.Size(121, 27);
            this.comboBox_bdrate.TabIndex = 1;
            this.comboBox_bdrate.SelectedIndexChanged += new System.EventHandler(this.comboBox_bdrate_SelectedIndexChanged);
            // 
            // comboBox_com
            // 
            this.comboBox_com.BackColor = System.Drawing.Color.White;
            this.comboBox_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_com.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_com.Font = new System.Drawing.Font("Cambria", 12F);
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(136, 28);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(121, 27);
            this.comboBox_com.TabIndex = 0;
            this.comboBox_com.SelectedIndexChanged += new System.EventHandler(this.comboBox_com_SelectedIndexChanged);
            this.comboBox_com.Click += new System.EventHandler(this.comboBox_com_Click);
            // 
            // button_tab1_exit
            // 
            this.button_tab1_exit.BackColor = System.Drawing.Color.White;
            this.button_tab1_exit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab1_exit.FlatAppearance.BorderSize = 2;
            this.button_tab1_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab1_exit.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab1_exit.Location = new System.Drawing.Point(356, 407);
            this.button_tab1_exit.Name = "button_tab1_exit";
            this.button_tab1_exit.Size = new System.Drawing.Size(78, 31);
            this.button_tab1_exit.TabIndex = 38;
            this.button_tab1_exit.Text = "??????????";
            this.button_tab1_exit.UseVisualStyleBackColor = false;
            this.button_tab1_exit.Click += new System.EventHandler(this.button_tab1_exit_Click);
            // 
            // button_tab1_next
            // 
            this.button_tab1_next.BackColor = System.Drawing.Color.White;
            this.button_tab1_next.Enabled = false;
            this.button_tab1_next.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab1_next.FlatAppearance.BorderSize = 2;
            this.button_tab1_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab1_next.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab1_next.Location = new System.Drawing.Point(440, 407);
            this.button_tab1_next.Name = "button_tab1_next";
            this.button_tab1_next.Size = new System.Drawing.Size(78, 31);
            this.button_tab1_next.TabIndex = 37;
            this.button_tab1_next.Text = "??????????";
            this.button_tab1_next.UseVisualStyleBackColor = false;
            this.button_tab1_next.Click += new System.EventHandler(this.button_tab1_next_Click);
            // 
            // label_discr
            // 
            this.label_discr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_discr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_discr.Location = new System.Drawing.Point(26, 75);
            this.label_discr.Name = "label_discr";
            this.label_discr.Size = new System.Drawing.Size(491, 45);
            this.label_discr.TabIndex = 36;
            this.label_discr.Text = "???????????????? ???????????????????? ?????????????????? ?? ??????????????, ?? ?? ???????????????????? ???? ???????????????? ?????????????????????? ??" +
    "??????????.\r\n\r\n";
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title.Location = new System.Drawing.Point(3, 14);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(401, 41);
            this.label_title.TabIndex = 35;
            this.label_title.Text = "?????? ???????????????????????? ???????????? ????????????\r\n";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage_pickVect);
            this.tabControl1.Controls.Add(this.tabPage_opts);
            this.tabControl1.Controls.Add(this.tabPage_print);
            this.tabControl1.Controls.Add(this.tabPage_end);
            this.tabControl1.Font = new System.Drawing.Font("Cambria", 12F);
            this.tabControl1.Location = new System.Drawing.Point(161, -30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 479);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage_pickVect
            // 
            this.tabPage_pickVect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_pickVect.Controls.Add(this.button_deviceInfo);
            this.tabPage_pickVect.Controls.Add(this.loadingCircle_previewLoad);
            this.tabPage_pickVect.Controls.Add(this.label_type);
            this.tabPage_pickVect.Controls.Add(this.label_resol);
            this.tabPage_pickVect.Controls.Add(this.button_tab2_back);
            this.tabPage_pickVect.Controls.Add(this.button_tab2_next);
            this.tabPage_pickVect.Controls.Add(this.button_refresh);
            this.tabPage_pickVect.Controls.Add(this.button_upload);
            this.tabPage_pickVect.Controls.Add(this.button_delete);
            this.tabPage_pickVect.Controls.Add(this.listBox_fileList);
            this.tabPage_pickVect.Controls.Add(this.pictureBox_preview);
            this.tabPage_pickVect.Location = new System.Drawing.Point(4, 31);
            this.tabPage_pickVect.Name = "tabPage_pickVect";
            this.tabPage_pickVect.Size = new System.Drawing.Size(531, 444);
            this.tabPage_pickVect.TabIndex = 5;
            this.tabPage_pickVect.Text = "tabPage1";
            // 
            // button_deviceInfo
            // 
            this.button_deviceInfo.BackColor = System.Drawing.Color.White;
            this.button_deviceInfo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_deviceInfo.FlatAppearance.BorderSize = 2;
            this.button_deviceInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deviceInfo.Location = new System.Drawing.Point(420, 328);
            this.button_deviceInfo.Name = "button_deviceInfo";
            this.button_deviceInfo.Size = new System.Drawing.Size(98, 34);
            this.button_deviceInfo.TabIndex = 43;
            this.button_deviceInfo.Text = "????????";
            this.button_deviceInfo.UseVisualStyleBackColor = false;
            this.button_deviceInfo.Click += new System.EventHandler(this.button_deviceInfo_Click);
            // 
            // loadingCircle_previewLoad
            // 
            this.loadingCircle_previewLoad.Active = true;
            this.loadingCircle_previewLoad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle_previewLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle_previewLoad.BackgroundImage")));
            this.loadingCircle_previewLoad.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle_previewLoad.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle_previewLoad.InnerCircleRadius = 5;
            this.loadingCircle_previewLoad.Location = new System.Drawing.Point(222, 159);
            this.loadingCircle_previewLoad.Name = "loadingCircle_previewLoad";
            this.loadingCircle_previewLoad.NumberSpoke = 12;
            this.loadingCircle_previewLoad.OuterCircleRadius = 11;
            this.loadingCircle_previewLoad.RotationSpeed = 100;
            this.loadingCircle_previewLoad.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle_previewLoad.SpokeThickness = 2;
            this.loadingCircle_previewLoad.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle_previewLoad.TabIndex = 32;
            this.loadingCircle_previewLoad.Text = "loadingCircle2";
            this.loadingCircle_previewLoad.UseWaitCursor = true;
            this.loadingCircle_previewLoad.Visible = false;
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(269, 237);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(0, 19);
            this.label_type.TabIndex = 42;
            // 
            // label_resol
            // 
            this.label_resol.AutoSize = true;
            this.label_resol.Location = new System.Drawing.Point(269, 215);
            this.label_resol.Name = "label_resol";
            this.label_resol.Size = new System.Drawing.Size(0, 19);
            this.label_resol.TabIndex = 41;
            // 
            // button_tab2_back
            // 
            this.button_tab2_back.BackColor = System.Drawing.Color.White;
            this.button_tab2_back.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab2_back.FlatAppearance.BorderSize = 2;
            this.button_tab2_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab2_back.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab2_back.Location = new System.Drawing.Point(356, 407);
            this.button_tab2_back.Name = "button_tab2_back";
            this.button_tab2_back.Size = new System.Drawing.Size(78, 31);
            this.button_tab2_back.TabIndex = 40;
            this.button_tab2_back.Text = "??????????";
            this.button_tab2_back.UseVisualStyleBackColor = false;
            this.button_tab2_back.Click += new System.EventHandler(this.button_tab2_back_Click);
            // 
            // button_tab2_next
            // 
            this.button_tab2_next.BackColor = System.Drawing.Color.White;
            this.button_tab2_next.Enabled = false;
            this.button_tab2_next.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab2_next.FlatAppearance.BorderSize = 2;
            this.button_tab2_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab2_next.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab2_next.Location = new System.Drawing.Point(440, 407);
            this.button_tab2_next.Name = "button_tab2_next";
            this.button_tab2_next.Size = new System.Drawing.Size(78, 31);
            this.button_tab2_next.TabIndex = 39;
            this.button_tab2_next.Text = "??????????";
            this.button_tab2_next.UseVisualStyleBackColor = false;
            this.button_tab2_next.Click += new System.EventHandler(this.button_tab2_next_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.Color.White;
            this.button_refresh.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_refresh.FlatAppearance.BorderSize = 2;
            this.button_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_refresh.Location = new System.Drawing.Point(420, 368);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(97, 33);
            this.button_refresh.TabIndex = 4;
            this.button_refresh.Text = "????????????????";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_upload
            // 
            this.button_upload.BackColor = System.Drawing.Color.White;
            this.button_upload.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_upload.FlatAppearance.BorderSize = 2;
            this.button_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_upload.Location = new System.Drawing.Point(116, 400);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(98, 33);
            this.button_upload.TabIndex = 3;
            this.button_upload.Text = "??????????????????";
            this.button_upload.UseVisualStyleBackColor = false;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.White;
            this.button_delete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_delete.FlatAppearance.BorderSize = 2;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.Location = new System.Drawing.Point(13, 400);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(97, 33);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "??????????????";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // listBox_fileList
            // 
            this.listBox_fileList.FormattingEnabled = true;
            this.listBox_fileList.ItemHeight = 19;
            this.listBox_fileList.Location = new System.Drawing.Point(13, 10);
            this.listBox_fileList.Name = "listBox_fileList";
            this.listBox_fileList.Size = new System.Drawing.Size(250, 384);
            this.listBox_fileList.TabIndex = 1;
            this.listBox_fileList.SelectedIndexChanged += new System.EventHandler(this.listBox_fileList_SelectedIndexChanged);
            // 
            // pictureBox_preview
            // 
            this.pictureBox_preview.BackColor = System.Drawing.Color.Silver;
            this.pictureBox_preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_preview.Location = new System.Drawing.Point(269, 11);
            this.pictureBox_preview.Name = "pictureBox_preview";
            this.pictureBox_preview.Size = new System.Drawing.Size(248, 201);
            this.pictureBox_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_preview.TabIndex = 0;
            this.pictureBox_preview.TabStop = false;
            // 
            // tabPage_opts
            // 
            this.tabPage_opts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_opts.Controls.Add(this.groupBox_pens);
            this.tabPage_opts.Controls.Add(this.button_tab3_back);
            this.tabPage_opts.Controls.Add(this.groupBox_size);
            this.tabPage_opts.Controls.Add(this.button_tab3_next);
            this.tabPage_opts.Location = new System.Drawing.Point(4, 31);
            this.tabPage_opts.Name = "tabPage_opts";
            this.tabPage_opts.Size = new System.Drawing.Size(531, 444);
            this.tabPage_opts.TabIndex = 7;
            this.tabPage_opts.Text = "tabPage_opts";
            // 
            // groupBox_pens
            // 
            this.groupBox_pens.Controls.Add(this.pictureBox_color);
            this.groupBox_pens.Controls.Add(this.label_color);
            this.groupBox_pens.Controls.Add(this.comboBox_pens);
            this.groupBox_pens.Controls.Add(this.textBox_elev_corr);
            this.groupBox_pens.Controls.Add(this.label_elev_corr_1);
            this.groupBox_pens.Controls.Add(this.label_elev_corr);
            this.groupBox_pens.Controls.Add(this.textBox_elev_delta);
            this.groupBox_pens.Controls.Add(this.label_elev_delta_1);
            this.groupBox_pens.Controls.Add(this.label_elev_delta);
            this.groupBox_pens.Location = new System.Drawing.Point(17, 182);
            this.groupBox_pens.Name = "groupBox_pens";
            this.groupBox_pens.Size = new System.Drawing.Size(500, 141);
            this.groupBox_pens.TabIndex = 47;
            this.groupBox_pens.TabStop = false;
            this.groupBox_pens.Text = "?????????????????? ????????";
            // 
            // pictureBox_color
            // 
            this.pictureBox_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_color.Location = new System.Drawing.Point(149, 85);
            this.pictureBox_color.Name = "pictureBox_color";
            this.pictureBox_color.Size = new System.Drawing.Size(49, 25);
            this.pictureBox_color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_color.TabIndex = 48;
            this.pictureBox_color.TabStop = false;
            // 
            // label_color
            // 
            this.label_color.AutoSize = true;
            this.label_color.Location = new System.Drawing.Point(95, 88);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(52, 19);
            this.label_color.TabIndex = 47;
            this.label_color.Text = "????????: ";
            // 
            // comboBox_pens
            // 
            this.comboBox_pens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pens.FormattingEnabled = true;
            this.comboBox_pens.Location = new System.Drawing.Point(25, 43);
            this.comboBox_pens.Name = "comboBox_pens";
            this.comboBox_pens.Size = new System.Drawing.Size(173, 27);
            this.comboBox_pens.TabIndex = 46;
            this.comboBox_pens.SelectedIndexChanged += new System.EventHandler(this.comboBox_pens_SelectedIndexChanged);
            // 
            // textBox_elev_corr
            // 
            this.textBox_elev_corr.Font = new System.Drawing.Font("Cambria", 12F);
            this.textBox_elev_corr.Location = new System.Drawing.Point(355, 85);
            this.textBox_elev_corr.MaxLength = 14;
            this.textBox_elev_corr.Name = "textBox_elev_corr";
            this.textBox_elev_corr.Size = new System.Drawing.Size(62, 26);
            this.textBox_elev_corr.TabIndex = 43;
            // 
            // label_elev_corr_1
            // 
            this.label_elev_corr_1.AutoSize = true;
            this.label_elev_corr_1.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_elev_corr_1.Location = new System.Drawing.Point(419, 87);
            this.label_elev_corr_1.Name = "label_elev_corr_1";
            this.label_elev_corr_1.Size = new System.Drawing.Size(57, 19);
            this.label_elev_corr_1.TabIndex = 45;
            this.label_elev_corr_1.Text = "??????????.";
            // 
            // label_elev_corr
            // 
            this.label_elev_corr.AutoSize = true;
            this.label_elev_corr.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_elev_corr.Location = new System.Drawing.Point(226, 79);
            this.label_elev_corr.Name = "label_elev_corr";
            this.label_elev_corr.Size = new System.Drawing.Size(123, 38);
            this.label_elev_corr.TabIndex = 44;
            this.label_elev_corr.Text = "??????????????????????????\r\n???????????????? ????????:\r\n";
            // 
            // textBox_elev_delta
            // 
            this.textBox_elev_delta.Font = new System.Drawing.Font("Cambria", 12F);
            this.textBox_elev_delta.Location = new System.Drawing.Point(355, 39);
            this.textBox_elev_delta.MaxLength = 14;
            this.textBox_elev_delta.Name = "textBox_elev_delta";
            this.textBox_elev_delta.Size = new System.Drawing.Size(62, 26);
            this.textBox_elev_delta.TabIndex = 11;
            // 
            // label_elev_delta_1
            // 
            this.label_elev_delta_1.AutoSize = true;
            this.label_elev_delta_1.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_elev_delta_1.Location = new System.Drawing.Point(419, 42);
            this.label_elev_delta_1.Name = "label_elev_delta_1";
            this.label_elev_delta_1.Size = new System.Drawing.Size(57, 19);
            this.label_elev_delta_1.TabIndex = 13;
            this.label_elev_delta_1.Text = "??????????.";
            // 
            // label_elev_delta
            // 
            this.label_elev_delta.AutoSize = true;
            this.label_elev_delta.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_elev_delta.Location = new System.Drawing.Point(226, 31);
            this.label_elev_delta.Name = "label_elev_delta";
            this.label_elev_delta.Size = new System.Drawing.Size(122, 38);
            this.label_elev_delta.TabIndex = 12;
            this.label_elev_delta.Text = "???????????? \r\n???????????????? ????????:";
            // 
            // button_tab3_back
            // 
            this.button_tab3_back.BackColor = System.Drawing.Color.White;
            this.button_tab3_back.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab3_back.FlatAppearance.BorderSize = 2;
            this.button_tab3_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab3_back.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab3_back.Location = new System.Drawing.Point(356, 407);
            this.button_tab3_back.Name = "button_tab3_back";
            this.button_tab3_back.Size = new System.Drawing.Size(78, 31);
            this.button_tab3_back.TabIndex = 42;
            this.button_tab3_back.Text = "??????????";
            this.button_tab3_back.UseVisualStyleBackColor = false;
            this.button_tab3_back.Click += new System.EventHandler(this.button_tab3_back_Click);
            // 
            // groupBox_size
            // 
            this.groupBox_size.Controls.Add(this.textBox_xsize);
            this.groupBox_size.Controls.Add(this.label_measure_xsize);
            this.groupBox_size.Controls.Add(this.textBox_ysize);
            this.groupBox_size.Controls.Add(this.label_measure_ysize);
            this.groupBox_size.Controls.Add(this.label_maxx);
            this.groupBox_size.Controls.Add(this.label_maxy);
            this.groupBox_size.Controls.Add(this.label_ysize);
            this.groupBox_size.Controls.Add(this.label_xsize);
            this.groupBox_size.Controls.Add(this.radioButton_ysize);
            this.groupBox_size.Controls.Add(this.radioButton_xsize);
            this.groupBox_size.Font = new System.Drawing.Font("Cambria", 12F);
            this.groupBox_size.Location = new System.Drawing.Point(17, 11);
            this.groupBox_size.Name = "groupBox_size";
            this.groupBox_size.Size = new System.Drawing.Size(500, 151);
            this.groupBox_size.TabIndex = 19;
            this.groupBox_size.TabStop = false;
            this.groupBox_size.Text = "????????????";
            // 
            // textBox_xsize
            // 
            this.textBox_xsize.Font = new System.Drawing.Font("Cambria", 12F);
            this.textBox_xsize.Location = new System.Drawing.Point(149, 76);
            this.textBox_xsize.MaxLength = 14;
            this.textBox_xsize.Name = "textBox_xsize";
            this.textBox_xsize.Size = new System.Drawing.Size(92, 26);
            this.textBox_xsize.TabIndex = 0;
            this.textBox_xsize.Text = "100";
            this.textBox_xsize.TextChanged += new System.EventHandler(this.textBox_xsize_TextChanged);
            // 
            // label_measure_xsize
            // 
            this.label_measure_xsize.AutoSize = true;
            this.label_measure_xsize.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_measure_xsize.Location = new System.Drawing.Point(247, 79);
            this.label_measure_xsize.Name = "label_measure_xsize";
            this.label_measure_xsize.Size = new System.Drawing.Size(38, 19);
            this.label_measure_xsize.TabIndex = 10;
            this.label_measure_xsize.Text = "MM.";
            // 
            // textBox_ysize
            // 
            this.textBox_ysize.Font = new System.Drawing.Font("Cambria", 12F);
            this.textBox_ysize.Location = new System.Drawing.Point(149, 109);
            this.textBox_ysize.MaxLength = 14;
            this.textBox_ysize.Name = "textBox_ysize";
            this.textBox_ysize.Size = new System.Drawing.Size(92, 26);
            this.textBox_ysize.TabIndex = 1;
            this.textBox_ysize.TextChanged += new System.EventHandler(this.textBox_ysize_TextChanged);
            // 
            // label_measure_ysize
            // 
            this.label_measure_ysize.AutoSize = true;
            this.label_measure_ysize.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_measure_ysize.Location = new System.Drawing.Point(247, 112);
            this.label_measure_ysize.Name = "label_measure_ysize";
            this.label_measure_ysize.Size = new System.Drawing.Size(38, 19);
            this.label_measure_ysize.TabIndex = 9;
            this.label_measure_ysize.Text = "MM.";
            // 
            // label_maxx
            // 
            this.label_maxx.AutoSize = true;
            this.label_maxx.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_maxx.Location = new System.Drawing.Point(307, 79);
            this.label_maxx.Name = "label_maxx";
            this.label_maxx.Size = new System.Drawing.Size(110, 19);
            this.label_maxx.TabIndex = 8;
            this.label_maxx.Text = "????????.: 297mm";
            // 
            // label_maxy
            // 
            this.label_maxy.AutoSize = true;
            this.label_maxy.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_maxy.Location = new System.Drawing.Point(307, 111);
            this.label_maxy.Name = "label_maxy";
            this.label_maxy.Size = new System.Drawing.Size(110, 19);
            this.label_maxy.TabIndex = 7;
            this.label_maxy.Text = "????????.: 210mm";
            // 
            // label_ysize
            // 
            this.label_ysize.AutoSize = true;
            this.label_ysize.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_ysize.Location = new System.Drawing.Point(72, 112);
            this.label_ysize.Name = "label_ysize";
            this.label_ysize.Size = new System.Drawing.Size(67, 19);
            this.label_ysize.TabIndex = 5;
            this.label_ysize.Text = "????????????:";
            // 
            // label_xsize
            // 
            this.label_xsize.AutoSize = true;
            this.label_xsize.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_xsize.Location = new System.Drawing.Point(69, 79);
            this.label_xsize.Name = "label_xsize";
            this.label_xsize.Size = new System.Drawing.Size(72, 19);
            this.label_xsize.TabIndex = 4;
            this.label_xsize.Text = "????????????:";
            // 
            // radioButton_ysize
            // 
            this.radioButton_ysize.AutoSize = true;
            this.radioButton_ysize.Font = new System.Drawing.Font("Cambria", 12F);
            this.radioButton_ysize.Location = new System.Drawing.Point(260, 30);
            this.radioButton_ysize.Name = "radioButton_ysize";
            this.radioButton_ysize.Size = new System.Drawing.Size(133, 23);
            this.radioButton_ysize.TabIndex = 3;
            this.radioButton_ysize.TabStop = true;
            this.radioButton_ysize.Text = "???????????? ????????????";
            this.radioButton_ysize.UseVisualStyleBackColor = true;
            // 
            // radioButton_xsize
            // 
            this.radioButton_xsize.AutoSize = true;
            this.radioButton_xsize.Font = new System.Drawing.Font("Cambria", 12F);
            this.radioButton_xsize.Location = new System.Drawing.Point(103, 30);
            this.radioButton_xsize.Name = "radioButton_xsize";
            this.radioButton_xsize.Size = new System.Drawing.Size(138, 23);
            this.radioButton_xsize.TabIndex = 2;
            this.radioButton_xsize.TabStop = true;
            this.radioButton_xsize.Text = "???????????? ????????????";
            this.radioButton_xsize.UseVisualStyleBackColor = true;
            this.radioButton_xsize.CheckedChanged += new System.EventHandler(this.radioButton_xsize_CheckedChanged);
            // 
            // button_tab3_next
            // 
            this.button_tab3_next.BackColor = System.Drawing.Color.White;
            this.button_tab3_next.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab3_next.FlatAppearance.BorderSize = 2;
            this.button_tab3_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab3_next.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab3_next.Location = new System.Drawing.Point(440, 407);
            this.button_tab3_next.Name = "button_tab3_next";
            this.button_tab3_next.Size = new System.Drawing.Size(78, 31);
            this.button_tab3_next.TabIndex = 41;
            this.button_tab3_next.Text = "??????????";
            this.button_tab3_next.UseVisualStyleBackColor = false;
            this.button_tab3_next.Click += new System.EventHandler(this.button_tab3_next_Click);
            // 
            // tabPage_print
            // 
            this.tabPage_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_print.Controls.Add(this.label_percentage);
            this.tabPage_print.Controls.Add(this.label_progress);
            this.tabPage_print.Controls.Add(this.label_speed);
            this.tabPage_print.Controls.Add(this.label_leftTime);
            this.tabPage_print.Controls.Add(this.label_spendTme);
            this.tabPage_print.Controls.Add(this.button_abort);
            this.tabPage_print.Controls.Add(this.button_pause);
            this.tabPage_print.Controls.Add(this.progressBar1);
            this.tabPage_print.Location = new System.Drawing.Point(4, 31);
            this.tabPage_print.Name = "tabPage_print";
            this.tabPage_print.Size = new System.Drawing.Size(531, 444);
            this.tabPage_print.TabIndex = 6;
            this.tabPage_print.Text = "tabPage_setSize";
            // 
            // label_percentage
            // 
            this.label_percentage.AutoSize = true;
            this.label_percentage.Location = new System.Drawing.Point(12, 378);
            this.label_percentage.Name = "label_percentage";
            this.label_percentage.Size = new System.Drawing.Size(13, 19);
            this.label_percentage.TabIndex = 7;
            this.label_percentage.Text = " ";
            this.label_percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(12, 308);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(13, 19);
            this.label_progress.TabIndex = 6;
            this.label_progress.Text = " ";
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Location = new System.Drawing.Point(12, 37);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(13, 19);
            this.label_speed.TabIndex = 5;
            this.label_speed.Text = " ";
            // 
            // label_leftTime
            // 
            this.label_leftTime.AutoSize = true;
            this.label_leftTime.Location = new System.Drawing.Point(12, 69);
            this.label_leftTime.Name = "label_leftTime";
            this.label_leftTime.Size = new System.Drawing.Size(13, 19);
            this.label_leftTime.TabIndex = 4;
            this.label_leftTime.Text = " ";
            // 
            // label_spendTme
            // 
            this.label_spendTme.AutoSize = true;
            this.label_spendTme.Location = new System.Drawing.Point(12, 8);
            this.label_spendTme.Name = "label_spendTme";
            this.label_spendTme.Size = new System.Drawing.Size(13, 19);
            this.label_spendTme.TabIndex = 3;
            this.label_spendTme.Text = " ";
            // 
            // button_abort
            // 
            this.button_abort.BackColor = System.Drawing.Color.White;
            this.button_abort.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_abort.FlatAppearance.BorderSize = 2;
            this.button_abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_abort.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_abort.Location = new System.Drawing.Point(258, 381);
            this.button_abort.Name = "button_abort";
            this.button_abort.Size = new System.Drawing.Size(130, 52);
            this.button_abort.TabIndex = 2;
            this.button_abort.Text = "???????????????? ????????????";
            this.button_abort.UseVisualStyleBackColor = false;
            this.button_abort.Click += new System.EventHandler(this.button_abort_Click);
            // 
            // button_pause
            // 
            this.button_pause.BackColor = System.Drawing.Color.White;
            this.button_pause.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_pause.FlatAppearance.BorderSize = 2;
            this.button_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pause.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_pause.Location = new System.Drawing.Point(394, 381);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(123, 52);
            this.button_pause.TabIndex = 1;
            this.button_pause.Text = "??????????";
            this.button_pause.UseVisualStyleBackColor = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 330);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(501, 45);
            this.progressBar1.TabIndex = 0;
            // 
            // tabPage_end
            // 
            this.tabPage_end.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_end.Controls.Add(this.label2);
            this.tabPage_end.Controls.Add(this.label3);
            this.tabPage_end.Controls.Add(this.button_tab5_exit);
            this.tabPage_end.Location = new System.Drawing.Point(4, 31);
            this.tabPage_end.Name = "tabPage_end";
            this.tabPage_end.Size = new System.Drawing.Size(531, 444);
            this.tabPage_end.TabIndex = 8;
            this.tabPage_end.Text = "tabPage_end";
            // 
            // button_tab5_exit
            // 
            this.button_tab5_exit.BackColor = System.Drawing.Color.White;
            this.button_tab5_exit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_tab5_exit.FlatAppearance.BorderSize = 2;
            this.button_tab5_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tab5_exit.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tab5_exit.Location = new System.Drawing.Point(440, 407);
            this.button_tab5_exit.Name = "button_tab5_exit";
            this.button_tab5_exit.Size = new System.Drawing.Size(78, 31);
            this.button_tab5_exit.TabIndex = 39;
            this.button_tab5_exit.Text = "??????????";
            this.button_tab5_exit.UseVisualStyleBackColor = false;
            this.button_tab5_exit.Click += new System.EventHandler(this.button_tab1_exit_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(26, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 63);
            this.label1.TabIndex = 40;
            this.label1.Text = "?????? ?????????????????????? ???????????? ???????????????????? ?????????????????????? ?? ????????????????????. ???????????????? ?????? ?????????? ?? " +
    "???????????????? ???????????????????? ?? ?????????? ??????????????????????.\r\n";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(26, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 45);
            this.label2.TabIndex = 41;
            this.label2.Text = "???? ???????????? ?????????????? ???????????? ????????????.\r\n";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 41);
            this.label3.TabIndex = 40;
            this.label3.Text = "???????????? ??????????????????\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_PrintMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(694, 446);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.label_5);
            this.Controls.Add(this.label_title_2);
            this.Controls.Add(this.label_4);
            this.Controls.Add(this.label_3);
            this.Controls.Add(this.label_2);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_PrintMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "???????????? ????????????";
            this.Load += new System.EventHandler(this.Form_PrintMaster_Load);
            this.tabPage_main.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_pickVect.ResumeLayout(false);
            this.tabPage_pickVect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
            this.tabPage_opts.ResumeLayout(false);
            this.groupBox_pens.ResumeLayout(false);
            this.groupBox_pens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_color)).EndInit();
            this.groupBox_size.ResumeLayout(false);
            this.groupBox_size.PerformLayout();
            this.tabPage_print.ResumeLayout(false);
            this.tabPage_print.PerformLayout();
            this.tabPage_end.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.Label label_3;
        private System.Windows.Forms.Label label_4;
        private System.Windows.Forms.Label label_title_2;
        private System.Windows.Forms.Label label_5;
        private System.Windows.Forms.Button button_help;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_bd;
        private System.Windows.Forms.Label label_com;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.ComboBox comboBox_bdrate;
        private System.Windows.Forms.ComboBox comboBox_com;
        private System.Windows.Forms.Button button_tab1_exit;
        private System.Windows.Forms.Button button_tab1_next;
        private System.Windows.Forms.Label label_discr;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_pickVect;
        private System.Windows.Forms.TabPage tabPage_print;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.ListBox listBox_fileList;
        private System.Windows.Forms.PictureBox pictureBox_preview;
        private MRG.Controls.UI.LoadingCircle loadingCircle_previewLoad;
        private System.Windows.Forms.Button button_tab2_back;
        private System.Windows.Forms.Button button_tab2_next;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Label label_resol;
        private System.Windows.Forms.TabPage tabPage_opts;
        private System.Windows.Forms.Button button_tab3_back;
        private System.Windows.Forms.Button button_tab3_next;
        private System.Windows.Forms.GroupBox groupBox_size;
        private System.Windows.Forms.TextBox textBox_xsize;
        private System.Windows.Forms.Label label_measure_xsize;
        private System.Windows.Forms.TextBox textBox_ysize;
        private System.Windows.Forms.Label label_measure_ysize;
        private System.Windows.Forms.Label label_maxx;
        private System.Windows.Forms.Label label_maxy;
        private System.Windows.Forms.Label label_ysize;
        private System.Windows.Forms.Label label_xsize;
        private System.Windows.Forms.RadioButton radioButton_ysize;
        private System.Windows.Forms.RadioButton radioButton_xsize;
        private System.Windows.Forms.GroupBox groupBox_pens;
        private System.Windows.Forms.ComboBox comboBox_pens;
        private System.Windows.Forms.TextBox textBox_elev_corr;
        private System.Windows.Forms.Label label_elev_corr_1;
        private System.Windows.Forms.Label label_elev_corr;
        private System.Windows.Forms.TextBox textBox_elev_delta;
        private System.Windows.Forms.Label label_elev_delta_1;
        private System.Windows.Forms.Label label_elev_delta;
        private System.Windows.Forms.Label label_color;
        private System.Windows.Forms.PictureBox pictureBox_color;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.Label label_leftTime;
        private System.Windows.Forms.Label label_spendTme;
        private System.Windows.Forms.Button button_abort;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_deviceInfo;
        private System.Windows.Forms.Label label_percentage;
        private System.Windows.Forms.TabPage tabPage_end;
        private System.Windows.Forms.Button button_tab5_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
