/*=================================\
* CWA.Printing.Macro\MacroElem.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:37
* Last Edited: 01.07.2017 13:09:58
*=================================*/

using System.Drawing;

namespace CWA.Printing.Macro
{
    /// <summary>
    /// Описывает элемент макроса.
    /// </summary>
    public class MacroElem
    {
        /// <summary>
        /// Преобразует MacroElemType в MacroElemTypeShorted.
        /// </summary>
        /// <param name="t">Экземпляр класса MacroElemType.</param>
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
        /// Преобразует MacroElemTypeShorted в MacroElemType.
        /// </summary>
        /// <param name="t">Экземпляр класса MacroElemTypeShorted.</param>
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
        /// Форматированное имя элемента.
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
        /// Тип элемента.
        /// </summary>
        public MacroElemType Type { get; set; }

        /// <summary>
        /// Перемещение в конкретную точку.
        /// </summary>
        public int ToolMove { get; set; }

        /// <summary>
        /// Перемещение в конкретную точку.
        /// </summary>
        public PointF MoveToPoint { get; set; }

        /// <summary>
        /// Относительное смещение.
        /// </summary>
        public PointF MoveRelative { get; set; }

        /// <summary>
        /// Задержка после выполнения основного действия в МС.
        /// </summary>
        public float Delay { get; set; }

        /// <summary>
        /// Преобразует экземпляр к строковому представлению (возвращает свойство  <see cref="StringType"/>).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return StringType;
        }
    }
}
