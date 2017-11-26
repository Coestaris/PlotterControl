/*=================================\
* PlotterControl\Form_Dialog_PrintEnterName.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 09.08.2017 14:57
* Last Edited: 27.08.2017 14:30:46
*=================================*/

namespace CnC_WFA
{
    partial class Form_Dialog_PrintEnterNames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dialog_PrintEnterNames));
            this.button_ok = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.loadingCircle_previewLoad = new MRG.Controls.UI.LoadingCircle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox_pcName = new System.Windows.Forms.TextBox();
            this.label_pc = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("Cambria", 12F);
            this.button_ok.Location = new System.Drawing.Point(343, 81);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(82, 30);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Cambria", 12F);
            this.textBox_name.Location = new System.Drawing.Point(142, 49);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(283, 26);
            this.textBox_name.TabIndex = 1;
            this.textBox_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_name_KeyDown);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Cambria", 12F);
            this.button_cancel.Location = new System.Drawing.Point(245, 81);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(82, 30);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // loadingCircle_previewLoad
            // 
            this.loadingCircle_previewLoad.Active = true;
            this.loadingCircle_previewLoad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loadingCircle_previewLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingCircle_previewLoad.BackgroundImage")));
            this.loadingCircle_previewLoad.Color = System.Drawing.SystemColors.MenuHighlight;
            this.loadingCircle_previewLoad.ForeColor = System.Drawing.Color.Transparent;
            this.loadingCircle_previewLoad.InnerCircleRadius = 5;
            this.loadingCircle_previewLoad.Location = new System.Drawing.Point(178, 16);
            this.loadingCircle_previewLoad.Name = "loadingCircle_previewLoad";
            this.loadingCircle_previewLoad.NumberSpoke = 12;
            this.loadingCircle_previewLoad.OuterCircleRadius = 11;
            this.loadingCircle_previewLoad.RotationSpeed = 100;
            this.loadingCircle_previewLoad.Size = new System.Drawing.Size(75, 75);
            this.loadingCircle_previewLoad.SpokeThickness = 2;
            this.loadingCircle_previewLoad.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle_previewLoad.TabIndex = 33;
            this.loadingCircle_previewLoad.Text = "loadingCircle2";
            this.loadingCircle_previewLoad.UseWaitCursor = true;
            this.loadingCircle_previewLoad.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // textBox_pcName
            // 
            this.textBox_pcName.Font = new System.Drawing.Font("Cambria", 12F);
            this.textBox_pcName.Location = new System.Drawing.Point(142, 13);
            this.textBox_pcName.Name = "textBox_pcName";
            this.textBox_pcName.Size = new System.Drawing.Size(252, 26);
            this.textBox_pcName.TabIndex = 34;
            // 
            // label_pc
            // 
            this.label_pc.AutoSize = true;
            this.label_pc.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_pc.Location = new System.Drawing.Point(12, 16);
            this.label_pc.Name = "label_pc";
            this.label_pc.Size = new System.Drawing.Size(124, 19);
            this.label_pc.TabIndex = 35;
            this.label_pc.Text = "Путь к вектору:";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Cambria", 12F);
            this.label_name.Location = new System.Drawing.Point(12, 52);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(111, 19);
            this.label_name.TabIndex = 36;
            this.label_name.Text = "Имя вектора: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 27);
            this.button1.TabIndex = 37;
            this.button1.Text = "P";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "VectFile.pcv";
            this.openFileDialog1.Filter = "PrRes Files(*.pcv)|*.pcv|PrRes Files(*.prres)|*.prres";
            // 
            // Form_Dialog_PrintEnterNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(437, 124);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadingCircle_previewLoad);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_pc);
            this.Controls.Add(this.textBox_pcName);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Dialog_PrintEnterNames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправка вектора на устройство";
            this.Load += new System.EventHandler(this.EnterNameDialog_Load);
            this.Shown += new System.EventHandler(this.EnterNameDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button_ok;
        public System.Windows.Forms.TextBox textBox_name;
        public System.Windows.Forms.Button button_cancel;
        public MRG.Controls.UI.LoadingCircle loadingCircle_previewLoad;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.TextBox textBox_pcName;
        public System.Windows.Forms.Label label_pc;
        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
