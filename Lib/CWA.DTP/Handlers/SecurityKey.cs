/*=================================\
* CWA.DTP\SecurityKey.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 16.09.2017 11:37
* Last Edited: 26.09.2017 20:49:14
*=================================*/

using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace CWA.DTP
{
    public sealed class SecurityKey
    {
        public SecurityKey(byte[] LongKey)
        {
            MD5Manager = MD5.Create();
            SetFromHash(LongKey);
        }

        public SecurityKey()
        {
            MD5Manager = MD5.Create();
        }

        public void SetFromHash(string StringKey)
        {
            key = MD5Manager.ComputeHash(Encoding.Default.GetBytes(StringKey));
        }

        public void SetFromHash(byte[] LongKey)
        {
            key = MD5Manager.ComputeHash(LongKey);
        }

        public SecurityKey(string StringKey)
        {
            MD5Manager = MD5.Create();
            SetFromHash(StringKey);
        }

        internal MD5 MD5Manager;

        internal byte[] key;

        public byte[] Key
        {
            get => key;
            set
            {
                if (value.Length != 16)
                    throw new ArgumentException("Длина массива должна быть 16", nameof(value));
                key = value;
            }
        }

        public static SecurityKey DefaultKey => new SecurityKey() { key = new byte[16] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };

        public static bool operator ==(SecurityKey a, SecurityKey b)
        {
            if (a is null && b is null)
                return true;

            try
            {
                return (a.key.SequenceEqual(b.key));
            }
            catch
            {
                return false;
            }
        }

        public static bool operator !=(SecurityKey a, SecurityKey b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SecurityKey))
                return false;
            return this == (SecurityKey)obj;
        }

        public unsafe override int GetHashCode()
        {
            fixed (byte* data = key)
                return (int)CrCHandler.CRC32(data, (UInt32)key.Length);
        }
    }
}
