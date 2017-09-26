/*=================================\
* CWA.DTP\SerialPacketWriter.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 20.09.2017 9:31:13
*=================================*/

using System.IO.Ports;
using System.Threading;

namespace CWA.DTP
{
    public sealed class SerialPacketWriter : IPacketWriter
    {
        public SerialPort Port { get; private set; }

        public SerialPacketWriter(SerialPort port)
        {
            Port = port;
            if (!port.IsOpen) port.Open();
        }

        public bool Write(byte[] packet)
        {
            try
            {
                Port.Write(packet, 0, packet.Length);
                return true;
            }
            catch { return false; }
            
        }

        public void Close()
        {
            if (Port != null && Port.IsOpen)
            {
                //Пока есть какие-то байты для чтения, ничего не делать
                while (Port.BytesToRead != 0) Thread.Sleep(10);
                //Закрываем порт
                lock (Port) Port.Close();
            }
        }
    }
}
