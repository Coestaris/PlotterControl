using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TsudaKageyu;

namespace CnC_WFA
{
    public partial class Form_Dialog_Assoc : Form
    {
        public Form_Dialog_Assoc()
        {
            InitializeComponent();
        }

        private string[] Discr =
        {
            ".PCV - основной формат векторных рисунков. Его можно получить либо с помощью векторизации изображения, либо с помощью редактора",
            ".PCVDOC - формат векторных документов, которые в последствии можно преобразовать в вектор.",
            ".PRRES",
            ".PCMACROS",
            ".PCMPACK",
            ".PCGRAPH"
        };


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChLB.SelectedIndex != -1) label_discr.Text = Discr[ChLB.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int diff = 0;
            List<string> log = new List<string>();
            for (int i = 0; i <= ChLB.Items.Count - 1; i++)
            {
                if (current[i] != startStatus[i])
                {
                    diff++;
                    FileAssociation.AssocDeleteFailReason err;
                    if (current[i])
                    {
                        if (!FileAssociation.DeleteAssociation((FileAssociation.FileFormats)(i), out err)) log.Add("Невозможно удалить ассоциацию. Причина: " + err.ToString());
                    }
                    else if (!FileAssociation.RegisterAssociation((FileAssociation.FileFormats)(i))) log.Add("Невохможно установить ассоцииацию");
                }
            }
            if (log.Count != 0) MessageBox.Show(string.Join("\n", log), "Ассоциации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("Успешно установленно\\удаленно " + diff + " ассоциаций", "Ассоциации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form_Dialog_Assoc_Load(null, null);
        }

        CheckedImageListBox ChLB;

        private void Form_Dialog_Assoc_Load(object sender, EventArgs e)
        {
            IconExtractor ie = new IconExtractor("Lib\\IconSet.dll");

            ie.GetIcon((int)FileAssociation.IconIndex.Icon_PCV).ToBitmap();

            ChLB = new CheckedImageListBox()
            {
                Location = new Point(12, 12),
                Size = new Size(404, 124),
                ImageSize = new Size(15, 15),
                Font = new Font("Cambria", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204),
                BackColor = Color.White
            };

            ChLB.AddItem(".PCV", ie.GetIcon((int)FileAssociation.IconIndex.Icon_PCV).ToBitmap());
            ChLB.AddItem(".PCVDOC", ie.GetIcon((int)FileAssociation.IconIndex.Icon_PCVDOC).ToBitmap());
            ChLB.AddItem(".PRRES", ie.GetIcon((int)FileAssociation.IconIndex.Icon_PRRES).ToBitmap());
            ChLB.AddItem(".PCMACROS", ie.GetIcon((int)FileAssociation.IconIndex.Icon_Macros).ToBitmap());
            ChLB.AddItem(".PCMPACK", ie.GetIcon((int)FileAssociation.IconIndex.Icon_MacroPack).ToBitmap());
            ChLB.AddItem(".PCGRAPH", ie.GetIcon((int)FileAssociation.IconIndex.Icon_PCGraph).ToBitmap());

            Controls.Add(ChLB); 

            ChLB.ItemCheck += checkedListBox_ItemCheck;
            ChLB.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;

            startStatus = FileAssociation.GetUnidentifiedAssoc();
            current = FileAssociation.GetUnidentifiedAssoc();
            for (int i = 0; i <= ChLB.Items.Count - 1; i++)
                ChLB.SetItemChecked(i, !startStatus[i]);
            button_save.Enabled = false;
            if (!current.Contains(true))
            {
                selectStatus = true;
                button_selectAll.Text = "Снять выделение";
            }
            else
            {
                selectStatus = false;
                button_selectAll.Text = "Выделить всё";
            }
        }

        private bool selectStatus = false;

        private List<bool> startStatus, current;

        private void button2_Click(object sender, EventArgs e)
        {
            selectStatus = !selectStatus;
            if (selectStatus) button_selectAll.Text = "Снять выделение";
            else button_selectAll.Text = "Выделить всё";
            for (int i = 0; i <= ChLB.Items.Count - 1; i++)
                ChLB.SetItemChecked(i, selectStatus);
        }

        private bool SkipCloseCheck = false;

        private void button_exit_Click(object sender, EventArgs e)
        {
            if (button_save.Enabled)
            {
                if (MessageBox.Show("Желаете выйти без сохранения изменений?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SkipCloseCheck = true;
                    Close();
                }
            }
            else
            {
                SkipCloseCheck = true;
                Close();
            }
        }

        private void Form_Dialog_Assoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SkipCloseCheck) if (button_save.Enabled) if (MessageBox.Show("Желаете выйти без сохранения изменений?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
        }

        private void label_discr_Click(object sender, EventArgs e)
        {
            ((Control)sender).Focus();
        }

        private void Form_Dialog_Assoc_Click(object sender, EventArgs e)
        {
            ((Control)sender).Focus();
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            current[e.Index] = e.NewValue == CheckState.Unchecked;
            button_save.Enabled = !Enumerable.SequenceEqual(current, startStatus);
        }
    }

    public class CheckedImageListBox : CheckedListBox
    {
        private void Init()
        {
            Images = new List<Image>();
            MouseClick += ProccedMouse;
            LostFocus += CheckedImageListBox_LostFocus;
        }

        private void CheckedImageListBox_LostFocus(object sender, EventArgs e)
        {
            SelectedIndex = -1;
        }

        public void AddItem(string Caption, Image img)
        {
            if (Images == null) Init();
            Items.Add(Caption);
            Images.Add(img);
        }

        public Size ImageSize { get; set; }
        public List<Image> Images { get; set; }

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
            string s = Items[e.Index].ToString();
            int nX = e.Bounds.X + 2;
            int nY = e.Bounds.Y + 2;
            Graphics g = e.Graphics;
            Rectangle oCheckBoxRectangle = new Rectangle(nX, nY, 10, 10);
            if (e.State.HasFlag(DrawItemState.Selected)) g.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 4));
            else g.FillRectangle(new SolidBrush(SystemColors.Control), e.Bounds);

            g.DrawRectangle(new Pen(Color.Black, 2), oCheckBoxRectangle);
            if (GetItemChecked(e.Index))
            {
                g.DrawString(s, Font, new SolidBrush(Color.Black), e.Bounds.X + ImageSize.Width + 15 + 5, e.Bounds.Y + 1);
                g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), oCheckBoxRectangle.X + 2, oCheckBoxRectangle.Y + 2, 6, 6);
            }
            else
            {
                g.DrawString(s, Font, new SolidBrush(Color.Gray), e.Bounds.X + ImageSize.Width + 15 + 5, e.Bounds.Y + 1);
                g.FillRectangle(new SolidBrush(Color.White), oCheckBoxRectangle.X + 2, oCheckBoxRectangle.Y + 2, 6, 6);
            }
            g.DrawImage(Images[e.Index], new Rectangle(new Point(e.Bounds.X + 15, e.Bounds.Y), ImageSize));
        }
    }
}


