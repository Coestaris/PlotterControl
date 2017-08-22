/*=================================\
* PlotterControl\CnC_WFA.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 18.08.2017 20:26:46
*=================================*/

using CWA;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;

namespace CnC_WFA
{
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ProgId("CnCWFA")]
    static class CNCWFA
    {
        static string[] NecessaryDirectrories = { "\\Data", "\\Data\\Images", "\\Data\\Vect", "\\Data\\Macros", "\\Temp", "\\Data\\Vdocs", "\\Logs", "\\Plugins", "\\Data\\Cache" };

        [STAThread]
        static void Main()
        {
            string execDirectory = new FileInfo(Application.ExecutablePath).DirectoryName;

            // ---====  CREATING NECESSARY DIRECTORIES  ===---
            foreach (string s in NecessaryDirectrories.Select(p=>p = execDirectory + p)) if (!Directory.Exists(s)) Directory.CreateDirectory(s);

            // ---====  SETUP APPLICATION  ===---

            //    ==GlobalOptions==
            GlobalOptions.Filename = execDirectory + "\\Options\\Options.xml";
            GlobalOptions.BuildFilename = execDirectory + "\\Options\\Build";
            GlobalOptions.Load();
            
            //    ==TranslateBase==
            TranslateBase.LangDirectory = execDirectory + "\\Options\\";
            TranslateBase.Init();
            TranslateBase.CurrentLangName = GlobalOptions.Lang;
            TranslateBase.ProceedLang();

            //    ==GlobalOptionsLogPolitics==
            GlobalOptionsLogPolitics.Filename = execDirectory + "\\Options\\logPolitics.xml";
            GlobalOptionsLogPolitics.OutPutDir = execDirectory + "\\Logs\\";
            GlobalOptionsLogPolitics.Load();

            //    ==CommandLineParser==
            CommandLineParser.CommamndsFileName = execDirectory + "\\Options\\Commands.xml";
            CommandLineParser.Init();

            //    ==CurvePluginHandler==
            CurvePluginHandler.PluginDir = execDirectory + "\\Plugins\\";
            if (GlobalOptions.PreloadPlugins) CurvePluginHandler.Init();

            //    ==Association==
            //FileAssociation.DeleteAllAssociations();
            FileAssociation.PathToIcons = execDirectory + "\\Lib\\IconSet.dll";
            FileAssociation.PathToProgram = execDirectory + "\\Plotter Control.exe";
            FileAssociation.DiscoverRegistryAccessibility();
            if (!GlobalOptions.IgnoreRegisterExtentions)
            {
                FileAssociation.AssociateAll();
            }

            //    ==Application==
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // ---====  STARTING APPLICATION  ===---
            CommandLineParser.Parse(Environment.GetCommandLineArgs());


            // ---====  DELETING TEMPORARY DIRECTORY ===---
            try
            {
                foreach (string s in Directory.GetFiles(new FileInfo(Application.ExecutablePath).DirectoryName + "\\Temp")) File.Delete(s);
                Directory.Delete(new FileInfo(Application.ExecutablePath).DirectoryName + "\\Temp");
            }
            catch { };
        }
    }
}
