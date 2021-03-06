/*=================================\
* PlotterControl\FileAssociation.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.10.2017 20:19
* Last Edited: 06.10.2017 20:19:53
*=================================*/

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
        private static bool CanWriteRegistryValue;

        internal static bool CanWriteRegistry
        {
            get { return CanWriteRegistryValue; }
        }

        internal static void DiscoverRegistryAccessibility()
        {
            try
            {
                Registry.LocalMachine.OpenSubKey("SOFTWARE", true).Close();
                CanWriteRegistryValue = true;
            }
            catch { CanWriteRegistryValue = false; }
        }

        public enum FileFormats 
        {
            PCV = 0,
            PCVDOC = 1,
            PRRES = 2,
            PCMACROS = 3,
            PCMPACK = 4,
            PCGRAPH = 5
        }

        [Flags]
        public enum AssocDeleteFailReason
        {
            CantDeleteMainTree = 1,
            CantOpenClassesTree = 2,
            CantDeleteDataTree = 4,
            unknown = 8,
        }

        internal enum IconIndex
        {
            Icon_PCV = 1,
            Icon_MacroPack = 12,
            Icon_Macros = 2,
            Icon_PRRES = 3,
            Icon_PCVDOC = 4,
            Icon_Program = 5,
            Icon_Contex_Edit = 6,
            Icon_Contex_Info = 7,
            Icon_Contex_Read = 8,
            Icon_Contex_OpenPicture = 9,
            Icon_Contex_Print = 10,
            Icon_Contex_Run = 11,
            Icon_PCGraph = 13
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

        public static List<bool> GetUnidentifiedAssoc()
        {
            List<bool> Unidentified = new List<bool>
            {
                !new FileAssociationInfo(".pcv").Exists,
                !new FileAssociationInfo(".pcgraph").Exists,
                !new FileAssociationInfo(".pcvdoc").Exists,
                !new FileAssociationInfo(".prres").Exists,
                !new FileAssociationInfo(".pcmacros").Exists,
                !new FileAssociationInfo(".pcmpack").Exists
            };
            return Unidentified;
        }

        public static void AllertAboutAdmin()
        {
            MessageBox.Show(TB.L.Phrase["Core.RequiredAdministrator"], TB.L.Phrase["Core.Word.Association"], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public static void AssociateAll()
        {
            if (GlobalOptions.IgnoreRegisterExtentions) return;
            List<bool> Unidentified = GetUnidentifiedAssoc();
            if (Unidentified.Contains(true))
            {
                List<string> ErrorList = new List<string>();
                if (Unidentified[(int)FileFormats.PCV]) ErrorList.Add(".PCV (" + TB.L.Phrase["Core.UnSetted.MainVectorFiles"] + ")");
                if (Unidentified[(int)FileFormats.PCGRAPH]) ErrorList.Add(".PCGRAPH (" + TB.L.Phrase["Core.UnSetted.MainVectorFiles"] +")");
                if (Unidentified[(int)FileFormats.PCVDOC]) ErrorList.Add(".VDOC ("+ TB.L.Phrase["Core.UnSetted.VectorDocument"] + ")");
                if (Unidentified[(int)FileFormats.PRRES]) ErrorList.Add(".PRRES ("+ TB.L.Phrase["Core.UnSetted.OldVectorFiles"] + ")");
                if (Unidentified[(int)FileFormats.PCMACROS]) ErrorList.Add(".PCMACROS ("+ TB.L.Phrase["Core.UnSetted.Macros"] + ")");
                if (Unidentified[(int)FileFormats.PCMPACK]) ErrorList.Add(".PCMPACK ("+ TB.L.Phrase["Core.UnSetted.MacroPacks"] + ")");
                var a = MessageBox.Show(string.Format(TB.L.Phrase["Core.SetAssociation"], string.Join("; ", ErrorList)), TB.L.Phrase["Core.Word.Association"], MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (a == DialogResult.Cancel) { GlobalOptions.IgnoreRegisterExtentions = true; GlobalOptions.Save(); return; }
                else if (a == DialogResult.No) return;
            }
            else return;
            if (!CanWriteRegistry)
            {
                AllertAboutAdmin();
                return;
            }
            if (Unidentified[(int)FileFormats.PCGRAPH]) RegPCGRAPH();
            if (Unidentified[(int)FileFormats.PCV]) RegPCV();
            if (Unidentified[(int)FileFormats.PCVDOC]) RegPCVDOC();
            if (Unidentified[(int)FileFormats.PRRES]) RegPRRES();
            if (Unidentified[(int)FileFormats.PCMACROS]) RegPCMACROS();
            if (Unidentified[(int)FileFormats.PCMPACK]) RegPCMPACK();
            BrendanGrant.FileAssociation.ShellNotification.NotifyOfChange();
        }

        public static bool RegisterAssociation(FileFormats format)
        {
            switch (format)
            {
                case FileFormats.PCGRAPH:
                    try
                    {
                        RegPCGRAPH();
                        return true;
                    }
                    catch { return false; }
                case FileFormats.PCV:
                    try
                    {
                        RegPCV();
                        return true;
                    }
                    catch { return false; }
                case FileFormats.PCVDOC:
                    try
                    {
                        RegPCVDOC();
                        return true;
                    }
                    catch { return false; }
                case FileFormats.PRRES:
                    try
                    {
                        RegPRRES();
                        return true;
                    }
                    catch { return false; }
                case FileFormats.PCMACROS:
                    try
                    {
                        RegPCMACROS();
                        return true;
                    }
                    catch { return false; }
                case FileFormats.PCMPACK:
                    try
                    {
                        RegPCMPACK();
                        return true;
                    }
                    catch { return false; }
                default:
                    return false;
            }
        }

        private static void RegPCV()
        {
            AssociateMain("CNCWFAOPENER.PCV", ".pcv", PerceivedTypes.Image, "vect\\pcv");
            AssociateMainData("CNCWFAOPENER.PCV", TB.L.Phrase["Core.PCV"], EditFlags.None, IconIndex.Icon_PCV);
            AssociateVerb("CNCWFAOPENER.PCV", @" --open_vector ~~%1", TB.L.Phrase["Core.Word.Open"], IconIndex.Icon_Program, "Top");
            AssociateVerb("CNCWFAOPENER.PCV", @" --edit_vector ~~%1", TB.L.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
            AssociateVerb("CNCWFAOPENER.PCV", @" --render_vector ~~%1", TB.L.Phrase["Core.Word.OpenAsImage"], IconIndex.Icon_Contex_OpenPicture);
            AssociateVerb("CNCWFAOPENER.PCV", @" --print_vector ~~%1", TB.L.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
        }

        private static void RegPCGRAPH()
        {
            AssociateMain("CNCWFAOPENER.PCGRAPH", ".pcgraph", PerceivedTypes.Image, "vect\\pcgraph");
            AssociateMainData("CNCWFAOPENER.PCGRAPH", TB.L.Phrase["Core.PCGRAPH"], EditFlags.None, IconIndex.Icon_PCGraph);
            AssociateVerb("CNCWFAOPENER.PCGRAPH", @" --edit_graph ~~%1", TB.L.Phrase["Core.Word.Open"], IconIndex.Icon_Program, "Top");
            AssociateVerb("CNCWFAOPENER.PCGRAPH", @" --edit_graph ~~%1", TB.L.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
            AssociateVerb("CNCWFAOPENER.PCGRAPH", @" --render_graph ~~%1", TB.L.Phrase["Core.Word.OpenAsImage"], IconIndex.Icon_Contex_OpenPicture);
            AssociateVerb("CNCWFAOPENER.PCGRAPH", @" --print_graph ~~%1", TB.L.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
        }

        private static void RegPCVDOC()
        {
            AssociateMain("CNCWFAOPENER.PCVDOC", ".pcvdoc", PerceivedTypes.Image, "vect\\pcvdoc");
            AssociateMainData("CNCWFAOPENER.PCVDOC", TB.L.Phrase["Core.PCVDOC"], EditFlags.None, IconIndex.Icon_PCVDOC);
            AssociateVerb("CNCWFAOPENER.PCVDOC", @" --open_doc ~~%1", TB.L.Phrase["Core.Word.Open"], IconIndex.Icon_Program, "Top");
            AssociateVerb("CNCWFAOPENER.PCVDOC", @" --render_doc ~~%1", TB.L.Phrase["Core.Word.OpenAsImage"], IconIndex.Icon_Contex_OpenPicture);
            AssociateVerb("CNCWFAOPENER.PCVDOC", @" --print_doc ~~%1", TB.L.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
            AssociateVerb("CNCWFAOPENER.PCVDOC", @" --convert_doc ~~%1", TB.L.Phrase["Core.Word.OpenAsVector"], IconIndex.Icon_Contex_Read);
        }

        private static void RegPRRES()
        {
            AssociateMain("CNCWFAOPENER.PRRES", ".prres", PerceivedTypes.Image, "vect\\prres");
            AssociateMainData("CNCWFAOPENER.PRRES", TB.L.Phrase["Core.PRRES"], EditFlags.None, IconIndex.Icon_PRRES);
            AssociateVerb("CNCWFAOPENER.PRRES", @" --open_vector ~~%1", TB.L.Phrase["Core.Word.Open"], IconIndex.Icon_Program, "Top");
            AssociateVerb("CNCWFAOPENER.PRRES", @" --edit_vector ~~%1", TB.L.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
            AssociateVerb("CNCWFAOPENER.PRRES", @" --render_vector ~~%1", TB.L.Phrase["Core.Word.OpenAsImage"], IconIndex.Icon_Contex_OpenPicture);
            AssociateVerb("CNCWFAOPENER.PRRES", @" --print_vector ~~%1", TB.L.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
        }

        private static void RegPCMACROS()
        {
            AssociateMain("CNCWFAOPENER.PCMACROS", ".pcmacros", PerceivedTypes.Image, "vect\\pcmacros");
            AssociateMainData("CNCWFAOPENER.PCMACROS", TB.L.Phrase["Core.PCMACROS"], EditFlags.None, IconIndex.Icon_Macros);
            AssociateVerb("CNCWFAOPENER.PCMACROS", @" --run_macro ~~%1", TB.L.Phrase["Core.Word.Run"], IconIndex.Icon_Contex_Run);
            AssociateVerb("CNCWFAOPENER.PCMACROS", @" --edit_macro ~~%1", TB.L.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
            AssociateVerb("CNCWFAOPENER.PCMACROS", @" --info_macro ~~%1", TB.L.Phrase["Core.Word.Info"], IconIndex.Icon_Contex_Info);
            AssociateVerb("CNCWFAOPENER.PCMACROS", @" --print_macro ~~%1", TB.L.Phrase["Core.Word.Print"], IconIndex.Icon_Contex_Print);
        }

        private static void RegPCMPACK()
        {
            AssociateMain("CNCWFAOPENER.PCMPACK", ".pcmpack", PerceivedTypes.Image, "vect\\macropack");
            AssociateMainData("CNCWFAOPENER.PCMPACK", TB.L.Phrase["Core.PCMPACK"], EditFlags.None, IconIndex.Icon_MacroPack);
            AssociateVerb("CNCWFAOPENER.PCMPACK", @" --open_mpack ~~%1", TB.L.Phrase["Core.Word.Open"], IconIndex.Icon_Program);
            AssociateVerb("CNCWFAOPENER.PCMPACK", @" --edit_mpack ~~%1", TB.L.Phrase["Core.Word.Edit"], IconIndex.Icon_Contex_Edit);
            AssociateVerb("CNCWFAOPENER.PCMPACK", @" --info_mpack ~~%1", TB.L.Phrase["Core.Word.Options"], IconIndex.Icon_Contex_Info);
        }

        public static void DeleteAllAssociations()
        {
            List<string> CantDelete = new List<string>();
            foreach (var item in Enum.GetValues(typeof(FileFormats)))
                if (!DeleteAssociation((FileFormats)item, out AssocDeleteFailReason reason))
                    CantDelete.Add(TB.L.Phrase["Core.ProgID"] + "\"" + ((FileFormats)item).ToString() + "\". Reason(s): " + reason.ToString());
            if (CantDelete.Count != 0) MessageBox.Show(TB.L.Error["Core.CantDeleteNextElems"] + "\n  --" + string.Join("\n  --" ,CantDelete));
        }
        
        public static bool DeleteAssociation(FileFormats index, out AssocDeleteFailReason FailReason)
        {
            RegistryKey a = null;
            string Key = "";
            string DataKey = "";
            switch (index)
            {
                case (FileFormats.PCV):
                    Key = ".pcv";
                    DataKey = ".PCV";
                    break;

                case (FileFormats.PCGRAPH):
                    Key = ".pcgraph";
                    DataKey = ".PCGRAPH";
                    break;

                case (FileFormats.PRRES):
                    Key = ".prres";
                    DataKey = ".PRRES";
                    break;

                case (FileFormats.PCVDOC):
                    Key = ".pcvdoc";
                    DataKey = ".PCVDOC";
                    break;

                case (FileFormats.PCMPACK):
                    Key = ".pcmpack";
                    DataKey = ".PCMPACK";
                    break;

                case (FileFormats.PCMACROS):
                    Key = ".pcmacros";
                    DataKey = ".PCMACROS";
                    break;
            }
            AssocDeleteFailReason reason = AssocDeleteFailReason.unknown;
            try { Registry.ClassesRoot.DeleteSubKeyTree(Key); } catch { reason |= AssocDeleteFailReason.CantDeleteMainTree; }
            try { a = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true); } catch { reason |= AssocDeleteFailReason.CantOpenClassesTree; };
            try { a.DeleteSubKeyTree("CNCWFAOPENER" + DataKey); } catch { reason |= AssocDeleteFailReason.CantDeleteDataTree; }
            FailReason = reason;
            FailReason ^= AssocDeleteFailReason.unknown;
            return reason == AssocDeleteFailReason.unknown;
        }
    }
}
