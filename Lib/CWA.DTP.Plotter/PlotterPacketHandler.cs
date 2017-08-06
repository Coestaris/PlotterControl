﻿/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

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
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWA.DTP.Plotter
{
    internal class PlotterPacketHandler : AbstractPakcetHandler
    {
        public PlotterPacketHandler(Sender sender, PacketListener listener)
        {
            Listener = listener;
            Sender = sender;
        }

        public bool RefreshConfig()
        {
            var res = GetResult((UInt16)CommandType.Plotter_RefreshConfig);
            return !res.IsEmpty;
        }

        public bool StartPrinting(UInt16 XCoef, UInt16 YCoef, UInt16 Index)
        {
            byte[] ResBuff = new byte[6];
            Buffer.BlockCopy(BitConverter.GetBytes(XCoef), 0, ResBuff, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(YCoef), 0, ResBuff, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Index), 0, ResBuff, 4, 2);
            var res = GetResult((UInt16)CommandType.Plotter_Print_Run, ResBuff);
            return !res.IsEmpty;
        }
/*
        Plotter_RefreshConfig = 0x120,
        Plotter_Print_Run = 0x121,
        Plotter_Print_Info = 0x122,
        Plotter_Print_Abort = 0x123,*/
    }
}
