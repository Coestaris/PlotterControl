﻿/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

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
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_CurvePlugins : Form
    {
        public Form_CurvePlugins()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            if(backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Не спеши, он еще занят...");
                return;
            }
            CurvePluginHandler.Dispose();
            listBox1.Items.Clear();
            panel_wait.Visible = true;
            panel_main.Enabled = false;
            panel_content.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void Form_CurvePlugins_Load(object sender, EventArgs e)
        {
            loadingCircle_tab1.InnerCircleRadius = 25;
            loadingCircle_tab1.OuterCircleRadius = 26;
            loadingCircle_tab1.NumberSpoke = 100;
            panel_wait.Top = Height /2 - panel_wait.Height / 2 - 40;
            panel_wait.Left = Width /2 - panel_wait.Width / 2;
            panel_cantFindPlugins.Top = Height / 2 - panel_cantFindPlugins.Height / 2 - 40;
            panel_cantFindPlugins.Left = Width / 2 - panel_cantFindPlugins.Width / 2;
            panel_cantFindPlugins.Visible = false;
            loadingCircle_tab1.Top = panel_wait.Height / 2 - loadingCircle_tab1.Height / 2 - 40;
            loadingCircle_tab1.Left = panel_wait.Width / 2 - loadingCircle_tab1.Width / 2;
            Reload();
        }

        private void Set(CurveScript b)
        {
            label_Title.Text = b.Info.Name;
            pictureBox_prev_2.Image = new Bitmap(10, 10);
            label_usage_content.Visible = !string.IsNullOrEmpty(b.Info.Usage);
            label_usage_discr.Visible = !string.IsNullOrEmpty(b.Info.Usage);
            label_creator_content.Visible = !string.IsNullOrEmpty(b.Info.Creator);
            label_creator_name.Visible = !string.IsNullOrEmpty(b.Info.Creator);
            using (Graphics gr = Graphics.FromImage(pictureBox_prev_2.Image))
            {
                var discr_height = gr.MeasureString(b.Info.Discription, label_discr_content.Font).Height + 10;
                label_discr_content.Height = (int)discr_height;
                label_discr_content.Text = b.Info.Discription;
                var creator_height = gr.MeasureString(b.Info.Creator, label_creator_content.Font).Height + 10;
                label_creator_content.Height = (int)creator_height;
                label_creator_name.Top = 83 + (int)discr_height;
                label_creator_content.Top = 108 + (int)discr_height;
                label_creator_content.Text = b.Info.Creator;
                var usage_height = gr.MeasureString(b.Info.Usage, label_usage_content.Font).Height + 10;
                label_usage_content.Height = (int)usage_height;
                label_usage_discr.Top = 125 + (int)creator_height + (int)discr_height;
                label_usage_content.Top = 145 + (int)creator_height + (int)discr_height;
                label_usage_content.Text = b.Info.Usage;
            }
            
            var ex1 = b.Exmpl1();
            var im1 = pictureBox_prev_1.Image;
            try { im1.Dispose(); } catch { };
            pictureBox_prev_1.Image = ex1.image;
            label_prev_1.Text = ex1.Discr;
            var ex2 = b.Exmpl2();
            var im2 = pictureBox_prev_2.Image;
            try { im2.Dispose(); } catch { };
            pictureBox_prev_2.Image = ex2.image;
            label_prev_2.Text = ex2.Discr;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Set(CurvePluginHandler.LoadedPlugins[listBox1.SelectedIndex]);
            }
        }

        int lastindex = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            lastindex = listBox1.SelectedIndex;
            Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Перейти по ссылке \"" + NormalizeLink(CurvePluginHandler.LoadedPlugins[listBox1.SelectedIndex].Info.LearnMore) + "\"", "Переход по ссылке", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Process.Start(CurvePluginHandler.LoadedPlugins[listBox1.SelectedIndex].Info.LearnMore);
        }

        private string NormalizeLink(string learnMore)
        {
            while(learnMore.IndexOf('%')!=-1)
            {
                learnMore = learnMore.Replace(learnMore.Substring(learnMore.IndexOf('%'), 6), russianLinkTable[learnMore.Substring(learnMore.IndexOf('%'), 6)]);
            }
            return learnMore;
        }

        #region russianLinkTable
        private readonly Dictionary<string, string> russianLinkTable = new Dictionary<string, string>()
        {
            { "%D0%B0" , "а" },
            { "%D0%B1" , "б" },
            { "%D0%B2" , "в" },
            { "%D0%B3" , "г" },
            { "%D0%B4" , "д" },
            { "%D0%B5" , "е" },
            { "%D1%91" , "ё" },
            { "%D0%B6" , "ж" },
            { "%D0%B7" , "з" },
            { "%D0%B8" , "и" },
            { "%D0%B9" , "й" },
            { "%D0%BA" , "к" },
            { "%D0%BB" , "л" },
            { "%D0%BC" , "м" },
            { "%D0%BD" , "н" },
            { "%D0%BE" , "о" },
            { "%D0%BF" , "п" },
            { "%D1%80" , "р" },
            { "%D1%81" , "с" },
            { "%D1%82" , "т" },
            { "%D1%83" , "у" },
            { "%D1%84" , "ф" },
            { "%D1%85" , "х" },
            { "%D1%86" , "ц" },
            { "%D1%87" , "ч" },
            { "%D1%88" , "ш" },
            { "%D1%89" , "щ" },
            { "%D1%8A" , "ъ" },
            { "%D1%8B" , "ы" },
            { "%D1%8C" , "ь" },
            { "%D1%8D" , "э" },
            { "%D1%8E" , "ю" },
            { "%D1%8F" , "я" },
            { "%D0%90" , "А" },
            { "%D0%91" , "Б" },
            { "%D0%92" , "В" },
            { "%D0%93" , "Г" },
            { "%D0%94" , "Д" },
            { "%D0%95" , "Е" },
            { "%D0%81" , "Ё" },
            { "%D0%96" , "Ж" },
            { "%D0%97" , "З" },
            { "%D0%98" , "И" },
            { "%D0%99" , "Й" },
            { "%D0%9A" , "К" },
            { "%D0%9B" , "Л" },
            { "%D0%9C" , "М" },
            { "%D0%9D" , "Н" },
            { "%D0%9E" , "О" },
            { "%D0%9F" , "П" },
            { "%D0%A0" , "Р" },
            { "%D0%A1" , "С" },
            { "%D0%A2" , "Т" },
            { "%D0%A3" , "У" },
            { "%D0%A4" , "Ф" },
            { "%D0%A5" , "Х" },
            { "%D0%A6" , "Ц" },
            { "%D0%A7" , "Ч" },
            { "%D0%A8" , "Ш" },
            { "%D0%A9" , "Щ" },
            { "%D0%AA" , "Ъ" },
            { "%D0%AB" , "Ы" },
            { "%D0%AC" , "Ь" },
            { "%D0%AD" , "Э" },
            { "%D0%AE" , "Ю" },
            { "%D0%AF" , "Я" }
        };
        #endregion;

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //TODO: разобратся с этим условием
            //if (!GlobalOptions.PreloadPlugins) CurvePluginHandler.Init();
            CurvePluginHandler.Init();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            listBox1.Items.AddRange(CurvePluginHandler.LoadedPlugins.Select(p => p.Name).Cast<object>().ToArray());
            if (listBox1.Items.Count == 0)
            {
                panel_cantFindPlugins.Visible = true;
                label_usage_content.Visible = false;
                label_usage_discr.Visible = false;
                label_creator_content.Visible = false;
                label_creator_name.Visible = false;
                label_discr_content.Visible = false;
                label_discr_title.Visible = false;
                label_Title.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label_prev_1.Visible = false;
                label_prev_2.Visible = false;
                panel_content.Visible = false;
                var ex1 = new Bitmap(1, 1);
                var im1 = pictureBox_prev_1.Image;
                try { im1.Dispose(); } catch { };
                pictureBox_prev_1.Image = ex1;
                var ex2 = new Bitmap(1, 1);
                var im2 = pictureBox_prev_2.Image;
                try { im2.Dispose(); } catch { };
                pictureBox_prev_2.Image = ex2;
            }
            else
            {
                listBox1.SelectedIndex = lastindex;
                panel_cantFindPlugins.Visible = false;
                label_usage_content.Visible = true;
                label_usage_discr.Visible = true;
                label_creator_content.Visible = true;
                label_creator_name.Visible = true;
                label_discr_content.Visible = true;
                label_discr_title.Visible = true;

                panel_content.Visible = true;

                label_Title.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                label_prev_1.Visible = true;
                label_prev_2.Visible = true;
                if (lastindex != -1) Set(CurvePluginHandler.LoadedPlugins[lastindex]);
                else Set(CurvePluginHandler.LoadedPlugins[0]);
            }
            panel_wait.Visible = false;
            panel_main.Enabled = true;
            panel_content.Enabled = true;
            panel_main.Visible = true;
        }
    }

}
