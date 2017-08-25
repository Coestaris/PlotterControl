/*=================================\
* PlotterControl\Form_Dialog_VectorEdit.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 25.08.2017 22:17:30
*=================================*/

using CWA_Resources;
using CWA_Resources.Properties;

namespace CnC_WFA
{
    partial class Form_Dialog_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dialog_Edit));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel_rotc = new System.Windows.Forms.Panel();
            this.label_rotatecenter = new System.Windows.Forms.Label();
            this.comboBox_rotatecenter = new System.Windows.Forms.ComboBox();
            this.label_angle = new System.Windows.Forms.Label();
            this.textBox_anglec = new System.Windows.Forms.TextBox();
            this.button_rotc_cancel = new System.Windows.Forms.Button();
            this.button_rotc_ok = new System.Windows.Forms.Button();
            this.panel_sdelete = new System.Windows.Forms.Panel();
            this.label_sd_threshold = new System.Windows.Forms.Label();
            this.textBox_sd_threshold = new System.Windows.Forms.TextBox();
            this.button_sd_cancel = new System.Windows.Forms.Button();
            this.button_sd_ok = new System.Windows.Forms.Button();
            this.panel_rotatec = new System.Windows.Forms.Panel();
            this.radioButton_270deg = new System.Windows.Forms.RadioButton();
            this.radioButton_180deg = new System.Windows.Forms.RadioButton();
            this.radioButton_90deg = new System.Windows.Forms.RadioButton();
            this.button_rot_cancel = new System.Windows.Forms.Button();
            this.button_rot_ok = new System.Windows.Forms.Button();
            this.panel_resize = new System.Windows.Forms.Panel();
            this.textBox_newwith = new System.Windows.Forms.TextBox();
            this.label_newwidth = new System.Windows.Forms.Label();
            this.label_newheight = new System.Windows.Forms.Label();
            this.textBox_newheight = new System.Windows.Forms.TextBox();
            this.checkBox_keepratio = new System.Windows.Forms.CheckBox();
            this.button_resize_cansel = new System.Windows.Forms.Button();
            this.button_resize_ok = new System.Windows.Forms.Button();
            this.panel_flip = new System.Windows.Forms.Panel();
            this.button_flip_cancel = new System.Windows.Forms.Button();
            this.button_flip_ok = new System.Windows.Forms.Button();
            this.radioButton_yflip = new System.Windows.Forms.RadioButton();
            this.radioButton_xflip = new System.Windows.Forms.RadioButton();
            this.loadingCircle2 = new MRG.Controls.UI.LoadingCircle();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_ndresol = new System.Windows.Forms.Label();
            this.label_2ndname = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_move = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_merge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_flip = new System.Windows.Forms.Button();
            this.button_rotate = new System.Windows.Forms.Button();
            this.button_resize = new System.Windows.Forms.Button();
            this.button_rotatec = new System.Windows.Forms.Button();
            this.button_smdelete = new System.Windows.Forms.Button();
            this.button_vectinfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_openvector = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.treeView_pointsex = new System.Windows.Forms.TreeView();
            this.treeView_points = new System.Windows.Forms.TreeView();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_proceed = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_rotc.SuspendLayout();
            this.panel_sdelete.SuspendLayout();
            this.panel_rotatec.SuspendLayout();
            this.panel_resize.SuspendLayout();
            this.panel_flip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(887, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage1.Controls.Add(this.panel_rotc);
            this.tabPage1.Controls.Add(this.panel_sdelete);
            this.tabPage1.Controls.Add(this.panel_rotatec);
            this.tabPage1.Controls.Add(this.panel_resize);
            this.tabPage1.Controls.Add(this.panel_flip);
            this.tabPage1.Controls.Add(this.loadingCircle2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label_ndresol);
            this.tabPage1.Controls.Add(this.label_2ndname);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.loadingCircle1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button_vectinfo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button_openvector);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.treeView_pointsex);
            this.tabPage1.Controls.Add(this.treeView_points);
            this.tabPage1.Controls.Add(this.button_cancel);
            this.tabPage1.Controls.Add(this.button_ok);
            this.tabPage1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(879, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // panel_rotc
            // 
            this.panel_rotc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(218)))), ((int)(((byte)(235)))));
            this.panel_rotc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_rotc.Controls.Add(this.label_rotatecenter);
            this.panel_rotc.Controls.Add(this.comboBox_rotatecenter);
            this.panel_rotc.Controls.Add(this.label_angle);
            this.panel_rotc.Controls.Add(this.textBox_anglec);
            this.panel_rotc.Controls.Add(this.button_rotc_cancel);
            this.panel_rotc.Controls.Add(this.button_rotc_ok);
            this.panel_rotc.Location = new System.Drawing.Point(30, 131);
            this.panel_rotc.Name = "panel_rotc";
            this.panel_rotc.Size = new System.Drawing.Size(158, 134);
            this.panel_rotc.TabIndex = 44;
            this.panel_rotc.Visible = false;
            // 
            // label_rotatecenter
            // 
            this.label_rotatecenter.AutoSize = true;
            this.label_rotatecenter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_rotatecenter.Location = new System.Drawing.Point(4, 41);
            this.label_rotatecenter.Name = "label_rotatecenter";
            this.label_rotatecenter.Size = new System.Drawing.Size(100, 17);
            this.label_rotatecenter.TabIndex = 11;
            this.label_rotatecenter.Text = "Rotate Center: ";
            // 
            // comboBox_rotatecenter
            // 
            this.comboBox_rotatecenter.BackColor = System.Drawing.Color.White;
            this.comboBox_rotatecenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rotatecenter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_rotatecenter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox_rotatecenter.FormattingEnabled = true;
            this.comboBox_rotatecenter.Items.AddRange(new object[] {
            "Center",
            "Left Top Corner",
            "Left Bottom Corner",
            "Right Top Corner",
            "Right Bottom  Corner"});
            this.comboBox_rotatecenter.Location = new System.Drawing.Point(15, 61);
            this.comboBox_rotatecenter.Name = "comboBox_rotatecenter";
            this.comboBox_rotatecenter.Size = new System.Drawing.Size(118, 25);
            this.comboBox_rotatecenter.TabIndex = 10;
            this.comboBox_rotatecenter.SelectedIndexChanged += new System.EventHandler(this.comboBox_rotatecenter_SelectedIndexChanged);
            // 
            // label_angle
            // 
            this.label_angle.AutoSize = true;
            this.label_angle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_angle.Location = new System.Drawing.Point(4, 12);
            this.label_angle.Name = "label_angle";
            this.label_angle.Size = new System.Drawing.Size(50, 17);
            this.label_angle.TabIndex = 9;
            this.label_angle.Text = "Angle: ";
            // 
            // textBox_anglec
            // 
            this.textBox_anglec.BackColor = System.Drawing.Color.White;
            this.textBox_anglec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox_anglec.Location = new System.Drawing.Point(65, 8);
            this.textBox_anglec.Name = "textBox_anglec";
            this.textBox_anglec.Size = new System.Drawing.Size(60, 25);
            this.textBox_anglec.TabIndex = 9;
            // 
            // button_rotc_cancel
            // 
            this.button_rotc_cancel.BackColor = System.Drawing.Color.White;
            this.button_rotc_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_rotc_cancel.FlatAppearance.BorderSize = 2;
            this.button_rotc_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rotc_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_rotc_cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_rotc_cancel.Image")));
            this.button_rotc_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rotc_cancel.Location = new System.Drawing.Point(13, 95);
            this.button_rotc_cancel.Name = "button_rotc_cancel";
            this.button_rotc_cancel.Size = new System.Drawing.Size(79, 33);
            this.button_rotc_cancel.TabIndex = 3;
            this.button_rotc_cancel.Text = "Cancel";
            this.button_rotc_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_rotc_cancel.UseVisualStyleBackColor = false;
            // 
            // button_rotc_ok
            // 
            this.button_rotc_ok.BackColor = System.Drawing.Color.White;
            this.button_rotc_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_rotc_ok.FlatAppearance.BorderSize = 2;
            this.button_rotc_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rotc_ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_rotc_ok.Image = ((System.Drawing.Image)(resources.GetObject("button_rotc_ok.Image")));
            this.button_rotc_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rotc_ok.Location = new System.Drawing.Point(95, 96);
            this.button_rotc_ok.Name = "button_rotc_ok";
            this.button_rotc_ok.Size = new System.Drawing.Size(57, 33);
            this.button_rotc_ok.TabIndex = 2;
            this.button_rotc_ok.Text = "Ok";
            this.button_rotc_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_rotc_ok.UseVisualStyleBackColor = false;
            // 
            // panel_sdelete
            // 
            this.panel_sdelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(218)))), ((int)(((byte)(235)))));
            this.panel_sdelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_sdelete.Controls.Add(this.label_sd_threshold);
            this.panel_sdelete.Controls.Add(this.textBox_sd_threshold);
            this.panel_sdelete.Controls.Add(this.button_sd_cancel);
            this.panel_sdelete.Controls.Add(this.button_sd_ok);
            this.panel_sdelete.Location = new System.Drawing.Point(719, 197);
            this.panel_sdelete.Name = "panel_sdelete";
            this.panel_sdelete.Size = new System.Drawing.Size(153, 96);
            this.panel_sdelete.TabIndex = 43;
            this.panel_sdelete.Visible = false;
            // 
            // label_sd_threshold
            // 
            this.label_sd_threshold.AutoSize = true;
            this.label_sd_threshold.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_sd_threshold.Location = new System.Drawing.Point(4, 3);
            this.label_sd_threshold.Name = "label_sd_threshold";
            this.label_sd_threshold.Size = new System.Drawing.Size(122, 17);
            this.label_sd_threshold.TabIndex = 9;
            this.label_sd_threshold.Text = "Delete Threshold: ";
            // 
            // textBox_sd_threshold
            // 
            this.textBox_sd_threshold.BackColor = System.Drawing.Color.White;
            this.textBox_sd_threshold.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox_sd_threshold.Location = new System.Drawing.Point(11, 24);
            this.textBox_sd_threshold.Name = "textBox_sd_threshold";
            this.textBox_sd_threshold.Size = new System.Drawing.Size(100, 25);
            this.textBox_sd_threshold.TabIndex = 9;
            this.textBox_sd_threshold.Text = "0";
            // 
            // button_sd_cancel
            // 
            this.button_sd_cancel.BackColor = System.Drawing.Color.White;
            this.button_sd_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_sd_cancel.FlatAppearance.BorderSize = 2;
            this.button_sd_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sd_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_sd_cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_sd_cancel.Image")));
            this.button_sd_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_sd_cancel.Location = new System.Drawing.Point(8, 58);
            this.button_sd_cancel.Name = "button_sd_cancel";
            this.button_sd_cancel.Size = new System.Drawing.Size(79, 33);
            this.button_sd_cancel.TabIndex = 3;
            this.button_sd_cancel.Text = "Cancel";
            this.button_sd_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_sd_cancel.UseVisualStyleBackColor = false;
            this.button_sd_cancel.Click += new System.EventHandler(this.button_sd_cancel_Click);
            // 
            // button_sd_ok
            // 
            this.button_sd_ok.BackColor = System.Drawing.Color.White;
            this.button_sd_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_sd_ok.FlatAppearance.BorderSize = 2;
            this.button_sd_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sd_ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_sd_ok.Image = ((System.Drawing.Image)(resources.GetObject("button_sd_ok.Image")));
            this.button_sd_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_sd_ok.Location = new System.Drawing.Point(91, 58);
            this.button_sd_ok.Name = "button_sd_ok";
            this.button_sd_ok.Size = new System.Drawing.Size(57, 33);
            this.button_sd_ok.TabIndex = 2;
            this.button_sd_ok.Text = "Ok";
            this.button_sd_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_sd_ok.UseVisualStyleBackColor = false;
            this.button_sd_ok.Click += new System.EventHandler(this.button_sd_ok_Click);
            // 
            // panel_rotatec
            // 
            this.panel_rotatec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(218)))), ((int)(((byte)(235)))));
            this.panel_rotatec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_rotatec.Controls.Add(this.radioButton_270deg);
            this.panel_rotatec.Controls.Add(this.radioButton_180deg);
            this.panel_rotatec.Controls.Add(this.radioButton_90deg);
            this.panel_rotatec.Controls.Add(this.button_rot_cancel);
            this.panel_rotatec.Controls.Add(this.button_rot_ok);
            this.panel_rotatec.Location = new System.Drawing.Point(535, 151);
            this.panel_rotatec.Name = "panel_rotatec";
            this.panel_rotatec.Size = new System.Drawing.Size(171, 123);
            this.panel_rotatec.TabIndex = 42;
            this.panel_rotatec.Visible = false;
            // 
            // radioButton_270deg
            // 
            this.radioButton_270deg.AutoSize = true;
            this.radioButton_270deg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton_270deg.Location = new System.Drawing.Point(4, 52);
            this.radioButton_270deg.Name = "radioButton_270deg";
            this.radioButton_270deg.Size = new System.Drawing.Size(138, 21);
            this.radioButton_270deg.TabIndex = 6;
            this.radioButton_270deg.TabStop = true;
            this.radioButton_270deg.Text = "Rotate by 270 deg";
            this.radioButton_270deg.UseVisualStyleBackColor = true;
            // 
            // radioButton_180deg
            // 
            this.radioButton_180deg.AutoSize = true;
            this.radioButton_180deg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton_180deg.Location = new System.Drawing.Point(4, 29);
            this.radioButton_180deg.Name = "radioButton_180deg";
            this.radioButton_180deg.Size = new System.Drawing.Size(138, 21);
            this.radioButton_180deg.TabIndex = 5;
            this.radioButton_180deg.TabStop = true;
            this.radioButton_180deg.Text = "Rotate by 180 deg";
            this.radioButton_180deg.UseVisualStyleBackColor = true;
            // 
            // radioButton_90deg
            // 
            this.radioButton_90deg.AutoSize = true;
            this.radioButton_90deg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton_90deg.Location = new System.Drawing.Point(4, 6);
            this.radioButton_90deg.Name = "radioButton_90deg";
            this.radioButton_90deg.Size = new System.Drawing.Size(130, 21);
            this.radioButton_90deg.TabIndex = 4;
            this.radioButton_90deg.TabStop = true;
            this.radioButton_90deg.Text = "Rotate by 90 deg";
            this.radioButton_90deg.UseVisualStyleBackColor = true;
            // 
            // button_rot_cancel
            // 
            this.button_rot_cancel.BackColor = System.Drawing.Color.White;
            this.button_rot_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_rot_cancel.FlatAppearance.BorderSize = 2;
            this.button_rot_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rot_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_rot_cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_rot_cancel.Image")));
            this.button_rot_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rot_cancel.Location = new System.Drawing.Point(24, 85);
            this.button_rot_cancel.Name = "button_rot_cancel";
            this.button_rot_cancel.Size = new System.Drawing.Size(79, 33);
            this.button_rot_cancel.TabIndex = 3;
            this.button_rot_cancel.Text = "Cancel";
            this.button_rot_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_rot_cancel.UseVisualStyleBackColor = false;
            // 
            // button_rot_ok
            // 
            this.button_rot_ok.BackColor = System.Drawing.Color.White;
            this.button_rot_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_rot_ok.FlatAppearance.BorderSize = 2;
            this.button_rot_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rot_ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_rot_ok.Image = ((System.Drawing.Image)(resources.GetObject("button_rot_ok.Image")));
            this.button_rot_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rot_ok.Location = new System.Drawing.Point(109, 85);
            this.button_rot_ok.Name = "button_rot_ok";
            this.button_rot_ok.Size = new System.Drawing.Size(57, 33);
            this.button_rot_ok.TabIndex = 2;
            this.button_rot_ok.Text = "Ok";
            this.button_rot_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_rot_ok.UseVisualStyleBackColor = false;
            // 
            // panel_resize
            // 
            this.panel_resize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(218)))), ((int)(((byte)(235)))));
            this.panel_resize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_resize.Controls.Add(this.textBox_newwith);
            this.panel_resize.Controls.Add(this.label_newwidth);
            this.panel_resize.Controls.Add(this.label_newheight);
            this.panel_resize.Controls.Add(this.textBox_newheight);
            this.panel_resize.Controls.Add(this.checkBox_keepratio);
            this.panel_resize.Controls.Add(this.button_resize_cansel);
            this.panel_resize.Controls.Add(this.button_resize_ok);
            this.panel_resize.Location = new System.Drawing.Point(712, 33);
            this.panel_resize.Name = "panel_resize";
            this.panel_resize.Size = new System.Drawing.Size(160, 158);
            this.panel_resize.TabIndex = 41;
            this.panel_resize.Visible = false;
            // 
            // textBox_newwith
            // 
            this.textBox_newwith.BackColor = System.Drawing.Color.White;
            this.textBox_newwith.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox_newwith.Location = new System.Drawing.Point(21, 45);
            this.textBox_newwith.Name = "textBox_newwith";
            this.textBox_newwith.Size = new System.Drawing.Size(100, 25);
            this.textBox_newwith.TabIndex = 5;
            // 
            // label_newwidth
            // 
            this.label_newwidth.AutoSize = true;
            this.label_newwidth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_newwidth.Location = new System.Drawing.Point(3, 24);
            this.label_newwidth.Name = "label_newwidth";
            this.label_newwidth.Size = new System.Drawing.Size(84, 17);
            this.label_newwidth.TabIndex = 8;
            this.label_newwidth.Text = "New width: ";
            // 
            // label_newheight
            // 
            this.label_newheight.AutoSize = true;
            this.label_newheight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_newheight.Location = new System.Drawing.Point(3, 69);
            this.label_newheight.Name = "label_newheight";
            this.label_newheight.Size = new System.Drawing.Size(86, 17);
            this.label_newheight.TabIndex = 7;
            this.label_newheight.Text = "New height: ";
            // 
            // textBox_newheight
            // 
            this.textBox_newheight.BackColor = System.Drawing.Color.White;
            this.textBox_newheight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox_newheight.Location = new System.Drawing.Point(21, 90);
            this.textBox_newheight.Name = "textBox_newheight";
            this.textBox_newheight.Size = new System.Drawing.Size(100, 25);
            this.textBox_newheight.TabIndex = 6;
            // 
            // checkBox_keepratio
            // 
            this.checkBox_keepratio.AutoSize = true;
            this.checkBox_keepratio.Checked = true;
            this.checkBox_keepratio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_keepratio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_keepratio.Location = new System.Drawing.Point(6, 7);
            this.checkBox_keepratio.Name = "checkBox_keepratio";
            this.checkBox_keepratio.Size = new System.Drawing.Size(139, 21);
            this.checkBox_keepratio.TabIndex = 4;
            this.checkBox_keepratio.Text = "Keep Aspect Ratio";
            this.checkBox_keepratio.UseVisualStyleBackColor = true;
            // 
            // button_resize_cansel
            // 
            this.button_resize_cansel.BackColor = System.Drawing.Color.White;
            this.button_resize_cansel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_resize_cansel.FlatAppearance.BorderSize = 2;
            this.button_resize_cansel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_resize_cansel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_resize_cansel.Image = ((System.Drawing.Image)(resources.GetObject("button_resize_cansel.Image")));
            this.button_resize_cansel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_resize_cansel.Location = new System.Drawing.Point(15, 119);
            this.button_resize_cansel.Name = "button_resize_cansel";
            this.button_resize_cansel.Size = new System.Drawing.Size(79, 33);
            this.button_resize_cansel.TabIndex = 3;
            this.button_resize_cansel.Text = "Cancel";
            this.button_resize_cansel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_resize_cansel.UseVisualStyleBackColor = false;
            this.button_resize_cansel.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_resize_ok
            // 
            this.button_resize_ok.BackColor = System.Drawing.Color.White;
            this.button_resize_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_resize_ok.FlatAppearance.BorderSize = 2;
            this.button_resize_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_resize_ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_resize_ok.Image = ((System.Drawing.Image)(resources.GetObject("button_resize_ok.Image")));
            this.button_resize_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_resize_ok.Location = new System.Drawing.Point(98, 119);
            this.button_resize_ok.Name = "button_resize_ok";
            this.button_resize_ok.Size = new System.Drawing.Size(57, 33);
            this.button_resize_ok.TabIndex = 2;
            this.button_resize_ok.Text = "Ok";
            this.button_resize_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_resize_ok.UseVisualStyleBackColor = false;
            this.button_resize_ok.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel_flip
            // 
            this.panel_flip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(218)))), ((int)(((byte)(235)))));
            this.panel_flip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_flip.Controls.Add(this.button_flip_cancel);
            this.panel_flip.Controls.Add(this.button_flip_ok);
            this.panel_flip.Controls.Add(this.radioButton_yflip);
            this.panel_flip.Controls.Add(this.radioButton_xflip);
            this.panel_flip.Location = new System.Drawing.Point(535, 33);
            this.panel_flip.Name = "panel_flip";
            this.panel_flip.Size = new System.Drawing.Size(153, 107);
            this.panel_flip.TabIndex = 40;
            this.panel_flip.Visible = false;
            // 
            // button_flip_cancel
            // 
            this.button_flip_cancel.BackColor = System.Drawing.Color.White;
            this.button_flip_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_flip_cancel.FlatAppearance.BorderSize = 2;
            this.button_flip_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_flip_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_flip_cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_flip_cancel.Image")));
            this.button_flip_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_flip_cancel.Location = new System.Drawing.Point(4, 69);
            this.button_flip_cancel.Name = "button_flip_cancel";
            this.button_flip_cancel.Size = new System.Drawing.Size(79, 33);
            this.button_flip_cancel.TabIndex = 3;
            this.button_flip_cancel.Text = "Cancel";
            this.button_flip_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_flip_cancel.UseVisualStyleBackColor = false;
            this.button_flip_cancel.Click += new System.EventHandler(this.button_flip_cancel_Click);
            // 
            // button_flip_ok
            // 
            this.button_flip_ok.BackColor = System.Drawing.Color.White;
            this.button_flip_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_flip_ok.FlatAppearance.BorderSize = 2;
            this.button_flip_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_flip_ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_flip_ok.Image = ((System.Drawing.Image)(resources.GetObject("button_flip_ok.Image")));
            this.button_flip_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_flip_ok.Location = new System.Drawing.Point(89, 69);
            this.button_flip_ok.Name = "button_flip_ok";
            this.button_flip_ok.Size = new System.Drawing.Size(57, 33);
            this.button_flip_ok.TabIndex = 2;
            this.button_flip_ok.Text = "Ok";
            this.button_flip_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_flip_ok.UseVisualStyleBackColor = false;
            this.button_flip_ok.Click += new System.EventHandler(this.button_flip_ok_Click);
            // 
            // radioButton_yflip
            // 
            this.radioButton_yflip.AutoSize = true;
            this.radioButton_yflip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton_yflip.Location = new System.Drawing.Point(3, 32);
            this.radioButton_yflip.Name = "radioButton_yflip";
            this.radioButton_yflip.Size = new System.Drawing.Size(62, 21);
            this.radioButton_yflip.TabIndex = 1;
            this.radioButton_yflip.TabStop = true;
            this.radioButton_yflip.Text = "Y Flip";
            this.radioButton_yflip.UseVisualStyleBackColor = true;
            // 
            // radioButton_xflip
            // 
            this.radioButton_xflip.AutoSize = true;
            this.radioButton_xflip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton_xflip.Location = new System.Drawing.Point(3, 9);
            this.radioButton_xflip.Name = "radioButton_xflip";
            this.radioButton_xflip.Size = new System.Drawing.Size(62, 21);
            this.radioButton_xflip.TabIndex = 0;
            this.radioButton_xflip.TabStop = true;
            this.radioButton_xflip.Text = "X Flip";
            this.radioButton_xflip.UseVisualStyleBackColor = true;
            // 
            // loadingCircle2
            // 
            this.loadingCircle2.Active = false;
            this.loadingCircle2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle2.BackgroundImage")));
            this.loadingCircle2.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle2.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle2.InnerCircleRadius = 5;
            this.loadingCircle2.Location = new System.Drawing.Point(165, 50);
            this.loadingCircle2.Name = "loadingCircle2";
            this.loadingCircle2.NumberSpoke = 12;
            this.loadingCircle2.OuterCircleRadius = 11;
            this.loadingCircle2.RotationSpeed = 100;
            this.loadingCircle2.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle2.SpokeThickness = 2;
            this.loadingCircle2.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle2.TabIndex = 39;
            this.loadingCircle2.Text = "loadingCircle2";
            this.loadingCircle2.UseWaitCursor = true;
            this.loadingCircle2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(130, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 29);
            this.button1.TabIndex = 38;
            this.button1.Text = "Prev.";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(743, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "2nd Vect preview";
            // 
            // label_ndresol
            // 
            this.label_ndresol.AutoSize = true;
            this.label_ndresol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_ndresol.Location = new System.Drawing.Point(520, 301);
            this.label_ndresol.Name = "label_ndresol";
            this.label_ndresol.Size = new System.Drawing.Size(82, 17);
            this.label_ndresol.TabIndex = 36;
            this.label_ndresol.Text = "Resolution: ";
            // 
            // label_2ndname
            // 
            this.label_2ndname.AutoSize = true;
            this.label_2ndname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_2ndname.Location = new System.Drawing.Point(520, 282);
            this.label_2ndname.Name = "label_2ndname";
            this.label_2ndname.Size = new System.Drawing.Size(51, 17);
            this.label_2ndname.TabIndex = 35;
            this.label_2ndname.Text = "Name: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(524, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 253);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = false;
            this.loadingCircle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle1.BackgroundImage")));
            this.loadingCircle1.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle1.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle1.InnerCircleRadius = 5;
            this.loadingCircle1.Location = new System.Drawing.Point(275, 101);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 12;
            this.loadingCircle1.OuterCircleRadius = 11;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle1.SpokeThickness = 2;
            this.loadingCircle1.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle1.TabIndex = 33;
            this.loadingCircle1.Text = "loadingCircle2";
            this.loadingCircle1.UseWaitCursor = true;
            this.loadingCircle1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_move);
            this.groupBox2.Controls.Add(this.button_delete);
            this.groupBox2.Controls.Add(this.button_merge);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(6, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 59);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Points";
            // 
            // button_move
            // 
            this.button_move.BackColor = System.Drawing.Color.White;
            this.button_move.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_move.FlatAppearance.BorderSize = 2;
            this.button_move.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_move.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_move.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_move.Location = new System.Drawing.Point(184, 18);
            this.button_move.Name = "button_move";
            this.button_move.Size = new System.Drawing.Size(83, 33);
            this.button_move.TabIndex = 9;
            this.button_move.Text = "Move";
            this.button_move.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_move.UseVisualStyleBackColor = false;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.White;
            this.button_delete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_delete.FlatAppearance.BorderSize = 2;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_delete.Location = new System.Drawing.Point(6, 18);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(83, 33);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "Delete";
            this.button_delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_merge
            // 
            this.button_merge.BackColor = System.Drawing.Color.White;
            this.button_merge.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_merge.FlatAppearance.BorderSize = 2;
            this.button_merge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_merge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_merge.Image = ((System.Drawing.Image)(resources.GetObject("button_merge.Image")));
            this.button_merge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_merge.Location = new System.Drawing.Point(95, 18);
            this.button_merge.Name = "button_merge";
            this.button_merge.Size = new System.Drawing.Size(83, 33);
            this.button_merge.TabIndex = 4;
            this.button_merge.Text = "Merge";
            this.button_merge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_merge.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_flip);
            this.groupBox1.Controls.Add(this.button_rotate);
            this.groupBox1.Controls.Add(this.button_resize);
            this.groupBox1.Controls.Add(this.button_rotatec);
            this.groupBox1.Controls.Add(this.button_smdelete);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(411, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 254);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transform";
            // 
            // button_flip
            // 
            this.button_flip.BackColor = System.Drawing.Color.White;
            this.button_flip.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_flip.FlatAppearance.BorderSize = 2;
            this.button_flip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_flip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_flip.Image = ((System.Drawing.Image)(resources.GetObject("button_flip.Image")));
            this.button_flip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_flip.Location = new System.Drawing.Point(6, 19);
            this.button_flip.Name = "button_flip";
            this.button_flip.Size = new System.Drawing.Size(101, 37);
            this.button_flip.TabIndex = 10;
            this.button_flip.Text = "Flip";
            this.button_flip.UseVisualStyleBackColor = false;
            this.button_flip.Click += new System.EventHandler(this.button_flip_Click);
            // 
            // button_rotate
            // 
            this.button_rotate.BackColor = System.Drawing.Color.White;
            this.button_rotate.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_rotate.FlatAppearance.BorderSize = 2;
            this.button_rotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rotate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_rotate.Image = ((System.Drawing.Image)(resources.GetObject("button_rotate.Image")));
            this.button_rotate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rotate.Location = new System.Drawing.Point(6, 105);
            this.button_rotate.Name = "button_rotate";
            this.button_rotate.Size = new System.Drawing.Size(101, 37);
            this.button_rotate.TabIndex = 11;
            this.button_rotate.Text = "Rotate";
            this.button_rotate.UseVisualStyleBackColor = false;
            // 
            // button_resize
            // 
            this.button_resize.BackColor = System.Drawing.Color.White;
            this.button_resize.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_resize.FlatAppearance.BorderSize = 2;
            this.button_resize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_resize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_resize.Image = ((System.Drawing.Image)(resources.GetObject("button_resize.Image")));
            this.button_resize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_resize.Location = new System.Drawing.Point(6, 62);
            this.button_resize.Name = "button_resize";
            this.button_resize.Size = new System.Drawing.Size(101, 37);
            this.button_resize.TabIndex = 14;
            this.button_resize.Text = "New Size";
            this.button_resize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_resize.UseVisualStyleBackColor = false;
            this.button_resize.Click += new System.EventHandler(this.button_resize_Click);
            // 
            // button_rotatec
            // 
            this.button_rotatec.BackColor = System.Drawing.Color.White;
            this.button_rotatec.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_rotatec.FlatAppearance.BorderSize = 2;
            this.button_rotatec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rotatec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_rotatec.Image = ((System.Drawing.Image)(resources.GetObject("button_rotatec.Image")));
            this.button_rotatec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rotatec.Location = new System.Drawing.Point(6, 210);
            this.button_rotatec.Name = "button_rotatec";
            this.button_rotatec.Size = new System.Drawing.Size(101, 37);
            this.button_rotatec.TabIndex = 12;
            this.button_rotatec.Text = "Rotate C.";
            this.button_rotatec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_rotatec.UseVisualStyleBackColor = false;
            this.button_rotatec.Click += new System.EventHandler(this.button_rotatec_Click);
            // 
            // button_smdelete
            // 
            this.button_smdelete.BackColor = System.Drawing.Color.White;
            this.button_smdelete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_smdelete.FlatAppearance.BorderSize = 2;
            this.button_smdelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_smdelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_smdelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_smdelete.Location = new System.Drawing.Point(6, 152);
            this.button_smdelete.Name = "button_smdelete";
            this.button_smdelete.Size = new System.Drawing.Size(101, 50);
            this.button_smdelete.TabIndex = 13;
            this.button_smdelete.Text = "Smart Delete";
            this.button_smdelete.UseVisualStyleBackColor = false;
            this.button_smdelete.Click += new System.EventHandler(this.button_smdelete_Click);
            // 
            // button_vectinfo
            // 
            this.button_vectinfo.BackColor = System.Drawing.Color.White;
            this.button_vectinfo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_vectinfo.FlatAppearance.BorderSize = 2;
            this.button_vectinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_vectinfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_vectinfo.Image = ((System.Drawing.Image)(resources.GetObject("button_vectinfo.Image")));
            this.button_vectinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_vectinfo.Location = new System.Drawing.Point(293, 278);
            this.button_vectinfo.Name = "button_vectinfo";
            this.button_vectinfo.Size = new System.Drawing.Size(75, 37);
            this.button_vectinfo.TabIndex = 15;
            this.button_vectinfo.Text = "Info";
            this.button_vectinfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_vectinfo.UseVisualStyleBackColor = false;
            this.button_vectinfo.Click += new System.EventHandler(this.button_vectinfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Vector";
            // 
            // button_openvector
            // 
            this.button_openvector.BackColor = System.Drawing.Color.White;
            this.button_openvector.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_openvector.FlatAppearance.BorderSize = 2;
            this.button_openvector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_openvector.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_openvector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_openvector.Location = new System.Drawing.Point(317, 6);
            this.button_openvector.Name = "button_openvector";
            this.button_openvector.Size = new System.Drawing.Size(88, 31);
            this.button_openvector.TabIndex = 7;
            this.button_openvector.Text = "Browse";
            this.button_openvector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_openvector.UseVisualStyleBackColor = false;
            this.button_openvector.Click += new System.EventHandler(this.button_openvector_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Current",
            "Other"});
            this.comboBox1.Location = new System.Drawing.Point(215, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 25);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // treeView_pointsex
            // 
            this.treeView_pointsex.BackColor = System.Drawing.SystemColors.Control;
            this.treeView_pointsex.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_pointsex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.treeView_pointsex.Location = new System.Drawing.Point(215, 43);
            this.treeView_pointsex.Name = "treeView_pointsex";
            this.treeView_pointsex.Size = new System.Drawing.Size(190, 216);
            this.treeView_pointsex.TabIndex = 5;
            this.treeView_pointsex.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_pointsex_AfterSelect);
            // 
            // treeView_points
            // 
            this.treeView_points.BackColor = System.Drawing.SystemColors.Control;
            this.treeView_points.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_points.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.treeView_points.FullRowSelect = true;
            this.treeView_points.Location = new System.Drawing.Point(12, 43);
            this.treeView_points.Name = "treeView_points";
            this.treeView_points.Size = new System.Drawing.Size(190, 216);
            this.treeView_points.TabIndex = 2;
            this.treeView_points.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_points_AfterSelect);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.White;
            this.button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_cancel.FlatAppearance.BorderSize = 2;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_cancel.Image")));
            this.button_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cancel.Location = new System.Drawing.Point(374, 266);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(82, 49);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.BackColor = System.Drawing.Color.White;
            this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_ok.FlatAppearance.BorderSize = 2;
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ok.Location = new System.Drawing.Point(462, 266);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(56, 49);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ok";
            this.button_ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(879, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(879, 325);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Help";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "VectFile.pcv";
            this.openFileDialog1.Filter = "PrRes Files(*.pcv)|*.pcv|PrRes Files(*.prres)|*.prres";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker_proceed
            // 
            this.backgroundWorker_proceed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_proceed_DoWork);
            this.backgroundWorker_proceed.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_proceed_RunWorkerCompleted);
            // 
            // Form_Dialog_Edit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(887, 357);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Cambria", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Dialog_Edit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Dialog_Edit_Load);
            this.MouseEnter += new System.EventHandler(this.Dialog_Edit_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Dialog_Edit_MouseLeave);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel_rotc.ResumeLayout(false);
            this.panel_rotc.PerformLayout();
            this.panel_sdelete.ResumeLayout(false);
            this.panel_sdelete.PerformLayout();
            this.panel_rotatec.ResumeLayout(false);
            this.panel_rotatec.PerformLayout();
            this.panel_resize.ResumeLayout(false);
            this.panel_resize.PerformLayout();
            this.panel_flip.ResumeLayout(false);
            this.panel_flip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.TreeView treeView_points;
        private System.Windows.Forms.Button button_move;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_openvector;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TreeView treeView_pointsex;
        private System.Windows.Forms.Button button_merge;
        private System.Windows.Forms.Button button_resize;
        private System.Windows.Forms.Button button_smdelete;
        private System.Windows.Forms.Button button_rotatec;
        private System.Windows.Forms.Button button_rotate;
        private System.Windows.Forms.Button button_flip;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_vectinfo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        public MRG.Controls.UI.LoadingCircle loadingCircle1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_ndresol;
        private System.Windows.Forms.Label label_2ndname;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        public MRG.Controls.UI.LoadingCircle loadingCircle2;
        private System.ComponentModel.BackgroundWorker backgroundWorker_proceed;
        private System.Windows.Forms.Panel panel_resize;
        private System.Windows.Forms.TextBox textBox_newheight;
        private System.Windows.Forms.TextBox textBox_newwith;
        private System.Windows.Forms.CheckBox checkBox_keepratio;
        private System.Windows.Forms.Button button_resize_cansel;
        private System.Windows.Forms.Button button_resize_ok;
        private System.Windows.Forms.Panel panel_flip;
        private System.Windows.Forms.Button button_flip_cancel;
        private System.Windows.Forms.Button button_flip_ok;
        private System.Windows.Forms.RadioButton radioButton_yflip;
        private System.Windows.Forms.RadioButton radioButton_xflip;
        private System.Windows.Forms.Panel panel_sdelete;
        private System.Windows.Forms.Label label_sd_threshold;
        private System.Windows.Forms.TextBox textBox_sd_threshold;
        private System.Windows.Forms.Button button_sd_cancel;
        private System.Windows.Forms.Button button_sd_ok;
        private System.Windows.Forms.Panel panel_rotatec;
        private System.Windows.Forms.RadioButton radioButton_270deg;
        private System.Windows.Forms.RadioButton radioButton_180deg;
        private System.Windows.Forms.RadioButton radioButton_90deg;
        private System.Windows.Forms.Button button_rot_cancel;
        private System.Windows.Forms.Button button_rot_ok;
        private System.Windows.Forms.Label label_newwidth;
        private System.Windows.Forms.Label label_newheight;
        private System.Windows.Forms.Panel panel_rotc;
        private System.Windows.Forms.Label label_rotatecenter;
        private System.Windows.Forms.ComboBox comboBox_rotatecenter;
        private System.Windows.Forms.Label label_angle;
        private System.Windows.Forms.TextBox textBox_anglec;
        private System.Windows.Forms.Button button_rotc_cancel;
        private System.Windows.Forms.Button button_rotc_ok;
    }
}
