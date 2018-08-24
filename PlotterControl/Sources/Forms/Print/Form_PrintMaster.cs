/*=================================\
* PlotterControl\Form_PrintMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

using CWA;
using CWA.DTP;
using CWA.DTP.Plotter;
using CWA_Resources.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_PrintMaster : Form
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Form_PrintMaster));

        private DTPMaster master;
        private PlotterConfig configMaster;
        private PlotterContent contentMaster;
        private VectorMetaData[] Metas;
        private VectorMetaData SelectedMetadata;

        public Form_PrintMaster(string fn, bool ignr)
        {
             
        }

        public Form_PrintMaster(string fn, bool ignr, string port, int bdrate, SizeF size, bool auto)
        {
            //TODO: !!
        }

        public Form_PrintMaster()
        {
            InitializeComponent();
        }

        private void CheckState(int State)
        {
            Label[] labels = new Label[]
            {
                label_1,
                label_2,
                label_3,
                label_4,
                label_5
            };
            Image None = ((Image)(resources.GetObject("label_1.Image")));
            Image Checked = Resources.ok1;
            for (int i = 0; i < labels.Length; i++)
                labels[i].Image = i < State ? Checked : None;
        }

        private void comboBox_com_Click(object sender, EventArgs e)
        {
            comboBox_com.Items.Clear();
            comboBox_com.Items.AddRange(SerialPort.GetPortNames());
        }

        private void ResetConntection()
        {
            master?.CloseConnection();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (button_open.Text == TB.L.Phrase["Form_PrintMaster.Disonnect"])
            {
                ResetConntection();
                button_tab1_next.Enabled = false;
                comboBox_bdrate.Enabled = true;
                comboBox_com.Enabled = true;
                button_open.Text = TB.L.Phrase["Form_PrintMaster.Connect"];
            }
            else
            {
                if(comboBox_bdrate.Text == "")
                {
                    MessageBox.Show(
                        TB.L.Phrase["Connection.EnterBDRate"],  
                        TB.L.Phrase["Connection.Error"], 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ResetConntection();
                button_tab1_next.Enabled = false;

                if(comboBox_com.Text == "")
                {
                    MessageBox.Show(
                        TB.L.Phrase["Connection.EnterPort"],
                        TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SerialPort port = new SerialPort(comboBox_com.Text, int.Parse(comboBox_bdrate.Text));
                try
                {
                    port.Open();
                    port.DiscardInBuffer();
                    port.DiscardOutBuffer();
                    System.Threading.Thread.Sleep(200);
                }
                catch
                {
                    MessageBox.Show(
                        string.Format(TB.L.Phrase["Connection.UnableToOpenPort"], comboBox_com.Text),
                        TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DTPMaster._this = null;

                try
                {
                    master = new DTPMaster(
                        new SerialPacketReader(port, 2500),
                        new SerialPacketWriter(port));

                    if (!master.Device.Test())
                    {
                        MessageBox.Show(
                            TB.L.Phrase["Connection.DeviceNotAnswered"],
                            TB.L.Phrase["Connection.Error"],
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch(TimeoutException)
                {
                    MessageBox.Show(
                        TB.L.Phrase["Connection.DeviceNotAnswered"],
                        TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (port.IsOpen)
                        port.Close();

                    return;
                }
                button_tab1_next.Enabled = true;
                comboBox_bdrate.Enabled = false;
                comboBox_com.Enabled = false;
                button_open.Text = TB.L.Phrase["Form_PrintMaster.Disonnect"];

                if (!master.SecurityManager.IsValidated)
                    if(new ValidateForm(master).ShowDialog() != DialogResult.OK)
                    {
                        //запуск стандартной процедуры отключения
                        ResetConntection();
                        button_tab1_next.Enabled = false;
                        comboBox_bdrate.Enabled = true;
                        comboBox_com.Enabled = true;
                        button_open.Text = TB.L.Phrase["Form_PrintMaster.Connect"];
                    };
            }
        }

        private void button_tab1_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateListBox()
        {
            listBox_fileList.Items.Clear();
            loadingCircle_previewLoad.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button_tab1_next_Click(object sender, EventArgs e)
        {
            CheckState(1);
            tabControl1.SelectedIndex = 1;
            UpdateListBox();
        }

        private void comboBox_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_tab1_next.Enabled = false;
        }

        private void comboBox_bdrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_tab1_next.Enabled = false;
        }

        private delegate void backgroundWorkerEndHandler(object o);

        private void backgroundWorkerEnd(object o)
        {
            if(InvokeRequired)
            {
                var d = new backgroundWorkerEndHandler(backgroundWorkerEnd);
                d.Invoke(o);
            }
            else
            {
                listBox_fileList.Items.AddRange(
                    Metas.Select(p => p.Name).ToArray());
                loadingCircle_previewLoad.Visible = false;
                if (Metas.Length != 0)
                    listBox_fileList.SelectedIndex = 0;
                               
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerEnd(null);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (contentMaster == null)
                contentMaster = new PlotterContent(master);
            else contentMaster.Refresh();
            Metas = contentMaster.GetAllVectorsMetaData();
            foreach (var item in Metas)
                item.DownloadPreview();
        }


        private void listBox_fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox_fileList.SelectedIndex != -1)
            {
                var im = pictureBox_preview.Image;
                im?.Dispose();
                int index = listBox_fileList.SelectedIndex;
                pictureBox_preview.Image = (Bitmap)Metas[index].Preview.Clone();
                label_resol.Text = string.Format(TB.L.Phrase["Form_PrintMaster.Resoulution"], Metas[index].Width, Metas[index].Height);
                label_type.Text = string.Format(TB.L.Phrase["Form_PrintMaster.VectorType"], Metas[index].Type);
            }
            button_tab2_next.Enabled = listBox_fileList.SelectedIndex != -1;
        }

        private void button_tab2_back_Click(object sender, EventArgs e)
        {
            CheckState(0);
            tabControl1.SelectedIndex = 0;
            ResetConntection();
            button_tab1_next.Enabled = false;
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            FormTranslator.Translate(new Form_Dialog_PrintEnterNames(master)).ShowDialog();
            UpdateListBox();
        }

        private void Form_PrintMaster_Load(object sender, EventArgs e)
        {
            comboBox_com.Items.AddRange(SerialPort.GetPortNames());
            comboBox_bdrate.Text = GlobalOptions.Mainbd.ToString();
            comboBox_com.Text = GlobalOptions.Mainport;
            radioButton_xsize.Checked = true;
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (listBox_fileList.SelectedIndex != -1)
            {
                try
                {
                    contentMaster.DeleteVector(Metas.ToList().Find(p =>
                        p.Name == (string)listBox_fileList.Items[listBox_fileList.SelectedIndex]).Index);
                    UpdateListBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format(TB.L.Phrase["Form_PrintMaster.ErrorText"],
                            ex.GetType().FullName,
                            ex.StackTrace,
                            ex.Message),
                        TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                }
            }
            else MessageBox.Show(
                     TB.L.Phrase["Form_PrintMaster.SelectItem"], 
                     TB.L.Phrase["Connection.Error"],
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static float GetYsize(float imgWidth, float imgHeight, float xSize)
        {
            return xSize * imgHeight / imgWidth;
        }

        public static float GetXsize(float imgWidth, float imgHeight, float ySize)
        {
            return ySize * imgWidth / imgHeight;
        }

        private void button_tab2_next_Click(object sender, EventArgs e)
        {
            SelectedMetadata = Metas[listBox_fileList.SelectedIndex];
            CheckState(2);
            tabControl1.SelectedIndex = 2;
            configMaster = new PlotterConfig(master);
            comboBox_pens.Items.Clear();
            comboBox_pens.Items.AddRange(configMaster.Pens.Select(p => p.Name).ToArray());
            comboBox_pens.Items.Add(TB.L.Phrase["Form_PrintMaster.CustomPen"]);
            comboBox_pens.SelectedIndex = 0;
            RecalcSize();
        }

        private string[] lastCorrectStrings = new string[2];

        private void RecalcSize()
        {
            if (radioButton_xsize.Checked)
            {
                if(!float.TryParse(textBox_xsize.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float xsize))
                {
                    MessageBox.Show(
                        string.Format(
                            TB.L.Phrase["Form_PrintMaster.UncorrectNumber"],
                            textBox_xsize.Text),
                        TB.L.Phrase["Form_PrintMaster.WrongInput"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_xsize.Text = lastCorrectStrings[0];
                    return;
                }
                float ysize = GetYsize(SelectedMetadata.Width, SelectedMetadata.Height, xsize);
                if(xsize <= 0 || ysize <= 0 || xsize >= 297 || ysize >= 210)
                {
                    MessageBox.Show(
                        string.Format(
                              TB.L.Phrase["Form_PrintMaster.SizeXY"],
                            textBox_xsize.Text),
                        TB.L.Phrase["Form_PrintMaster.WrongInput"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_xsize.Text = lastCorrectStrings[0];
                    return;
                }
                lastCorrectStrings[0] = textBox_xsize.Text;
                textBox_ysize.Text = ysize.ToString(CultureInfo.InvariantCulture);
            } else
            {
                if (!float.TryParse(textBox_ysize.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float ysize))
                {
                    MessageBox.Show(
                      string.Format(
                          TB.L.Phrase["Form_PrintMaster.UncorrectNumber"],
                          textBox_xsize.Text),
                      TB.L.Phrase["Form_PrintMaster.WrongInput"],
                      MessageBoxButtons.OK, MessageBoxIcon.Error); textBox_ysize.Text = lastCorrectStrings[1];
                    return;
                }
                float xsize = GetXsize(SelectedMetadata.Width, SelectedMetadata.Height, ysize);
                if (xsize <= 0 || ysize <= 0 || xsize >= 297 || ysize >= 210)
                {
                    MessageBox.Show(
                      string.Format(
                            TB.L.Phrase["Form_PrintMaster.SizeXY"],
                          textBox_xsize.Text),
                      TB.L.Phrase["Form_PrintMaster.WrongInput"],
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_ysize.Text = lastCorrectStrings[1];
                    return;
                }
                lastCorrectStrings[1] = textBox_ysize.Text;
                textBox_xsize.Text = xsize.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void comboBox_pens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_pens.SelectedIndex != -1)
            {
                textBox_elev_corr.Enabled = comboBox_pens.SelectedIndex == comboBox_pens.Items.Count - 1;
                textBox_elev_delta.Enabled = comboBox_pens.SelectedIndex == comboBox_pens.Items.Count - 1;
                label_color.Visible = comboBox_pens.SelectedIndex != comboBox_pens.Items.Count - 1;
                pictureBox_color.Visible = comboBox_pens.SelectedIndex != comboBox_pens.Items.Count - 1;
                if (comboBox_pens.SelectedIndex != comboBox_pens.Items.Count - 1)
                {
                    textBox_elev_corr.Text = configMaster.Pens[comboBox_pens.SelectedIndex].ElevationCorrection.ToString();
                    textBox_elev_delta.Text = configMaster.Pens[comboBox_pens.SelectedIndex].ElevationDelta.ToString();
                    var bmp = new Bitmap(pictureBox_color.Width, pictureBox_color.Height);
                    using (var gr = Graphics.FromImage(bmp))
                        gr.FillRectangle(new SolidBrush(configMaster.Pens[comboBox_pens.SelectedIndex].Color),
                            new Rectangle(new Point(0, 0), pictureBox_color.Size));
                    pictureBox_color.Image = bmp;
                }
            }
        }

        private void radioButton_xsize_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ysize.Enabled = !radioButton_xsize.Checked;
            textBox_xsize.Enabled = radioButton_xsize.Checked;
        }

        private void textBox_xsize_TextChanged(object sender, EventArgs e)
        {
            RecalcSize();
        }

        private void textBox_ysize_TextChanged(object sender, EventArgs e)
        {
            RecalcSize();
        }

        private void button_tab3_next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            CheckState(3);
            printMaster = new PrintMaster(master, 0.013f, 0.013f, 600);
            printMaster.SetXSize(float.Parse(textBox_xsize.Text, NumberStyles.Float, CultureInfo.InvariantCulture));
            printMaster.OnError += PrintMaster_OnError;
            printMaster.PrintingEnd += PrintMaster_PrintingEnd;
            printMaster.StatusRequest += PrintMaster_StatusRequest;
            printMaster.BeginPrinting(SelectedMetadata.Index, new PlotterPenInfo("", UInt16.Parse(textBox_elev_delta.Text), Int16.Parse(textBox_elev_corr.Text), Color.Empty));
        }

        private void PrintMaster_PrintingEnd()
        {
            if (InvokeRequired)
            {
                var d = new PrintEndEventHandler(PrintMaster_PrintingEnd);
                Invoke(d);
            }
            else
            {
                tabControl1.SelectedIndex = 4;
                CheckState(4);
            }
        }

        private void PrintMaster_StatusRequest(PrintStatus arg, UInt32 CurrentPosition, UInt32 MaxPosition, PrintStatusTimeArgs TimeArgs)
        {
            if(InvokeRequired)
            {
                var d = new PrintStatusEventHandler(PrintMaster_StatusRequest);
                Invoke(d, arg, CurrentPosition, MaxPosition, TimeArgs);
            } else
            {
                progressBar1.Maximum = (int)MaxPosition;
                progressBar1.Value = (int)CurrentPosition;
                label_spendTme.Text = string.Format(TB.L.Phrase["Form_PrintMaster.TimeSpend"], TimeArgs.SecondsSpend);
                label_leftTime.Text = string.Format(TB.L.Phrase["Form_PrintMaster.EstimatedTime"], TimeArgs.SecondsLeft);
                label_speed.Text = string.Format(TB.L.Phrase["Form_PrintMaster.Speed"], TimeArgs.Speed);
                label_progress.Text = string.Format(TB.L.Phrase["Form_PrintMaster.Progress"], CurrentPosition, MaxPosition);
                label_percentage.Text = string.Format(TB.L.Phrase["Form_PrintMaster.Percentage"], (float)CurrentPosition / MaxPosition * 100f);
            }
        }

        private void PrintMaster_OnError(PrintErrorType arg)
        {
            if (InvokeRequired)
            {
                var d = new PrintErrorEventHandler(PrintMaster_OnError);
                Invoke(d, arg);
            }
            else
            {
                MessageBox.Show(
                         string.Format(TB.L.Phrase["Form_PrintMaster.ErrorText"],
                             arg.GetType().FullName,
                             //ex.StackTrace,
                             "null",
                             arg.ToString()),
                         TB.L.Phrase["Connection.Error"],
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                printMaster.Master.CloseConnection();
                tabControl1.SelectedIndex = 4;
                CheckState(4);
            }
        }

        private PrintMaster printMaster;

        private void button_deviceInfo_Click(object sender, EventArgs e)
        {
            FormTranslator.Translate(new Form_DeviceInfo(master)).ShowDialog();
        }

        private void button_tab3_back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            CheckState(1);
        }

        private void button_abort_Click(object sender, EventArgs e)
        {
            printMaster.AbortPrinting();
            tabControl1.SelectedIndex = 4;
            CheckState(4);
        }

        private void button_tab4_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_PrintMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            //master?.Dispose();
        }
    }
}
