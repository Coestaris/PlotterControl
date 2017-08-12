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
	unsigned int crc = 0xFFFF;
	while (length--) {
		x = crc >> 8 ^ *data_p++;
		x ^= x >> 4;
		crc = (crc << 8) ^ ((long)(x << 12)) ^ ((long)(x << 5)) ^ ((long)x);
	}
	return crc;
}
#endif 

byte* ComputeChecksumBytes(const byte* data_p, int length) {

#ifdef SimpleCRC	
	byte* a = SplitNumber(ComputeChecksum(data_p, length));
#else
	//byte* a = SplitNumber(CRC16Handler.ccitt(data_p, length));
	//return SplitNumber(CRC16Handler.ccitt(data_p, length));
#endif
	int a1 = a[0];
	int b1 = a[1];
	delete[] a;
	return new byte[2]{ a1 , b1 };
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
	File file = SD.open("log"+String(packetCount)+".txt", FILE_WRITE );
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
	
	for (int i = 0; i <= len - 3; i++)
	{
		Wait();
		buffer[i + 2] = Serial.read();
	};

	//Serial.readBytes(buffer + 2, len - 2);

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


uint8_t PLOTTER_MOTOR_PINS[3][2] =
		{ { PLOTTER_XSTEP, PLOTTER_XDIR },
		  { PLOTTER_YSTEP, PLOTTER_YDIR },
		  { PLOTTER_ZSTEP, PLOTTER_ZDIR } };
uint8_t PLOTTER_PAUSELED = PLOTTER_PauseLed;
uint8_t PLOTTER_PAUSECOM = PLOTTER_PauseCom;
uint16_t PLOTTER_work = PLOTTER_WORK;
uint16_t PLOTTER_idle = PLOTTER_IDLE;
bool PLOTTER_pause = false;
bool PLOTTER_com = false;
uint32_t PLOTTER_DelayTime = 50;

void PLOTTER_INIT()
{
	if (SD.exists(CONFIGNAME))
	{
		File PLOTTER_CONFIG_FILE = SD.open(CONFIGNAME, O_READ);
		PLOTTER_MOTOR_PINS[0][0] = PLOTTER_CONFIG_FILE.read();
		PLOTTER_MOTOR_PINS[0][1] = PLOTTER_CONFIG_FILE.read();
		PLOTTER_MOTOR_PINS[1][0] = PLOTTER_CONFIG_FILE.read();
		PLOTTER_MOTOR_PINS[1][1] = PLOTTER_CONFIG_FILE.read();
		PLOTTER_MOTOR_PINS[2][0] = PLOTTER_CONFIG_FILE.read();
		PLOTTER_MOTOR_PINS[2][1] = PLOTTER_CONFIG_FILE.read();
		PLOTTER_work = (uint16_t)(PLOTTER_CONFIG_FILE.read() | (PLOTTER_CONFIG_FILE.read() << 8));
		PLOTTER_idle = (uint16_t)(PLOTTER_CONFIG_FILE.read() | (PLOTTER_CONFIG_FILE.read() << 8));
		PLOTTER_pause = PLOTTER_CONFIG_FILE.read() == 1;
		PLOTTER_com = PLOTTER_CONFIG_FILE.read() == 1;
		PLOTTER_PAUSELED = PLOTTER_CONFIG_FILE.read();
		PLOTTER_PAUSECOM = PLOTTER_CONFIG_FILE.read();
		PLOTTER_CONFIG_FILE.close();
	}
	else PLOTTER_ResetToDefault();
	pinMode(PLOTTER_PAUSELED, OUTPUT);
	pinMode(PLOTTER_PAUSECOM, OUTPUT);
	for (int i = 0; i < 3; i++) for (int count = 0; count < 2; count++) pinMode(PLOTTER_MOTOR_PINS[i][count], OUTPUT);
	PLOTTER_DelayTime = 50;
	digitalWrite(PLOTTER_PAUSELED, PLOTTER_pause);
	digitalWrite(PLOTTER_PAUSECOM, PLOTTER_com);
}

//#define DebugPrint

void PLOTTER_RUN(String Path, uint16_t ElevationDelta, int16_t ElevationCorrection, uint16_t XCoef, uint16_t YCoef)
{
	digitalWrite(RelayPin, 0);
	delay(20);

	File PrintFile = SD.open(Path.c_str(), O_READ);
	if (!PrintFile)
		Error(ERROR_SD_CARDINIT);
	uint32_t PrintFileSize = PrintFile.size();
#ifdef DebugPrint
	File DebugFILE = SD.open("printLog4.txt", O_CREAT | O_WRITE | O_APPEND);
	DebugFILE.print("=====\nFileName:");
	DebugFILE.println(Path);
	DebugFILE.print("FleSize:");
	DebugFILE.println(PrintFileSize);
	DebugFILE.close();
#endif
	uint32_t counter = 0;
	bool drawing = false;
	while (counter != PrintFileSize)
	{
		byte* Bytes = new byte[4];
		PrintFile.seek(counter);
		if(PrintFile.readBytes(Bytes, 4) != 4)
			Error(ERROR_SD_CARDINIT);;

		//if (Serial.available() != 0)
//			Read();

#ifdef DebugPrint
		File DebugFILE = SD.open("printLog4.txt", O_CREAT | O_WRITE | O_APPEND);
		DebugFILE.print("Counter: "); 
		DebugFILE.print(counter);
		DebugFILE.print("Bytes: [");
		DebugFILE.print(Bytes[0]);
		DebugFILE.print(",");
		DebugFILE.print(Bytes[1]);
		DebugFILE.print(",");
		DebugFILE.print(Bytes[2]);
		DebugFILE.print(",");
		DebugFILE.print(Bytes[3]);
		DebugFILE.print("]. ");
#endif
		if (Bytes[0] == 100 && Bytes[1] == 100 && Bytes[2] == 100 && Bytes[3] == 100)
		{
			//DOWN!
#ifdef DebugPrint
			DebugFILE.print("DOWN! ");
			DebugFILE.print(- PLOTTER_UpSteps);
			DebugFILE.close();
#endif
			PLOTTER_MoveSM(0, 0, ElevationDelta + ElevationCorrection);
			counter += 4;
			PLOTTER_DelayTime = PLOTTER_work;
			delete[] Bytes;
			continue;
		}
		if (Bytes[0] == 101 && Bytes[1] == 101 && Bytes[2] == 101 && Bytes[3] == 101)
		{
			//UP!
#ifdef DebugPrint
			DebugFILE.print("UP! ");
			DebugFILE.print(PLOTTER_UpSteps + PLOTTER_UpCorrectSteps);
			DebugFILE.close();
#endif
			PLOTTER_MoveSM(0, 0, - (int16_t)ElevationDelta);
			PLOTTER_DelayTime = PLOTTER_idle;
			counter += 4;
			delete[] Bytes;
			continue;
		}
		int16_t dx = (int16_t)(((Bytes[1] & 0xFF) << 8) | (Bytes[0] & 0xFF));
		int16_t dy = (int16_t)(((Bytes[3] & 0xFF) << 8) | (Bytes[2] & 0xFF));
#ifdef DebugPrint
		DebugFILE.print("MOVE! ");
		DebugFILE.print(dx);
		DebugFILE.print(",");
		DebugFILE.print(dy);
		DebugFILE.print("||");
		DebugFILE.print(XCoef, 4);
		DebugFILE.print(",");
		DebugFILE.print(XCoef, 4);
		DebugFILE.print("||");
		DebugFILE.print((int32_t)(dx * XCoef));
		DebugFILE.print(",");
		DebugFILE.println((int32_t)(dx * XCoef));
		DebugFILE.close();
#endif
		delete[] Bytes;
		PLOTTER_MoveSM((int32_t)((int32_t)dx * (int32_t)XCoef), (int32_t)((int32_t)dy * (int32_t)YCoef), 0);
		counter += 4;
	}
	PrintFile.close();
	delay(20);
	digitalWrite(RelayPin, 1);
}

void PLOTTER_ResetToDefault()
{
	File PLOTTER_CONFIG_FILE = SD.open(CONFIGNAME, O_WRITE | O_CREAT);
	byte* data = new byte[14]
	{
		PLOTTER_XSTEP,
		PLOTTER_XDIR,
		PLOTTER_YSTEP,
		PLOTTER_YDIR,
		PLOTTER_ZSTEP,
		PLOTTER_ZDIR,
		(byte)(PLOTTER_WORK & 0xFF),
		(byte)((PLOTTER_WORK >> 8) & 0xFF),
		(byte)(PLOTTER_IDLE & 0xFF),
		(byte)((PLOTTER_IDLE >> 8) & 0xFF),
		0,
		0,
		PLOTTER_PauseLed,
		PLOTTER_PauseCom,
	};
	PLOTTER_CONFIG_FILE.write(data, 18);
	PLOTTER_CONFIG_FILE.close();
	delete[] data;
}

void PLOTTER_moveForward(uint32_t sm)
{
	digitalWrite(PLOTTER_MOTOR_PINS[sm][1], HIGH);
	digitalWrite(PLOTTER_MOTOR_PINS[sm][0], HIGH);
	digitalWrite(PLOTTER_MOTOR_PINS[sm][0], LOW);
}

void PLOTTER_moveBackward(uint32_t sm)
{
	digitalWrite(PLOTTER_MOTOR_PINS[sm][1], LOW);
	digitalWrite(PLOTTER_MOTOR_PINS[sm][0], HIGH);
	digitalWrite(PLOTTER_MOTOR_PINS[sm][0], LOW);
}

void PLOTTER_delayMicros(uint32_t wt)
{
	uint32_t mls;
	uint16_t mks;
	mls = (uint32_t)(wt / 1000);
	mks = (uint16_t)(wt % 1000);
	if (mls > 0) delay(mls);
	if (mks > 0) delayMicroseconds(mks);
}

void PLOTTER_MoveSM(int32_t x, int32_t y, int32_t z)
{
	int32_t c[3], c2[3];
	double c1[3], d[3];
	int32_t m, i;
	boolean flg;
	c[0] = x;
	c[1] = y;
	c[2] = z;
	m = 1;
	for (i = 0; i < 3; i++)
	{
		if (m < abs(c[i])) m = abs(c[i]);
	}
	for (i = 0; i < 3; i++)
	{
		c1[i] = 0;
		d[i] = 1.0 * c[i] / m;
		c2[i] = 0;
	}
	flg = false;
	for (i = 0; i < 3; i++)
	{
		if (abs(c1[i]) < abs(c[i])) flg = true;
	}
	while (flg)
	{
		flg = false;
		for (i = 0; i < 3; i++)
		{
			if (abs(c1[i]) < abs(c[i]))
				c1[i] += d[i];
			if (abs(c1[i]) - abs(c2[i]) >= 0.5)
			{
				if (c[i]>0)
				{
					c2[i]++;
					PLOTTER_moveForward(i);
				}
				else
				{
					c2[i]--;
					PLOTTER_moveBackward(i);
				}
			}
			if (abs(c1[i]) < abs(c[i])) flg = true;
		}
		PLOTTER_delayMicros(PLOTTER_DelayTime);
	}
}
