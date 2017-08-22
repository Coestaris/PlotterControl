/*=================================\
* CWA.DTP.Plotter\PrintStatusTimeArgs.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:33
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;

namespace CWA.DTP.Plotter
{
    public class PrintStatusTimeArgs
    {
        public DateTime StartTime { get; internal set; }
        public double SecondsSpend { get; internal set; }
        public double SecondsLeft { get; internal set; }
        public double Speed { get; internal set; }

        public override string ToString()
        {
            return string.Format("StartTime: {0}. Time Left: {1}s. Speed: {2} operations / sec", StartTime, SecondsLeft, Speed);
        }
    }
}
