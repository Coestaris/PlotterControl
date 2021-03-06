/*=================================\
* CWA.DTP\SerialPacketReader.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 08.10.2017 20:40:01
*=================================*/

using System.IO.Ports;
using System.Threading;

namespace CWA.DTP
{
    public sealed class SerialPacketReader : IPacketReader
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
            var lowLenByte = (byte)Port.ReadByte();
            var highLenByte = (byte)Port.ReadByte();
            var Length = HelpMethods.GetNumber(lowLenByte, highLenByte) - 255;
            var buffer = new byte[Length];
            buffer[0] = lowLenByte;
            buffer[1] = highLenByte;
            for (int i = 0; i <= Length - 3; i++)
            {
                buffer[i + 2] = (byte)Port.ReadByte();
            }
            Port.ReadExisting();
            return buffer;
        }

        internal static bool FirstAvailable(
            int TimeOutInterval,
            out SerialPacketReader reader, 
            out SerialPacketWriter writer,
            out Sender sender,
            bool SyncTyme)
        {
            sender = null;
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
                    var a = new GeneralPacketHandler(Sender.Empty, new PacketListener(reader, writer));
                    var res = a.Device_Test();
                    if(res != null)
                    {
                        if (SyncTyme)
                            if (a.Device_SyncTime() == -1)
                                throw new FailOperationException("��������� ���������������� �����.");
                        reader.TimeOutInterval = TimeOutInterval;
                        sender = res;
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

        public void Close()
        {
            if (Port != null && Port.IsOpen)
            {
                //���� ���� �����-�� ����� ��� ������, ������ �� ������
                while (Port.BytesToRead != 0) Thread.Sleep(10);
                //��������� ����
                lock (Port) Port.Close();
            }
        }
    }
}
