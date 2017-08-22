/*=================================\
* CWA.DTP\EnumsAndInterface.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

namespace CWA.DTP
{
    public interface IPacketReader
    {
        void Reset();
        byte[] Read();
    }

    public interface IPacketWriter
    {
        bool Write(byte[] packet);
    }

    public enum AnswerStatus
    {
        OK = 0x20,
	    Warning = 0x40,
	    Error = 0x60
    };

    public enum AnswerDataType
    {
        CODE = 0x20,
    	DATA = 0x40,
    	NONE = 0x60
    };

    public enum SenderType
    {
        UnNamedByteMask = 0x20,
    	SevenByteName = 0x40
    };
}
