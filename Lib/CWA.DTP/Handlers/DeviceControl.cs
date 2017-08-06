using System;

namespace CWA.DTP
{
    public class DeviceControl
    {
        internal DTPMaster ParentMaster;

        internal DeviceControl() { }

        public bool Test()
        {
            return ParentMaster.ph.Device_Test();
        }

        public bool Test(byte[] data)
        {
            return ParentMaster.ph.Device_DataTest(data);
        }

        public bool SyncTyme()
        {
            return ParentMaster.ph.Device_SyncTime() != -1;
        }

        public CardInfo CardInfo
        {
            get
            {
                return ParentMaster.ph.Device_GetCardInfo().CI;
            }
        }

        public DeviceInfo DeviceInfo
        {
            get
            {
                return ParentMaster.ph.Device_GetGlobalInfo().DI;
            }
        }

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
