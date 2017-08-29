/*=================================\
* PlotterControl\Form_Dialog_EditElement.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 28.08.2017 23:32:04
*=================================*/

namespace CnC_WFA
{
    partial class Form_Dialog_EditElement
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_docCaption = new System.Windows.Forms.Button();
            this.button_axisCaption = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_axis = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_axis = new System.Windows.Forms.TabPage();
            this.checkBox_axis_show = new System.Windows.Forms.CheckBox();
            this.groupBox_axis_display = new System.Windows.Forms.GroupBox();
            this.label_axis_width = new System.Windows.Forms.Label();
            this.label_axis_color = new System.Windows.Forms.Label();
            this.label_axis_color_info = new System.Windows.Forms.Label();
            this.button_axis_color = new System.Windows.Forms.Button();
            this.pictureBox_axis_color = new System.Windows.Forms.PictureBox();
            this.textBox_axis_width = new System.Windows.Forms.TextBox();
            this.groupBox_axis_param = new System.Windows.Forms.GroupBox();
            this.label_axis_offset_y = new System.Windows.Forms.Label();
            this.label_axis_offset_x = new System.Windows.Forms.Label();
            this.textBox_axis_offset_y = new System.Windows.Forms.TextBox();
            this.textBox_axis_offset_x = new System.Windows.Forms.TextBox();
            this.radioButton_axis_limited = new System.Windows.Forms.RadioButton();
            this.radioButton_axis_unlimited = new System.Windows.Forms.RadioButton();
            this.label_axis_label = new System.Windows.Forms.Label();
            this.tabPage_axisCaption = new System.Windows.Forms.TabPage();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_grid = new System.Windows.Forms.Button();
            this.button_legend = new System.Windows.Forms.Button();
            this.button_addPoints = new System.Windows.Forms.Button();
            this.tabPage_docCaption = new System.Windows.Forms.TabPage();
            this.tabPage_grid = new System.Windows.Forms.TabPage();
            this.tabPage_legend = new System.Windows.Forms.TabPage();
            this.tabPage_addPoints = new System.Windows.Forms.TabPage();
            this.checkBox_axisC_displ = new System.Windows.Forms.CheckBox();
            this.checkBox_docC_displ = new System.Windows.Forms.CheckBox();
            this.checkBox_grid_displ = new System.Windows.Forms.CheckBox();
            this.checkBox_legend_displ = new System.Windows.Forms.CheckBox();
            this.checkBox_addPoints_displ = new System.Windows.Forms.CheckBox();
            this.groupBox_inde = new System.Windows.Forms.GroupBox();
            this.radioButton_independence = new System.Windows.Forms.RadioButton();
            this.radioButton_asMarkeks = new System.Windows.Forms.RadioButton();
            this.label_markers_period_end = new System.Windows.Forms.Label();
            this.label_markers_period_start = new System.Windows.Forms.Label();
            this.label_markers_period = new System.Windows.Forms.Label();
            this.textBox_markers_period_end = new System.Windows.Forms.TextBox();
            this.textBox_markers_period_start = new System.Windows.Forms.TextBox();
            this.checkBox_markers_period = new System.Windows.Forms.CheckBox();
            this.textBox_markers_period = new System.Windows.Forms.TextBox();
            this.button_markers_compile = new System.Windows.Forms.Button();
            this.panel_markers_status = new System.Windows.Forms.Panel();
            this.button_markers_status = new System.Windows.Forms.Button();
            this.label_markers_status = new System.Windows.Forms.Label();
            this.timer_markers_expire = new System.Windows.Forms.Timer(this.components);
            this.textBox_axis_x = new System.Windows.Forms.TextBox();
            this.textBox_axis_y = new System.Windows.Forms.TextBox();
            this.label_axis_x = new System.Windows.Forms.Label();
            this.label_axis_y = new System.Windows.Forms.Label();
            this.checkBox_axis_x = new System.Windows.Forms.CheckBox();
            this.checkBox_axis_y = new System.Windows.Forms.CheckBox();
            this.groupBox_names = new System.Windows.Forms.GroupBox();
            this.groupBox_markers = new System.Windows.Forms.GroupBox();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_axis.SuspendLayout();
            this.groupBox_axis_display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_axis_color)).BeginInit();
            this.groupBox_axis_param.SuspendLayout();
            this.tabPage_axisCaption.SuspendLayout();
            this.tabPage_docCaption.SuspendLayout();
            this.tabPage_grid.SuspendLayout();
            this.tabPage_legend.SuspendLayout();
            this.tabPage_addPoints.SuspendLayout();
            this.groupBox_inde.SuspendLayout();
            this.panel_markers_status.SuspendLayout();
            this.groupBox_names.SuspendLayout();
            this.groupBox_markers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.panel3.Controls.Add(this.button_addPoints);
            this.panel3.Controls.Add(this.button_legend);
            this.panel3.Controls.Add(this.button_grid);
            this.panel3.Controls.Add(this.button_docCaption);
            this.panel3.Controls.Add(this.button_axisCaption);
            this.panel3.Controls.Add(this.button_exit);
            this.panel3.Controls.Add(this.button_axis);
            this.panel3.Location = new System.Drawing.Point(-9, -12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 361);
            this.panel3.TabIndex = 14;
            // 
            // button_docCaption
            // 
            this.button_docCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_docCaption.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_docCaption.FlatAppearance.BorderSize = 2;
            this.button_docCaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_docCaption.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_docCaption.ForeColor = System.Drawing.Color.White;
            this.button_docCaption.Location = new System.Drawing.Point(18, 108);
            this.button_docCaption.Name = "button_docCaption";
            this.button_docCaption.Size = new System.Drawing.Size(122, 36);
            this.button_docCaption.TabIndex = 38;
            this.button_docCaption.Text = "Подпись док.";
            this.button_docCaption.UseVisualStyleBackColor = false;
            this.button_docCaption.Click += new System.EventHandler(this.button_docCaption_Click);
            // 
            // button_axisCaption
            // 
            this.button_axisCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_axisCaption.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_axisCaption.FlatAppearance.BorderSize = 2;
            this.button_axisCaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_axisCaption.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_axisCaption.ForeColor = System.Drawing.Color.White;
            this.button_axisCaption.Location = new System.Drawing.Point(18, 66);
            this.button_axisCaption.Name = "button_axisCaption";
            this.button_axisCaption.Size = new System.Drawing.Size(122, 36);
            this.button_axisCaption.TabIndex = 37;
            this.button_axisCaption.Text = "Подписи осей";
            this.button_axisCaption.UseVisualStyleBackColor = false;
            this.button_axisCaption.Click += new System.EventHandler(this.button_axisCaption_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_exit.ForeColor = System.Drawing.Color.White;
            this.button_exit.Location = new System.Drawing.Point(21, 309);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(119, 36);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "Закрыть";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_axis
            // 
            this.button_axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(92)))), ((int)(((byte)(199)))));
            this.button_axis.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_axis.FlatAppearance.BorderSize = 2;
            this.button_axis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_axis.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_axis.ForeColor = System.Drawing.Color.White;
            this.button_axis.Location = new System.Drawing.Point(18, 24);
            this.button_axis.Name = "button_axis";
            this.button_axis.Size = new System.Drawing.Size(122, 36);
            this.button_axis.TabIndex = 1;
            this.button_axis.Text = "Оси";
            this.button_axis.UseVisualStyleBackColor = false;
            this.button_axis.Click += new System.EventHandler(this.button_axis_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_axis);
            this.tabControl1.Controls.Add(this.tabPage_axisCaption);
            this.tabControl1.Controls.Add(this.tabPage_docCaption);
            this.tabControl1.Controls.Add(this.tabPage_grid);
            this.tabControl1.Controls.Add(this.tabPage_legend);
            this.tabControl1.Controls.Add(this.tabPage_addPoints);
            this.tabControl1.Location = new System.Drawing.Point(124, -24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 378);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage_axis
            // 
            this.tabPage_axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_axis.Controls.Add(this.checkBox_axis_show);
            this.tabPage_axis.Controls.Add(this.groupBox_axis_display);
            this.tabPage_axis.Controls.Add(this.groupBox_axis_param);
            this.tabPage_axis.Controls.Add(this.label_axis_label);
            this.tabPage_axis.Location = new System.Drawing.Point(4, 22);
            this.tabPage_axis.Name = "tabPage_axis";
            this.tabPage_axis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_axis.Size = new System.Drawing.Size(533, 352);
            this.tabPage_axis.TabIndex = 0;
            this.tabPage_axis.Text = "tabPage_axis";
            // 
            // checkBox_axis_show
            // 
            this.checkBox_axis_show.AutoSize = true;
            this.checkBox_axis_show.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_axis_show.Location = new System.Drawing.Point(398, 17);
            this.checkBox_axis_show.Name = "checkBox_axis_show";
            this.checkBox_axis_show.Size = new System.Drawing.Size(110, 21);
            this.checkBox_axis_show.TabIndex = 132;
            this.checkBox_axis_show.Text = "Отображать";
            this.checkBox_axis_show.UseVisualStyleBackColor = true;
            this.checkBox_axis_show.CheckedChanged += new System.EventHandler(this.checkBox_axis_show_CheckedChanged);
            // 
            // groupBox_axis_display
            // 
            this.groupBox_axis_display.Controls.Add(this.label_axis_width);
            this.groupBox_axis_display.Controls.Add(this.label_axis_color);
            this.groupBox_axis_display.Controls.Add(this.label_axis_color_info);
            this.groupBox_axis_display.Controls.Add(this.button_axis_color);
            this.groupBox_axis_display.Controls.Add(this.pictureBox_axis_color);
            this.groupBox_axis_display.Controls.Add(this.textBox_axis_width);
            this.groupBox_axis_display.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_axis_display.Location = new System.Drawing.Point(32, 191);
            this.groupBox_axis_display.Name = "groupBox_axis_display";
            this.groupBox_axis_display.Size = new System.Drawing.Size(469, 125);
            this.groupBox_axis_display.TabIndex = 131;
            this.groupBox_axis_display.TabStop = false;
            this.groupBox_axis_display.Text = "Параметры отображения";
            // 
            // label_axis_width
            // 
            this.label_axis_width.AutoSize = true;
            this.label_axis_width.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_axis_width.Location = new System.Drawing.Point(33, 38);
            this.label_axis_width.Name = "label_axis_width";
            this.label_axis_width.Size = new System.Drawing.Size(98, 17);
            this.label_axis_width.TabIndex = 128;
            this.label_axis_width.Text = "Ширина осей";
            // 
            // label_axis_color
            // 
            this.label_axis_color.AutoSize = true;
            this.label_axis_color.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_axis_color.Location = new System.Drawing.Point(33, 79);
            this.label_axis_color.Name = "label_axis_color";
            this.label_axis_color.Size = new System.Drawing.Size(75, 17);
            this.label_axis_color.TabIndex = 127;
            this.label_axis_color.Text = "Цвет осей";
            // 
            // label_axis_color_info
            // 
            this.label_axis_color_info.AutoSize = true;
            this.label_axis_color_info.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_axis_color_info.Location = new System.Drawing.Point(276, 79);
            this.label_axis_color_info.Name = "label_axis_color_info";
            this.label_axis_color_info.Size = new System.Drawing.Size(134, 17);
            this.label_axis_color_info.TabIndex = 126;
            this.label_axis_color_info.Text = "RGB (100, 100, 100)";
            // 
            // button_axis_color
            // 
            this.button_axis_color.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_axis_color.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_axis_color.FlatAppearance.BorderSize = 2;
            this.button_axis_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_axis_color.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_axis_color.Location = new System.Drawing.Point(186, 70);
            this.button_axis_color.Name = "button_axis_color";
            this.button_axis_color.Size = new System.Drawing.Size(84, 35);
            this.button_axis_color.TabIndex = 124;
            this.button_axis_color.Text = "Выбрать";
            this.button_axis_color.UseVisualStyleBackColor = false;
            this.button_axis_color.Click += new System.EventHandler(this.button_axis_color_Click);
            // 
            // pictureBox_axis_color
            // 
            this.pictureBox_axis_color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_axis_color.Location = new System.Drawing.Point(138, 73);
            this.pictureBox_axis_color.Name = "pictureBox_axis_color";
            this.pictureBox_axis_color.Size = new System.Drawing.Size(42, 28);
            this.pictureBox_axis_color.TabIndex = 125;
            this.pictureBox_axis_color.TabStop = false;
            // 
            // textBox_axis_width
            // 
            this.textBox_axis_width.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_axis_width.Location = new System.Drawing.Point(138, 35);
            this.textBox_axis_width.Name = "textBox_axis_width";
            this.textBox_axis_width.Size = new System.Drawing.Size(100, 25);
            this.textBox_axis_width.TabIndex = 12;
            // 
            // groupBox_axis_param
            // 
            this.groupBox_axis_param.Controls.Add(this.label_axis_offset_y);
            this.groupBox_axis_param.Controls.Add(this.label_axis_offset_x);
            this.groupBox_axis_param.Controls.Add(this.textBox_axis_offset_y);
            this.groupBox_axis_param.Controls.Add(this.textBox_axis_offset_x);
            this.groupBox_axis_param.Controls.Add(this.radioButton_axis_limited);
            this.groupBox_axis_param.Controls.Add(this.radioButton_axis_unlimited);
            this.groupBox_axis_param.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_axis_param.Location = new System.Drawing.Point(32, 56);
            this.groupBox_axis_param.Name = "groupBox_axis_param";
            this.groupBox_axis_param.Size = new System.Drawing.Size(469, 129);
            this.groupBox_axis_param.TabIndex = 130;
            this.groupBox_axis_param.TabStop = false;
            this.groupBox_axis_param.Text = "Параметры осей";
            // 
            // label_axis_offset_y
            // 
            this.label_axis_offset_y.AutoSize = true;
            this.label_axis_offset_y.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_axis_offset_y.Location = new System.Drawing.Point(197, 68);
            this.label_axis_offset_y.Name = "label_axis_offset_y";
            this.label_axis_offset_y.Size = new System.Drawing.Size(109, 17);
            this.label_axis_offset_y.TabIndex = 130;
            this.label_axis_offset_y.Text = "Смещение по Y";
            // 
            // label_axis_offset_x
            // 
            this.label_axis_offset_x.AutoSize = true;
            this.label_axis_offset_x.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_axis_offset_x.Location = new System.Drawing.Point(197, 35);
            this.label_axis_offset_x.Name = "label_axis_offset_x";
            this.label_axis_offset_x.Size = new System.Drawing.Size(109, 17);
            this.label_axis_offset_x.TabIndex = 129;
            this.label_axis_offset_x.Text = "Смещение по Х";
            // 
            // textBox_axis_offset_y
            // 
            this.textBox_axis_offset_y.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_axis_offset_y.Location = new System.Drawing.Point(312, 65);
            this.textBox_axis_offset_y.Name = "textBox_axis_offset_y";
            this.textBox_axis_offset_y.Size = new System.Drawing.Size(81, 25);
            this.textBox_axis_offset_y.TabIndex = 11;
            // 
            // textBox_axis_offset_x
            // 
            this.textBox_axis_offset_x.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_axis_offset_x.Location = new System.Drawing.Point(312, 32);
            this.textBox_axis_offset_x.Name = "textBox_axis_offset_x";
            this.textBox_axis_offset_x.Size = new System.Drawing.Size(81, 25);
            this.textBox_axis_offset_x.TabIndex = 10;
            // 
            // radioButton_axis_limited
            // 
            this.radioButton_axis_limited.AutoSize = true;
            this.radioButton_axis_limited.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.radioButton_axis_limited.Location = new System.Drawing.Point(22, 33);
            this.radioButton_axis_limited.Name = "radioButton_axis_limited";
            this.radioButton_axis_limited.Size = new System.Drawing.Size(154, 21);
            this.radioButton_axis_limited.TabIndex = 9;
            this.radioButton_axis_limited.TabStop = true;
            this.radioButton_axis_limited.Text = "Ограниченные оси";
            this.radioButton_axis_limited.UseVisualStyleBackColor = true;
            this.radioButton_axis_limited.CheckedChanged += new System.EventHandler(this.radioButton_axis_limited_CheckedChanged);
            // 
            // radioButton_axis_unlimited
            // 
            this.radioButton_axis_unlimited.AutoSize = true;
            this.radioButton_axis_unlimited.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.radioButton_axis_unlimited.Location = new System.Drawing.Point(22, 84);
            this.radioButton_axis_unlimited.Name = "radioButton_axis_unlimited";
            this.radioButton_axis_unlimited.Size = new System.Drawing.Size(169, 21);
            this.radioButton_axis_unlimited.TabIndex = 8;
            this.radioButton_axis_unlimited.TabStop = true;
            this.radioButton_axis_unlimited.Text = "Неограниченные оси";
            this.radioButton_axis_unlimited.UseVisualStyleBackColor = true;
            // 
            // label_axis_label
            // 
            this.label_axis_label.AutoSize = true;
            this.label_axis_label.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_axis_label.Location = new System.Drawing.Point(31, 14);
            this.label_axis_label.Name = "label_axis_label";
            this.label_axis_label.Size = new System.Drawing.Size(151, 22);
            this.label_axis_label.TabIndex = 7;
            this.label_axis_label.Text = "Параметры осей";
            // 
            // tabPage_axisCaption
            // 
            this.tabPage_axisCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_axisCaption.Controls.Add(this.checkBox_axisC_displ);
            this.tabPage_axisCaption.Location = new System.Drawing.Point(4, 22);
            this.tabPage_axisCaption.Name = "tabPage_axisCaption";
            this.tabPage_axisCaption.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_axisCaption.Size = new System.Drawing.Size(533, 352);
            this.tabPage_axisCaption.TabIndex = 1;
            this.tabPage_axisCaption.Text = "tabPage2";
            // 
            // button_grid
            // 
            this.button_grid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_grid.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_grid.FlatAppearance.BorderSize = 2;
            this.button_grid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_grid.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_grid.ForeColor = System.Drawing.Color.White;
            this.button_grid.Location = new System.Drawing.Point(18, 150);
            this.button_grid.Name = "button_grid";
            this.button_grid.Size = new System.Drawing.Size(122, 36);
            this.button_grid.TabIndex = 39;
            this.button_grid.Text = "Сетка";
            this.button_grid.UseVisualStyleBackColor = false;
            this.button_grid.Click += new System.EventHandler(this.button_grid_Click);
            // 
            // button_legend
            // 
            this.button_legend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_legend.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_legend.FlatAppearance.BorderSize = 2;
            this.button_legend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_legend.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_legend.ForeColor = System.Drawing.Color.White;
            this.button_legend.Location = new System.Drawing.Point(18, 192);
            this.button_legend.Name = "button_legend";
            this.button_legend.Size = new System.Drawing.Size(122, 36);
            this.button_legend.TabIndex = 40;
            this.button_legend.Text = "Легенда";
            this.button_legend.UseVisualStyleBackColor = false;
            this.button_legend.Click += new System.EventHandler(this.button_legend_Click);
            // 
            // button_addPoints
            // 
            this.button_addPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_addPoints.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_addPoints.FlatAppearance.BorderSize = 2;
            this.button_addPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addPoints.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_addPoints.ForeColor = System.Drawing.Color.White;
            this.button_addPoints.Location = new System.Drawing.Point(18, 234);
            this.button_addPoints.Name = "button_addPoints";
            this.button_addPoints.Size = new System.Drawing.Size(122, 46);
            this.button_addPoints.TabIndex = 41;
            this.button_addPoints.Text = "Точки на графике";
            this.button_addPoints.UseVisualStyleBackColor = false;
            this.button_addPoints.Click += new System.EventHandler(this.button_addPoints_Click);
            // 
            // tabPage_docCaption
            // 
            this.tabPage_docCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_docCaption.Controls.Add(this.checkBox_docC_displ);
            this.tabPage_docCaption.Location = new System.Drawing.Point(4, 22);
            this.tabPage_docCaption.Name = "tabPage_docCaption";
            this.tabPage_docCaption.Size = new System.Drawing.Size(533, 352);
            this.tabPage_docCaption.TabIndex = 2;
            this.tabPage_docCaption.Text = "tabPage1";
            // 
            // tabPage_grid
            // 
            this.tabPage_grid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_grid.Controls.Add(this.checkBox_grid_displ);
            this.tabPage_grid.Location = new System.Drawing.Point(4, 22);
            this.tabPage_grid.Name = "tabPage_grid";
            this.tabPage_grid.Size = new System.Drawing.Size(533, 352);
            this.tabPage_grid.TabIndex = 3;
            this.tabPage_grid.Text = "tabPage1";
            // 
            // tabPage_legend
            // 
            this.tabPage_legend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_legend.Controls.Add(this.checkBox_legend_displ);
            this.tabPage_legend.Location = new System.Drawing.Point(4, 22);
            this.tabPage_legend.Name = "tabPage_legend";
            this.tabPage_legend.Size = new System.Drawing.Size(533, 352);
            this.tabPage_legend.TabIndex = 4;
            this.tabPage_legend.Text = "tabPage1";
            // 
            // tabPage_addPoints
            // 
            this.tabPage_addPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage_addPoints.Controls.Add(this.panel_markers_status);
            this.tabPage_addPoints.Controls.Add(this.checkBox_addPoints_displ);
            this.tabPage_addPoints.Controls.Add(this.groupBox_markers);
            this.tabPage_addPoints.Controls.Add(this.groupBox_names);
            this.tabPage_addPoints.Location = new System.Drawing.Point(4, 22);
            this.tabPage_addPoints.Name = "tabPage_addPoints";
            this.tabPage_addPoints.Size = new System.Drawing.Size(533, 352);
            this.tabPage_addPoints.TabIndex = 5;
            this.tabPage_addPoints.Text = "tabPage1";
            // 
            // checkBox_axisC_displ
            // 
            this.checkBox_axisC_displ.AutoSize = true;
            this.checkBox_axisC_displ.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_axisC_displ.Location = new System.Drawing.Point(398, 17);
            this.checkBox_axisC_displ.Name = "checkBox_axisC_displ";
            this.checkBox_axisC_displ.Size = new System.Drawing.Size(110, 21);
            this.checkBox_axisC_displ.TabIndex = 133;
            this.checkBox_axisC_displ.Text = "Отображать";
            this.checkBox_axisC_displ.UseVisualStyleBackColor = true;
            // 
            // checkBox_docC_displ
            // 
            this.checkBox_docC_displ.AutoSize = true;
            this.checkBox_docC_displ.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_docC_displ.Location = new System.Drawing.Point(398, 17);
            this.checkBox_docC_displ.Name = "checkBox_docC_displ";
            this.checkBox_docC_displ.Size = new System.Drawing.Size(110, 21);
            this.checkBox_docC_displ.TabIndex = 134;
            this.checkBox_docC_displ.Text = "Отображать";
            this.checkBox_docC_displ.UseVisualStyleBackColor = true;
            // 
            // checkBox_grid_displ
            // 
            this.checkBox_grid_displ.AutoSize = true;
            this.checkBox_grid_displ.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_grid_displ.Location = new System.Drawing.Point(398, 17);
            this.checkBox_grid_displ.Name = "checkBox_grid_displ";
            this.checkBox_grid_displ.Size = new System.Drawing.Size(110, 21);
            this.checkBox_grid_displ.TabIndex = 134;
            this.checkBox_grid_displ.Text = "Отображать";
            this.checkBox_grid_displ.UseVisualStyleBackColor = true;
            // 
            // checkBox_legend_displ
            // 
            this.checkBox_legend_displ.AutoSize = true;
            this.checkBox_legend_displ.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_legend_displ.Location = new System.Drawing.Point(398, 17);
            this.checkBox_legend_displ.Name = "checkBox_legend_displ";
            this.checkBox_legend_displ.Size = new System.Drawing.Size(110, 21);
            this.checkBox_legend_displ.TabIndex = 134;
            this.checkBox_legend_displ.Text = "Отображать";
            this.checkBox_legend_displ.UseVisualStyleBackColor = true;
            // 
            // checkBox_addPoints_displ
            // 
            this.checkBox_addPoints_displ.AutoSize = true;
            this.checkBox_addPoints_displ.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_addPoints_displ.Location = new System.Drawing.Point(388, 17);
            this.checkBox_addPoints_displ.Name = "checkBox_addPoints_displ";
            this.checkBox_addPoints_displ.Size = new System.Drawing.Size(110, 21);
            this.checkBox_addPoints_displ.TabIndex = 134;
            this.checkBox_addPoints_displ.Text = "Отображать";
            this.checkBox_addPoints_displ.UseVisualStyleBackColor = true;
            this.checkBox_addPoints_displ.CheckedChanged += new System.EventHandler(this.checkBox_addPoints_displ_CheckedChanged);
            // 
            // groupBox_inde
            // 
            this.groupBox_inde.Controls.Add(this.button_markers_compile);
            this.groupBox_inde.Controls.Add(this.label_markers_period_end);
            this.groupBox_inde.Controls.Add(this.label_markers_period_start);
            this.groupBox_inde.Controls.Add(this.label_markers_period);
            this.groupBox_inde.Controls.Add(this.textBox_markers_period_end);
            this.groupBox_inde.Controls.Add(this.textBox_markers_period_start);
            this.groupBox_inde.Controls.Add(this.checkBox_markers_period);
            this.groupBox_inde.Controls.Add(this.textBox_markers_period);
            this.groupBox_inde.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_inde.Location = new System.Drawing.Point(11, 46);
            this.groupBox_inde.Name = "groupBox_inde";
            this.groupBox_inde.Size = new System.Drawing.Size(452, 117);
            this.groupBox_inde.TabIndex = 135;
            this.groupBox_inde.TabStop = false;
            this.groupBox_inde.Text = "Параметры";
            // 
            // radioButton_independence
            // 
            this.radioButton_independence.AutoSize = true;
            this.radioButton_independence.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.radioButton_independence.Location = new System.Drawing.Point(11, 19);
            this.radioButton_independence.Name = "radioButton_independence";
            this.radioButton_independence.Size = new System.Drawing.Size(138, 21);
            this.radioButton_independence.TabIndex = 0;
            this.radioButton_independence.TabStop = true;
            this.radioButton_independence.Text = "Самостоятельно";
            this.radioButton_independence.UseVisualStyleBackColor = true;
            this.radioButton_independence.CheckedChanged += new System.EventHandler(this.radioButton_independence_CheckedChanged);
            // 
            // radioButton_asMarkeks
            // 
            this.radioButton_asMarkeks.AutoSize = true;
            this.radioButton_asMarkeks.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.radioButton_asMarkeks.Location = new System.Drawing.Point(184, 19);
            this.radioButton_asMarkeks.Name = "radioButton_asMarkeks";
            this.radioButton_asMarkeks.Size = new System.Drawing.Size(184, 21);
            this.radioButton_asMarkeks.TabIndex = 1;
            this.radioButton_asMarkeks.TabStop = true;
            this.radioButton_asMarkeks.Text = "Совпадать с маркерами";
            this.radioButton_asMarkeks.UseVisualStyleBackColor = true;
            // 
            // label_markers_period_end
            // 
            this.label_markers_period_end.AutoSize = true;
            this.label_markers_period_end.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_markers_period_end.Location = new System.Drawing.Point(335, 53);
            this.label_markers_period_end.Name = "label_markers_period_end";
            this.label_markers_period_end.Size = new System.Drawing.Size(25, 17);
            this.label_markers_period_end.TabIndex = 21;
            this.label_markers_period_end.Text = "по";
            // 
            // label_markers_period_start
            // 
            this.label_markers_period_start.AutoSize = true;
            this.label_markers_period_start.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_markers_period_start.Location = new System.Drawing.Point(296, 31);
            this.label_markers_period_start.Name = "label_markers_period_start";
            this.label_markers_period_start.Size = new System.Drawing.Size(66, 17);
            this.label_markers_period_start.TabIndex = 20;
            this.label_markers_period_start.Text = "Начать с";
            // 
            // label_markers_period
            // 
            this.label_markers_period.AutoSize = true;
            this.label_markers_period.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_markers_period.Location = new System.Drawing.Point(9, 41);
            this.label_markers_period.Name = "label_markers_period";
            this.label_markers_period.Size = new System.Drawing.Size(58, 17);
            this.label_markers_period.TabIndex = 19;
            this.label_markers_period.Text = "Период";
            // 
            // textBox_markers_period_end
            // 
            this.textBox_markers_period_end.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_markers_period_end.Location = new System.Drawing.Point(366, 51);
            this.textBox_markers_period_end.Name = "textBox_markers_period_end";
            this.textBox_markers_period_end.Size = new System.Drawing.Size(75, 25);
            this.textBox_markers_period_end.TabIndex = 18;
            // 
            // textBox_markers_period_start
            // 
            this.textBox_markers_period_start.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_markers_period_start.Location = new System.Drawing.Point(366, 25);
            this.textBox_markers_period_start.Name = "textBox_markers_period_start";
            this.textBox_markers_period_start.Size = new System.Drawing.Size(75, 25);
            this.textBox_markers_period_start.TabIndex = 17;
            // 
            // checkBox_markers_period
            // 
            this.checkBox_markers_period.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_markers_period.Location = new System.Drawing.Point(173, 31);
            this.checkBox_markers_period.Name = "checkBox_markers_period";
            this.checkBox_markers_period.Size = new System.Drawing.Size(128, 40);
            this.checkBox_markers_period.TabIndex = 16;
            this.checkBox_markers_period.Text = "На заданом промежутке\r\n\r\n";
            this.checkBox_markers_period.UseVisualStyleBackColor = true;
            this.checkBox_markers_period.CheckedChanged += new System.EventHandler(this.checkBox_markers_period_CheckedChanged);
            // 
            // textBox_markers_period
            // 
            this.textBox_markers_period.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_markers_period.Location = new System.Drawing.Point(73, 38);
            this.textBox_markers_period.Name = "textBox_markers_period";
            this.textBox_markers_period.Size = new System.Drawing.Size(84, 25);
            this.textBox_markers_period.TabIndex = 15;
            // 
            // button_markers_compile
            // 
            this.button_markers_compile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_markers_compile.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_markers_compile.FlatAppearance.BorderSize = 2;
            this.button_markers_compile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_markers_compile.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_markers_compile.Location = new System.Drawing.Point(12, 73);
            this.button_markers_compile.Name = "button_markers_compile";
            this.button_markers_compile.Size = new System.Drawing.Size(107, 35);
            this.button_markers_compile.TabIndex = 136;
            this.button_markers_compile.Text = "Применить";
            this.button_markers_compile.UseVisualStyleBackColor = false;
            this.button_markers_compile.Click += new System.EventHandler(this.button_markers_compile_Click);
            // 
            // panel_markers_status
            // 
            this.panel_markers_status.Controls.Add(this.button_markers_status);
            this.panel_markers_status.Controls.Add(this.label_markers_status);
            this.panel_markers_status.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.panel_markers_status.Location = new System.Drawing.Point(26, 298);
            this.panel_markers_status.Name = "panel_markers_status";
            this.panel_markers_status.Size = new System.Drawing.Size(485, 41);
            this.panel_markers_status.TabIndex = 137;
            this.panel_markers_status.Visible = false;
            // 
            // button_markers_status
            // 
            this.button_markers_status.BackColor = System.Drawing.Color.White;
            this.button_markers_status.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_markers_status.FlatAppearance.BorderSize = 2;
            this.button_markers_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_markers_status.Location = new System.Drawing.Point(377, 3);
            this.button_markers_status.Name = "button_markers_status";
            this.button_markers_status.Size = new System.Drawing.Size(103, 36);
            this.button_markers_status.TabIndex = 1;
            this.button_markers_status.Text = "Подробнее";
            this.button_markers_status.UseVisualStyleBackColor = false;
            this.button_markers_status.Visible = false;
            this.button_markers_status.Click += new System.EventHandler(this.button_markers_status_Click);
            // 
            // label_markers_status
            // 
            this.label_markers_status.AutoSize = true;
            this.label_markers_status.Location = new System.Drawing.Point(3, 12);
            this.label_markers_status.Name = "label_markers_status";
            this.label_markers_status.Size = new System.Drawing.Size(132, 17);
            this.label_markers_status.TabIndex = 0;
            this.label_markers_status.Text = "textextetxtextextext";
            // 
            // timer_markers_expire
            // 
            this.timer_markers_expire.Interval = 1500;
            // 
            // textBox_axis_x
            // 
            this.textBox_axis_x.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_axis_x.Location = new System.Drawing.Point(352, 27);
            this.textBox_axis_x.Name = "textBox_axis_x";
            this.textBox_axis_x.Size = new System.Drawing.Size(100, 25);
            this.textBox_axis_x.TabIndex = 138;
            // 
            // textBox_axis_y
            // 
            this.textBox_axis_y.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.textBox_axis_y.Location = new System.Drawing.Point(352, 53);
            this.textBox_axis_y.Name = "textBox_axis_y";
            this.textBox_axis_y.Size = new System.Drawing.Size(100, 25);
            this.textBox_axis_y.TabIndex = 139;
            // 
            // label_axis_x
            // 
            this.label_axis_x.AutoSize = true;
            this.label_axis_x.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_axis_x.Location = new System.Drawing.Point(181, 30);
            this.label_axis_x.Name = "label_axis_x";
            this.label_axis_x.Size = new System.Drawing.Size(165, 17);
            this.label_axis_x.TabIndex = 140;
            this.label_axis_x.Text = "Особое название оси X:";
            // 
            // label_axis_y
            // 
            this.label_axis_y.AutoSize = true;
            this.label_axis_y.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_axis_y.Location = new System.Drawing.Point(181, 56);
            this.label_axis_y.Name = "label_axis_y";
            this.label_axis_y.Size = new System.Drawing.Size(164, 17);
            this.label_axis_y.TabIndex = 141;
            this.label_axis_y.Text = "Особое название оси Y:";
            // 
            // checkBox_axis_x
            // 
            this.checkBox_axis_x.AutoSize = true;
            this.checkBox_axis_x.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_axis_x.Location = new System.Drawing.Point(23, 29);
            this.checkBox_axis_x.Name = "checkBox_axis_x";
            this.checkBox_axis_x.Size = new System.Drawing.Size(96, 21);
            this.checkBox_axis_x.TabIndex = 142;
            this.checkBox_axis_x.Text = "checkBox1";
            this.checkBox_axis_x.UseVisualStyleBackColor = true;
            // 
            // checkBox_axis_y
            // 
            this.checkBox_axis_y.AutoSize = true;
            this.checkBox_axis_y.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.checkBox_axis_y.Location = new System.Drawing.Point(23, 56);
            this.checkBox_axis_y.Name = "checkBox_axis_y";
            this.checkBox_axis_y.Size = new System.Drawing.Size(96, 21);
            this.checkBox_axis_y.TabIndex = 143;
            this.checkBox_axis_y.Text = "checkBox2";
            this.checkBox_axis_y.UseVisualStyleBackColor = true;
            // 
            // groupBox_names
            // 
            this.groupBox_names.Controls.Add(this.checkBox_axis_y);
            this.groupBox_names.Controls.Add(this.checkBox_axis_x);
            this.groupBox_names.Controls.Add(this.label_axis_y);
            this.groupBox_names.Controls.Add(this.label_axis_x);
            this.groupBox_names.Controls.Add(this.textBox_axis_y);
            this.groupBox_names.Controls.Add(this.textBox_axis_x);
            this.groupBox_names.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_names.Location = new System.Drawing.Point(32, 221);
            this.groupBox_names.Name = "groupBox_names";
            this.groupBox_names.Size = new System.Drawing.Size(469, 95);
            this.groupBox_names.TabIndex = 144;
            this.groupBox_names.TabStop = false;
            this.groupBox_names.Text = "Название осей";
            // 
            // groupBox_markers
            // 
            this.groupBox_markers.Controls.Add(this.radioButton_asMarkeks);
            this.groupBox_markers.Controls.Add(this.groupBox_inde);
            this.groupBox_markers.Controls.Add(this.radioButton_independence);
            this.groupBox_markers.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox_markers.Location = new System.Drawing.Point(32, 38);
            this.groupBox_markers.Name = "groupBox_markers";
            this.groupBox_markers.Size = new System.Drawing.Size(469, 177);
            this.groupBox_markers.TabIndex = 145;
            this.groupBox_markers.TabStop = false;
            this.groupBox_markers.Text = "Засечки на осях";
            // 
            // Form_Dialog_EditElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(648, 345);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_Dialog_EditElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Dialog_EditElement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Dialog_EditElement_FormClosing);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_axis.ResumeLayout(false);
            this.tabPage_axis.PerformLayout();
            this.groupBox_axis_display.ResumeLayout(false);
            this.groupBox_axis_display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_axis_color)).EndInit();
            this.groupBox_axis_param.ResumeLayout(false);
            this.groupBox_axis_param.PerformLayout();
            this.tabPage_axisCaption.ResumeLayout(false);
            this.tabPage_axisCaption.PerformLayout();
            this.tabPage_docCaption.ResumeLayout(false);
            this.tabPage_docCaption.PerformLayout();
            this.tabPage_grid.ResumeLayout(false);
            this.tabPage_grid.PerformLayout();
            this.tabPage_legend.ResumeLayout(false);
            this.tabPage_legend.PerformLayout();
            this.tabPage_addPoints.ResumeLayout(false);
            this.tabPage_addPoints.PerformLayout();
            this.groupBox_inde.ResumeLayout(false);
            this.groupBox_inde.PerformLayout();
            this.panel_markers_status.ResumeLayout(false);
            this.panel_markers_status.PerformLayout();
            this.groupBox_names.ResumeLayout(false);
            this.groupBox_names.PerformLayout();
            this.groupBox_markers.ResumeLayout(false);
            this.groupBox_markers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_docCaption;
        private System.Windows.Forms.Button button_axisCaption;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_axis;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_axis;
        private System.Windows.Forms.TabPage tabPage_axisCaption;
        private System.Windows.Forms.TextBox textBox_axis_width;
        private System.Windows.Forms.TextBox textBox_axis_offset_y;
        private System.Windows.Forms.TextBox textBox_axis_offset_x;
        private System.Windows.Forms.RadioButton radioButton_axis_limited;
        private System.Windows.Forms.RadioButton radioButton_axis_unlimited;
        private System.Windows.Forms.Label label_axis_label;
        private System.Windows.Forms.CheckBox checkBox_axis_show;
        private System.Windows.Forms.GroupBox groupBox_axis_display;
        private System.Windows.Forms.Label label_axis_width;
        private System.Windows.Forms.Label label_axis_color;
        internal System.Windows.Forms.Label label_axis_color_info;
        internal System.Windows.Forms.Button button_axis_color;
        internal System.Windows.Forms.PictureBox pictureBox_axis_color;
        private System.Windows.Forms.GroupBox groupBox_axis_param;
        private System.Windows.Forms.Label label_axis_offset_x;
        private System.Windows.Forms.Label label_axis_offset_y;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_grid;
        private System.Windows.Forms.Button button_addPoints;
        private System.Windows.Forms.Button button_legend;
        private System.Windows.Forms.CheckBox checkBox_axisC_displ;
        private System.Windows.Forms.TabPage tabPage_docCaption;
        private System.Windows.Forms.CheckBox checkBox_docC_displ;
        private System.Windows.Forms.TabPage tabPage_grid;
        private System.Windows.Forms.CheckBox checkBox_grid_displ;
        private System.Windows.Forms.TabPage tabPage_legend;
        private System.Windows.Forms.CheckBox checkBox_legend_displ;
        private System.Windows.Forms.TabPage tabPage_addPoints;
        private System.Windows.Forms.CheckBox checkBox_addPoints_displ;
        private System.Windows.Forms.RadioButton radioButton_asMarkeks;
        private System.Windows.Forms.GroupBox groupBox_inde;
        private System.Windows.Forms.RadioButton radioButton_independence;
        private System.Windows.Forms.Label label_markers_period_end;
        private System.Windows.Forms.Label label_markers_period_start;
        private System.Windows.Forms.Label label_markers_period;
        private System.Windows.Forms.TextBox textBox_markers_period_end;
        private System.Windows.Forms.TextBox textBox_markers_period_start;
        private System.Windows.Forms.CheckBox checkBox_markers_period;
        private System.Windows.Forms.TextBox textBox_markers_period;
        internal System.Windows.Forms.Button button_markers_compile;
        private System.Windows.Forms.Panel panel_markers_status;
        private System.Windows.Forms.Button button_markers_status;
        private System.Windows.Forms.Label label_markers_status;
        private System.Windows.Forms.Label label_axis_y;
        private System.Windows.Forms.Label label_axis_x;
        private System.Windows.Forms.TextBox textBox_axis_y;
        private System.Windows.Forms.TextBox textBox_axis_x;
        private System.Windows.Forms.Timer timer_markers_expire;
        private System.Windows.Forms.GroupBox groupBox_markers;
        private System.Windows.Forms.GroupBox groupBox_names;
        private System.Windows.Forms.CheckBox checkBox_axis_y;
        private System.Windows.Forms.CheckBox checkBox_axis_x;
    }
}
