/*=================================\
* CWA.DTP\DTPMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 22.08.2017 21:41:32
*=================================*/

using CWA.DTP.FileTransfer;
using System.IO.Ports;
using System.Threading;

namespace CWA.DTP
{
    public sealed partial class DTPMaster
    {
        internal GeneralPacketHandler ph;

        public PacketListener Listener
        {
            get
            {
                return ph.Listener;
            }
        }

        public Sender Sender
        {
            get
            {
                return ph.Sender;
            }
        }

        public DTPMaster(IPacketReader reader, IPacketWriter writer)
        {
            ph = new GeneralPacketHandler(new Sender(SenderType.SevenByteName), new PacketListener(reader, writer));
            Device = new DeviceControl() { ParentMaster = this };
        }

        public DTPMaster(IPacketReader reader, IPacketWriter writer, string SenderName)
        {
            ph = new GeneralPacketHandler(new Sender(SenderType.SevenByteName, SenderName), new PacketListener(reader, writer));
            Device = new DeviceControl() { ParentMaster = this };
        }

        public DTPMaster(Sender sender, PacketListener listener)
        {
            ph = new GeneralPacketHandler(sender, listener);
            Device = new DeviceControl() { ParentMaster = this };
        }

        public DeviceControl Device { get; private set; }

        public FileSender CreateFileSender(FileTransferSecurityFlags flags)
        {
            return new FileSender(flags)
            {
                BaseHandler = ph
            };
        }

        public FileReceiver CreateFileReceiver(FileTransferSecurityFlags flags)
        {
            return new FileReceiver(flags)
            {
                BaseHandler = ph
            };
        }

        public SdCardDirectory CreateDirectoryHandler(string Path)
        {
            return new SdCardDirectory(Path, ph);
        }

        public SdCardDirectory CreateDirectoryHandlerFromRoot()
        {
            return new SdCardDirectory("/", ph);
        }

        public void CloseConnection()
        {
            if(Listener.PacketReader is SerialPacketReader)
            {
                SerialPort port = (Listener.PacketReader as SerialPacketReader).Port;
                if (port.IsOpen)
                {
                    while (port.BytesToRead != 0) Thread.Sleep(100);
                    lock (port) port.Close();
                }
            }
            if (Listener.PacketWriter is SerialPacketWriter)
            {
                SerialPort port = (Listener.PacketReader as SerialPacketWriter).Port;
                if (port.IsOpen)
                {
                    while (port.BytesToRead != 0) Thread.Sleep(100);
                    lock (port) port.Close();
                }
            }
        }

        public SdCardFile CreateFileHandler(string Path)
        {
            return new SdCardFile(Path, ph);
        }


    }
}
