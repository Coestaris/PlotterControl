/*=================================\
* CWA.DTP\FileSenderError.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

namespace CWA.DTP.FileTransfer
{
    public enum FileSenderError
    {
        CantSendPacket,
        CantCreateFile,
        CantDeleteFile,
        CantOpenFile,
        CantCloseFile,
        NotEqualSizes,
        CantGetHashOfFile,
        HashesNotEqual,
        CantGetFileSize,
        LengthsNotEqual,
    }
}
