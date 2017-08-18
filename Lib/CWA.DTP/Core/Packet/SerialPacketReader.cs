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
* CWA.DTP \ SerialPacketReader.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:24
*
*=================================*/

using System.IO.Ports;
using System.Threading;

namespace CWA.DTP
{
    public class SerialPacketReader : IPacketReader
    {
        private byte[] Result;
        private bool GetAnsw = false;
        public SerialPort Port { get; private set; }

        public int TimeOutInterval { get; set; } = 5000;
        
        public SerialPacketReader(SerialPort port, int TimeOutInterval)
        {
            this.TimeOutInterval = TimeOutInterval;
            Port = port;
            port.DataReceived += AsyncGetData;
            if (!port.IsOpen) port.Open();
        }

        public void Reset()
        {
            Port.Close();
            Port.Open();
        }

        public SerialPacketReader(SerialPort port)
        {
            Port = port;
            port.DataReceived += AsyncGetData;
            if (!port.IsOpen) port.Open();
        }

        public byte[] Read()
        {
            GetAnsw = false;
            int counter = 0;
            while (counter <= TimeOutInterval)
            {
                counter += 1;
                Thread.Sleep(1);
                if (GetAnsw)
                {
                    GetAnsw = false;
                    return Result;
                }
            }
            throw new WrongPacketInputException(TimeOutInterval);
        }

        private byte[] ReadAsync()
        {
            /* var a = (byte)_port.ReadByte();
             var b = (byte)_port.ReadByte();
             var len = DtpHelper.GetNumber(a, b) - 255;
             if (len < 12) throw new WrongPacketInputException(len, _port.BytesToRead + 2);
             var buffer = new byte[len];
             int total = 0;
             while (total != len - 2)
             {
                 var buffer_ = new byte[len - total - 2];
                 int newLen = _port.Read(buffer_, 0, len - total - 2);
                 Buffer.BlockCopy(buffer_, 0, buffer, 2 + total, newLen);
                 total += newLen;
             }
             return buffer;*/

            var a = (byte)Port.ReadByte();
            var b = (byte)Port.ReadByte();


            var len = HelpMethods.GetNumber(a, b) - 255;
            var buffer = new byte[len];
            buffer[0] = a;
            buffer[1] = b;

            //Console.WriteLine("LEN: {0}. LEN: {1} {2}", len, a, b);
            
            /*byte[] inBuff = new byte[len - 2];
            port.Read(inBuff, 0, len - 2);
            var e = inBuff.ToList();
            e.Insert(0, b);
            e.Insert(0, a);
            */
            for (int i = 0; i <= len - 3; i++)
            {
                buffer[i + 2] = (byte)Port.ReadByte();
            }
            Port.ReadExisting();
            return buffer;
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

        private void AsyncGetData(object sender, SerialDataReceivedEventArgs e)
        {
            Result = ReadAsync();
            GetAnsw = true;
        }
    }
}
