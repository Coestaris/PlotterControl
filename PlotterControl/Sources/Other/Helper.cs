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

using System;
using System.Linq;
using System.Drawing;

namespace Helper
{
    public abstract class Helper
    {
        public static void Wr<T>(T[][] arr)
        {
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                for (int ii = 0; ii <= arr[i].Length - 1; ii++)
                {
                    if (ii != arr[i].Length - 1)
                    {
                        Console.Write(arr[i][ii].ToString());
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.Write(arr[i][ii].ToString());
                        Console.Write(";");
                    }
                }
                if (i != arr.Length - 1) Console.WriteLine();
            }
        }

        public static void Swap<t>(ref t t1, ref t t2)
        {
            var tm = t1;
            t1 = t2;
            t2 = tm;
        }

        public static T[] Arr<T>(params T[] el)
        {
            return el;
        }

        public static void InsertToArray<T>(ref T[] arr, T em)
        {
            if (arr == null) arr = new T[0];
            var l = arr.ToList();
            l.Add(em);
            arr = l.ToArray();
        }

        public static long GCD(long x, long y)
        {
            return y == 0 ? x : GCD(y, x % y);
        }

        public static float Distance(Point a, Point b)
        {
            return (float)Math.Sqrt((a.X - a.X) * (a.X - a.X) + (a.Y - a.Y) * (a.Y - a.Y));
        }

        public static void ConcatArrays<T>(ref T[] a, ref T[] b)
        {
            if (a == null) a = new T[0];
            if (b == null) b = new T[0];
            var l = a.ToList();
            l.AddRange(b);
            a = l.ToArray();
        }

        public static void DeleteFromArray<T>(int count, ref T[] ar)
        {
            if (count == 0) throw new ArgumentException("Count cant be 0", nameof(count));
            if (count > ar.Length) throw new ArgumentException("Count cant be > ar.Length()");
            var l = ar.ToList();
            l.RemoveAt(count - 1);
            ar = l.ToArray();
        }

        public static bool IfIn<T>(T em, T[] arr)
        {
            return arr.Contains(em);
        }

        public static byte GetAverageColor(Color c)
        {
            return (byte)((c.R + c.B + c.G) / 3);
        }

        public static Color NewOneChColor(byte b)
        {
            return Color.FromArgb(b, b, b);
        }

    }

}
