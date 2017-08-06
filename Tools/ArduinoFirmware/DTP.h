#pragma once

// DTP.h

/*
* == COMMANDS ==
*
*         ========== STRUCTURE ==========
*
*  +---------+--------------------+-------------------------------------------------------------------------------------------+
*  | NAME    |  SIZE              |   DISCRIPTION									      |	
*  +---------+--------------------+-------------------------------------------------------------------------------------------+
*  | Size    |  2 Bytes           |  Bytes Total size of the packet in bytes INCLUDING the 4-byte CRC appended to the data.   |
*  | Command |  2 Bytes           |  Bytes Command id or status id.							      |
*  | Address |  8 Bytes           |  Bytes Client address (unit name) or SERIAL_COMMAND_BROADCAST_ADDRESS.		      |
*  | Data    |  <variable length> |  Packet data, zero or more bytes with the caveat that it must be in multiples of 4 bytes. |
*  | CRC     |  2 Bytes           |  16-bit CRC of entire packet.						              |
*  +---------+--------------------+-------------------------------------------------------------------------------------------+
*
*
*         ========== COMMANDS ==========
*
*
*  1.   0x101    Run File
*		Request to run file.Data = Filename.
*       DataExample: cvf\\nvidia_log.cvf
*
*  2.   0x102    Reset
*		Request to reset Arduino.
*
*  3.   0x103    Get File Tree(Recursive)
*		Request to get Recursive File tree.Data = 0x50.
*
*  4.   0x104    Get File Tree(Recursive) of current Dir
*		Request to get Recursive File tree of Dir.Data = DirName.
*		DataExample: options\\
*
*  5.   0x105    Get File Data
*		Request to get all bytes of file.Data = FileName.
*		DataExample: options\\opts.txt
*
*  6.   0x106    Write Data to File(Full Rewrite File)
*		Request to fully rewrite all bytes of file.Data = FileName.
*		DataExample: options\\opts.txt
*
*  7.   0x107    Delete File
*	    Request to Delete file.
*	    Data: Absolute file name.
*	    Answer Errors:
*			1. 0 - Ok.
*			2. 1 - Can`t delete, reason unknown.
*			3. 2 - File not exists.
*
*  8.   0x108    Rename File
*		Request to rename file.Data = FileName || NewName.
*		DataExample: options\\opts.txt || options\\options.opts
*
*  9.   0x109    Get File Info
*		Request to get some file info.Data = FileName.
*		DataExample: options\\opts.txt
*
*  10.  0x10a    Append File With Data
*		Request to append some bytes to file.Data = FileName.
*		DataExample: options\\opts.txt
*
*  11.  0x10b    Create Folder
*		Request to create folder.Data = FolderDir.
*		DataExample: options\\
*
*  12.  0x10c    Delete Folder
*		Request to delete folder.Data = FolderDir.
*		DataExample: options\\
*
*  13.  0x10d    Rename Folder
*		Request to rename folder.Data = FolderDir.
*		DataExample: options\\
*
*  14.  0x10e    Get Data File(Partial)
*		Request to get some bytes of file.Data = FileName || Position || Count.
*		DataExample: cvf\\nvidia_logo.cvf || 0 || 60
*
*  15.  0x110    Test
*		Check command.
*		Data: Any count of bytes.
*		Answer: n - bytes: Returns all recived bytes.		
*
*  16.  0x111    DataTest.
*		Check command. 
*		Data: Nothing;
*		Answer: Nothing;	
*
*  17.  0x112    Get Info
*		Request to get some iformation about sd card.
*		Data: Nothing;
*		Answer: 6 bytes;
*
*
*
*  18.  0x113    Answer
*		Data:
*			1. Command 2 bytes.
*			2. Satus 1 byte.
*			3. ErrorCode n bytes.
*				1. 1 byte: ErrorCode Type.
*				2. 1 or N bytes: ErrorCode or Data.
*
*		ErrorCode Type:
*			1. Code = 0x20
*			1. Data = 0x40
*			1. None = 0x60
*
*		Status:
*			1. OK = 0x20
*			2. Warning = 0x40
*			3. Error = 0x60
*
*  19.  0x114 Create File.
*	    Request to Create file.
*	    Data: Absolute file name.
*	    Answer Errors: 
*			1. 0 - Ok.
*			2. 1 - Can`t create, reason unknown.
*
* */

#ifndef _DTP_h
#define _DTP_h

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif

#include "SDFAT\SdFat.h";

#ifndef SDVar
extern SdFat SD;
#define SDVar
#endif

#ifdef PacketFileDebug
extern int packetCount = 0;
#endif

enum class DTP_COMMANDTYPE : uint16_t
{
	RunFile = 0x101,
	File_GetFileTree = 0x103,
	File_GetFileData = 0x105,
	File_GetFileLength = 0x10e,
	File_WriteDataToFile = 0x106,
	File_DeleteFile = 0x107,
	File_CreateFile = 0x114,
	File_RenameFile = 0x108,
	File_GetFileInfo = 0x109,
	File_AppendDataToFile = 0x10a,
	Folder_Create = 0x10b,
	Folder_Delete = 0x10c, 
	Folder_Rename = 0x10d,
	Test = 0x110,
	DataTest = 0x111,
	GetSDInfo = 0x112, 
	Answer = 0x113, 
	GetDateTime = 0x115,
	SetTime = 0x116, 
	FILE_GetHashSumOfFile = 0x117, 
	SET_DIGITAL_PIN = 0x118,
	SET_ANALOG_PIN = 0x119,
	SPEAKER_BEEP = 0x11a,
	GetInfo = 0x11b, 
	File_Open = 0x11c, 
	File_Close = 0x11d, 
	File_Exists = 0x11e, 
	Plotter_RefreshConfig = 0x120,
	Plotter_Print_Run = 0x121,
	Plotter_Print_Info = 0x122,
	Plotter_Print_Abort = 0x123,
};

enum class DTP_ANSWER_STATUS
{
	OK = 0x20,
	Warning = 0x40,
	Error = 0x60
};

enum class DTP_ANSWER_ERRORCODE_TYPE
{
	CODE = 0x20,
	DATA = 0x40,
	NONE = 0x60
};

enum class DTP_SENDERTYPE
{
	UnNamedByteMask = 0x20,
	SevenByteName = 0x40
};

enum class SDTCARD_TYPE
{
	SD1 = 0x10,
	SD2 = 0x20,
	SDHC = 0x30,
	Unknown = 0x40
};

const String ERROR_TIMEMODULE_CANTINIT PROGMEM = { "201020" };
const String ERROR_LOST_MEMORY PROGMEM = { "100001" };
const String ERROR_SD_INITSDCARD PROGMEM = { "220100" };
const String ERROR_SD_CARDINIT PROGMEM = { "220200" };
const String ERROR_SD_INITVOLUME PROGMEM = { "220101" };
const String ERROR_WRONG_SUM PROGMEM = { "101010" };
const String ERROR_CANT_SEND_FULL_PACKET PROGMEM = { "222222" };

#include "DTP_CORE.h"

#endif