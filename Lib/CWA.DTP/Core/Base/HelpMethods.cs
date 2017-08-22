/*=================================\
* CWA.DTP\HelpMethods.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;

namespace CWA.DTP
{
    public static class HelpMethods
    {
        public static Tuple<byte, byte> SplitNumber(int num)
        {
            byte low = (byte)(num & 0xFF);
            byte high = (byte)((num >> 8) & 0xFF);
            return new Tuple<byte, byte>(low, high);
        }

        public static UInt16 GetNumber(byte low, byte high)
        {
            return (UInt16)(low | (high << 8));
        }
    }
}
