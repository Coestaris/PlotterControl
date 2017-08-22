/*=================================\
* CWA.DTP\CardInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;
using System.Linq;

namespace CWA.DTP
{
    public class CardInfo
    {
        public UInt32 DataStartBlock { get; internal set; }
        public UInt32 RootDirStart { get; internal set; }
        public UInt32 BlocksPerFat { get; internal set; }
        public UInt32 FatCount { get; internal set; }
        public UInt32 FatStartBlock { get; internal set; }
        public UInt32 FreeSpace { get; internal set; }
        public UInt32 FreeClusters { get; internal set; }
        public UInt32 ClusterCount { get; internal set; }
        public byte BlocksPerCluster { get; internal set; }
        public SdCardFatType FatType { get; internal set; }
        public bool EraseSingleBlock { get; internal set; }
        public byte FlashEraseSize { get; internal set; }
        public UInt32 CardSize { get; internal set; }
        public CardType Type { get; internal set; }
        public byte ManufacturingDateMonth { get; internal set; }
        public short ManufacturingDateYear { get; internal set; }
        public UInt32 SerialNumber { get; internal set; }
        public byte MinorVersion { get; internal set; }
        public byte MajorVersion { get; internal set; }
        public byte[] ProductVersion { get; internal set; }
        public string OEMID { get; internal set; }
        public byte ManufacturerID { get; internal set; }

        internal CardInfo() { }

        public override string ToString()
        {
            string res = "";
            res += string.Format("SD Type: {0}\n", Type);
            res += string.Format("Manufacturer ID: 0x{0}\n", ManufacturerID.ToString("X"));
            res += string.Format("OEM ID: {0}\n", OEMID);
            res += string.Format("Product: {0}\n", string.Join("", ProductVersion.Select(p => (char)p)));
            res += string.Format("Version: {0}{1}\n", MajorVersion, MinorVersion);
            res += string.Format("Serial number: 0x{0}\n", SerialNumber.ToString("X"));
            res += string.Format("Manufacturing date: {0}/{1}\n", ManufacturingDateMonth, ManufacturingDateYear);
            res += string.Format("CardSize: {0} MB\n", CardSize);
            res += string.Format("FlashEraseSize: {0}\n", FlashEraseSize);
            res += string.Format("EraseSingleBlock: {0}\n", EraseSingleBlock);
            res += string.Format("Volume is FAT{0}\n", (int)FatType);
            res += string.Format("BlocksPerCluster: {0}\n", BlocksPerCluster);
            res += string.Format("ClusterCount: {0}\n", ClusterCount);
            res += string.Format("FreeClusters: {0}\n", FreeClusters);
            res += string.Format("FreeSpace: {0} MB\n", FreeSpace);
            res += string.Format("FatStartBlock: {0}\n", FatStartBlock);
            res += string.Format("FatCount: {0}\n", FatCount);
            res += string.Format("BlocksPerFat: {0}\n", BlocksPerFat);
            res += string.Format("RootDirStart: {0}\n", RootDirStart);
            res += string.Format("DataStartBlock: {0}", DataStartBlock);
            return res;
        }
    }
}
