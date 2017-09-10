/*=================================\
* CWA.DTP\SerialPacketWriter.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 09.09.2017 20:39:00
*=================================*/

using System.IO.Ports;

namespace CWA.DTP
{
    public class SerialPacketWriter : IPacketWriter
    {
        public SerialPort Port { get; private set; }

        public SerialPacketWriter(SerialPort port)
        {
            Port = port;
            if (!port.IsOpen) port.Open();
        }

        public bool Write(byte[] packet)
        {
            Port.Write(packet, 0, packet.Length);
            return true; //Always okay
        }
    }
}
