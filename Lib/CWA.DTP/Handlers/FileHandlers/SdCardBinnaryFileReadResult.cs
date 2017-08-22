/*=================================\
* CWA.DTP\SdCardBinnaryFileReadResult.cs
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
    public class SdCardBinnaryFileReadResult<T>
    {
        public T Result { get; private set; }
        public bool Succeed { get; private set; }

        internal SdCardBinnaryFileReadResult(T val, bool Succeed)
        {
            Result = val;
            this.Succeed = Succeed;
        }
    }
}
