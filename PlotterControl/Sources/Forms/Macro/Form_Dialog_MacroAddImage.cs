/*=================================\
* PlotterControl\Form_Dialog_MacroAddImage.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 26.08.2017 15:49
* Last Edited: 26.08.2017 16:34:50
*=================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_Dialog_MacroAddImage : Form
    {
        public string Path;
        public float XSize, YSize;

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox_width.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out XSize))
            {
                MessageBox.Show("XSize Wrong");
                return;
            }
            if (!float.TryParse(textBox_height.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out YSize))
            {
                MessageBox.Show("YSize Wrs;adf");
                return;
            }
            if (!File.Exists(textBox_path.Text))
            {
                MessageBox.Show("Not exists file");
                return;
            }

            Path = textBox_path.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_pick_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = openFileDialog1.FileName;
                LoadPic();
            }
        }

        private void Form_Dialog_MacroAddImage_Load(object sender, EventArgs e)
        {
            if (XSize != 0)
                textBox_width.Text = XSize.ToString(CultureInfo.InvariantCulture);
            if (YSize != 0)
                textBox_height.Text = YSize.ToString(CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(Path))
            {
                textBox_path.Text = Path;
                if (!File.Exists(textBox_path.Text))
                    MessageBox.Show("Not exists file");
                else LoadPic();
            }
        }

        private void LoadPic()
        {
            var im = pictureBox.Image;
            im?.Dispose();
            pictureBox.Image = new Bitmap(textBox_path.Text);
        }

        public Form_Dialog_MacroAddImage()
        {
            InitializeComponent();
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            openFileDialog1.Filter = string.Format(TB.L.Phrase["VectorMaster.AllImageFiles"] + "({1})|{1}|{0}|" + TB.L.Phrase["VectorMaster.AllFiles"] + "|*", string.Join("|", codecs.Select(codec => string.Format("{0} ({1})|{1}", codec.CodecName, codec.FilenameExtension)).ToArray()), string.Join(";", codecs.Select(codec => codec.FilenameExtension).ToArray()));

        }
    }
}
