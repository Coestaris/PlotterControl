/*=================================\
* PlotterControl\Form_DeviceInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

using CWA.DTP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_DeviceInfo : Form
    {
        List<int> lstValues = new List<int> { 8654, 1235 };

        private void createPie()
        {
            float sum = lstValues.Count;
            for (int iCnt = 0; iCnt < lstValues.Count; iCnt++)
            {
                sum += lstValues[iCnt];
            }
            Color[] color = { Color.Red, Color.Blue, Color.Maroon, Color.Yellow, Color.Green, Color.Indigo };
            Rectangle rect = new Rectangle(new Point(2,2),new Size(pictureBox1.Width - 4, pictureBox1.Height - 4));
            Bitmap bmp = new Bitmap(rect.Height, rect.Width);
            float fDegValue = .0f;
            float fDegSum = .0f;
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(pictureBox1.BackColor);
                for (int iCnt = 0; iCnt < lstValues.Count; iCnt++)
                {
                    fDegValue = (lstValues[iCnt] / sum) * 360;
                    Brush brush = new SolidBrush(color[iCnt]);
                    graphics.FillPie(brush, rect, fDegSum, fDegValue);
                    fDegSum += fDegValue;
                }
            }
            pictureBox1.Image = bmp;
        }

        private DTPMaster master;

        public Form_DeviceInfo(DTPMaster master)
        {
            this.master = master;
            InitializeComponent();
        }

        private void Form_DeviceInfo_Load(object sender, EventArgs e)
        {
            var di = master.Device.CardInfo;
            label1.Text = string.Format("?????????????? - ?????????????????? ????????????????????????({0}MB)\n?????????? - ?????????????? ????????????????????????({1}MB)", di.FreeSpace, (int)di.CardSize - (int)di.FreeSpace);
            lstValues = new List<int>() { (int)di.FreeSpace, (int)di.CardSize - (int)di.FreeSpace };
            richTextBox1.Text = string.Format("===========\nCARD IFNO:\n\n{0}\n===========\nDEVICE INFO:\n\n{1}", di.ToString(), master.Device.DeviceInfo.ToString());
            createPie();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
