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

using CWA.Vectors;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public static class CurvePluginHandler
    {
        public static string PluginDir;

        public static List<CurveScript> LoadedPlugins;

        public static void Init()
        {
            LoadedPlugins = new List<CurveScript>();
            foreach (string s in Directory.GetFiles(PluginDir, "Curve_*.cs")) LoadedPlugins.Add(new CurveScript(s));
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
        public Func<ToVectorParams, Vect> GetVector;

        public CurveScript(string Filename)
        {
            ExecuteScript(File.ReadAllText(Filename));
            Init();
            Info = GetInfo();
            FileName = Filename;
            Name = Info.Name;
        }

        private Type _baseType;

        private void ExecuteScript(string program)
        {
            var CSHarpProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };
            compilerParams.ReferencedAssemblies.AddRange(new string[]
            {
                "System.dll",
                "System.Core.dll",
                "System.Net.dll",
                "System.Drawing.dll",
                 "Lib\\CWA_Vectors.dll",
                 Application.ExecutablePath
            });
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
                    GetVector = (Func<ToVectorParams, Vect>)Delegate.CreateDelegate(typeof(Func<ToVectorParams, Vect>), _baseType.GetMethod("GetVector"));
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

    public class CurveInfo
    {
        public string LearnMore;
        public Language Language;
        public string Discription;
        public string Name;
        public string Creator;
        public string Usage;
        public string MathematicalBasis;
    }
}
