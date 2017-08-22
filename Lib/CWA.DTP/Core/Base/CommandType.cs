/*=================================\
* CWA.DTP\CommandType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;

namespace CWA.DTP
{
    internal enum CommandType : UInt32
    {
        RunFile = 0x101, 
        File_GetFileTree = 0x103, 
        File_GetFileData = 0x105,
        File_GetFileLength = 0x10e,
        File_WriteDataToFile = 0x106, 
        File_DeleteFile = 0x107, 
        File_CreateFile = 0x114, 
        File_RenameFile = 0x108,
        File_GetFileInfo = 0x109, 
        File_AppendDataToFile = 0x10a, 
        Folder_Create = 0x10b, 
        Folder_Delete = 0x10c, 
        Folder_Rename = 0x10d,
        Test = 0x110, 
        DataTest = 0x111, 
        GetSDInfo = 0x112, 
        Answer = 0x113, 
        GetDateTime = 0x115, 
        SetTime = 0x116, 
        FILE_GetHashSumOfFile = 0x117, 
        SET_DIGITAL_PIN = 0x118,
        SET_ANALOG_PIN = 0x119,
        SPEAKER_BEEP = 0x11a,
        GetInfo = 0x11b, 
        File_Open = 0x11c, 
        File_Close = 0x11d, 
        File_Exists = 0x11e, 
    };
}
