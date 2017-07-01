/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

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
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

using CWA;
using CWA.Connection;
using CWA.Printing;
using CWA.Vectors.Document;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class MainWindow : Form
    {
        string _configDefport;
        int config_defspeed, config_maxsc, config_maxdis;
        private StartPrintOption config_spo;
        private ReturnBackOption config_rbo;
        private Color[] colors;
        private bool[] configchanged;
        private bool IsConfigChanged;
        private int device_maxw, device_maxh;
        private float device_xmm, device_ymm;
        private bool device_use;
        private string device_path, device_ard;
        private int device_vertCorrection;
        private bool[] devicechanged;
        private bool IsDevicegChanged;
        private Bitmap pb, pd, vb, vd;
        private bool DriverInstalled;
        private DeviceMemorySetup a;
        private string ls7, ls6, ls5, ls4, ls3, ls2, ls1;
        private Form_ManualControl fm;
        private Form_PrintMaster fp;
        private Form_VectorMaster fv;
        private Form_ViewVect fvw;
        private Form_SerialMonitor fs;
        private Form_EditVector fe;
        private Form_Dialog_Assoc fda;
        private Form_CurvePlugins fc;
        private bool config_preload;
        private bool FirstConfigPreloadChange = true;
        private Form_Dialog_Lang fdl;
        private Form_Graph fg;
        private Form_Macro fme;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckChangedDevice()
        {
            IsDevicegChanged = devicechanged.ToList().Find(p => p == true);
            button_device.Text = TranslateBase.CurrentLang.Phrase["MainWindow.DeviceTitle"] + (IsDevicegChanged ? "*" : " ")+ "\n ";
            button_home.Text = TranslateBase.CurrentLang.Phrase["MainWindow.Word.Main"] + (IsConfigChanged ? "*" : " ")+ "       ";
            button_main_device_save.Enabled = IsDevicegChanged;
        }

        private void CheckChanged()
        {
            IsConfigChanged = configchanged.ToList().Find(p => p == true);
            button_config.Text = TranslateBase.CurrentLang.Phrase["MainWindow.OptionsTitle"] +  (IsConfigChanged?"*":" ");
            button_home.Text = TranslateBase.CurrentLang.Phrase["MainWindow.Word.Main"] + (IsConfigChanged ? "*" : "") + "       ";
            button_main_config_save.Enabled = IsConfigChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_home.BackColor = Color.FromArgb(4, 60, 130);
            tabControl_main.SelectedIndex = 0;
            button_print.BackColor = Color.FromArgb(0, 32, 77);
            button_vect.BackColor = Color.FromArgb(0, 32, 77);
            button_help.BackColor = Color.FromArgb(0, 32, 77);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsDevicegChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Device_Discard();
                }
                else return;
            }
            if (IsConfigChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config_Discard();
                }
                else return;
            }
            if (a != null && a.IsWorking)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.CloseConnectionSession"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            button5_Click_2(null, null);
            button_print.BackColor = Color.FromArgb(4, 60, 130);
            button_home.BackColor = Color.FromArgb(0, 32, 77);
            button_vect.BackColor = Color.FromArgb(0, 32, 77);
            button_help.BackColor = Color.FromArgb(0, 32, 77);
            tabControl_main.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsDevicegChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Device_Discard();
                }
                else return;
            }
            if (IsConfigChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config_Discard();
                }
                else return;
            }
            if (a != null && a.IsWorking)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.CloseConnectionSession"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tabControl_main.SelectedIndex = 2;
            button_vect.BackColor = Color.FromArgb(4, 60, 130);
            button_print.BackColor = Color.FromArgb(0, 32, 77);
            button_home.BackColor = Color.FromArgb(0, 32, 77);
            button_help.BackColor = Color.FromArgb(0, 32, 77);
            button_main_vect.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsDevicegChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Device_Discard();
                }
                else return;
            }
            if (IsConfigChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config_Discard();
                }
                else return;
            }
            if (a != null && a.IsWorking)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.CloseConnectionSession"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            button_help.BackColor = Color.FromArgb(4, 60, 130);
            button_print.BackColor = Color.FromArgb(0, 32, 77);
            button_vect.BackColor = Color.FromArgb(0, 32, 77);
            button_home.BackColor = Color.FromArgb(0, 32, 77);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1_Click(null, null);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2_Click(null, null);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3_Click(null, null);
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4_Click(null, null);
        }

        private void Config_Discard()
        {
            comboBox_mainport.Text = _configDefport;
            comboBox_mainrate.Text = config_defspeed.ToString();
            textBox_sh.Text = config_maxsc.ToString();
            textBox_md.Text = config_maxdis.ToString();
            comboBox_peo.Text = config_rbo.ToString();
            comboBox_pso.Text = config_spo.ToString();
            GlobalOptions.DefPrintBack = colors[0];
            GlobalOptions.DefPrintDraw = colors[1];
            GlobalOptions.DefViewBack = colors[2];
            GlobalOptions.DefViewDraw = colors[3];
            FillColors();
            configchanged = new bool[11];
            CheckChanged();
        }
       
        private void Device_Discard()
        {
            textBox_xmm.Text = device_xmm.ToString(CultureInfo.InvariantCulture);
            textBox_ymm.Text = device_ymm.ToString(CultureInfo.InvariantCulture);
            textBox_maxstepheight.Text = device_maxh.ToString();
            textBox_MaxStepWidth.Text = device_maxw.ToString();
            checkBox_usedevicespeed.Checked = GlobalOptions.UseAutoSpeed;
            label_main_device_pathto.Text = TranslateBase.CurrentLang.Phrase["MainWindow.PathToArduino"] + ": " + device_path;
            comboBox_main_device_board.Text = ArduinoBoard.Boards.ToList().Find(p=> p.ProgramName == device_ard).DisplayName;
            devicechanged = new bool[8];
            CheckChangedDevice();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (IsDevicegChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Device_Discard();
                }
                else return;
            }
            if (IsConfigChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config_Discard();
                }
                else return;
            }
            if (a != null && a.IsWorking)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.CloseConnectionSession"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox1.BackColor = Color.FromArgb(4, 60, 130);
            pictureBox2.BackColor = Color.FromArgb(4, 60, 130);
            tabControl_about.SelectedIndex = 2;
            button_about.BackColor = Color.FromArgb(5, 92, 199);
            button_config.BackColor = Color.FromArgb(4, 60, 130);
            button_device.BackColor = Color.FromArgb(4, 60, 130);
            button_memory.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (IsDevicegChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Device_Discard();
                }
                else return;
            }
            if (a != null && a.IsWorking)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.CloseConnectionSession"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            configchanged = new bool[11];
            colors = new Color[4];
            colors[0] = GlobalOptions.DefPrintBack;
            colors[1] = GlobalOptions.DefPrintDraw;
            colors[3] = GlobalOptions.DefViewBack;
            colors[3] = GlobalOptions.DefViewDraw;
            _configDefport = comboBox_mainport.Text;
            config_preload = checkBox_main_config_preload.Checked;
            config_defspeed = int.Parse(comboBox_mainrate.Text);
            config_maxdis = int.Parse(textBox_md.Text);
            config_maxsc = int.Parse(textBox_sh.Text);
            config_rbo = ExOperators.GetEnum<ReturnBackOption>(comboBox_peo.Text);
            config_spo = ExOperators.GetEnum<StartPrintOption>(comboBox_pso.Text);
            pictureBox1.BackColor = Color.FromArgb(4, 60, 130);
            pictureBox2.BackColor = Color.FromArgb(4, 60, 130);
            tabControl_about.SelectedIndex = 1;
            button_config.BackColor = Color.FromArgb(5, 92, 199);
            button_about.BackColor = Color.FromArgb(4, 60, 130);
            button_device.BackColor = Color.FromArgb(4, 60, 130);
            button_memory.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (IsConfigChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config_Discard();
                }
                else return;
            }
            if (a!=null && a.IsWorking)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.CloseConnectionSession"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            devicechanged = new bool[8];
            device_vertCorrection = int.Parse(textBox_main_config_vertCorrection.Text);
            device_ard = GlobalOptions.DefBoard.ToString();
            device_maxh = int.Parse(textBox_maxstepheight.Text);
            device_maxw = int.Parse(textBox_MaxStepWidth.Text);
            device_path = GlobalOptions.PathToArduino;
            device_use = checkBox_usedevicespeed.Checked;
            device_xmm = float.Parse(textBox_xmm.Text, CultureInfo.InvariantCulture);
            device_ymm = float.Parse(textBox_ymm.Text, CultureInfo.InvariantCulture);
            pictureBox1.BackColor = Color.FromArgb(5, 92, 199);
            pictureBox2.BackColor = Color.FromArgb(4, 60, 130);
            tabControl_about.SelectedIndex = 0;
            button_device.BackColor = Color.FromArgb(5, 92, 199);
            button_config.BackColor = Color.FromArgb(4, 60, 130);
            button_about.BackColor = Color.FromArgb(4, 60, 130);
            button_memory.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (IsDevicegChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Device_Discard();
                }
                else return;
            }
            if (IsConfigChanged)
            {
                if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.DontSaveChanges"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config_Discard();
                } else return;
            }
            tabControl_about.SelectedIndex = 3;
            pictureBox2.BackColor = Color.FromArgb(5, 92, 199);
            pictureBox1.BackColor = Color.FromArgb(4, 60, 130);
            button_memory.BackColor = Color.FromArgb(5, 92, 199);
            button_config.BackColor = Color.FromArgb(4, 60, 130);
            button_about.BackColor = Color.FromArgb(4, 60, 130);
            button_device.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void pictureBox_pd_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = GlobalOptions.DefPrintBack;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                GlobalOptions.DefPrintBack = colorDialog1.Color;
                FillColors();
            }
        }

        private void button_pd_Click_1(object sender, EventArgs e)
        {
            colorDialog1.Color = GlobalOptions.DefPrintDraw;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                configchanged[7] = (!CompareColors(colors[1], colorDialog1.Color));
                CheckChanged();
                GlobalOptions.DefPrintDraw = colorDialog1.Color;
                FillColors();
            }
        }

        private void button_vb_Click_1(object sender, EventArgs e)
        {
            colorDialog1.Color = GlobalOptions.DefViewBack;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                configchanged[8] = (!CompareColors(colors[2],colorDialog1.Color));
                GlobalOptions.DefViewBack = colorDialog1.Color;
                CheckChanged();
                FillColors();
            }
        }

        private void button_vd_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = GlobalOptions.DefViewDraw;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                configchanged[9] = (!CompareColors(colors[3], colorDialog1.Color));
                GlobalOptions.DefViewDraw = colorDialog1.Color;
                CheckChanged();
                FillColors();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.OriArduino"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Drivers"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.YouDontNeedToInstallDrivers"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Drivers"], MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                if (Directory.Exists("Driver\\CH341SER"))
                {
                    foreach (var n in Directory.GetFiles("Driver\\CH341SER")) File.Delete(n);
                    Directory.Delete("Driver\\CH341SER");
                }
                var a = ZipFile.Open("Driver\\CH341SER.zip", ZipArchiveMode.Read);
                a.ExtractToDirectory("Driver\\CH341SER");
                ProcessStartInfo info;
                if (Environment.Is64BitOperatingSystem) info = new ProcessStartInfo(@"Driver\install64.bat");
                else info = new ProcessStartInfo(@"Driver\install.bat");
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info).WaitForExit();
                foreach (var n in Directory.GetFiles("Driver\\CH341SER")) File.Delete(n);
                Directory.Delete("Driver\\CH341SER");
            }
        }

        private bool CompareColors(Color a, Color b)
        {
            return a.R == b.R && a.G == b.G && a.B == b.B;
        }

        private void button_pb_Click_1(object sender, EventArgs e)
        {
            colorDialog1.Color = GlobalOptions.DefPrintBack;
            if(colorDialog1.ShowDialog()== DialogResult.OK)
            {
                configchanged[6] = (!CompareColors(colors[0],colorDialog1.Color));
                GlobalOptions.DefPrintBack = colorDialog1.Color;
                CheckChanged();
                FillColors();
            }
        }

        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(comboBox_main_device_port.Text == "")
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.EnterPortName"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(GlobalOptions.PathToArduino + "\\arduino_debug.exe"))
            {
                if (Directory.Exists("Driver\\sketch"))
                {
                    foreach (var n in Directory.GetFiles("Driver\\sketch")) File.Delete(n);
                    Directory.Delete("Driver\\sketch");
                }
                var a = ZipFile.Open("Driver\\sketch.zip", ZipArchiveMode.Read);
                a.ExtractToDirectory("Driver\\sketch");
                File.Move("Driver\\sketch\\sketch", "Driver\\sketch\\sketch.ino");
                CopyFolder("Driver\\sketch", GlobalOptions.PathToArduino+ "\\sketch");
                string gla = "\"{0}\" {1} {2} {3}";
                gla = string.Format(gla, GlobalOptions.PathToArduino, GlobalOptions.DefBoard.ProgramName, comboBox_main_device_port.Text, "sketch\\sketch.ino");
                Process.Start("Driver\\upload.bat", gla).WaitForExit();
                foreach (var n in Directory.GetFiles(GlobalOptions.PathToArduino + "\\sketch")) File.Delete(n);
                Directory.Delete(GlobalOptions.PathToArduino + "\\sketch");
                foreach (var n in Directory.GetFiles("Driver\\sketch")) File.Delete(n);
                Directory.Delete("Driver\\sketch");

            }
            else MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.WasSetWrongPathOrFileNotFound"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           if (MessageBox.Show(TranslateBase.CurrentLang.Message["MainWindow.VisitDeveloperSize"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Process.Start("https://www.arduino.cc/en/Main/Software");
        }

        private void button_main_device_pick_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(folderBrowserDialog1.SelectedPath + "\\arduino_debug.exe"))
                {
                    devicechanged[6] = (folderBrowserDialog1.SelectedPath != device_path);
                    CheckChangedDevice();
                    label_main_device_pathto.Text = TranslateBase.CurrentLang.Phrase["MainWindow.PathToArduino"] +": " + folderBrowserDialog1.SelectedPath;
                    GlobalOptions.PathToArduino = folderBrowserDialog1.SelectedPath;
                    GlobalOptions.Save();
                }
                else MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.WasSetWrongPathOrFileNotFound"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_main_device_port_Click(object sender, EventArgs e)
        {
            comboBox_main_device_port.Items.Clear();
            comboBox_main_device_port.Items.AddRange(SerialPort.GetPortNames());
        }

        private void comboBox_main_device_board_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalOptions.DefBoard = ArduinoBoard.Boards.ToList().Find(p => p.DisplayName == comboBox_main_device_board.Text);
            devicechanged[5] = (GlobalOptions.DefBoard.ProgramName != device_ard);
            CheckChangedDevice();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if(button_main_memory_connect.Text == TranslateBase.CurrentLang.Phrase["MainWindow.Word.Disconnect"])
            {
                timer1.Stop();
                checkBox_main_memory_readonly.Checked = true;
                checkBox1_CheckedChanged(null, null);
                checkBox_main_memory_readonly.Enabled = false;
                button_main_memory_load.Enabled = false;
                button_main_memory_get.Enabled = false;
                checkBox_main_memory_val.Enabled = false;
                button_main_memory_def.Enabled = false;
                checkBox_main_memory_val.Checked = false;
                a.Stop();
                progressBar_main_memory_val.Value = 0;
                label_high.Text = "";
                label_low.Text = "";
                label_val.Text = "";
                button_main_memory_connect.Text = TranslateBase.CurrentLang.Phrase["MainWindow.Word.Connect"];
                checkBox_main_memory_val_CheckedChanged(null, null);
            } else
            if (comboBox_main_memory_ports.Text == "")
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.EnterPortName"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox_main_memory_bd.Text == "")
            {
                MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.EnterBD"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                try
                {
                    a = new DeviceMemorySetup(comboBox_main_memory_ports.Text, int.Parse(comboBox_main_memory_bd.Text));
                    button_get_Click(null, null);
                    timer1.Start();
                    checkBox_main_memory_readonly.Enabled = true;
                    button_main_memory_load.Enabled = true;
                    button_main_memory_get.Enabled = true;
                    button_main_memory_def.Enabled = true;
                    checkBox_main_memory_val.Enabled = true;
                    button_main_memory_connect.Text = TranslateBase.CurrentLang.Phrase["MainWindow.Word.Disconnect"];
                    checkBox_main_memory_val_CheckedChanged(null, null);
                }
                catch(DeviceMemorySetup.MemorySetupBadRespondException g)
                {
                    //TODO: MAKE DAT EXCEPTION!
                }
                catch(DeviceMemorySetup.MemorySetupTimeoutException g)
                {
                    MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.TimeOut"], TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    try { a.Stop(); } catch { };
                    return;
                }
                catch(Exception g)
                {
                    MessageBox.Show(TranslateBase.CurrentLang.Error["MainWindow.ContConnectOrOpenTo"] + comboBox_main_memory_ports.Text + '!', TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void button_get_Click(object p1, object p2)
        {
            Thread.Sleep(1000);
            Cursor = Cursors.WaitCursor;
            timer1.Stop();
            textBox_main_memory_xd.Text = a.XDir.ToString();
            textBox_main_memory_yd.Text = a.YDir.ToString();
            textBox_main_memory_zd.Text = a.ZDir.ToString();
            textBox_main_memory_xs.Text = a.XStep.ToString();
            textBox_main_memory_ys.Text = a.YStep.ToString();
            textBox_main_memory_zs.Text = a.ZStep.ToString();
            textBox_main_memory_idle.Text = a.IdleDelay.ToString();
            textBox_main_memory_work.Text = a.WorkDelay.ToString();
            checkBox_main_memory_com.Checked = a.Com;
            checkBox_main_memory_pause.Checked = a.Pause;
            if(checkBox_main_memory_val.Checked) timer1.Start();
            Cursor = Cursors.Default;
            Thread.Sleep(500);
        }

        private void FillColors()
        {
            string s = TranslateBase.CurrentLang.Phrase["MainWindow.RGB"];
            label_main_config_1.Text = string.Format(s, GlobalOptions.DefViewDraw.R, GlobalOptions.DefViewDraw.G, GlobalOptions.DefViewDraw.B);
            label_main_config_2.Text = string.Format(s, GlobalOptions.DefViewBack.R, GlobalOptions.DefViewBack.G, GlobalOptions.DefViewBack.B);
            label_main_config_3.Text = string.Format(s, GlobalOptions.DefPrintDraw.R, GlobalOptions.DefPrintDraw.G, GlobalOptions.DefPrintDraw.B);
            label_main_config_4.Text = string.Format(s, GlobalOptions.DefPrintBack.R, GlobalOptions.DefPrintBack.G, GlobalOptions.DefPrintBack.B);
            Rectangle rect = new Rectangle(0, 0, pb.Width, pb.Height);
            using (Graphics gr = Graphics.FromImage(pb)) gr.FillRectangle(new SolidBrush(GlobalOptions.DefPrintBack), rect);
            using (Graphics gr = Graphics.FromImage(pd)) gr.FillRectangle(new SolidBrush(GlobalOptions.DefPrintDraw), rect);
            using (Graphics gr = Graphics.FromImage(vb)) gr.FillRectangle(new SolidBrush(GlobalOptions.DefViewBack), rect);
            using (Graphics gr = Graphics.FromImage(vd)) gr.FillRectangle(new SolidBrush(GlobalOptions.DefViewDraw), rect);
            pictureBox_pb.Image = pb;
            pictureBox_pd.Image = pd;
            pictureBox_vb.Image = vb;
            pictureBox_vd.Image = vd;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int d = a.Speed;
            if (d > progressBar_main_memory_val.Maximum)
            {
                progressBar_main_memory_val.Maximum = d;
                label_high.Text = d.ToString();
            }
            int l_idle = (int)(d * 0.10 + 10);
            int l_work = (int)(d * 0.14 + 20);
            label_val.Text = string.Format(TranslateBase.CurrentLang.Phrase["MainWindow.IdleAndWorkDelays"], d, l_idle, l_work);
            progressBar_main_memory_val.Value = d;
        }

        private void textBox_sh_TextChanged(object sender, EventArgs e)
        {
            var a = 0;
            var g = textBox_sh;
            string s = g.Text;
            if (s != "" && !int.TryParse(s, out a))
            {
                MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["MainWindow.WrongNumber"], s), TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                g.Text = ls1;
                return;
            }
            if (s == "") return;
            configchanged[2] = (int.Parse(s) != config_maxsc);
            CheckChanged();
            ls1 = s;
        }

        private void textBox_md_TextChanged(object sender, EventArgs e)
        {
            var a = 0;
            var g = textBox_md;
            string s = g.Text;
            if (s != "" && !int.TryParse(s, out a))
            {
                MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["MainWindow.WrongNumber"], s), TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                g.Text = ls2;
                return;
            }
            if (s == "") return;
            configchanged[3] = (int.Parse(s) != config_maxdis);
            CheckChanged();
            ls2 = s;
        }

        private void textBox_maxstepheight_TextChanged(object sender, EventArgs e)
        {
            var a = 0;
            var g = textBox_maxstepheight;
            string s = g.Text;
            if (s != "" && !int.TryParse(s, out a))
            {
                MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["MainWindow.WrongNumber"], s), TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                g.Text = ls3;
                return;
            }
            if (s == "") return;
            devicechanged[0] = (int.Parse(s) != device_maxh);
            CheckChangedDevice();
            ls3 = s;
        }

        private void button_main_device_save_Click(object sender, EventArgs e)
        {
            GlobalOptions.UpKoof = int.Parse(textBox_main_config_vertCorrection.Text);
            GlobalOptions.Mainbd = int.Parse(comboBox_mainrate.Text);
            GlobalOptions.Mainport = comboBox_mainport.Text;
            GlobalOptions.XMM = float.Parse(textBox_xmm.Text, CultureInfo.InvariantCulture);
            GlobalOptions.YMM = float.Parse(textBox_ymm.Text, CultureInfo.InvariantCulture);
            GlobalOptions.UseAutoSpeed = checkBox_usedevicespeed.Checked;
            IsDevicegChanged = false;
            button7_Click(null, null);
            CheckChangedDevice();
            GlobalOptions.Save();
        }

        private void button_main_config_save_Click(object sender, EventArgs e)
        {
            GlobalOptions.Mainbd = int.Parse(comboBox_mainrate.Text);
            GlobalOptions.Mainport = comboBox_mainport.Text;
            GlobalOptions.MaxDisConst = int.Parse(textBox_md.Text);
            GlobalOptions.StepHeightConst = int.Parse(textBox_sh.Text);
            GlobalOptions.PreloadPlugins = checkBox_main_config_preload.Checked;
            GlobalOptions.DefRbo = ExOperators.GetEnum<ReturnBackOption>(comboBox_peo.Text);
            GlobalOptions.DefSpo = ExOperators.GetEnum<StartPrintOption>(comboBox_pso.Text);
            GlobalOptions.Save();
            IsConfigChanged = false;
            button6_Click_1(null, null);
            CheckChanged();
        }

        private void button_main_config_def_Click(object sender, EventArgs e)
        {
            GlobalOptions.StepHeightConst = 2000;
            GlobalOptions.MaxDisConst = 100;
            GlobalOptions.Mainbd = 115200;
            GlobalOptions.Mainport = "COM0";
            GlobalOptions.DefPrintBack = Color.White;
            GlobalOptions.DefPrintDraw = Color.Black;
            GlobalOptions.DefViewBack = Color.Black;
            GlobalOptions.DefViewDraw = Color.White;
            GlobalOptions.DefRbo = ReturnBackOption.ReturnToZero;
            GlobalOptions.DefSpo = StartPrintOption.None;
            textBox_sh.Text = GlobalOptions.StepHeightConst.ToString();
            textBox_md.Text = GlobalOptions.MaxDisConst.ToString();
            comboBox_mainrate.Text = GlobalOptions.Mainbd.ToString();
            comboBox_mainport.Text = GlobalOptions.Mainport.ToString();
            comboBox_peo.Text = GlobalOptions.DefRbo.ToString();
            comboBox_pso.Text = GlobalOptions.DefSpo.ToString();
            FillColors();
            CheckChanged();
        }

        private void checkBox_usedevicespeed_CheckedChanged(object sender, EventArgs e)
        {
            devicechanged[4] = (checkBox_usedevicespeed.Checked != device_use);
            CheckChangedDevice();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GlobalOptions.PathToArduino = "";
            GlobalOptions.XMM = 0.013f;
            GlobalOptions.YMM = 0.013f;
            GlobalOptions.DefBoard = ArduinoBoard.Boards.ToList().Find(p => p.ProgramName == "arduino:avr:mega");
            GlobalOptions.StepHeightConst = 2000;
            GlobalOptions.MaxDisConst = 100;
            GlobalOptions.UseAutoSpeed = false;
            textBox_xmm.Text = GlobalOptions.XMM.ToString(CultureInfo.InvariantCulture);
            textBox_ymm.Text = GlobalOptions.YMM.ToString(CultureInfo.InvariantCulture);
            checkBox_usedevicespeed.Checked = GlobalOptions.UseAutoSpeed;
            textBox_MaxStepWidth.Text = GlobalOptions.MaxWidthSteps.ToString();
            textBox_maxstepheight.Text = GlobalOptions.MaxHeightSteps.ToString();
            label_main_device_pathto.Text = TranslateBase.CurrentLang.Error["MainWindow.PathToArduino"] +" :"+ GlobalOptions.PathToArduino;
            comboBox_main_device_board.Text = GlobalOptions.DefBoard.DisplayName;
            CheckChangedDevice();
        }

        private void button_main_device_help_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Перейти на локальную страницу справки в веб-браузере?", TranslateBase.CurrentLang.Phrase["MainWindow.Word.GoAway"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Process.Start("HTML Help\\Home.html");
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            tabControl_print_manual.SelectedIndex = 0;
            button_main_print.BackColor = Color.FromArgb(5, 92, 199);
            button_main_macro.BackColor = Color.FromArgb(4, 60, 130);
            button_main_ser.BackColor = Color.FromArgb(4, 60, 130);
            button_main_manual.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            tabControl_print_manual.SelectedIndex = 2;
            button_main_ser.BackColor = Color.FromArgb(5, 92, 199);
            button_main_print.BackColor = Color.FromArgb(4, 60, 130);
            button_main_macro.BackColor = Color.FromArgb(4, 60, 130);
            button_main_manual.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabControl_print_manual.SelectedIndex = 3;
            button_main_manual.BackColor = Color.FromArgb(5, 92, 199);
            button_main_print.BackColor = Color.FromArgb(4, 60, 130);
            button_main_macro.BackColor = Color.FromArgb(4, 60, 130);
            button_main_ser.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void comboBox_main_memory_ports_Click(object sender, EventArgs e)
        {
            comboBox_main_memory_ports.Items.Clear();
            comboBox_main_memory_ports.Items.AddRange(SerialPort.GetPortNames());
        }

        private void button_main_macro_Click(object sender, EventArgs e)
        {
            tabControl_print_manual.SelectedIndex = 1;
            button_main_macro.BackColor = Color.FromArgb(5, 92, 199);
            button_main_print.BackColor = Color.FromArgb(4, 60, 130);
            button_main_ser.BackColor = Color.FromArgb(4, 60, 130);
            button_main_manual.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            if (fs == null) fs = new Form_SerialMonitor();
            if (!fs.Visible) { fs = FormTranslator.Translate(new Form_SerialMonitor()); fs.Show(); }
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            if (fp == null) fp = new Form_PrintMaster();
            if (!fp.Visible) { fp = new Form_PrintMaster(); fp.Show(); }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if (fm == null) fm = new Form_ManualControl();
            if (!fm.Visible) { fm = FormTranslator.Translate(new Form_ManualControl()); fm.Show(); }
        }

        private void button_main_vect_Click(object sender, EventArgs e)
        {
            tabControl_vect.SelectedIndex = 0;
            button_main_graph.BackColor = Color.FromArgb(4, 60, 130);
            button_main_other.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vect.BackColor = Color.FromArgb(5, 92, 199);
            button_main_vectview.BackColor = Color.FromArgb(4, 60, 130);
            button_main_editor.BackColor = Color.FromArgb(4, 60, 130);
            button_main_curve.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_main_vectview_Click(object sender, EventArgs e)
        {
            tabControl_vect.SelectedIndex = 1;
            button_main_graph.BackColor = Color.FromArgb(4, 60, 130);
            button_main_other.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vectview.BackColor = Color.FromArgb(5, 92, 199);
            button_main_vect.BackColor = Color.FromArgb(4, 60, 130);
            button_main_editor.BackColor = Color.FromArgb(4, 60, 130);
            button_main_curve.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_main_editor_Click(object sender, EventArgs e)
        {
            tabControl_vect.SelectedIndex = 2;
            button_main_graph.BackColor = Color.FromArgb(4, 60, 130);
            button_main_other.BackColor = Color.FromArgb(4, 60, 130);
            button_main_editor.BackColor = Color.FromArgb(5, 92, 199);
            button_main_vectview.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vect.BackColor = Color.FromArgb(4, 60, 130);
            button_main_curve.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            if (fv == null) fv = new Form_VectorMaster();
            if (!fv.Visible) { fv = FormTranslator.Translate(new Form_VectorMaster()); fv.Show(); } else fv.Focus();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (fvw == null) fvw = new Form_ViewVect();
            if (!fvw.Visible) { fvw = FormTranslator.Translate(new Form_ViewVect()); fvw.Show(); }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (fe == null) fe = new Form_EditVector();
            if (!fe.Visible) { fe = new Form_EditVector(); fe.Show(); }
        }

        private void button_main_curve_Click(object sender, EventArgs e)
        {
            button_main_graph.BackColor = Color.FromArgb(4, 60, 130);
            button_main_other.BackColor = Color.FromArgb(4, 60, 130);
            tabControl_vect.SelectedIndex = 3;
            button_main_curve.BackColor = Color.FromArgb(5, 92, 199);
            button_main_vectview.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vect.BackColor = Color.FromArgb(4, 60, 130);
            button_main_editor.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_vect_curve_start_Click(object sender, EventArgs e)
        {
            if (fc == null) fc = new Form_CurvePlugins();
            if (!fc.Visible) { fc = new Form_CurvePlugins(); fc.Show(); }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int count = Directory.GetFiles(CurvePluginHandler.PluginDir + "Compiled\\").Length;
            if (MessageBox.Show("Кэш служит для ускорения загрузки плагинов, при его удалении программа будет вынуждена повторно их обработать.\nВы действительно хотите удалить "+ count + " кэшированных (скомпилированных) плагинов?", "Подверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if(fc != null && fc.Visible) { MessageBox.Show("Для этого необходимо закрыть мастер кривых", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if(GlobalOptions.PreloadPlugins) { MessageBox.Show("Невозможно очистить кэш, когда включена функция предварительной загрузки плагинов. Отключите ее и перезагрузите прогамму", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                List<string> cantDelete = new List<string>();

                foreach(var a in Directory.GetFiles(CurvePluginHandler.PluginDir + "Compiled\\"))
                {
                    try { File.Delete(a); } catch { cantDelete.Add(a); }
                }
                if (cantDelete.Count != 0) MessageBox.Show(string.Format("Успешно удалено {0} элементов\nНевозможно удалить следующии ({1}):\n{2}", count - cantDelete.Count, cantDelete.Count, string.Join("\n  -", cantDelete)),"Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(string.Format("Успешно удалено {0} элементов", count), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox_main_config_vertCorrection_TextChanged(object sender, EventArgs e)
        {
            var a = 0;
            var g = textBox_main_config_vertCorrection;
            string s = g.Text;
            if (s != "" && !int.TryParse(s, out a))
            {
                MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["MainWindow.WrongNumber"], s), TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                g.Text = ls7;
                return;
            }
            if (s == "") return;
            devicechanged[7] = (int.Parse(s) != device_vertCorrection);
            CheckChangedDevice();
            ls7 = s;
        }

        private void checkBox_main_config_preload_CheckedChanged(object sender, EventArgs e)
        {
            if (FirstConfigPreloadChange) FirstConfigPreloadChange = false;
            else
            {
                MessageBox.Show("Необходимо перезапустить программу для того, чтобы изменения вступили в силу", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                configchanged[10] = (config_preload != checkBox_main_config_preload.Checked);
                CheckChanged();
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (FileAssociation.CanWriteRegistry) Text += '*';
        }

        private void button_main_graph_Click(object sender, EventArgs e)
        {
            tabControl_vect.SelectedIndex = 4;
            button_main_graph.BackColor  = Color.FromArgb(5, 92, 199);
            button_main_other.BackColor = Color.FromArgb(4, 60, 130);
            button_main_curve.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vectview.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vect.BackColor = Color.FromArgb(4, 60, 130);
            button_main_editor.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_main_other_Click(object sender, EventArgs e)
        {
            tabControl_vect.SelectedIndex = 5;
            button_main_graph.BackColor = Color.FromArgb(4, 60, 130);
            button_main_other.BackColor = Color.FromArgb(5, 92, 199);
            button_main_curve.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vectview.BackColor = Color.FromArgb(4, 60, 130);
            button_main_vect.BackColor = Color.FromArgb(4, 60, 130);
            button_main_editor.BackColor = Color.FromArgb(4, 60, 130);
        }

        private void button_main_config_lang_Click(object sender, EventArgs e)
        {
            if (fdl == null) fdl = new Form_Dialog_Lang();
            if (!fdl.Visible) { fdl = new Form_Dialog_Lang(); fdl.ShowDialog(); }
            else fdl.Focus();
        }

        private void button_vect_graph_open_Click(object sender, EventArgs e)
        {
            if (fg == null) fg = new Form_Graph();
            if (!fg.Visible) { fg = new Form_Graph(); fg.Show(); }
            else fg.Focus();
        }

        private void button2_Click_4(object sender, EventArgs e)
        {
            if (fme == null) fme = new Form_Macro();
            if (!fme.Visible) { fme = new Form_Macro(); fme.Show(); }
            else fme.Focus();
        }

        private void button_main_config_assoc_Click(object sender, EventArgs e)
        {
            if (!FileAssociation.CanWriteRegistry)
            {
                FileAssociation.AllertAboutAdmin();
                return;
            } else
            {
                if (fda == null) fda = new Form_Dialog_Assoc();
                if (!fda.Visible) { fda = new Form_Dialog_Assoc(); fda.ShowDialog(); }
                else fda.Focus();
            }
        }

        private void textBox_MaxStepWidth_TextChanged(object sender, EventArgs e)
        {
            var a = 0;
            var g = textBox_MaxStepWidth;
            string s = g.Text;
            if (s != "" && !int.TryParse(s, out a))
            {
                MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["MainWindow.WrongNumber"], s), TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                g.Text = ls4;
                return;
            }
            if (s == "") return;
            devicechanged[1] = (int.Parse(s) != device_maxw);
            CheckChangedDevice();
            ls4 = s;
        }

        private void textBox_ymm_TextChanged(object sender, EventArgs e)
        {
            var a = .0f;
            var g = textBox_ymm;
            string s = g.Text;
            if (s != "" && !float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out a))
            {
                MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["MainWindow.WrongNumber"], s), TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                g.Text = ls5;
                return;
            }
            if (s == "") return;
            devicechanged[3] = (float.Parse(s, CultureInfo.InvariantCulture) != device_ymm);
            CheckChangedDevice();
            ls5 = s;
        }

        private void textBox_xmm_TextChanged(object sender, EventArgs e)
        {
            var a = .0f;
            var g = textBox_xmm;
            string s = g.Text;
            if (s != "" && !float.TryParse(s,NumberStyles.Any, CultureInfo.InvariantCulture, out a))
            {
                MessageBox.Show(string.Format(TranslateBase.CurrentLang.Error["MainWindow.WrongNumber"], s), TranslateBase.CurrentLang.Phrase["MainWindow.Word.Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                g.Text = ls6;
                return;
            }
            if (s == "") return;
            devicechanged[2] = (float.Parse(s, CultureInfo.InvariantCulture) != device_xmm);
            CheckChangedDevice();
            ls6 = s;
        }

        private void comboBox_mainport_SelectedIndexChanged(object sender, EventArgs e)
        {
            configchanged[0] = (comboBox_mainport.Text != _configDefport);
            CheckChanged();
        }

        private void comboBox_mainrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            configchanged[1] = (int.Parse(comboBox_mainrate.Text) != config_defspeed);
            CheckChanged();
        }

        private void comboBox_pso_SelectedIndexChanged(object sender, EventArgs e)
        {
            configchanged[4] = (ExOperators.GetEnum<StartPrintOption>(comboBox_pso.Text) != config_spo);
            CheckChanged();
        }

        private void comboBox_peo_SelectedIndexChanged(object sender, EventArgs e)
        {
            configchanged[5] = (ExOperators.GetEnum<ReturnBackOption>(comboBox_peo.Text) != config_rbo);
            CheckChanged();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if(progressBar_main_memory_val.Value!=0)
            {
                try
                {
                    timer1.Stop();
                    a.ResetData();
                    Thread.Sleep(1000);
                    button_get_Click(null, null);

                }
                catch { }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var a = checkBox_main_memory_readonly.Checked;
            textBox_main_memory_idle.Enabled = !a;
            textBox_main_memory_work.Enabled = !a;
            textBox_main_memory_xd.Enabled = !a;
            textBox_main_memory_yd.Enabled = !a;
            textBox_main_memory_zd.Enabled = !a;
            textBox_main_memory_xs.Enabled = !a;
            textBox_main_memory_ys.Enabled = !a;
            textBox_main_memory_zs.Enabled = !a;
            checkBox_main_memory_com.Enabled = !a;
            checkBox_main_memory_pause.Enabled = !a;
            label_main_memory_idle.Enabled = !a;
            label_main_memory_work.Enabled = !a;
            label_main_memory_xd.Enabled = !a;
            label_main_memory_xs.Enabled = !a;
            label_main_memory_yd.Enabled = !a;
            label_main_memory_ys.Enabled = !a;
            label_main_memory_zd.Enabled = !a;
            label_main_memory_zs.Enabled = !a;
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            a.XDir = int.Parse(textBox_main_memory_xd.Text);
            a.YDir = int.Parse(textBox_main_memory_yd.Text);
            a.ZDir = int.Parse(textBox_main_memory_zd.Text);
            a.XStep = int.Parse(textBox_main_memory_xs.Text);
            a.YStep = int.Parse(textBox_main_memory_ys.Text);
            a.ZStep = int.Parse(textBox_main_memory_zs.Text);
            a.IdleDelay = int.Parse(textBox_main_memory_idle.Text);
            a.WorkDelay = int.Parse(textBox_main_memory_work.Text);
            a.Pause = checkBox_main_memory_pause.Checked;
            a.Com = checkBox_main_memory_com.Checked;
            a.Load();
        }

        private void button_get_Click_(object sender, EventArgs e)
        {
            button_get_Click(null, null);
        }

        private void checkBox_main_memory_val_CheckedChanged(object sender, EventArgs e)
        {
            var a = checkBox_main_memory_val.Checked;
            progressBar_main_memory_val.Enabled = a;
            if (a)
            {
                progressBar_main_memory_val.Visible = true;
                timer1.Start();
                label_high.Text = "650";
                label_low.Text = "0";
            }
            else
            {
                progressBar_main_memory_val.Visible = false;
                progressBar_main_memory_val.Value = 0;
                label_high.Text = "";
                label_low.Text = "";
                label_val.Text = "";
                timer1.Stop();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            //new Form_Graph().ShowDialog();
            //Close();
            

            configchanged = new bool[11];
            devicechanged = new bool[8];
            comboBox_main_device_port.Items.AddRange(SerialPort.GetPortNames());
            comboBox_main_device_port.Text = GlobalOptions.Mainport.ToString();
            comboBox_main_device_board.Items.Clear();
            comboBox_main_device_board.Items.AddRange(ArduinoBoard.Boards.Select(p => p.DisplayName).ToArray());
            comboBox_main_device_board.Text = GlobalOptions.DefBoard.DisplayName;
            if (!File.Exists(folderBrowserDialog1.SelectedPath + "\\arduino_debug.exe"))
            {
                if (File.Exists("C:\\Program Files (x86)\\Arduino\\arduino_debug.exe")) { GlobalOptions.PathToArduino = "C:\\Program Files (x86)\\Arduino\\"; }
                if (File.Exists("C:\\Program Files\\Arduino\\arduino_debug.exe")) { GlobalOptions.PathToArduino = "C:\\Program Files\\Arduino\\"; }
            }
            label_main_device_pathto.Text = TranslateBase.CurrentLang.Phrase["MainWindow.PathToArduino"] + ": " + GlobalOptions.PathToArduino;
            if (File.Exists("c:\\Windows\\System32\\drivers\\CH341S64.SYS") || File.Exists("c:\\Windows\\System32\\drivers\\CH341S32.SYS")) DriverInstalled = true;
            if (DriverInstalled) button_main_device_driver.Enabled = false;
            label_main_device_isinstall.Visible = DriverInstalled;
            colorDialog1.AnyColor = true;
            for (int i = 0; i <= 50; i++) comboBox_mainport.Items.Add("COM" + i.ToString());
            foreach (string s in Enum.GetNames(typeof(StartPrintOption))) comboBox_pso.Items.Add(s);
            foreach (string s in Enum.GetNames(typeof(ReturnBackOption))) comboBox_peo.Items.Add(s);
            textBox_xmm.Text = GlobalOptions.XMM.ToString(CultureInfo.InvariantCulture);
            textBox_ymm.Text = GlobalOptions.YMM.ToString(CultureInfo.InvariantCulture);
            textBox_sh.Text = GlobalOptions.StepHeightConst.ToString();
            textBox_md.Text = GlobalOptions.MaxDisConst.ToString();
            comboBox_mainrate.Text = GlobalOptions.Mainbd.ToString();
            comboBox_mainport.Text = GlobalOptions.Mainport.ToString();
            textBox_main_config_vertCorrection.Text = GlobalOptions.UpKoof.ToString();
            comboBox_peo.Text = GlobalOptions.DefRbo.ToString();
            comboBox_pso.Text = GlobalOptions.DefSpo.ToString();
            checkBox_main_config_preload.Checked = GlobalOptions.PreloadPlugins;
            checkBox_usedevicespeed.Checked = GlobalOptions.UseAutoSpeed;
            comboBox_main_memory_bd.Text = GlobalOptions.Mainbd.ToString();
            comboBox_main_memory_ports.Items.AddRange(SerialPort.GetPortNames());
            textBox_MaxStepWidth.Text = GlobalOptions.MaxWidthSteps.ToString();
            textBox_maxstepheight.Text = GlobalOptions.MaxHeightSteps.ToString();
            comboBox_main_memory_ports.Text = GlobalOptions.Mainport.ToString();
            pb = new Bitmap(65, 23);
            vb = new Bitmap(65, 23);
            pd = new Bitmap(65, 23);
            vd = new Bitmap(65, 23);
            label_main_about_version.Text = TranslateBase.CurrentLang.Phrase["MainWindow.Version"] + ": " + GlobalOptions.Ver + '.';
            label_main_about_build.Text = TranslateBase.CurrentLang.Phrase["MainWindow.Build"] + ": " + GlobalOptions.Build + '.';
            label_main_about_dotnet.Text = TranslateBase.CurrentLang.Phrase["MainWindow.TargetDotNet"] + ": " + "4.5.2" + '.';
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            label_main_about_hm.Text+= FileVersionInfo.GetVersionInfo(fi.Directory.FullName + "\\Lib\\CWA_VectorHM.dll").FileVersion + '.';
            label_main_about_pr.Text += FileVersionInfo.GetVersionInfo(fi.Directory.FullName + "\\Lib\\CWA_Vectors.dll").FileVersion + '.';
            label_main_about_v.Text += FileVersionInfo.GetVersionInfo(fi.Directory.FullName + "\\Lib\\CWA_Printing.dll").FileVersion + '.';
            label_main_about_ve.Text += FileVersionInfo.GetVersionInfo(fi.Directory.FullName + "\\Lib\\CWA_VEditor.dll").FileVersion + '.';
            label_main_about_pm.Text += FileVersionInfo.GetVersionInfo(fi.Directory.FullName + "\\Lib\\CWA_PrintMacros.dll").FileVersion + '.';
            label_main_about_con.Text += FileVersionInfo.GetVersionInfo(fi.Directory.FullName + "\\Lib\\CWA_Connection.dll").FileVersion + '.';
            FillColors();
            button_home.BackColor = Color.FromArgb(4, 60, 130);
            tabControl_about.SelectedIndex = 2;
            button_about.BackColor = Color.FromArgb(5, 92, 199);
            configchanged = new bool[11];
            devicechanged = new bool[8];
            FirstConfigPreloadChange = false;
            CheckChangedDevice();
            CheckChanged();
        }
    }
}
