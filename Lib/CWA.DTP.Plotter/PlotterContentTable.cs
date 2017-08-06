using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.DTP.Plotter
{
    internal class PlotterContentTable
    {
        private const string ConfigFileName = "/ctable.cfg";

        private DTPMaster Master;

        public List<UInt16> VectorAdresses { get; private set; }

        internal Dictionary<UInt16, UInt32> VectorHashes { get; private set; }

        internal Dictionary<UInt16, UInt32> PreviewHashes { get; private set; }

        internal UInt16 CountOfVectors { get; private set; }

        internal byte[] ToByteArray()
        {
            List<byte> bytes = new List<byte>();
            foreach (byte item in VectorAdresses)
            {
                bytes.AddRange(new byte[10] {
                    (byte)(item & 0xFF),
                    (byte)((item >> 8) & 0xFF),
                    (byte)(VectorHashes[item] & 0xFF),
                    (byte)((VectorHashes[item] >> 8) & 0xFF),
                    (byte)((VectorHashes[item] >> 16) & 0xFF),
                    (byte)((VectorHashes[item] >> 24) & 0xFF),
                    (byte)(PreviewHashes[item] & 0xFF),
                    (byte)((PreviewHashes[item] >> 8) & 0xFF),
                    (byte)((PreviewHashes[item] >> 16) & 0xFF),
                    (byte)((PreviewHashes[item] >> 24) & 0xFF)
                });
            }
            return bytes.ToArray();
        }

        internal void Upload()
        {
            var file = Master.CreateFileHandler(ConfigFileName).Open(true);
            if (!file.BinnaryFile.Write(ToByteArray()))
                throw new FailOperationException("Не удалось записать данные таблицы векторов");
            file.Close();
            CountOfVectors = (UInt16)VectorAdresses.Count;
        }

        private void Download()
        {
            var file = Master.CreateFileHandler(ConfigFileName);
            if (!file.IsExists) file.Create();
            file.Open(false);
            var readRes = file.BinnaryFile.ReadByteArray(file.Length);
            if(!readRes.Succeed)
                throw new FailOperationException("Не удалось прочитать таблицы векторов");

            VectorAdresses = new List<UInt16>();
            VectorHashes = new Dictionary<ushort, uint>();
            PreviewHashes = new Dictionary<ushort, uint>();

            if (readRes.Result.Length != 0)
            {
                readRes.Result.Split(10).ToList().ForEach(p =>
                {
                    var a = p.ToArray();
                    VectorAdresses.Add((UInt16)(a[0] | (a[1] << 8)));
                    VectorHashes.Add(VectorAdresses.Last(), (UInt32)((a[5] << 24) | (a[4] << 16) | (a[3] << 8) | a[2]));
                    PreviewHashes.Add(VectorAdresses.Last(), (UInt32)((a[9] << 24) | (a[8] << 16) | (a[7] << 8) | a[6]));
                });
            }

            CountOfVectors = (UInt16)VectorAdresses.Count;
            file.Close();
        }

        internal PlotterContentTable(DTPMaster master)
        {
            Master = master;
            Download();
        }
    }
}
