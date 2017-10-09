/*=================================\
* CWA.DTP\PlotterPacketHandler.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 08.10.2017 20:58:51
*=================================*/

using System;
using System.Collections.Generic;

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

        public bool StartPrinting(UInt16 ElevDelta, Int16 ElevCorr, UInt16 XCoef, UInt16 YCoef, UInt16 Index)
        {
            byte[] ResBuff = new byte[10];
            Buffer.BlockCopy(BitConverter.GetBytes(ElevDelta), 0, ResBuff, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(ElevCorr), 0, ResBuff, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(XCoef), 0, ResBuff, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(YCoef), 0, ResBuff, 6, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Index), 0, ResBuff, 8, 2);
            var res = GetResult((UInt16)CommandType.Plotter_Print_Run, ResBuff);
            return !res.IsEmpty;
        }

        public bool TurnOnEngines()
        {
            return !GetResult((UInt16)CommandType.Plotter_TurnEngines_On).IsEmpty;
        }

        public bool TurnOffEngines()
        {
            return !GetResult((UInt16)CommandType.Plotter_TurnEngines_On).IsEmpty;
        }

        public class PrintStatusRequestResult
        {
            public PrintStatus Status { get; set; } = Plotter.PrintStatus.FailGetStatus;
            public UInt32 Max { get; set; } = 0;
            public UInt32 Curr { get; set; } = 0;
        }

        public PrintStatusRequestResult PrintStatus()
        {
            var res = GetResult((UInt16)CommandType.Plotter_Print_Info);
            var result = new PrintStatusRequestResult();
            if(res.IsEmpty || res.Data.Length != 9)
                return result;
            switch (res.Data[8])
            {
                case(0): result.Status = Plotter.PrintStatus.NotPrinting;
                    return result;
                case(1):
                    result.Status = Plotter.PrintStatus.Printing;
                    break;
                default:
                    return result;
            }
            result.Max = BitConverter.ToUInt32(res.Data, 0);
            result.Curr = BitConverter.ToUInt32(res.Data, 4);
            return result;
        }

        public bool RunFlFormatFile(UInt16 Index)
        {
            return !GetResult((UInt16)CommandType.Plotter_Print_Run_Ex, BitConverter.GetBytes(Index)).IsEmpty;
        }

        public bool MoveTool(Int16 dx, Int16 dy, Int16 dz)
        {
            var result = new List<byte>();
            result.AddRange(BitConverter.GetBytes(dx));
            result.AddRange(BitConverter.GetBytes(dy));
            result.AddRange(BitConverter.GetBytes(dz));
            return !GetResult((UInt16)CommandType.Plotter_Move, result.ToArray()).IsEmpty;
        }

        internal bool PrintingAbort()
        {
            return !GetResult((UInt16)CommandType.Plotter_Print_Abort).IsEmpty;
        }
    }
}
