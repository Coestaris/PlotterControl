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

#define RelayPin 10
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

//#define PacketDebugInfo;
//#define OptimizeSendrerBytes
//#define PacketFileDebug
#define SimpleCRC
//#define DEBUG

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

	void HandlePacket(byte* data, uint32_t dataLen, uint16_t command);
#pragma endregion

#pragma region Plotter

#define PLOTTER_PauseLed 8
#define PLOTTER_PauseCom 9
#define PLOTTER_ButtonStop A2
#define PLOTTER_PauseLed 8
#define PLOTTER_PauseCom 9
#define PLOTTER_ButtonStop A2
#define PLOTTER_ButtonPause A1
#define PLOTTER_Analog A0
#define PLOTTER_XDIR 4
#define PLOTTER_YDIR 2
#define PLOTTER_ZDIR 6
#define PLOTTER_XSTEP 5
#define PLOTTER_YSTEP 3
#define PLOTTER_ZSTEP 7
#define PLOTTER_WORK 50 
#define PLOTTER_IDLE 40
#define PLOTTER_UPSTEPS 1650
#define PLOTTER_UPCORRECTSTEPS 50
#define CONFIGNAME "/config.cfg"
	
	void PLOTTER_INIT();

	void PLOTTER_RUN(String Path, uint16_t XCoef, uint16_t YCoef);

	void PLOTTER_ResetToDefault();

	void PLOTTER_moveForward(uint32_t sm);

	void PLOTTER_moveBackward(uint32_t sm);

	void PLOTTER_delayMicros(uint32_t wt);

	void PLOTTER_MoveSM(int32_t x, int32_t y, int32_t z);

#pragma endregion

#endif

