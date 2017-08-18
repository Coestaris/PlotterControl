/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:


	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.


	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.Printing.Macro \ PrintMacros_MacroElem.cs
*
* Created: 17.06.2017 21:03
* Last Edited: 18.08.2017 20:23:26
*
*=================================*/

using System.Drawing;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// ��������� ������� �������.
    /// </summary>
    public class MacroElem
    {
        /// <summary>
        /// ����������� MacroElemType � MacroElemTypeShorted.
        /// </summary>
        /// <param name="t">��������� ������ MacroElemType.</param>
        public static MacroElemTypeShorted NormalToShorted(MacroElemType t)
        {
            switch (t)
            {
                case (MacroElemType.Tool): return MacroElemTypeShorted.T;
                case (MacroElemType.MoveToPoint): return MacroElemTypeShorted.MTP;
                case (MacroElemType.MoveRelative): return MacroElemTypeShorted.MR;
                case (MacroElemType.Delay): return MacroElemTypeShorted.D;
                case (MacroElemType.None): return MacroElemTypeShorted.N;
                case (MacroElemType.ToolAndDelay): return MacroElemTypeShorted.TAD;
                case (MacroElemType.MoveToPointAndDelay): return MacroElemTypeShorted.MTPAD;
                case (MacroElemType.MoveRelativeAndDelay): return MacroElemTypeShorted.MRAD;
                default: return MacroElemTypeShorted.T;
            }
        }

        /// <summary>
        /// ����������� MacroElemTypeShorted � MacroElemType.
        /// </summary>
        /// <param name="t">��������� ������ MacroElemTypeShorted.</param>
        public static MacroElemType ShortedTypeToNormal(MacroElemTypeShorted t)
        {
            switch (t)
            {
                case (MacroElemTypeShorted.T): return MacroElemType.Tool;
                case (MacroElemTypeShorted.MTP): return MacroElemType.MoveToPoint;
                case (MacroElemTypeShorted.MR): return MacroElemType.MoveRelative;
                case (MacroElemTypeShorted.D): return MacroElemType.Delay;
                case (MacroElemTypeShorted.N): return MacroElemType.None;
                case (MacroElemTypeShorted.TAD): return MacroElemType.ToolAndDelay;
                case (MacroElemTypeShorted.MTPAD): return MacroElemType.MoveToPointAndDelay;
                case (MacroElemTypeShorted.MRAD): return MacroElemType.MoveRelativeAndDelay;
                default: return MacroElemType.None;
            }
        }

        /// <summary>
        /// ��������������� ��� ��������.
        /// </summary>
        public string StringType
        {
            get
            {
                switch (Type)
                {
                    case (MacroElemType.Delay): return "Wait " + Delay + " ms";
                    case (MacroElemType.MoveRelative): return string.Format("Offset Tool on [X: {0}, Y: {1}]", MoveRelative.X, MoveRelative.Y);
                    case (MacroElemType.MoveRelativeAndDelay): return string.Format("Offset Tool on [X: {0}, Y: {1}] and Wait {2}", MoveRelative.X, MoveRelative.Y, Delay);
                    case (MacroElemType.MoveToPoint): return string.Format("Move tool on point [X: {0}, Y: {1}]", MoveToPoint.X, MoveToPoint.Y);
                    case (MacroElemType.MoveToPointAndDelay): return string.Format("Move tool on point [X: {0}, Y: {1}] and Wait {2} ms", MoveToPoint.X, MoveToPoint.Y, Delay);
                    case (MacroElemType.None): return "Empty Event";
                    case (MacroElemType.Tool):
                        if (ToolMove == GlobalOptions.StepHeightConst) return "Tool Up";
                        else if (ToolMove == -GlobalOptions.StepHeightConst) return "Tool Down";
                        if (ToolMove > 0) return string.Format("Move Tool Up to {0} steps", ToolMove);
                        else if (ToolMove < 0) return string.Format("Move Tool Down to {0} steps", -ToolMove);
                        else return "Empty Event";
                    case (MacroElemType.ToolAndDelay):
                        if (ToolMove == GlobalOptions.StepHeightConst) return "Tool Up and Wait " + Delay + "ms";
                        else if (ToolMove == -GlobalOptions.StepHeightConst) return "Tool Down and Wait " + Delay + "ms";
                        if (ToolMove > 0) return string.Format("Move Tool Up to {0} steps and Wait {1} ms", ToolMove, Delay);
                        else if (ToolMove < 0) return string.Format("Move Tool Down to {0} steps and Wait {1} ms", -ToolMove, Delay);
                        else return "Wait " + Delay + " ms";
                    default: return "Something goes Wrong :\"";
                }
            }
        }

        /// <summary>
        /// ��� ��������.
        /// </summary>
        public MacroElemType Type { get; set; }

        /// <summary>
        /// ����������� � ���������� �����.
        /// </summary>
        public int ToolMove { get; set; }

        /// <summary>
        /// ����������� � ���������� �����.
        /// </summary>
        public PointF MoveToPoint { get; set; }

        /// <summary>
        /// ������������� ��������.
        /// </summary>
        public PointF MoveRelative { get; set; }

        /// <summary>
        /// �������� ����� ���������� ��������� �������� � ��.
        /// </summary>
        public float Delay { get; set; }

        /// <summary>
        /// ����������� ��������� � ���������� ������������� (���������� ��������  <see cref="StringType"/>).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return StringType;
        }
    }
}
