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
* CWA.DTP \ SdCardFile.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
*=================================*/

using System;

namespace CWA.DTP
{
    public class SdCardFile
    {
        private static bool IsGlobalOpenedFiles = false;

        private GeneralPacketHandler ph;
        
        public string FilePath { get; set; }

        internal SdCardFile(string path, GeneralPacketHandler ph)
        {
            FilePath = path;
            this.ph = ph;
        }

        public bool IsOpen { get; private set; }

        public UInt32 CRC32
        {
            get
            {
                if (!IsExists)
                    throw new FileHandlerException("Файл не существует");
                if (!IsOpen)
                    throw new FileHandlerException("Файл закрыт");
                var a = ph.File_GetCrC32();
                if (a.Status != GeneralPacketHandler.WriteReadFileHandleResult.OK)
                    throw new FailOperationException("Не удалось получить хеш-код фалйа");
                return BitConverter.ToUInt32(a.Result, 0);
            }
        }

        public bool IsExists
        {
            get
            {
                var res = ph.File_Exists(FilePath);
                if (res == GeneralPacketHandler.FileExistsResult.Fail)
                    throw new FailOperationException(res);
                return res == GeneralPacketHandler.FileExistsResult.Exists;
            }
        }

        public SdCardFile Open(bool ClearContent)
        {
            if(!IsExists)
                throw new FileHandlerException("Файл не существует");
            if (IsOpen)
                throw new FileHandlerException("Файл уже был открыть");
            if (IsGlobalOpenedFiles)
                throw new FailOperationException("На этом домене уже есть открытый файл. Невозможно отрыть более однго файлов");
            var res = ph.File_Open(FilePath, ClearContent);
            if (res != GeneralPacketHandler.WriteReadFileHandleResult.OK)
                throw new FailOperationException("Не удалось открыть файл", res);
            IsOpen = true;
            IsGlobalOpenedFiles = true;
            return this;
        }

        public void Close()
        {
            if(!IsOpen)
                throw new FileHandlerException("Файл закрыт");
            var res = ph.File_Close();
            if (!res)
                throw new FailOperationException("Не удалось закрыть файл");
            IsOpen = false;
            IsGlobalOpenedFiles = false;
        }

        public uint Length
        {
            get
            {
                if (!IsOpen)
                    throw new FileHandlerException("Файл закрыт");
                var res = ph.File_GetLength();
                if(res.Status != GeneralPacketHandler.FileDirHandleResult.OK)
                    throw new FailOperationException("Не удалось получить длину (размер) файла", res);
                return res.Length;
            }
        }

        public SdCardFile Create()
        {
            var res = ph.File_Create(FilePath);
            if(res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException("Не удалось создать файл", res);
            return this;
        }

        public void ClearAllBytes()
        {
            if(IsOpen) if(!ph.File_Close()) throw new FailOperationException("Не удалось закрыть файл");
            var res = ph.File_Open(FilePath, true);
            if(res != GeneralPacketHandler.WriteReadFileHandleResult.OK)
                throw new FailOperationException("Не удалось открыть файл", res);
            if (!IsOpen) if (!ph.File_Close()) throw new FailOperationException("Не удалось закрыть файл");
        }

        public void Delete()
        {
            var res = ph.File_Delete(FilePath);
            if (res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException(res);
        }

        public SdCardDirectoryFileInfo FileInfo
        {
            get
            {
                var res = ph.File_GetInfo(FilePath);
                return res.FI;
            }
        }
        
        public SdCardDirectory ParentDirectory
        {
            get
            {
                var path = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                return new SdCardDirectory(path, ph);
                
            }
        }

        public SdCardBinnaryFile BinnaryFile
        {
            get
            {
                if (IsOpen)
                    return new SdCardBinnaryFile(this, ph);
                else throw new FileHandlerException("Файл закрыт");
            }
        }
        
    }
}
