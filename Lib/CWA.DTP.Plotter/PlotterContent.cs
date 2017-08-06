using CWA.DTP.FileTransfer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWA.DTP.Plotter
{
    public class PlotterContent
    {
        internal DTPMaster Master;

        internal PlotterContentTable ContentTable { get; private set; }

        public List<UInt16> VectorIndexes
        {
            get
            {
                return ContentTable.VectorAdresses;
            }
        }

        public PlotterContent(DTPMaster master)
        {
            Master = master;
            ContentTable = new PlotterContentTable(Master);
        }

        public VectorMetaData[] GetAllVectorsMetaData()
        {
            List<VectorMetaData> result = new List<VectorMetaData>();
            foreach (UInt16 index in ContentTable.VectorAdresses)
            {
                var file = Master.CreateFileHandler(index + ".m").Open(false);
                var readRes = file.BinnaryFile.ReadByteArray(file.Length);
                file.Close();
                if (!readRes.Succeed) throw new FailOperationException("Ну удалось получить данные");
                result.Add(new VectorMetaData(readRes.Result, this) { Index = index });
            }
            return result.ToArray();
        }

        public bool DeleteAllVectors()
        {
            for (int i = ContentTable.VectorAdresses.Count; i > 0 ; i--)
            {
                UInt16 index = ContentTable.VectorAdresses[i - 1];
                try
                {
                    Master.CreateFileHandler(index + ".p").Delete();
                    Master.CreateFileHandler(index + ".m").Delete();
                    Master.CreateFileHandler(index + ".v").Delete();
                    ContentTable.VectorAdresses.Remove(index);
                    ContentTable.VectorHashes.Remove(index);
                    ContentTable.PreviewHashes.Remove(index);
                    ContentTable.Upload();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public UInt16 CountOfVectors
        {
            get
            {
                return ContentTable.CountOfVectors;
            }
        }

        public VectorMetaData GetVectorMetaData(UInt16 index)
        {
            if (!ContentTable.VectorAdresses.Contains(index))
                throw new IndexOutOfRangeException();
            var file = Master.CreateFileHandler(index + ".m").Open(false);
            var readRes = file.BinnaryFile.ReadByteArray(file.Length);
            file.Close();
            if (!readRes.Succeed) throw new FailOperationException("Ну удалось получить данные");
            return new VectorMetaData(readRes.Result, this) { Index = index };
        }

        public bool DeleteVector(UInt16 index)
        {
            if (!ContentTable.VectorAdresses.Contains(index))
                throw new IndexOutOfRangeException();
            try
            {
                Master.CreateFileHandler(index + ".p").Delete();
                Master.CreateFileHandler(index + ".m").Delete();
                Master.CreateFileHandler(index + ".v").Delete();
                ContentTable.VectorAdresses.Remove(index);
                ContentTable.VectorHashes.Remove(index);
                ContentTable.PreviewHashes.Remove(index);
                ContentTable.Upload();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UploadVector(Vectors.Vector vector)
        {
            return UploadVector(vector, vector.Filename.Split('\\').Last().Split('.').First());
        }

        public bool UploadVector(Vectors.Vector vector, string name)
        {
            UInt16 index = (UInt16)(CountOfVectors + 1);
            string previewName =string.Format("{0}.p", index);
            string vectorName = string.Format("{0}.v", index);
            string metaDataName = string.Format("{0}.m", index);
            string previewPcName = string.Format("{1}\\Data\\Cache\\{0}", previewName, Environment.CurrentDirectory);
            string vectorPcName = string.Format("{1}\\Data\\Cache\\{0}", vectorName, Environment.CurrentDirectory);
            string metaDataPcName = string.Format("{1}\\Data\\Cache\\{0}", metaDataName, Environment.CurrentDirectory);
            var preview = new Bitmap(vector.ToBitmap(Color.White, Color.Black), new Size(500, 500));
            var bytes = vector.ToBinnaryVector();
            var meta = new VectorMetaData(this)
            {
                Height = (UInt16)vector.Header.Height,
                Index = index,
                Name = name,
                Type = vector.Header.VectType,
                Width = (UInt16)vector.Header.Width
            };
            preview.Save(previewPcName);
            File.WriteAllBytes(vectorPcName, bytes);
            File.WriteAllBytes(metaDataPcName, meta.ToByteArray());

            var fileSender = Master.CreateFileSender(FileTransferSecurityFlags.VerifyLengh);

            fileSender.PacketLength = 2000;

            if (!fileSender.SendFileSync(vectorPcName, vectorName))
                return false;
            if (!fileSender.SendFileSync(previewPcName, previewName))
                return false;
            if (!fileSender.SendFileSync(metaDataPcName, metaDataName))
                return false;

            ContentTable.VectorHashes.Add(index, CrCHandler.CRC32(vectorPcName));
            ContentTable.PreviewHashes.Add(index, CrCHandler.CRC32(previewPcName));
            ContentTable.VectorAdresses.Add(index);
            ContentTable.Upload();
            return true;
        }
    }
}
