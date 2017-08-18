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
* PlotterControl \ Helper.cs
*
* Created: 17.06.2017 21:04
* Last Edited: 01.07.2017 13:09:58
*
*=================================*/

using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Helper
{
    public abstract class Helper
    {
        public static void Wr<T>(T[][] arr)
        {
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                for (int ii = 0; ii <= arr[i].Length - 1; ii++)
                {
                    if (ii != arr[i].Length - 1)
                    {
                        Console.Write(arr[i][ii].ToString());
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.Write(arr[i][ii].ToString());
                        Console.Write(";");
                    }
                }
                if (i != arr.Length - 1) Console.WriteLine();
            }
        }

        public static void Swap<t>(ref t t1, ref t t2)
        {
            var tm = t1;
            t1 = t2;
            t2 = tm;
        }

        public static T[] Arr<T>(params T[] el)
        {
            return el;
        }

        public static void InsertToArray<T>(ref T[] arr, T em)
        {
            if (arr == null) arr = new T[0];
            var l = arr.ToList();
            l.Add(em);
            arr = l.ToArray();
        }

        public static long GCD(long x, long y)
        {
            return y == 0 ? x : GCD(y, x % y);
        }

        public static float Distance(Point a, Point b)
        {
            return (float)Math.Sqrt((a.X - a.X) * (a.X - a.X) + (a.Y - a.Y) * (a.Y - a.Y));
        }

        public static void ConcatArrays<T>(ref T[] a, ref T[] b)
        {
            if (a == null) a = new T[0];
            if (b == null) b = new T[0];
            var l = a.ToList();
            l.AddRange(b);
            a = l.ToArray();
        }

        public static void DeleteFromArray<T>(int count, ref T[] ar)
        {
            if (count == 0) throw new ArgumentException("Count cant be 0", nameof(count));
            if (count > ar.Length) throw new ArgumentException("Count cant be > ar.Length()");
            var l = ar.ToList();
            l.RemoveAt(count - 1);
            ar = l.ToArray();
        }

        public static bool IfIn<T>(T em, T[] arr)
        {
            return arr.Contains(em);
        }

        public static byte GetAverageColor(Color c)
        {
            return (byte)((c.R + c.B + c.G) / 3);
        }

        public static Color NewOneChColor(byte b)
        {
            return Color.FromArgb(b, b, b);
        }

    }

}

namespace CnC_WFA
{

    public class CheckedImageListBox : CheckedListBox
    {
        private void Init()
        {
            Images = new List<Image>();
            MouseClick += ProccedMouse;
            LostFocus += CheckedImageListBox_LostFocus;
            InactiveImages = new List<Image>();
        }

        private void CheckedImageListBox_LostFocus(object sender, EventArgs e)
        {
            SelectedIndex = -1;
        }

        public void AddItem(string Caption, Image img)
        {
            if (Images == null) Init();
            Items.Add(Caption);
            Images.Add(new Bitmap(img, ImageSize));
            InactiveImages.Add(vl.AverageGrayForm(new Bitmap(Images.Last())));
        }

        private CWA.Vectors.VectLib vl = new CWA.Vectors.VectLib();
        public Size ImageSize { get; set; }
        public List<Image> Images { get; set; }
        public List<Image> InactiveImages { get; set; }

