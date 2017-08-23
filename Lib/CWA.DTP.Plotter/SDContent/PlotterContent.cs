/*=================================\
* CWA.DTP.Plotter\PlotterContent.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:34
* Last Edited: 23.08.2017 20:35:40
*=================================*/

using CWA.DTP.FileTransfer;
using CWA.Vectors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

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

        public bool UploadVector(Vector vector)
        {
            return UploadVector(vector, vector.Filename.Split('\\').Last().Split('.').First());
        }

        public bool UploadVector(Vector vector, string name)
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

            //Находим хэш файла пк.
            var localHash = CrCHandler.CRC32(vectorPcName);
            if(ContentTable.PreviewHashes.Values.Contains(localHash))
            {
                //Если файл с таким хэшем есть на устройстве, то нечего его переотправлять
                return true;
            }

            var fileSender = Master.CreateFileSender(FileTransferSecurityFlags.VerifyLengh
                                                   | FileTransferSecurityFlags.VerifyCheckSum);
            fileSender.PacketLength = 2000;
            if (!fileSender.SendFileSync(vectorPcName, vectorName))
                return false;
            if (!fileSender.SendFileSync(previewPcName, previewName))
                return false;
            if (!fileSender.SendFileSync(metaDataPcName, metaDataName))
                return false;
            //Добавляем в нашу таблицу хэш данного вектора.
            ContentTable.VectorHashes.Add(index, CrCHandler.CRC32(vectorPcName));
            //Хэш превью изображения.
            ContentTable.PreviewHashes.Add(index, CrCHandler.CRC32(previewPcName));
            //Сам адресс вектора.
            ContentTable.VectorAdresses.Add(index);
            //Загружаем измененный конфиг на девайс.
            try
            {
                ContentTable.Upload();
            }
            catch
            {
                //Особо неважно, что именно произошло.
                return false;
            }
            return true;
        }

        public void Refresh()
        {
            ContentTable = new PlotterContentTable(Master);
        }
    }
}
