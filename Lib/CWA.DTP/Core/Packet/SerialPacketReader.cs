/*=================================\
* CWA.DTP\SerialPacketReader.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
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
