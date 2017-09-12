/*=================================\
* CWA.DTP\PlotterContentTable.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 12.09.2017 21:45:57
*=================================*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace CWA.DTP.Plotter
{
    internal class PlotterContentTable : AbstractMaster
    {
        private const string ConfigFileName = "/ctable.cfg";

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

        public override string ToString()
        {
            string formatString = "{3}. Adress: {0}, Vector Hash: {1}, Preview Hash: {2}";
            string res = "Vectors:\n"; int counter = 0;
            foreach(var i in VectorAdresses)
                res += string.Format(formatString, i, VectorHashes[i], PreviewHashes[i], counter++) + '\n';
            return res;
        }

        internal static PlotterContentTable FromBytes(byte[] bytes)
        {
            var Result = new PlotterContentTable()
            {
                VectorAdresses = new List<UInt16>(),
                VectorHashes = new Dictionary<ushort, uint>(),
                PreviewHashes = new Dictionary<ushort, uint>()
            };
            if (bytes.Length != 0)
            {
                bytes.Split(10).ToList().ForEach(p =>
                {
                    var a = p.ToArray();
                    Result.VectorAdresses.Add((UInt16)(a[0] | (a[1] << 8)));
                    Result.VectorHashes.Add(Result.VectorAdresses.Last(), (UInt32)((a[5] << 24) | (a[4] << 16) | (a[3] << 8) | a[2]));
                    Result.PreviewHashes.Add(Result.VectorAdresses.Last(), (UInt32)((a[9] << 24) | (a[8] << 16) | (a[7] << 8) | a[6]));
                });
            }
            Result.CountOfVectors = (UInt16)Result.VectorAdresses.Count;
            return Result;
        }

        internal PlotterContentTable(DTPMaster master) : base(master)
        {
            Download();
        }

        internal PlotterContentTable() : base(null) { }
    }
}
