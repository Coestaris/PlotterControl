/*=================================\
* PlotterControl\FormTranslator.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 15.09.2017 22:51:45
*=================================*/

using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.IO.Compression;
using System.Drawing;

namespace CnC_WFA
{
    public class Language
    {
        public string Name;

        public Image Icon; 
        public Dictionary<string, string> Menu;
        public Dictionary<string, string> Phrase;
        public Dictionary<string, string> Message;
        public Dictionary<string, string> Error;

        public Language()
        {
            Name = "";
            Menu = new Dictionary<string, string>();
            Phrase = new Dictionary<string, string>();
            Message = new Dictionary<string, string>();
            Error = new Dictionary<string, string>();
        }
    }

    public static class FormTranslator
    {
        public static Form_ViewVect Translate(Form_ViewVect form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.Text = a["Form_ViewVect.Caption"];
            return form;
        }

        public static Form_VectorMaster Translate(Form_VectorMaster form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.label_title.Text = a["Form_VectorMaster.label_title"];
            form.label_colormod.Text = a["Form_VectorMaster.label_colormod"];
            form.label_1.Text = a["Form_VectorMaster.label_1"];
            form.label_2.Text = a["Form_VectorMaster.label_2"];
            form.label_3.Text = a["Form_VectorMaster.label_3"];
            form.label_4.Text = a["Form_VectorMaster.label_4"];
            form.label_5.Text = a["Form_VectorMaster.label_5"];
            form.label_6.Text = a["Form_VectorMaster.label_6"];
            form.label_7.Text = a["Form_VectorMaster.label_7"];
            form.label_gauss_scale.Text = a["Form_VectorMaster.label_gauss_scale"];
            form.label_gauss_sigma.Text = a["Form_VectorMaster.label_gauss_sigma"];
            form.label_harbw.Text = a["Form_VectorMaster.label_harbw"];
            form.label_imgname.Text = a["Form_VectorMaster.label_imgname"];
            form.label_instr.Text = a["Form_VectorMaster.label_instr"];
            form.label_path.Text = a["Form_VectorMaster.label_path"];
            form.label_percentage.Text = a["Form_VectorMaster.label_percentage"];
            form.label_resolution.Text = a["Form_VectorMaster.label_resolution"];
            form.label_resolution_.Text = a["Form_VectorMaster.label_resolution_"];
            form.label_size.Text = a["Form_VectorMaster.label_size"];
            form.label_sobel.Text = a["Form_VectorMaster.label_sobel"];
            form.label_strcount.Text = a["Form_VectorMaster.label_strcount"];
            form.label_timespend.Text = a["Form_VectorMaster.label_timespend"];
            form.label_title.Text = a["Form_VectorMaster.label_title"];
            form.label_titlle1.Text = a["Form_VectorMaster.label_titlle1"];
            form.button_next1.Text = a["Form_VectorMaster.button_next1"];
            form.button_back_img.Text = a["Form_VectorMaster.button_back_img"];
            form.button_back_pr.Text = a["Form_VectorMaster.button_back_pr"];
            form.button_back_tab2.Text = a["Form_VectorMaster.button_back_tab2"];
            form.button_back_tab3.Text = a["Form_VectorMaster.button_back_tab3"];
            form.button_back_tab4.Text = a["Form_VectorMaster.button_back_tab4"];
            form.button_exit.Text = a["Form_VectorMaster.button_exit"];
            form.button_exit_tab0.Text = a["Form_VectorMaster.button_exit_tab0"];
            form.button_help.Text = a["Form_VectorMaster.button_help"];
            form.button_loadimage.Text = a["Form_VectorMaster.button_loadimage"];
            form.button_next.Text = a["Form_VectorMaster.button_next"];
            form.button_next1.Text = a["Form_VectorMaster.button_next1"];
            form.button_next_tab0.Text = a["Form_VectorMaster.button_next_tab0"];
            form.button_next_tab2.Text = a["Form_VectorMaster.button_next_tab2"];
            form.button_next_tab3.Text = a["Form_VectorMaster.button_next_tab3"];
            form.button_next_tab4.Text = a["Form_VectorMaster.button_next_tab4"];
            form.button_openfolder.Text = a["Form_VectorMaster.button_openfolder"];
            form.button_peview.Text = a["Form_VectorMaster.button_peview"];
            form.button_pr.Text = a["Form_VectorMaster.button_pr"];
            form.button_print.Text = a["Form_VectorMaster.button_print"];
            form.button_remove.Text = a["Form_VectorMaster.button_remove"];
            form.button_savepr.Text = a["Form_VectorMaster.button_savepr"];
            form.button_show.Text = a["Form_VectorMaster.button_show"];
            form.button_update.Text = a["Form_VectorMaster.button_update"];
            form.button_update_tab2.Text = a["Form_VectorMaster.button_update_tab2"];
            form.button_update_tab3.Text = a["Form_VectorMaster.button_update_tab3"];
            form.checkBox_useflip.Text = a["Form_VectorMaster.checkBox_useflip"];
            form.groupBox_colormod.Text = a["Form_VectorMaster.groupBox_colormod"];
            form.groupBox_flip.Text = a["Form_VectorMaster.groupBox_flip"];
            form.groupBox_gauss.Text = a["Form_VectorMaster.groupBox_gauss"];
            form.groupBox_grayform.Text = a["Form_VectorMaster.groupBox_grayform"];
            form.groupBox_rotate.Text = a["Form_VectorMaster.groupBox_rotate"];
            form.groupBox_sobel.Text = a["Form_VectorMaster.groupBox_sobel"];
            form.radioButton_0deg.Text = a["Form_VectorMaster.radioButton_0deg"];
            form.radioButton_180deg.Text = a["Form_VectorMaster.radioButton_180deg"];
            form.radioButton_270deg.Text = a["Form_VectorMaster.radioButton_270deg"];
            form.radioButton_90deg.Text = a["Form_VectorMaster.radioButton_90deg"];
            form.radioButton_flipx.Text = a["Form_VectorMaster.radioButton_flipx"];
            form.radioButton_flipy.Text = a["Form_VectorMaster.radioButton_flipy"];
            form.radioButton_grayform.Text = a["Form_VectorMaster.radioButton_grayform"];
            form.radioButton_hardbw.Text = a["Form_VectorMaster.radioButton_hardbw"];

            return form;
        }

