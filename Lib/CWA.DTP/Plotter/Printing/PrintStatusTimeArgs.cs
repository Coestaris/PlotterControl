/*=================================\
* CWA.DTP\PrintStatusTimeArgs.cs
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
