/*=================================\
* CWA.DTP.Plotter\AbstractMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 24.08.2017 20:28
* Last Edited: 24.08.2017 20:51:03
*=================================*/

namespace CWA.DTP.Plotter
{
    public abstract class AbstractMaster
    {
        public DTPMaster Master { get; set; }

        internal PlotterPacketHandler ph;

        public AbstractMaster(DTPMaster master)
        {
            Master = master;
            ph = new PlotterPacketHandler(master.Sender, master.Listener);
        }
    }
}
