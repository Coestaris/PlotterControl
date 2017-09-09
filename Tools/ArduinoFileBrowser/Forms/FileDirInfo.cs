/*=================================\
* ArduinoFileBrowser\FileDirInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.09.2017 20:10
* Last Edited: 06.09.2017 21:01:35
*=================================*/

using CWA.DTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser.Forms
{
    public partial class FileDirInfo : Form
    {
        public FileDirInfo(SdCardFile File, SdCardDirectoryFileInfo Info, UInt32 CRC, Image Ico)
        {
            InitializeComponent();
            pictureBox_ico.Image = Ico;
            label_name.Text = File.FileName;
            var fileType = MainForm.SystemFileName(File.FilePath, false, "");
            label_type.Text = $"Тип: файл {(fileType != InfoType.Unknown ? "(системный " + fileType.ToString() + ')' : "")}";
            label_size.Text = $"Размер: {MainForm.ProccedSize(Info.FileDirectorySize)}";
            label_path.Text = $"Путь к файлу: {File.FilePath}";
            label_created.Text = $"Создан: {Info.CreationTime.ToString("g")}";
            label_hash.Text = $"CRC32: {CRC.ToString()}";
            label_isHidden.Text = $"IsHidden: {Info.IsHidden}";
            label_isLfn.Text = $"IsLFN: {Info.IsLFN}";
            label_isRO.Text = $"IsReadOnly: {Info.IsReadOnly}";
            label_isSystem.Text = $"IsSystem: {Info.IsSystem}";
        }

        public FileDirInfo(SdCardDirectory Dir, SdCardDirectoryFileInfo Info, Image Ico)
        {
            InitializeComponent();
            pictureBox_ico.Image = Ico;
            label_name.Text = Info.Name;
            label_type.Text = $"Тип: папка";
            label_size.Text = "Размер: --";
            label_path.Text = $"Путь к папке: {Dir.DirectoryPath}";
            label_created.Text = $"Создана: {Info.CreationTime.ToString("g")}";
            label_hash.Text = "CRC32: --";
            label_isHidden.Text = $"IsHidden: {Info.IsHidden}";
            label_isLfn.Text = $"IsLFN: {Info.IsLFN}";
            label_isRO.Text = $"IsReadOnly: {Info.IsReadOnly}";
            label_isSystem.Text = $"IsSystem: {Info.IsSystem}";
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
