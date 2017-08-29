/*=================================\
* CWA.DTP\DeviceControl.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 28.08.2017 14:38:23
*=================================*/

using System;

namespace CWA.DTP
{
    public class DeviceControl
    {
        internal DTPMaster ParentMaster;

        internal DeviceControl() { }

        public bool Test() => ParentMaster.ph.Device_Test();

        public bool Test(byte[] data) => ParentMaster.ph.Device_DataTest(data);

        public bool SyncTyme() => ParentMaster.ph.Device_SyncTime() != -1;

        public CardInfo CardInfo => ParentMaster.ph.Device_GetCardInfo().CI;

        public DeviceInfo DeviceInfo => ParentMaster.ph.Device_GetGlobalInfo().DI;

        public DateTime DateTime
        {
            get
            {
                var res = ParentMaster.ph.Device_GetTime();
                if (!res.Success)
                    throw new FailOperationException("Cant get DateTime");
                return res.Time;
            }
            set
            {
                if(!ParentMaster.ph.Device_SetTime(value))
                    throw new FailOperationException("Cant set DateTime");
            }
        }
    }
}
