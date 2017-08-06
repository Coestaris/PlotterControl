using CWA.DTP;
using CWA.DTP.FileTransfer;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class ReceiveDialog : Form
    {
        public ReceiveDialog()
        {
            InitializeComponent();
        }

        private void SetupReceiver()
        {
            fileReceiver = master.CreateFileReceiver(FileTransferSecurityFlags.VerifyLengh);
            fileReceiver.PacketLength = PacketSize;
            fileReceiver.ReceiveProcessChanged += FileSender_ReceiverProcessChanged;
            fileReceiver.ReceiveError += FileSender_ReceiverError;
            fileReceiver.ReceivingEnd += FileSender_ReceiverEnd;
        }

        private DateTime startTime;
        private long totalBytes;
        private int PacketSize = 2000;
        private DTPMaster master;
        private FileReceiver fileReceiver;

        public ReceiveDialog(DTPMaster master)
        {
            InitializeComponent();
            this.master = master;
            SetupReceiver();
            textBox_pcName.Text = "C:\\File.txt";
            textBox_deviceName.Text = "/File.txt";
        }

        public ReceiveDialog(DTPMaster master, string oldName, string newName)
        {
            InitializeComponent();
            this.master = master;
            SetupReceiver();
            SetupSending(newName, oldName);
        }

        private void FileSender_ReceiverEnd(FileTransferEndArgs arg)
        {
            Console.WriteLine("Done in {0}! Speed {1:0.##} KBytes/s", arg.TimeSpend, totalBytes / arg.TimeSpend / 1024);
            if (arg.IsForcedEnd) DialogResult = DialogResult.Cancel;
            else DialogResult = DialogResult.OK;

            //FormCloseThread();
        }

        private void FileSender_ReceiverError(FileReceiverErrorArgs arg)
        {
            Console.Write("ERROR! Code {0}, IsCritical {1}", arg.Error.ToString(), arg.IsCritical);
            MessageBox.Show(string.Format("Проиошла ошибка. Код ошибки: {0}.\nВозможно продолжать отравку: {1}", arg.Error, arg.IsCritical ? "нет" : "да"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            if(arg.IsCritical) FormCloseThread();
        }

        private delegate void FormCloseThreadFeedBack();
        private delegate void SendingProcessChangedThreadFeedBack(FileTransferProcessArgs arg);

        private void FormCloseThread()
        {
            if (InvokeRequired)
            {
                FormCloseThreadFeedBack d = new FormCloseThreadFeedBack(FormCloseThread);
                Invoke(d, new object[] {  });
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

                if ((int)arg.PacketTrasfered > progressBar1.Maximum) progressBar1.Maximum = (int)arg.PacketTrasfered;

                progressBar1.Value = (int)arg.PacketTrasfered;
                label_percentage.Text = string.Format("Завершенно {0:0.##}% процесса", (double)arg.PacketTrasfered / total * 100);
                if(arg.TimeLeft > 60) label_timeleft.Text = string.Format("Времени осталось: {0:0} сек. ({1:0.#} мин)", arg.TimeLeft, arg.TimeLeft / 60f);
                else label_timeleft.Text = string.Format("Времени осталось: {0:0} сек.", arg.TimeLeft);
                label_speed.Text = string.Format("Скорость передачи: {0:0.##} КБайт", arg.Speed);
            }
        }

        private void FileSender_ReceiverProcessChanged(FileTransferProcessArgs arg)
        {
            SendingProcessChangedThread(arg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileReceiver.StopAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SetupSending(textBox_pcName.Text, textBox_deviceName.Text);
        }

        private void SetupSending(string OldName, string NewName)
        {
            try
            {
                var a = master.CreateFileHandler(NewName).Open(false);

                panel1.Visible = false;
                startTime = DateTime.Now;
                totalBytes = a.Length;

                a.Close();
            } catch(Exception ex)
            {
                if (MessageBox.Show(
                 string.Format("Произошла ошибка типа {0}.\n{2}\n\nСтек вызовов:\n{1}",
                 ex.GetType().FullName, ex.StackTrace, ex.Message),
                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) Close();
            }
            fileReceiver.ReceiveFileAsync(OldName, NewName);
            label_name.Text = string.Format("{1}  ->  {0}", OldName, NewName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_pcName.Text = saveFileDialog.FileName;
                if (textBox_pcName.Text.Contains("\\"))
                    textBox_deviceName.Text = '/' + textBox_pcName.Text.Split('\\').Last();
                else textBox_deviceName.Text = '/' + textBox_pcName.Text;
            }
        }

        private void ReceiveDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
 