/*
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

using BrendanGrant.Helpers.FileAssociation;
using CWA;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CnC_WFA
{
    static class FileAssociation
    {
        internal static bool CanWriteRegistry()
        {
            try
            {
                Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                return true;
            }
            catch { return false; }
        }

        private enum IconIndex
        {
            Icon_CVF = 1,
            Icon_MacroPack = 12,
            Icon_Macros = 2,
            Icon_PRRES = 3,
            Icon_VDOC = 4,
            Icon_Program = 5,
            Icon_Contex_Edit = 6,
            Icon_Contex_Info = 7,
            Icon_Contex_Read = 8,
            Icon_Contex_OpenPicture = 9,
            Icon_Contex_Print = 10,
            Icon_Contex_Run = 11
        }

        public static string PathToProgram, PathToIcons;

        private static void AssociateVerb(string ProgID, string Command, string Name, IconIndex IconIndex)
        {
            ProgramAssociationInfo a = new ProgramAssociationInfo(ProgID);
            a.AddVerb(new ProgramVerb(Name, PathToProgram + Command));
            Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true).OpenSubKey(ProgID, true).OpenSubKey("shell", true).OpenSubKey(Name, true).SetValue("Icon", PathToIcons + ',' + (int)IconIndex);
        }

        private static void AssociateVerb(string ProgID, string Command, string Name, IconIndex IconIndex, string Position)
        {
            ProgramAssociationInfo a = new ProgramAssociationInfo(ProgID);
            a.AddVerb(new ProgramVerb(Name, PathToProgram + Command));
            Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true).OpenSubKey(ProgID, true).OpenSubKey("shell", true).OpenSubKey(Name, true).SetValue("Icon", PathToIcons + ',' + (int)IconIndex);
            Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true).OpenSubKey(ProgID, true).OpenSubKey("shell", true).OpenSubKey(Name, true).SetValue("Position", Position);
        }

        private static void AssociateMainData(string ProgID, string Description, EditFlags flags, IconIndex IconIndex)
        {
            ProgramAssociationInfo a = new ProgramAssociationInfo(ProgID);
            if (!a.Exists) a.Create();
            Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true).OpenSubKey(ProgID, true).CreateSubKey("DefaultIcon", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", PathToIcons + ',' + (int)IconIndex);
            a.Description = Description;
            a.EditFlags = flags;
        }

        private static void AssociateMain(string ProgID, string Ext, PerceivedTypes PerceivedType, string ContentType)
        {
            FileAssociationInfo a = new FileAssociationInfo(Ext);
            if (!a.Exists) a.Create();
            a.PerceivedType = PerceivedType;
            a.ContentType = ContentType;
            a.PersistentHandler = new Guid("{897fe156-ccc2-4992-8144-abb654ea92b9}");
            a.ProgID = ProgID;
        }

        public static void Associate()
        {
            if (GlobalOptions.IgnoreRegisterExtentions) return;
            FileAssociationInfo fai_cvf = new FileAssociationInfo(".cvf");
            FileAssociationInfo fai_vdoc = new FileAssociationInfo(".vdoc");
            FileAssociationInfo fai_prres = new FileAssociationInfo(".prres");
            FileAssociationInfo fai_pcmacros = new FileAssociationInfo(".pcmacros");
            FileAssociationInfo fai_pcmpack = new FileAssociationInfo(".pcmpack");
            List<string> Unsetted = new List<string>();
            if (!fai_cvf.Exists) Unsetted.Add(".CVF ("+TranslateBase.CurrentLang.Phrase["Core.UnSetted.MainVectorFiles"] +")");
            if (!fai_vdoc.Exists) Unsetted.Add(".VDOC ("+ TranslateBase.CurrentLang.Phrase["Core.UnSetted.VectorDocument"] + ")");
            if (!fai_prres.Exists) Unsetted.Add(".PRRES ("+ TranslateBase.CurrentLang.Phrase["Core.UnSetted.OldVectorFiles"] + ")");
            if (!fai_pcmacros.Exists) Unsetted.Add(".PCMACROS ("+ TranslateBase.CurrentLang.Phrase["Core.UnSetted.Macros"] + ")");
            if (!fai_pcmpack.Exists) Unsetted.Add(".PCMPACK ("+ TranslateBase.CurrentLang.Phrase["Core.UnSetted.MacroPacks"] + ")");
            if (Unsetted.Count != 0)
            {
                var a = MessageBox.Show(string.Format(TranslateBase.CurrentLang.Phrase["Core.SetAssociation"], string.Join("; ", Unsetted)), TranslateBase.CurrentLang.Phrase["Core.Word.Association"], MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (a == DialogResult.Cancel) { GlobalOptions.IgnoreRegisterExtentions = true; GlobalOptions.Save(); return; }
                else if (a == DialogResult.No) return;
            }
            else return;
            if(!CanWriteRegistry())
            {
                var a = MessageBox.Show(TranslateBase.CurrentLang.Phrase["Core.RequiredAdministrator"], TranslateBase.CurrentLang.Phrase["Core.Word.Association"], MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (!new FileAssociationInfo(".cvf").Exists)
            {
                AssociateMain("CNCWFAOPENER.CVF", ".cvf", PerceivedTypes.Image, "vect\\cvf");
                AssociateMainData("CNCWFAOPENER.CVF", TranslateBase.CurrentLang.Phrase["Core.CVF"], EditFlags.None, IconIndex.Icon_CVF);
                AssociateVerb("CNCWFAOPENER.CVF", @" --open_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Open"], IconIndex.Icon_Program, "Top");
                AssociateVerb("CNCWFAOPENER.CVF", @" --edit_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
                AssociateVerb("CNCWFAOPENER.CVF", @" --render_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.OpenAsImage"], IconIndex.Icon_Contex_OpenPicture);
                AssociateVerb("CNCWFAOPENER.CVF", @" --print_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
            }
            if (!new FileAssociationInfo(".vdoc").Exists)
            {
                AssociateMain("CNCWFAOPENER.VDOC", ".vdoc", PerceivedTypes.Image, "vect\\vdoc");
                AssociateMainData("CNCWFAOPENER.VDOC", TranslateBase.CurrentLang.Phrase["Core.VDOC"], EditFlags.None, IconIndex.Icon_VDOC);
                AssociateVerb("CNCWFAOPENER.VDOC", @" --open_doc ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Open"], IconIndex.Icon_Program, "Top");
                AssociateVerb("CNCWFAOPENER.VDOC", @" --render_doc ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.OpenAsImage"], IconIndex.Icon_Contex_OpenPicture);
                AssociateVerb("CNCWFAOPENER.VDOC", @" --print_doc ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
                AssociateVerb("CNCWFAOPENER.VDOC", @" --convert_doc ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.OpenAsVector"], IconIndex.Icon_Contex_Read);
            }
            if (!new FileAssociationInfo(".prres").Exists)
            {
                AssociateMain("CNCWFAOPENER.PRRES", ".prres", PerceivedTypes.Image, "vect\\prres");
                AssociateMainData("CNCWFAOPENER.PRRES", TranslateBase.CurrentLang.Phrase["Core.PRRES"], EditFlags.None, IconIndex.Icon_PRRES);
                AssociateVerb("CNCWFAOPENER.PRRES", @" --open_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Open"], IconIndex.Icon_Program, "Top");
                AssociateVerb("CNCWFAOPENER.PRRES", @" --edit_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
                AssociateVerb("CNCWFAOPENER.PRRES", @" --render_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.OpenAsImage"], IconIndex.Icon_Contex_OpenPicture);
                AssociateVerb("CNCWFAOPENER.PRRES", @" --print_vector ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
            }
            if (!new FileAssociationInfo(".pcmacros").Exists)
            {
                AssociateMain("CNCWFAOPENER.PCMACROS", ".pcmacros", PerceivedTypes.Image, "vect\\pcmacros");
                AssociateMainData("CNCWFAOPENER.PCMACROS", TranslateBase.CurrentLang.Phrase["Core.PCMACROS"], EditFlags.None, IconIndex.Icon_Macros);
                AssociateVerb("CNCWFAOPENER.PCMACROS", @" --run_macro ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Run"], IconIndex.Icon_Contex_Run);
                AssociateVerb("CNCWFAOPENER.PCMACROS", @" --edit_macro ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
                AssociateVerb("CNCWFAOPENER.PCMACROS", @" --info_macro ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Info"], IconIndex.Icon_Contex_Info);
                AssociateVerb("CNCWFAOPENER.PCMACROS", @" --print_macro ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
            }
            if (!new FileAssociationInfo(".pcmpack").Exists)
            {
                AssociateMain("CNCWFAOPENER.PCMPACK", ".pcmpack", PerceivedTypes.Image, "vect\\macropack");
                AssociateMainData("CNCWFAOPENER.PCMPACK", TranslateBase.CurrentLang.Phrase["Core.PCMPACK"], EditFlags.None, IconIndex.Icon_MacroPack);
                AssociateVerb("CNCWFAOPENER.PCMPACK", @" --open_mpack ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Open"], IconIndex.Icon_Program);
                AssociateVerb("CNCWFAOPENER.PCMPACK", @" --edit_mpack ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
                AssociateVerb("CNCWFAOPENER.PCMPACK", @" --info_mpack ~~%1", TranslateBase.CurrentLang.Phrase["Core.Word.Options"], IconIndex.Icon_Contex_Info);
            }
            BrendanGrant.FileAssociation.ShellNotification.NotifyOfChange();
        }

        public static void DeleteAssociation()
        {
            RegistryKey a = null;
            List<string> CantDelete = new List<string>();
            try { Registry.ClassesRoot.DeleteSubKeyTree(".pcmacros"); } catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.ProgID"] + "\".pcmacros\""); }
            try { Registry.ClassesRoot.DeleteSubKeyTree(".pcmpack"); } catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.ProgID"] + "\".pcpack\""); }
            try { Registry.ClassesRoot.DeleteSubKeyTree(".cvf"); } catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.ProgID"] + "\".cvf\""); }
            try { Registry.ClassesRoot.DeleteSubKeyTree(".prres"); } catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.ProgID"] + "\".prres\""); }
            try { Registry.ClassesRoot.DeleteSubKeyTree(".vdoc");} catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.ProgID"] + "\".vdoc\""); }
            try { a = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true); } catch { /*Ignore*/ };
            try { a.DeleteSubKeyTree("CNCWFAOPENER.PCMPACK"); } catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.DataTree"] + "\".PCMPACK\""); }
            try { a.DeleteSubKeyTree("CNCWFAOPENER.PCMACROS"); } catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.DataTree"] + " \".PCMACROS\""); }
            try { a.DeleteSubKeyTree("CNCWFAOPENER.CVF");} catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.DataTree"] + "\".CVF\""); }
            try { a.DeleteSubKeyTree("CNCWFAOPENER.PRRES");} catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.DataTree"] + "\".PRRES\""); }
            try { a.DeleteSubKeyTree("CNCWFAOPENER.VDOC");} catch { CantDelete.Add(TranslateBase.CurrentLang.Phrase["Core.DataTree"] + "\".VDOC\""); }
            if (CantDelete.Count != 0) MessageBox.Show(TranslateBase.CurrentLang.Error["Core.CantDeleteNextElems"] + "\n  --" + string.Join("\n  --" ,CantDelete));
        }
        
    }
}
