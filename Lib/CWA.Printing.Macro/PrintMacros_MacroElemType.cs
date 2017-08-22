/*=================================\
* CWA.Printing.Macro\PrintMacros_MacroElemType.cs
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
    /// ��������� ��� �������.
    /// </summary>
    public enum MacroElemType
    {
        /// <summary>
        /// ������ ����������� ���� (�����/����).
        /// </summary>
        Tool,

        /// <summary>
        /// ����������� ����������� � ���������� �����.
        /// </summary>
        MoveToPoint,

        /// <summary>
        /// �������� ����������� �� �������� ������.
        /// </summary>
        MoveRelative,

        /// <summary>
        /// ������ ��������.
        /// </summary>
        Delay,

        /// <summary>
        /// ������ �� ������.
        /// </summary>
        None,

        /// <summary>
        /// ����������� ���� (�����/����) � ��������� �����.
        /// </summary>
        ToolAndDelay,

        /// <summary>
        /// ����������� ����������� � ���������� ����� � ��������� �����.
        /// </summary>
        MoveToPointAndDelay,

        /// <summary>
        /// ����������� ����������� � ���������� ����� � ��������� �����.
        /// </summary>
        MoveRelativeAndDelay
    }
}
