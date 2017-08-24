/*=================================\
* CWA.DTP\FileReceiver.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 24.08.2017 14:07:41
*=================================*/

using System;
using System.IO;
using System.Threading;

namespace CWA.DTP.FileTransfer
{
    public class FileReceiver
    {
        private bool CheckSum { get; set; } = true;

        private bool CheckLen { get; set; } = true;

        public int PacketLength { get; set; } = 3200;

        internal GeneralPacketHandler BaseHandler;

        internal FileReceiver(int _packetLength, FileTransferSecurityFlags flags)
        {
            CheckSum = flags.HasFlag(FileTransferSecurityFlags.VerifyCheckSum);
            CheckLen = flags.HasFlag(FileTransferSecurityFlags.VerifyLengh);
            PacketLength = _packetLength;
        }

        internal FileReceiver(FileTransferSecurityFlags flags)
        {
            CheckSum = (flags & FileTransferSecurityFlags.VerifyCheckSum) != 0;
            CheckLen = (flags & FileTransferSecurityFlags.VerifyLengh) != 0;
        }

        public event FileTrasferProcessHandler ReceiveProcessChanged;

        public event FileTrasferEndHandler ReceivingEnd;

        public event FileRecieverErrorHandler ReceiveError;

        private void RaiseProcessEvent(FileTransferProcessArgs arg)
        {
            Counter = (int)arg.PacketTrasfered;
            Total = arg.PacketTrasfered + arg.PacketsLeft;
            ReceiveProcessChanged?.Invoke(arg);
        }

        private void RaiseEndEvent(FileTransferEndArgs arg)
        {
            TimerThread.Abort();
            ReceivingEnd?.Invoke(arg);
        }

        private void RaiseErrorEvent(FileReceiverErrorArgs arg)
        {
            ReceiveError?.Invoke(arg);
            if (arg.IsCritical)
            {
                RecieverThread?.Abort();
                TimerThread.Abort();
            }
        }

        public void StopAsync()
        {
            ForceStop = true;

            while (RecieverThread.ThreadState == ThreadState.Running) Thread.Sleep(100);

            TimerThread.Abort();
        }

        private int Counter, CountOfData, LasProgress, OnseSecondProgress;

        private long Total;

        private double Speed, lSpeed, LeftTime, LastLeftTime;

        private bool ForceStop = false;

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

        private Thread TimerThread, RecieverThread;

        private SdCardFile MainFile;

        public bool ReceiveFileSync(string pcName, string DeviceName)
        {
            TimerThread = new Thread(TimerThreadMethod);
            TimerThread.Start();
            DateTime startTime = DateTime.Now;
            MainFile = new SdCardFile(DeviceName, BaseHandler);
            try
            {
                if (!MainFile.IsExists)
                {
                    RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.FileNotExists, true));
                    return false;
                }
            }
            catch
            {
                RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantOpenFile, true));
                return false;
            }
            try { MainFile.Open(false); }
            catch
            {
                RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantOpenFile, true));
                return false;
            }
            var bf = MainFile.BinnaryFile;
            bf.CursorPos = 0;
            UInt32 len = 0;
            try { len = MainFile.Length; }
            catch
            {
                RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantGetFileSize, true));
                return false;
            }
            byte[] buffer = new byte[len];
            UInt32 currentPacket = 0;
            UInt32 totalPackets = (UInt32)(len / PacketLength);
            UInt32 currIndex = 0, delta = 0, index = 0;
            while (currIndex < len)
            {
                if (currIndex + PacketLength > len)
                {
                    delta = len - currIndex;
                    currIndex = len;
                } 
                else
                {
                    currIndex += (UInt32)PacketLength;
                    delta = (UInt32)PacketLength;
                }
                SdCardBinnaryFileReadResult<byte[]> res;
                try { res = bf.ReadByteArray(delta); }
                catch
                {
                    RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantGetPacket, true));
                    return false;
                }
                if (!res.Succeed)
                {
                    RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantGetPacket, true));
                    return false;
                }
                else
                {
                    if (ForceStop)
                    {
                        try { MainFile.Close(); }
                        catch { RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantCloseFile, true)); }
                        RaiseEndEvent(new FileTransferEndArgs((DateTime.Now - startTime).TotalSeconds, true));
                        return false;
                    }

                    currentPacket++;
                    RaiseProcessEvent(new FileTransferProcessArgs((long)(DateTime.Now - startTime).TotalSeconds, LeftTime, totalPackets - currentPacket, currentPacket, Speed, PacketLength));
                    Buffer.BlockCopy(res.Result, 0, buffer, (int)index, (int)delta);
                    index += delta;
                }
            }
            File.Create(pcName).Close();
            File.WriteAllBytes(pcName, buffer);
            if(CheckLen)
                if (len != new FileInfo(pcName).Length)
                    RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.NotEqualSizes, false));
            if(CheckSum)
            {
                UInt32 localHash = CrCHandler.CRC32(pcName);
                UInt32 deviceHash = 0;
                try
                {
                    deviceHash = MainFile.CRC32;
                }
                catch
                {
                    RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantGetHashOfFile, true));
                    return false;
                }
                if(localHash != deviceHash)
                    RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.HashesNotEqual, false));
            }
            try { MainFile.Close(); } catch
            {
                RaiseErrorEvent(new FileReceiverErrorArgs(FileReceiverError.CantCloseFile, true));
                return false;
            }
            RaiseEndEvent(new FileTransferEndArgs((DateTime.Now - startTime).TotalSeconds, false));
            return true;
        }
        
        public void ReceiveFileAsync(string pcName, string DeviceName)
        {
            RecieverThread = new Thread(p =>
            {
                ReceiveFileSync(pcName, DeviceName);
            });
            RecieverThread.Start();
        }
    }
}
