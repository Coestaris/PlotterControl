/*=================================\
* CWA.DTP\FileTransferProcessArgs.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;

namespace CWA.DTP.FileTransfer
{
    public sealed class FileTransferProcessArgs : EventArgs
    {
        public long TimeSpend { get; private set; }
        public double TimeLeft { get; private set; }
        public long PacketsLeft { get; private set; }
        public long PacketTrasfered { get; private set; }
        public double Speed { get; private set; }
        public int PacketsLength { get; private set; }

        internal FileTransferProcessArgs(long timeSpend, double timeLeft, long packetLeft, long packetSended, double speed, int packetLength)
        {
            TimeSpend = timeSpend;
            TimeLeft = timeLeft;
            PacketsLeft = packetLeft;
            PacketTrasfered = packetSended;
            Speed = speed;
            PacketsLength = packetLength;
        }
    }
}
