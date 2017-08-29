/*=================================\
* CWA.DTP.Plotter\VectorMetaData.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:34
* Last Edited: 28.08.2017 14:40:09
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
        private bool LoadedPreview;
        private Bitmap PreviewCache;
        private PlotterContent Parrent;

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
            var fileSender = Parrent.Master.CreateFileReceiver(FileTransfer.FileTransferSecurityFlags.VerifyLengh | FileTransfer.FileTransferSecurityFlags.VerifyCheckSum);
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
            LoadedPreview = false;
            Parrent = parrent;
        }

        internal VectorMetaData(byte[] data, PlotterContent parrent)
        {
            LoadedPreview = false;
            Parrent = parrent;
            UInt16 stringLen = (UInt16)(data[0] | (data[1] << 8));
            Type = (VectType)data[stringLen + 2];
            Height = (UInt16)(data[stringLen + 3] | (data[stringLen + 4] << 8));
            Width = (UInt16)(data[stringLen + 5] | (data[stringLen + 6] << 8));
            Name = new string(data.Skip(2).Take(stringLen).ToList().FindAll(p => p != 0).Select(p => (char)p).ToArray());
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
