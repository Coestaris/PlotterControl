/*=================================\
* ArduinoFileBrowser\SomeFileInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 24.08.2017 22:03
* Last Edited: 24.08.2017 23:08:45
*=================================*/

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
using System.IO;

namespace FileBrowser
{
    public enum InfoType
    {
        Config,
        CTable,
        Pens,
        VMeta,
        VData,
        FLVData
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


        public SomeFileInfo(InfoType type, string FileName)
        {
            InitializeComponent();

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
