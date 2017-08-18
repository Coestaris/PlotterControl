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
* CWA.DTP \ Sender.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:24
*
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