        public static MainWindow Translate(MainWindow form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_about.Text = a["MainWindow.button_about"];
            form.button_config.Text = a["MainWindow.button_config"];
            form.button_device.Text = a["MainWindow.button_device"];
            form.button_help.Text = a["MainWindow.button_help"];
            form.button_home.Text = a["MainWindow.button_home"];
            form.button_main_about_help.Text = a["MainWindow.button_main_about_help"];
            form.button_main_config_def.Text = a["MainWindow.button_main_config_def"];
            form.button_main_config_help.Text = a["MainWindow.button_main_config_help"];
            form.button_main_config_save.Text = a["MainWindow.button_main_config_save"];
            form.button_main_device_col.Text = a["MainWindow.button_main_device_col"];
            form.button_main_device_def.Text = a["MainWindow.button_main_device_def"];
            form.button_main_device_driver.Text = a["MainWindow.button_main_device_driver"];
            form.button_main_device_help.Text = a["MainWindow.button_main_device_help"];
            form.button_main_device_ide.Text = a["MainWindow.button_main_device_ide"];
            form.button_main_device_pick.Text = a["MainWindow.button_main_device_pick"];
            form.button_main_device_save.Text = a["MainWindow.button_main_device_save"];
            form.button_main_device_scetch.Text = a["MainWindow.button_main_device_scetch"];
            form.button_main_editor.Text = a["MainWindow.button_main_editor"];
            form.button_main_macro.Text = a["MainWindow.button_main_macro"];
            form.button_main_manual.Text = a["MainWindow.button_main_manual"];
            form.button_main_memory_connect.Text = a["MainWindow.button_main_memory_connect"];
            form.button_main_memory_def.Text = a["MainWindow.button_main_memory_def"];
            form.button_main_memory_get.Text = a["MainWindow.button_main_memory_get"];
            form.button_main_memory_help.Text = a["MainWindow.button_main_memory_help"];
            form.button_main_memory_load.Text = a["MainWindow.button_main_memory_load"];
            form.button_main_print.Text = a["MainWindow.button_main_print"];
            form.button_main_ser.Text = a["MainWindow.button_main_ser"];
            form.button_main_vect.Text = a["MainWindow.button_main_vect"];
            form.button_main_vectview.Text = a["MainWindow.button_main_vectview"];
            form.button_memory.Text = a["MainWindow.button_memory"];
            form.button_pb.Text = a["MainWindow.button_pb"];
            form.button_pd.Text = a["MainWindow.button_pd"];
            form.button_print.Text = a["MainWindow.button_print"];
            form.button_print_help.Text = a["MainWindow.button_print_help"];
            form.button_print_mc_help.Text = a["MainWindow.button_print_mc_help"];
            form.button_print_mc_start.Text = a["MainWindow.button_print_mc_start"];
            form.button_print_mc_start1.Text = a["MainWindow.button_print_mc_start1"];
            form.button_print_print_help.Text = a["MainWindow.button_print_print_help"];
            form.button_print_print_start.Text = a["MainWindow.button_print_print_start"];
            form.button_print_viewer_help.Text = a["MainWindow.button_print_viewer_help"];
            form.button_vb.Text = a["MainWindow.button_vb"];
            form.button_vd.Text = a["MainWindow.button_vd"];
            form.button_vect.Text = a["MainWindow.button_vect"];
            form.button_vect_editor_help.Text = a["MainWindow.button_vect_editor_help"];
            form.button_vect_editor_start.Text = a["MainWindow.button_vect_editor_start"];
            form.button_vect_pr_start.Text = a["MainWindow.button_vect_pr_start"];
            form.button_vect_vect_help.Text = a["MainWindow.button_vect_vect_help"];
            form.button_vect_viewer_start.Text = a["MainWindow.button_vect_viewer_start"];
            form.checkBox_main_memory_com.Text = a["MainWindow.checkBox_main_memory_com"];
            form.checkBox_main_memory_pause.Text = a["MainWindow.checkBox_main_memory_pause"];
            form.checkBox_main_memory_readonly.Text = a["MainWindow.checkBox_main_memory_readonly"];
            form.checkBox_main_memory_val.Text = a["MainWindow.checkBox_main_memory_val"];
            form.checkBox_usedevicespeed.Text = a["MainWindow.checkBox_usedevicespeed"];
            form.label_help_title.Text = a["MainWindow.label_help_title"];
            form.label_main_about_about.Text = a["MainWindow.label_main_about_about"];
            form.label_main_about_build.Text = a["MainWindow.label_main_about_build"];
            form.label_main_about_con.Text = a["MainWindow.label_main_about_con"];
            form.label_main_about_discr.Text = a["MainWindow.label_main_about_discr"];
            form.label_main_about_dotnet.Text = a["MainWindow.label_main_about_dotnet"];
            form.label_main_about_hm.Text = a["MainWindow.label_main_about_hm"];
            form.label_main_about_pm.Text = a["MainWindow.label_main_about_pm"];
            form.label_main_about_pr.Text = a["MainWindow.label_main_about_pr"];
            form.label_main_about_v.Text = a["MainWindow.label_main_about_v"];
            form.label_main_about_ve.Text = a["MainWindow.label_main_about_ve"];
            form.label_main_about_version.Text = a["MainWindow.label_main_about_version"];
            form.label_main_config_1.Text = a["MainWindow.label_main_config_1"];
            form.label_main_config_2.Text = a["MainWindow.label_main_config_2"];
            form.label_main_config_3.Text = a["MainWindow.label_main_config_3"];
            form.label_main_config_4.Text = a["MainWindow.label_main_config_4"];
            form.label_main_config_5.Text = a["MainWindow.label_main_config_5"];
            form.label_main_config_6.Text = a["MainWindow.label_main_config_6"];
            form.label_main_config_7.Text = a["MainWindow.label_main_config_7"];
            form.label_main_config_title.Text = a["MainWindow.label_main_config_title"];
            form.label_main_device_1.Text = a["MainWindow.label_main_device_1"];
            form.label_main_device_2.Text = a["MainWindow.label_main_device_2"];
            form.label_main_device_3.Text = a["MainWindow.label_main_device_3"];
            form.label_main_device_4.Text = a["MainWindow.label_main_device_4"];
            form.label_main_device_5.Text = a["MainWindow.label_main_device_5"];
            form.label_main_device_board.Text = a["MainWindow.label_main_device_board"];
            form.label_main_device_indev.Text = a["MainWindow.label_main_device_indev"];
            form.label_main_device_isinstall.Text = a["MainWindow.label_main_device_isinstall"];
            form.label_main_device_pathto.Text = a["MainWindow.label_main_device_pathto"];
            form.label_main_device_title.Text = a["MainWindow.label_main_device_title"];
            form.label_main_memory_1.Text = a["MainWindow.label_main_memory_1"];
            form.label_main_memory_2.Text = a["MainWindow.label_main_memory_2"];
            form.label_main_memory_bd.Text = a["MainWindow.label_main_memory_bd"];
            form.label_main_memory_idle.Text = a["MainWindow.label_main_memory_idle"];
            form.label_main_memory_port.Text = a["MainWindow.label_main_memory_port"];
            form.label_main_memory_title.Text = a["MainWindow.label_main_memory_title"];
            form.label_main_memory_work.Text = a["MainWindow.label_main_memory_work"];
            form.label_main_memory_xd.Text = a["MainWindow.label_main_memory_xd"];
            form.label_main_memory_xs.Text = a["MainWindow.label_main_memory_xs"];
            form.label_main_memory_yd.Text = a["MainWindow.label_main_memory_yd"];
            form.label_main_memory_ys.Text = a["MainWindow.label_main_memory_ys"];
            form.label_main_memory_zd.Text = a["MainWindow.label_main_memory_zd"];
            form.label_main_memory_zs.Text = a["MainWindow.label_main_memory_zs"];
            form.label_main_table.Text = a["MainWindow.label_main_table"];
            form.label_mainport.Text = a["MainWindow.label_mainport"];
            form.label_mainrate.Text = a["MainWindow.label_mainrate"];
            form.label_maxstepheight.Text = a["MainWindow.label_maxstepheight"];
            form.label_MaxStepWidth.Text = a["MainWindow.label_MaxStepWidth"];
            form.label_md.Text = a["MainWindow.label_md"];
            form.label_pb.Text = a["MainWindow.label_pb"];
            form.label_pd.Text = a["MainWindow.label_pd"];
            form.label_peo.Text = a["MainWindow.label_peo"];
            form.label_print_macro_title.Text = a["MainWindow.label_print_macro_title"];
            form.label_print_mc_discr.Text = a["MainWindow.label_print_mc_discr"];
            form.label_print_mc_title.Text = a["MainWindow.label_print_mc_title"];
            form.label_print_print_discr.Text = a["MainWindow.label_print_print_discr"];
            form.label_print_print_title.Text = a["MainWindow.label_print_print_title"];
            form.label_print_ser_discr.Text = a["MainWindow.label_print_ser_discr"];
            form.label_print_ser_title.Text = a["MainWindow.label_print_ser_title"];
            form.label_print_title.Text = a["MainWindow.label_print_title"];
            form.label_pso.Text = a["MainWindow.label_pso"];
            form.label_sh.Text = a["MainWindow.label_sh"];
            form.label_title.Text = a["MainWindow.label_title"];
            form.label_title2.Text = a["MainWindow.label_title2"];
            form.label_title3.Text = a["MainWindow.label_title3"];
            form.label_vb.Text = a["MainWindow.label_vb"];
            form.label_vd.Text = a["MainWindow.label_vd"];
            form.label_vect_editor_discr.Text = a["MainWindow.label_vect_editor_discr"];
            form.label_vect_editor_title.Text = a["MainWindow.label_vect_editor_title"];
            form.label_vect_title.Text = a["MainWindow.label_vect_title"];
            form.label_vect_vect_discr.Text = a["MainWindow.label_vect_vect_discr"];
            form.label_vect_vect_title.Text = a["MainWindow.label_vect_vect_title"];
            form.label_vect_viewer_title.Text = a["MainWindow.label_vect_viewer_title"];
            form.label_vect_viewr_discr.Text = a["MainWindow.label_vect_viewr_discr"];
            form.label_xmm.Text = a["MainWindow.label_xmm"];
            form.label_ymm.Text = a["MainWindow.label_ymm"];
            form.Text = a["MainWindow.Text"];
            form.textBox_maxstepheight.Text = a["MainWindow.textBox_maxstepheight"];
            form.textBox_MaxStepWidth.Text = a["MainWindow.textBox_MaxStepWidth"];
            form.textBox_md.Text = a["MainWindow.textBox_md"];
            form.textBox_sh.Text = a["MainWindow.textBox_sh"];
            form.textBox_xmm.Text = a["MainWindow.textBox_xmm"];
            form.textBox_ymm.Text = a["MainWindow.textBox_ymm"];
            return form;
        }

