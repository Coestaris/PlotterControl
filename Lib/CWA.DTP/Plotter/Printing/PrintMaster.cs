/*=================================\
* CWA.DTP\PrintMaster.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 12.09.2017 21:45
* Last Edited: 12.09.2017 21:51:04
*=================================*/

using System;
using System.Drawing;
using System.Threading;

namespace CWA.DTP.Plotter
{
    public class PrintMaster : AbstractMaster
    {
        private int LasProgress, CountOfData;

        private double lSpeed, LastLeftTime;

        private bool Printing;

        private float XCoef, YCoef;

        private float XSize = .0f;

        private float YSize = .0f;

        private DateTime StartTime;

        private Thread StatusRequestTimer;

        public event PrintErrorEventHandler OnError;

        public event PrintEndEventHandler PrintingEnd;

        public event PrintStatusEventHandler StatusRequest;

        private void RaiseErrorEvent(PrintErrorType arg)
        {
            OnError?.Invoke(arg);
            StatusRequestTimer?.Abort();
        }

        private void RaiseEndEvent()
        {
            PrintingEnd?.Invoke();
            StatusRequestTimer?.Abort();
        }

        private void RaiseStatusRequest(PrintStatus arg, UInt32 CurrentPosition, UInt32 MaxPosition, PrintStatusTimeArgs TimeArgs)
        {
            StatusRequest?.Invoke(arg, CurrentPosition, MaxPosition, TimeArgs);
        }

        public PlotterContent ContentMaster { get; private set; }

        public UInt32 StatusRequestInterval { get; set; }

        public float XMM { get; set; }

        public float YMM { get; set; }

        internal PrintMaster(DTPMaster master, float Xmm, float Ymm, UInt32 statusRequestInterval) : base(master)
        {
            StatusRequestInterval = statusRequestInterval;
            ph = new PlotterPacketHandler(master.Sender, master.Listener);
            XMM = Xmm;
            YMM = Ymm;
            ContentMaster = new PlotterContent(Master);
        }

        public void SetXSize(float XSize)
        {
            this.XSize = XSize;
            YSize = 0;
        }

        public void SetYSize(float YSize)
        {
            this.YSize = YSize;
            XSize = 0;
        }

        private float GetYsize(float imgWidth, float imgHeight, float xSize)
        {
            return xSize * imgHeight / imgWidth;
        }

        private float GetXsize(float imgWidth, float imgHeight, float ySize)
        {
            return ySize * imgWidth / imgHeight;
        }

        private void GetCoefficients(SizeF printSize)
        {
            XCoef = XSize / XMM / printSize.Width;
            YCoef = YSize / YMM / printSize.Height;
        }

        private void StatusRequestTimerHandler()
        {
            while (Printing)
            {
                var res = ph.PrintStatus();
                if (res.Status == PrintStatus.FailGetStatus)
                    RaiseErrorEvent(PrintErrorType.CantGetStatus);
                if (res.Status == PrintStatus.NotPrinting)
                {
                    Printing = false;
                    RaiseEndEvent();
                }
                var OnseSecondProgress = (Int32)res.Curr - LasProgress;
                LasProgress = (Int32)res.Curr;
                CountOfData += OnseSecondProgress;
                double Speed = 0, LeftTime = 0;
                if (lSpeed == 0) Speed = (double)OnseSecondProgress * 2;
                else Speed = (lSpeed + (double)OnseSecondProgress * 2) / 2;
                lSpeed = Speed;
                if (LastLeftTime == 0 || LastLeftTime == float.PositiveInfinity)
                {
                    if (OnseSecondProgress == 0) LeftTime = float.PositiveInfinity;
                    else LeftTime = (res.Max - CountOfData) / OnseSecondProgress / 2;
                }
                else
                {
                    if (OnseSecondProgress == 0) LeftTime = float.PositiveInfinity;
                    else LeftTime = (LastLeftTime + (res.Max - CountOfData) / OnseSecondProgress / 2) / 2;
                }
                LastLeftTime = LeftTime;
                PrintStatusTimeArgs TimeArgs = new PrintStatusTimeArgs()
                {
                    StartTime = StartTime,
                    SecondsLeft = LeftTime,
                    SecondsSpend = (DateTime.Now - StartTime).TotalSeconds,
                    Speed = Speed
                };
                RaiseStatusRequest(res.Status, res.Curr, res.Max, TimeArgs);
                Thread.Sleep(500);
            }
        }
        
        public void BeginPrinting(UInt16 Index, PlotterPenInfo Pen)
        {
            StartTime = DateTime.Now;
            if (ContentMaster == null)
                ContentMaster = new PlotterContent(Master);

            if (!ContentMaster.ContentTable.VectorAdresses.Contains(Index))
            {
                RaiseErrorEvent(PrintErrorType.CantFoundFileWithSpecifiedIndex);
                return;
            }
            VectorMetaData metaData = ContentMaster.GetVectorMetaData(Index);
            if (XSize == 0)
                XSize = GetXsize(metaData.Width, metaData.Height, YSize);
            else YSize = GetYsize(metaData.Width, metaData.Height, XSize);
            GetCoefficients(new SizeF(metaData.Width, metaData.Height));
            try
            {
                ph.StartPrinting(Pen.ElevationDelta, Pen.ElevationCorrection, (UInt16)XCoef, (UInt16)YCoef, Index);
            }
            catch
            {
                RaiseErrorEvent(PrintErrorType.CantFoundFileWithSpecifiedIndex);
                return;
            }
            Printing = true;

            Thread.Sleep(1000);

            StatusRequestTimer = new Thread(StatusRequestTimerHandler);
            StatusRequestTimer.Start();

        }
    }
}
