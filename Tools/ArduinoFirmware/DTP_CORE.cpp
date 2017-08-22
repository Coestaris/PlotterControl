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
uint16_t ComputeChecksum(const byte* data_p, uint32_t length) {
	uint8_t x;
	uint16_t crc = 0xFFFF;
	while (length--) {
		x = crc >> 8 ^ *data_p++;
		x ^= x >> 4;
		crc = (crc << 8) ^ ((int32_t)(x << 12)) ^ ((int32_t)(x << 5)) ^ ((int32_t)x);
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

void Error(String Pattern, bool freeze) {
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
	if(freeze) while (true)
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
		Error(ERROR_WRONG_SUM, true);
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
bool PLOTTER_ForceStop = false;
uint32_t PLOTTER_DelayTime = 50;

bool PLOTTER_CheckBounds()
{
	return digitalRead(PLOTTER_BoundSensor_XF) || digitalRead(PLOTTER_BoundSensor_XB) || digitalRead(PLOTTER_BoundSensor_YL) || digitalRead(PLOTTER_BoundSensor_YR);
}

//#define DebugPrint
uint32_t counter = 0;

uint32_t PLOTTER_GetCurrentPosition()
{
	return counter;
}

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

void PLOTTER_RUN(File &file, uint16_t ElevationDelta, int16_t ElevationCorrection, uint16_t XCoef, uint16_t YCoef)
{
	digitalWrite(RelayPin, 0);
	delay(200);
	if (!file)
		Error(ERROR_SD_CARDINIT, true);
	uint32_t PrintFileSize = file.size();
#ifdef DebugPrint
	File DebugFILE = SD.open("printLog4.txt", O_CREAT | O_WRITE | O_APPEND);
	DebugFILE.print("=====\nFileName:");
	DebugFILE.println(Path);
	DebugFILE.print("FleSize:");
	DebugFILE.println(PrintFileSize);
	DebugFILE.close();
#endif
	counter = 0;	
	PLOTTER_DelayTime = PLOTTER_idle;
	bool drawing = false;
	PLOTTER_ForceStop = false;
	while (counter != PrintFileSize)
	{
		byte* Bytes = new byte[4];
		file.seek(counter);
		if(file.readBytes(Bytes, 4) != 4)
			Error(ERROR_SD_CARDINIT, true);
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
			drawing = true;
			//DOWN!
#ifdef DebugPrint
			DebugFILE.print("DOWN! ");
			DebugFILE.print(- PLOTTER_UpSteps);
			DebugFILE.close();
#endif
			PLOTTER_LowerPen(ElevationDelta);
			counter += 4;
			delete[] Bytes;
			continue;
		}
		if (Bytes[0] == 101 && Bytes[1] == 101 && Bytes[2] == 101 && Bytes[3] == 101)
		{
			drawing = false;
			//UP!
#ifdef DebugPrint
			DebugFILE.print("UP! ");
			DebugFILE.print(PLOTTER_UpSteps + PLOTTER_UpCorrectSteps);
			DebugFILE.close();
#endif
			PLOTTER_LiftPen(ElevationDelta, ElevationCorrection);
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
		if (!PLOTTER_MoveSM((int32_t)((int32_t)dx * (int32_t)XCoef), 
							(int32_t)((int32_t)dy * (int32_t)YCoef), 
							0, 
							true) || PLOTTER_ForceStop)
		{
			if (drawing)
				PLOTTER_LiftPen(ElevationDelta, ElevationCorrection);
			Error("010", false);
			break;
		};
		counter += 4;
	}
	delay(200);
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

void PLOTTER_Abort()
{
	PLOTTER_ForceStop = true;
}

bool PLOTTER_MoveSM(int32_t x, int32_t y, int32_t z, bool checkBoundsAndComands)
{
	int32_t values[3], values1[3];
	double deltas1[3], deltas[3];
	int32_t Step, i, Counter_ = 0;
	boolean Flag;
	values[0] = x;
	values[1] = y;
	values[2] = z;
	Step = 1;
	for (i = 0; i < 3; i++)
	{
		if (Step < abs(values[i])) Step = abs(values[i]);
	}
	for (i = 0; i < 3; i++)
	{
		deltas1[i] = 0;
		deltas[i] = 1.0 * values[i] / Step;
		values1[i] = 0;
	}
	Flag = false;
	for (i = 0; i < 3; i++)
	{
		if (abs(deltas1[i]) < abs(values[i])) Flag = true;
	}
	while (Flag)
	{
		if(checkBoundsAndComands) if (Counter_++ % 500 == 0)
		{
			if (PLOTTER_CheckBounds())
				return false;
			if (Serial.available() != 0) Read();
		}
		Flag = false;
		for (i = 0; i < 3; i++)
		{
			if (abs(deltas1[i]) < abs(values[i]))
				deltas1[i] += deltas[i];
			if (abs(deltas1[i]) - abs(values1[i]) >= 0.5)
			{
				if (values[i]>0)
				{
					values1[i]++;
					PLOTTER_moveForward(i);
				}
				else
				{
					values1[i]--;
					PLOTTER_moveBackward(i);
				}
			}
			if (abs(deltas1[i]) < abs(values[i])) Flag = true;
		}
		PLOTTER_delayMicros(PLOTTER_DelayTime);
	}
	return true;
}

void PLOTTER_LiftPen(uint16_t ElevationDelta, int16_t ElevationCorrection)
{
	PLOTTER_MoveSM(0, 0, -((int16_t)ElevationDelta + (int16_t)ElevationCorrection), false);
	PLOTTER_DelayTime = PLOTTER_idle;
}

void PLOTTER_LowerPen(uint16_t ElevationDelta)
{
	PLOTTER_MoveSM(0, 0, (int16_t)ElevationDelta, false);
	PLOTTER_DelayTime = PLOTTER_work;
}

static const uint32_t crc_32_tab[] PROGMEM = { 
	0x00000000, 0x77073096, 0xee0e612c, 0x990951ba, 0x076dc419, 0x706af48f,
	0xe963a535, 0x9e6495a3, 0x0edb8832, 0x79dcb8a4, 0xe0d5e91e, 0x97d2d988,
	0x09b64c2b, 0x7eb17cbd, 0xe7b82d07, 0x90bf1d91, 0x1db71064, 0x6ab020f2,
	0xf3b97148, 0x84be41de, 0x1adad47d, 0x6ddde4eb, 0xf4d4b551, 0x83d385c7,
	0x136c9856, 0x646ba8c0, 0xfd62f97a, 0x8a65c9ec, 0x14015c4f, 0x63066cd9,
	0xfa0f3d63, 0x8d080df5, 0x3b6e20c8, 0x4c69105e, 0xd56041e4, 0xa2677172,
	0x3c03e4d1, 0x4b04d447, 0xd20d85fd, 0xa50ab56b, 0x35b5a8fa, 0x42b2986c,
	0xdbbbc9d6, 0xacbcf940, 0x32d86ce3, 0x45df5c75, 0xdcd60dcf, 0xabd13d59,
	0x26d930ac, 0x51de003a, 0xc8d75180, 0xbfd06116, 0x21b4f4b5, 0x56b3c423,
	0xcfba9599, 0xb8bda50f, 0x2802b89e, 0x5f058808, 0xc60cd9b2, 0xb10be924,
	0x2f6f7c87, 0x58684c11, 0xc1611dab, 0xb6662d3d, 0x76dc4190, 0x01db7106,
	0x98d220bc, 0xefd5102a, 0x71b18589, 0x06b6b51f, 0x9fbfe4a5, 0xe8b8d433,
	0x7807c9a2, 0x0f00f934, 0x9609a88e, 0xe10e9818, 0x7f6a0dbb, 0x086d3d2d,
	0x91646c97, 0xe6635c01, 0x6b6b51f4, 0x1c6c6162, 0x856530d8, 0xf262004e,
	0x6c0695ed, 0x1b01a57b, 0x8208f4c1, 0xf50fc457, 0x65b0d9c6, 0x12b7e950,
	0x8bbeb8ea, 0xfcb9887c, 0x62dd1ddf, 0x15da2d49, 0x8cd37cf3, 0xfbd44c65,
	0x4db26158, 0x3ab551ce, 0xa3bc0074, 0xd4bb30e2, 0x4adfa541, 0x3dd895d7,
	0xa4d1c46d, 0xd3d6f4fb, 0x4369e96a, 0x346ed9fc, 0xad678846, 0xda60b8d0,
	0x44042d73, 0x33031de5, 0xaa0a4c5f, 0xdd0d7cc9, 0x5005713c, 0x270241aa,
	0xbe0b1010, 0xc90c2086, 0x5768b525, 0x206f85b3, 0xb966d409, 0xce61e49f,
	0x5edef90e, 0x29d9c998, 0xb0d09822, 0xc7d7a8b4, 0x59b33d17, 0x2eb40d81,
	0xb7bd5c3b, 0xc0ba6cad, 0xedb88320, 0x9abfb3b6, 0x03b6e20c, 0x74b1d29a,
	0xead54739, 0x9dd277af, 0x04db2615, 0x73dc1683, 0xe3630b12, 0x94643b84,
	0x0d6d6a3e, 0x7a6a5aa8, 0xe40ecf0b, 0x9309ff9d, 0x0a00ae27, 0x7d079eb1,
	0xf00f9344, 0x8708a3d2, 0x1e01f268, 0x6906c2fe, 0xf762575d, 0x806567cb,
	0x196c3671, 0x6e6b06e7, 0xfed41b76, 0x89d32be0, 0x10da7a5a, 0x67dd4acc,
	0xf9b9df6f, 0x8ebeeff9, 0x17b7be43, 0x60b08ed5, 0xd6d6a3e8, 0xa1d1937e,
	0x38d8c2c4, 0x4fdff252, 0xd1bb67f1, 0xa6bc5767, 0x3fb506dd, 0x48b2364b,
	0xd80d2bda, 0xaf0a1b4c, 0x36034af6, 0x41047a60, 0xdf60efc3, 0xa867df55,
	0x316e8eef, 0x4669be79, 0xcb61b38c, 0xbc66831a, 0x256fd2a0, 0x5268e236,
	0xcc0c7795, 0xbb0b4703, 0x220216b9, 0x5505262f, 0xc5ba3bbe, 0xb2bd0b28,
	0x2bb45a92, 0x5cb36a04, 0xc2d7ffa7, 0xb5d0cf31, 0x2cd99e8b, 0x5bdeae1d,
	0x9b64c2b0, 0xec63f226, 0x756aa39c, 0x026d930a, 0x9c0906a9, 0xeb0e363f,
	0x72076785, 0x05005713, 0x95bf4a82, 0xe2b87a14, 0x7bb12bae, 0x0cb61b38,
	0x92d28e9b, 0xe5d5be0d, 0x7cdcefb7, 0x0bdbdf21, 0x86d3d2d4, 0xf1d4e242,
	0x68ddb3f8, 0x1fda836e, 0x81be16cd, 0xf6b9265b, 0x6fb077e1, 0x18b74777,
	0x88085ae6, 0xff0f6a70, 0x66063bca, 0x11010b5c, 0x8f659eff, 0xf862ae69,
	0x616bffd3, 0x166ccf45, 0xa00ae278, 0xd70dd2ee, 0x4e048354, 0x3903b3c2,
	0xa7672661, 0xd06016f7, 0x4969474d, 0x3e6e77db, 0xaed16a4a, 0xd9d65adc,
	0x40df0b66, 0x37d83bf0, 0xa9bcae53, 0xdebb9ec5, 0x47b2cf7f, 0x30b5ffe9,
	0xbdbdf21c, 0xcabac28a, 0x53b39330, 0x24b4a3a6, 0xbad03605, 0xcdd70693,
	0x54de5729, 0x23d967bf, 0xb3667a2e, 0xc4614ab8, 0x5d681b02, 0x2a6f2b94,
	0xb40bbe37, 0xc30c8ea1, 0x5a05df1b, 0x2d02ef8d
};

inline uint32_t updateCRC32(uint8_t ch, uint32_t crc)
{
	uint32_t idx = ((crc) ^ (ch)) & 0xff;
	uint32_t tab_value = pgm_read_dword(crc_32_tab + idx);
	return tab_value ^ ((crc) >> 8);
}

uint32_t crc32_ofFile(File &file, uint32_t &charcnt)
{
	uint32_t oldcrc32 = 0xFFFFFFFF;
	charcnt = 0;

	while (file.available())
	{
		uint8_t c = file.read();
		charcnt++;
		oldcrc32 = updateCRC32(c, oldcrc32);
	}

	return ~oldcrc32;
}