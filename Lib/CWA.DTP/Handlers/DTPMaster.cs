/*=================================\
* CWA.DTP\DTPMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 26.09.2017 21:41:34
*=================================*/

using System;
using CWA.DTP.FileTransfer;
using CWA.DTP.Plotter;
using System.Security;

namespace CWA.DTP
{
    public sealed class DTPMaster : IDisposable
    {
        internal static DTPMaster _this; 

        public static DTPMaster CreateFromSerial() => CreateFromSerial(1000, new Sender(SenderType.UnNamedByteMask), true);

        public static DTPMaster CreateFromSerial(int TimeOut) => CreateFromSerial(TimeOut, new Sender(SenderType.UnNamedByteMask), true);

        public static DTPMaster CreateFromSerial(int TimeOut, string SenderName) => CreateFromSerial(TimeOut, new Sender(SenderName), true);

        public static DTPMaster CreateFromSerial(int TimeOut, Sender Sender, bool SyncTime)
        {
            if (SerialPacketReader.FirstAvailable(TimeOut, out var reader, out var writer, out var sender, SyncTime))
            {
                var master = new DTPMaster(Sender, new PacketListener(reader, writer));
                master.Device._deviceSender = sender;
                return master;
            }
            else return null;
        }

        public DTPMaster(IPacketReader reader, IPacketWriter writer) : this(Sender.Empty, new PacketListener(reader, writer))  { }

        public DTPMaster(IPacketReader reader, IPacketWriter writer, string SenderName) : this(new Sender(SenderName), new PacketListener(reader, writer)) { }

        public static void CheckConnAndVal(bool IgnoreValidation = false)
        {
            if (_this == null)
                throw new InvalidOperationException("Выполнение операции без контролирующего мастера");
            if(!IgnoreValidation && !_this.SecurityManager.IsValidated)
                throw new SecurityException("Для выполнения данной операции необходимо пройти валидацию");
            if (_this.isClosed)
                throw new InvalidOperationException("Невозможно выполнить операцию, так как подключение закрыто");
        }

        /*~DTPMaster()
        {
            _this = null;
        }*/

        public DTPMaster(Sender sender, PacketListener listener)
        {
            if (_this != null)
                throw new InvalidOperationException("Уже был создан мастер, пожалуйста используйте его");

            ph = new GeneralPacketHandler(sender, listener);
            Device = new DeviceControl() { ParentMaster = this };
            SecurityManager = new SecurityManager(this);
            _this = this;
        }

        internal GeneralPacketHandler ph;

        public PacketListener Listener => ph.Listener;

        public Sender Sender => ph.Sender;
        
        public DeviceControl Device { get; private set; }

        public SecurityManager SecurityManager { get; private set; }

        public FileSender CreateFileSender(FileTransferSecurityFlags flags) => new FileSender(flags) { Master = this };

        public FileReceiver CreateFileReceiver(FileTransferSecurityFlags flags) => new FileReceiver(flags) { Master = this };

        public SdCardDirectory CreateDirectoryHandler(string Path) => new SdCardDirectory(Path, this);

        public SdCardDirectory CreateDirectoryHandlerFromRoot() => SdCardDirectory.Root(ph);

        public SdCardFile CreateFileHandler(string Path) => new SdCardFile(Path, this);

        public MovingControl CreatePlotterMovingControl() => new MovingControl(this);

        public PlotterConfig CreatePlotterConfig() => new PlotterConfig(this);

        public PlotterContent CreatePlotterContent() => new PlotterContent(this);

        public PrintMaster CreatePlotterPrintMaster(float XMM, float YMM) => new PrintMaster(this, XMM, YMM, 0);

        internal bool isClosed = false;

        public void CloseConnection()
        {
            Listener.PacketReader.Close();
            Listener.PacketWriter.Close();
            isClosed = true;
        }

        public void Dispose()
        {
            CloseConnection();
            _this = null;
        }
    }
}
