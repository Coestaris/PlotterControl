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

using CWA.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace CnC_WFA
{
    public static class CommandLineParser
    {
        public static string CommamndsFileName;

        public static void Parse(string[] data)
        {
            if (data.Length == 1) { Application.Run(FormTranslator.Translate(new MainWindow())); return; }
            {
                //MessageBox.Show(string.Join(" ", data));
                var data1 = string.Join(" ", data);
                var data2 = data1.Split(' ').ToList().GetRange(1, data1.Split(' ').Length - 1);
                //MessageBox.Show(string.Join(" ", data2));
                CommandParseResult a = null;
                try { a = CommandManagment.Parse(string.Join(" ", data2)); } catch (Exception e) { MessageBox.Show("\"" + string.Join(" ", data2) + "\" - " + TranslateBase.CurrentLang.Error["Core.WrongInputCommand"] + e.Message); }
                MakeAction(a);
            }
        }
        public static void Init()
        {
            if (File.Exists(CommamndsFileName)) CommandManagment.Load();
            else MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["Core.OpenError.VectEditor"], CommamndsFileName));
        }

        [STAThread]
        private static void MakeAction(CommandParseResult res)
        {
            if (res == null)
            {
                Application.Run(FormTranslator.Translate(new MainWindow()));
                return;
            } else
            if (res.Name == "print_vector")
            {
                try
                {
                    if (!File.Exists(res.Filename)) { MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["Core.CantFindFile"], res.Filename)); Application.Run(new MainWindow()); return; }
                    else
                    {
                        string port = res.Flags["port"];
                        int bdrate = int.Parse(res.Flags["bdrate"]);
                        SizeF a = new SizeF();
                        a.Width = float.Parse(res.Flags["size"].Split('x')[0], CultureInfo.InvariantCulture);
                        a.Height = float.Parse(res.Flags["size"].Split('x')[1], CultureInfo.InvariantCulture);
                        bool auto = bool.Parse(res.Flags["auto"]);
                        Application.Run(new Form_PrintMaster(res.Filename, true, port, bdrate, a, auto));
                    }
                } catch (Exception e) { MessageBox.Show(TranslateBase.CurrentLang.Error["Core.OpenError.Print"] + e.Message); Application.Run(new MainWindow()); return; }
            } else
            if (res.Name == "open_vector")
            {
                try
                {
                    if (!File.Exists(res.Filename)) { MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["Core.CantFindFile"], res.Filename)); Application.Run(new MainWindow()); return; }
                    Application.Run(FormTranslator.Translate(new Form_ViewVect(res.Filename, false)));
                } catch(Exception e) { MessageBox.Show(TranslateBase.CurrentLang.Error["Core.OpenError.ViewVect"] + e.Message); Application.Run(new MainWindow()); return; }
            } else
            if (res.Name == "render_vector")
            {
                try
                {
                    if (!File.Exists(res.Filename)) { MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["Core.CantFindFile"], res.Filename)); Application.Run(new MainWindow()); return; }
                    new Vect(res.Filename).ToBitmap(Color.FromName(res.Flags["backcolor"]), Color.FromName(res.Flags["drawcolor"])).Save(new FileInfo(Application.ExecutablePath).Directory.FullName + "\\Temp\\_contex_render_.png");
                    System.Diagnostics.Process.Start(new FileInfo(Application.ExecutablePath).Directory.FullName + "\\Temp\\_contex_render_.png");
                    System.Threading.Thread.Sleep(2000);
                }
                catch (Exception e) { MessageBox.Show(TranslateBase.CurrentLang.Error["Core.OpenError.Render"] + e.Message); Application.Run(new MainWindow()); return; }
            } else
            if(res.Name == "edit_vector")
            {

            }
            if(res.Name == "open_doc")
            {
                try
                {
                    if (!File.Exists(res.Filename)) { MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["Core.CantFindFile"], res.Filename)); Application.Run(new MainWindow()); return; }
                    Application.Run(new Form_EditVector(res.Filename));
                }
                catch (Exception e) { MessageBox.Show(TranslateBase.CurrentLang.Error["Core.OpenError.VectEditor"] + e.Message); Application.Run(new MainWindow()); return; }
            }
        }
    }

    internal class CommandParseResult
    {
        public Command BaseCmd;
        public string Name;

        public bool isContain(string Flag)
        {
            return Flags.ContainsKey(Flag);
        }

        public bool isEmpty()
        {
            return BaseCmd == null;
        }

        public CommandParseResult(Dictionary<string, string> flags, Command cmd)
        {
            BaseCmd = cmd;
            Flags = flags;
            Name = cmd.Name;
        }

        public string Filename;
        public Dictionary<string, string> Flags;
    }

    internal class CommandManagment
    {
        public static List<Command> Commands;

        public static CommandParseResult Parse(string Str)
        {
            string FileName = "";
            string[] flags;
            string flagsdata = "";
            if (Str.Contains('~'))
            {
                var k = Str.Split('~').ToList().FindAll(p => p != "").Select(p => p.Trim()).ToArray();
                if (k.Length != 2)
                {
                    MessageBox.Show(TranslateBase.CurrentLang.Error["Core.MoreThan1FilenameTags"]);
                    return null;
                }
                FileName = k.Last();
                flagsdata = k.First();
            }
            else
            {
                flagsdata = Str;
                FileName = "";
            }
            flags = flagsdata.Split('-').ToList().FindAll(p=>p.Trim()!="").ToArray();
            List<string> fl = new List<string>();
            foreach (var j in flags)
            {
                fl.AddRange(j.Split(')'));
            }
            flags = fl.FindAll(p => p.Trim() != "").Select(p => p.Trim()).ToArray();
           
            string MainCommand = flags.First();
            var h = new Dictionary<string, string>();
            for (int i = 1; i <= flags.Length - 1; i++)
            {
                string name = flags[i].Split('(')[0];
                string value = flags[i].Split('(')[1];
                h.Add(name, value);
            }
            Command cmd = Commands.Find(p => p.Name == MainCommand);
            if (cmd == null)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["Core.UnknownCommand"]);
                return null;
            }
            for(int i =0; i<=h.Count-1; i++)
            {
                if (!cmd.Flags.Select(p => p.Name).Contains(h.Keys.ElementAt(i)))
                {
                    if (cmd.Flags.Count == 0) MessageBox.Show(TranslateBase.CurrentLang.Error["Core.WrongAnyFlags"]);
                    MessageBox.Show(TranslateBase.CurrentLang.Error["Core.WrongFlag"] + string.Join(",", cmd.Flags.Select(p => p.Name)));
                }
            }
            for (int i = 0; i <= cmd.Flags.Count - 1; i++)
            {
                if (!h.ContainsKey(cmd.Flags[i].Name)) h.Add(cmd.Flags[i].Name, (string)cmd.Flags[i].DefValue);
                else { };
            }
            var m = new CommandParseResult(h, cmd);
            m.Filename = FileName;
            return m;
        }

        public static void Load()
        {
            Commands = new List<Command>();
            var a = new XmlDocument();
            a.Load(CommandLineParser.CommamndsFileName);
            for (int i = 0; i <= a.ChildNodes[2].ChildNodes.Count - 1; i++)
            {
                Commands.Add(new Command());
                Commands[i].Name = a.ChildNodes[2].ChildNodes[i].ChildNodes[0].InnerText;
                Commands[i].Flags = new List<Flag>();
                for (int ii = 1; ii <= a.ChildNodes[2].ChildNodes[i].ChildNodes.Count - 1; ii++)
                {
                    Flag fl = new Flag();
                    fl.Name = a.ChildNodes[2].ChildNodes[i].ChildNodes[ii].Attributes[0].Value;
                    fl.Type = Type.GetType(a.ChildNodes[2].ChildNodes[i].ChildNodes[ii].Attributes[1].Value);
                    fl.Id = a.ChildNodes[2].ChildNodes[i].ChildNodes[ii].Attributes[2].Value;
                    fl.Req = bool.Parse(a.ChildNodes[2].ChildNodes[i].ChildNodes[ii].Attributes[3].Value);
                    fl.DefValue = a.ChildNodes[2].ChildNodes[i].ChildNodes[ii].Attributes[4].Value;
                    Commands[i].Flags.Add(fl);
                }
            }
        }
    }

    internal class Command
    {
        public string Name;
        public List<Flag> Flags;
    }

    internal class Flag
    {
        public Type Type;
        public string Name;
        public string Id;
        public bool Req;
        public object DefValue;

        public Flag()
        {
        }
    }
}
