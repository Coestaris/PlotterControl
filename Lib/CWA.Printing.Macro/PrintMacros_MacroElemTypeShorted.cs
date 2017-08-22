/*=================================\
* CWA.Printing.Macro\PrintMacros_MacroElemTypeShorted.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 01.07.2017 13:09:58
*=================================*/

namespace CWA.Printing.Macro
{
    /// <summary>
    /// ��������� ��� �������, � ����������� ����, ������� ��� �������� � �����. 
    /// ��� �������� - ����������� ��������� ������������ MacroElemType.
    /// </summary>
    public enum MacroElemTypeShorted
    {
        /// <summary>
        /// ����������: MacroElemType.Tool. ������ ����������� ���� (�����/����).
        /// </summary>
        T,

        /// <summary>
        /// ����������: MacroElemType.MoveToPoint. ����������� ����������� � ���������� �����.
        /// </summary>
        MTP,

        /// <summary>
        /// ����������: MacroElemType.MoveRelative. �������� ����������� �� �������� ������.
        /// </summary>
        MR,

        /// <summary>
        /// ����������: MacroElemType.Delay. ������ ��������.
        /// </summary>
        D,

        /// <summary>
        /// ����������: MacroElemType.None. ������ �� ������.
        /// </summary>
        N,

        /// <summary>
        /// ����������: MacroElemType.ToolAndDelay. ����������� ���� (�����/����) � ��������� �����.
        /// </summary>
        TAD,

        /// <summary>
        /// ����������: MacroElemType.MoveToPointAndDelay. ����������� ����������� � ���������� ����� � ��������� �����.
        /// </summary>
        MTPAD,

        /// <summary>
        /// ����������: MacroElemType.MoveRelativeAndDelay. ����������� ����������� � ���������� ����� � ��������� �����.
        /// </summary>
        MRAD
    }
}
