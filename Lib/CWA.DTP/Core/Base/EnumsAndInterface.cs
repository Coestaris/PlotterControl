/*=================================\
* CWA.DTP\EnumsAndInterface.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 20.09.2017 9:28:03
*=================================*/

namespace CWA.DTP
{
    public interface IPacketReader
    {
        void Reset();
        byte[] Read();
        void Close();
    }

    public interface IPacketWriter
    {
        bool Write(byte[] packet);
        void Close();
    }

    public enum AnswerStatus
    {
        OK = 0x10,
    	Warning = 0x20,
    	Error = 0x40,
	    ValidationError = 0x60
    };

    enum ValidationStatus
    {
        NotValidated = 0x10,
	    Validated = 0x20,
	    WrongKey = 0x40,
	    Ok = 0x80
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
