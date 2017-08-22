/*=================================\
* CWA.Vectors.Document\VEditor_DocumentBorderStyle.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 01.07.2017 13:09:58
*=================================*/

namespace CWA.Vectors.Document
{
    /// <summary>
    /// ��������� ��� ���������� ������� ���������.
    /// </summary>
    public enum DocumentBorderStyle
    {
        /// <summary>
        /// ������ (�� ����������).
        /// </summary>
        None,
        
        /// <summary>
        /// ������ �� ���������������� �����.
        /// </summary>
        Dot,

        /// <summary>
        /// ������ �� ���������������� ����.
        /// </summary>
        Dash,

        /// <summary>
        /// ������ �� ����������������, ���������� ����.
        /// </summary>
        LongDash,

        /// <summary>
        /// ������ �� ����������������, ������������ ���� � �����.
        /// </summary>
        DashDot,

        /// <summary>
        /// ���������� ������ �����.
        /// </summary>
        Default,

        /// <summary>
        /// ���������� ������� ������ �����.
        /// </summary>
        DoubleLine,

        /// <summary>
        /// ���������� ������� ������ �����.
        /// </summary>
        TripleLine,

        /// <summary>
        /// ���������� ��������� �����.
        /// </summary>
        Wave,

        /// <summary>
        /// ���������� ������� ��������� �����.
        /// </summary>
        DoubleWave,

        /// <summary>
        /// ��������� ������ ������������(����) � ����� ���������.
        /// </summary>
        Triangle,

        /// <summary>
        /// ��������� ������ ��������� ������������(����) � ����� ���������.
        /// </summary>
        DoubleTriangle
    }
}
