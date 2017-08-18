/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:


	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.


	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.DTP \ DeviceControl.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:24
*
*=================================*/

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
