/*=================================\
* CWA.DTP\SecurityManager.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 16.09.2017 11:37
* Last Edited: 16.09.2017 23:58:29
*=================================*/

using System;

namespace CWA.DTP
{
    public sealed class SecurityManager
    {
        internal DTPMaster ParentMaster;

        internal SecurityManager(DTPMaster dTPMaster)
        {
            ParentMaster = dTPMaster;
            IsValidationRequired = ParentMaster.ph.Security_IsValidationRequired();
        }

        public static InvalidOperationException NotValidatedDevice = new InvalidOperationException("Ќевозможно выполнить данную операцию, когда не выполнена необходима€ валидаци€");

        public bool IsValidationRequired { get; private set; }

        public bool IsValidated => (!IsValidationRequired) ? true : _validKey != null;

        public bool SetValidation(bool Use)
        {
            if (!IsValidated)
                throw new InvalidOperationException("Ќевозможно выполнить данную операцию, когда не выполнена необходима€ валидаци€");

            if (ParentMaster.ph.Security_SetValidation(Use))
            {
                IsValidationRequired = true;
                return true;
            }
            return false;
        }

        public bool ChangeKey(SecurityKey LastKey, SecurityKey NewKey)
        {
            if (!IsValidated)
                throw new InvalidOperationException("Ќевозможно выполнить данную операцию, когда не выполнена необходима€ валидаци€");

            if (ParentMaster.ph.Security_ChangeKey(LastKey.key, NewKey.key))
            {
                _validKey = NewKey;
                return true;
            }
            return false;
        }

        public bool Validate(SecurityKey Key)
        {
            if(ParentMaster.ph.Security_Validate(Key.key))
            {
                _validKey = Key;
                return true;
            }
            return false;
        }

        private SecurityKey _validKey;

        public SecurityKey ValidKey => IsValidationRequired ? 
                _validKey ?? throw new InvalidOperationException("¬алидаци€ либо не была успешной, либо не была проведена вовсе.")
                : SecurityKey.Empty;
        
    }
}
