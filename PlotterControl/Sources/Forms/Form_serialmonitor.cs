/*=================================\
* PlotterControl\Form_serialmonitor.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 27.11.2017 14:04
* Last Edited: 27.11.2017 14:04:46
*=================================*/

using System;
using System.Windows.Forms;
using CWA.DTP;
using System.Text;
using System.Linq;
using System.IO.Ports;
using CWA.Connection;
using System.Threading;
using System.Collections.Generic;

namespace CnC_WFA
{
    public partial class Form_SerialMonitor : Form
    {
        public Form_SerialMonitor()
        {
            InitializeComponent();
        }

        private void checkBox_size_CheckedChanged(object sender, System.EventArgs e)
        {
            textBox_size_b1.Enabled = checkBox_size.Checked;
            textBox_size_b2.Enabled = checkBox_size.Checked;
        }

        private void checkBox_hash_CheckedChanged(object sender, System.EventArgs e)
        {
            textBox_hash_b1.Enabled = checkBox_hash.Checked;
            textBox_hash_b2.Enabled = checkBox_hash.Checked;
        }

        private void Form_SerialMonitor_Load(object sender, System.EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(CommandType)))
            {
                var name = Enum.GetName(typeof(CommandType), item);
                UInt32 itemI = (UInt32)item;
                comboBox_command.Items.Add(string.Format("{0} - 0x{1}", name, itemI.ToString("X").Trim()));
            }

            foreach (var item in Enum.GetValues(typeof(CWA.DTP.Plotter.CommandType)))
            {
                var name = Enum.GetName(typeof(CWA.DTP.Plotter.CommandType), item);
                UInt32 itemI = (UInt32)item;
                comboBox_command.Items.Add(string.Format("{0} - 0x{1}", name, itemI.ToString("X").Trim()));
            }


