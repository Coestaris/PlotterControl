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
* CWA.DTP.Plotter \ PlotterContentTable.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:25
*
*=================================*/

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
