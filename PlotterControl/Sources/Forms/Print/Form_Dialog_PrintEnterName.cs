using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CWA.DTP;
using CWA.DTP.Plotter;

namespace CnC_WFA
{
    public partial class Form_Dialog_PrintEnterNames : Form
    {
        private DTPMaster master;

        public Form_Dialog_PrintEnterNames(DTPMaster master)
        {
            this.master = master;
            InitializeComponent();
        }

        public string Value { get; set; }

        private void button_ok_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox_pcName.Enabled = false;
            button_cancel.Enabled = false;
            button_ok.Enabled = false;
            textBox_name.Enabled = false;
            Value = textBox_name.Text;
            loadingCircle_previewLoad.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EnterNameDialog_Load(object sender, EventArgs e)
        {
            textBox_name.Focus();
        }

        private void EnterNameDialog_Shown(object sender, EventArgs e)
        {
            textBox_name.Focus();
        }

        private void textBox_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_ok.PerformClick();
        }

        private delegate void backgroundWorkerEndHandler(object o);

        private void backgroundWorkerEnd(object o)
        {
            if (InvokeRequired)
            {
                var d = new backgroundWorkerEndHandler(backgroundWorkerEnd);
                d.Invoke(o);
            }
            else
            {
                Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PlotterContent contentMaster = new PlotterContent(master);
                if (textBox_name.Text != "") contentMaster.UploadVector(new CWA.Vectors.Vector(textBox_pcName.Text), textBox_name.Text);
                else contentMaster.UploadVector(new CWA.Vectors.Vector(textBox_pcName.Text));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Произошла ошибка типа {0}.\n{2}\n\nСтек вызовов:\n{1}", 
                    ex.GetType().FullName, 
                    ex.StackTrace,
                    ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
}

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerEnd(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox_pcName.Text = openFileDialog1.FileName;
        }
    }
}
