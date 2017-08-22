/*=================================\
* CWA.DTP.Plotter\CommandType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

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