            comboBox_command.SelectedIndex = 1;
            comboBox_sender.Items.AddRange(Enum.GetNames(typeof(SenderType)));
            comboBox_sender.SelectedIndex = 0;
            comboBox_conv.Items.AddRange(new string[] {
                "UInt16 To Bytes",
                "Int16 To Bytes",
                "UInt32 To Bytes",
                "Int32 To Bytes",
                "UInt64 To Bytes",
                "Int64 To Bytes",
                "Float To Bytes",
                "Double To Bytes",
                "String To Bytes",
            });
            comboBox_port.Items.Clear();
            comboBox_port.Items.AddRange(SerialPort.GetPortNames());
            comboBox_bd.Items.AddRange(BdRate.GetNamesStrings());
        }

        private string Convert(string Input, int index)
        {
            byte[] bytes = new byte[0];
            try
            {
                switch (index)
                {
                    case (0):
                        bytes = BitConverter.GetBytes(UInt16.Parse(Input));
                    break;
                    case (1):
                        bytes = BitConverter.GetBytes(Int16.Parse(Input));
                        break;
                    case (2):
                        bytes = BitConverter.GetBytes(UInt32.Parse(Input));
                        break;
                    case (3):
                        bytes = BitConverter.GetBytes(Int32.Parse(Input));
                        break;
                    case (4):
                        bytes = BitConverter.GetBytes(UInt64.Parse(Input));
                        break;
                    case (5):
                        bytes = BitConverter.GetBytes(UInt64.Parse(Input));
                        break;
                    case (6):
                        bytes = BitConverter.GetBytes(Single.Parse(Input));
                        break;
                    case (7):
                        bytes = BitConverter.GetBytes(Double.Parse(Input));
                        break;
                    case (8):
                        bytes = Encoding.Default.GetBytes(Input);
                        break;
                    default:
                        break;
                }
                return string.Join(",", bytes);
            }
            catch(Exception e)
            {
                MessageBox.Show(
                    string.Format(
                        TB.L.Phrase["Form_PrintMaster.ErrorText"],
                        e.GetType().FullName, e.StackTrace, e.Message),
                     TB.L.Phrase["Connection.Error"],
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void comboBox_command_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] bytes = new byte[0];
            try { bytes = BitConverter.GetBytes((UInt16)(CommandType)Enum.Parse(typeof(CommandType), comboBox_command.Text.Split('-')[0])); }
            catch(ArgumentException) { bytes = BitConverter.GetBytes((UInt16)(CWA.DTP.Plotter.CommandType)Enum.Parse(typeof(CWA.DTP.Plotter.CommandType), comboBox_command.Text.Split('-')[0])); }
            finally
            {
                textBox_command_b1.Text = bytes[0].ToString();
                textBox_command_b2.Text = bytes[1].ToString();
            }
        }

        private void comboBox_sender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_sender.Text == SenderType.SevenByteName.ToString())
            {
                textBox_sender_b1.Text = ((UInt16)SenderType.SevenByteName).ToString();
                textBox_fill.Enabled = true;
            } else
            {
                textBox_sender_b1.Text = ((UInt16)SenderType.UnNamedByteMask).ToString();
                textBox_fill.Enabled = false;
            }
        }

        private void button_fill_Click(object sender, EventArgs e)
        {
            if (textBox_fill.Text.Length != 7)
            {
                MessageBox.Show(
                     TB.L.Phrase["Connection.Enter7CharString"],
                     TB.L.Phrase["Connection.Error"],
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBox_sender_b2.Text = ((byte)textBox_fill.Text[0]).ToString();
            textBox_sender_b3.Text = ((byte)textBox_fill.Text[1]).ToString();
            textBox_sender_b4.Text = ((byte)textBox_fill.Text[2]).ToString();
            textBox_sender_b5.Text = ((byte)textBox_fill.Text[3]).ToString();
            textBox_sender_b6.Text = ((byte)textBox_fill.Text[4]).ToString();
            textBox_sender_b7.Text = ((byte)textBox_fill.Text[5]).ToString();
            textBox_sender_b8.Text = ((byte)textBox_fill.Text[6]).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_conv_output.Text = Convert(textBox_conv_input.Text, comboBox_conv.SelectedIndex);
        }

        private void TryToCoputeLenghAndHash(bool action = false)
        {
            UInt16 Command;
            byte[] Sender;
            byte[] DataBytes = new byte[0];
            try { Command = BitConverter.ToUInt16(new byte[] { byte.Parse(textBox_command_b1.Text), byte.Parse(textBox_command_b2.Text) }, 0); }
            catch { label_err.Text = TB.L.Phrase["Connection.Error"] + ": " + TB.L.Phrase["Connection.Error.Command"]; return; }
            try
            {
                Sender = new byte[8]
                {
                    byte.Parse(textBox_sender_b1.Text),
                    byte.Parse(textBox_sender_b2.Text),
                    byte.Parse(textBox_sender_b3.Text),
                    byte.Parse(textBox_sender_b4.Text),
                    byte.Parse(textBox_sender_b5.Text),
                    byte.Parse(textBox_sender_b6.Text),
                    byte.Parse(textBox_sender_b7.Text),
                    byte.Parse(textBox_sender_b8.Text),
                };
            }
            catch { label_err.Text = TB.L.Phrase["Connection.Error"] + ": " + TB.L.Phrase["Connection.Error.SenderBytes"]; return; }
            if (textBox_data.Text != "")
            try { DataBytes = textBox_data.Text.Split(',').Select(p => byte.Parse(p)).ToArray(); }
            catch { label_err.Text = label_err.Text = TB.L.Phrase["Connection.Error"] + ": " + TB.L.Phrase["Connection.Error.Data"];  return; }
            UInt16 Length = (UInt16)(DataBytes.Length + 14 + 255);
            byte[] lengthBytes;
            try {  lengthBytes = checkBox_size.Checked ? new byte[] { byte.Parse(textBox_size_b1.Text), byte.Parse(textBox_size_b2.Text) } : BitConverter.GetBytes(Length); }
            catch  {  label_err.Text = label_err.Text = TB.L.Phrase["Connection.Error"] + ": " + TB.L.Phrase["Connection.Error.Size"]; ; return; }
            if (!checkBox_size.Checked)
            {
                textBox_size_b1.Text = lengthBytes[0].ToString();
                textBox_size_b2.Text = lengthBytes[1].ToString();
            }
            byte[] crc;
            if (!checkBox_hash.Checked)
            {
                var crcH = new CrCHandler();
                crc = crcH.ComputeChecksumBytes(DataBytes);
                textBox_hash_b1.Text = crc[0].ToString();
                textBox_hash_b2.Text = crc[1].ToString();
            }
            else
            {
                try {  crc = new byte[] { byte.Parse(textBox_hash_b1.Text), byte.Parse(textBox_hash_b2.Text) }; }
                catch  { label_err.Text = label_err.Text = TB.L.Phrase["Connection.Error"] + ": " + TB.L.Phrase["Connection.Error.Hash"]; return; }
            }
            if (action)
            {
                byte[] totalBytes = new byte[DataBytes.Length + 14];
                Buffer.BlockCopy(lengthBytes, 0, totalBytes, 0, 2);
                Buffer.BlockCopy(BitConverter.GetBytes(Command), 0, totalBytes, 2, 2);
                Buffer.BlockCopy(Sender, 0, totalBytes, 4, 8);
                Buffer.BlockCopy(DataBytes, 0, totalBytes, 12, DataBytes.Length);
                Buffer.BlockCopy(crc, 0, totalBytes, 12 + DataBytes.Length, 2);
                Requests.Add(new Packet()
                {
                    Command = Command,
                    Data = DataBytes,
                    Sender = new Sender(Sender),
                    TotalData = totalBytes,
                    Size = (Int16)(Length - 255)
                });

                listBox.Items.Add($"R{Requests.Count}. ${TB.L.Phrase["Connection.Error.Command"]}: ({textBox_command_b1.Text}, {textBox_command_b2.Text})");
                try
                {
                    Answers.Add(GetResult(totalBytes));
                    listBox.Items.Add($"A{Answers.Count}. ${TB.L.Phrase["Connection.Status"]}: {Answers.Last().Status}. ${TB.L.Phrase["Connection.AnswerTo"]}: {Answers.Last().Command}");
                }
                catch (Exception e)
                {
                    label_err.Text = TB.L.Phrase["Connection.Error.SendingError"];
                    MessageBox.Show(
                        string.Format(
                            TB.L.Phrase["Form_PrintMaster.ErrorText"],
                            e.GetType().FullName, e.StackTrace, e.Message),
                            TB.L.Phrase["Connection.Error"],
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                label_err.Text = "Sended";
                return;
            }
            label_err.Text = "Ok";
        }

        private List<PacketAnswer> Answers = new List<PacketAnswer>();
        private List<Packet> Requests = new List<Packet>();

        private void textBox_command_b1_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_command_b2_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b1_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b2_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b3_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b4_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b5_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b6_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b7_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_sender_b8_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void textBox_data_TextChanged(object sender, EventArgs e) => TryToCoputeLenghAndHash();

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox_port_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_port.Items.Clear();
            comboBox_port.Items.AddRange(SerialPort.GetPortNames());
        }

        private SerialPort port;

        private PacketListener Listener;

        protected PacketAnswer GetResult(byte[] bytes)
        {
            return Listener.SendAndListenPacket(new Packet() { TotalData = bytes }, true);
        }

        private void button_conn_Click(object sender, EventArgs e)
        {
            if(button_conn.Text != TB.L.Phrase["Connection.Disconnect"])
            try
            {
                port = new SerialPort(comboBox_port.Text, int.Parse(comboBox_bd.Text.Remove(0, 2)));
                port.Open();

                Listener = new PacketListener(new SerialPacketReader(port, 3000), new SerialPacketWriter(port));

                button_conn.Text = TB.L.Phrase["Connection.Disconnect"];
                button_send.Enabled = true;
                comboBox_bd.Enabled = false;
                comboBox_port.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        TB.L.Phrase["Form_PrintMaster.ErrorText"],
                        ex.GetType().FullName, ex.StackTrace, ex.Message),
                        TB.L.Phrase["Connection.Error"],
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                port.Close();
                button_send.Enabled = false;
                button_conn.Text = TB.L.Phrase["Connection.Connect"];
                comboBox_bd.Enabled = true;
                comboBox_port.Enabled = true;
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            TryToCoputeLenghAndHash(true);
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string name = (string)listBox.Items[index];
                var prefix = name.Split('.')[0];
                int listIndex = int.Parse(prefix.Remove(0, 1));
                if (prefix[0] == 'A')
                    ShowInfoAboutAnswer(listIndex);
                else ShowInfoAboutRequest(listIndex);
            }
        }

        private void ShowInfoAboutAnswer(int index)
        {
            var ob = Answers[index-1];
            string s = $"${TB.L.Phrase["Connection.Sender"]}: {ob.Sender.ToString()}\n${TB.L.Phrase["Connection.AnswStatus"]}: {ob.Status}\n${TB.L.Phrase["Connection.AnswCommand"]}: {ob.Command}\n\n${TB.L.Phrase["Connection.AnswerDataType"]}: {ob.DataType}\n";
            if (ob.DataType == AnswerDataType.CODE)
                s += $"   ${TB.L.Phrase["Connection.AnswerCode"]}: {ob.Code}";
            else if(ob.DataType == AnswerDataType.DATA)
            {
                s += $"   ${TB.L.Phrase["Connection.AnswerData"]}: {string.Join(",", ob.Data)}\n";
                s += $"   ${TB.L.Phrase["Connection.Or"]}: {string.Join("", ob.Data.Select(p=>(char)p))}";
            }
            MessageBox.Show(s, TB.L.Phrase["Connectio.AnswerData"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowInfoAboutRequest(int index)
        {
            var ob = Requests[index - 1];
            MessageBox.Show($"${TB.L.Phrase["Connection.PacketSender"]}: {ob.Sender.ToString()}\n${TB.L.Phrase["Connection.PacketCommand"]}: {ob.Command}\n${TB.L.Phrase["Connection.PacketData"]}: {string.Join(",", ob.Data)}", 
                TB.L.Phrase["Connection.PacketInfo"],
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
