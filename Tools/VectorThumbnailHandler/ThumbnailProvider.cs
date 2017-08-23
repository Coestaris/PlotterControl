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
    [ThumbnailProvider("PCVThumbnailer", ".pcv", ThumbnailAdornment = ThumbnailAdornment.None, DisableProcessIsolation = true)]
    public class ThumbnailProvider : Microsoft.WindowsAPICodePack.ShellExtensions.ThumbnailProvider, IThumbnailFromShellObject, IThumbnailFromFile
    {
        public Bitmap ConstructBitmap(FileInfo info, int sideSize)
        {
            return new Vector(info.FullName).ToBitmap(Color.White, Color.Black, new Size(sideSize, sideSize));
        }

        public Bitmap ConstructBitmap(ShellObject shellObject, int sideSize)
        {
            return new Vector(shellObject.ParsingName).ToBitmap(Color.White, Color.Black, new Size(sideSize, sideSize));
        }
    }
}