#pragma once

// Board.h

#ifndef _BOARD_h
#define _BOARD_h

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif

enum class Board
{
	yun,
	uno,
	duemulanove,
	nano,
	mega,
	adk,
	leonardo,
	leonardo_eth,
	micro,
	esplora,
	mini,
	ethernet,
	fio,
	bt,
	lilypad_usb,
	lilypad,
	pro,
	ng,
	robot_control,
	robot_motor,
	gemma,
	circuitplay,
	yunmini,
	industrial101,
	linio_one,
	uno_wifi,
	unknown
};

enum class BoardArchitecture
{
	avr,
	arm,
	i686,
	i586,
	unknown
};

#if defined(__AVR__)
const BoardArchitecture _BOARD_ARCHITECTURE_ = BoardArchitecture::avr;
#elif defined(__ARM__)
const BoardArchitecture _BOARD_ARCHITECTURE_ = BoardArchitecture::arm;
#elif defined(__I686__)
const BoardArchitecture _BOARD_ARCHITECTURE_ = BoardArchitecture::i686;
#elif defined(__I586__)
const BoardArchitecture _BOARD_ARCHITECTURE_ = BoardArchitecture::i586;
#else
const BoardArchitecture _BOARD_ARCHITECTURE_ = BoardArchitecture::unknown;
#endif

#ifdef AVR_UNO_WIFI
const Board _BOARD_ = Board::uno_wifi;
#define _FLASH_MEMORY_ 253952
#define _SRAM_MEMORY_ 8192

#elif defined(ARDUINO_AVR_YUN)
const Board _BOARD_ = Board::yun;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_UNO)
const Board _BOARD_ = Board::uno;
#define _FLASH_MEMORY_ 32256
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_DUEMILANOVE)
const Board _BOARD_ = Board::duemulanove;
#define _FLASH_MEMORY_ 30720
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_NANO)
const Board _BOARD_ = Board::nano;
#define _FLASH_MEMORY_ 30720
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_MEGA2560)
const Board _BOARD_ = Board::mega;
#define _FLASH_MEMORY_ 253952
#define _SRAM_MEMORY_ 8192

#elif defined(ARDUINO_AVR_ADK)
const Board _BOARD_ = Board::adk;
#define _FLASH_MEMORY_ 253952
#define _SRAM_MEMORY_ 8192

#elif defined(ARDUINO_AVR_LEONARDO)
const Board _BOARD_ = Board::leonardo;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_LEONARDO_ETH)
const Board _BOARD_ = Board::leonardo_eth;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_MICRO)
const Board _BOARD_ = Board::micro;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_ESPLORA)
const Board _BOARD_ = Board::esplora;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_MINI)
const Board _BOARD_ = Board::mini;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 8192

#elif defined(ARDUINO_AVR_ETHERNET)
const Board _BOARD_ = Board::ethernet;
#define _FLASH_MEMORY_ 32256
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_FIO)
const Board _BOARD_ = Board::fio;
#define _FLASH_MEMORY_ 30720
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_BT)
const Board _BOARD_ = Board::bt;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_LILYPAD_USB)
const Board _BOARD_ = Board::lilypad_usb;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_LILYPAD)
const Board _BOARD_ = Board::lilypad;
#define _FLASH_MEMORY_ 30720
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_PRO)
const Board _BOARD_ = Board::pro;
#define _FLASH_MEMORY_ 30720
#define _SRAM_MEMORY_ 2048

#elif defined(ARDUINO_AVR_NG)
const Board _BOARD_ = Board::ng;
#define _FLASH_MEMORY_ 7168
#define _SRAM_MEMORY_ 1024

#elif defined(ARDUINO_AVR_ROBOT_CONTROL)
const Board _BOARD_ = Board::robot_control;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_ROBOT_MOTOR)
const Board _BOARD_ = Board::robot_motor;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_GEMMA)
const Board _BOARD_ = Board::gemma;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 5310

#elif defined(ARDUINO_AVR_CIRCUITPLAY)
const Board _BOARD_ = Board::circuitplay;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_YUNMINI)
const Board _BOARD_ = Board::yunmini;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_INDUSTRIAL101)
const Board _BOARD_ = Board::industrial101;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_LININO_ONE)
const Board _BOARD_ = Board::linio_one;
#define _FLASH_MEMORY_ 28672
#define _SRAM_MEMORY_ 2560

#elif defined(ARDUINO_AVR_UNO_WIFI)
const Board _BOARD_ = Board::uno_wifi;
#define _FLASH_MEMORY_ 32256
#define _SRAM_MEMORY_ 2048

#else
const Board _BOARD_ = Board::unknown;
#define _FLASH_MEMORY_ 0
#define _SRAM_MEMORY_ 0
#pragma warning Your board is not supported.

#endif

#endif