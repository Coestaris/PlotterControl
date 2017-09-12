/*=================================\
* CWA.DTP\PrintingDelegates.cs
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
    public delegate void PrintEndEventHandler();

    public delegate void PrintErrorEventHandler(PrintErrorType arg);

    public delegate void PrintStatusEventHandler(PrintStatus arg, UInt32 CurrentPosition, UInt32 MaxPosition, PrintStatusTimeArgs TimeArgs);
}
