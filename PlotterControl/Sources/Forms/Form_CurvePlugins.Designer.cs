namespace CnC_WFA
{
    partial class Form_CurvePlugins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CurvePlugins));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_wait = new System.Windows.Forms.Panel();
            this.label_load = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_usage_content = new System.Windows.Forms.Label();
            this.label_usage_discr = new System.Windows.Forms.Label();
            this.label_prev_2 = new System.Windows.Forms.Label();
            this.label_prev_1 = new System.Windows.Forms.Label();
            this.label_discr_title = new System.Windows.Forms.Label();
            this.label_discr_content = new System.Windows.Forms.Label();
            this.label_creator_content = new System.Windows.Forms.Label();
            this.label_creator_name = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.pictureBox_prev_1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_prev_2 = new System.Windows.Forms.PictureBox();
            this.panel_content = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.loadingCircle_tab1 = new MRG.Controls.UI.LoadingCircle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel_main.SuspendLayout();
            this.panel_wait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prev_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prev_2)).BeginInit();
            this.panel_content.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(77)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Cambria", 12F);
            this.listBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(8, 10);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 627);
            this.listBox1.TabIndex = 15;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel_main
            // 
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Controls.Add(this.button2);
            this.panel_main.Controls.Add(this.button1);
            this.panel_main.Controls.Add(this.label_usage_content);
            this.panel_main.Controls.Add(this.label_usage_discr);
            this.panel_main.Controls.Add(this.label_prev_2);
            this.panel_main.Controls.Add(this.label_prev_1);
            this.panel_main.Controls.Add(this.label_discr_title);
            this.panel_main.Controls.Add(this.label_discr_content);
            this.panel_main.Controls.Add(this.label_creator_content);
            this.panel_main.Controls.Add(this.label_creator_name);
            this.panel_main.Controls.Add(this.label_Title);
            this.panel_main.Controls.Add(this.pictureBox_prev_1);
            this.panel_main.Controls.Add(this.pictureBox_prev_2);
            this.panel_main.Font = new System.Drawing.Font("Cambria", 12F);
            this.panel_main.Location = new System.Drawing.Point(254, -1);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1022, 707);
            this.panel_main.TabIndex = 14;
            this.panel_main.Visible = false;
            // 
            // panel_wait
            // 
            this.panel_wait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.panel_wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_wait.Controls.Add(this.loadingCircle_tab1);
            this.panel_wait.Controls.Add(this.label_load);
            this.panel_wait.Font = new System.Drawing.Font("Cambria", 12F);
            this.panel_wait.Location = new System.Drawing.Point(317, 356);
            this.panel_wait.Name = "panel_wait";
            this.panel_wait.Size = new System.Drawing.Size(361, 164);
            this.panel_wait.TabIndex = 15;
            // 
            // label_load
            // 
            this.label_load.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_load.Location = new System.Drawing.Point(-1, 89);
            this.label_load.Name = "label_load";
            this.label_load.Size = new System.Drawing.Size(361, 73);
            this.label_load.TabIndex = 0;
            this.label_load.Text = "Подождите, пока компилируются и\r\nподготавливаются плагины. Это может занять\r\nодно" +
    "й до минуты.";
            this.label_load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cambria", 12F);
            this.button2.Location = new System.Drawing.Point(141, 641);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 56);
            this.button2.TabIndex = 14;
            this.button2.Text = "Подробнее\r\n(Wikipedia)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cambria", 12F);
            this.button1.Location = new System.Drawing.Point(12, 641);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 56);
            this.button1.TabIndex = 13;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label_usage_content
            // 
            this.label_usage_content.Location = new System.Drawing.Point(30, 160);
            this.label_usage_content.Name = "label_usage_content";
            this.label_usage_content.Size = new System.Drawing.Size(655, 23);
            this.label_usage_content.TabIndex = 12;
            this.label_usage_content.Text = "label2";
            // 
            // label_usage_discr
            // 
            this.label_usage_discr.AutoSize = true;
            this.label_usage_discr.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label_usage_discr.Location = new System.Drawing.Point(30, 135);
            this.label_usage_discr.Name = "label_usage_discr";
            this.label_usage_discr.Size = new System.Drawing.Size(105, 19);
            this.label_usage_discr.TabIndex = 11;
            this.label_usage_discr.Text = "Применение";
            // 
            // label_prev_2
            // 
            this.label_prev_2.Location = new System.Drawing.Point(704, 657);
            this.label_prev_2.Name = "label_prev_2";
            this.label_prev_2.Size = new System.Drawing.Size(300, 38);
            this.label_prev_2.TabIndex = 10;
            this.label_prev_2.Text = "label1";
            this.label_prev_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_prev_1
            // 
            this.label_prev_1.Location = new System.Drawing.Point(704, 311);
            this.label_prev_1.Name = "label_prev_1";
            this.label_prev_1.Size = new System.Drawing.Size(300, 38);
            this.label_prev_1.TabIndex = 9;
            this.label_prev_1.Text = "label1";
            this.label_prev_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_discr_title
            // 
            this.label_discr_title.AutoSize = true;
            this.label_discr_title.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label_discr_title.Location = new System.Drawing.Point(30, 50);
            this.label_discr_title.Name = "label_discr_title";
            this.label_discr_title.Size = new System.Drawing.Size(85, 19);
            this.label_discr_title.TabIndex = 8;
            this.label_discr_title.Text = "Описание";
            // 
            // label_discr_content
            // 
            this.label_discr_content.Location = new System.Drawing.Point(30, 75);
            this.label_discr_content.Name = "label_discr_content";
            this.label_discr_content.Size = new System.Drawing.Size(655, 23);
            this.label_discr_content.TabIndex = 7;
            this.label_discr_content.Text = "label2";
            // 
            // label_creator_content
            // 
            this.label_creator_content.Location = new System.Drawing.Point(30, 118);
            this.label_creator_content.Name = "label_creator_content";
            this.label_creator_content.Size = new System.Drawing.Size(655, 23);
            this.label_creator_content.TabIndex = 6;
            this.label_creator_content.Text = "label2";
            // 
            // label_creator_name
            // 
            this.label_creator_name.AutoSize = true;
            this.label_creator_name.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label_creator_name.Location = new System.Drawing.Point(30, 93);
            this.label_creator_name.Name = "label_creator_name";
            this.label_creator_name.Size = new System.Drawing.Size(75, 19);
            this.label_creator_name.TabIndex = 5;
            this.label_creator_name.Text = "История";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Bold);
            this.label_Title.Location = new System.Drawing.Point(17, 20);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(47, 23);
            this.label_Title.TabIndex = 4;
            this.label_Title.Text = "title";
            // 
            // pictureBox_prev_1
            // 
            this.pictureBox_prev_1.Location = new System.Drawing.Point(704, 11);
            this.pictureBox_prev_1.Name = "pictureBox_prev_1";
            this.pictureBox_prev_1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_prev_1.TabIndex = 3;
            this.pictureBox_prev_1.TabStop = false;
            // 
            // pictureBox_prev_2
            // 
            this.pictureBox_prev_2.Location = new System.Drawing.Point(704, 352);
            this.pictureBox_prev_2.Name = "pictureBox_prev_2";
            this.pictureBox_prev_2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_prev_2.TabIndex = 1;
            this.pictureBox_prev_2.TabStop = false;
            // 
            // panel_content
            // 
            this.panel_content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(77)))));
            this.panel_content.Controls.Add(this.button3);
            this.panel_content.Location = new System.Drawing.Point(-23, -30);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(282, 738);
            this.panel_content.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Cambria", 12F);
            this.button3.Location = new System.Drawing.Point(31, 686);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 38);
            this.button3.TabIndex = 15;
            this.button3.Text = "Обновить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form_CurvePlugins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1274, 704);
            this.Controls.Add(this.panel_wait);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CurvePlugins";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мастер кривых";
            this.Load += new System.EventHandler(this.Form_CurvePlugins_Load);
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.panel_wait.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prev_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prev_2)).EndInit();
            this.panel_content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_usage_content;
        private System.Windows.Forms.Label label_usage_discr;
        private System.Windows.Forms.Label label_prev_2;
        private System.Windows.Forms.Label label_prev_1;
        private System.Windows.Forms.Label label_discr_title;
        private System.Windows.Forms.Label label_discr_content;
        private System.Windows.Forms.Label label_creator_content;
        private System.Windows.Forms.Label label_creator_name;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.PictureBox pictureBox_prev_1;
        private System.Windows.Forms.PictureBox pictureBox_prev_2;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel_wait;
        private System.Windows.Forms.Label label_load;
        private MRG.Controls.UI.LoadingCircle loadingCircle_tab1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}