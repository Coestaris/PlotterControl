/*=================================\
* CWA.DTP\SdCardBinnaryFileReadResult.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 21.09.2017 10:59:05
*=================================*/

namespace CWA.DTP
{
    public sealed class SdCardBinnaryFileReadResult<T>
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
