/*=================================\
* CWA.DTP\FileRecieverErrorArgs.cs
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
    public class FileReceiverErrorArgs : EventArgs
    {
        public FileReceiverError Error { get; private set; }
        public bool IsCritical { get; private set; }

        internal FileReceiverErrorArgs(FileReceiverError error, bool isCritical)
        {
            Error = error;
            IsCritical = isCritical;
        }
    }
}
