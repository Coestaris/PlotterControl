/*=================================\
* CWA.DTP\DeviceControl.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 26.09.2017 21:24:40
*=================================*/

using System;

namespace CWA.DTP
{
    public sealed class DeviceControl
    {
        internal Sender _deviceSender;

        internal DTPMaster ParentMaster;

        internal DeviceControl() { }

        //Самый верный способ - задавать его при подключении, т. е. при вызове Test.
        //Для этого нужно обойти стандартный packetHandler =\, т. к. тот расчитан хранить подобное "в себе".
        //Потому, пускай, Device_Test возвращает не true или false, а Sender иди null. Профит.
        public Sender DeviceSender { get => _deviceSender ?? throw new InvalidOperationException("Для начала необходимо вызвать метод DeviceControl.Test(), что бы задать начальное значение данного параметра."); }

        public bool Test()
        {
            DTPMaster.CheckConnAndVal(true);
            var res = ParentMaster.ph.Device_Test();
            if (res != null)
            {
                _deviceSender = res;
                return true;
            }
            return false;
        }

        public bool SpeakerBeep(string Pattern)
        {
            DTPMaster.CheckConnAndVal();
            return ParentMaster.ph.Device_SpeakerBeep(Pattern);
        }

        public bool Test(byte[] data)
        {
            DTPMaster.CheckConnAndVal();
            return ParentMaster.ph.Device_DataTest(data);
        }

        public bool SyncTyme()
        {
            DTPMaster.CheckConnAndVal();
            return ParentMaster.ph.Device_SyncTime() != -1;
        }


        public CardInfo CardInfo
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                return ParentMaster.ph.Device_GetCardInfo().CI;
            }
        }

        public DeviceInfo DeviceInfo
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                return ParentMaster.ph.Device_GetGlobalInfo().DI;
            }
        }

        public DateTime DateTime
        {
            get
            {
                DTPMaster.CheckConnAndVal();
                var res = ParentMaster.ph.Device_GetTime();
                if (!res.Success)
                    throw new FailOperationException("Cant get DateTime");
                return res.Time;
            }
            set
            {
                DTPMaster.CheckConnAndVal();
                if (!ParentMaster.ph.Device_SetTime(value))
                    throw new FailOperationException("Cant set DateTime");
            }
        }
    }
}
