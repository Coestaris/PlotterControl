/*=================================\
* CWA.DTP\WrongPacketInputException.cs
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
    public class WrongPacketInputException : Exception
    {
        public enum ExceptionType
        {
            WrongDataLenInput,
            WrongDataInput,
            TimeOut,
            WrongSum,
        }

        Exception baseException;

        public ExceptionType Type { get; private set; }

        //TimeOut
        public WrongPacketInputException(int timeOut)
        {
            Type = ExceptionType.TimeOut;
        }

        //WrongdataInput
        public WrongPacketInputException(Exception baseException)
        {
            Type = ExceptionType.WrongDataInput;
        }

        //wrongDataLenInput
        public WrongPacketInputException(int EnteredLen, int BytesToRead)
        {
            Type = ExceptionType.WrongDataLenInput;
        }

        //TODO Конкретную дату под конкретный случай, а лучше конечно же отдельные классы, леньтяй
        //WrongSum
        public WrongPacketInputException(Packet basePacket, Tuple<byte,byte> exceptedCRC, Tuple<byte,byte> packetCRC)
        {
            Type = ExceptionType.WrongSum;
        }
    }
}
