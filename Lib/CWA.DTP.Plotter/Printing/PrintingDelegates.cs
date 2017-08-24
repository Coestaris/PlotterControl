/*=================================\
* CWA.DTP.Plotter\PrintingDelegates.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 24.08.2017 20:42
* Last Edited: 24.08.2017 20:43:23
*=================================*/

using System;

namespace CWA.DTP.Plotter
{
    public delegate void PrintEndEventHandler();

    public delegate void PrintErrorEventHandler(PrintErrorType arg);

    public delegate void PrintStatusEventHandler(PrintStatus arg, UInt32 CurrentPosition, UInt32 MaxPosition, PrintStatusTimeArgs TimeArgs);
}
