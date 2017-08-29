/*=================================\
* CWA.DTP.Plotter\FlFormatPrintMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 24.08.2017 20:27
* Last Edited: 28.08.2017 14:39:06
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
