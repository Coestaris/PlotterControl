#pragma once

#include "DTP.h"

File WriteFile;
uint16_t PrintFileName;
bool isOpenFile;

uint16_t XCoef;
uint16_t YCoef;

uint16_t ElevDelta;
int16_t ElevCorr;
uint16_t YCoef;

bool ReqToStartPrint = false;
int ii = 0;

void HandlePacket(byte* data, uint32_t dataLen, uint16_t command) {
#pragma region Vars

#ifdef DEBUG
	File debugFILE = SD.open("debug", O_CREAT | O_APPEND | O_WRITE);
	debugFILE.println("==NEW PACKET==");
	debugFILE.print("COMMAND (uint16_t): ");
	debugFILE.println(command);
	debugFILE.print("DATALEN (int): ");
	debugFILE.println(dataLen);
#endif 
	DTP_ANSWER_STATUS status;
	DTP_ANSWER_ERRORCODE_TYPE error_code;
	int dataByte = 0;
	byte* dataBytes = new byte[1];
	int dataBytesLen = 0;
#pragma endregion

	switch ((DTP_COMMANDTYPE)command)
	{
		/*
		case DTP_COMMANDTYPE::Plotter_Print_Info:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;

			dataBytesLen = 9;
			dataBytes = new byte[dataBytesLen]
			{
				size & 0xFF,
				(size >> 8) & 0xFF,
				(size >> 16) & 0xFF,
				(size >> 24) & 0xFF,

				size & 0xFF,
				(size >> 8) & 0xFF,
				(size >> 16) & 0xFF,
				(size >> 24) & 0xFF,
			};
			break;
		}
		*/
		case DTP_COMMANDTYPE::Plotter_Print_Run:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			dataByte = 0;
			ElevDelta = (uint16_t)(data[0] | (data[1] << 8));
			ElevCorr = (int16_t)(data[2] | (data[3] << 8));
			XCoef = (uint16_t)(data[4] | (data[5] << 8));
			YCoef = (uint16_t)(data[6] | (data[7] << 8));
			PrintFileName = (uint16_t)(data[8] | (data[9] << 8));
			ReqToStartPrint = true;
			break;
		}

		case DTP_COMMANDTYPE::File_GetFileInfo:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;
			delete[] dataBytes;

			String path = "";
			for (int i = 0; i <= dataLen - 1; i++)
				path += (char)data[i];

			File a = SD.open(path.c_str());
			if (!SD.exists(path.c_str()))
			{
				status = DTP_ANSWER_STATUS::Error;
				dataBytesLen = 1;
				dataBytes = new byte[1]{ 0 };
				break;
			}
			dir_t d;
			if (!a.dirEntry(&d));
			uint16_t date = d.creationDate;
			uint16_t time = d.creationTime;

			byte* temp = SplitNumber(FAT_YEAR(date));
			byte* timeBytes = new byte[7]
			{
				FAT_HOUR(time),
				FAT_MINUTE(time),
				FAT_SECOND(time),
				FAT_DAY(date),
				FAT_MONTH(date),
				temp[0],
				temp[1]
			};

			delete[] temp;

			uint32_t size = a.size();
			dataBytesLen = 16;
			dataBytes = new byte[dataBytesLen];

			dataBytes[0] = size & 0xFF;
			dataBytes[1] = (size >> 8) & 0xFF;
			dataBytes[2] = (size >> 16) & 0xFF;
			dataBytes[3] = (size >> 24) & 0xFF;

			memcpy(dataBytes + 4, timeBytes, 7);

			dataBytes[11] = a.isHidden() ? 1 : 0;
			dataBytes[12] = a.isLFN() ? 1 : 0;
			dataBytes[13] = a.isReadOnly() ? 1 : 0;
			dataBytes[14] = a.isSystem() ? 1 : 0;
			dataBytes[15] = a.isDir() ? 1 : 0;

			delete[] timeBytes;

			break;
		}

		case DTP_COMMANDTYPE::FILE_GetHashSumOfFile:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;
			delete[] dataBytes;
			WriteFile.seek(0);
			uint32_t len;
			uint32_t crc = crc32(WriteFile, len);
			WriteFile.seek(0);
			dataBytesLen = 5;
			dataBytes = new byte[5]
			{
				0, 			
				crc & 0xFF,
				(crc >> 8) & 0xFF,
				(crc >> 16) & 0xFF,
				(crc >> 24) & 0xFF
			};
			WriteFile.close();
		Exit: break;
		}

		case DTP_COMMANDTYPE::Test:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::NONE;
			break;
		}

		case DTP_COMMANDTYPE::DataTest:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;
			dataBytesLen = dataLen;
			delete[] dataBytes;
			dataBytes = new byte[dataLen];
			memcpy(dataBytes, data, dataLen);
			break;
		}
		case DTP_COMMANDTYPE::Plotter_RefreshConfig:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::NONE;
			PLOTTER_INIT();
			break;
		}
	
		case DTP_COMMANDTYPE::Folder_Create:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			String path = "";
			for (int i = 0; i <= dataLen - 2; i++)
				path += (char)data[i];
			File f = SD.open(path, O_READ);
			if (f)
			{
				if (f.isDir()) dataByte = 2;
				else dataByte = 3;
				f.close();
				break;
			}
			dataByte = SD.mkdir(path.c_str(), data[dataLen - 1] == 1) ? 0 : 1;
			break;
		}

		case DTP_COMMANDTYPE::Folder_Delete:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			String path = "";
			for (int i = 0; i <= dataLen - 2; i++)
				path += (char)data[i];
			File f = SD.open(path, O_READ);
			if (!f)
			{
				dataByte = 2;
				f.close();
				break;
			}
			if (data[dataLen - 1] == 1) dataByte = f.rmRfStar() ? 0 : 1;
			else dataByte = SD.rmdir(path.c_str()) ? 0 : 1;
			f.close();
			break;
		}

		case DTP_COMMANDTYPE::File_WriteDataToFile:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			int len = GetNumber(data[0], data[1]);
			String path = "";
			for (int i = 0; i <= len - 1; i++)
				path += (char)data[i + 2];
			if (!SD.exists(path.c_str()))
			{
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 1;
				break;
			}
			File a = SD.open(path, O_WRITE);
			if (!a)
			{
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 2;
				break;
			}
			a.write(data + 2 + len, dataLen - (2 + len));
			a.close();
			break;
		}

		case DTP_COMMANDTYPE::File_Open:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			String path = "";
			for (int i = 0; i <= dataLen - 2; i++)
				path += (char)data[i];
			bool isClear = data[dataLen - 1] == 1;
			if (!SD.exists(path.c_str()))
			{
				isOpenFile = false;
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 1;
				break;
			}
			if (isClear) WriteFile = SD.open(path, O_READ | O_WRITE | O_AT_END | O_CREAT | O_TRUNC);
			else WriteFile = SD.open(path, O_READ | O_WRITE | O_APPEND | O_AT_END | O_CREAT);
			if (!WriteFile)
			{
				isOpenFile = false;
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 2;
				break;
			}
			isOpenFile = true;
			dataByte = 0;
			break;
		}

		case DTP_COMMANDTYPE::File_Exists:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			String path = "";
			for (int i = 0; i <= dataLen - 1; i++)
				path += (char)data[i];
			if (!SD.exists(path.c_str()))
			{
				dataByte = 1;
			}
			else dataByte = 0;
			break;
		}

		case DTP_COMMANDTYPE::File_Close:
		{
			if (WriteFile.isOpen()) WriteFile.close();
			isOpenFile = false;
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::NONE;
			break;
		}

		case DTP_COMMANDTYPE::File_GetFileLength:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;
			if (!isOpenFile)
			{
				status = DTP_ANSWER_STATUS::Error;
				break;
			}
			dataBytesLen = 4;
			delete[] dataBytes;
			uint32_t size = WriteFile.size();
			dataBytesLen = 4;
			dataBytes = new byte[dataBytesLen];
			dataBytes[0] = size & 0xFF;
			dataBytes[1] = (size >> 8) & 0xFF;
			dataBytes[2] = (size >> 16) & 0xFF;
			dataBytes[3] = (size >> 24) & 0xFF;
			break;
		}

		case DTP_COMMANDTYPE::File_GetFileData:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;
			delete[] dataBytes;
			if (!isOpenFile)
			{
				status = DTP_ANSWER_STATUS::Error;
				dataBytesLen = 1;
				dataBytes = new byte[1]{ 1 };
				break;
			}
			uint32_t startBlock = ((uint32_t)data[3] << 24) | ((uint32_t)data[2] << 16) | ((uint32_t)data[1] << 8) | (uint32_t)data[0];
			uint32_t length = ((uint32_t)data[7] << 24) | ((uint32_t)data[6] << 16) | ((uint32_t)data[5] << 8) | (uint32_t)data[4];

			WriteFile.seek(startBlock);
			dataBytes = new byte[length];
			dataBytesLen = length;

			uint32_t newLength = WriteFile.readBytes(dataBytes, length);
		
			if (newLength != length)
				Error(ERROR_SD_CARDINIT);
		
			if (newLength == -1)
			{
				status = DTP_ANSWER_STATUS::Error;
				dataBytesLen = 1;
				dataBytes = new byte[1]{ 2 };
				break;
			};

			/*
			File f = SD.open("log13.txt", O_CREAT | O_WRITE | O_APPEND);
			f.print("Packet:");
			f.print(ii++);
			f.print(" ");
			f.print(startBlock);
			f.print(" ");
			f.print(length);
			f.print(". ");
			for (int i = 0; i <= 7; i++)
			{
				f.print(data[i]);
				f.print(',');
			}
			f.println();
			f.close();
			*/

			break;
		}

		case DTP_COMMANDTYPE::File_AppendDataToFile:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			if (isOpenFile && WriteFile.write(data, dataLen) != -1) dataByte = 0;
			else dataByte = 1;
			break;
		}

		case DTP_COMMANDTYPE::GetSDInfo:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;

			cid_t cid;
			if (!SD.card()->readCID(&cid)) {
				//sdErrorMsg("readCID failed");
			}

			csd_t csd;
			uint32_t eraseSize;
			uint8_t eraseSingleBlock;
			if (!SD.card()->readCSD(&csd)) {
				//sdErrorMsg("readCSD failed");
			}
			if (csd.v1.csd_ver == 0) {
				eraseSingleBlock = csd.v1.erase_blk_en;
				eraseSize = (csd.v1.sector_size_high << 1) | csd.v1.sector_size_low;
			}
			else if (csd.v2.csd_ver == 1) {
				eraseSingleBlock = csd.v2.erase_blk_en;
				eraseSize = (csd.v2.sector_size_high << 1) | csd.v2.sector_size_low;
			}
			else {
			}
			SDTCARD_TYPE type;
			switch (SD.card()->type())
			{
			case SD_CARD_TYPE_SD1:
				type = SDTCARD_TYPE::SD1;
				break;
			case SD_CARD_TYPE_SD2:
				type = SDTCARD_TYPE::SD2;
				break;
			case SD_CARD_TYPE_SDHC:
				type = SDTCARD_TYPE::SDHC;
				break;
			default:
				type = SDTCARD_TYPE::Unknown;
			}
			eraseSize++;
			uint32_t cardSize = SD.card()->cardSize();
			uint32_t volumesize = 0.000512 * cardSize;
			uint32_t freeClusterCount = SD.vol()->freeClusterCount();
			uint32_t freeSpace = freeClusterCount * 0.000512 * SD.vol()->blocksPerCluster();
			uint32_t clusterCount = SD.vol()->clusterCount();
			uint32_t fatStartBlock = SD.vol()->fatStartBlock();
			uint32_t blocksPerFat = SD.vol()->blocksPerFat();
			uint32_t rootDirStart = SD.vol()->rootDirStart();
			uint32_t dataStartBlock = SD.vol()->dataStartBlock();
			delete[] dataBytes;
			dataBytesLen = 55;
			dataBytes = new byte[dataBytesLen]
			{
				// Manufacturer ID
				cid.mid,
				// OEM ID
				cid.oid[0],
				cid.oid[1],
				// Product Version
				(byte)cid.pnm[0],
				(byte)cid.pnm[1],
				(byte)cid.pnm[2],
				(byte)cid.pnm[3],
				(byte)cid.pnm[4],
				// Version
				cid.prv_n,
				cid.prv_m,
				// Serial number 
				cid.psn & 0xFF,
				(cid.psn >> 8) & 0xFF,
				(cid.psn >> 16) & 0xFF,
				(cid.psn >> 24) & 0xFF,
				// Manufacturing date
				cid.mdt_month,
				cid.mdt_year_low,
				cid.mdt_year_high,
				// CardSize
				volumesize & 0xFF,
				(volumesize >> 8) & 0xFF,
				(volumesize >> 16) & 0xFF,
				(volumesize >> 24) & 0xFF,
				// flashEraseSize
				eraseSize,
				// eraseSingleBlock
				eraseSingleBlock ? 1 : 0,
				// Fat type
				SD.vol()->fatType(),
				// blocksPerCluster
				SD.vol()->blocksPerCluster(),
				// clusterCount
				clusterCount & 0xFF,
				(clusterCount >> 8) & 0xFF,
				(clusterCount >> 16) & 0xFF,
				(clusterCount >> 24) & 0xFF,
				// freeClusters
				freeClusterCount & 0xFF,
				(freeClusterCount >> 8) & 0xFF,
				(freeClusterCount >> 16) & 0xFF,
				(freeClusterCount >> 24) & 0xFF,
				// freeSpace
				freeSpace & 0xFF,
				(freeSpace >> 8) & 0xFF,
				(freeSpace >> 16) & 0xFF,
				(freeSpace >> 24) & 0xFF,
				// fatStartBlock
				fatStartBlock & 0xFF,
				(fatStartBlock >> 8) & 0xFF,
				(fatStartBlock >> 16) & 0xFF,
				(fatStartBlock >> 24) & 0xFF,
				// fatCount
				SD.vol()->fatCount(),
				// blocksPerFat
				blocksPerFat & 0xFF,
				(blocksPerFat >> 8) & 0xFF,
				(blocksPerFat >> 16) & 0xFF,
				(blocksPerFat >> 24) & 0xFF,
				// rootDirStart
				rootDirStart & 0xFF,
				(rootDirStart >> 8) & 0xFF,
				(rootDirStart >> 16) & 0xFF,
				(rootDirStart >> 24) & 0xFF,
				// dataStartBlock
				dataStartBlock & 0xFF,
				(dataStartBlock >> 8) & 0xFF,
				(dataStartBlock >> 16) & 0xFF,
				(dataStartBlock >> 24) & 0xFF,
				//Type
				(byte)type
			};
			break;
		}

		case DTP_COMMANDTYPE::File_CreateFile:
		{
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			String path = "";
			for (int i = 0; i <= dataLen - 1; i++)
				path += (char)data[i];
			if (SD.exists(path.c_str()))
			{
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 2;
				break;
			}
			File myFile = SD.open(path, FILE_WRITE);
			if (!myFile)
			{
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 1;
				break;
			}
			else myFile.close();
			if (!SD.exists(path.c_str()))
			{
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 1;
				break;
			}
			else status = DTP_ANSWER_STATUS::OK;
			break;
		}

		case DTP_COMMANDTYPE::File_DeleteFile:
		{
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			String path = "";
			for (int i = 0; i <= dataLen - 1; i++)
				path += (char)data[i];
			if (!SD.exists(path.c_str()))
			{
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 2;
				break;
			}
			bool a = SD.remove(path.c_str());
			if (SD.exists(path.c_str()) || !a)
			{
				status = DTP_ANSWER_STATUS::Error;
				dataByte = 1;
			}
			else status = DTP_ANSWER_STATUS::OK;
			break;
		}

		case DTP_COMMANDTYPE::File_GetFileTree:
		{
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;
			status = DTP_ANSWER_STATUS::OK;
			String path = "";
			for (int i = 0; i <= dataLen - 1; i++)
				path += (char)data[i];
			File root = SD.open(path);
			if (!root)
			{
				status = DTP_ANSWER_STATUS::Error;
				break;
			}
			root.rewindDirectory();
			int totalLen = 0;
			while (true)
			{
				File entry = root.openNextFile();
				if (!entry)
				{
					entry.close();
					root.rewindDirectory();
					break;
				}
				char name_[DirectoryBufferSize];
				entry.getName(name_, DirectoryBufferSize);
				String name = String(name_);
				if (entry.isDirectory()) name = '/' + name;
				int len = name.length();
				totalLen += len + 1;
				entry.close();
			}
			int lastLEN = totalLen;
			delete[] dataBytes;
			dataBytes = new byte[totalLen];
			totalLen = 0;
			root.rewindDirectory();
			while (true)
			{
				File entry = root.openNextFile();
				if (!entry)
				{
					entry.close();
					root.rewindDirectory();
					break;
				}
				char name_[DirectoryBufferSize];
				entry.getName(name_, DirectoryBufferSize);
				String name = String(name_);
				if (entry.isDirectory()) name = '/' + name;
				int len = name.length();
				for (int i = 0; i <= len - 1; i++)
					dataBytes[i + totalLen] = (byte)name[i];
				totalLen += len;
				dataBytes[totalLen] = 1;
				totalLen += 1;
				entry.close();
			}
			root.close();
			if (lastLEN != totalLen);// Error(ERROR_);
			dataBytesLen = totalLen;
			break;
		}

		case DTP_COMMANDTYPE::SetTime:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::NONE;
			int year_ = GetNumber(data[5], data[6]);
			setSyncProvider(RTC.get);
			setTime(
				data[0],
				data[1],
				data[2],
				data[3],
				data[4],
				year_
			);
			RTC.set(now());
			break;
		}

		case DTP_COMMANDTYPE::GetInfo:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;

			Board Board = _BOARD_;
			BoardArchitecture BoardArchitecture = _BOARD_ARCHITECTURE_;

			delete[] dataBytes;

			int StackFreeMemory = FreeMemory();

			dataBytesLen = 36;
			dataBytes = new byte[dataBytesLen]
			{
				(byte)Board,
				(byte)BoardArchitecture,
				StackFreeMemory & 0xFF,
				(StackFreeMemory >> 8) & 0xFF,
				(StackFreeMemory >> 16) & 0xFF,
				(StackFreeMemory >> 24) & 0xFF,
				F_CPU & 0xFF,
				(F_CPU >> 8) & 0xFF,
				(F_CPU >> 16) & 0xFF,
				(F_CPU >> 24) & 0xFF,
				(F_CPU >> 32) & 0xFF,
				(F_CPU >> 40) & 0xFF,
				(F_CPU >> 48) & 0xFF,
				(F_CPU >> 56) & 0xFF,
				GCC_VERSION & 0xFF,
				(GCC_VERSION >> 8) & 0xFF,
				(GCC_VERSION >> 16) & 0xFF,
				(GCC_VERSION >> 24) & 0xFF,
				ARDUINO & 0xFF,
				(ARDUINO >> 8) & 0xFF,
				(ARDUINO >> 16) & 0xFF,
				(ARDUINO >> 24) & 0xFF,
				DTP_VERSION & 0xFF,
				(DTP_VERSION >> 8) & 0xFF,
				(DTP_VERSION >> 16) & 0xFF,
				(DTP_VERSION >> 24) & 0xFF,
				//TODO написать нормальное определени€ подключени€ устройств.
				1,
				1,
				_FLASH_MEMORY_ & 0xFF,
				(_FLASH_MEMORY_ >> 8) & 0xFF,
				(_FLASH_MEMORY_ >> 16) & 0xFF,
				(_FLASH_MEMORY_ >> 24) & 0xFF,
				_SRAM_MEMORY_ & 0xFF,
				(_SRAM_MEMORY_ >> 8) & 0xFF,
				(_SRAM_MEMORY_ >> 16) & 0xFF,
				(_SRAM_MEMORY_ >> 24) & 0xFF
			};
			break;
		}

		case DTP_COMMANDTYPE::GetDateTime:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::DATA;
			dataBytesLen = 7;
			delete[] dataBytes;
			byte* temp = SplitNumber(year());
			dataBytes = new byte[7]
			{
				hour(),
				minute(),
				second(),
				day(),
				month(),
				temp[0],
				temp[1]
			};
			delete[] temp;
			break;
			//„асы, минуты, секунды, день, мес€ц, год
		}
	}
