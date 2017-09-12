/*=================================\
* CWA.DTP\FlFormatPrintMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 12.09.2017 21:45:57
*=================================*/

namespace CWA.DTP.Plotter
{
    class FlFormatPrintMaster : AbstractMaster
    {
        public FlFormatPrintMaster(DTPMaster master) : base(master)
        {
            Content = new PlotterContent(master);
        }

        public PlotterContent Content { get; private set; }
    }
}
