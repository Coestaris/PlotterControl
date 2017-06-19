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
        static string[] NecessaryDirectrories = { "\\Data", "\\Data\\Images", "\\Data\\Vect", "\\Data\\Macros", "\\Temp", "\\Data\\Vdocs", "\\Logs", "\\Plugins" };

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
            FileAssociation.DiscoverRegistryAccessibility();
            if (!GlobalOptions.IgnoreRegisterExtentions)
            {
                FileAssociation.PathToIcons = execDirectory + "\\Lib\\IconSet.dll";
                FileAssociation.PathToProgram = execDirectory + "\\CNC_WFA.exe";
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