#ifdef DEBUG
	debugFILE.print("ANSWER STATUS: ");
	debugFILE.println((uint32_t)status);
	debugFILE.print("ANSWER DATA TYPE: ");
	debugFILE.println((uint32_t)error_code);
	debugFILE.print("dataBytesLen: ");
	debugFILE.println(dataBytesLen);
#endif
#pragma region CreatingAnswerPacket
#ifndef OptimizeSendrerBytes
	byte* commandAnsw = new byte[2]{ 19, 1 };
	byte* senderData = new byte[8]{ (byte)DTP_SENDERTYPE::SevenByteName, 68,116,112,67,108,110,116 };
#endif
	int TotalDataLen;
	byte* TotalData;
	byte* commandByte = SplitNumber((int)command);
	if (error_code == DTP_ANSWER_ERRORCODE_TYPE::CODE)
	{
		delete[] dataBytes;
		dataBytes = new byte[5]{ commandByte[0], commandByte[1], (byte)status, (byte)error_code, dataByte };
		dataBytesLen = 5;
	}
	else if (error_code == DTP_ANSWER_ERRORCODE_TYPE::DATA)
	{
		dataBytesLen += 4;
		byte* tempByteArray = new byte[dataBytesLen];
		memcpy(tempByteArray + 4, dataBytes, dataBytesLen - 4);
		tempByteArray[0] = commandByte[0];
		tempByteArray[1] = commandByte[1];
		tempByteArray[2] = (byte)status;
		tempByteArray[3] = (byte)error_code;
		delete[] dataBytes;
		dataBytes = new byte[dataBytesLen];
		memcpy(dataBytes, tempByteArray, dataBytesLen);
		delete[] tempByteArray;
	}
	else
	{
		delete[] dataBytes;
		dataBytes = new byte[4]{ commandByte[0], commandByte[1], (byte)status, (byte)error_code };
		dataBytesLen = 4;
	}
	TotalDataLen = 14 + dataBytesLen;
	TotalData = new byte[TotalDataLen];
	byte* len = SplitNumber(TotalDataLen + 255);
	byte* crc = ComputeChecksumBytes(dataBytes, dataBytesLen);

	memcpy(TotalData, len, 2);
	memcpy(TotalData + 2, commandAnsw, 2);
	memcpy(TotalData + 4, senderData, 8);
	memcpy(TotalData + 12, dataBytes, dataBytesLen);
	memcpy(TotalData + 12 + dataBytesLen, crc, 2);
	if (Serial.write(TotalData, TotalDataLen) != TotalDataLen)
	{
		Error(ERROR_CANT_SEND_FULL_PACKET);
#ifdef DEBUG
		debugFILE.println("CANT SEND FULL PACKET");
	}
	else debugFILE.println("OK!");
	debugFILE.close();
