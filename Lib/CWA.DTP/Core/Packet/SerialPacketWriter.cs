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
* CWA.DTP \ SerialPacketWriter.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
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
