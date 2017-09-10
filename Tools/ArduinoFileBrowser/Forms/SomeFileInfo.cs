/*=================================\
* ArduinoFileBrowser\SomeFileInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 24.08.2017 22:03
* Last Edited: 10.09.2017 18:56:31
*=================================*/

using CWA.DTP;
using CWA.DTP.Plotter;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileBrowser
{
    public enum InfoType
    {
        Config,
        CTable,
        Pens,
        VMeta,
        VData,
        FLVData,
        Image,
        Unknown
    }
    
    public partial class SomeFileInfo : Form
    {
        public static string VDataToString(byte[] bytes)
        {
            string res = "";
            foreach (var item in bytes.Split(4))
            {
                var iArr = item.ToArray();
                if (iArr.SequenceEqual(new byte[] { 100, 100, 100, 100 })) res += "\nDOWN!\n";
                else if (iArr.SequenceEqual(new byte[] { 101, 101, 101, 101 })) res += "\nUP!\n";
                else
                {
                    Int16 dx = (Int16)(((iArr[1] & 255) << 8) | (iArr[0] & 255));
                    Int16 dy = (Int16)(((iArr[3] & 255) << 8) | (iArr[2] & 255));
                    res += string.Format("[{0}, {1}]   ", dx, dy);
                }
            }
            return res;

        }

        private InfoType type;
        private string FileName;

        public SomeFileInfo(InfoType type, string FileName)
        {
            InitializeComponent();
            this.type = type;
            this.FileName = FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SomeFileInfo_Load(object sender, EventArgs e)
        {
            label1.Text = string.Format("Тип файла: {0}", type.ToString());
            try
            {
                if (type == InfoType.Config)
                    richTextBox1.Text = new PlotterConfigOptions(File.ReadAllBytes(FileName)).ToString();
                else if (type == InfoType.CTable)
                    richTextBox1.Text = PlotterContentTable.FromBytes(File.ReadAllBytes(FileName)).ToString();
                else if (type == InfoType.Pens)
                    richTextBox1.Text = string.Join("", PlotterConfig.GetPensFromBytes(File.ReadAllBytes(FileName)).Select(p => p.ToString() + "\n============================\n"));
                else if (type == InfoType.VMeta)
                    richTextBox1.Text = new VectorMetaData(File.ReadAllBytes(FileName), null).ToString();
                else if (type == InfoType.VData)
                    richTextBox1.Text = VDataToString(File.ReadAllBytes(FileName));
                else if (type == InfoType.FLVData)
                    richTextBox1.Text = string.Join("\n", new FlFormat(File.ReadAllBytes(FileName)).Elements.Select(p => p.ToString()));
                else
                {
                    DialogResult = DialogResult.No;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Произошла ошибка типа {0}.\n{2}\n\nНажмите \"Повтор\" для повторной попытки. Стек вызовов:\n{1}", ex.GetType().FullName, ex.StackTrace, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
