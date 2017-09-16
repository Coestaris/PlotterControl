/*=================================\
* ArduinoFileBrowser\MainForm.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:41
* Last Edited: 16.09.2017 14:01:46
*=================================*/

using CnC_WFA;
using CWA.DTP;
using FileBrowser.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TsudaKageyu;

namespace FileBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string portName = "COM9";
        private Sender Sender = new Sender("Coestar");
        private SerialPort port;
        private Bitmap folderImage;
        private Bitmap backImage;
        private Bitmap forwardImage;
        private DTPMaster Master;
        private List<string> CurrentPath = new List<string>();

        public static float ParseSize(string size)
        {
            var data = size.Split(' ');
            if (!float.TryParse(data[0], out float res)) return 0;
            return res * (data[1] == "B" ? 1f :
                          data[1] == "Kb" ? 1024f :
                          data[1] == "Mb" ? 1048576f :
                          1073741824f);
        }

        public static string ProccedSize(int size)
        {
            if (size < 1024) return size.ToString() + " B";
            else if (size < 1048576f) return (size / 1024f).ToString() + " Kb";
            else if (size < 1073741824f) return (size / 1048576f).ToString() + " Mb";
            else return (size / 1073741824f).ToString() + " Gb";
        }

        private void TrySetupFolder()
        {
            try
            {
                SetupFolder();
            }
            catch (WrongPacketInputException ex)
            {
                if (System.Windows.Forms.MessageBox.Show(
                            string.Format("Невозможно получить данные. Произошла ошибка типа WrongPacketInputException (причина {0}), это может означать что устройство работает не коректно и не грамотно обрабатывает входящие и исходящие пакеты. Попробуйте перезагрузить его и нажать \"Повтор\"", ex.Type.ToString()), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    TrySetupFolder();
                else listView1.Items.Clear();
            }
            catch (Exception ex)
            {
                if (System.Windows.Forms.MessageBox.Show(
                          string.Format("Невозможно получить данные. Произошла ошибка типа {0}, нажмите \"Повтор\" для повторной попытки. Стек вызовов:\n{1}", ex.GetType().FullName, ex.StackTrace), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    TrySetupFolder();
                else listView1.Items.Clear();
            }
        }

        private void RecalcColumnHeaderWidth()
        {
            float totalWidth = Width;
            float[] WidthCoof =
            {
                .4f,
                .2f,
                .2f,
                .2f
            };
            for (int i = 0; i < listView1.Columns.Count; i++)
                listView1.Columns[i].Width = (int)(totalWidth * WidthCoof[i]);
        }
        
        private void SetupFolder()
        {
            string Path = string.Join("", CurrentPath);
            label_path.Text = "Device:\\" + Path.Replace('/', '\\');
            listView1.Items.Clear();
            var ResultFiles = Master.CreateDirectoryHandler(Path).SubFiles;
            var ResultDirs = Master.CreateDirectoryHandler(Path).SubDirectroies;
            if (Path != "/") listView1.Items.Add(new ListViewItem(new string[] { "...", "", "", "" }, ResultFiles.Length + 1));
            foreach (var a in ResultDirs)
            {
                var res = Master.CreateDirectoryHandler(Path == "/" ? a.DirectoryPath : Path + '/' + a.DirectoryPath).DirectoryInfo;
                string flagString = string.Format("{0}{1}{2}{3}", res.IsSystem ? 's' : '-', res.IsHidden ? 'h' : '-', res.IsLFN ? 'l' : '-', res.IsReadOnly ? 'r' : '-');
                ListViewItem item = new ListViewItem(new string[] { '[' + a.DirectoryPath + ']', "<folder>", res.CreationTime.ToString(), flagString }, ResultFiles.Length);
                listView1.Items.Add(item);
            }
            ImageList il = new ImageList();
            listView1.SmallImageList?.Images.Clear();
            foreach (var a in ResultFiles)
            {
                il.Images.Add(IconManager.FindIconForFilename(a.FilePath, false));
                var res = Master.CreateFileHandler(Path == "/" ? a.FilePath : Path + '/' + a.FilePath).FileInfo;

                string flagString = string.Format("{0}{1}{2}{3}", res.IsSystem ? 's' : '-', res.IsHidden ? 'h' : '-', res.IsLFN ? 'l' : '-', res.IsReadOnly ? 'r' : '-');

                ListViewItem item = new ListViewItem(new string[] { a.FilePath, ProccedSize(res.FileDirectorySize), res.CreationTime.ToString(), flagString }, il.Images.Count - 1);
                listView1.Items.Add(item);
            }
            il.Images.Add(folderImage);
            il.Images.Add(backImage);
            il.Images.Add(forwardImage);
            il.Images.Add(emptyImage);
            listView1.SmallImageList = il;
            listView1.ListViewItemSorter = new ListViewComparer(lastColumn, lastOrder);
            listView1.Sort();

            listView1.Columns[lastColumn].ImageIndex = listView1.SmallImageList.Images.Count - (lastOrder == SortOrder.Descending ? 2 : 3);
        }

        private void GetData()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader() {Text = "Name"},
                new ColumnHeader() {Text = "Size" },
                new ColumnHeader() {Text = "Creation Date" },
                new ColumnHeader() {Text = "Flags" }
            });
            CurrentPath = new List<string>() { "/" };
            SetupFolder();
            RecalcColumnHeaderWidth();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            string DllName = "Lib\\FileBrowserResources.dll";

            if (!File.Exists(DllName))
                throw new DllNotFoundException($"Dll {DllName} not found");

            var ie = new IconExtractor(DllName);

            backImage = ie.GetIcon(0).ToBitmap();
            forwardImage = ie.GetIcon(1).ToBitmap();
            folderImage = ie.GetIcon(2).ToBitmap();

            emptyImage = new Bitmap(5, 5);

            //folderImage = new Bitmap("Icons\\folder.png");
            //backImage = new Bitmap("Icons\\back.png");
            //forwardImage = new Bitmap("Icons\\forward.png");

            MainForm_SizeChanged(null, null);
            try
            {
                port?.Close();
                port = new SerialPort(portName, 115200);
                Master = new DTPMaster(new SerialPacketReader(port, 4000), new SerialPacketWriter(port));
                Master.Device.SyncTyme();

            }
            catch (WrongPacketInputException ex)
            {
                if (System.Windows.Forms.MessageBox.Show(
                    string.Format("Невозможно получить данные. Произошла ошибка типа WrongPacketInputException (причина {0}. Сообщение: {1}), это может означать что устройство работает не коректно и не грамотно обрабатывает входящие и исходящие пакеты. Попробуйте перезагрузить его и нажать \"Повтор\"", ex.Type.ToString(), ex.Message), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    MainFormLoad(null, null);
                else
                {
                    Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                if (System.Windows.Forms.MessageBox.Show(
                    string.Format("Произошла ошибка типа {0}.\n{2}\n\nНажмите \"Повтор\" для повторной попытки. Стек вызовов:\n{1}", ex.GetType().FullName, ex.StackTrace, ex.Message), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    MainFormLoad(null, null);
                else
                {
                    Close();
                    return;
                }
            }

            try
            {
                GetData();
            }
            catch (WrongPacketInputException ex)
            {
                if (System.Windows.Forms.MessageBox.Show(
                   string.Format("Невозможно получить данные. Произошла ошибка типа WrongPacketInputException (причина {0}. Сообщение: {1}), это может означать что устройство работает не коректно и не грамотно обрабатывает входящие и исходящие пакеты. Попробуйте перезагрузить его и нажать \"Повтор\"", ex.Type.ToString(), ex.Message), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    MainFormLoad(null, null);
                else
                {
                    Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                if (System.Windows.Forms.MessageBox.Show(
                    string.Format("Невозможно получить данные.\n{2}\n\nПроизошла ошибка типа {0}, нажмите \"Повтор\" для повторной попытки. Стек вызовов:\n{1}", ex.GetType().FullName, ex.StackTrace, ex.Message), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    MainFormLoad(null, null);
                else
                {
                    Close();
                    return;
                }
            }
        }

        static internal InfoType SystemFileName(string fileName, bool proceed, string newPath)
        {
            if (fileName.EndsWith("config.cfg"))
            {
                if (proceed)
                    new SomeFileInfo(InfoType.Config, newPath).ShowDialog();
                return InfoType.Config;
            }
            else if (fileName.EndsWith("ctable.cfg"))
            {
                if (proceed)
                    new SomeFileInfo(InfoType.CTable, newPath).ShowDialog();
                return InfoType.CTable;
            }
            else if (fileName.EndsWith("pens.cfg"))
            {
                if (proceed)
                    new SomeFileInfo(InfoType.Pens, newPath).ShowDialog();
                return InfoType.Pens;
            }
            else if (fileName.EndsWith(".m"))
            {
                if (proceed)
                    new SomeFileInfo(InfoType.VMeta, newPath).ShowDialog();
                return InfoType.VMeta;
            }
            else if (fileName.EndsWith(".p"))
            {
                if (proceed)
                {
                    if (File.Exists(newPath + ".png"))
                        File.Delete(newPath + ".png");
                    File.Move(newPath, newPath + ".png");
                    System.Diagnostics.Process.Start(newPath + ".png");
                }
                return InfoType.Image;
            }
            else if (fileName.EndsWith(".v"))
            {
                if (proceed)
                    new SomeFileInfo(InfoType.VData, newPath).ShowDialog();
                return InfoType.VData;
            }
            else if (fileName.EndsWith(".flv"))
            {
                if (proceed)
                    new SomeFileInfo(InfoType.FLVData, newPath).ShowDialog();
                return InfoType.FLVData;
            }
            else
                if (proceed) System.Diagnostics.Process.Start(newPath);
            return InfoType.Unknown;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1 && (e == null || e.Button == MouseButtons.Left))
            {
                if (listView1.SelectedItems[0].SubItems[1].Text != "<folder>")
                    if (listView1.SelectedIndices[0] == 0 && listView1.SelectedItems[0].SubItems[0].Text == "...")
                    {
                        CurrentPath.RemoveAt(CurrentPath.Count - 1);
                        TrySetupFolder();
                    }
                    else
                    {
                        if (!Directory.Exists("Temp"))
                            Directory.CreateDirectory("Temp");

                        string path = string.Join("", CurrentPath);
                        string newPath = new FileInfo(System.Windows.Forms.Application.ExecutablePath).Directory.FullName + "\\Temp\\" + listView1.SelectedItems[0].SubItems[0].Text;
                        string fileName = path + (path != "/" ? "/" : "") + listView1.SelectedItems[0].SubItems[0].Text;
                        var fileInfo = Master.CreateFileHandler(fileName);
                        if (SystemFileName(fileInfo.FileName, false, "") != InfoType.Unknown)
                        {
                            var res = System.Windows.Forms.MessageBox.Show("Предполагаемо, этот файл - системный. Хотите открыть его встроенным просмотрщиком?", "Передача", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                if (new ReceiveDialog(Master, fileName, newPath).ShowDialog() == DialogResult.OK)
                                    SystemFileName(fileName, true, newPath);
                            }
                            else if (res == DialogResult.No)
                            {
                                HandleLocalFile(newPath, fileName);
                            }
                   
                        }
                        else
                        {
                            if (System.Windows.Forms.MessageBox.Show("Вы хотите передать файл на ПК и просмотреть его?", "Передача", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                                return;
                            HandleLocalFile(newPath, fileName);
                        }
                    }
                else
                {
                    string path = listView1.SelectedItems[0].SubItems[0].Text.Trim('[', ']');
                    CurrentPath.Add(CurrentPath.Last().EndsWith("/") ? path : '/' + path);
                    TrySetupFolder();
                }
            }
        }

        private void HandleLocalFile(string newPath, string fileName)
        {
            var locHash = CrCHandler.CRC32(newPath);
            if (new ReceiveDialog(Master, fileName, newPath).ShowDialog() == DialogResult.OK)
            {
                var res = System.Diagnostics.Process.Start(newPath);
                res.WaitForExit();
                if (CrCHandler.CRC32(newPath) != locHash)
                    if (System.Windows.Forms.MessageBox.Show("Файл был изменен. Хотите отправить его на устройство?", "Передача", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        new SendDialog(Master, newPath, fileName).ShowDialog();
                        TrySetupFolder();
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var a = new ReceiveDialog(Master);
                string path = string.Join("", CurrentPath);
                a.textBox_deviceName.Text = path + (path != "/" ? "/" : "") + listView1.SelectedItems[0].SubItems[0].Text;
                a.ShowDialog();
            }
            else new ReceiveDialog(Master).ShowDialog();
            TrySetupFolder();
        }

        int lastColumn = 0;
        SortOrder lastOrder = SortOrder.Ascending;
        private Bitmap emptyImage;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lastColumn)
            {
                if (lastOrder == SortOrder.Ascending)
                {
                    listView1.Columns[lastColumn].ImageIndex = listView1.SmallImageList.Images.Count - 2;
                    lastOrder = SortOrder.Descending;
                }
                else
                {
                    listView1.Columns[lastColumn].ImageIndex = listView1.SmallImageList.Images.Count - 3;
                    lastOrder = SortOrder.Ascending;
                }
                listView1.ListViewItemSorter = new ListViewComparer(e.Column, lastOrder);
            }
            else
            {
                listView1.Columns[lastColumn].ImageIndex = listView1.SmallImageList.Images.Count - 1;
                listView1.Columns[e.Column].ImageIndex = listView1.SmallImageList.Images.Count - 3;
                lastOrder = SortOrder.Ascending;
                listView1.ListViewItemSorter = new ListViewComparer(e.Column, SortOrder.Ascending);
            }
            listView1.Sort();
            lastColumn = e.Column;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            listView1.Width = Width - 40;
            listView1.Height = Height - 90;

            button_info.Left = Width - 365;
            button_refresh.Left = Width - 283;
            button_send.Left = Width - 202;
            button_rec.Left = Width - 112;

            RecalcColumnHeaderWidth();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string path = string.Join("", CurrentPath);
                System.Windows.Forms.Clipboard.SetText(path + (path != "/" ? "/" : "") + listView1.SelectedItems[0].SubItems[0].Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new SendDialog(Master).ShowDialog();
            TrySetupFolder();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrySetupFolder();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string path = string.Join("", CurrentPath);
                if (listView1.SelectedItems[0].SubItems[1].Text != "<folder>")
                {
                    var a = Master.CreateFileHandler(path + (path != "/" ? "/" : "") + listView1.SelectedItems[0].SubItems[0].Text);
                    try
                    {
                        a.Delete();
                        TrySetupFolder();
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Can`t delete File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var a = Master.CreateDirectoryHandler(path + (path != "/" ? "/" : "") + listView1.SelectedItems[0].SubItems[0].Text.Trim('[', ']'));
                    try
                    {
                        a.Delete(true);
                        TrySetupFolder();
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Can`t delete Dir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else System.Windows.Forms.MessageBox.Show("Select File or Dir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo HI = listView1.HitTest(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                if (HI.Location == ListViewHitTestLocations.None)
                    contextMenuStrip2.Show(Cursor.Position);
                else contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1_MouseDoubleClick(null, null);
        }

        private void createDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = new EnterNameDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                string path = string.Join("", CurrentPath);
                var dir = Master.CreateDirectoryHandler(path + (path != "/" ? "/" : "") + d.Value);
                try
                {
                    dir.Create(false);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Unable to create dir" + dir.DirectoryPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                TrySetupFolder();
            }
        }

        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = new EnterNameDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                string path = string.Join("", CurrentPath);
                var file = Master.CreateFileHandler(path + (path != "/" ? "/" : "") + d.Value);
                try
                {
                    file.Create();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Unable to create file" + file.FilePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                TrySetupFolder();
            }
        }

        private void button_info_Click(object sender, EventArgs e)
        {
            new Form_DeviceInfo(Master).ShowDialog();
        }

        private void toolStripMenuItem1_prop_Click(object sender, EventArgs e)
        {
            string path = string.Join("", CurrentPath);
            try
            {
                if (listView1.SelectedItems[0].SubItems[1].Text != "<folder>")
                {
                    var a = Master.CreateFileHandler(path + (path != "/" ? "/" : "") + listView1.SelectedItems[0].SubItems[0].Text);
                    a.Open(false);
                    new FileDirInfo(a, a.FileInfo, a.CRC32, listView1.SmallImageList.Images[listView1.SelectedIndices[0]]).ShowDialog();
                    a.Close();
                } else
                {
                    var a = Master.CreateDirectoryHandler(path + (path != "/" ? "/" : "") + listView1.SelectedItems[0].SubItems[0].Text.Trim('[', ']'));
                    new FileDirInfo(a, a.DirectoryInfo, listView1.SmallImageList.Images[listView1.SmallImageList.Images.Count - 4]).ShowDialog();
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Произошла ошибка типа {0}.\n{2}\n\nСтек вызовов:\n{1}", ex.GetType().FullName, ex.StackTrace, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
            }
        }
    }

    class ListViewComparer : IComparer
    {
        private int col;
        private SortOrder order;

        public ListViewComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }

        public ListViewComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }

        public int Compare(object x, object y)
        {
            ListViewItem xI = (ListViewItem)x;
            ListViewItem yI = (ListViewItem)y;
            int returnVal = -1;
            if (col == 0)
            {
                if (xI.SubItems[1].Text.StartsWith("<") || yI.SubItems[1].Text.StartsWith("<")) return 0;
                if (xI.SubItems[0].Text == "..." || yI.SubItems[0].Text == "...") return 0;
                returnVal = String.Compare(xI.SubItems[col].Text, yI.SubItems[col].Text);
            }
            else if (col == 1)
            {
                if (xI.SubItems[1].Text.StartsWith("<") || yI.SubItems[1].Text.StartsWith("<")) return 0;
                if (xI.SubItems[0].Text == "..." || yI.SubItems[0].Text == "...") return 0;
                float xVal = MainForm.ParseSize(xI.SubItems[col].Text);
                float yVal = MainForm.ParseSize(yI.SubItems[col].Text);
                returnVal = Comparer.Default.Compare(xVal, yVal);
            }
            else if (col == 2)
            {
                if (xI.SubItems[0].Text == "..." || yI.SubItems[0].Text == "...") return 0;
                if (xI.SubItems[1].Text.StartsWith("<") || yI.SubItems[1].Text.StartsWith("<")) return 0;
                DateTime xVal = DateTime.Parse(xI.SubItems[col].Text);
                DateTime yVal = DateTime.Parse(yI.SubItems[col].Text);
                returnVal = DateTime.Compare(xVal, yVal);
            }
            if (order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }
    }
    
    /// <summary>
    /// Internals are mostly from here: http://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using
    /// Caches all results.
    /// </summary>
    public static class IconManager
    {
        private static readonly Dictionary<string, Icon> _smallIconCache = new Dictionary<string, Icon>();
        private static readonly Dictionary<string, Icon> _largeIconCache = new Dictionary<string, Icon>();
        /// <summary>
        /// Get an icon for a given filename
        /// </summary>
        /// <param name="fileName">any filename</param>
        /// <param name="large">16x16 or 32x32 icon</param>
        /// <returns>null if path is null, otherwise - an icon</returns>
        public static Icon FindIconForFilename(string fileName, bool large)
        {
            var extension = Path.GetExtension(fileName);
            if (extension == null)
                return null;
            var cache = large ? _largeIconCache : _smallIconCache;
            Icon icon;
            if (cache.TryGetValue(extension, out icon))
                return icon;
            icon = IconReader.GetFileIcon(fileName, large ? IconReader.IconSize.Large : IconReader.IconSize.Small, false);
            cache.Add(extension, icon);
            return icon;
        }
        /// <summary>
        /// http://stackoverflow.com/a/6580799/1943849
        /// </summary>
        static ImageSource ToImageSource(this Icon icon)
        {
            var imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return imageSource;
        }
        /// <summary>
        /// Provides static methods to read system icons for both folders and files.
        /// </summary>
        /// <example>
        /// <code>IconReader.GetFileIcon("c:\\general.xls");</code>
        /// </example>
        static class IconReader
        {
            /// <summary>
            /// Options to specify the size of icons to return.
            /// </summary>
            public enum IconSize
            {
                /// <summary>
                /// Specify large icon - 32 pixels by 32 pixels.
                /// </summary>
                Large = 0,
                /// <summary>
                /// Specify small icon - 16 pixels by 16 pixels.
                /// </summary>
                Small = 1
            }
            /// <summary>
            /// Returns an icon for a given file - indicated by the name parameter.
            /// </summary>
            /// <param name="name">Pathname for file.</param>
            /// <param name="size">Large or small</param>
            /// <param name="linkOverlay">Whether to include the link icon</param>
            /// <returns>System.Drawing.Icon</returns>
            public static Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
            {
                var shfi = new Shell32.Shfileinfo();
                var flags = Shell32.ShgfiIcon | Shell32.ShgfiUsefileattributes;
                if (linkOverlay) flags += Shell32.ShgfiLinkoverlay;
                /* Check the size specified for return. */
                if (IconSize.Small == size)
                    flags += Shell32.ShgfiSmallicon;
                else
                    flags += Shell32.ShgfiLargeicon;
                Shell32.SHGetFileInfo(name,
                    Shell32.FileAttributeNormal,
                    ref shfi,
                    (uint)Marshal.SizeOf(shfi),
                    flags);
                // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
                var icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                User32.DestroyIcon(shfi.hIcon);     // Cleanup
                return icon;
            }
        }
        /// <summary>
        /// Wraps necessary Shell32.dll structures and functions required to retrieve Icon Handles using SHGetFileInfo. Code
        /// courtesy of MSDN Cold Rooster Consulting case study.
        /// </summary>
        static class Shell32
        {
            private const int MaxPath = 256;
            [StructLayout(LayoutKind.Sequential)]
            public struct Shfileinfo
            {
                private const int Namesize = 80;
                public readonly IntPtr hIcon;
                private readonly int iIcon;
                private readonly uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)]
                private readonly string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Namesize)]
                private readonly string szTypeName;
            };
            public const uint ShgfiIcon = 0x000000100;     // get icon
            public const uint ShgfiLinkoverlay = 0x000008000;     // put a link overlay on icon
            public const uint ShgfiLargeicon = 0x000000000;     // get large icon
            public const uint ShgfiSmallicon = 0x000000001;     // get small icon
            public const uint ShgfiUsefileattributes = 0x000000010;     // use passed dwFileAttribute
            public const uint FileAttributeNormal = 0x00000080;
            [DllImport("Shell32.dll")]
            public static extern IntPtr SHGetFileInfo(
                string pszPath,
                uint dwFileAttributes,
                ref Shfileinfo psfi,
                uint cbFileInfo,
                uint uFlags
                );
        }
        /// <summary>
        /// Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
        /// </summary>
        static class User32
        {
            /// <summary>
            /// Provides access to function required to delete handle. This method is used internally
            /// and is not required to be called separately.
            /// </summary>
            /// <param name="hIcon">Pointer to icon handle.</param>
            /// <returns>N/A</returns>
            [DllImport("User32.dll")]
            public static extern int DestroyIcon(IntPtr hIcon);
        }
    }
}