        public void ProccedMouse(object sender, MouseEventArgs e)
        {
            int LineIndex = -1;
            int iHeight = GetItemHeight(0);
            for (int i = 0; i < Items.Count; i++)
                if (e.Y > iHeight * i && e.Y < iHeight * (i + 1))
                    LineIndex = i;
            SelectedItems.Clear();
            if (e.X > 15)
                if (LineIndex != -1) SetItemChecked(LineIndex, !GetItemChecked(LineIndex));
            SelectedIndex = LineIndex;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Items.Count == 0) return;
            string s = Items[e.Index].ToString();
            int nX = e.Bounds.X + 2;
            int nY = e.Bounds.Y + 2;
            Graphics g = e.Graphics;
            Rectangle oCheckBoxRectangle = new Rectangle(nX, nY, 10, 10);
            if (e.State.HasFlag(DrawItemState.Selected)) g.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 4));
            else g.FillRectangle(new SolidBrush(Color.White), e.Bounds);

            g.DrawRectangle(new Pen(Color.Black, 2), oCheckBoxRectangle);
            if (GetItemChecked(e.Index))
            {
                g.DrawString(s, Font, new SolidBrush(Color.Black), e.Bounds.X + ImageSize.Width + 15 + 5, e.Bounds.Y + 1);
                g.FillRectangle(new SolidBrush(Color.Blue), oCheckBoxRectangle.X + 2, oCheckBoxRectangle.Y + 2, 6, 6);
                g.DrawImage(Images[e.Index], new Point(e.Bounds.X + 15, e.Bounds.Y));
            }
            else
            {
                g.DrawString(s, Font, new SolidBrush(Color.Gray), e.Bounds.X + ImageSize.Width + 15 + 5, e.Bounds.Y + 1);
                g.FillRectangle(new SolidBrush(Color.White), oCheckBoxRectangle.X + 2, oCheckBoxRectangle.Y + 2, 6, 6);
                g.DrawImage(InactiveImages[e.Index], new Point(e.Bounds.X + 15, e.Bounds.Y));
            }
        }
    }


    public partial class ImageListBox : ListBox
    {
        private int m_LastItemCount;
        private int m_LastClientWidth;
        private int m_LastImageSize;
        private int m_MaxStringHeigth;
        private ImageList m_ImageList;

        public ImageList ImageList
        {
            get { return m_ImageList; }
            set
            {
                m_ImageList = value;
            }
        }

        public ImageListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            ImageListBoxItem item = e.Index < 0 || this.DesignMode ? null : Items[e.Index] as ImageListBoxItem;
            bool draw = m_ImageList != null && (item != null);

            if (draw)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();

                Size imageSize = m_ImageList.ImageSize;
                if (this.ItemHeight != imageSize.Height + 2) this.ItemHeight = imageSize.Height + 2;

                CheckHorizonalScroll(e.Graphics, e.Font);

                Rectangle bounds = e.Bounds;
                string strTextToDraw = item.ToString();
                Color color = e.ForeColor;

                if (item.ImageIndex > -1 && item.ImageIndex < m_ImageList.Images.Count)
                {
                    m_ImageList.Draw(e.Graphics, bounds.Left, bounds.Top, item.ImageIndex);
                    if (item.Color != Color.Empty) color = item.Color;
                }

                e.Graphics.DrawString(strTextToDraw, e.Font, new SolidBrush(color), /*bounds.Left*/0 + imageSize.Width, bounds.Top + (int)((this.ItemHeight - m_MaxStringHeigth) / 2));
            }
            else
            {
                base.OnDrawItem(e);
            }
        }

        private void CheckHorizonalScroll(Graphics g, Font f)
        {
            int maxStringWidth = 0;
            int maxStringHeight = 0;
            foreach (object item in Items)
            {
                string s = item.ToString();
                SizeF size = g.MeasureString(s, f);
                if (maxStringHeight < size.Height) maxStringHeight = (int)size.Height;
                if (maxStringWidth < size.Width) maxStringWidth = (int)size.Width;
            }

            m_LastImageSize = m_ImageList.ImageSize.Width;
            m_LastClientWidth = ClientSize.Width;
            m_LastItemCount = Items.Count;
            m_MaxStringHeigth = maxStringHeight;

            int he = maxStringWidth + m_LastImageSize;
            if (HorizontalExtent != he) HorizontalExtent = he;

        }

        public class ImageListBoxItem
        {
            private int m_ImageIndex;
            private object m_Item;
            private Color m_Color;

            public int ImageIndex
            {
                get { return m_ImageIndex; }
                set { m_ImageIndex = value; }
            }

            public object Item
            {
                get { return m_Item; }
                set { m_Item = value; }
            }

            public Color Color
            {
                get { return m_Color; }
                set { m_Color = value; }
            }

            public ImageListBoxItem() : this(null) { }

            public ImageListBoxItem(object item) : this(-1, item) { }

            public ImageListBoxItem(int imageIndex, object item) : this(imageIndex, Color.Empty, item) { }

            public ImageListBoxItem(int imageIndex, Color color, object item)
            {
                m_ImageIndex = imageIndex;
                m_Color = color;
                m_Item = item;
            }

            public override string ToString()
            {
                if (m_Item == null) return "Null";
                return m_Item.ToString();
            }
        }
    }
}
