/*=================================\
* CWA.DTP\SerialPacketWriter.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
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

        public static bool FirstAvailable(int TimeOutInterval, out SerialPacketReader reader, out SerialPacketWriter writer)
        {
            reader = null; writer = null;
            var ports = SerialPort.GetPortNames();
            if (ports == null) return false;
            foreach (var item in ports)
            {
                var port = new SerialPort(item, 115200);
                try { port.Open(); }
                catch { return false; }
                if (port.IsOpen)
                {
                    reader = new SerialPacketReader(port, 500);
                    writer = new SerialPacketWriter(port);
                    var a = new GeneralPacketHandler(Sender.Nullable, new PacketListener(reader, writer));
                    if (a.Device_Test())
                    {
                        reader.TimeOutInterval = TimeOutInterval;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            return false;
        }
    }
}
