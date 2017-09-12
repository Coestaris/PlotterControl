/*=================================\
* CWA.DTP\AbstractMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 12.09.2017 21:45:57
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
            if(Master != null)
                ph = new PlotterPacketHandler(master.Sender, master.Listener);
        }
    }
}
