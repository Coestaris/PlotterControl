/*=================================\
* CWA.DTP\CommandType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 15.09.2017 22:40:15
*=================================*/

using System;

namespace CWA.DTP.Plotter
{
    enum CommandType : UInt32
    {
        Plotter_RefreshConfig = 0x120,
        Plotter_Print_Run = 0x121,
        Plotter_Print_Info = 0x122,
        Plotter_Print_Abort = 0x123,
        Plotter_Print_Run_Ex = 0x124,
        Plotter_Move = 0x125,
        Plotter_TurnEngines_On = 0x126,
        Plotter_TurnEngines_Off = 0x127,
    };
}
