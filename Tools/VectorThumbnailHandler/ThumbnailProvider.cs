using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions;
using CWA.Vectors;

namespace HandlerSamples
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("CNCWFA.PCVThumbnailer")]
    [Guid("38AA8375-27EC-4EAF-955E-D7BDA633069E")]
    [ThumbnailProvider("PCVThumbnailer", ".pcv", ThumbnailAdornment = ThumbnailAdornment.DropShadow, DisableProcessIsolation = true)]
    public class ThumbnailProvider : Microsoft.WindowsAPICodePack.ShellExtensions.ThumbnailProvider, IThumbnailFromShellObject, IThumbnailFromFile
    {
        private const float FontSizeKoef = 0.0872727272727273f;
        private const float TextXKoef = 0.0748181818181818f;
        private const float TextYKoef = 0.8136363636363636f;

        public Bitmap ConstructBitmap(FileInfo info, int sideSize)
        {
            return ProccedBitmap(info.FullName, sideSize);
        }

        private Bitmap ProccedBitmap(string Filename, int sideSize)
        {
            var v = new Vector(Filename);
            int borderSize = (int)(sideSize * .1f);
            Bitmap baseBmp = v.ToBitmap(Color.White, Color.Black, new Size(sideSize - borderSize, sideSize - borderSize));
            Bitmap bmp = new Bitmap(sideSize, sideSize);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                string FileFortamStr = ".PCV";
                switch (v.Header.FileFormat)
                {
                    case VectorFileFormat.PRRES:
                        FileFortamStr = ".PRRES";
                        break;
                    case VectorFileFormat.PCV:
                        FileFortamStr = ".PCV";
                        break;
                    case VectorFileFormat.OPCV:
                        FileFortamStr = ".OPCV";
                        break;
                    default:
                        FileFortamStr = "err";
                        break;
                }
                gr.FillRectangle(new SolidBrush(Color.FromArgb(101, 0, 101)), new Rectangle(0, 0, sideSize, sideSize));
                gr.DrawImage(baseBmp, new Point(borderSize / 2, borderSize / 2));
                gr.DrawString(FileFortamStr, new Font("Century", FontSizeKoef * sideSize), Brushes.Black, new PointF(TextXKoef * sideSize, TextYKoef * sideSize));
            }
            return bmp;
        }

        public Bitmap ConstructBitmap(ShellObject shellObject, int sideSize)
        {
            return ProccedBitmap(shellObject.ParsingName, sideSize);
        }
    }
}