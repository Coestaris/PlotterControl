/*=================================\
* CWA.DTP\SdCardFile.cs
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
