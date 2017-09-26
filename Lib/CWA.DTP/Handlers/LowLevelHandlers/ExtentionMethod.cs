/*=================================\
* CWA.DTP\ExtentionMethod.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 21.09.2017 10:06:00
*=================================*/

using System.Collections.Generic;
using System.Linq;

namespace CWA.DTP
{
    public static class ExtentionMethod
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
    }
}
