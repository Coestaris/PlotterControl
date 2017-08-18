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
* CWA.DTP \ PacketAnswer.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
*=================================*/

using System;
using System.Linq;

namespace CWA.DTP
{
    public class PacketAnswer
    {
        public UInt16 Command { get; set; }
        public Sender Sender { get; set; }
        public AnswerStatus Status { get; set; }
        public AnswerDataType DataType { get; set; }
        public byte Code { get; set; }
        public byte[] Data { get; set; }
        private bool isEmpty;

        public PacketAnswer(Packet base_)
        {
            if (base_.IsEmpty) { IsEmpty = true; return; };
            if (base_.Data == null || base_.Data.Length < 4) { IsEmpty = true; return; };
            Command = HelpMethods.GetNumber(base_.Data[0], base_.Data[1]);
            Status = (AnswerStatus)base_.Data[2];
            DataType = ((AnswerDataType)base_.Data[3]);
            Sender = base_.Sender;
            if (DataType == AnswerDataType.CODE)
                Code = base_.Data[4];
            else if (DataType == AnswerDataType.DATA)
                Data = base_.Data.ToList().GetRange(4, base_.Data.Length - 4).ToArray();
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            private set { isEmpty = value; }
        }

        public override string ToString()
        {
            switch (DataType)
            {
                case AnswerDataType.CODE:
                    return string.Format("Answer:\n   -Answer to Command: {0};\n   -Sender of Answer: {1};\n   -Answer Status: {2};\n   -ErrorCode Type: {3};\n   -Data (Byte): {4};",
                           Command.ToString(), Sender.ToString(), Status.ToString(), DataType.ToString(), Code);
                case AnswerDataType.DATA:
                    return string.Format("Answer:\n   -Answer to Command: {0}\n   -Sender of Answer: {1}\n   -Answer Status: {2}\n   -ErrorCode Type: {3}\n   -Data (Byte array. {4} Byte(s)): {5}",
                           Command.ToString(), Sender.ToString(), Status.ToString(), DataType.ToString(), Data.Length, string.Join(",", Data) + " or \"" + string.Join("", Data.Select(p => (char)p)) + "\"");
                case AnswerDataType.NONE:
                    return string.Format("Answer:\n   -Answer to Command: {0}\n   -Sender of Answer: {1}\n\t-Answer Status: {2}\n   -ErrorCode Type: {3}\n   -Sender dont send any data.",
                           Command.ToString(), Sender.ToString(), Status.ToString(), DataType.ToString());
                default:
                    return null;
            }
        }
    }
}
