/*=================================\
* PlotterControl\FormTranslator.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.10.2017 20:19
* Last Edited: 26.11.2017 23:21:50
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
            form.contoursToolStripMenuItem.Text = a["Form_ViewVect.contoursToolStripMenuItem"];
            form.fileToolStripMenuItem.Text = a["Form_ViewVect.fileToolStripMenuItem"];
            form.infoStripToolStripMenuItem.Text = a["Form_ViewVect.infoStripToolStripMenuItem"];
            form.label.Text = a["Form_ViewVect.label"];
            form.label_status.Text = a["Form_ViewVect.label_status"];
            form.label_zoom_max.Text = a["Form_ViewVect.label_zoom_max"];
            form.label_zoom_min.Text = a["Form_ViewVect.label_zoom_min"];
            form.label3.Text = a["Form_ViewVect.label3"];
            form.loadingCircle1.Text = a["Form_ViewVect.loadingCircle1"];
            form.menuStrip1.Text = a["Form_ViewVect.menuStrip1"];
            form.statusStrip1.Text = a["Form_ViewVect.statusStrip1"];
            form.Text = a["Form_ViewVect.Text"];
            form.toolStripMenuItem_backgroundColor.Text = a["Form_ViewVect.toolStripMenuItem_backgroundColor"];
            form.toolStripMenuItem_close.Text = a["Form_ViewVect.toolStripMenuItem_close"];
            form.toolStripMenuItem_color.Text = a["Form_ViewVect.toolStripMenuItem_color"];
            form.toolStripMenuItem_defDisp.Text = a["Form_ViewVect.toolStripMenuItem_defDisp"];
            form.toolStripMenuItem_edit.Text = a["Form_ViewVect.toolStripMenuItem_edit"];
            form.ToolStripMenuItem_exit.Text = a["Form_ViewVect.ToolStripMenuItem_exit"];
            form.ToolStripMenuItem_open.Text = a["Form_ViewVect.ToolStripMenuItem_open"];
            form.toolStripMenuItem_print.Text = a["Form_ViewVect.toolStripMenuItem_print"];
            form.toolStripMenuItem_resetZoom.Text = a["Form_ViewVect.toolStripMenuItem_resetZoom"];
            form.toolStripMenuItem_saveAs.Text = a["Form_ViewVect.toolStripMenuItem_saveAs"];
            form.toolStripMenuItem_selectedColor.Text = a["Form_ViewVect.toolStripMenuItem_selectedColor"];
            form.viewToolStripMenuItem.Text = a["Form_ViewVect.viewToolStripMenuItem"];
            form.windowsToolStripMenuItem.Text = a["Form_ViewVect.windowsToolStripMenuItem"];
            form.zoomToolStripMenuItem.Text = a["Form_ViewVect.zoomToolStripMenuItem"];
            return form;
        }

        public static Form_Graph Translate(Form_Graph form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_add.Text = a["Form_Graph.button_add"];
            form.button_copy.Text = a["Form_Graph.button_copy"];
            form.button_del.Text = a["Form_Graph.button_del"];
            form.button_edit.Text = a["Form_Graph.button_edit"];
            form.button_loaderr_close.Text = a["Form_Graph.button_loaderr_close"];
            form.button_loaderr_more.Text = a["Form_Graph.button_loaderr_more"];
            form.button1.Text = a["Form_Graph.button1"];
            form.button2.Text = a["Form_Graph.button2"];
            form.button3.Text = a["Form_Graph.button3"];
            form.checkBox_use_addPoints.Text = a["Form_Graph.checkBox_use_addPoints"];
            form.checkBox_use_axis.Text = a["Form_Graph.checkBox_use_axis"];
            form.checkBox_use_axisNames.Text = a["Form_Graph.checkBox_use_axisNames"];
            form.checkBox_use_docName.Text = a["Form_Graph.checkBox_use_docName"];
            form.checkBox_use_Grid.Text = a["Form_Graph.checkBox_use_Grid"];
            form.checkBox_use_legend.Text = a["Form_Graph.checkBox_use_legend"];
            form.groupBox1.Text = a["Form_Graph.groupBox1"];
            form.groupBox2.Text = a["Form_Graph.groupBox2"];
            form.label_load.Text = a["Form_Graph.label_load"];
            form.label_x.Text = a["Form_Graph.label_x"];
            form.label_y.Text = a["Form_Graph.label_y"];
            form.label1.Text = a["Form_Graph.label1"];
            form.labelHint.Text = a["Form_Graph.labelHint"];
            form.loadingCircle_tab1.Text = a["Form_Graph.loadingCircle_tab1"];
            form.Text = a["Form_Graph.Text"];
            return form;
        }

        public static Form_Dialog_MacroAddImage Translate(Form_Dialog_MacroAddImage form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_cancel.Text = a["Form_Dialog_MacroAddImage.button_cancel"];
            form.button_ok.Text = a["Form_Dialog_MacroAddImage.button_ok"];
            form.button_pick.Text = a["Form_Dialog_MacroAddImage.button_pick"];
            form.label_height.Text = a["Form_Dialog_MacroAddImage.label_height"];
            form.label_height_mm.Text = a["Form_Dialog_MacroAddImage.label_height_mm"];
            form.label_path.Text = a["Form_Dialog_MacroAddImage.label_path"];
            form.label_width.Text = a["Form_Dialog_MacroAddImage.label_width"];
            form.label_width_mm.Text = a["Form_Dialog_MacroAddImage.label_width_mm"];
            form.Text = a["Form_Dialog_MacroAddImage.Text"];
            form.textBox_height.Text = a["Form_Dialog_MacroAddImage.textBox_height"];
            form.textBox_width.Text = a["Form_Dialog_MacroAddImage.textBox_width"];
            return form;
        }

        public static Form_MacroPack Translate(Form_MacroPack form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_back_3.Text = a["Form_MacroPack.button_back_3"];
            form.button_connect.Text = a["Form_MacroPack.button_connect"];
            form.button_create.Text = a["Form_MacroPack.button_create"];
            form.button_exit_3.Text = a["Form_MacroPack.button_exit_3"];
            form.button_exit1.Text = a["Form_MacroPack.button_exit1"];
            form.button_info.Text = a["Form_MacroPack.button_info"];
            form.button_load.Text = a["Form_MacroPack.button_load"];
            form.button_preset_run.Text = a["Form_MacroPack.button_preset_run"];
            form.button_reopen.Text = a["Form_MacroPack.button_reopen"];
            form.groupBox_connection.Text = a["Form_MacroPack.groupBox_connection"];
            form.groupBox_info.Text = a["Form_MacroPack.groupBox_info"];
            form.groupBox_macro.Text = a["Form_MacroPack.groupBox_macro"];
            form.groupBox_presets.Text = a["Form_MacroPack.groupBox_presets"];
            form.label_caption.Text = a["Form_MacroPack.label_caption"];
            form.label_name.Text = a["Form_MacroPack.label_name"];
            form.label1.Text = a["Form_MacroPack.label1"];
            form.loadingCircle_previewLoad.Text = a["Form_MacroPack.loadingCircle_previewLoad"];
            form.richTextBox_discr.Text = a["Form_MacroPack.richTextBox_discr"];
            form.tabPage1.Text = a["Form_MacroPack.tabPage1"];
            form.tabPage2.Text = a["Form_MacroPack.tabPage2"];
            form.tabPage3.Text = a["Form_MacroPack.tabPage3"];
            form.Text = a["Form_MacroPack.Text"];
            return form;
        }

        public static Form_Macro Translate(Form_Macro form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_100percent.Text = a["Form_Macro.button_100percent"];
            form.button_addel.Text = a["Form_Macro.button_addel"];
            form.button1.Text = a["Form_Macro.button1"];
            form.groupBox_addel.Text = a["Form_Macro.groupBox_addel"];
            form.groupBox_eltype.Text = a["Form_Macro.groupBox_eltype"];
            form.groupBox_main.Text = a["Form_Macro.groupBox_main"];
            form.groupBox_zoom.Text = a["Form_Macro.groupBox_zoom"];
            form.label_addstatus.Text = a["Form_Macro.label_addstatus"];
            form.label_delay.Text = a["Form_Macro.label_delay"];
            form.label_elements.Text = a["Form_Macro.label_elements"];
            form.label_move_horvertlen.Text = a["Form_Macro.label_move_horvertlen"];
            form.label_move_offangleangle.Text = a["Form_Macro.label_move_offangleangle"];
            form.label_move_offanglelength.Text = a["Form_Macro.label_move_offanglelength"];
            form.label_move_offcoorx.Text = a["Form_Macro.label_move_offcoorx"];
            form.label_move_offcoory.Text = a["Form_Macro.label_move_offcoory"];
            form.label_move_topointx.Text = a["Form_Macro.label_move_topointx"];
            form.label_move_topointy.Text = a["Form_Macro.label_move_topointy"];
            form.label_zoom.Text = a["Form_Macro.label_zoom"];
            form.menuStrip.Text = a["Form_Macro.menuStrip"];
            form.radioButton_elt_move.Text = a["Form_Macro.radioButton_elt_move"];
            form.radioButton_elt_none.Text = a["Form_Macro.radioButton_elt_none"];
            form.radioButton_elt_tdown.Text = a["Form_Macro.radioButton_elt_tdown"];
            form.radioButton_elt_tup.Text = a["Form_Macro.radioButton_elt_tup"];
            form.radioButton_move_hor.Text = a["Form_Macro.radioButton_move_hor"];
            form.radioButton_move_vetr.Text = a["Form_Macro.radioButton_move_vetr"];
            form.statusStrip1.Text = a["Form_Macro.statusStrip1"];
            form.tabPage1.Text = a["Form_Macro.tabPage1"];
            form.tabPage2.Text = a["Form_Macro.tabPage2"];
            form.tabPage3.Text = a["Form_Macro.tabPage3"];
            form.tabPage4.Text = a["Form_Macro.tabPage4"];
            form.Text = a["Form_Macro.Text"];
            form.textBox_move_topointx.Text = a["Form_Macro.textBox_move_topointx"];
            form.textBox_move_topointy.Text = a["Form_Macro.textBox_move_topointy"];
            form.toolStripMenuItem_addimg.Text = a["Form_Macro.toolStripMenuItem_addimg"];
            form.toolStripMenuItem_close.Text = a["Form_Macro.toolStripMenuItem_close"];
            form.toolStripMenuItem_file.Text = a["Form_Macro.toolStripMenuItem_file"];
            form.toolStripMenuItem_load.Text = a["Form_Macro.toolStripMenuItem_load"];
            form.toolStripMenuItem_macro.Text = a["Form_Macro.toolStripMenuItem_macro"];
            form.toolStripMenuItem_new.Text = a["Form_Macro.toolStripMenuItem_new"];
            form.toolStripMenuItem_save.Text = a["Form_Macro.toolStripMenuItem_save"];
            form.toolStripMenuItem_saveas.Text = a["Form_Macro.toolStripMenuItem_saveas"];
            form.toolStripMenuItem_tocorner.Text = a["Form_Macro.toolStripMenuItem_tocorner"];
            form.toolStripStatusLabel_xglobal.Text = a["Form_Macro.toolStripStatusLabel_xglobal"];
            form.toolStripTextBox_discr.Text = a["Form_Macro.toolStripTextBox_discr"];
            form.toolStripTextBox_name.Text = a["Form_Macro.toolStripTextBox_name"];
            return form;
        }

        public static Form_Dialog_Lang Translate(Form_Dialog_Lang form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_edit.Text = a["Form_Dialog_Lang.button_edit"];
            form.button_exit.Text = a["Form_Dialog_Lang.button_exit"];
            form.button_select.Text = a["Form_Dialog_Lang.button_select"];
            form.Text = a["Form_Dialog_Lang.Text"];
            return form;
        }

        public static Form_Dialog_PrintEnterNames Translate(Form_Dialog_PrintEnterNames form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_cancel.Text = a["Form_Dialog_PrintEnterNames.button_cancel"];
            form.button_ok.Text = a["Form_Dialog_PrintEnterNames.button_ok"];
            form.button1.Text = a["Form_Dialog_PrintEnterNames.button1"];
            form.label_name.Text = a["Form_Dialog_PrintEnterNames.label_name"];
            form.label_pc.Text = a["Form_Dialog_PrintEnterNames.label_pc"];
            form.loadingCircle_previewLoad.Text = a["Form_Dialog_PrintEnterNames.loadingCircle_previewLoad"];
            form.Text = a["Form_Dialog_PrintEnterNames.Text"];
            return form;
        }

        public static Form_PrintMaster Translate(Form_PrintMaster form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_abort.Text = a["Form_PrintMaster.button_abort"];
            form.button_delete.Text = a["Form_PrintMaster.button_delete"];
            form.button_deviceInfo.Text = a["Form_PrintMaster.button_deviceInfo"];
            form.button_help.Text = a["Form_PrintMaster.button_help"];
            form.button_open.Text = a["Form_PrintMaster.button_open"];
            form.button_pause.Text = a["Form_PrintMaster.button_pause"];
            form.button_refresh.Text = a["Form_PrintMaster.button_refresh"];
            form.button_tab1_exit.Text = a["Form_PrintMaster.button_tab1_exit"];
            form.button_tab1_next.Text = a["Form_PrintMaster.button_tab1_next"];
            form.button_tab2_back.Text = a["Form_PrintMaster.button_tab2_back"];
            form.button_tab2_next.Text = a["Form_PrintMaster.button_tab2_next"];
            form.button_tab3_back.Text = a["Form_PrintMaster.button_tab3_back"];
            form.button_tab3_next.Text = a["Form_PrintMaster.button_tab3_next"];
            form.button_tab4_close.Text = a["Form_PrintMaster.button_tab4_close"];
            form.button_tab5_exit.Text = a["Form_PrintMaster.button_tab5_exit"];
            form.button_upload.Text = a["Form_PrintMaster.button_upload"];
            form.groupBox_pens.Text = a["Form_PrintMaster.groupBox_pens"];
            form.groupBox_size.Text = a["Form_PrintMaster.groupBox_size"];
            form.groupBox4.Text = a["Form_PrintMaster.groupBox4"];
            form.label_1.Text = a["Form_PrintMaster.label_1"];
            form.label_2.Text = a["Form_PrintMaster.label_2"];
            form.label_3.Text = a["Form_PrintMaster.label_3"];
            form.label_4.Text = a["Form_PrintMaster.label_4"];
            form.label_5.Text = a["Form_PrintMaster.label_5"];
            form.label_bd.Text = a["Form_PrintMaster.label_bd"];
            form.label_color.Text = a["Form_PrintMaster.label_color"];
            form.label_com.Text = a["Form_PrintMaster.label_com"];
            form.label_discr.Text = a["Form_PrintMaster.label_discr"];
            form.label_elev_corr.Text = a["Form_PrintMaster.label_elev_corr"];
            form.label_elev_corr_1.Text = a["Form_PrintMaster.label_elev_corr_1"];
            form.label_elev_delta.Text = a["Form_PrintMaster.label_elev_delta"];
            form.label_elev_delta_1.Text = a["Form_PrintMaster.label_elev_delta_1"];
            form.label_leftTime.Text = a["Form_PrintMaster.label_leftTime"];
            form.label_maxx.Text = a["Form_PrintMaster.label_maxx"];
            form.label_maxy.Text = a["Form_PrintMaster.label_maxy"];
            form.label_measure_xsize.Text = a["Form_PrintMaster.label_measure_xsize"];
            form.label_measure_ysize.Text = a["Form_PrintMaster.label_measure_ysize"];
            form.label_percentage.Text = a["Form_PrintMaster.label_percentage"];
            form.label_progress.Text = a["Form_PrintMaster.label_progress"];
            form.label_speed.Text = a["Form_PrintMaster.label_speed"];
            form.label_spendTme.Text = a["Form_PrintMaster.label_spendTme"];
            form.label_title.Text = a["Form_PrintMaster.label_title"];
            form.label_title_2.Text = a["Form_PrintMaster.label_title_2"];
            form.label_xsize.Text = a["Form_PrintMaster.label_xsize"];
            form.label_ysize.Text = a["Form_PrintMaster.label_ysize"];
            form.label1.Text = a["Form_PrintMaster.label1"];
            form.label2.Text = a["Form_PrintMaster.label2"];
            form.label3.Text = a["Form_PrintMaster.label3"];
            form.label4.Text = a["Form_PrintMaster.label4"];
            form.loadingCircle_previewLoad.Text = a["Form_PrintMaster.loadingCircle_previewLoad"];
            form.radioButton_xsize.Text = a["Form_PrintMaster.radioButton_xsize"];
            form.radioButton_ysize.Text = a["Form_PrintMaster.radioButton_ysize"];
            form.tabPage_end.Text = a["Form_PrintMaster.tabPage_end"];
            form.tabPage_end1.Text = a["Form_PrintMaster.tabPage_end1"];
            form.tabPage_main.Text = a["Form_PrintMaster.tabPage_main"];
            form.tabPage_opts.Text = a["Form_PrintMaster.tabPage_opts"];
            form.tabPage_pickVect.Text = a["Form_PrintMaster.tabPage_pickVect"];
            form.tabPage_print.Text = a["Form_PrintMaster.tabPage_print"];
            form.Text = a["Form_PrintMaster.Text"];
            form.textBox_xsize.Text = a["Form_PrintMaster.textBox_xsize"];
            return form;
        }

        public static Form_Dialog_Edit Translate(Form_Dialog_Edit form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_cancel.Text = a["Form_Dialog_Edit.button_cancel"];
            form.button_delete.Text = a["Form_Dialog_Edit.button_delete"];
            form.button_flip.Text = a["Form_Dialog_Edit.button_flip"];
            form.button_flip_cancel.Text = a["Form_Dialog_Edit.button_flip_cancel"];
            form.button_flip_ok.Text = a["Form_Dialog_Edit.button_flip_ok"];
            form.button_merge.Text = a["Form_Dialog_Edit.button_merge"];
            form.button_move.Text = a["Form_Dialog_Edit.button_move"];
            form.button_ok.Text = a["Form_Dialog_Edit.button_ok"];
            form.button_openvector.Text = a["Form_Dialog_Edit.button_openvector"];
            form.button_resize.Text = a["Form_Dialog_Edit.button_resize"];
            form.button_resize_cansel.Text = a["Form_Dialog_Edit.button_resize_cansel"];
            form.button_resize_ok.Text = a["Form_Dialog_Edit.button_resize_ok"];
            form.button_rot_cancel.Text = a["Form_Dialog_Edit.button_rot_cancel"];
            form.button_rot_ok.Text = a["Form_Dialog_Edit.button_rot_ok"];
            form.button_rotate.Text = a["Form_Dialog_Edit.button_rotate"];
            form.button_rotatec.Text = a["Form_Dialog_Edit.button_rotatec"];
            form.button_rotc_cancel.Text = a["Form_Dialog_Edit.button_rotc_cancel"];
            form.button_rotc_ok.Text = a["Form_Dialog_Edit.button_rotc_ok"];
            form.button_sd_cancel.Text = a["Form_Dialog_Edit.button_sd_cancel"];
            form.button_sd_ok.Text = a["Form_Dialog_Edit.button_sd_ok"];
            form.button_smdelete.Text = a["Form_Dialog_Edit.button_smdelete"];
            form.button_vectinfo.Text = a["Form_Dialog_Edit.button_vectinfo"];
            form.button1.Text = a["Form_Dialog_Edit.button1"];
            form.checkBox_keepratio.Text = a["Form_Dialog_Edit.checkBox_keepratio"];
            form.groupBox1.Text = a["Form_Dialog_Edit.groupBox1"];
            form.groupBox2.Text = a["Form_Dialog_Edit.groupBox2"];
            form.label_2ndname.Text = a["Form_Dialog_Edit.label_2ndname"];
            form.label_angle.Text = a["Form_Dialog_Edit.label_angle"];
            form.label_ndresol.Text = a["Form_Dialog_Edit.label_ndresol"];
            form.label_newheight.Text = a["Form_Dialog_Edit.label_newheight"];
            form.label_newwidth.Text = a["Form_Dialog_Edit.label_newwidth"];
            form.label_rotatecenter.Text = a["Form_Dialog_Edit.label_rotatecenter"];
            form.label_sd_threshold.Text = a["Form_Dialog_Edit.label_sd_threshold"];
            form.label1.Text = a["Form_Dialog_Edit.label1"];
            form.label4.Text = a["Form_Dialog_Edit.label4"];
            form.loadingCircle1.Text = a["Form_Dialog_Edit.loadingCircle1"];
            form.loadingCircle2.Text = a["Form_Dialog_Edit.loadingCircle2"];
            form.radioButton_180deg.Text = a["Form_Dialog_Edit.radioButton_180deg"];
            form.radioButton_270deg.Text = a["Form_Dialog_Edit.radioButton_270deg"];
            form.radioButton_90deg.Text = a["Form_Dialog_Edit.radioButton_90deg"];
            form.radioButton_xflip.Text = a["Form_Dialog_Edit.radioButton_xflip"];
            form.radioButton_yflip.Text = a["Form_Dialog_Edit.radioButton_yflip"];
            form.tabPage1.Text = a["Form_Dialog_Edit.tabPage1"];
            form.tabPage2.Text = a["Form_Dialog_Edit.tabPage2"];
            form.tabPage3.Text = a["Form_Dialog_Edit.tabPage3"];
            form.Text = a["Form_Dialog_Edit.Text"];
            form.textBox_sd_threshold.Text = a["Form_Dialog_Edit.textBox_sd_threshold"];
            return form;
        }

        public static Form_DeviceInfo Translate(Form_DeviceInfo form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_tab2_back.Text = a["Form_DeviceInfo.button_tab2_back"];
            form.label1.Text = a["Form_DeviceInfo.label1"];
            form.richTextBox1.Text = a["Form_DeviceInfo.richTextBox1"];
            form.Text = a["Form_DeviceInfo.Text"];
            return form;
        }
        
        public static Form_Dialog_Assoc Translate(Form_Dialog_Assoc form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_exit.Text = a["Form_Dialog_Assoc.button_exit"];
            form.button_save.Text = a["Form_Dialog_Assoc.button_save"];
            form.button_selectAll.Text = a["Form_Dialog_Assoc.button_selectAll"];
            form.label_discr.Text = a["Form_Dialog_Assoc.label_discr"];
            form.Text = a["Form_Dialog_Assoc.Text"];
            return form;
        }

        public static Form_Dialog_MacroPackEdit Translate(Form_Dialog_MacroPackEdit form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_addnew.Text = a["Form_Dialog_MacroPackEdit.button_addnew"];
            form.button_close.Text = a["Form_Dialog_MacroPackEdit.button_close"];
            form.button_conn.Text = a["Form_Dialog_MacroPackEdit.button_conn"];
            form.button_load.Text = a["Form_Dialog_MacroPackEdit.button_load"];
            form.button_macro.Text = a["Form_Dialog_MacroPackEdit.button_macro"];
            form.button_main.Text = a["Form_Dialog_MacroPackEdit.button_main"];
            form.button_openineditor.Text = a["Form_Dialog_MacroPackEdit.button_openineditor"];
            form.button_preset.Text = a["Form_Dialog_MacroPackEdit.button_preset"];
            form.button_remove.Text = a["Form_Dialog_MacroPackEdit.button_remove"];
            form.button_repickpath.Text = a["Form_Dialog_MacroPackEdit.button_repickpath"];
            form.button_samples_add.Text = a["Form_Dialog_MacroPackEdit.button_samples_add"];
            form.button_samples_remove.Text = a["Form_Dialog_MacroPackEdit.button_samples_remove"];
            form.button_save.Text = a["Form_Dialog_MacroPackEdit.button_save"];
            form.checkBox_isHidden.Text = a["Form_Dialog_MacroPackEdit.checkBox_isHidden"];
            form.label_bdrate.Text = a["Form_Dialog_MacroPackEdit.label_bdrate"];
            form.label_caption.Text = a["Form_Dialog_MacroPackEdit.label_caption"];
            form.label_conn_title.Text = a["Form_Dialog_MacroPackEdit.label_conn_title"];
            form.label_discr.Text = a["Form_Dialog_MacroPackEdit.label_discr"];
            form.label_macro_caption.Text = a["Form_Dialog_MacroPackEdit.label_macro_caption"];
            form.label_macro_charbind.Text = a["Form_Dialog_MacroPackEdit.label_macro_charbind"];
            form.label_macro_discr.Text = a["Form_Dialog_MacroPackEdit.label_macro_discr"];
            form.label_macro_elemcount.Text = a["Form_Dialog_MacroPackEdit.label_macro_elemcount"];
            form.label_macro_keybind.Text = a["Form_Dialog_MacroPackEdit.label_macro_keybind"];
            form.label_macro_name.Text = a["Form_Dialog_MacroPackEdit.label_macro_name"];
            form.label_macro_path.Text = a["Form_Dialog_MacroPackEdit.label_macro_path"];
            form.label_macro_title.Text = a["Form_Dialog_MacroPackEdit.label_macro_title"];
            form.label_main_title.Text = a["Form_Dialog_MacroPackEdit.label_main_title"];
            form.label_name.Text = a["Form_Dialog_MacroPackEdit.label_name"];
            form.label_portname.Text = a["Form_Dialog_MacroPackEdit.label_portname"];
            form.label_sample_title.Text = a["Form_Dialog_MacroPackEdit.label_sample_title"];
            form.label_samples.Text = a["Form_Dialog_MacroPackEdit.label_samples"];
            form.richTextBox_discr.Text = a["Form_Dialog_MacroPackEdit.richTextBox_discr"];
            form.tabPage_connection.Text = a["Form_Dialog_MacroPackEdit.tabPage_connection"];
            form.tabPage_macro.Text = a["Form_Dialog_MacroPackEdit.tabPage_macro"];
            form.tabPage_main.Text = a["Form_Dialog_MacroPackEdit.tabPage_main"];
            form.tabPage_sample.Text = a["Form_Dialog_MacroPackEdit.tabPage_sample"];
            form.Text = a["Form_Dialog_MacroPackEdit.Text"];
            return form;
        }

        public static Form_EditVector Translate(Form_EditVector form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_angle_0deg.Text = a["Form_EditVector.button_angle_0deg"];
            form.button_angle_m90deg.Text = a["Form_EditVector.button_angle_m90deg"];
            form.button_angle_p90deg.Text = a["Form_EditVector.button_angle_p90deg"];
            form.button_delete.Text = a["Form_EditVector.button_delete"];
            form.button_dideprop.Text = a["Form_EditVector.button_dideprop"];
            form.button_drcolor.Text = a["Form_EditVector.button_drcolor"];
            form.button_edit.Text = a["Form_EditVector.button_edit"];
            form.button_hidezoom.Text = a["Form_EditVector.button_hidezoom"];
            form.button_loaddata_load.Text = a["Form_EditVector.button_loaddata_load"];
            form.button_newdoc_brouse.Text = a["Form_EditVector.button_newdoc_brouse"];
            form.button_newdoc_cancel.Text = a["Form_EditVector.button_newdoc_cancel"];
            form.button_newdoc_ok.Text = a["Form_EditVector.button_newdoc_ok"];
            form.button_pickfont.Text = a["Form_EditVector.button_pickfont"];
            form.button_rename.Text = a["Form_EditVector.button_rename"];
            form.checkBox_useborder.Text = a["Form_EditVector.checkBox_useborder"];
            form.cirlceToolStripMenuItem1.Text = a["Form_EditVector.cirlceToolStripMenuItem1"];
            form.cloneToolStripMenuItem.Text = a["Form_EditVector.cloneToolStripMenuItem"];
            form.dataToolStripMenuItem1.Text = a["Form_EditVector.dataToolStripMenuItem1"];
            form.deleteToolStripMenuItem.Text = a["Form_EditVector.deleteToolStripMenuItem"];
            form.editToolStripMenuItem.Text = a["Form_EditVector.editToolStripMenuItem"];
            form.groupBox1.Text = a["Form_EditVector.groupBox1"];
            form.groupBox2.Text = a["Form_EditVector.groupBox2"];
            form.label_addtext.Text = a["Form_EditVector.label_addtext"];
            form.label_bordoffset.Text = a["Form_EditVector.label_bordoffset"];
            form.label_bordstyle.Text = a["Form_EditVector.label_bordstyle"];
            form.label_dataload_xpos.Text = a["Form_EditVector.label_dataload_xpos"];
            form.label_dataload_ypos.Text = a["Form_EditVector.label_dataload_ypos"];
            form.label_fileautor.Text = a["Form_EditVector.label_fileautor"];
            form.label_filediscr.Text = a["Form_EditVector.label_filediscr"];
            form.label_fileinfo.Text = a["Form_EditVector.label_fileinfo"];
            form.label_help_height.Text = a["Form_EditVector.label_help_height"];
            form.label_hint_text.Text = a["Form_EditVector.label_hint_text"];
            form.label_loaddata_cont.Text = a["Form_EditVector.label_loaddata_cont"];
            form.label_loaddata_hint.Text = a["Form_EditVector.label_loaddata_hint"];
            form.label_loaddata_path.Text = a["Form_EditVector.label_loaddata_path"];
            form.label_loaddata_resolution.Text = a["Form_EditVector.label_loaddata_resolution"];
            form.label_newdoc_height.Text = a["Form_EditVector.label_newdoc_height"];
            form.label_newdoc_lab.Text = a["Form_EditVector.label_newdoc_lab"];
            form.label_newdoc_name.Text = a["Form_EditVector.label_newdoc_name"];
            form.label_newdoc_path.Text = a["Form_EditVector.label_newdoc_path"];
            form.label_newdoc_width.Text = a["Form_EditVector.label_newdoc_width"];
            form.label_obcount.Text = a["Form_EditVector.label_obcount"];
            form.label_subtype.Text = a["Form_EditVector.label_subtype"];
            form.label_text_anglevalue.Text = a["Form_EditVector.label_text_anglevalue"];
            form.label_text_highanglelim.Text = a["Form_EditVector.label_text_highanglelim"];
            form.label_text_hint_x.Text = a["Form_EditVector.label_text_hint_x"];
            form.label_text_hint_y.Text = a["Form_EditVector.label_text_hint_y"];
            form.label_text_lowanglelim.Text = a["Form_EditVector.label_text_lowanglelim"];
            form.label_text_width.Text = a["Form_EditVector.label_text_width"];
            form.label_type.Text = a["Form_EditVector.label_type"];
            form.label_zoom.Text = a["Form_EditVector.label_zoom"];
            form.label1.Text = a["Form_EditVector.label1"];
            form.label2.Text = a["Form_EditVector.label2"];
            form.label3.Text = a["Form_EditVector.label3"];
            form.labelHint.Text = a["Form_EditVector.labelHint"];
            form.lineToolStripMenuItem1.Text = a["Form_EditVector.lineToolStripMenuItem1"];
            form.radioButton_newdoc_usesize.Text = a["Form_EditVector.radioButton_newdoc_usesize"];
            form.radioButton_newdoc_usevector.Text = a["Form_EditVector.radioButton_newdoc_usevector"];
            form.rasterImageToolStripMenuItem.Text = a["Form_EditVector.rasterImageToolStripMenuItem"];
            form.richTextBox_filediscr.Text = a["Form_EditVector.richTextBox_filediscr"];
            form.richTextBox_texteditor_text.Text = a["Form_EditVector.richTextBox_texteditor_text"];
            form.shapeToolStripMenuItem1.Text = a["Form_EditVector.shapeToolStripMenuItem1"];
            form.squareToolStripMenuItem.Text = a["Form_EditVector.squareToolStripMenuItem"];
            form.statusStrip1.Text = a["Form_EditVector.statusStrip1"];
            form.Text = a["Form_EditVector.Text"];
            form.textBox_loaddata_x.Text = a["Form_EditVector.textBox_loaddata_x"];
            form.textBox_loaddata_y.Text = a["Form_EditVector.textBox_loaddata_y"];
            form.textBox_newdoc_height.Text = a["Form_EditVector.textBox_newdoc_height"];
            form.textBox_newdoc_name.Text = a["Form_EditVector.textBox_newdoc_name"];
            form.textBox_newdoc_width.Text = a["Form_EditVector.textBox_newdoc_width"];
            form.textToolStripMenuItem1.Text = a["Form_EditVector.textToolStripMenuItem1"];
            form.toolStrip1.Text = a["Form_EditVector.toolStrip1"];
            form.toolStripButton_docopts_.Text = a["Form_EditVector.toolStripButton_docopts_"];
            form.toolStripButton_new.Text = a["Form_EditVector.toolStripButton_new"];
            form.toolStripButton_open.Text = a["Form_EditVector.toolStripButton_open"];
            form.toolStripButton_render_.Text = a["Form_EditVector.toolStripButton_render_"];
            form.toolStripButton_save.Text = a["Form_EditVector.toolStripButton_save"];
            form.toolStripButton_save_.Text = a["Form_EditVector.toolStripButton_save_"];
            form.toolStripButton_theme.Text = a["Form_EditVector.toolStripButton_theme"];
            form.toolStripButton1.Text = a["Form_EditVector.toolStripButton1"];
            form.toolStripButton2.Text = a["Form_EditVector.toolStripButton2"];
            form.toolStripButton3.Text = a["Form_EditVector.toolStripButton3"];
            form.toolStripSplitButton_additems.Text = a["Form_EditVector.toolStripSplitButton_additems"];
            form.toolStripStatusLabel_fileversion.Text = a["Form_EditVector.toolStripStatusLabel_fileversion"];
            form.toolStripStatusLabel2.Text = a["Form_EditVector.toolStripStatusLabel2"];
            form.toolStripStatusLabel4.Text = a["Form_EditVector.toolStripStatusLabel4"];
            form.toolStripStatusLabel5.Text = a["Form_EditVector.toolStripStatusLabel5"];
            form.toolStripStatusLabel6.Text = a["Form_EditVector.toolStripStatusLabel6"];
            form.triangleToolStripMenuItem1.Text = a["Form_EditVector.triangleToolStripMenuItem1"];
            return form;
        }

        public static Form_Dialog_EditGraph Translate(Form_Dialog_EditGraph form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_data.Text = a["Form_Dialog_EditGraph.button_data"];
            form.button_data_formula_compile.Text = a["Form_Dialog_EditGraph.button_data_formula_compile"];
            form.button_data_formula_help.Text = a["Form_Dialog_EditGraph.button_data_formula_help"];
            form.button_data_formula_status_more.Text = a["Form_Dialog_EditGraph.button_data_formula_status_more"];
            form.button_display.Text = a["Form_Dialog_EditGraph.button_display"];
            form.button_display_color.Text = a["Form_Dialog_EditGraph.button_display_color"];
            form.button_exit.Text = a["Form_Dialog_EditGraph.button_exit"];
            form.button_markers.Text = a["Form_Dialog_EditGraph.button_markers"];
            form.button_markers_color.Text = a["Form_Dialog_EditGraph.button_markers_color"];
            form.button_markers_compile.Text = a["Form_Dialog_EditGraph.button_markers_compile"];
            form.button_markers_help.Text = a["Form_Dialog_EditGraph.button_markers_help"];
            form.button_markers_setpoints.Text = a["Form_Dialog_EditGraph.button_markers_setpoints"];
            form.button_markers_status.Text = a["Form_Dialog_EditGraph.button_markers_status"];
            form.checkBox_display_display.Text = a["Form_Dialog_EditGraph.checkBox_display_display"];
            form.checkBox_markers_period.Text = a["Form_Dialog_EditGraph.checkBox_markers_period"];
            form.checkBox_markers_use.Text = a["Form_Dialog_EditGraph.checkBox_markers_use"];
            form.groupBox_data_formula_formula.Text = a["Form_Dialog_EditGraph.groupBox_data_formula_formula"];
            form.groupBox_data_formula_limits.Text = a["Form_Dialog_EditGraph.groupBox_data_formula_limits"];
            form.groupBox_markers_display.Text = a["Form_Dialog_EditGraph.groupBox_markers_display"];
            form.groupBox_markers_params.Text = a["Form_Dialog_EditGraph.groupBox_markers_params"];
            form.groupBox_period.Text = a["Form_Dialog_EditGraph.groupBox_period"];
            form.groupBox_points.Text = a["Form_Dialog_EditGraph.groupBox_points"];
            form.groupBox1.Text = a["Form_Dialog_EditGraph.groupBox1"];
            form.label_data_formula_end.Text = a["Form_Dialog_EditGraph.label_data_formula_end"];
            form.label_data_formula_help.Text = a["Form_Dialog_EditGraph.label_data_formula_help"];
            form.label_data_formula_start.Text = a["Form_Dialog_EditGraph.label_data_formula_start"];
            form.label_data_formula_status.Text = a["Form_Dialog_EditGraph.label_data_formula_status"];
            form.label_data_forumula_range_info.Text = a["Form_Dialog_EditGraph.label_data_forumula_range_info"];
            form.label_data_info.Text = a["Form_Dialog_EditGraph.label_data_info"];
            form.label_data_title.Text = a["Form_Dialog_EditGraph.label_data_title"];
            form.label_display_color.Text = a["Form_Dialog_EditGraph.label_display_color"];
            form.label_display_color_rgb.Text = a["Form_Dialog_EditGraph.label_display_color_rgb"];
            form.label_display_title.Text = a["Form_Dialog_EditGraph.label_display_title"];
            form.label_display_width.Text = a["Form_Dialog_EditGraph.label_display_width"];
            form.label_markers_color.Text = a["Form_Dialog_EditGraph.label_markers_color"];
            form.label_markers_color_info.Text = a["Form_Dialog_EditGraph.label_markers_color_info"];
            form.label_markers_period.Text = a["Form_Dialog_EditGraph.label_markers_period"];
            form.label_markers_period_end.Text = a["Form_Dialog_EditGraph.label_markers_period_end"];
            form.label_markers_period_start.Text = a["Form_Dialog_EditGraph.label_markers_period_start"];
            form.label_markers_size.Text = a["Form_Dialog_EditGraph.label_markers_size"];
            form.label_markers_status.Text = a["Form_Dialog_EditGraph.label_markers_status"];
            form.label_markers_type.Text = a["Form_Dialog_EditGraph.label_markers_type"];
            form.label_name.Text = a["Form_Dialog_EditGraph.label_name"];
            form.label1.Text = a["Form_Dialog_EditGraph.label1"];
            form.label3.Text = a["Form_Dialog_EditGraph.label3"];
            form.radioButton_data_formula.Text = a["Form_Dialog_EditGraph.radioButton_data_formula"];
            form.radioButton_markers_inpoints.Text = a["Form_Dialog_EditGraph.radioButton_markers_inpoints"];
            form.radioButton_markers_period.Text = a["Form_Dialog_EditGraph.radioButton_markers_period"];
            form.radioButton1.Text = a["Form_Dialog_EditGraph.radioButton1"];
            form.radioButton2.Text = a["Form_Dialog_EditGraph.radioButton2"];
            form.richTextBox_data_formula_add.Text = a["Form_Dialog_EditGraph.richTextBox_data_formula_add"];
            form.tabPage_data.Text = a["Form_Dialog_EditGraph.tabPage_data"];
            form.tabPage_data_formula.Text = a["Form_Dialog_EditGraph.tabPage_data_formula"];
            form.tabPage_data_fromFile.Text = a["Form_Dialog_EditGraph.tabPage_data_fromFile"];
            form.tabPage_display.Text = a["Form_Dialog_EditGraph.tabPage_display"];
            form.tabPage_markers.Text = a["Form_Dialog_EditGraph.tabPage_markers"];
            form.Text = a["Form_Dialog_EditGraph.Text"];
            form.textBox_data_formula_end.Text = a["Form_Dialog_EditGraph.textBox_data_formula_end"];
            form.textBox_data_formula_formula.Text = a["Form_Dialog_EditGraph.textBox_data_formula_formula"];
            form.textBox_data_formula_start.Text = a["Form_Dialog_EditGraph.textBox_data_formula_start"];
            return form;
        }
        

        public static Form_Dialog_EditElement Translate(Form_Dialog_EditElement form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_addPoints.Text = a["Form_Dialog_EditElement.button_addPoints"];
            form.button_axis.Text = a["Form_Dialog_EditElement.button_axis"];
            form.button_axis_color.Text = a["Form_Dialog_EditElement.button_axis_color"];
            form.button_axisCaption.Text = a["Form_Dialog_EditElement.button_axisCaption"];
            form.button_docCaption.Text = a["Form_Dialog_EditElement.button_docCaption"];
            form.button_exit.Text = a["Form_Dialog_EditElement.button_exit"];
            form.button_grid.Text = a["Form_Dialog_EditElement.button_grid"];
            form.button_legend.Text = a["Form_Dialog_EditElement.button_legend"];
            form.button_markers_compile.Text = a["Form_Dialog_EditElement.button_markers_compile"];
            form.button_markers_status.Text = a["Form_Dialog_EditElement.button_markers_status"];
            form.checkBox_addPoints_displ.Text = a["Form_Dialog_EditElement.checkBox_addPoints_displ"];
            form.checkBox_axis_show.Text = a["Form_Dialog_EditElement.checkBox_axis_show"];
            form.checkBox_axis_x.Text = a["Form_Dialog_EditElement.checkBox_axis_x"];
            form.checkBox_axis_y.Text = a["Form_Dialog_EditElement.checkBox_axis_y"];
            form.checkBox_axisC_displ.Text = a["Form_Dialog_EditElement.checkBox_axisC_displ"];
            form.checkBox_docC_displ.Text = a["Form_Dialog_EditElement.checkBox_docC_displ"];
            form.checkBox_grid_displ.Text = a["Form_Dialog_EditElement.checkBox_grid_displ"];
            form.checkBox_legend_displ.Text = a["Form_Dialog_EditElement.checkBox_legend_displ"];
            form.checkBox_markers_period.Text = a["Form_Dialog_EditElement.checkBox_markers_period"];
            form.groupBox_axis_display.Text = a["Form_Dialog_EditElement.groupBox_axis_display"];
            form.groupBox_axis_param.Text = a["Form_Dialog_EditElement.groupBox_axis_param"];
            form.groupBox_inde.Text = a["Form_Dialog_EditElement.groupBox_inde"];
            form.groupBox_markers.Text = a["Form_Dialog_EditElement.groupBox_markers"];
            form.groupBox_names.Text = a["Form_Dialog_EditElement.groupBox_names"];
            form.label_axis_color.Text = a["Form_Dialog_EditElement.label_axis_color"];
            form.label_axis_color_info.Text = a["Form_Dialog_EditElement.label_axis_color_info"];
            form.label_axis_label.Text = a["Form_Dialog_EditElement.label_axis_label"];
            form.label_axis_offset_x.Text = a["Form_Dialog_EditElement.label_axis_offset_x"];
            form.label_axis_offset_y.Text = a["Form_Dialog_EditElement.label_axis_offset_y"];
            form.label_axis_width.Text = a["Form_Dialog_EditElement.label_axis_width"];
            form.label_axis_x.Text = a["Form_Dialog_EditElement.label_axis_x"];
            form.label_axis_y.Text = a["Form_Dialog_EditElement.label_axis_y"];
            form.label_markers_period.Text = a["Form_Dialog_EditElement.label_markers_period"];
            form.label_markers_period_end.Text = a["Form_Dialog_EditElement.label_markers_period_end"];
            form.label_markers_period_start.Text = a["Form_Dialog_EditElement.label_markers_period_start"];
            form.label_markers_status.Text = a["Form_Dialog_EditElement.label_markers_status"];
            form.radioButton_asMarkeks.Text = a["Form_Dialog_EditElement.radioButton_asMarkeks"];
            form.radioButton_axis_limited.Text = a["Form_Dialog_EditElement.radioButton_axis_limited"];
            form.radioButton_axis_unlimited.Text = a["Form_Dialog_EditElement.radioButton_axis_unlimited"];
            form.radioButton_independence.Text = a["Form_Dialog_EditElement.radioButton_independence"];
            form.tabPage_addPoints.Text = a["Form_Dialog_EditElement.tabPage_addPoints"];
            form.tabPage_axis.Text = a["Form_Dialog_EditElement.tabPage_axis"];
            form.tabPage_axisCaption.Text = a["Form_Dialog_EditElement.tabPage_axisCaption"];
            form.tabPage_docCaption.Text = a["Form_Dialog_EditElement.tabPage_docCaption"];
            form.tabPage_grid.Text = a["Form_Dialog_EditElement.tabPage_grid"];
            form.tabPage_legend.Text = a["Form_Dialog_EditElement.tabPage_legend"];
            form.Text = a["Form_Dialog_EditElement.Text"];
            return form;
        }

        public static Form_VectorMaster Translate(Form_VectorMaster form)
        {
            var a = TB.L.Menu;
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
            form.button_main_config_assoc.Text = a["MainWindow.button_main_config_assoc"];
            form.button_main_config_clearcache.Text = a["MainWindow.button_main_config_clearcache"];
            form.button_main_config_def.Text = a["MainWindow.button_main_config_def"];
            form.button_main_config_help.Text = a["MainWindow.button_main_config_help"];
            form.button_main_config_lang.Text = a["MainWindow.button_main_config_lang"];
            form.button_main_config_save.Text = a["MainWindow.button_main_config_save"];
            form.button_main_curve.Text = a["MainWindow.button_main_curve"];
            form.button_main_device_col.Text = a["MainWindow.button_main_device_col"];
            form.button_main_device_def.Text = a["MainWindow.button_main_device_def"];
            form.button_main_device_driver.Text = a["MainWindow.button_main_device_driver"];
            form.button_main_device_help.Text = a["MainWindow.button_main_device_help"];
            form.button_main_device_ide.Text = a["MainWindow.button_main_device_ide"];
            form.button_main_device_pick.Text = a["MainWindow.button_main_device_pick"];
            form.button_main_device_save.Text = a["MainWindow.button_main_device_save"];
            form.button_main_device_scetch.Text = a["MainWindow.button_main_device_scetch"];
            form.button_main_editor.Text = a["MainWindow.button_main_editor"];
            form.button_main_graph.Text = a["MainWindow.button_main_graph"];
            form.button_main_macro.Text = a["MainWindow.button_main_macro"];
            form.button_main_manual.Text = a["MainWindow.button_main_manual"];
            form.button_main_memory_connect.Text = a["MainWindow.button_main_memory_connect"];
            form.button_main_memory_def.Text = a["MainWindow.button_main_memory_def"];
            form.button_main_memory_get.Text = a["MainWindow.button_main_memory_get"];
            form.button_main_memory_help.Text = a["MainWindow.button_main_memory_help"];
            form.button_main_memory_load.Text = a["MainWindow.button_main_memory_load"];
            form.button_main_other.Text = a["MainWindow.button_main_other"];
            form.button_main_print.Text = a["MainWindow.button_main_print"];
            form.button_main_ser.Text = a["MainWindow.button_main_ser"];
            form.button_main_vect.Text = a["MainWindow.button_main_vect"];
            form.button_main_vectview.Text = a["MainWindow.button_main_vectview"];
            form.button_memory.Text = a["MainWindow.button_memory"];
            form.button_pb.Text = a["MainWindow.button_pb"];
            form.button_pd.Text = a["MainWindow.button_pd"];
            form.button_print.Text = a["MainWindow.button_print"];
            form.button_print_help.Text = a["MainWindow.button_print_help"];
            form.button_print_macro_mpack.Text = a["MainWindow.button_print_macro_mpack"];
            form.button_print_macro_new.Text = a["MainWindow.button_print_macro_new"];
            form.button_print_mc_help.Text = a["MainWindow.button_print_mc_help"];
            form.button_print_mc_start.Text = a["MainWindow.button_print_mc_start"];
            form.button_print_mc_start1.Text = a["MainWindow.button_print_mc_start1"];
            form.button_print_print_help.Text = a["MainWindow.button_print_print_help"];
            form.button_print_print_start.Text = a["MainWindow.button_print_print_start"];
            form.button_print_viewer_help.Text = a["MainWindow.button_print_viewer_help"];
            form.button_vb.Text = a["MainWindow.button_vb"];
            form.button_vd.Text = a["MainWindow.button_vd"];
            form.button_vect.Text = a["MainWindow.button_vect"];
            form.button_vect_curve_help.Text = a["MainWindow.button_vect_curve_help"];
            form.button_vect_curve_start.Text = a["MainWindow.button_vect_curve_start"];
            form.button_vect_editor_help.Text = a["MainWindow.button_vect_editor_help"];
            form.button_vect_editor_start.Text = a["MainWindow.button_vect_editor_start"];
            form.button_vect_graph_help.Text = a["MainWindow.button_vect_graph_help"];
            form.button_vect_graph_open.Text = a["MainWindow.button_vect_graph_open"];
            form.button_vect_pr_start.Text = a["MainWindow.button_vect_pr_start"];
            form.button_vect_vect_help.Text = a["MainWindow.button_vect_vect_help"];
            form.button_vect_viewer_start.Text = a["MainWindow.button_vect_viewer_start"];
            form.checkBox_main_config_preload.Text = a["MainWindow.checkBox_main_config_preload"];
            form.checkBox_main_memory_com.Text = a["MainWindow.checkBox_main_memory_com"];
            form.checkBox_main_memory_pause.Text = a["MainWindow.checkBox_main_memory_pause"];
            form.checkBox_main_memory_readonly.Text = a["MainWindow.checkBox_main_memory_readonly"];
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
            form.label_main_config_vertCorrection.Text = a["MainWindow.label_main_config_vertCorrection"];
            form.label_main_config_vertCorrection_dicsr.Text = a["MainWindow.label_main_config_vertCorrection_dicsr"];
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
            form.label_print_macro_mpack.Text = a["MainWindow.label_print_macro_mpack"];
            form.label_print_macro_new.Text = a["MainWindow.label_print_macro_new"];
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
            form.label_vect_curve_discr.Text = a["MainWindow.label_vect_curve_discr"];
            form.label_vect_curve_title.Text = a["MainWindow.label_vect_curve_title"];
            form.label_vect_editor_discr.Text = a["MainWindow.label_vect_editor_discr"];
            form.label_vect_editor_title.Text = a["MainWindow.label_vect_editor_title"];
            form.label_vect_graph_discr.Text = a["MainWindow.label_vect_graph_discr"];
            form.label_vect_graph_title.Text = a["MainWindow.label_vect_graph_title"];
            form.label_vect_title.Text = a["MainWindow.label_vect_title"];
            form.label_vect_vect_discr.Text = a["MainWindow.label_vect_vect_discr"];
            form.label_vect_vect_title.Text = a["MainWindow.label_vect_vect_title"];
            form.label_vect_viewer_title.Text = a["MainWindow.label_vect_viewer_title"];
            form.label_vect_viewr_discr.Text = a["MainWindow.label_vect_viewr_discr"];
            form.label_xmm.Text = a["MainWindow.label_xmm"];
            form.label_ymm.Text = a["MainWindow.label_ymm"];
            form.label1.Text = a["MainWindow.label1"];
            form.label2.Text = a["MainWindow.label2"];
            form.tabPage_about.Text = a["MainWindow.tabPage_about"];
            form.tabPage_config.Text = a["MainWindow.tabPage_config"];
            form.tabPage_device.Text = a["MainWindow.tabPage_device"];
            form.tabPage_main_help.Text = a["MainWindow.tabPage_main_help"];
            form.tabPage_main_main.Text = a["MainWindow.tabPage_main_main"];
            form.tabPage_main_print.Text = a["MainWindow.tabPage_main_print"];
            form.tabPage_main_vect.Text = a["MainWindow.tabPage_main_vect"];
            form.tabPage_memory.Text = a["MainWindow.tabPage_memory"];
            form.tabPage_print_macro.Text = a["MainWindow.tabPage_print_macro"];
            form.tabPage_print_manual.Text = a["MainWindow.tabPage_print_manual"];
            form.tabPage_print_print.Text = a["MainWindow.tabPage_print_print"];
            form.tabPage_print_serial.Text = a["MainWindow.tabPage_print_serial"];
            form.tabPage_vect_curve.Text = a["MainWindow.tabPage_vect_curve"];
            form.tabPage_vect_editor.Text = a["MainWindow.tabPage_vect_editor"];
            form.tabPage_vect_graph.Text = a["MainWindow.tabPage_vect_graph"];
            form.tabPage_vect_other.Text = a["MainWindow.tabPage_vect_other"];
            form.tabPage_vect_pr.Text = a["MainWindow.tabPage_vect_pr"];
            form.tabPage_vect_viewer.Text = a["MainWindow.tabPage_vect_viewer"];
            form.Text = a["MainWindow.Text"];
            form.textBox_main_config_vertCorrection.Text = a["MainWindow.textBox_main_config_vertCorrection"];
            form.textBox_maxstepheight.Text = a["MainWindow.textBox_maxstepheight"];
            form.textBox_MaxStepWidth.Text = a["MainWindow.textBox_MaxStepWidth"];
            form.textBox_md.Text = a["MainWindow.textBox_md"];
            form.textBox_sh.Text = a["MainWindow.textBox_sh"];
            form.textBox_xmm.Text = a["MainWindow.textBox_xmm"];
            form.textBox_ymm.Text = a["MainWindow.textBox_ymm"];
            return form;
        }

        public static Form_CurvePlugins Translate(Form_CurvePlugins form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button1.Text = a["Form_CurvePlugins.button1"];
            form.button2.Text = a["Form_CurvePlugins.button2"];
            form.button3.Text = a["Form_CurvePlugins.button3"];
            form.label_cantFindPlugins.Text = a["Form_CurvePlugins.label_cantFindPlugins"];
            form.label_creator_content.Text = a["Form_CurvePlugins.label_creator_content"];
            form.label_creator_name.Text = a["Form_CurvePlugins.label_creator_name"];
            form.label_discr_content.Text = a["Form_CurvePlugins.label_discr_content"];
            form.label_discr_title.Text = a["Form_CurvePlugins.label_discr_title"];
            form.label_load.Text = a["Form_CurvePlugins.label_load"];
            form.label_prev_1.Text = a["Form_CurvePlugins.label_prev_1"];
            form.label_prev_2.Text = a["Form_CurvePlugins.label_prev_2"];
            form.label_Title.Text = a["Form_CurvePlugins.label_Title"];
            form.label_usage_content.Text = a["Form_CurvePlugins.label_usage_content"];
            form.label_usage_discr.Text = a["Form_CurvePlugins.label_usage_discr"];
            form.loadingCircle_tab1.Text = a["Form_CurvePlugins.loadingCircle_tab1"];
            form.Text = a["Form_CurvePlugins.Text"];
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
            form.button_turnOff.Text = a["Form_ManualControl.button_turnOff"];
            form.button_turnOn.Text = a["Form_ManualControl.button_turnOn"];
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
            form.tabPage1.Text = a["Form_ManualControl.tabPage1"];
            form.tabPage2.Text = a["Form_ManualControl.tabPage2"];
            form.tabPage3.Text = a["Form_ManualControl.tabPage3"];
            form.tabPage4.Text = a["Form_ManualControl.tabPage4"];
            form.Text = a["Form_ManualControl.Text"];
            form.textBox_step.Text = a["Form_ManualControl.textBox_step"];
            form.textBox_xmove.Text = a["Form_ManualControl.textBox_xmove"];
            form.textBox_ymove.Text = a["Form_ManualControl.textBox_ymove"];
            form.textBox_zmove.Text = a["Form_ManualControl.textBox_zmove"];
            return form;
        }

        public static Form_SerialMonitor Translate(Form_SerialMonitor form)
        {
            var a = TranslateBase.CurrentLang.Menu;
            form.button_conn.Text = a["Form_SerialMonitor.button_conn"];
            form.button_exit.Text = a["Form_SerialMonitor.button_exit"];
            form.button_fill.Text = a["Form_SerialMonitor.button_fill"];
            form.button_send.Text = a["Form_SerialMonitor.button_send"];
            form.button1.Text = a["Form_SerialMonitor.button1"];
            form.checkBox_hash.Text = a["Form_SerialMonitor.checkBox_hash"];
            form.checkBox_size.Text = a["Form_SerialMonitor.checkBox_size"];
            form.label_bd.Text = a["Form_SerialMonitor.label_bd"];
            form.label_command.Text = a["Form_SerialMonitor.label_command"];
            form.label_command_send.Text = a["Form_SerialMonitor.label_command_send"];
            form.label_conv.Text = a["Form_SerialMonitor.label_conv"];
            form.label_conv_arr.Text = a["Form_SerialMonitor.label_conv_arr"];
            form.label_data.Text = a["Form_SerialMonitor.label_data"];
            form.label_data_sep.Text = a["Form_SerialMonitor.label_data_sep"];
            form.label_fill.Text = a["Form_SerialMonitor.label_fill"];
            form.label_hash.Text = a["Form_SerialMonitor.label_hash"];
            form.label_list.Text = a["Form_SerialMonitor.label_list"];
            form.label_port.Text = a["Form_SerialMonitor.label_port"];
            form.label_sender.Text = a["Form_SerialMonitor.label_sender"];
            form.label_sender_type.Text = a["Form_SerialMonitor.label_sender_type"];
            form.label_size.Text = a["Form_SerialMonitor.label_size"];
            form.Text = a["Form_SerialMonitor.Text"];
            return form;
        }
        //20
    }

    public static class TB
    {
        public static Language L => TranslateBase.CurrentLang;
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
                        //if (nodeVal.InnerText == "") continue;
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
