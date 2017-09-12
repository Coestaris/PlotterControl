/*=================================\
* CWA.DTP\FlFormatElement.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 12.09.2017 21:45:57
*=================================*/

using System;

namespace CWA.DTP.Plotter
{
    public class FlFormatElement
    {
        public Int16 Dx { get; set; }
        public Int16 Dy { get; set; }
        public Int16 Dz { get; set; }
        public UInt16 Delay { get; set; }

        public FlFormatElement(short dx, short dy, short dz, ushort delay)
        {
            Dx = dx;
            Dy = dy;
            Dz = dz;
            Delay = delay;
        }

        public FlFormatElement() { }

        public override string ToString()
        {
            return string.Format("Dx: {0}; Dy: {1}; Dz: {2}; Delay: {3}", Dx, Dy, Dz, Delay);
        }
    }
}
