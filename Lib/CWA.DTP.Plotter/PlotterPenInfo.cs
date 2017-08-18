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
* CWA.DTP.Plotter \ PlotterPenInfo.cs
*
* Created: 09.08.2017 15:56
* Last Edited: 18.08.2017 20:23:25
*
*=================================*/

using System;
using System.Drawing;
using System.Linq;

namespace CWA.DTP.Plotter
{
    public class PlotterPenInfo
    {
        public string Name { get; set; }
        public UInt16 ElevationDelta { get; set; }
        public Int16 ElevationCorrection { get; set; }
        public Color Color { get; set; }

        internal byte[] ToByteArray()
        {
            var result = new byte[7 + Name.Length];
            Buffer.BlockCopy(Name.Select(p => (byte)p).ToArray(), 0, result, 0, Name.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(ElevationDelta), 0, result, Name.Length, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(ElevationCorrection), 0, result, Name.Length + 2, 2);
            Buffer.BlockCopy(new byte[3] { Color.R, Color.G, Color.B }, 0, result, Name.Length + 4, 3);
            return result;
        }

        public PlotterPenInfo(string Name, UInt16 ElevationDelta, Int16 ElevationCorrection, Color color)
        {
            this.Name = Name;
            this.ElevationCorrection = ElevationCorrection;
            this.ElevationDelta = ElevationDelta;
            Color = color;
        }

        internal PlotterPenInfo(byte[] data)
        {
            Name = new String(data.Take(data.Length - 7).Select(p => (char)p).ToArray());
            ElevationDelta = BitConverter.ToUInt16(data.Skip(Name.Length).ToArray(), 0);
            ElevationCorrection = BitConverter.ToInt16(data.Skip(Name.Length).ToArray(), 2);
            byte[] colorBytes = data.Skip(Name.Length + 4).ToArray();
            Color = Color.FromArgb(255, colorBytes[0], colorBytes[1], colorBytes[2]);
        }

        public override string ToString()
        {
            return string.Format("Name: {0}. \nElevationDelta: {1}. \nElevationCorrection: {2}. \nColor: {3}",
                Name, ElevationDelta, ElevationCorrection, Color.ToString());
        }
    }
}
