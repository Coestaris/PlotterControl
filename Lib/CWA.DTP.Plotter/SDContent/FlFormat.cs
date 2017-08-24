/*=================================\
* CWA.DTP.Plotter\FlFormat.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 24.08.2017 14:19
* Last Edited: 24.08.2017 20:16:32
*=================================*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace CWA.DTP.Plotter
{
    public class FlFormat
    {
        public List<FlFormatElement> Elements { get; private set; }

        public unsafe UInt32 CRC32
        {
            get
            {
                byte[] bytes = ToBytes();
                fixed (byte* bytesP = bytes)
                    return CrCHandler.CRC32(bytesP, (UInt32)bytes.Length);
            }
        }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            foreach (var item in Elements)
            {
                bytes.AddRange(BitConverter.GetBytes(item.Dx));
                bytes.AddRange(BitConverter.GetBytes(item.Dy));
                bytes.AddRange(BitConverter.GetBytes(item.Dz));
                bytes.AddRange(BitConverter.GetBytes(item.Delay));
            }
            return bytes.ToArray();
        }

        public FlFormat()
        {
            Elements = new List<FlFormatElement>();
        }

        public FlFormat(byte[] bytes)
        {
            Elements = new List<FlFormatElement>();
            bytes.Split(8).ToList().ForEach(p =>
            {
                var data = p.ToArray();
                var elem = new FlFormatElement()
                {
                    Dx = (Int16)((data[1] & 0xFF) << 8 | (data[0] & 0xFF)),
                    Dy = (Int16)((data[3] & 0xFF) << 8 | (data[2] & 0xFF)),
                    Dz = (Int16)((data[5] & 0xFF) << 8 | (data[4] & 0xFF)),
                    Delay = (UInt16)((data[7] & 0xFF) << 8 | (data[6] & 0xFF)),
                };
                Elements.Add(elem);
            });
        }
    }
}
