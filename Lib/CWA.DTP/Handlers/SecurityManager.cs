/*=================================\
* CWA.DTP\SecurityManager.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 16.09.2017 11:37
* Last Edited: 08.10.2017 20:45:38
*=================================*/

using System;
using System.Security;

namespace CWA.DTP
{
    public sealed class SecurityManager
    {
        internal DTPMaster ParentMaster;

        private bool _validated = false;

        internal SecurityManager(DTPMaster dTPMaster)
        {
            ParentMaster = dTPMaster;
            IsValidationRequired = ParentMaster.ph.Security_IsValidationRequired();
            try
            {
                _validated = ParentMaster.ph.Device_DataTest(new byte[] { 1, 2 });
            }
            catch(SecurityException)
            {
                _validated = false;
            }
        }

        public bool IsValidationRequired { get; private set; }

        public bool IsValidated => (!IsValidationRequired) ? true : (_validated ? true : _validKey != null);

        public bool SetValidation(bool Use)
        {
            DTPMaster.CheckConnAndVal(); 
            if (ParentMaster.ph.Security_SetValidation(Use))
            {
                IsValidationRequired = true;
                return true;
            }
            return false;
        }

        public bool ResetKey()
        {
            bool res = false;
            if (ParentMaster.Listener.PacketReader is SerialPacketReader)
            {
                (ParentMaster.Listener.PacketReader as SerialPacketReader).TimeOutInterval += 3000;
                res = ParentMaster.ph.Security_ResetKey();
                (ParentMaster.Listener.PacketReader as SerialPacketReader).TimeOutInterval -= 3000;
            }
            if (res)
            {
                IsValidationRequired = true;
                _validKey = SecurityKey.DefaultKey;
            }
            return res;
        }

        public bool ChangeKey(SecurityKey LastKey, SecurityKey NewKey)
        {
            DTPMaster.CheckConnAndVal();
            if (ParentMaster.ph.Security_ChangeKey(LastKey.key, NewKey.key))
            {
                _validKey = NewKey;
                return true;
            }
            return false;
        }

        public bool Validate(SecurityKey Key)
        {
            if (IsValidated)
                return true;

            DTPMaster.CheckConnAndVal(true);
            if (ParentMaster.ph.Security_Validate(Key.key))
            {
                _validKey = Key;
                return true;
            }
            return false;
        }

        private SecurityKey _validKey;

        public SecurityKey ValidKey => IsValidationRequired ? 
                _validKey ?? throw new InvalidOperationException("Валидация либо не была успешной, либо не была проведена вовсе.")
                : SecurityKey.DefaultKey;
        
    }
}
