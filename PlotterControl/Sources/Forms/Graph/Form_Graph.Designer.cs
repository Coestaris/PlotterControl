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
* PlotterControl \ Form_Graph.Designer.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 06.08.2017 20:52:18
*
*=================================*/

using CWA_Resources.Properties;

namespace CnC_WFA
{
    partial class Form_Graph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Graph));
            this.listBox_Main = new System.Windows.Forms.ListBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_copy = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_setup_addPoints = new System.Windows.Forms.Button();
            this.checkBox_use_addPoints = new System.Windows.Forms.CheckBox();
            this.button_setup_legend = new System.Windows.Forms.Button();
            this.checkBox_use_legend = new System.Windows.Forms.CheckBox();
            this.button_setup_grid = new System.Windows.Forms.Button();
            this.checkBox_use_Grid = new System.Windows.Forms.CheckBox();
            this.button_setup_docName = new System.Windows.Forms.Button();
            this.checkBox_use_docName = new System.Windows.Forms.CheckBox();
            this.button_setup_axisNames = new System.Windows.Forms.Button();
            this.checkBox_use_axisNames = new System.Windows.Forms.CheckBox();
            this.button_setup_axis = new System.Windows.Forms.Button();
            this.checkBox_use_axis = new System.Windows.Forms.CheckBox();
            this.labelHint = new System.Windows.Forms.Label();
            this.label_zoom = new System.Windows.Forms.Label();
            this.timer_redraw = new System.Windows.Forms.Timer(this.components);
            this.panel_tools = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_y = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.panel_wait = new System.Windows.Forms.Panel();
            this.loadingCircle_tab1 = new MRG.Controls.UI.LoadingCircle();
            this.label_load = new System.Windows.Forms.Label();
            this.panel_loaderr = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_loaderr_close = new System.Windows.Forms.Button();
            this.button_loaderr_more = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel_tools.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_wait.SuspendLayout();
            this.panel_loaderr.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Main
            // 
            this.listBox_Main.BackColor = System.Drawing.Color.White;
            this.listBox_Main.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.listBox_Main.FormattingEnabled = true;
            this.listBox_Main.ItemHeight = 17;
            this.listBox_Main.Location = new System.Drawing.Point(14, 25);
            this.listBox_Main.Name = "listBox_Main";
            this.listBox_Main.Size = new System.Drawing.Size(224, 123);
            this.listBox_Main.TabIndex = 0;
            this.listBox_Main.SelectedIndexChanged += new System.EventHandler(this.listBox_Main_SelectedIndexChanged);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.White;
            this.button_add.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_add.FlatAppearance.BorderSize = 2;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_add.Location = new System.Drawing.Point(14, 154);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(88, 38);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.Color.White;
            this.button_edit.Enabled = false;
            this.button_edit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_edit.FlatAppearance.BorderSize = 2;
            this.button_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_edit.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_edit.Location = new System.Drawing.Point(108, 154);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(130, 38);
            this.button_edit.TabIndex = 2;
            this.button_edit.Text = "Редактировать";
            this.button_edit.UseVisualStyleBackColor = false;
            this.button_edit.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_del
            // 
            this.button_del.BackColor = System.Drawing.Color.White;
            this.button_del.Enabled = false;
            this.button_del.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_del.FlatAppearance.BorderSize = 2;
            this.button_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_del.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_del.Location = new System.Drawing.Point(150, 198);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(88, 40);
            this.button_del.TabIndex = 3;
            this.button_del.Text = "Удалить";
            this.button_del.UseVisualStyleBackColor = false;
            this.button_del.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(860, 650);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_copy);
            this.groupBox1.Controls.Add(this.button_del);
            this.groupBox1.Controls.Add(this.button_edit);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.listBox_Main);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 247);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Графики";
            // 
            // button_copy
            // 
            this.button_copy.BackColor = System.Drawing.Color.White;
            this.button_copy.Enabled = false;
            this.button_copy.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_copy.FlatAppearance.BorderSize = 2;
            this.button_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_copy.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_copy.Location = new System.Drawing.Point(14, 200);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(130, 38);
            this.button_copy.TabIndex = 4;
            this.button_copy.Text = "Дублировать";
            this.button_copy.UseVisualStyleBackColor = false;
            this.button_copy.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(6, 614);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(214, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_setup_addPoints);
            this.groupBox2.Controls.Add(this.checkBox_use_addPoints);
            this.groupBox2.Controls.Add(this.button_setup_legend);
            this.groupBox2.Controls.Add(this.checkBox_use_legend);
            this.groupBox2.Controls.Add(this.button_setup_grid);
            this.groupBox2.Controls.Add(this.checkBox_use_Grid);
            this.groupBox2.Controls.Add(this.button_setup_docName);
            this.groupBox2.Controls.Add(this.checkBox_use_docName);
            this.groupBox2.Controls.Add(this.button_setup_axisNames);
            this.groupBox2.Controls.Add(this.checkBox_use_axisNames);
            this.groupBox2.Controls.Add(this.button_setup_axis);
            this.groupBox2.Controls.Add(this.checkBox_use_axis);
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(5, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 231);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Элементы";
            // 
            // button_setup_addPoints
            // 
            this.button_setup_addPoints.BackColor = System.Drawing.Color.White;
            this.button_setup_addPoints.Enabled = false;
            this.button_setup_addPoints.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_setup_addPoints.FlatAppearance.BorderSize = 2;
            this.button_setup_addPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_setup_addPoints.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_setup_addPoints.Image = ((System.Drawing.Image)(resources.GetObject("button_setup_addPoints.Image")));
            this.button_setup_addPoints.Location = new System.Drawing.Point(199, 190);
            this.button_setup_addPoints.Name = "button_setup_addPoints";
            this.button_setup_addPoints.Size = new System.Drawing.Size(32, 29);
            this.button_setup_addPoints.TabIndex = 14;
            this.button_setup_addPoints.UseVisualStyleBackColor = false;
            // 
            // checkBox_use_addPoints
            // 
            this.checkBox_use_addPoints.AutoSize = true;
            this.checkBox_use_addPoints.Location = new System.Drawing.Point(14, 195);
            this.checkBox_use_addPoints.Name = "checkBox_use_addPoints";
            this.checkBox_use_addPoints.Size = new System.Drawing.Size(146, 21);
            this.checkBox_use_addPoints.TabIndex = 13;
            this.checkBox_use_addPoints.Text = "Точки на графике";
            this.checkBox_use_addPoints.UseVisualStyleBackColor = true;
            this.checkBox_use_addPoints.CheckedChanged += new System.EventHandler(this.checkBox_use_addPoints_CheckedChanged);
            // 
            // button_setup_legend
            // 
            this.button_setup_legend.BackColor = System.Drawing.Color.White;
            this.button_setup_legend.Enabled = false;
            this.button_setup_legend.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_setup_legend.FlatAppearance.BorderSize = 2;
            this.button_setup_legend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_setup_legend.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_setup_legend.Image = ((System.Drawing.Image)(resources.GetObject("button_setup_legend.Image")));
            this.button_setup_legend.Location = new System.Drawing.Point(199, 156);
            this.button_setup_legend.Name = "button_setup_legend";
            this.button_setup_legend.Size = new System.Drawing.Size(32, 29);
            this.button_setup_legend.TabIndex = 12;
            this.button_setup_legend.UseVisualStyleBackColor = false;
            // 
            // checkBox_use_legend
            // 
            this.checkBox_use_legend.AutoSize = true;
            this.checkBox_use_legend.Location = new System.Drawing.Point(14, 161);
            this.checkBox_use_legend.Name = "checkBox_use_legend";
            this.checkBox_use_legend.Size = new System.Drawing.Size(82, 21);
            this.checkBox_use_legend.TabIndex = 11;
            this.checkBox_use_legend.Text = "Легенда";
            this.checkBox_use_legend.UseVisualStyleBackColor = true;
            this.checkBox_use_legend.CheckedChanged += new System.EventHandler(this.checkBox_use_legend_CheckedChanged);
            // 
            // button_setup_grid
            // 
            this.button_setup_grid.BackColor = System.Drawing.Color.White;
            this.button_setup_grid.Enabled = false;
            this.button_setup_grid.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_setup_grid.FlatAppearance.BorderSize = 2;
            this.button_setup_grid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_setup_grid.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_setup_grid.Image = ((System.Drawing.Image)(resources.GetObject("button_setup_grid.Image")));
            this.button_setup_grid.Location = new System.Drawing.Point(199, 122);
            this.button_setup_grid.Name = "button_setup_grid";
            this.button_setup_grid.Size = new System.Drawing.Size(32, 29);
            this.button_setup_grid.TabIndex = 10;
            this.button_setup_grid.UseVisualStyleBackColor = false;
            // 
            // checkBox_use_Grid
            // 
            this.checkBox_use_Grid.AutoSize = true;
            this.checkBox_use_Grid.Location = new System.Drawing.Point(14, 127);
            this.checkBox_use_Grid.Name = "checkBox_use_Grid";
            this.checkBox_use_Grid.Size = new System.Drawing.Size(65, 21);
            this.checkBox_use_Grid.TabIndex = 9;
            this.checkBox_use_Grid.Text = "Сетка";
            this.checkBox_use_Grid.UseVisualStyleBackColor = true;
            this.checkBox_use_Grid.CheckedChanged += new System.EventHandler(this.checkBox__use_Grid_CheckedChanged);
            // 
            // button_setup_docName
            // 
            this.button_setup_docName.BackColor = System.Drawing.Color.White;
            this.button_setup_docName.Enabled = false;
            this.button_setup_docName.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_setup_docName.FlatAppearance.BorderSize = 2;
            this.button_setup_docName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_setup_docName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_setup_docName.Image = ((System.Drawing.Image)(resources.GetObject("button_setup_docName.Image")));
            this.button_setup_docName.Location = new System.Drawing.Point(199, 88);
            this.button_setup_docName.Name = "button_setup_docName";
            this.button_setup_docName.Size = new System.Drawing.Size(32, 29);
            this.button_setup_docName.TabIndex = 8;
            this.button_setup_docName.UseVisualStyleBackColor = false;
            // 
            // checkBox_use_docName
            // 
            this.checkBox_use_docName.AutoSize = true;
            this.checkBox_use_docName.Location = new System.Drawing.Point(14, 93);
            this.checkBox_use_docName.Name = "checkBox_use_docName";
            this.checkBox_use_docName.Size = new System.Drawing.Size(167, 21);
            this.checkBox_use_docName.TabIndex = 7;
            this.checkBox_use_docName.Text = "Название документа";
            this.checkBox_use_docName.UseVisualStyleBackColor = true;
            this.checkBox_use_docName.CheckedChanged += new System.EventHandler(this.checkBox_use_docName_CheckedChanged);
            // 
            // button_setup_axisNames
            // 
            this.button_setup_axisNames.BackColor = System.Drawing.Color.White;
            this.button_setup_axisNames.Enabled = false;
            this.button_setup_axisNames.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_setup_axisNames.FlatAppearance.BorderSize = 2;
            this.button_setup_axisNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_setup_axisNames.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_setup_axisNames.Image = ((System.Drawing.Image)(resources.GetObject("button_setup_axisNames.Image")));
            this.button_setup_axisNames.Location = new System.Drawing.Point(199, 54);
            this.button_setup_axisNames.Name = "button_setup_axisNames";
            this.button_setup_axisNames.Size = new System.Drawing.Size(32, 29);
            this.button_setup_axisNames.TabIndex = 6;
            this.button_setup_axisNames.UseVisualStyleBackColor = false;
            // 
            // checkBox_use_axisNames
            // 
            this.checkBox_use_axisNames.AutoSize = true;
            this.checkBox_use_axisNames.Location = new System.Drawing.Point(14, 59);
            this.checkBox_use_axisNames.Name = "checkBox_use_axisNames";
            this.checkBox_use_axisNames.Size = new System.Drawing.Size(125, 21);
            this.checkBox_use_axisNames.TabIndex = 5;
            this.checkBox_use_axisNames.Text = "Название осей";
            this.checkBox_use_axisNames.UseVisualStyleBackColor = true;
            this.checkBox_use_axisNames.CheckedChanged += new System.EventHandler(this.checkBox_use_axisNames_CheckedChanged);
            // 
            // button_setup_axis
            // 
            this.button_setup_axis.BackColor = System.Drawing.Color.White;
            this.button_setup_axis.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_setup_axis.FlatAppearance.BorderSize = 2;
            this.button_setup_axis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_setup_axis.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_setup_axis.Image = ((System.Drawing.Image)(resources.GetObject("button_setup_axis.Image")));
            this.button_setup_axis.Location = new System.Drawing.Point(199, 20);
            this.button_setup_axis.Name = "button_setup_axis";
            this.button_setup_axis.Size = new System.Drawing.Size(32, 29);
            this.button_setup_axis.TabIndex = 4;
            this.button_setup_axis.UseVisualStyleBackColor = false;
            this.button_setup_axis.Click += new System.EventHandler(this.button_setup_axis_Click);
            // 
            // checkBox_use_axis
            // 
            this.checkBox_use_axis.AutoSize = true;
            this.checkBox_use_axis.Checked = true;
            this.checkBox_use_axis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_use_axis.Location = new System.Drawing.Point(14, 25);
            this.checkBox_use_axis.Name = "checkBox_use_axis";
            this.checkBox_use_axis.Size = new System.Drawing.Size(53, 21);
            this.checkBox_use_axis.TabIndex = 0;
            this.checkBox_use_axis.Text = "Оси";
            this.checkBox_use_axis.UseVisualStyleBackColor = true;
            this.checkBox_use_axis.CheckedChanged += new System.EventHandler(this.checkBox_use_axis_CheckedChanged);
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.BackColor = System.Drawing.Color.White;
            this.labelHint.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHint.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelHint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHint.Location = new System.Drawing.Point(190, 306);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(496, 32);
            this.labelHint.TabIndex = 9;
            this.labelHint.Text = "Добавьте графики для начала работы...\r\n";
            // 
            // label_zoom
            // 
            this.label_zoom.AutoSize = true;
            this.label_zoom.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.label_zoom.Location = new System.Drawing.Point(14, 599);
            this.label_zoom.Name = "label_zoom";
            this.label_zoom.Size = new System.Drawing.Size(0, 17);
            this.label_zoom.TabIndex = 10;
            // 
            // timer_redraw
            // 
            this.timer_redraw.Interval = 500;
            this.timer_redraw.Tick += new System.EventHandler(this.timer_redraw_Tick);
            // 
            // panel_tools
            // 
            this.panel_tools.Controls.Add(this.button3);
            this.panel_tools.Controls.Add(this.button2);
            this.panel_tools.Controls.Add(this.button1);
            this.panel_tools.Controls.Add(this.label_zoom);
            this.panel_tools.Controls.Add(this.groupBox2);
            this.panel_tools.Controls.Add(this.groupBox1);
            this.panel_tools.Controls.Add(this.trackBar1);
            this.panel_tools.Location = new System.Drawing.Point(873, 2);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(270, 661);
            this.panel_tools.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(113, 529);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 40);
            this.button3.TabIndex = 16;
            this.button3.Text = "Загр";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(19, 529);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 40);
            this.button2.TabIndex = 5;
            this.button2.Text = "Сохр";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(226, 614);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 45);
            this.button1.TabIndex = 15;
            this.button1.Text = "С";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_y);
            this.panel1.Controls.Add(this.label_x);
            this.panel1.Location = new System.Drawing.Point(12, 616);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 47);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_y.Location = new System.Drawing.Point(3, 25);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(46, 17);
            this.label_y.TabIndex = 1;
            this.label_y.Text = "label2";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_x.Location = new System.Drawing.Point(3, 5);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(46, 17);
            this.label_x.TabIndex = 0;
            this.label_x.Text = "label1";
            // 
            // panel_wait
            // 
            this.panel_wait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.panel_wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_wait.Controls.Add(this.loadingCircle_tab1);
            this.panel_wait.Controls.Add(this.label_load);
            this.panel_wait.Font = new System.Drawing.Font("Cambria", 12F);
            this.panel_wait.Location = new System.Drawing.Point(390, 255);
            this.panel_wait.Name = "panel_wait";
            this.panel_wait.Size = new System.Drawing.Size(361, 164);
            this.panel_wait.TabIndex = 16;
            this.panel_wait.Visible = false;
            // 
            // loadingCircle_tab1
            // 
            this.loadingCircle_tab1.Active = true;
            this.loadingCircle_tab1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle_tab1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle_tab1.BackgroundImage")));
            this.loadingCircle_tab1.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle_tab1.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle_tab1.InnerCircleRadius = 5;
            this.loadingCircle_tab1.Location = new System.Drawing.Point(137, 11);
            this.loadingCircle_tab1.Name = "loadingCircle_tab1";
            this.loadingCircle_tab1.NumberSpoke = 12;
            this.loadingCircle_tab1.OuterCircleRadius = 11;
            this.loadingCircle_tab1.RotationSpeed = 100;
            this.loadingCircle_tab1.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle_tab1.SpokeThickness = 2;
            this.loadingCircle_tab1.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle_tab1.TabIndex = 31;
            this.loadingCircle_tab1.Text = "loadingCircle2";
            this.loadingCircle_tab1.UseWaitCursor = true;
            // 
            // label_load
            // 
            this.label_load.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_load.Location = new System.Drawing.Point(-1, 89);
            this.label_load.Name = "label_load";
            this.label_load.Size = new System.Drawing.Size(361, 73);
            this.label_load.TabIndex = 0;
            this.label_load.Text = "Подождите, пока идет загрузка и \r\nобработка данных. Это может занять\r\nдо пары мин" +
    "ут.";
            this.label_load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_loaderr
            // 
            this.panel_loaderr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.panel_loaderr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_loaderr.Controls.Add(this.button_loaderr_more);
            this.panel_loaderr.Controls.Add(this.button_loaderr_close);
            this.panel_loaderr.Controls.Add(this.label1);
            this.panel_loaderr.Font = new System.Drawing.Font("Cambria", 12F);
            this.panel_loaderr.Location = new System.Drawing.Point(99, 70);
            this.panel_loaderr.Name = "panel_loaderr";
            this.panel_loaderr.Size = new System.Drawing.Size(361, 164);
            this.panel_loaderr.TabIndex = 32;
            this.panel_loaderr.Visible = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(-1, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Обнаружены ошибки при загрузке документа.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_loaderr_close
            // 
            this.button_loaderr_close.BackColor = System.Drawing.Color.White;
            this.button_loaderr_close.Enabled = false;
            this.button_loaderr_close.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_loaderr_close.FlatAppearance.BorderSize = 2;
            this.button_loaderr_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_loaderr_close.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_loaderr_close.Location = new System.Drawing.Point(186, 117);
            this.button_loaderr_close.Name = "button_loaderr_close";
            this.button_loaderr_close.Size = new System.Drawing.Size(106, 40);
            this.button_loaderr_close.TabIndex = 5;
            this.button_loaderr_close.Text = "Закрiть";
            this.button_loaderr_close.UseVisualStyleBackColor = false;
            // 
            // button_loaderr_more
            // 
            this.button_loaderr_more.BackColor = System.Drawing.Color.White;
            this.button_loaderr_more.Enabled = false;
            this.button_loaderr_more.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_loaderr_more.FlatAppearance.BorderSize = 2;
            this.button_loaderr_more.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_loaderr_more.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_loaderr_more.Location = new System.Drawing.Point(74, 117);
            this.button_loaderr_more.Name = "button_loaderr_more";
            this.button_loaderr_more.Size = new System.Drawing.Size(106, 40);
            this.button_loaderr_more.TabIndex = 6;
            this.button_loaderr_more.Text = "Подробнее";
            this.button_loaderr_more.UseVisualStyleBackColor = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pcgraph";
            this.saveFileDialog1.FileName = "graph";
            this.saveFileDialog1.Filter = "PC Graph|*.pcgraph|XML File|*.xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "pcgraph";
            this.openFileDialog1.FileName = "graph";
            this.openFileDialog1.Filter = "PC Graph|*.pcgraph|XML File|*.xml";
            // 
            // Form_Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1140, 675);
            this.Controls.Add(this.panel_loaderr);
            this.Controls.Add(this.panel_wait);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_tools);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 714);
            this.Name = "Form_Graph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Построение графиков";
            this.Load += new System.EventHandler(this.Form_Graph_Load);
            this.SizeChanged += new System.EventHandler(this.Form_Graph_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel_tools.ResumeLayout(false);
            this.panel_tools.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_wait.ResumeLayout(false);
            this.panel_loaderr.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Main;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_setup_axis;
        private System.Windows.Forms.CheckBox checkBox_use_axis;
        private System.Windows.Forms.Button button_setup_addPoints;
        private System.Windows.Forms.CheckBox checkBox_use_addPoints;
        private System.Windows.Forms.Button button_setup_legend;
        private System.Windows.Forms.CheckBox checkBox_use_legend;
        private System.Windows.Forms.Button button_setup_grid;
        private System.Windows.Forms.CheckBox checkBox_use_Grid;
        private System.Windows.Forms.Button button_setup_docName;
        private System.Windows.Forms.CheckBox checkBox_use_docName;
        private System.Windows.Forms.Button button_setup_axisNames;
        private System.Windows.Forms.CheckBox checkBox_use_axisNames;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.Label label_zoom;
        private System.Windows.Forms.Timer timer_redraw;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Panel panel_tools;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel_wait;
        private MRG.Controls.UI.LoadingCircle loadingCircle_tab1;
        private System.Windows.Forms.Label label_load;
        private System.Windows.Forms.Panel panel_loaderr;
        private System.Windows.Forms.Button button_loaderr_more;
        private System.Windows.Forms.Button button_loaderr_close;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
