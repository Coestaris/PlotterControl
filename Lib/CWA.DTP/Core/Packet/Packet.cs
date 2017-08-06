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
using System.Linq;
using System.Text;

namespace CWA.DTP
{
    public struct Packet
    {
        public short Size { get; set; }
        public UInt16 Command { get; set; }
        public Sender Sender { get; set; }
        public byte[] Data { get; set; }
        public byte[] Crc { get; set; }

        public bool IsEmpty { get; set; }

        public byte[] TotalData { get; set; }

        public static Packet NULL
        {
            get { return new Packet() { IsEmpty = true }; }
        }

        public Packet(byte[] data, UInt16 command, Sender sender)
        {
            Data = data;
            Command = command;
            Sender = sender;
            CrCHandler crc = new CrCHandler();
            Crc = crc.ComputeChecksumBytes(data);
            Size = (short)(data.Length + 14);
            TotalData = new byte[0];
            IsEmpty = false;
        }

        public override string ToString()
        {
            if (TotalData != null) return string.Format("Packet[{0}. Data: {1}]", Sender.ToString(), string.Join("", Data.Select(p => (char)p)));
            else return string.Format("Packet[{0}. Data: {1}]", Sender.ToString(), string.Join("", TotalData.Select(p => (char)p)));
        }

        public static bool operator !=(Packet first, Packet second)
        {
            if (first == second) return false;
            else return true;
        }

        public static bool operator ==(Packet first, Packet second)
        {
            if (first.Command == second.Command &&
                Enumerable.SequenceEqual(first.Data, second.Data) &&
                first.Sender == second.Sender) return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            if (typeof(Packet) != obj.GetType()) return false;
            return this == (Packet)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ToString(bool v)
        {
            if (TotalData != null) return string.Format("Packet[{0}. Data: {1}]", Sender.ToString(), string.Join(",", TotalData.Select(p => p.ToString())));
            else return string.Format("Packet[{0}. Data: {1}]", Sender.ToString(), string.Join(",", Data.Select(p => p.ToString())));
        }

        public static Packet ParsePacket(byte[] data, int len)
        {
            try
            {
                var a = new Packet()
                {
                    TotalData = data
                };
                var command = (UInt16)HelpMethods.GetNumber(data[2], data[3]);
                var sender = new Sender(SenderType.UnNamedByteMask);
                var sendertype = (SenderType)data[4];
                sender.Type = sendertype;
                Buffer.BlockCopy(data, 5, sender.Mask, 0, 7);
                if (sendertype == SenderType.SevenByteName) sender.Name = Encoding.Default.GetString(sender.Mask);
                a.Sender = sender;
                a.Size = (short)len;
                a.Command = command;
                a.Data = new byte[len - 14];
                Buffer.BlockCopy(data, 12, a.Data, 0, len - 14);
                CrCHandler crc = new CrCHandler();
                a.Crc = new byte[2] { data[data.Length - 2], data[data.Length - 1] };
                var newCrc = crc.ComputeChecksumBytes(a.Data);
                if (a.Crc[0] != newCrc[0] || a.Crc[1] != newCrc[1]) throw new WrongPacketInputException(a, new Tuple<byte, byte>(newCrc[0], newCrc[1]), new Tuple<byte, byte>(a.Crc[0], a.Crc[1]));
                return a;
            }
            catch(Exception e)
            {
                throw new WrongPacketInputException(e);
            }
        }

        static public Packet GetPacket(UInt16 type, byte[] data, Sender sender)
        {
            var result = new Packet(data, type, sender);
            var resdata = new byte[result.Size];
            var sizeBytes = HelpMethods.SplitNumber(result.Size + 255);
            resdata[0] = sizeBytes.Item1;
            resdata[1] = sizeBytes.Item2;
            var commandBytes = HelpMethods.SplitNumber((UInt16)type);
            resdata[2] = commandBytes.Item1;
            resdata[3] = commandBytes.Item2;
            resdata[4] = (byte)sender.Type;
            Buffer.BlockCopy(sender.Mask, 0, resdata, 5, 7);
            Buffer.BlockCopy(data, 0, resdata, 12, data.Length);
            Buffer.BlockCopy(result.Crc, 0, resdata, 12 + data.Length, 2);
            result.TotalData = resdata;
            return result;
        }
    }
}