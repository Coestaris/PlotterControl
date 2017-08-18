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
* CWA.DTP.Plotter \ PlotterConfigOptions.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:23:25
*
*=================================*/

using System;

namespace CWA.DTP.Plotter
{
    public class PlotterConfigOptions
    {
        public byte PinMappingXStep { get; set; }
        public byte PinMappingYStep { get; set; }
        public byte PinMappingZStep { get; set; }
        public byte PinMappingXDirection { get; set; }
        public byte PinMappingYDirection { get; set; }
        public byte PinMappingZDirection { get; set; }
        public byte PinMappingComLed { get; set; }
        public byte PinMappingPauseLed { get; set; }
        public UInt16 WorkDelay { get; set; }
        public UInt16 IdleDelay { get; set; }
        public bool ComLed { get; set; }
        public bool PauseLed { get; set; }

        internal PlotterConfigOptions(byte[] data)
        {
            PinMappingXStep = data[0];
            PinMappingXDirection = data[1];
            PinMappingYStep = data[2];
            PinMappingYDirection = data[3];
            PinMappingZStep = data[4];
            PinMappingZDirection = data[5];
            WorkDelay = (UInt16)(data[6] | (data[7] << 8));
            IdleDelay = (UInt16)(data[8] | (data[9] << 8));
            PauseLed = data[10] == 1;
            ComLed = data[11] == 1;
            PinMappingPauseLed = data[12];
            PinMappingComLed = data[13];
        }

        public override string ToString()
        {
            return string.Format("Pin Mapping:\n - X Step: {0}\n - X Dir: {1}\n - Y Step: {2}\n - Y Dir: {3}\n - Z Step: {4}\n - Z Dir: {5}\n - Pause Led: {6}\n - Com Led: {7}\n\nWork Delay: {8}\nIdle Delay: {9}\nIs Com Led: {10}\nIs Pause Led: {11}",
                PinMappingXStep, PinMappingXDirection, PinMappingYStep, PinMappingYDirection, PinMappingZStep, PinMappingZDirection, PinMappingPauseLed, PinMappingComLed,
                WorkDelay, IdleDelay, ComLed, PauseLed);
        }

        internal byte[] ToByteArray()
        {
            return new byte[PlotterConfig.ConfigFileLength]
            {
                PinMappingXStep,
                PinMappingXDirection,
                PinMappingYStep,
                PinMappingYDirection,
                PinMappingZStep,
                PinMappingZDirection,
                (byte)(WorkDelay & 0xFF),
                (byte)((WorkDelay >> 8) & 0xFF),
                (byte)(IdleDelay & 0xFF),
                (byte)((IdleDelay >> 8) & 0xFF),
                (byte)(ComLed ? 1 : 0),
                (byte)(PauseLed ? 1 : 0),
                PinMappingPauseLed,
                PinMappingComLed,
            };
        }
    }
}
