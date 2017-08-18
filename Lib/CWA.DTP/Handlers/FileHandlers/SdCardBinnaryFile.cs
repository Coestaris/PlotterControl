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
* CWA.DTP \ SdCardBinnaryFile.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
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

        #region Write Methods
        public bool Write(string val)
        {
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
            if(ph.File_Append(new byte[1] { val }))
            {
                cacheLength += 1;
                CursorPos += 1;
                return true;
            }
            return false;
        }

        public bool Write(short val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += 2;
                CursorPos += 2;
                return true;
            }
            return false;
        }

        public bool Write(UInt16 val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += 2;
                CursorPos += 2;
                return true;
            }
            return false;
        }

        public bool Write(int val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += 4;
                CursorPos += 4;
                return true;
            }
            return false;
        }

        public bool Write(UInt32 val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += 4;
                CursorPos += 4;
                return true;
            }
            return false;
        }

        public bool Write(long val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += 8;
                CursorPos += 8;
                return true;
            }
            return false;
        }

        public bool Write(UInt64 val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                cacheLength += 8;
                CursorPos += 8;
                return true;
            }
            return false;
        }

        public bool Write(float val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                CursorPos += 4;
                cacheLength += 4;
                return true;
            }
            return false;
        }

        public bool Write(double val)
        {
            if (ph.File_Append(BitConverter.GetBytes(val)))
            {
                CursorPos += 8;
                cacheLength += 8;
                return true;
            }
            return false;
        }

        public bool Write(bool val)
        {
            if (ph.File_Append(new byte[1] { val ? (byte)1 : (byte)0 }))
            {
                CursorPos += 1;
                cacheLength += 1;
                return true;
            }
            return false;
        }

        public bool Write(char val)
        {
            if (ph.File_Append( new byte[1] { (byte)val }))
            {
                cacheLength += 1;
                CursorPos += 1;
                return true;
            }
            return false;
        }
        
        public bool Write(byte[] val)
        {
            if (ph.File_Append(val))
            {
                cacheLength += 1;
                CursorPos += 1;
                return true;
            }
            return false;
        }
        #endregion

        #region Read Methods
        private SdCardBinnaryFileReadResult<object> ReadByte()
        {
            if (CursorPos + 1 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 1);
            if(res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 1;
                return new SdCardBinnaryFileReadResult<object>(res.Result[0], true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadBool()
        {
            if (CursorPos + 1 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 1);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 1;
                return new SdCardBinnaryFileReadResult<object>(res.Result[0] == 1, true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadShort()
        {
            if (CursorPos + 2 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 2);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 2;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToInt16(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadUInt16()
        {
            if (CursorPos + 2 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 2);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 2;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToUInt16(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadInt()
        {
            if (CursorPos + 4 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 4);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 4;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToInt32(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadUInt32()
        {
            if (CursorPos + 4 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 4);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 4;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToUInt32(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadLong()
        {
            if (CursorPos + 8 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 8);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 8;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToInt64(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadUInt64()
        {
            if (CursorPos + 8 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 8);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 8;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToUInt64(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadFloat()
        {
            if (CursorPos + 4 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 4);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 4;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToSingle(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }

        private SdCardBinnaryFileReadResult<object> ReadDouble()
        {
            if (CursorPos + 8 > cacheLength)
                throw new ArgumentOutOfRangeException();
            var res = ph.File_Read(CursorPos, 8);
            if (res.Status == GeneralPacketHandler.WriteReadFileHandleResult.OK)
            {
                CursorPos += 8;
                return new SdCardBinnaryFileReadResult<object>(BitConverter.ToDouble(res.Result, 0), true);
            }
            return new SdCardBinnaryFileReadResult<object>(0, false);
        }
        #endregion

        public SdCardBinnaryFileReadResult<byte[]> ReadByteArray(UInt32 length)
        {
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
