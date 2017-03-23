#include "DTP.h"

#ifdef SDVar
SdFat SD;
#endif

#if defined(OptimizeSendrerBytes) && defined(CommandAnswVar) && defined(SenderDataVar) 
	byte* commandAnsw = new byte[2]{ 19, 1 };
	byte* senderData = new byte[8]{ (byte)DTP_SENDERTYPE::SevenByteName, 68,116,112,67,108,110,116 };
#endif

#if !defined(SimpleCRC) && defined(CRC32) && defined (CRC16)
	FastCRC32 CRC32Handler;
	FastCRC16 CRC16Handler;
#endif

byte* SplitNumber(int num) {
	//byte a = (byte)(num & 0xFF);
	//byte b = (byte)((num >> 8) & 0xFF);
	//a = new byte[2]{ a, b };

	byte* res = new byte[2]{ (byte)(num & 0xFF), (byte)((num >> 8) & 0xFF) };
	return res;
}

#ifdef SimpleCRC
int ComputeChecksum(const byte* data_p, int length) {
	unsigned char x;
	unsigned short crc = 0xFFFF;
	while (length--) {
		x = crc >> 8 ^ *data_p++;
		x ^= x >> 4;
		crc = (crc << 8) ^ ((int)(x << 12)) ^ ((int)(x << 5)) ^ ((int)x);
	}
	return crc;
}
#endif 

byte* ComputeChecksumBytes(const byte* data_p, int length) {

#ifdef SimpleCRC	
	byte* a = SplitNumber(ComputeChecksum(data_p, length));
#else
	//byte* a = SplitNumber(CRC16Handler.ccitt(data_p, length));
#endif
	//int a1 = a[0];
	//int b1 = a[1];
	//delete[] a;
	//return new byte[2]{ a1 , b1 };
	return SplitNumber(CRC16Handler.ccitt(data_p, length));
}

int FreeMemory() {
	extern int __heap_start, *__brkval;
	int v;
	return (int)&v - (__brkval == 0 ? (int)&__heap_start : (int)__brkval);
}

int GetNumber(byte low, byte high) {
	return (short)(low | (high << 8));
}

void Wait() {
	while (!Serial.available()) {};
}

void Error(String Pattern) {
	int counter = ErrorLedStartPos;
	bool dir = true;
	digitalWrite(SpeakerPinPower, HIGH);
	analogWrite(ErrorLedPower, 255);
	for (int i = 0; i <= Pattern.length() - 1; i++)
	{
		switch (Pattern[i])
		{
		case('0'):
		{
			delay(200);
			break;
		}
		case('1'):
		{
			analogWrite(ErrorLedPower, 0);
			tone(SpeakerPin, SpeakerFrequency);
			delay(SpeakerShortDelay);
			if (Pattern[i + 1] == '0') {
				noTone(SpeakerPin);
				analogWrite(ErrorLedPower, ErrorLedHighThreshold);
			}
			break;
		}
		case('2'):
		{
			analogWrite(ErrorLedPower, 0);
			tone(SpeakerPin, SpeakerFrequency);
			delay(SpeakerLongDelay);
			if (Pattern[i + 1] == '0') {
				noTone(SpeakerPin);
				analogWrite(ErrorLedPower, ErrorLedHighThreshold);
			}
			break;
		}
		}
	}
	digitalWrite(SpeakerPinPower, LOW);
	while (true)
	{
		if (dir) counter++;
		else counter--;
		if (counter >= ErrorLedHighThreshold) dir = false;
		if (counter <= ErrorLedLowThreshold) dir = true;
		delay(5);
		analogWrite(ErrorLedPower, counter);
	}
}

void dateTime(uint16_t* date, uint16_t* time) {
	*date = FAT_DATE(year(), month(), day());
	*time = FAT_TIME(hour(), minute(), second());
}

#ifdef PacketFileDebug
int packetCount = 0;
void Read() {
	File file = SD.open("log"+String(packetCount )+".txt", FILE_WRITE );
	packetCount++;
	file.println("packet: " + String(packetCount));
	Wait();
	byte a = Serial.read();
	file.println("readed first byte: " + String(a));
	Wait();
	byte b = Serial.read();
	file.println("readed second byte: " + String(b));
	int len = GetNumber(a, b) - 255;
	file.println("total len is: " + String(len));
	byte* buffer = new byte[len];
	for (int i = 0; i <= len - 3; i++)
	{
		Wait();
		buffer[i + 2] = Serial.read();
	};
	buffer[0] = a;
	buffer[1] = b;
	int command = (int)GetNumber(buffer[2], buffer[3]);
	file.println("command is: " + String(command));
	int dataLen = len - 14;
	file.println("datalen is: " + String(dataLen));
	byte* data = new byte[dataLen];
	memcpy(data, buffer + 12, len - 14);
#ifdef SimpleCRC
	byte* crc = ComputeChecksumBytes(data, dataLen);
#else
	byte* crc = SplitNumber(CRCHandlers::CRC16Handler.ccitt(data, dataLen));
#endif
	file.println("data bytes: ");
	for (int i = 0; i <= dataLen; i++)
	{
		file.print(String(data[i]) + " ");
	}
	file.println();
	file.println("total bytes: ");
	for (int i = 0; i <= len - 1; i++)
	{
		file.print(String(buffer[i]) + ",");
	}
	file.println();
	file.println("buffer[len - 2] is: " + String(buffer[len - 2]));
	file.println("buffer[len - 1] is:" + String(buffer[len - 1]));
	file.println("old crc is: " + String(buffer[len - 2]) + " " + buffer[len - 1]);
	file.println("new crc is: " + String(crc[0]) + " " + crc[1]);
	file.println(FreeMemory());
	delete[] buffer;
	if (crc[0] != buffer[len - 2] || crc[1] != buffer[len - 1])
	{
		file.println("Error! Wrong crc");
		file.close();
		Error(ERROR_WRONG_SUM);
		return;
	}
	if (!file.close()) Error(ERROR_SD_INITSDCARD);
	HandlePacket(data, dataLen, command);
	delete[] crc;
	delete[] data;
}
#else
void Read() {
	Wait();
	byte a = Serial.read();
	Wait();
	byte b = Serial.read();
	int len = GetNumber(a, b) - 255;
	byte* buffer = new byte[len];
	/*for (int i = 0; i <= len - 3; i++)
	{
		Wait();
		buffer[i + 2] = Serial.read();
	};*/

	Serial.readBytes(buffer + 2, len - 2);

	int command = (int)GetNumber(buffer[2], buffer[3]);
	int dataLen = len - 14;
	byte* data = new byte[dataLen];
	memcpy(data, buffer + 12, len - 14);
#ifdef SimpleCRC
	byte* crc = ComputeChecksumBytes(data, dataLen);
#else
	byte* crc = SplitNumber(CRC16Handler.ccitt(data, dataLen));
#endif
	delete[] buffer;
	if (crc[0] != buffer[len - 2] || crc[1] != buffer[len - 1])
	{
		Error(ERROR_WRONG_SUM);
		return;
	}
	HandlePacket(data, dataLen, command);
	delete[] crc;
	delete[] data;
}
#endif
