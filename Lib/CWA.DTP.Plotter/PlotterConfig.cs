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

        private DTPMaster Master;

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
