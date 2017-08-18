/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

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
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.DTP.Plotter \ PlotterConfig.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:25
*
*=================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.DTP.Plotter
{
    public class PlotterConfig
    {
        private const string ConfigFileName = "/config.cfg";

        private const string PensConfigFileName = "/pens.cfg";

        internal const UInt16 ConfigFileLength = 14;

        public DTPMaster Master { get; set; }

        public List<PlotterPenInfo> Pens { get; private set; }

        public PlotterConfigOptions Options { get; private set; }

        private static bool Equals(byte[] source, byte[] separator, int index)
        {
            for (int i = 0; i < separator.Length; ++i)
                if (index + i >= source.Length || source[index + i] != separator[i])
                    return false;
            return true;
        }

        public static byte[][] Separate(byte[] source, byte[] separator)
        {
            var Parts = new List<byte[]>();
            var Index = 0;
            byte[] Part;
            for (var I = 0; I < source.Length; ++I)
            {
                if (Equals(source, separator, I))
                {
                    Part = new byte[I - Index];
                    Array.Copy(source, Index, Part, 0, Part.Length);
                    Parts.Add(Part);
                    Index = I + separator.Length;
                    I += separator.Length - 1;
                }
            }
            Part = new byte[source.Length - Index];
            Array.Copy(source, Index, Part, 0, Part.Length);
            Parts.Add(Part);
            return Parts.ToArray();
        }

        private readonly byte[] Separator = new byte[8] { 0, 1, 2, 3, 4, 5, 6, 7};

        public void UploadPenProfiles()
        {
            List<byte> data = new List<byte>();
            foreach(var a in Pens)
            {
                data.AddRange(a.ToByteArray());
                data.AddRange(Separator);
            }
            var file = Master.CreateFileHandler(PensConfigFileName);
            if (!file.IsExists)
                file.Create();
            file.Open(true);
            file.BinnaryFile.Write(data.ToArray());
            file.Close();
        }

        public void DownloadPenProfiles()
        {
            Pens = new List<PlotterPenInfo>();
            var file = Master.CreateFileHandler(PensConfigFileName);
            if (!file.IsExists)
                return;
            file.Open(false);
            var readRes = file.BinnaryFile.ReadByteArray(file.Length);
            file.Close();
            if (readRes.Succeed)
            {
                if (readRes.Result.Length == 0)
                    return;
                else
                {
                    var data = Separate(readRes.Result, Separator);
                    foreach (var item in data.ToList().FindAll(p=>p.Length != 0))
                        Pens.Add(new PlotterPenInfo(item));
                }
            }
            else throw new FailOperationException("Не удалось получить массив байтов конфиг-файла перьев.");
        }

        public void UploadConfig()
        {
            var file = Master.CreateFileHandler(ConfigFileName).Open(true);
            if (!file.BinnaryFile.Write(Options.ToByteArray()))
                throw new FailOperationException("Не удалось записать данные конфиг-файла");
            file.Close();
            var ph = new PlotterPacketHandler(Master.Sender, Master.Listener);
            if (!ph.RefreshConfig())
                throw new FailOperationException("Не удалось обновить конфиг");
        }

        public void DownloadConfig()
        {
            var file = Master.CreateFileHandler(ConfigFileName).Open(false);
            var readRes = file.BinnaryFile.ReadByteArray(ConfigFileLength);
            if (readRes.Succeed) Options = new PlotterConfigOptions(readRes.Result);
            else throw new FailOperationException("Не удалось получить массив байтов конфиг-файла.");
            file.Close();
        }

        public PlotterConfig(DTPMaster master)
        {
            Master = master;
            DownloadConfig();
            DownloadPenProfiles();
        }
    }
}
