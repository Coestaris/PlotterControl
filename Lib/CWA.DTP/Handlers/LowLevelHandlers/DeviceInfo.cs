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
* CWA.DTP \ DeviceInfo.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
*=================================*/

using System;

namespace CWA.DTP
{
    public class DeviceInfo
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
            res += string.Format("isConnectTimeModule: {0}\n", IsConnectTimeModule);
            return res;
        }
    }
}
