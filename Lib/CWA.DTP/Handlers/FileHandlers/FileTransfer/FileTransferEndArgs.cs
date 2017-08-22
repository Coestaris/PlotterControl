/*=================================\
* CWA.DTP\FileTransferEndArgs.cs
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
    public class FileTransferEndArgs : EventArgs
    {
        public bool IsForcedEnd { get; private set; }

        public double TimeSpend { get; private set; }

        internal FileTransferEndArgs(double timeSpend, bool isForcedEnd)
        {
            TimeSpend = timeSpend;
            IsForcedEnd = isForcedEnd;
        }
    }
}
