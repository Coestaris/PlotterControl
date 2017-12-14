/*=================================\
* PlotterControl\Form_CurvePlugins.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

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
                MessageBox.Show(
                    TB.L.Phrase["Form_CurvePlugins.Busy"],
                    TB.L.Phrase["Form_CurvePlugins.Plugins"],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
            loadingCircle_tab1.Top = panel_wait.Height / 2 - loadingCircle_tab1.Height / 2 - 40;
            loadingCircle_tab1.Left = panel_wait.Width / 2 - loadingCircle_tab1.Width / 2;
            panel_cantFindPlugins.Top = Height / 2 - panel_cantFindPlugins.Height / 2 - 40;
            panel_cantFindPlugins.Left = Width / 2 - panel_cantFindPlugins.Width / 2;
            panel_cantFindPlugins.Visible = false;
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
            if(MessageBox.Show(
                string.Format(
                    TB.L.Phrase["Form_CurvePlugins.VisitLink"],
                    NormalizeLink(CurvePluginHandler.LoadedPlugins[listBox1.SelectedIndex].Info.LearnMore)),
                TB.L.Phrase["Form_CurvePlugins.Plugins"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Process.Start(CurvePluginHandler.LoadedPlugins[listBox1.SelectedIndex].Info.LearnMore);
        }


        private string NormalizeLink(string learnMore)
        {
            while (learnMore.IndexOf('%') != -1)
            {
                learnMore = learnMore.Replace(learnMore.Substring(learnMore.IndexOf('%'), 6), russianLinkTable[learnMore.Substring(learnMore.IndexOf('%'), 6)]);
            }
            return learnMore;
        }

        #region russianLinkTable
        private readonly Dictionary<string, string> russianLinkTable = new Dictionary<string, string>()
        {
            { "%D0%B0" , "à" },
            { "%D0%B1" , "á" },
            { "%D0%B2" , "â" },
            { "%D0%B3" , "ã" },
            { "%D0%B4" , "ä" },
            { "%D0%B5" , "å" },
            { "%D1%91" , "¸" },
            { "%D0%B6" , "æ" },
            { "%D0%B7" , "ç" },
            { "%D0%B8" , "è" },
            { "%D0%B9" , "é" },
            { "%D0%BA" , "ê" },
            { "%D0%BB" , "ë" },
            { "%D0%BC" , "ì" },
            { "%D0%BD" , "í" },
            { "%D0%BE" , "î" },
            { "%D0%BF" , "ï" },
            { "%D1%80" , "ð" },
            { "%D1%81" , "ñ" },
            { "%D1%82" , "ò" },
            { "%D1%83" , "ó" },
            { "%D1%84" , "ô" },
            { "%D1%85" , "õ" },
            { "%D1%86" , "ö" },
            { "%D1%87" , "÷" },
            { "%D1%88" , "ø" },
            { "%D1%89" , "ù" },
            { "%D1%8A" , "ú" },
            { "%D1%8B" , "û" },
            { "%D1%8C" , "ü" },
            { "%D1%8D" , "ý" },
            { "%D1%8E" , "þ" },
            { "%D1%8F" , "ÿ" },
            { "%D0%90" , "À" },
            { "%D0%91" , "Á" },
            { "%D0%92" , "Â" },
            { "%D0%93" , "Ã" },
            { "%D0%94" , "Ä" },
            { "%D0%95" , "Å" },
            { "%D0%81" , "¨" },
            { "%D0%96" , "Æ" },
            { "%D0%97" , "Ç" },
            { "%D0%98" , "È" },
            { "%D0%99" , "É" },
            { "%D0%9A" , "Ê" },
            { "%D0%9B" , "Ë" },
            { "%D0%9C" , "Ì" },
            { "%D0%9D" , "Í" },
            { "%D0%9E" , "Î" },
            { "%D0%9F" , "Ï" },
            { "%D0%A0" , "Ð" },
            { "%D0%A1" , "Ñ" },
            { "%D0%A2" , "Ò" },
            { "%D0%A3" , "Ó" },
            { "%D0%A4" , "Ô" },
            { "%D0%A5" , "Õ" },
            { "%D0%A6" , "Ö" },
            { "%D0%A7" , "×" },
            { "%D0%A8" , "Ø" },
            { "%D0%A9" , "Ù" },
            { "%D0%AA" , "Ú" },
            { "%D0%AB" , "Û" },
            { "%D0%AC" , "Ü" },
            { "%D0%AD" , "Ý" },
            { "%D0%AE" , "Þ" },
            { "%D0%AF" , "ß" }
        };
        #endregion;


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //TODO: ???????????????????? ?? ???????? ????????????????
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
