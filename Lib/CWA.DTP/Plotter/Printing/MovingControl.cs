/*=================================\
* CWA.DTP\MovingControl.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 15.09.2017 22:12
* Last Edited: 15.09.2017 22:49:57
*=================================*/

using System;

namespace CWA.DTP.Plotter
{
    public class MovingControl : AbstractMaster
    {
        public MovingControl(DTPMaster master) : base(master) { }

        public bool MoveTool(Int16 dx, Int16 dy, Int16 dz)
        {
            DTPMaster.CheckConnAndVal();
            return ph.MoveTool(dx, dy, dz);
        }

        public bool MoveTool(PlotterPenInfo pen, bool UpDirrection)
        {
            DTPMaster.CheckConnAndVal();
            return ph.MoveTool(0, 0, UpDirrection ? (Int16)(pen.ElevationCorrection + pen.ElevationDelta) : (Int16)pen.ElevationDelta);
        }

        public bool MoveTool(UInt16 PenIndex, bool UpDirrection)
        {
            return MoveTool(new PlotterConfig(Master).Pens[PenIndex], UpDirrection);
        }

        public bool TurnOnEngines()
        {
            DTPMaster.CheckConnAndVal();
            return ph.TurnOnEngines();
        }

        public bool TurnOffEngines()
        {
            DTPMaster.CheckConnAndVal();
            return ph.TurnOnEngines();
        }
    }
}
