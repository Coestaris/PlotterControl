/*=================================\
* CWA.DTP\SecurityManager.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 16.09.2017 11:37
* Last Edited: 16.09.2017 14:02:41
*=================================*/

namespace CWA.DTP
{
    public sealed class SecurityManager
    {
        internal DTPMaster ParentMaster;

        internal SecurityManager() { }

        public bool IsValidationRequired { get => ParentMaster.ph.Security_IsValidationRequired(); }

       // public bool IsValidated() { }

        //public bool Set

       // public bool ChangeKey(SecurityKey LastKey, SecurityKey NewKey)
       // {
      //  }

       // public bool EnterKey(SecurityKey Key)
       // {
            
      //  }

        public SecurityKey Key;
    }
}
