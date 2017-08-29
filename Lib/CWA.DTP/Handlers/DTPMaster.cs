/*=================================\
* CWA.DTP\DTPMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 28.08.2017 14:37:22
*=================================*/

using CWA.DTP.FileTransfer;
using System.IO.Ports;
using System.Threading;

namespace CWA.DTP
{
    public sealed partial class DTPMaster
    {
        internal GeneralPacketHandler ph;

        public PacketListener Listener => ph.Listener;

        public Sender Sender => ph.Sender;
        
        public DTPMaster(IPacketReader reader, IPacketWriter writer) : this(Sender.Empty, new PacketListener(reader, writer))  { }

        public DTPMaster(IPacketReader reader, IPacketWriter writer, string SenderName) : this(new Sender(SenderName), new PacketListener(reader, writer)) { }

        public DTPMaster(Sender sender, PacketListener listener)
        {
            ph = new GeneralPacketHandler(sender, listener);
            Device = new DeviceControl() { ParentMaster = this };
        }

        public DeviceControl Device { get; private set; }

        public FileSender CreateFileSender(FileTransferSecurityFlags flags) => new FileSender(flags) { BaseHandler = ph };

        public FileReceiver CreateFileReceiver(FileTransferSecurityFlags flags) => new FileReceiver(flags) { BaseHandler = ph };

        public SdCardDirectory CreateDirectoryHandler(string Path) => new SdCardDirectory(Path, ph);

        public SdCardDirectory CreateDirectoryHandlerFromRoot() => SdCardDirectory.Root(ph);

        public SdCardFile CreateFileHandler(string Path) => new SdCardFile(Path, ph);

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
                SerialPort port = (Listener.PacketWriter as SerialPacketWriter).Port;
                if (port.IsOpen)
                {
                    while (port.BytesToRead != 0) Thread.Sleep(100);
                    lock (port) port.Close();
                }
            }
        }
        
    }
}
