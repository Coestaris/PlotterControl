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
* CWA.DTP \ DTPMaster.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:25
*
*=================================*/

using CWA.DTP.FileTransfer;

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

        public SdCardFile CreateFileHandler(string Path)
        {
            return new SdCardFile(Path, ph);
        }


    }
}
