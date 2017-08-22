/*=================================\
* CWA.DTP\Enums.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

namespace CWA.DTP
{
    public enum CardType
    {
        SD1 = 0x10,
        SD2 = 0x20,
        SDHC = 0x30,
        Unknown = 0x40
    };

    public enum Board
    {
        Yun,
        Uno,
        DueMulanove,
        Nano,
        Mega,
        Adk,
        Leonardo,
        LeonardoEth,
        Micro,
        Esplora,
        Mini,
        Ethernet,
        Fio,
        BT,
        LilypadUSB,
        Lilypad,
        Pro,
        NG,
        RobotControl,
        RobotMotor,
        Gemma,
        CircuitPlay,
        YunMini,
        Industrial101,
        LinioOne,
        UnoWifi,
        Unknown
    };

    public enum BoardArchitecture
    {
        AVR,
        ARM,
        I686,
        I586,
        Unknown
    };

    public enum SdCardFatType
    {
        FAT12 = 0xc,
        FAT16 = 0x10,
        FAT32 = 0x20,
    };
}
