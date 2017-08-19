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
* PlotterControl \ Form_DeviceInfo.cs
*
* Created: 18.08.2017 20:56
* Last Edited: 18.08.2017 21:33:21
*
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
            label1.Text = string.Format("Красный - свободное пространство({0}MB)\nСиний - занятое пространство({1}MB)", di.FreeSpace, (int)di.CardSize - (int)di.FreeSpace);
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
