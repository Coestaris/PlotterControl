/*=================================\
* CWA.Vectors.Document\VEditor_DocumentBorder.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 01.07.2017 13:09:58
*=================================*/

using System;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// ������������� ���������� � ������� ���������.
    /// </summary>
    public class DocumentBorder : ICloneable
    {
        /// <summary>
        /// ����� ������� �� ���� ���������.
        /// </summary>
        public float Offset { get; set; }

        /// <summary>
        /// ����� �������.
        /// </summary>
        public DocumentBorderStyle Style { get; set; }

        /// <summary>
        /// ������������ �� �������.
        /// </summary>
        public bool Use { get; set; }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="DocumentBorder"/>.
        /// </summary>
        /// <param name="offset">����� ������� �� ����� ���������.</param>
        /// <param name="style"> ����� �������.</param>
        /// <param name="use">������������ �� �������.</param>
        public DocumentBorder(float offset, DocumentBorderStyle style, bool use)
        {
            Offset = offset;
            Style = style;
            Use = use;
        }

        /// <summary>
        /// ������� ����� ��������� ������ <see cref="DocumentBorder"/>.
        /// </summary>
        public DocumentBorder() { }

        /// <summary>
        /// ��������� ������ ���������.
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
