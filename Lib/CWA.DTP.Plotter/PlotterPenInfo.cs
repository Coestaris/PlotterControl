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