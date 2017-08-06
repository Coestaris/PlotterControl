using System;
using System.Drawing;
using System.Threading;

namespace CWA.DTP.Plotter
{
    public enum PrintErrorType
    {
        CantFoundFileWithSpecifiedIndex,
        CantInitPrinting
    }

    public enum PrintStatus
    {
        FailGetStatus,
        Printing,
        NotPrinting
    }

    public delegate void PrintErrorHandler(PrintErrorType arg);

    public delegate void StatusErrorHandler(PrintStatus arg, UInt32 CurrentPosition, UInt32 MaxPosition);


    public class PrintMaster
    {
        private Thread StatusRequestTimer;

        public event PrintErrorHandler OnError;

        public event StatusErrorHandler StatusRequest;

        private void RaiseErrorEvent(PrintErrorType arg)
        {
            OnError?.Invoke(arg);
        }

        private void RaiseStatusRequest(PrintStatus arg, UInt32 CurrentPosition, UInt32 MaxPosition)
        {
            StatusRequest?.Invoke(arg, CurrentPosition, MaxPosition);
        }

        private PlotterPacketHandler ph;
        private DTPMaster Master;
        private bool Printing;
        private float XCoef, YCoef;
        private PlotterContent ContentMaster;

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
        }

        private float XSize = .0f;
        private float YSize = .0f;

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

        public void StatusRequestTimerHandler()
        {
            while (Printing)
            {
                Thread.Sleep((int)StatusRequestInterval);
            }
        }

        public void BeginPrinting(UInt16 Index)
        {

            StatusRequestTimer = new Thread(StatusRequestTimerHandler);
            StatusRequestTimer.Start();

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
                ph.StartPrinting((UInt16)XCoef, (UInt16)YCoef, Index);
            }
            catch
            {
                RaiseErrorEvent(PrintErrorType.CantFoundFileWithSpecifiedIndex);
                return;
            }

            Printing = true;
        }
    }
}