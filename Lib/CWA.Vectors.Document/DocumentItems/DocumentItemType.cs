/*=================================\
* CWA.Vectors.Document\DocumentItemType.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:32
* Last Edited: 01.07.2017 13:09:58
*=================================*/

namespace CWA.Vectors.Document
{
    /// <summary>
    /// ��������� ��� �������.
    /// </summary>
    public enum DocumentItemType
    {
        /// <summary>
        /// ����������� (������).
        /// </summary>
        Image,

        /// <summary>
        /// ������. ���� ��� ������� ������, �� �������� ������ SubType ��������� ��� ��� �� ������.
        /// </summary>
        Shape,

        /// <summary>
        /// ��������� ������ ��� �����.
        /// </summary>
        Text
    }
}
