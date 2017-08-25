/*=================================\
* PlotterControl\Form_Dialog_EditElement.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 19.08.2017 7:38:22
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_markers = new System.Windows.Forms.Button();
            this.button_display = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_axis = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_axis_display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_axis_color)).BeginInit();
            this.groupBox_axis_param.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.panel3.Controls.Add(this.button_markers);
            this.panel3.Controls.Add(this.button_display);
            this.panel3.Controls.Add(this.button_exit);
            this.panel3.Controls.Add(this.button_axis);
            this.panel3.Location = new System.Drawing.Point(-9, -12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 361);
            this.panel3.TabIndex = 14;
            // 
            // button_markers
            // 
            this.button_markers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_markers.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_markers.FlatAppearance.BorderSize = 2;
            this.button_markers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_markers.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_markers.ForeColor = System.Drawing.Color.White;
            this.button_markers.Location = new System.Drawing.Point(18, 108);
            this.button_markers.Name = "button_markers";
            this.button_markers.Size = new System.Drawing.Size(122, 36);
            this.button_markers.TabIndex = 38;
            this.button_markers.Text = "Маркеры";
            this.button_markers.UseVisualStyleBackColor = false;
            // 
            // button_display
            // 
            this.button_display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.button_display.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_display.FlatAppearance.BorderSize = 2;
            this.button_display.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_display.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_display.ForeColor = System.Drawing.Color.White;
            this.button_display.Location = new System.Drawing.Point(18, 66);
            this.button_display.Name = "button_display";
            this.button_display.Size = new System.Drawing.Size(122, 36);
            this.button_display.TabIndex = 37;
            this.button_display.Text = "Отображение";
            this.button_display.UseVisualStyleBackColor = false;
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(124, -24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 378);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage1.Controls.Add(this.checkBox_axis_show);
            this.tabPage1.Controls.Add(this.groupBox_axis_display);
            this.tabPage1.Controls.Add(this.groupBox_axis_param);
            this.tabPage1.Controls.Add(this.label_axis_label);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(533, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
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
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(533, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
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
            this.Load += new System.EventHandler(this.Form_Dialog_EditElement_Load);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox_axis_display.ResumeLayout(false);
            this.groupBox_axis_display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_axis_color)).EndInit();
            this.groupBox_axis_param.ResumeLayout(false);
            this.groupBox_axis_param.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_markers;
        private System.Windows.Forms.Button button_display;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_axis;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}
