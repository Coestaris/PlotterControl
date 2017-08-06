/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

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
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

#define SimpleCRC

using System;

namespace CWA.DTP
{
    public static class HelpMethods
    {
        public static Tuple<byte, byte> SplitNumber(int num)
        {
            byte low = (byte)(num & 0xFF);
            byte high = (byte)((num >> 8) & 0xFF);
            return new Tuple<byte, byte>(low, high);
        }

        public static UInt16 GetNumber(byte low, byte high)
        {
            return (UInt16)(low | (high << 8));
        }

#if SimpleCRC
        public static unsafe int ComputeChecksum(byte* data_p, int length) 
        {
            byte x;
            ushort crc = 0xFFFF;
            while (length-- != 0)
            {
                x = (byte)(crc >> 8 ^ *data_p++);
                x ^= (byte)(x >> 4);
                crc = (ushort)((crc << 8) ^ ((ushort)(x << 12)) ^ ((ushort)(x << 5)) ^ ((ushort)x));
            }
            return crc;
        }
#endif 

    }
}