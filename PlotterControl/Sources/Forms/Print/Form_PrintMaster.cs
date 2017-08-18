/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:


	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.


	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* PlotterControl \ Form_PrintMaster.cs
*
* Created: 09.08.2017 14:57
* Last Edited: 12.08.2017 23:47:44
*
*=================================*/

using CWA_Resources.Properties;
using CWA;
using CWA.Printing;
using CWA.Vectors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CWA.DTP;
using CWA.DTP.Plotter;

namespace CnC_WFA
{
    public partial class Form_PrintMaster : Form
    {
        int Index;
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
            //TODO :!!
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
            if (master != null)
            {
                if ((master.Listener.PacketReader as SerialPacketReader).Port.IsOpen)
                    (master.Listener.PacketReader as SerialPacketReader).Port.Close();
                if ((master.Listener.PacketWriter as SerialPacketWriter).Port.IsOpen)
                    (master.Listener.PacketReader as SerialPacketWriter).Port.Close();
            }
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (button_open.Text == "Откл.")
            {
                ResetConntection();
                button_tab1_next.Enabled = false;
                comboBox_bdrate.Enabled = true;
                comboBox_com.Enabled = true;
                button_open.Text = "Подкл.";
            }
            else
            {
                ResetConntection();
                button_tab1_next.Enabled = false;
                SerialPort port = new SerialPort(comboBox_com.Text, int.Parse(comboBox_bdrate.Text));
                try
                {
                    port.Open();
                }
                catch
                {
                    MessageBox.Show(string.Format("Не удалось открыть порт {0}", comboBox_com.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                master = new DTPMaster(
                    new SerialPacketReader(port),
                    new SerialPacketWriter(port));
                try
                {
                    if (!master.Device.Test())
                    {
                        MessageBox.Show("Устройство не ответило на первичный опрос", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Устройство не ответило на первичный опрос", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_tab1_next.Enabled = true;
                comboBox_bdrate.Enabled = false;
                comboBox_com.Enabled = false;
                button_open.Text = "Откл.";
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
                Bitmap preview = Metas[index].Preview;
                pictureBox_preview.Image = preview;
                label_resol.Text = string.Format("Размер: {0} x {1}", Metas[index].Width, Metas[index].Height);
                label_type.Text = string.Format("Тип: {0}", Metas[index].Type);
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
            new Form_Dialog_PrintEnterNames(master).ShowDialog();
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
                        string.Format("Произошла ошибка типа {0}.\n{2}\n\nСтек вызовов:\n{1}",
                        ex.GetType().FullName,
                        ex.StackTrace,
                        ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                }
            }
            else MessageBox.Show("Select item!");
        }

        /// <summary>
        /// Получает размер по высоте из размера по ширине (сохраняя пропорцию).
        /// </summary>
        /// <param name="imgWidth">Ширина изображения.</param>
        /// <param name="imgHeight">Высота изображения.</param>
        /// <param name="xSize">Размер по ширине.</param>
        public static float GetYsize(float imgWidth, float imgHeight, float xSize)
        {
            return xSize * imgHeight / imgWidth;
        }

        /// <summary>
        /// Получает размер по ширине из размера по высоте (сохраняя пропорцию).
        /// </summary>
        /// <param name="imgWidth">Ширина изображения.</param>
        /// <param name="imgHeight">Высота изображения.</param>
        /// <param name="ySize">Размер по высоте.</param>
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
            comboBox_pens.Items.Add("<польз. перо>");
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
                    MessageBox.Show(string.Format("\"{0}\" некорректное число", textBox_xsize.Text), "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_xsize.Text = lastCorrectStrings[0];
                    return;
                }
                float ysize = GetYsize(SelectedMetadata.Width, SelectedMetadata.Height, xsize);
                if(xsize <= 0 || ysize <= 0 || xsize >= 297 || ysize >= 210)
                {
                    MessageBox.Show(string.Format("Размеры по ширине должны в пределах 0мм и 297мм, а по высоте от 0мм до 210мм.", textBox_xsize.Text), "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_xsize.Text = lastCorrectStrings[0];
                    return;
                }
                lastCorrectStrings[0] = textBox_xsize.Text;
                textBox_ysize.Text = ysize.ToString(CultureInfo.InvariantCulture);
            } else
            {
                if (!float.TryParse(textBox_ysize.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float ysize))
                {
                    MessageBox.Show(string.Format("\"{0}\" некорректное число", textBox_ysize.Text), "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_ysize.Text = lastCorrectStrings[1];
                    return;
                }
                float xsize = GetXsize(SelectedMetadata.Width, SelectedMetadata.Height, ysize);
                if (xsize <= 0 || ysize <= 0 || xsize >= 297 || ysize >= 210)
                {
                    MessageBox.Show(string.Format("Размеры по ширине должны в пределах 0мм и 297мм, а по высоте от 0мм до 210мм.", textBox_xsize.Text), "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}
