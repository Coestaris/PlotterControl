/*=================================\
* PlotterControl\Form_ViewVect.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 12.09.2017 21:02:57
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.label_status = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_filename = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_resolution = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_oldprstyle = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_print = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_dispType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem_color = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_backgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_selectedColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_defDisp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_resetZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_cont = new System.Windows.Forms.Panel();
            this.panel_zoom = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label_zoom_max = new System.Windows.Forms.Label();
            this.label_zoom_min = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel_cont.SuspendLayout();
            this.panel_zoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Items.AddRange(new object[] {
            "contours"});
            this.listBox1.Location = new System.Drawing.Point(6, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 242);
            this.listBox1.TabIndex = 13;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.statusStrip1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_main.Location = new System.Drawing.Point(9, 9);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(615, 592);
            this.pictureBox_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_main.TabIndex = 16;
            this.pictureBox_main.TabStop = false;
            this.pictureBox_main.Visible = false;
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
            this.loadingCircle1.Location = new System.Drawing.Point(115, 471);
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
            this.label_status.Location = new System.Drawing.Point(100, 501);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(90, 17);
            this.label_status.TabIndex = 33;
            this.label_status.Text = "Отрисовка...";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_status.Visible = false;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_open,
            this.toolStripMenuItem_close,
            this.toolStripSeparator2,
            this.toolStripMenuItem_edit,
            this.toolStripMenuItem_saveAs,
            this.toolStripMenuItem_print,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ToolStripMenuItem_open
            // 
            this.ToolStripMenuItem_open.Name = "ToolStripMenuItem_open";
            this.ToolStripMenuItem_open.Size = new System.Drawing.Size(114, 22);
            this.ToolStripMenuItem_open.Text = "Open";
            this.ToolStripMenuItem_open.Click += new System.EventHandler(this.button4_Click);
            // 
            // toolStripMenuItem_close
            // 
            this.toolStripMenuItem_close.Name = "toolStripMenuItem_close";
            this.toolStripMenuItem_close.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenuItem_close.Text = "Close";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
            // 
            // toolStripMenuItem_edit
            // 
            this.toolStripMenuItem_edit.Name = "toolStripMenuItem_edit";
            this.toolStripMenuItem_edit.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenuItem_edit.Text = "Edit";
            // 
            // toolStripMenuItem_saveAs
            // 
            this.toolStripMenuItem_saveAs.Name = "toolStripMenuItem_saveAs";
            this.toolStripMenuItem_saveAs.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenuItem_saveAs.Text = "Save As";
            // 
            // toolStripMenuItem_print
            // 
            this.toolStripMenuItem_print.Name = "toolStripMenuItem_print";
            this.toolStripMenuItem_print.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenuItem_print.Text = "Print";
            this.toolStripMenuItem_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // ToolStripMenuItem_exit
            // 
            this.ToolStripMenuItem_exit.Name = "ToolStripMenuItem_exit";
            this.ToolStripMenuItem_exit.Size = new System.Drawing.Size(114, 22);
            this.ToolStripMenuItem_exit.Text = "Exit";
            this.ToolStripMenuItem_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_dispType,
            this.toolStripMenuItem_color,
            this.toolStripMenuItem_backgroundColor,
            this.toolStripMenuItem_selectedColor,
            this.toolStripSeparator3,
            this.toolStripMenuItem_defDisp,
            this.toolStripMenuItem_resetZoom});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolStripComboBox_dispType
            // 
            this.toolStripComboBox_dispType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_dispType.Items.AddRange(new object[] {
            "Random Color",
            "Заданные цвета"});
            this.toolStripComboBox_dispType.Name = "toolStripComboBox_dispType";
            this.toolStripComboBox_dispType.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox_dispType.Click += new System.EventHandler(this.toolStripComboBox_dispType_Click);
            // 
            // toolStripMenuItem_color
            // 
            this.toolStripMenuItem_color.Name = "toolStripMenuItem_color";
            this.toolStripMenuItem_color.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_color.Text = "Cotour Color";
            this.toolStripMenuItem_color.Click += new System.EventHandler(this.toolStripMenuItem_color_Click);
            // 
            // toolStripMenuItem_backgroundColor
            // 
            this.toolStripMenuItem_backgroundColor.Name = "toolStripMenuItem_backgroundColor";
            this.toolStripMenuItem_backgroundColor.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_backgroundColor.Text = "Background Color";
            this.toolStripMenuItem_backgroundColor.Click += new System.EventHandler(this.toolStripMenuItem_backgroundColor_Click);
            // 
            // toolStripMenuItem_selectedColor
            // 
            this.toolStripMenuItem_selectedColor.Name = "toolStripMenuItem_selectedColor";
            this.toolStripMenuItem_selectedColor.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_selectedColor.Text = "Selected Color";
            this.toolStripMenuItem_selectedColor.Click += new System.EventHandler(this.toolStripMenuItem_selectedColor_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem_defDisp
            // 
            this.toolStripMenuItem_defDisp.Name = "toolStripMenuItem_defDisp";
            this.toolStripMenuItem_defDisp.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_defDisp.Text = "Default display";
            this.toolStripMenuItem_defDisp.Click += new System.EventHandler(this.toolStripMenuItem_defDisp_Click);
            // 
            // toolStripMenuItem_resetZoom
            // 
            this.toolStripMenuItem_resetZoom.Name = "toolStripMenuItem_resetZoom";
            this.toolStripMenuItem_resetZoom.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem_resetZoom.Text = "Reset Zoom";
            this.toolStripMenuItem_resetZoom.Click += new System.EventHandler(this.toolStripMenuItem_resetZoom_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contoursToolStripMenuItem,
            this.infoStripToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // contoursToolStripMenuItem
            // 
            this.contoursToolStripMenuItem.Name = "contoursToolStripMenuItem";
            this.contoursToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.contoursToolStripMenuItem.Text = "Contours";
            this.contoursToolStripMenuItem.Click += new System.EventHandler(this.contoursToolStripMenuItem_Click);
            // 
            // infoStripToolStripMenuItem
            // 
            this.infoStripToolStripMenuItem.Name = "infoStripToolStripMenuItem";
            this.infoStripToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.infoStripToolStripMenuItem.Text = "Info strip";
            this.infoStripToolStripMenuItem.Click += new System.EventHandler(this.infoStripToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // panel_cont
            // 
            this.panel_cont.Controls.Add(this.listBox1);
            this.panel_cont.Location = new System.Drawing.Point(10, 30);
            this.panel_cont.Name = "panel_cont";
            this.panel_cont.Size = new System.Drawing.Size(257, 252);
            this.panel_cont.TabIndex = 39;
            // 
            // panel_zoom
            // 
            this.panel_zoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_zoom.Controls.Add(this.label3);
            this.panel_zoom.Controls.Add(this.label_zoom_max);
            this.panel_zoom.Controls.Add(this.label_zoom_min);
            this.panel_zoom.Controls.Add(this.trackBar1);
            this.panel_zoom.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.panel_zoom.Location = new System.Drawing.Point(4, 572);
            this.panel_zoom.Name = "panel_zoom";
            this.panel_zoom.Size = new System.Drawing.Size(257, 61);
            this.panel_zoom.TabIndex = 40;
            this.panel_zoom.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label_zoom_max
            // 
            this.label_zoom_max.AutoSize = true;
            this.label_zoom_max.Location = new System.Drawing.Point(208, 40);
            this.label_zoom_max.Name = "label_zoom_max";
            this.label_zoom_max.Size = new System.Drawing.Size(46, 17);
            this.label_zoom_max.TabIndex = 2;
            this.label_zoom_max.Text = "label2";
            // 
            // label_zoom_min
            // 
            this.label_zoom_min.AutoSize = true;
            this.label_zoom_min.Location = new System.Drawing.Point(3, 40);
            this.label_zoom_min.Name = "label_zoom_min";
            this.label_zoom_min.Size = new System.Drawing.Size(46, 17);
            this.label_zoom_min.TabIndex = 1;
            this.label_zoom_min.Text = "label1";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(3, 8);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(247, 45);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label);
            this.panel3.Controls.Add(this.pictureBox_main);
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(912, 623);
            this.panel3.TabIndex = 41;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(335, 274);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(307, 25);
            this.label.TabIndex = 17;
            this.label.Text = "Для просмотра выберите файл";
            // 
            // Form_ViewVect
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(912, 672);
            this.Controls.Add(this.panel_zoom);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_cont);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.loadingCircle1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_ViewVect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View vector";
            this.Load += new System.EventHandler(this.Form_ViewVect_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_viewvect_DragDropEnter);
            this.Resize += new System.EventHandler(this.Form_ViewVect_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_cont.ResumeLayout(false);
            this.panel_zoom.ResumeLayout(false);
            this.panel_zoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.PictureBox pictureBox_main;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public MRG.Controls.UI.LoadingCircle loadingCircle1;
        public System.Windows.Forms.Label label_status;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_filename;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_resolution;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_oldprstyle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_open;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_saveAs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_exit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_dispType;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_color;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_backgroundColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_selectedColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_resetZoom;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_defDisp;
        private System.Windows.Forms.Panel panel_cont;
        private System.Windows.Forms.Panel panel_zoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_zoom_max;
        private System.Windows.Forms.Label label_zoom_min;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label;
    }
}
