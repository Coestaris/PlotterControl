/*=================================\
* CWA.DTP\PacketListener.cs
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
    public class PacketListener
    {
        public IPacketReader PacketReader { get; set; }

        public IPacketWriter PacketWriter { get; set; }

        public PacketListener(IPacketReader reader, IPacketWriter writer)
        {
            PacketReader = reader;
            PacketWriter = writer;
        }
        
        public PacketAnswer SendAndListenPacket(Packet packet)
        {
            if (packet == null || packet.IsEmpty || packet.TotalData == null) throw new ArgumentException(nameof(packet));
            PacketWriter.Write(packet.TotalData);
            //Console.WriteLine("Sended packet");
            var result = PacketReader.Read();
            //Console.WriteLine("Readed packet");
            return new PacketAnswer(Packet.ParsePacket(result, result.Length));
        }
    }
}
