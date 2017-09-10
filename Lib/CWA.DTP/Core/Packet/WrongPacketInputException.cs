/*=================================\
* CWA.DTP\WrongPacketInputException.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 09.09.2017 21:01:28
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

        public Exception BaseException { get; private set; }
        public int TimeOut { get; private set; }
        public int EnteredLen { get; private set; }
        public int BytesToRead { get; private set; }
        public Packet BasePacket { get; private set; }
        public Tuple<byte, byte> ExceptedCRC { get; private set; }
        public Tuple<byte, byte> PacketCRC { get; private set; }

        public override string Message
        {
            get
            {
                switch (Type)
                {
                    case ExceptionType.WrongDataLenInput:
                        return string.Format("Количество полученных данных не совпадает с ожидаеммым. Ожидалось байтов {0}, получено {1}", EnteredLen, BytesToRead);
                    case ExceptionType.WrongDataInput:
                        return string.Format("Некорректный формат полученных данных. Парсер выдал следующие сообщение: {0}. Стек вызовов: {1}.", BaseException.Message, BaseException.StackTrace);
                    case ExceptionType.TimeOut:
                        return string.Format("Превышено время ожидания({0} мс) данных о пакете или их части.", TimeOut);
                    case ExceptionType.WrongSum:
                        return string.Format("Полученная хеш-сумма не совпадает с актуальной. Ошибочный пакет: {0}. Ожидаеммая сумма - {1}, полученная - {2}", BasePacket.ToString(true), ExceptedCRC.ToString(), PacketCRC.ToString());
                    default:
                        return "";
                }
            }
        }


        public ExceptionType Type { get; private set; }

        //TimeOut
        public WrongPacketInputException(int timeOut)
        {
            Type = ExceptionType.TimeOut;
            TimeOut = timeOut;
        }

        //WrongdataInput
        public WrongPacketInputException(Exception baseException)
        {
            Type = ExceptionType.WrongDataInput;
            BaseException = baseException;
        }

        //wrongDataLenInput
        public WrongPacketInputException(int enteredLen, int bytesToRead)
        {
            Type = ExceptionType.WrongDataLenInput;
            EnteredLen = enteredLen;
            BytesToRead = bytesToRead;
        }

        //TODO Конкретную дату под конкретный случай, а лучше конечно же отдельные классы, леньтяй
        //WrongSum
        public WrongPacketInputException(Packet basePacket, Tuple<byte,byte> exceptedCRC, Tuple<byte,byte> packetCRC)
        {
            Type = ExceptionType.WrongSum;
            PacketCRC = packetCRC;
            ExceptedCRC = exceptedCRC;
            BasePacket = basePacket;
        }
    }
}