#else
	}
#endif
#ifdef PacketDebugInfo
	File ff = SD.open("packetDebug.txt", FILE_WRITE);
	ff.print("Packet #");
	ff.println(ii);
	ff.print("--Len is: ");
	ff.print(TotalDataLen);
	ff.print(' ');
	ff.print(len[0]);
	ff.print(' ');
	ff.println(len[1]);
	ff.print("--DataLen: ");
	ff.println(dataBytesLen);
	ff.print("--Command: ");
	ff.println(command);
	for (int i = 0; i < TotalDataLen; i++)
	{
		ff.print(TotalData[i]);
		ff.print(',');
	}
	ff.close();
#endif

#ifndef OptimizeSendrerBytes
	delete[] commandAnsw;
	delete[] senderData;
#endif
	delete[] commandByte;
	delete[] len;
	delete[] TotalData;
	delete[] dataBytes;
	delete[] crc;
#pragma endregion

}

void setup()
{
	pinMode(RelayPin, OUTPUT);
	digitalWrite(RelayPin, 1);

	pinMode(SpeakerPinPower, OUTPUT);
	pinMode(SDCSPin, OUTPUT);
	Serial.begin(115200);
	if (!SD.begin(SDCSPin, SPI_FULL_SPEED)) {
		Error(ERROR_SD_INITSDCARD);
		return;
	}
	PLOTTER_INIT();
	tmElements_t tm;
	if (!RTC.read(tm))
		if (!RTC.chipPresent()) {
			Error(ERROR_TIMEMODULE_CANTINIT);
			return;
		}
	SdFile::dateTimeCallback(dateTime);
	analogWrite(ErrorLedPower, 0);
	delay(100);
	analogWrite(ErrorLedPower, 255);
}

void loop() 
{
	int before = FreeMemory();
	Read();
	if (before != FreeMemory()) Error(ERROR_LOST_MEMORY);

	if (ReqToStartPrint)
	{
		PLOTTER_RUN(String(PrintFileName) + ".v", ElevDelta, ElevCorr, XCoef, YCoef);
		ReqToStartPrint = false;
	} 
}

static const uint32_t crc_32_tab[] PROGMEM = { /* CRC polynomial 0xedb88320 */
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

uint32_t crc32(File &file, uint32_t &charcnt)
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
