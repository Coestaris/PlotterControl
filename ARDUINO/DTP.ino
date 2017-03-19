#pragma once

#include "DTP.h"

File WriteFile;
bool isOpenFile;

int ii = 0;

void HandlePacket(byte* data, int dataLen, uint16_t command) {
#pragma region Vars
	DTP_ANSWER_STATUS status;
	DTP_ANSWER_ERRORCODE_TYPE error_code;
	int dataByte = 0;
	byte* dataBytes = new byte[1];
	int dataBytesLen = 0;
#pragma endregion

	switch ((DTP_COMMANDTYPE)command)
	{
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
			unsigned char x;
			unsigned short crc = 0xFFFF;
			unsigned int length = WriteFile.size();
			for (int i = 0; i <= length; ++i)
			{
				int b = WriteFile.read();
				if (b == -1) 
				{
					status = DTP_ANSWER_STATUS::Error;
					dataBytesLen = 1;
					dataBytes = new byte[1]{ 2 };
					goto Exit;
				}
				x = crc >> 8 ^ b;
				x ^= x >> 4;
				crc = (crc << 8) ^ ((int)(x << 12)) ^ ((int)(x << 5)) ^ ((int)x);
			}
			byte* crc_;
			crc_ = SplitNumber(crc);
			dataBytesLen = 3;
			dataBytes = new byte[3]{ 0, crc_[0], crc_[1] };
			WriteFile.close();
			delete[] crc_;
			Exit : break;
		}

		case DTP_COMMANDTYPE::Test:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::NONE;
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
				if(f.isDir()) dataByte = 2;
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
			uint32_t startBlock = (data[3] << 24) | (data[2] << 16) | (data[1] << 8) | data[0];
			uint32_t length = (data[7] << 24) | (data[6] << 16) | (data[5] << 8) | data[4];
						
			WriteFile.seek(startBlock);
			byte* tmpBuff = new byte[length];

			int newLength = WriteFile.readBytes(tmpBuff, length);
			if(newLength == -1)
			{
				status = DTP_ANSWER_STATUS::Error;
				dataBytesLen = 1;
				dataBytes = new byte[1]{ 2 };
				break;
			};


			File f = SD.open("log11.txt", FILE_WRITE);
			f.print("Packet:");
			f.println(ii++);
			f.println(startBlock);
			f.println(length);
			f.println(newLength);
			f.close();

			dataBytesLen = newLength;
			dataBytes = new byte[newLength];
			memcpy(dataBytes, tmpBuff, newLength);
			delete[] tmpBuff;
			break;
		}

		case DTP_COMMANDTYPE::File_AppendDataToFile:
		{
			status = DTP_ANSWER_STATUS::OK;
			error_code = DTP_ANSWER_ERRORCODE_TYPE::CODE;
			if (isOpenFile && WriteFile.write(data, dataLen)!=-1) dataByte = 0; 
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
			if(!myFile)
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
	}

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

void setup() {
	pinMode(SpeakerPinPower, OUTPUT);
	pinMode(SDCSPin, OUTPUT);
	Serial.begin(115200);
	if (!SD.begin(SDCSPin, SPI_HALF_SPEED)) {
		Error(ERROR_SD_INITSDCARD);
		return;
	}

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

	File a = SD.open("dp.zip", FILE_READ);
	byte* buffer  = new byte[2000];
}

void loop() {
	int before = FreeMemory();
	Read();
	if (before != FreeMemory()) Error(ERROR_LOST_MEMORY);
}
