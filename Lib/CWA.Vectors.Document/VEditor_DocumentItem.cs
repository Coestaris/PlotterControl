/*=================================\
* CWA.Vectors.Document\VEditor_DocumentItem.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 22.08.2017 20:22:36
*=================================*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CWA.Vectors.Document
{
    /// <summary>
    /// Абстрактный класс объектов векторных документов.
    /// </summary>
    public abstract class DocumentItem : ICloneable
    {
        /// <summary>
        /// Угол наклона объекта относительно центра в градусах.
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// Цвет отображения в редакторе.
        /// </summary>
        public Color DispColor { get; set; }

        /// <summary>
        /// Представления объекта в виде класса <see cref="GraphicsPath"/>.
        /// </summary>
        public GraphicsPath GrPath { get; set; }

        /// <summary>
        /// Имя объекта. В документе обязано быть уникально!
        /// Так как ни кто за этим не следит (ни какой класс), то будьте внимательны.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Позиция объекта в документе.
        /// </summary>
        public PointF Position { get; set; }

        /// <summary>
        /// Размер объекта (в большинсте случаях устанавливается сам).
        /// </summary>
        public SizeF Size { get; set; }

        /// <summary>
        /// Тип объекта.
        /// </summary>
        public DocumentItemType Type { get; set; }

        /// <summary>
        /// Рисовать ли в редакторе данный объект цветом <see cref="DispColor"/>.
        /// </summary>
        public bool UseDispColor { get; set; }

        /// <summary>
        /// Клонирует объект.
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Рендерит объект. Метод обезательный к применению, после внесения изменений.
        /// </summary>
        public virtual void PreRender()
        {
            PreRenderPath();
            var m = new Matrix();
            m.RotateAt(Angle / 2, new PointF(Size.Width / 2 + Position.X, Size.Height / 2 + Position.Y));
            GrPath.Transform(m);
        }

        /// <summary>
        /// Рендерит объект в виде <see cref="GraphicsPath"/>.
        /// </summary>
        public virtual void PreRenderPath()
        {
            GrPath = null;
        }

        /// <summary>
        /// Возвращает єкливалентный 
        /// </summary>
        /// <returns></returns>
        public virtual GraphicsPath Render()
        {
            return GrPath;
        }

        /// <summary>
        /// Сравнивает объект с данным.
        /// </summary>
        /// <param name="obj">Второй объект для сравнения.</param>
        /// <returns>true елси они одинаковы.</returns>
        public override bool Equals(object obj)
        {
            var item = obj as DocumentItem;
            if (Name == item.Name && Position == item.Position && Type == item.Type && Size == item.Size &&
                Angle == item.Angle) return true;
            return false;
        }

        /// <summary>
        /// Возвращает хеш-код типа.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
