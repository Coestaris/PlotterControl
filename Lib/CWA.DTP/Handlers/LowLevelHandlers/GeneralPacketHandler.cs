/*=================================\
* CWA.DTP\GeneralPacketHandler.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 06.10.2017 20:43:16
*=================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWA.DTP
{
    internal class GeneralPacketHandler : AbstractPakcetHandler
    {
        public GeneralPacketHandler(Sender sender, PacketListener listener)
        {
            Listener = listener;
            Sender = sender;
        }

        #region Classes

        public abstract class PacketAnswerSpecialData
        {
            public PacketAnswer BaseAnswer { get; private set; }

            public UInt16 Command { get; private set; }

            protected ArgumentException WrongTypeException = new ArgumentException("Wrong Type or Nullale answer");

            public bool IsEmpty { get; private set; } = true;

            protected bool Init(UInt16 defType, PacketAnswer answer)
            {
                Command = defType;
                BaseAnswer = answer;
                IsEmpty = !answer.IsEmpty && answer.Command == defType && answer.Status != AnswerStatus.Error;
                return IsEmpty;
            }
        }
      

        public class PacketAnswerTotalInfo : PacketAnswerSpecialData
        {
            public DeviceInfo DI { get; }

            internal PacketAnswerTotalInfo(PacketAnswer answer)
            {
                if (!Init((UInt16)CommandType.GetInfo, answer)) throw WrongTypeException;
                DI = new DeviceInfo()
                {
                    Board = (Board)(answer.Data[0]),
                    BoardArchitecture = (BoardArchitecture)(answer.Data[1]),
                    StackFreeMemory = BitConverter.ToUInt32(answer.Data, 2),
                    CPU_F = BitConverter.ToInt64(answer.Data, 6),
                    GCC_verison = BitConverter.ToUInt32(answer.Data, 14),
                    ARD_version = BitConverter.ToUInt32(answer.Data, 18),
                    DTP_version = BitConverter.ToUInt32(answer.Data, 22),
                    IsConnectSDModule = answer.Data[26] == 1,
                    IsConnectTimeModule = answer.Data[27] == 1,
                    FlashMemorySize = BitConverter.ToUInt32(answer.Data, 28),
                    SRAMMemorySize = BitConverter.ToUInt32(answer.Data, 32)
                };
            }

            public override string ToString()
            {
                return DI.ToString();
            }
        }

        public bool Security_ResetKey()
        {
            var a = GetResult((UInt16)CommandType.Security_ResetKey);
            return !a.IsEmpty && a.Code == 1;
        }

        public class PacketAnswerCardInfo : PacketAnswerSpecialData
        {
            public CardInfo CI { get; }

            internal PacketAnswerCardInfo(PacketAnswer answer)
            {
                if (!Init((UInt16)CommandType.GetSDInfo, answer)) throw WrongTypeException;
                CI = new CardInfo()
                {
                    ManufacturerID = answer.Data[0],
                    OEMID = new string(new char[] {
                        (char)answer.Data[1],
                        (char)answer.Data[2]
                    }),
                    ProductVersion = new byte[5] {
                        answer.Data[3],
                        answer.Data[4],
                        answer.Data[5],
                        answer.Data[6],
                        answer.Data[7],
                    },
                    MajorVersion = answer.Data[8],
                    MinorVersion = answer.Data[9],
                    SerialNumber = BitConverter.ToUInt32(answer.Data, 10),
                    ManufacturingDateMonth = answer.Data[14],
                    ManufacturingDateYear = (short)(BitConverter.ToInt16(answer.Data, 15) + 2000),
                    CardSize = BitConverter.ToUInt32(answer.Data, 17),
                    FlashEraseSize = answer.Data[21],
                    EraseSingleBlock = answer.Data[22] == 1,
                    FatType = (SdCardFatType)answer.Data[23],
                    BlocksPerCluster = answer.Data[24],
                    ClusterCount = BitConverter.ToUInt32(answer.Data, 25),
                    FreeClusters = BitConverter.ToUInt32(answer.Data, 29),
                    FreeSpace = BitConverter.ToUInt32(answer.Data, 33),
                    FatStartBlock = BitConverter.ToUInt32(answer.Data, 37),
                    FatCount = answer.Data[41],
                    BlocksPerFat = BitConverter.ToUInt32(answer.Data, 42),
                    RootDirStart = BitConverter.ToUInt32(answer.Data, 46),
                    DataStartBlock = BitConverter.ToUInt32(answer.Data, 50),
                    Type = (CardType)answer.Data[54],
                };
            }

            public override string ToString()
            {
                return CI.ToString();
            }
        }

        public class PacketAnswerFileInfo : PacketAnswerSpecialData
        {
            public SdCardDirectoryFileInfo FI { get; }

            internal PacketAnswerFileInfo(PacketAnswer answer, string name)
            {
                if (!Init((UInt16)CommandType.File_GetFileInfo, answer)) throw WrongTypeException;
                FI = new SdCardDirectoryFileInfo()
                {
                    FileDirectorySize = BitConverter.ToInt32(answer.Data, 0),
                    CreationTime = new DateTime(
                        HelpMethods.GetNumber(answer.Data[9], answer.Data[10]),
                        answer.Data[8],
                        answer.Data[7],
                        answer.Data[4],
                        answer.Data[5],
                        answer.Data[6]
                    ),
                    IsHidden = answer.Data[11] == 1,
                    IsLFN = answer.Data[12] == 1,
                    IsReadOnly = answer.Data[13] == 1,
                    IsSystem = answer.Data[14] == 1,
                    IsDirectory = answer.Data[15] == 1,
                    Name = name
                };
            }

            public override string ToString()
            {
                return FI.ToString();
            }
        }

        public enum FileExistsResult
        {
            Fail,
            Exists,
            NotExists
        }

        public enum FileDirHandleResult
        {
            OK,
            Fail,
            FileOrDirAlreadyExist,
            FileOrDirNotExists
        }

        public enum WriteReadFileHandleResult
        {
            OK,
            Fail,
            FileNotExists,
            CantOpenFile,
            FileNotOpened,
            CantReadData
        }

        public class DataRequestResult
        {
            public WriteReadFileHandleResult Status { get; internal set; } = WriteReadFileHandleResult.Fail;
            public byte[] Result { get; internal set; } = new byte[0];
            public UInt32 ErrorByteIndex { get; internal set; }

            internal DataRequestResult() { }
        }

        public class FileLengthRequestResult
        {
            public FileDirHandleResult Status { get; internal set; } = FileDirHandleResult.Fail;
            public UInt32 Length { get; internal set; } = 0;

            internal FileLengthRequestResult() { }
        }

        public class DateTimeRequestResult
        {
            public bool Success { get; internal set; } = false;
            public DateTime Time { get; internal set; }

            internal DateTimeRequestResult() { }
        }

        public class GetFilesOrDirsRequestResult
        {
            public FileDirHandleResult Status { get; internal set; } = FileDirHandleResult.Fail;
            public List<string> ResultFiles { get; internal set; } = new List<string>();
            public List<string> ResultDirs { get; internal set; } = new List<string>();

            internal GetFilesOrDirsRequestResult() { }
        }

        #endregion

        public Sender Device_Test()
        {
            var result = GetResult((UInt16)CommandType.Test);
            return result.IsEmpty ? null : result.Sender;
        }

        public bool Device_DataTest(byte[] data)
        {
            var result = GetResult((UInt16)CommandType.DataTest, data);
            return (!result.IsEmpty && result.Status == AnswerStatus.OK && result.Data.ToList().SequenceEqual(data));
        }

        public long Device_SyncTime()
        {
            var res = Device_GetTime();
            if(!res.Success) return -1;
            DateTime deviceTime = res.Time;
            double diff = Math.Abs((DateTime.Now - deviceTime).TotalSeconds);
            if (diff > 20)
            {
                if (!Device_SetTime(DateTime.Now))
                    return -1;
                return (long)diff;
            }
            else return 0;
        }

        public FileDirHandleResult File_Create(string FileName)
        {
            var result = GetResult((UInt16)CommandType.File_CreateFile, Encoding.Default.GetBytes(FileName));
            if (result.IsEmpty) return FileDirHandleResult.Fail;
            switch (result.Code)
            {
                case (0):
                    return FileDirHandleResult.OK;
                case (1):
                    return FileDirHandleResult.Fail;
                case (2):
                    return FileDirHandleResult.FileOrDirAlreadyExist;
                default:
                    return FileDirHandleResult.Fail;
            }
        }

        public FileExistsResult File_Exists(string FileName)
        {
            var result = GetResult((UInt16)CommandType.File_Exists, Encoding.Default.GetBytes(FileName));
            if (result.IsEmpty) return FileExistsResult.Fail;
            if (result.Code == 1) return FileExistsResult.NotExists;
            else return FileExistsResult.Exists;
        }

        public FileDirHandleResult File_Delete(string FileName)
        {
            var result = GetResult((UInt16)CommandType.File_DeleteFile, Encoding.Default.GetBytes(FileName));
            if (result.IsEmpty) return FileDirHandleResult.Fail;
            switch (result.Code)
            {
                case (0):
                    return FileDirHandleResult.OK;
                case (1):
                    return FileDirHandleResult.Fail;
                case (2):
                    return FileDirHandleResult.FileOrDirNotExists;
                default:
                    return FileDirHandleResult.Fail;
            }
        }

        public FileDirHandleResult Dir_Create(string DirectoryName, bool CreateNecessary)
        {
            var data = new List<byte>();
            data.AddRange(Encoding.Default.GetBytes(DirectoryName));
            data.Add(CreateNecessary ? (byte)1 : (byte)0);
            var result = GetResult((UInt16)CommandType.Folder_Create, data.ToArray());
            if (result.IsEmpty) return FileDirHandleResult.Fail;
            switch (result.Code)
            {
                case (0):
                    return FileDirHandleResult.OK;
                case (1):
                    return FileDirHandleResult.Fail;
                case (2):
                    return FileDirHandleResult.FileOrDirAlreadyExist;
                case (3):
                    return FileDirHandleResult.FileOrDirAlreadyExist;
                default:
                    return FileDirHandleResult.Fail;
            }
        }

        public bool Device_SpeakerBeep(string Patten)
        {
            return !GetResult((UInt16)CommandType.SPEAKER_BEEP, Encoding.Default.GetBytes(Patten)).IsEmpty;
        }

        public FileDirHandleResult Dir_Delete(string DirectoryName, bool DeleteSubItems)
        {
            var data = new List<byte>();
            data.AddRange(Encoding.Default.GetBytes(DirectoryName));
            data.Add(DeleteSubItems ? (byte)1 : (byte)0);
            var result = GetResult((UInt16)CommandType.Folder_Delete, data.ToArray());
            if (result.IsEmpty) return FileDirHandleResult.Fail;
            switch (result.Code)
            {
                case (0):
                    return FileDirHandleResult.OK;
                case (1):
                    return FileDirHandleResult.Fail;
                case (2):
                    return FileDirHandleResult.FileOrDirNotExists;
                case (3):
                    return FileDirHandleResult.FileOrDirNotExists;
                default:
                    return FileDirHandleResult.Fail;
            }
        }

        public WriteReadFileHandleResult File_Open(string FileName, bool ClearFile)
        {
            var e = Encoding.Default.GetBytes(FileName).ToList();
            e.Add(ClearFile ? (byte)1 : (byte)0);
            var result = GetResult((UInt16)CommandType.File_Open, e.ToArray());
            if (result.IsEmpty) return WriteReadFileHandleResult.Fail;
            switch(result.Code)
            {
                case (0):
                    return WriteReadFileHandleResult.OK;
                case (1):
                    return WriteReadFileHandleResult.FileNotExists;
                case (2):
                    return WriteReadFileHandleResult.CantOpenFile;
                default:
                    return WriteReadFileHandleResult.Fail;
            }
        }

        public DataRequestResult File_GetCrC32()
        {
            var result_ = new DataRequestResult();
            var result = GetResult((UInt16)CommandType.FILE_GetHashSumOfFile);
            if (result.IsEmpty)
            {
                result_.Status = WriteReadFileHandleResult.Fail;
            }
            if (result.Data[0] != 0)
            {
                switch (result.Data[0])
                {
                    case (1):
                        result_.Status = WriteReadFileHandleResult.CantReadData;
                        result_.ErrorByteIndex = BitConverter.ToUInt32(result.Data, 1);
                        return result_;
                    default:
                        result_.Status =  WriteReadFileHandleResult.Fail;
                        return result_;
                }
            }
            result_.Result = new byte[result.Data.Length-1];
            Buffer.BlockCopy(result.Data, 1, result_.Result, 0, result.Data.Length - 1);
            result_.Status = WriteReadFileHandleResult.OK;
            return result_;
        }

        public PacketAnswerCardInfo Device_GetCardInfo()
        {
            return new PacketAnswerCardInfo(GetResult((UInt16)CommandType.GetSDInfo));
        }

        public PacketAnswerFileInfo File_GetInfo(string Name)
        {
            return new PacketAnswerFileInfo(GetResult((UInt16)CommandType.File_GetFileInfo, Encoding.Default.GetBytes(Name)), Name);
        }

        public PacketAnswerTotalInfo Device_GetGlobalInfo()
        {
            return new PacketAnswerTotalInfo(GetResult((UInt16)CommandType.GetInfo));
        }

        public DataRequestResult File_Read(UInt32 offset, UInt32 length)
        {
            var result_ = new DataRequestResult();
            byte[] data_ = new byte[8];
            Buffer.BlockCopy(BitConverter.GetBytes(offset), 0, data_, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(length), 0, data_, 4, 4);
            var result = GetResult((UInt16)CommandType.File_GetFileData, data_);
            if (result.IsEmpty)
            {
                result_.Status = WriteReadFileHandleResult.Fail;
                return result_;
            }
            if (result.Data.Length == 1 && result.Status == AnswerStatus.Error)
                switch (result.Data[0])
                {
                    case (1):
                        result_.Status = WriteReadFileHandleResult.FileNotOpened;
                        return result_;
                    case (2):
                        result_.Status = WriteReadFileHandleResult.CantReadData;
                        return result_;
                    default:
                        result_.Status = WriteReadFileHandleResult.Fail;
                        return result_;
                }
            result_.Result = result.Data;
            result_.Status = WriteReadFileHandleResult.OK;
            return result_;
        }

        public GetFilesOrDirsRequestResult Dir_GetFiles(string DirectoryName)
        {
            var files = new List<string>();
            var result = GetResult((UInt16)CommandType.File_GetFileTree, Encoding.Default.GetBytes(DirectoryName));
            if (result.IsEmpty || result.Status == AnswerStatus.Error) return new GetFilesOrDirsRequestResult();
            string s = Encoding.Default.GetString(result.Data);
            files = s.Split((char)1).ToList().FindAll(p => !p.StartsWith("/") && p.Trim() != "").OrderBy(p => p).ToList();
            return new GetFilesOrDirsRequestResult()
            {
                Status = FileDirHandleResult.OK,
                ResultFiles = files
            };
        }
        
        public GetFilesOrDirsRequestResult Dir_GetSubDirs(string DirectoryName)
        {
           var dirs = new List<string>();
            var result = GetResult((UInt16)CommandType.File_GetFileTree, Encoding.Default.GetBytes(DirectoryName));
            if (result.IsEmpty || result.Status == AnswerStatus.Error) return new GetFilesOrDirsRequestResult();
            string s = Encoding.Default.GetString(result.Data);
            var a = s.Split((char)1);
            dirs = a.ToList().FindAll(p => p.StartsWith("/") && p.Trim() != "").Select(p => p.Replace("/", "")).ToList().OrderBy(p => p).ToList();
            return new GetFilesOrDirsRequestResult()
            {
                Status = FileDirHandleResult.OK,
                ResultDirs = dirs
            };
        }

        public GetFilesOrDirsRequestResult Dir_GetFilesAndSubDirs(string DirectoryName)
        {
            var dirs = new List<string>();
            var files = new List<string>();
            var result = GetResult((UInt16)CommandType.File_GetFileTree, Encoding.Default.GetBytes(DirectoryName));
            if (result.IsEmpty || result.Status == AnswerStatus.Error) return new GetFilesOrDirsRequestResult();
            string s = Encoding.Default.GetString(result.Data);
            var a = s.Split((char)1);
            dirs = a.ToList().FindAll(p => p.StartsWith("/") && p.Trim() != "").Select(p => p.Replace("/", "")).ToList().OrderBy(p => p).ToList();
            files = a.ToList().FindAll(p => !p.StartsWith("/") && p.Trim() != "").OrderBy(p => p).ToList();
            return new GetFilesOrDirsRequestResult()
            {
                Status = FileDirHandleResult.OK,
                ResultFiles = files,
                ResultDirs = dirs
            };
        }

        public FileLengthRequestResult File_GetLength()
        {
            UInt32 Length = 0;
            var result = GetResult((UInt16)CommandType.File_GetFileLength);
            if (result.IsEmpty) return new FileLengthRequestResult();
            if (result.Status == AnswerStatus.Error) return new FileLengthRequestResult();
            Length = BitConverter.ToUInt32(result.Data, 0);
            return new FileLengthRequestResult()
            {
                Length = Length,
                Status = FileDirHandleResult.OK
            };
        }

        public bool File_Close()
        {
            var result = GetResult((UInt16)CommandType.File_Close);
            return !result.IsEmpty;
        }
        
        public bool File_Rewrite(byte[] bytes)
        {
            var result = GetResult((UInt16)CommandType.File_WriteDataToFile, bytes);
            if (result.IsEmpty) return false;
            return result.Code == 0;
        }

        public bool File_Append(byte[] bytes)
        {
            var result = GetResult((UInt16)CommandType.File_AppendDataToFile, bytes);
            if (result.IsEmpty) return false;
            return result.Code == 0;
        }

        public bool Device_SetTime(DateTime dt)
        {
            DateTime now = dt;
            byte[] data = new byte[7] {
                (byte)now.Hour,
                (byte)now.Minute,
                (byte)now.Second,
                (byte)now.Day,
                (byte)now.Month,
                HelpMethods.SplitNumber(now.Year).Item1, HelpMethods.SplitNumber(now.Year).Item2
            };
            var result = GetResult((UInt16)CommandType.SetTime, data);
            return !result.IsEmpty;
        }

        public bool Security_IsValidationRequired()
        {
            return GetResult((UInt16)CommandType.Security_IsValReq).Code == 1;
        }

        public bool Security_Validate(byte[] key)
        {
            var res = GetResult((UInt16)CommandType.Security_Validate, key);
            return res.Code == (byte)ValidationStatus.Ok;
        }

        public bool Security_ChangeKey(byte[] oldKey, byte[] newKey)
        {
            var res = GetResult((UInt16)CommandType.Security_ChangeKey, oldKey.Concat(newKey).ToArray());
            return (res.Code == (byte)ValidationStatus.Ok);
        }

        public bool Security_SetValidation(bool Use)
        {
            return !GetResult((UInt16)CommandType.Security_SetValidation, new byte[] { (byte)(Use ? 1 : 0) }).IsEmpty;
        }

        public DateTimeRequestResult Device_GetTime()
        {
            var res = new DateTime();
            var result = GetResult((UInt16)CommandType.GetDateTime);
            if (result.IsEmpty) return new DateTimeRequestResult();
            res = new DateTime(
                    HelpMethods.GetNumber(result.Data[5], result.Data[6]),
                    result.Data[4],
                    result.Data[3],
                    result.Data[0],
                    result.Data[1],
                    result.Data[2]
                 );
            return new DateTimeRequestResult()
            {
                Success = true,
                Time = res
            };
        }
    }
}