        public static Form_SerialMonitor Translate(Form_SerialMonitor form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            return form;
        }

        public static Form_ManualControl Translate(Form_ManualControl form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_dmove.Text = a["Form_ManualControl.button_dmove"];
            form.button_down.Text = a["Form_ManualControl.button_down"];
            form.button_exit.Text = a["Form_ManualControl.button_exit"];
            form.button_mc.Text = a["Form_ManualControl.button_mc"];
            form.button_startmc.Text = a["Form_ManualControl.button_startmc"];
            form.button_up.Text = a["Form_ManualControl.button_up"];
            form.checkBox_savemove.Text = a["Form_ManualControl.checkBox_savemove"];
            form.label_bdrate.Text = a["Form_ManualControl.label_bdrate"];
            form.label_com.Text = a["Form_ManualControl.label_com"];
            form.label_mcinfo.Text = a["Form_ManualControl.label_mcinfo"];
            form.label_mcstep.Text = a["Form_ManualControl.label_mcstep"];
            form.label_x.Text = a["Form_ManualControl.label_x"];
            form.label_y.Text = a["Form_ManualControl.label_y"];
            form.label_z.Text = a["Form_ManualControl.label_z"];
            form.label1.Text = a["Form_ManualControl.label1"];
            form.label2.Text = a["Form_ManualControl.label2"];
            form.label3.Text = a["Form_ManualControl.label3"];
            form.label4.Text = a["Form_ManualControl.label4"];
            form.Text = a["Form_ManualControl.Text"];
            form.textBox_step.Text = a["Form_ManualControl.textBox_step"];
            form.textBox_xmove.Text = a["Form_ManualControl.textBox_xmove"];
            form.textBox_ymove.Text = a["Form_ManualControl.textBox_ymove"];
            form.textBox_zmove.Text = a["Form_ManualControl.textBox_zmove"];
            return form;
        }
    }

