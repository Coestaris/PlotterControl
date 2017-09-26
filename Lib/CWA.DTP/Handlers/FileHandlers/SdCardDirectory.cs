/*=================================\
* CWA.DTP\SdCardDirectory.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 24.08.2017 13:56:48
*=================================*/

using System;
using System.Linq;

namespace CWA.DTP
{
    public sealed class SdCardDirectory
    {
        private DTPMaster master;

        public string DirectoryPath { get; set; }

        internal SdCardDirectory(string path, DTPMaster ph)
        {
            DirectoryPath = path;
            master = ph;
        }

        public bool IsExists
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                var res = master.ph.File_Exists(DirectoryPath);
                if (res == GeneralPacketHandler.FileExistsResult.Fail)
                    throw new FailOperationException(res);
                return res == GeneralPacketHandler.FileExistsResult.Exists;
            }
        }

        public SdCardDirectory Create(bool CreateNecessary)
        {
            DTPMaster.CheckConnAndVal();
            if (DirectoryPath == "/") throw new FileHandlerException("Невозможно создать корень -_-");
            if (IsExists) throw new FileHandlerException("Папка уже существует");
            var res = master.ph.Dir_Create(DirectoryPath, CreateNecessary);
            if (res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException("Не удалось создать папку", res);
            return this;
        }


        public void Delete(bool DeleteSubItems)
        {
            DTPMaster.CheckConnAndVal();
            if (DirectoryPath == "/") throw new FileHandlerException("Невозможно удалить корень -_-");
            if (!IsExists) throw new FileHandlerException("Папка не существует");
            var res = master.ph.Dir_Delete(DirectoryPath, DeleteSubItems);
            if (res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException(res);
        }

        public SdCardDirectoryFileInfo DirectoryInfo
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                if (DirectoryPath == "/")
                    return new SdCardDirectoryFileInfo()
                    {
                        IsDirectory = true,
                        IsSystem = true,
                        Name = "/"
                    };
                var res = master.ph.File_GetInfo(DirectoryPath);
                return res.FI;
            }
        }
       
        /*
        public SdCardDirectory ParentDirectory
        {
            get
            {
                   
            }
        }*/

        public SdCardDirectory[] SubDirectroies
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                if (DirectoryPath != "/")
                    if (!IsExists) throw new FileHandlerException("Папка не существует");
                var res = master.ph.Dir_GetSubDirs(DirectoryPath);
                if (res.Status == GeneralPacketHandler.FileDirHandleResult.OK)
                    return res.ResultDirs.Select(p => new SdCardDirectory(p, master)).ToArray();
                else throw new FailOperationException(res.Status);
            }
        }

        public SdCardFile[] SubFiles
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                if (DirectoryPath != "/")
                    if (!IsExists) throw new FileHandlerException("Папка не существует");
                var res = master.ph.Dir_GetFiles(DirectoryPath);
                if (res.Status == GeneralPacketHandler.FileDirHandleResult.OK)
                    return res.ResultFiles.Select(p => new SdCardFile(p, master)).ToArray();
                else throw new FailOperationException(res.Status);
            }
        }

        internal static SdCardDirectory Root(GeneralPacketHandler ph)
        {
            //TODO: Что-то сделать с этим дерьмом
            //return new SdCardDirectory("/", );
            throw new NotImplementedException();
        }
    }
}
