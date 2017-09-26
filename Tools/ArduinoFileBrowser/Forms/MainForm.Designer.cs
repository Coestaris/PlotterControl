/*=================================\
* ArduinoFileBrowser\MainForm.Designer.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:41
* Last Edited: 26.09.2017 21:40:01
*=================================*/

namespace FileBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label_path = new System.Windows.Forms.Label();
            this.button_rec = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1_prop = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirtoolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.createFiletoolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_info = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 45);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(665, 400);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_path.Location = new System.Drawing.Point(12, 19);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(39, 14);
            this.label_path.TabIndex = 1;
            this.label_path.Text = "label1";
            // 
            // button_rec
            // 
            this.button_rec.BackColor = System.Drawing.Color.White;
            this.button_rec.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_rec.FlatAppearance.BorderSize = 2;
            this.button_rec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rec.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_rec.Location = new System.Drawing.Point(593, 10);
            this.button_rec.Name = "button_rec";
            this.button_rec.Size = new System.Drawing.Size(84, 29);
            this.button_rec.TabIndex = 2;
            this.button_rec.Text = "Receive File";
            this.button_rec.UseVisualStyleBackColor = false;
            this.button_rec.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_send
            // 
            this.button_send.BackColor = System.Drawing.Color.White;
            this.button_send.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_send.FlatAppearance.BorderSize = 2;
            this.button_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_send.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_send.Location = new System.Drawing.Point(503, 10);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(84, 29);
            this.button_send.TabIndex = 4;
            this.button_send.Text = "Send File";
            this.button_send.UseVisualStyleBackColor = false;
            this.button_send.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.Color.White;
            this.button_refresh.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_refresh.FlatAppearance.BorderSize = 2;
            this.button_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_refresh.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_refresh.Location = new System.Drawing.Point(422, 10);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 29);
            this.button_refresh.TabIndex = 5;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1_prop,
            this.deleteToolStripMenuItem,
            this.copyNameToolStripMenuItem,
            this.toolStripSeparator2,
            this.createToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 126);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem1_prop
            // 
            this.toolStripMenuItem1_prop.Name = "toolStripMenuItem1_prop";
            this.toolStripMenuItem1_prop.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem1_prop.Text = "Свойства";
            this.toolStripMenuItem1_prop.Click += new System.EventHandler(this.toolStripMenuItem1_prop_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.button5_Click);
            // 
            // copyNameToolStripMenuItem
            // 
            this.copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            this.copyNameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyNameToolStripMenuItem.Text = "Скопировать имя";
            this.copyNameToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirToolStripMenuItem,
            this.createFileToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.createToolStripMenuItem.Text = "Создать";
            // 
            // createDirToolStripMenuItem
            // 
            this.createDirToolStripMenuItem.Name = "createDirToolStripMenuItem";
            this.createDirToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.createDirToolStripMenuItem.Text = "Папку";
            this.createDirToolStripMenuItem.Click += new System.EventHandler(this.createDirToolStripMenuItem_Click);
            // 
            // createFileToolStripMenuItem
            // 
            this.createFileToolStripMenuItem.Name = "createFileToolStripMenuItem";
            this.createFileToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.createFileToolStripMenuItem.Text = "Пустой файл";
            this.createFileToolStripMenuItem.Click += new System.EventHandler(this.createFileToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(129, 48);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirtoolStripMenuItem5,
            this.createFiletoolStripMenuItem6});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem4.Text = "Создать";
            // 
            // createDirtoolStripMenuItem5
            // 
            this.createDirtoolStripMenuItem5.Name = "createDirtoolStripMenuItem5";
            this.createDirtoolStripMenuItem5.Size = new System.Drawing.Size(146, 22);
            this.createDirtoolStripMenuItem5.Text = "Папку";
            this.createDirtoolStripMenuItem5.Click += new System.EventHandler(this.createDirToolStripMenuItem_Click);
            // 
            // createFiletoolStripMenuItem6
            // 
            this.createFiletoolStripMenuItem6.Name = "createFiletoolStripMenuItem6";
            this.createFiletoolStripMenuItem6.Size = new System.Drawing.Size(146, 22);
            this.createFiletoolStripMenuItem6.Text = "Пустой файл";
            this.createFiletoolStripMenuItem6.Click += new System.EventHandler(this.createFileToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.refreshToolStripMenuItem.Text = "Обновить";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_info
            // 
            this.button_info.BackColor = System.Drawing.Color.White;
            this.button_info.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button_info.FlatAppearance.BorderSize = 2;
            this.button_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_info.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.button_info.Location = new System.Drawing.Point(340, 10);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(76, 29);
            this.button_info.TabIndex = 6;
            this.button_info.Text = "Info";
            this.button_info.UseVisualStyleBackColor = false;
            this.button_info.Click += new System.EventHandler(this.button_info_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(689, 459);
            this.Controls.Add(this.button_info);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.button_rec);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.listView1);
            this.MinimumSize = new System.Drawing.Size(598, 435);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_rec;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem createDirtoolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem createFiletoolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button button_info;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1_prop;
    }
}

