using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.DTP.Plotter
{
    public class PlotterConfig
    {
        private const string ConfigFileName = "/config.cfg";

        internal const UInt16 ConfigFileLength = 18;

        private DTPMaster Master;

        public PlotterConfigOptions Options { get; private set; }

        public void Upload()
        {
            var file = Master.CreateFileHandler(ConfigFileName).Open(true);
            if (!file.BinnaryFile.Write(Options.ToByteArray()))
                throw new FailOperationException("Не удалось записать данные конфиг-файла");
            file.Close();
        }

        public void Download()
        {
            var file = Master.CreateFileHandler(ConfigFileName).Open(false);
            var readRes = file.BinnaryFile.ReadByteArray(ConfigFileLength);
            if (readRes.Succeed) Options = new PlotterConfigOptions(readRes.Result);
            else throw new FailOperationException("Не удалось получить массив байтов конфиг-файла.");
            file.Close();
        }

        public PlotterConfig(DTPMaster master)
        {
            Master = master;
            Download();
        }
    }
}
