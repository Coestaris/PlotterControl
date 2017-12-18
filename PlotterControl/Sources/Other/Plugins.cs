/*=================================\
* PlotterControl\Plugins.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 17.06.2017 21:04
* Last Edited: 19.08.2017 22:50:50
*=================================*/

using CWA;
using CWA.Vectors;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CnC_WFA
{
    public static class CurvePluginHandler
    {
        public static string PluginDir;

        public static List<CurveScript> LoadedPlugins;

        private static string DLLNameFormat;

        public static void Init()
        {
            DLLNameFormat = PluginDir + "Compiled\\{0}.dll";

            if (!Directory.Exists(PluginDir + "Compiled"))
                Directory.CreateDirectory(PluginDir + "Compiled");

            //if (File.Exists(PluginDir + "Compiled\\Compiled.zip"))
            //ZipFile.ExtractToDirectory(PluginDir + "Compiled\\Compiled.zip", PluginDir + "Compiled");

            LoadedPlugins = new List<CurveScript>();
            foreach (string s in Directory.GetFiles(PluginDir, "Curve_*.cs"))
                if (!File.Exists(string.Format(DLLNameFormat, new FileInfo(s).Name)))
                     LoadedPlugins.Add(new CurveScript(s));
                else if (new FileInfo(string.Format(DLLNameFormat, new FileInfo(s).Name)).CreationTime < new FileInfo(s).CreationTime)
                    LoadedPlugins.Add(new CurveScript(s));
                else LoadedPlugins.Add(new CurveScript(string.Format(DLLNameFormat, new FileInfo(s).Name), true));
            
            //File.Delete(PluginDir + "Compiled\\Compiled.zip");
            //File.Delete(PluginDir + "Compiled.zip");
            //ZipFile.CreateFromDirectory(PluginDir + "Compiled\\", PluginDir + "Compiled.zip");
            //File.Move(PluginDir + "Compiled.zip", PluginDir + "\\Compiled\\Compiled.zip");
        }

        public static void Dispose()
        {
            LoadedPlugins = new List<CurveScript>();
        }
    }

    public struct CurveExample
    {
        public string Discr;
        public Image image;
    }

    public class GifImage
    {
        private Image gifImage;
        private FrameDimension dimension;
        private int frameCount;
        private int currentFrame = -1;
        private bool reverse;
        private int step = 1;

        public GifImage(string path)
        {
            gifImage = Image.FromFile(path);
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            frameCount = gifImage.GetFrameCount(dimension);
        }

        public bool ReverseAtEnd
        {
            get { return reverse; }
            set { reverse = value; }
        }

        public Image GetNextFrame()
        {
            currentFrame += step;
            if (currentFrame >= frameCount || currentFrame < 1)
            {
                if (reverse)
                {
                    step *= -1;
                    currentFrame += step;
                }
                else currentFrame = 0;
            }
            return GetFrame(currentFrame);
        }

        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index);
            return (Image)gifImage.Clone();
        }
    }

    public class CurveScript
    {
        public string Name;
        public string FileName;
        public CurveInfo Info;
        
        public Action Init;
        public Func<CurveExample> Exmpl1;
        public Func<CurveExample> Exmpl2;
        public Func<CurveInfo> GetInfo;
        public Func<Size, double, object, double, Image> PreviewImage;
        public Func<GifImage> PreviewImageGif;
        public Func<ToVectorParams, Vector> GetVector;

        public CurveScript(string Filename)
        {
            FileName = Filename;
            ExecuteScript(File.ReadAllText(Filename, Encoding.ASCII));
            Init();
            Info = GetInfo();
            Name = Info.Name;
        }

        public CurveScript(string Filename, bool v)
        {
            FileName = Filename;
            Assembly dll = Assembly.LoadFile(FileName);
            try
            {
                _baseType = dll.GetType("Plugins.CurvePlugin");
                Init = (Action)Delegate.CreateDelegate(typeof(Action), _baseType.GetMethod("Init"));
                GetInfo = (Func<CurveInfo>)Delegate.CreateDelegate(typeof(Func<CurveInfo>), _baseType.GetMethod("GetInfo"));
                PreviewImage = (Func<Size, double, object, double, Image>)Delegate.CreateDelegate(typeof(Func<Size, double, object, double, Image>), _baseType.GetMethod("PreviewImage"));
                PreviewImageGif = (Func<GifImage>)Delegate.CreateDelegate(typeof(Func<GifImage>), _baseType.GetMethod("PreviewImageGif"));
                GetVector = (Func<ToVectorParams, Vector>)Delegate.CreateDelegate(typeof(Func<ToVectorParams, Vector>), _baseType.GetMethod("GetVector"));
                Exmpl1 = (Func<CurveExample>)Delegate.CreateDelegate(typeof(Func<CurveExample>), _baseType.GetMethod("Exmpl1"));
                Exmpl2 = (Func<CurveExample>)Delegate.CreateDelegate(typeof(Func<CurveExample>), _baseType.GetMethod("Exmpl2"));
                //Console.WriteLine("Done.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n============\n" + e.StackTrace);
                Environment.Exit(0);
            }
            Init();
            Info = GetInfo();
            Name = Info.Name;
        }

        private Type _baseType;

        const string CompileInfo  = 
@"[assembly: AssemblyTitle({0})] 
[assembly: AssemblyDescription({1})]
[assembly: AssemblyConfiguration({2})] 
[assembly: AssemblyCompany({3})]
[assembly: AssemblyProduct({4})] 
[assembly: AssemblyCopyright({5})]
[assembly: AssemblyTrademark({6})] 
[assembly: AssemblyCulture({7})] 
[assembly: ComVisible({8})] 
[assembly: AssemblyVersion({9})]
[assembly: AssemblyFileVersion({10})]";

        private void ExecuteScript(string program)
        {
            var CSHarpProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                OutputAssembly = CurvePluginHandler.PluginDir + "Compiled\\" + new FileInfo(FileName).Name + ".dll"
            };
            compilerParams.ReferencedAssemblies.AddRange(new string[]
            {
                "System.dll",
                "System.Core.dll",
                "System.Net.dll",
                "System.Drawing.dll",
                 "Lib\\CWA.Vectors.dll",
                 Application.ExecutablePath
            });

            compilerParams.IncludeDebugInformation = true;
            compilerParams.CompilerOptions = "/debug:pdbonly";

            string compInfo = string.Format(CompileInfo, 
                "\"Plugin: " + new FileInfo(FileName).Name.Split('.').First().Split('_').Last() + '\"',
                "\"Compiled Plugin For Plotter Control\"",
                "\"Debug\"",
                "\"Coestaris\"",
                "\"Plotter Control\"",
                "\"Copyright ??  2016-2017\"",
                "\"\"",
                "\"\"",
                "false",
                '\"' + GlobalOptions.Ver + '\"',
                '\"' + GlobalOptions.Ver + '\"'
                );

            program = program.Replace("/*ASSEMBLY INFO*/", compInfo);
            var compilerResult = CSHarpProvider.CompileAssemblyFromSource(compilerParams, program);
            if (compilerResult.Errors.Count == 0)
            {
                try
                {
                    _baseType = compilerResult.CompiledAssembly.GetType("Plugins.CurvePlugin");
                    Init = (Action)Delegate.CreateDelegate(typeof(Action), _baseType.GetMethod("Init"));
                    GetInfo = (Func<CurveInfo>)Delegate.CreateDelegate(typeof(Func<CurveInfo>), _baseType.GetMethod("GetInfo"));
                    PreviewImage = (Func<Size, double, object, double, Image>)Delegate.CreateDelegate(typeof(Func<Size, double, object, double, Image>), _baseType.GetMethod("PreviewImage"));
                    PreviewImageGif = (Func<GifImage>)Delegate.CreateDelegate(typeof(Func<GifImage>), _baseType.GetMethod("PreviewImageGif"));
                    GetVector = (Func<ToVectorParams, Vector>)Delegate.CreateDelegate(typeof(Func<ToVectorParams, Vector>), _baseType.GetMethod("GetVector"));
                    Exmpl1 = (Func<CurveExample>)Delegate.CreateDelegate(typeof(Func<CurveExample>), _baseType.GetMethod("Exmpl1"));
                    Exmpl2 = (Func<CurveExample>)Delegate.CreateDelegate(typeof(Func<CurveExample>), _baseType.GetMethod("Exmpl2"));
                    //Console.WriteLine("Done.");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "\n============\n" + e.StackTrace);
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show(string.Join("\n", compilerResult.Output.Cast<string>()));
                Environment.Exit(0);
            }
        }
    }

    public class ToVectorParams
    {

    }

    [Serializable]
    public class CurveInfo
    {
        public string LearnMore { get; set; } 
        public string Language { get; set; }
        public string Discription { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Usage { get; set; }
        public string MathematicalBasis { get; set; }

        public CurveInfo() { }

        public CurveInfo(string learnMore, string language, string discription, string name, string creator, string usage, string mathematicalBasis)
        {
            LearnMore = learnMore;
            Language = language;
            Discription = discription;
            Name = name;
            Creator = creator;
            Usage = usage;
            MathematicalBasis = mathematicalBasis;
        }
    }
}
