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
* CWA.DTP \ SdCardDirectory.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:25
*
*=================================*/

using System.Linq;

namespace CWA.DTP
{
    public class SdCardDirectory
    {
        private GeneralPacketHandler ph;

        public string DirectoryPath { get; set; }

        internal SdCardDirectory(string path, GeneralPacketHandler ph)
        {
            DirectoryPath = path;
            this.ph = ph;
        }

        public bool IsExists
        {
            get
            {
                var res = ph.File_Exists(DirectoryPath);
                if (res == GeneralPacketHandler.FileExistsResult.Fail)
                    throw new FailOperationException(res);
                return res == GeneralPacketHandler.FileExistsResult.Exists;
            }
        }

        public SdCardDirectory Create(bool CreateNecessary)
        {
            if (DirectoryPath == "/") throw new FileHandlerException("Невозможно создать корень -_-");
            if (IsExists) throw new FileHandlerException("Папка уже существует");
            var res = ph.Dir_Create(DirectoryPath, CreateNecessary);
            if (res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException("Не удалось создать папку", res);
            return this;
        }


        public void Delete(bool DeleteSubItems)
        {
            if (DirectoryPath == "/") throw new FileHandlerException("Невозможно удалить корень -_-");
            if (!IsExists) throw new FileHandlerException("Папка не существует");
            var res = ph.Dir_Delete(DirectoryPath, DeleteSubItems);
            if (res != GeneralPacketHandler.FileDirHandleResult.OK)
                throw new FailOperationException(res);
        }

        public SdCardDirectoryFileInfo DirectoryInfo
        {
            get
            {
                if (DirectoryPath == "/")
                    return new SdCardDirectoryFileInfo()
                    {
                        IsDirectory = true,
                        IsSystem = true,
                        Name = "/"
                    };
                var res = ph.File_GetInfo(DirectoryPath);
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
                if (DirectoryPath != "/")
                    if (!IsExists) throw new FileHandlerException("Папка не существует");
                var res = ph.Dir_GetSubDirs(DirectoryPath);
                if (res.Status == GeneralPacketHandler.FileDirHandleResult.OK)
                    return res.ResultDirs.Select(p => new SdCardDirectory(p, ph)).ToArray();
                else throw new FailOperationException(res.Status);
            }
        }

        public SdCardFile[] SubFiles
        {
            get
            {
                if (DirectoryPath != "/")
                    if (!IsExists) throw new FileHandlerException("Папка не существует");
                var res = ph.Dir_GetFiles(DirectoryPath);
                if (res.Status == GeneralPacketHandler.FileDirHandleResult.OK)
                    return res.ResultFiles.Select(p => new SdCardFile(p, ph)).ToArray();
                else throw new FailOperationException(res.Status);
            }
        }
    }
}
