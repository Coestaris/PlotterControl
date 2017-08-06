using CWA.DTP.FileTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.DTP
{
    public sealed class DTPMaster
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

        public SdCardFile CreateFileHandler(string Path)
        {
            return new SdCardFile(Path, ph);
        }
    }
}
