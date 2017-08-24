/*=================================\
* CWA.DTP.Plotter\FlFormatPrintMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 24.08.2017 20:27
* Last Edited: 24.08.2017 21:40:47
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
