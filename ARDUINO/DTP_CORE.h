#pragma once
// DTP_CORE.h

#ifndef _DTP_CORE_h
#define _DTP_CORE_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#define DTP_VERSION 1008

#define SpeakerPinPower 49
#define SpeakerPin 48
#define SDCSPin 53
#define ErrorLedPower 46

#define GCC_VERSION 40902

#define ErrorLedLowThreshold 10
#define ErrorLedHighThreshold 240
#define ErrorLedStartPos 200
#define SpeakerFrequency 1100
#define SpeakerLongDelay 800
#define SpeakerShortDelay 200
#define SpeakerDelay 400

const int DirectoryBufferSize PROGMEM = 40;

#include "SPI.h"
#include "SDFAT\SdFat.h"
#include "DS1307\TimeLib.h"
#include "DS1307\DS1307RTC.h"
#include "Board.h"

//#define OptimizeSendrerBytes
//#define PacketFileDebug
//#define SimpleCRC

#ifndef SimpleCRC
#include "FastCRC\FastCRC.h"
	#ifndef CRC32
		extern FastCRC32 CRC32Handler;
	#define CRC32
	#endif
	#ifndef CRC16
			extern FastCRC16 CRC16Handler;
	#define CRC16
	#endif
#endif

#ifdef OptimizeSendrerBytes
	#ifndef  CommandAnswVar
		extern byte* commandAnsw;
	#define CommandAnswVar
	#endif
	#ifndef  SenderDataVar
		extern byte* senderData;
	#define SenderDataVar
	#endif
#endif

#pragma region Methods
	byte* SplitNumber(int num);

#ifdef SimpleCRC
	int ComputeChecksum(const byte* data_p, int length);
#endif

	byte* ComputeChecksumBytes(const byte* data_p, int length);

	int FreeMemory();

	int GetNumber(byte low, byte high);

	void Wait();

	void Error(String Pattern);

	void dateTime(uint16_t* date, uint16_t* time);

	void Read();

	void HandlePacket(byte* data, int dataLen, uint16_t command);
#pragma endregion

#endif

