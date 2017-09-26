/*=================================\
* CWA.DTP\PlotterConfig.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 12.09.2017 21:47:10
*=================================*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace CWA.DTP.Plotter
{
    public class PlotterConfig : AbstractMaster
    {
        private const string ConfigFileName = "/config.cfg";

        private const string PensConfigFileName = "/pens.cfg";

        internal const UInt16 ConfigFileLength = 14;

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

        private static readonly byte[] Separator = new byte[8] { 0, 1, 2, 3, 4, 5, 6, 7};

        public void UploadPenProfiles()
        {
            DTPMaster.CheckConnAndVal();
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

        internal static List<PlotterPenInfo> GetPensFromBytes(byte[] bytes)
        {
            var Pens = new List<PlotterPenInfo>();
            var data = Separate(bytes, Separator);
            foreach (var item in data.ToList().FindAll(p => p.Length != 0))
                Pens.Add(new PlotterPenInfo(item));
            return Pens;
        }

        public void DownloadPenProfiles()
        {
            DTPMaster.CheckConnAndVal();
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
                else Pens = GetPensFromBytes(readRes.Result);
            }
            else throw new FailOperationException("Не удалось получить массив байтов конфиг-файла перьев.");
        }

        public void UploadConfig()
        {
            DTPMaster.CheckConnAndVal();
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
            DTPMaster.CheckConnAndVal();
            var file = Master.CreateFileHandler(ConfigFileName).Open(false);
            var readRes = file.BinnaryFile.ReadByteArray(ConfigFileLength);
            if (readRes.Succeed) Options = new PlotterConfigOptions(readRes.Result);
            else throw new FailOperationException("Не удалось получить массив байтов конфиг-файла.");
            file.Close();
        }

        internal PlotterConfig(DTPMaster master) : base(master)
        {
            DownloadConfig();
            DownloadPenProfiles();
        }
    }
}
