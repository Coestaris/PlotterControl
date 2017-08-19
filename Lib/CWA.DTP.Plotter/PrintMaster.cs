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
* CWA.DTP.Plotter \ PrintMaster.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 19.08.2017 16:45:07
*
*=================================*/

using System;
using System.Drawing;
using System.Threading;

namespace CWA.DTP.Plotter
{
    public delegate void PrintEndEventHandler();

    public delegate void PrintErrorEventHandler(PrintErrorType arg);

    public delegate void PrintStatusEventHandler(PrintStatus arg, UInt32 CurrentPosition, UInt32 MaxPosition, PrintStatusTimeArgs TimeArgs);
    
    public class PrintMaster
    {
        private int LasProgress, CountOfData;

        private double lSpeed, LastLeftTime;

        private PlotterPacketHandler ph;

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

        public DTPMaster Master { get; set; }

        public PlotterContent ContentMaster { get; private set; }

        public UInt32 StatusRequestInterval { get; set; }

        public float XMM { get; set; }

        public float YMM { get; set; }

        public PrintMaster(DTPMaster master, float Xmm, float Ymm, UInt32 statusRequestInterval)
        {
            StatusRequestInterval = statusRequestInterval;
            Master = master;
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