    public static class TranslateBase
    {
        public static string CurrentLangName;
        public static Language CurrentLang;
        public static List<Language> LoadedLangs;
        public static string LangDirectory;

        public static void Init()
        {
            List<string> WasExtracted = new List<string>();
            var data = Directory.GetDirectories(LangDirectory, "Lang_*");
            if (data == null || data.Length == 0)
            {
                if (Directory.GetFiles(LangDirectory, "Lang_*.zip").Length != 0)
                {
                    foreach (var archives in Directory.GetFiles(LangDirectory, "Lang_*.zip"))
                    {
                        ZipFile.ExtractToDirectory(archives, LangDirectory + new FileInfo(archives).Name.Split('.')[0]);
                        WasExtracted.Add(LangDirectory + new FileInfo(archives).Name.Split('.')[0]);
                    }
                }
                else
                {
                    MessageBox.Show("Can`t find any language file");
                    Environment.Exit(1);
                }
            }
            LoadedLangs = new List<Language>();
            foreach (var a in Directory.GetDirectories(LangDirectory, "Lang_*"))
            {
                var g = new Language();
                var doc = new XmlDocument();
                doc.Load(a +'\\'+ new DirectoryInfo(a).Name+".xml");
                g.Name = doc.LastChild.FirstChild.InnerXml;
                g.Icon = new Bitmap(a + "\\Icon.png");
                foreach (var file in Directory.GetFiles(a + "\\", "LangContent_*"))
                {
                    var tmdoc = new XmlDocument();
                    tmdoc.Load(file);
                    foreach (var val in tmdoc.LastChild.ChildNodes)
                    {
                        XmlNode nodeVal = (XmlNode)val;
                        if (nodeVal.InnerText == "") continue;
                        if (nodeVal.Name == "phrase") g.Phrase.Add(nodeVal.Attributes[0].Value, nodeVal.InnerText);
                        else if (nodeVal.Name == "menu") g.Menu.Add(nodeVal.Attributes[0].Value, nodeVal.InnerText);
                        else if (nodeVal.Name == "message") g.Message.Add(nodeVal.Attributes[0].Value, nodeVal.InnerText);
                        else if (nodeVal.Name == "error") g.Error.Add(nodeVal.Attributes[0].Value, nodeVal.InnerText);
                    }
                }
                LoadedLangs.Add(g);
            }
            CurrentLang = LoadedLangs[0];
            CurrentLangName = CurrentLang.Name;
            if(WasExtracted.Count!=0)
            {
                foreach (var a in WasExtracted)
                {
                    foreach(var g in Directory.GetFiles(a)) File.Delete(g);
                    Directory.Delete(a);
                }
            }
        }

        internal static void ProceedLang()
        {
            var a = LoadedLangs.Find(p => p.Name == CurrentLangName);
            if (a == null)
            {
                MessageBox.Show("Can`t find selected language");
                return;
            }
            CurrentLang = a;
        }
    }
}
