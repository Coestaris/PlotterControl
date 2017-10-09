/*=================================\
* ArduinoFileBrowser\SendDialog.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.10.2017 20:19
* Last Edited: 06.10.2017 20:19:53
*=================================*/

using CWA.DTP;
using CWA.DTP.FileTransfer;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class SendDialog : Form
    {
        public SendDialog()
        {
            InitializeComponent();
        }

        private bool Sending;
        private string OldName, NewName;

        private void SendDialog_Load(object sender, EventArgs e)
        {
            fileSender = master.FileSender(FileTransferSecurityFlags.VerifyLengh);
            fileSender.PacketLength = PacketSize;
            fileSender.SendingProcessChanged += FileSender_SendingProcessChanged;
            fileSender.SendingError += FileSender_SendingError;
            fileSender.SendingEnd += FileSender_SendingEnd;

            if (Sending)
                SetupSending(OldName, NewName);
        }

        private DateTime startTime;
        private long totalBytes;
        private int PacketSize = 2000;
        private DTPMaster master;
        private FileSender fileSender;

        public SendDialog(DTPMaster master)
        {
            InitializeComponent();
            this.master = master;
            textBox_pcName.Text = "C:\\File.txt";
            textBox_deviceName.Text = "/File.txt";
        }

        public SendDialog(DTPMaster master, string oldName, string newName)
        {
            InitializeComponent();
            this.master = master;
            OldName = oldName;
            Sending = true;
            panel1.Visible = false;
            NewName = newName;
        }

        private void FileSender_SendingEnd(FileTransferEndArgs arg)
        {
            Console.WriteLine("Done in {0}! Speed {1:0.##} KBytes/s", arg.TimeSpend, totalBytes / arg.TimeSpend / 1024);
            FormCloseThread();
        }

        private void FileSender_SendingError(FileSenderErrorArgs arg)
        {
            Console.Write("ERROR! Code {0}, IsCritical {1}", arg.Error.ToString(), arg.IsCritical);
            MessageBox.Show(string.Format("Проиошла ошибка. Код ошибки: {0}.\nВозможно продолжать отравку: {1}", arg.Error, arg.IsCritical ? "нет" : "да"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            if (arg.IsCritical) FormCloseThread();
        }

        private delegate void FormCloseThreadFeedBack();
        private delegate void SendingProcessChangedThreadFeedBack(FileTransferProcessArgs arg);

        private void FormCloseThread()
        {
            if (InvokeRequired)
            {
                FormCloseThreadFeedBack d = new FormCloseThreadFeedBack(FormCloseThread);
                Invoke(d, new object[] { });
            }
            else
            {
                Close();
            }
        }

        private void SendingProcessChangedThread(FileTransferProcessArgs arg)
        {
            if (InvokeRequired)
            {
                SendingProcessChangedThreadFeedBack d = new SendingProcessChangedThreadFeedBack(SendingProcessChangedThread);
                Invoke(d, new object[] { arg });
            }
            else
            {
                var total = arg.PacketTrasfered + arg.PacketsLeft;
                progressBar1.Maximum = (int)total;
                progressBar1.Value = (int)arg.PacketTrasfered;

                label_percentage.Text = string.Format("Завершенно {0:0.##}% процесса", (double)arg.PacketTrasfered / total * 100);
                if (arg.TimeLeft > 60) label_timeleft.Text = string.Format("Времени осталось: {0:0} сек. ({1:0.#} мин)", arg.TimeLeft, arg.TimeLeft / 60f);
                else label_timeleft.Text = string.Format("Времени осталось: {0:0} сек.", arg.TimeLeft);
                label_speed.Text = string.Format("Скорость передачи: {0:0.##} КБайт", arg.Speed);
            }
        }

        private void FileSender_SendingProcessChanged(FileTransferProcessArgs arg)
        {
            SendingProcessChangedThread(arg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileSender.StopAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SetupSending(textBox_pcName.Text, textBox_deviceName.Text);
        }

        private void SetupSending(string OldName, string NewName)
        {
            panel1.Visible = false;
            startTime = DateTime.Now;
            totalBytes = new FileInfo(OldName).Length;
            fileSender.SendFileAsync(OldName, NewName);
            label_name.Text = string.Format("{0}  ->  {1}", OldName, NewName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_pcName.Text = openFileDialog.FileName;
                if (textBox_pcName.Text.Contains("\\"))
                    textBox_deviceName.Text = '/' + textBox_pcName.Text.Split('\\').Last();
                else textBox_deviceName.Text = '/' + textBox_pcName.Text;
            }
        }
    }
}
