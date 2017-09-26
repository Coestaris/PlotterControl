/*=================================\
* CWA.DTP\DeviceInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;

namespace CWA.DTP
{
    public sealed class DeviceInfo
    {
        public Board Board { get; internal set; }
        public BoardArchitecture BoardArchitecture { get; internal set; }
        public UInt32 StackFreeMemory { get; internal set; }
        public long CPU_F { get; internal set; }
        public UInt32 GCC_verison { get; internal set; }
        public UInt32 ARD_version { get; internal set; }
        public UInt32 DTP_version { get; internal set; }
        public bool IsConnectSDModule { get; internal set; }
        public bool IsConnectTimeModule { get; internal set; }
        public UInt32 FlashMemorySize { get; internal set; }
        public UInt32 SRAMMemorySize { get; internal set; }

        internal DeviceInfo() { }

        public override string ToString()
        {
            string res = "";
            res += string.Format("Board: {0}\n", Board);
            res += string.Format("BoardArchitecture: {0}\n", BoardArchitecture);
            res += string.Format("StackFreeMemory: {0}\n", StackFreeMemory);
            res += string.Format("FlashMemorySize: {0}\n", FlashMemorySize);
            res += string.Format("SRAMMemorySize: {0}\n", SRAMMemorySize);
            res += string.Format("CPU_F: {0}\n", CPU_F);
            res += string.Format("GCC_verison: {0}\n", GCC_verison);
            res += string.Format("ARD_version: {0}\n", ARD_version);
            res += string.Format("DTP_version: {0}\n", DTP_version);
            res += string.Format("isConnectSDModule: {0}\n", IsConnectSDModule);
            res += string.Format("isConnectTimeModule: {0}", IsConnectTimeModule);
            return res;
        }
    }
}
