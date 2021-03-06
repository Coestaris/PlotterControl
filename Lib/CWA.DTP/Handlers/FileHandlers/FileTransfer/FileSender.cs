/*=================================\
* CWA.DTP\FileSender.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 23.08.2017 19:19:50
*=================================*/

using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace CWA.DTP.FileTransfer
{
    public sealed class FileSender
    {
        private byte[] _data;

        private bool CheckSum { get; set; } = true;

        private bool CheckLen { get; set; } = true;

        public int PacketLength { get; set; } = 3200;

        internal DTPMaster Master;

        internal FileSender(int _packetLength, FileTransferSecurityFlags flags)
        {
            CheckSum = flags.HasFlag(FileTransferSecurityFlags.VerifyCheckSum);
            CheckLen = flags.HasFlag(FileTransferSecurityFlags.VerifyLengh);
            PacketLength = _packetLength;
        }

        internal FileSender(FileTransferSecurityFlags flags)
        {
            CheckSum = (flags & FileTransferSecurityFlags.VerifyCheckSum) != 0;
            CheckLen = (flags & FileTransferSecurityFlags.VerifyLengh) != 0;
        }

        public event FileTrasferProcessHandler SendingProcessChanged;

        public event FileTrasferEndHandler SendingEnd;

        public event FileSenderErrorHandler SendingError;

        private void RaiseProcessEvent(FileTransferProcessArgs arg)
        {
            Counter = (int)arg.PacketTrasfered;
            Total = arg.PacketTrasfered + arg.PacketsLeft;
            SendingProcessChanged?.Invoke(arg);
        }

        private void RaiseEndEvent(FileTransferEndArgs arg)
        {
            TimerThread.Abort();
            SendingEnd?.Invoke(arg);
        }

        private void RaiseErrorEvent(FileSenderErrorArgs arg)
        {
            SendingError?.Invoke(arg);
            if (arg.IsCritical)
            {
                SenderThread?.Abort();
                TimerThread.Abort();
            }
        }

        public void StopAsync()
        {
            if (SenderThread == null)
                throw new InvalidOperationException("Отправка либо не запущена, либо запущена как синхронный процесс (если так, то я хз был вызван этот метод -_-)");
            ForceStop = true;
            while (SenderThread.ThreadState == ThreadState.Running) Thread.Sleep(10);
            if (!Master.ph.File_Close())
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantCloseFile, false));
            TimerThread.Abort();
        }

        private bool HandleFiles(string NewName)
        {
            var res = Master.ph.File_Create(NewName);
            if (res == GeneralPacketHandler.FileDirHandleResult.Fail)
            {
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantCreateFile, true));
                return false;
            }

            /*if(res == PacketHandler.FileDirHandleResult.FileOrDirAlreadyExist)
            {
                if (BaseHandler.File_Delete(NewName) == PacketHandler.FileDirHandleResult.Fail)
                {
                    RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantDeleteFile, true));
                    return false;
                }
                if (BaseHandler.File_Create(NewName) == PacketHandler.FileDirHandleResult.Fail)
                {
                    RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantCreateFile, true));
                    return false;
                }
            }*/

            if (Master.ph.File_Open(NewName, true) != GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantOpenFile, true));
                return false;
            };
            return true;
        }
        
        private bool CompareLength()
        {
            var sizeResult = Master.ph.File_GetLength();
            if (sizeResult.Status == GeneralPacketHandler.FileDirHandleResult.Fail)
            {
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantGetFileSize, true));
                return false;
            }
            if (sizeResult.Length != _data.Length)
            {
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.NotEqualSizes, true));
                return false;
            }
            return true;
        }

        private unsafe bool CompareHash()
        {
            var deviceHash = Master.ph.File_GetCrC32();
            if (deviceHash.Status != GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantGetHashOfFile, true));
                return false;
            }
            UInt32 localHash = 0;
            fixed (byte* bytes = _data) localHash = CrCHandler.CRC32(bytes, (UInt32)_data.Length);
            if (BitConverter.ToUInt32(deviceHash.Result, 0) != localHash)
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.HashesNotEqual, false));
            return true;
        }

        private bool ForceStop = false;

        private long Total;

        private int Counter, CountOfData, LasProgress, OnseSecondProgress;

        private double Speed, lSpeed, LeftTime, LastLeftTime;

        private void TimerThreadMethod()
        {
            while (true)
            {
                OnseSecondProgress = Counter - LasProgress;
                LasProgress = Counter;
                CountOfData += OnseSecondProgress;
                if (lSpeed == 0) Speed = (double)OnseSecondProgress * PacketLength / 1024 * 2;
                else Speed = (lSpeed + (double)OnseSecondProgress * PacketLength / 1024 * 2) / 2;
                lSpeed = Speed;
                if (LastLeftTime == 0 || LastLeftTime == float.PositiveInfinity)
                {
                    if (OnseSecondProgress == 0) LeftTime = float.PositiveInfinity;
                    else LeftTime = (Total - CountOfData) / OnseSecondProgress / 2;
                }
                else
                {
                    if (OnseSecondProgress == 0) LeftTime = float.PositiveInfinity;
                    else LeftTime = (LastLeftTime + (Total - CountOfData) / OnseSecondProgress / 2) / 2;
                }
                LastLeftTime = LeftTime;
                Thread.Sleep(500);
            }
        }

        private Thread TimerThread, SenderThread;

        public bool SendFileSync(byte[] data, string NewName)
        {
            ForceStop = false;
            TimerThread = new Thread(TimerThreadMethod);
            TimerThread.Start();
            DateTime startTime = DateTime.Now;
            if (!HandleFiles(NewName)) return false;
            _data = data;
            var b = _data.Split(PacketLength);
            int totalCount = b.Count();
            int Current = 0;
            foreach (var c in b)
            {
                if(ForceStop)
                {
                    RaiseEndEvent(new FileTransferEndArgs((DateTime.Now - startTime).TotalSeconds, true));
                    return false;
                }
                Current++;
                if (!Master.ph.File_Append(c.ToArray()))
                {
                    RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantSendPacket, true));
                    return false;
                }
                RaiseProcessEvent(new FileTransferProcessArgs((long)(DateTime.Now - startTime).TotalSeconds, LeftTime, totalCount - Current, Current, Speed, PacketLength));
            }
            if (CheckLen)
            {
                if (!CompareLength())
                {
                    RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.LengthsNotEqual, false));
                    return false;
                }
            }
            if (CheckSum)
            {
                if (!CompareHash())
                {
                    RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.HashesNotEqual, false));
                    return false;
                }
            }
            if (!Master.ph.File_Close())
            {
                RaiseErrorEvent(new FileSenderErrorArgs(FileSenderError.CantCloseFile, true));
                return false;
            };
            RaiseEndEvent(new FileTransferEndArgs((DateTime.Now - startTime).TotalSeconds, false));
            _data = null;
            return true;
        }

        public bool SendFileSync(string pcName, string NewName)
        {
            return SendFileSync(File.ReadAllBytes(pcName), NewName);
        }

        public void SendFileAsync(string pcName, string NewName)
        {
            SenderThread = new Thread(p =>
            {
                SendFileSync(pcName, NewName);
            });
            SenderThread.Start();
        }

        public void SendFileAsync(byte[] data, string NewName)
        {
            SenderThread = new Thread(p =>
            {
                SendFileSync(data, NewName);
            });
            SenderThread.Start();
        }
    }
}
