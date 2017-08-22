/*=================================\
* CWA.DTP\Sender.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;
using System.Linq;

namespace CWA.DTP
{
    public class Sender
    {
        public byte[] Mask { get; set; }
        public SenderType Type { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length != 7) throw new ArgumentException();
                if (Mask == null) Mask = new byte[7];
                for (int i = 0; i <= 6; i++) Mask[i] = (byte)value[i];
                _name = value;
            }
        }

        public static Sender Nullable
        {
            get
            {
                return new Sender(SenderType.UnNamedByteMask);
            }
        }

        public Sender(SenderType type)
        {
            Type = type;
            if (type == SenderType.UnNamedByteMask) Mask = RandomGenerateSenderMask();
            Name = RandomGenerateSenderName(7);
        }

        public Sender(SenderType type, string Name)
        {
            Type = type;
            if (type == SenderType.UnNamedByteMask) Mask = RandomGenerateSenderMask();
            else this.Name = Name;
        }

        public static string RandomGenerateSenderName(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static byte[] RandomGenerateSenderMask()
        {
            Random r = new Random();
            var result = new byte[7];
            r.NextBytes(result);
            return result;
        }

        public override string ToString()
        {
            if (Type == SenderType.UnNamedByteMask)
                return string.Format("Sender[{0}]", string.Join(",", Mask));
            else return string.Format("Sender[{0}]", Name);
        }

        public static bool operator !=(Sender first, Sender second)
        {
            if (first == second) return false;
            else return true;
        }

        public static bool operator ==(Sender first, Sender second)
        {
            if (first.Type == second.Type &&
                Enumerable.SequenceEqual(first.Mask, second.Mask)) return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            if (typeof(Sender) != obj.GetType()) return false;
            return this == (Sender)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
