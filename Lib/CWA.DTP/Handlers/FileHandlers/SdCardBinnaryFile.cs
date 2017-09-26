/*=================================\
* CWA.DTP\SdCardBinnaryFile.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 21.09.2017 11:13:33
*=================================*/

using System;

namespace CWA.DTP
{
    public sealed class SdCardBinnaryFile
    {
        internal GeneralPacketHandler ph;
        internal SdCardFile ParentFile;
        private UInt32 cacheLength;

        internal SdCardBinnaryFile(SdCardFile ParentFile, GeneralPacketHandler ph)
        {
            this.ph = ph;
            this.ParentFile = ParentFile;
            cacheLength = ParentFile.Length;
        }

        public UInt32 CursorPos { get; set; }

        private readonly UInt32 _Ui8 = sizeof(byte);
        private readonly UInt32 _i16 = sizeof(Int16);
        private readonly UInt32 _Ui16 = sizeof(UInt16);
        private readonly UInt32 _i32 = sizeof(Int32);
        private readonly UInt32 _Ui32 = sizeof(UInt32);
        private readonly UInt32 _i64 = sizeof(Int64);
        private readonly UInt32 _Ui64 = sizeof(UInt64);
        private readonly UInt32 _D = sizeof(Double);
        private readonly UInt32 _S = sizeof(Single);

        #region Write Methods
        public bool Write(string val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(System.Text.Encoding.Default.GetBytes(val)))
            {
                cacheLength += (UInt32)val.Length;
                CursorPos += (UInt32)val.Length;
                return true;
            }
            return false;
        }

        public bool Write(byte val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(new byte[1] { val }))
            {
                cacheLength += _Ui8;
                CursorPos += _Ui8;
                return true;
            }
            return false;
        }

        public bool Write(Int16 val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += _i16;
                CursorPos += _i16;
                return true;
            }
            return false;
        }

        public bool Write(UInt16 val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += _Ui16;
                CursorPos += _Ui16;
                return true;
            }
            return false;
        }

        public bool Write(Int32 val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += _i32;
                CursorPos += _i32;
                return true;
            }
            return false;
        }

        public bool Write(UInt32 val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += 4;
                CursorPos += 4;
                return true;
            }
            return false;
        }

        public bool Write(Int64 val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += _i64;
                CursorPos += _i64;
                return true;
            }
            return false;
        }

        public bool Write(UInt64 val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += _Ui64;
                CursorPos += _Ui64;
                return true;
            }
            return false;
        }

        public bool Write(Single val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                CursorPos += _S;
                cacheLength += _S;
                return true;
            }
            return false;
        }

        public bool Write(Double val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                CursorPos += _D;
                cacheLength += _D;
                return true;
            }
            return false;
        }

        public bool Write(bool val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(new byte[1] { val ? (byte)1 : (byte)0 }))
            {
                CursorPos += _Ui8;
                cacheLength += _Ui8;
                return true;
            }
            return false;
        }

        public bool Write(char val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append( new byte[1] { (byte)val }))
            {
                cacheLength += _Ui8;
                CursorPos += _Ui8;
                return true;
            }
            return false;
        }
        
        public bool Write(byte[] val)
        {
            DTPMaster.CheckConnAndVal();
            if (ph.File_Append(val))
            {
                cacheLength += (UInt32)val.Length;
                CursorPos += (UInt32)val.Length;
                return true;
            }
            return false;
        }
        #endregion

        #region Read Methods
        private SdCardBinnaryFileReadResult<object> ReadByte()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _Ui8 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _Ui8);
            if(res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _Ui8;
                return new SdCardBinnaryFileReadResult<object>(res.Result[0], true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadBool()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _Ui8 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _Ui8);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _Ui8;
                return new SdCardBinnaryFileReadResult<object>(res.Result[0] == 1, true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadShort()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _i16 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _i16);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _i16;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToInt16(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadUInt16()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _Ui16 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _Ui16);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _Ui16;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToUInt16(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadInt()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _i32 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _i32);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _i32;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToInt32(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadUInt32()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _Ui32 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _Ui32);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _Ui32;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToUInt32(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadLong()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _i64 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _i64);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _i64;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToInt64(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadUInt64()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _Ui64 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _Ui64);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _Ui64;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToUInt64(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadFloat()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _S > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _S);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _S;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToSingle(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadDouble()
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + _D > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, _D);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += _D;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToDouble(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }
        #endregion

        public SdCardBinnaryFileReadResult<byte[]> ReadByteArray(UInt32 length)
        {
            DTPMaster.CheckConnAndVal();
            if (CursorPos + length > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, length);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += length;
                return new SdCardBinnaryFileReadResult<byte[]>(res.Result, true);
            }
            return new SdCardBinnaryFileReadResult<byte[]>(new byte[0], false);
        }

        /// <summary>
        /// Читает с SD карты значение указанного типа. В данный момент реализованы следующие типы: <see cref="Byte"/>, <see cref="Char"/>, <see cref="Int16"/>, <see cref="Int32"/>,
        /// <see cref="Int64"/>, <see cref="Single"/>, <see cref="Double"/>, <see cref="Boolean"/>, <see cref="UInt16"/>, <see cref="UInt32"/> и <see cref="UInt64"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public SdCardBinnaryFileReadResult<T> Read<T>()
        {
            Type type = typeof(T);
            if(type == typeof(byte))
            {
                var res = ReadByte();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            } else if(type == typeof(int))
            {
                var res = ReadInt();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            }
            else if (type == typeof(short))
            {
                var res = ReadShort();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            }
            else if (type == typeof(long))
            {
                var res = ReadLong();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            }
            else if (type == typeof(float))
            {
                var res = ReadFloat();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            }
            else if (type == typeof(double))
            {
                var res = ReadDouble();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            } else if (type == typeof(bool))
            {
                var res = ReadBool();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            } else if (type == typeof(char))
            {
                var res = ReadByte();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            } else if (type == typeof(UInt16))
            {
                var res = ReadUInt16();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            }
            else if (type == typeof(UInt32))
            {
                var res = ReadUInt32();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            }
            else if (type == typeof(UInt64))
            {
                var res = ReadUInt64();
                return new SdCardBinnaryFileReadResult<T>((T)res.Result, res.Succeed);
            }
            else throw new ArgumentException("Неподдерживаемый тип аргумента.", nameof(type));
        }
    }
}
