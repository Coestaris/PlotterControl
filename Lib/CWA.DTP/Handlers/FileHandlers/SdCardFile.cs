/*=================================\
* CWA.DTP\SdCardFile.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 24.08.2017 21:40:47
*=================================*/

using System;
using System.Linq;

namespace CWA.DTP
{
    public sealed class SdCardFile
    {
        private static bool IsGlobalOpenedFiles = false;

        internal DTPMaster Master;
        
        public string FilePath { get; set; }

        public bool IsOpen { get; private set; }

        public UInt32 CRC32
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                if (!IsExists)
                    throw new FileHandlerException("Файл не существует");
                if (!IsOpen)
                    throw new FileHandlerException("Файл закрыт");
                var a = Master.ph.File_GetCrC32();
                if (a.Status != GeneralPacketHandler.WriteReadFileHandleResult.OK)
                    throw new FailOperationException("Не удалось получить хеш-код фалйа");
                return BitConverter.ToUInt32(a.Result, 0);
            }
        }

        public bool IsExists
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                var res = Master.ph.File_Exists(FilePath);
                if (res == GeneralPacketHandler.FileExistsResult.Fail)
                    throw new FailOperationException(res);
                return res == GeneralPacketHandler.FileExistsResult.Exists;
            }
        }

        public string Extension
        {
            get
            {
                return FilePath.Split('.').Last();
            }
        }

        public string FileName
        {
            get
            {
                var countOfSeparators = FilePath.ToList().FindAll(p => p == '/').Count;
                if (countOfSeparators != 0) return FilePath.Split('/').Last();
                else return FilePath;
            }
        }
        
        public uint Length
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                if (!IsOpen)
                    throw new FileHandlerException("Файл закрыт");
                var res = Master.ph.File_GetLength();
                if(res.Status != GeneralPacketHandler.FileDirHandleResult.OK)
                    throw new FailOperationException("Не удалось получить длину (размер) файла", res);
                return res.Length;
            }
        }

        public SdCardDirectoryFileInfo FileInfo
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                var res = Master.ph.File_GetInfo(FilePath);
                return res.FI;
            }
        }
        
        public SdCardDirectory ParentDirectory
        {
            get
            {
                var countOfSeparators = FilePath.ToList().FindAll(p => p == '/').Count;
                if ((FilePath.StartsWith("/") && countOfSeparators == 1) || (!FilePath.StartsWith("/") && countOfSeparators == 0))
                    return SdCardDirectory.Root(Master.ph);
                var path = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                return new SdCardDirectory(path, Master);
                
            }
        }

        public SdCardBinnaryFile BinnaryFile
        {
            get
            {
                if (IsOpen)
                    return new SdCardBinnaryFile(this, Master.ph);
                else throw new FileHandlerException("Файл закрыт");
            }
        }
        
        internal SdCardFile(string path, DTPMaster master)
        {
            FilePath = path;
            Master = master;
        }

        public SdCardFile Open(bool ClearContent)
        {
            DTPMaster.CheckConnAndVal();
            if (!IsExists)
                throw new FileHandlerException("Файл не существует");
            if (IsOpen)
                throw new FileHandlerException("Файл уже был открыть");
            if (IsGlobalOpenedFiles)
                throw new FailOperationException("На этом домене уже есть открытый файл. Невозможно отрыть более однго файлов");
            var res = Master.ph.File_Open(FilePath, ClearContent);
            if (res != GeneralPacketHandler.WriteReadFileHandleResult.OK)
                throw new FailOperationException("Не удалось открыть файл", res);
            IsOpen = true;
            IsGlobalOpenedFiles = true;
            return this;
        }

        public void Close()
        {
            DTPMaster.CheckConnAndVal();
            if (!IsOpen)
                throw new FileHandlerException("Файл закрыт");
            var res = Master.ph.File_Close();
            if (!res)
                throw new FailOperationException("Не удалось закрыть файл");
            IsOpen = false;
            IsGlobalOpenedFiles = false;
        }

        public SdCardFile Create()
        {
            DTPMaster.CheckConnAndVal();
            var res = Master.ph.File_Create(FilePath);
            if(res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException("Не удалось создать файл", res);
            return this;
        }

        public void ClearAllBytes()
        {
            DTPMaster.CheckConnAndVal();
            if (IsOpen) if(!Master.ph.File_Close()) throw new FailOperationException("Не удалось закрыть файл");
            var res = Master.ph.File_Open(FilePath, true);
            if(res != GeneralPacketHandler.WriteReadFileHandleResult.OK)
                throw new FailOperationException("Не удалось открыть файл", res);
            if (!IsOpen) if (!Master.ph.File_Close()) throw new FailOperationException("Не удалось закрыть файл");
        }

        public void Delete()
        {
            DTPMaster.CheckConnAndVal();
            var res = Master.ph.File_Delete(FilePath);
            if (res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException(res);
        }
    }
}
