using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.DTP.Plotter
{
    enum CommandType
    {
        Plotter_RefreshConfig = 0x120,
        Plotter_Print_Run = 0x121,
        Plotter_Print_Info = 0x122,
        Plotter_Print_Abort = 0x123,
    }
}
