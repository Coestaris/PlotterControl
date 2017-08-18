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
* CWA.DTP.Plotter \ VectorMetaData.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:26
*
*=================================*/

using System;
using CWA.Vectors;
using System.Drawing;
using System.Linq;
using System.IO;

namespace CWA.DTP.Plotter
{
    public class VectorMetaData
    {
        private static int CountOfPreviews = 0;

        public string Name { get; internal set; }
        public VectType Type  { get; internal set; }
        public UInt16 Height { get; internal set; }
        public UInt16 Width { get; internal set; }
        public UInt16 Index { get; set; }
        public Bitmap Preview
        {
            get
            {
                if (!LoadedPreview)
                    DownloadPreview();
                return PreviewCache;
            }
        }

        private bool LoadedPreview;
        private Bitmap PreviewCache;
        private PlotterContent Parrent;

        public void DownloadPreview()
        {
            string pcName = string.Format("Data//Cache//{0}.p", Index);
            string dName = string.Format("{0}.p", Index);
            if (File.Exists(pcName))
            {
                UInt32 dCRC32 = Parrent.ContentTable.PreviewHashes[Index];
                UInt32 pcCRC32 = CrCHandler.CRC32(pcName);
                if (dCRC32 == pcCRC32)
                {
                    PreviewCache = new Bitmap(pcName);
                    return;
                };
            }
            var fileSender = Parrent.Master.CreateFileReceiver(FileTransfer.FileTransferSecurityFlags.VerifyLengh);
            fileSender.PacketLength = 2000;
            if (!fileSender.ReceiveFileSync(pcName, dName))
                throw new FileHandlerException("Не удалось передать миниатюру вектора");
            PreviewCache = new Bitmap(pcName);
            LoadedPreview = true;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nWidth: {1}\nHeight: {2}\nType: {3}\nIndex: {4}", Name, Width, Height, Type.ToString(), Index);
        }

        internal VectorMetaData(PlotterContent parrent)
        {
            Parrent = parrent;
        }

        internal VectorMetaData(byte[] data, PlotterContent parrent)
        {
            Parrent = parrent;
            UInt16 stringLen = (UInt16)(data[0] | (data[1] << 8));
            Type = (VectType)data[stringLen + 2];
            Height = (UInt16)(data[stringLen + 3] | (data[stringLen + 4] << 8));
            Width = (UInt16)(data[stringLen + 5] | (data[stringLen + 6] << 8));
            Name = new string(data.Skip(2).Take(stringLen).ToList().FindAll(p=> p!= 0).Select(p=>(char)p).ToArray());
        }

        internal byte[] ToByteArray()
        {
            var arr = new byte[Name.Length + 7];
            arr[0] = (byte)(Name.Length & 0xFF);
            arr[1] = (byte)((Name.Length >> 8) & 0xFF);
            Buffer.BlockCopy(Name.Select(p => (byte)p).ToArray(), 0, arr, 2, Name.Length);
            arr[Name.Length + 2] = (byte)Type;
            arr[Name.Length + 3] = (byte)(Height & 0xFF);
            arr[Name.Length + 4] = (byte)((Height >> 8) & 0xFF);
            arr[Name.Length + 5] = (byte)(Width & 0xFF);
            arr[Name.Length + 6] = (byte)((Width >> 8) & 0xFF);
            return arr;
        }
    }
}
