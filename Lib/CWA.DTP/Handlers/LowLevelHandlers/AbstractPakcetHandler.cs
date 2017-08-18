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
* CWA.DTP \ AbstractPakcetHandler.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
*=================================*/

using System;

namespace CWA.DTP
{
    public abstract class AbstractPakcetHandler
    {
        protected static readonly byte[] EmptyData = { 1 };

        protected PacketAnswer GetResult(UInt16 command)
        {
            return Listener.SendAndListenPacket(Packet.GetPacket(command, EmptyData, Sender));
        }

        protected PacketAnswer GetResult(UInt16 command, byte[] data)
        {
            return Listener.SendAndListenPacket(Packet.GetPacket(command, data, Sender));
        }

        public Sender Sender { get; set; }

        public PacketListener Listener { get; set; }
    }
}
