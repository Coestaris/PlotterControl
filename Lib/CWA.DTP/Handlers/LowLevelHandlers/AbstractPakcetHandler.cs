/*=================================\
* CWA.DTP\AbstractPakcetHandler.cs
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
    public abstract class AbstractPakcetHandler
    {
        protected static readonly byte[] EmptyData = { 1 };

        protected PacketAnswer GetResult(UInt16 command)
        {
            return Listener.SendAndListenPacket(Packet.GetPacket(command, EmptyData, Sender));
        }

        protected PacketAnswer GetResult(UInt16 command, byte[] data)
        {
            return Listener.SendAndListenPacket(Packet.GetPacket(command, data, Sender));
        }

        public Sender Sender { get; set; }

        public PacketListener Listener { get; set; }
    }
}
