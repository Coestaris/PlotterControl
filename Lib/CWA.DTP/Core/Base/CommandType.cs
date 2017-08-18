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
* CWA.DTP \ CommandType.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
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
