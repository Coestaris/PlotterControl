using CWA.Vectors;
using Microsoft.WindowsAPICodePack.ShellExtensions;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HandlerSamples
{
    public class PreviewHandleControl : UserControl
    {
        public PreviewHandleControl()
        {
            InitializeComponent();
        }

        public void Populate(Vector definition)
        {
            lblName.Text = definition.Filename;
            txtContent.Text = string.Format("Vector File Type: {0}\nResolution: {1}:\nContours: {2}. Points: {3}",
                definition.Header.VectType.ToString(), definition.GetResolutionByFormat("{0}x{1}"), definition.ContorurCount, definition.Points);
            imageEncoded.Image = definition.ToBitmap(Color.White, Color.Black);
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtContent = new TextBox();
            lblName = new Label();
            imageEncoded = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(imageEncoded)).BeginInit();
            SuspendLayout();
            // 
            // txtContent
            // 
            txtContent.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right);
            txtContent.Location = new Point(12, 250);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.ScrollBars = ScrollBars.Both;
            txtContent.Size = new Size(269, 80);
            txtContent.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(9, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 13);
            lblName.TabIndex = 1;
            lblName.Text = "file name";
            // 
            // imageEncoded
            // 
            imageEncoded.Anchor = ((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right);
            imageEncoded.Location = new Point(12, 25);
            imageEncoded.Name = "imageEncoded";
            imageEncoded.Size = new Size(269, 219);
            imageEncoded.SizeMode = PictureBoxSizeMode.Zoom;
            imageEncoded.TabIndex = 2;
            imageEncoded.TabStop = false;
            // 
            // PreviewHandleControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(imageEncoded);
            Controls.Add(lblName);
            Controls.Add(txtContent);
            Name = "PreviewHandleControl";
            Size = new Size(293, 342);
            ((System.ComponentModel.ISupportInitialize)(imageEncoded)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtContent;
        private Label lblName;
        private PictureBox imageEncoded;
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("CNCWFA.PCVPreviewe")]
    [Guid("05BAC26E-94A8-4441-BA69-9894FE6BBFC5")]
    [PreviewHandler("PreviewHandler", ".pcv", "{5F877EE5-2317-4131-B8D5-6FF965881296}")]
    public class PreviewHandler : WinFormsPreviewHandler, IPreviewFromShellObject, IPreviewFromFile
    {
        public PreviewHandler()
        {
            Control = new PreviewHandleControl();
        }

        public void Load(FileInfo info)
        {
            ((PreviewHandleControl)Control).Populate(new Vector(info.FullName));
        }

        public void Load(Microsoft.WindowsAPICodePack.Shell.ShellObject shellObject)
        {
            Load(new FileInfo(shellObject.ParsingName));
        }

    }


}