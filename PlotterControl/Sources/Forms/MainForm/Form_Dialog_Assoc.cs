using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            ".CVF - основной формат векторных рисунков. Его можно получить либо с помощью векторизации изображения, либо с помощью редактора",
            ".VDOC - формат векторных документов, которые в последствии можно преобразовать в вектор.",
            ".PRRES",
            ".PCMACROS",
            ".PCMPACK"
        };


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(checkedListBox.SelectedIndex != -1) label_discr.Text = Discr[checkedListBox.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int diff = 0;
            List<string> log = new List<string>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (current[i] != startStatus[i])
                {
                    diff++;
                    FileAssociation.AssocDeleteFailReason err;
                    if (current[i])
                    {
                        if(!FileAssociation.DeleteAssociation((FileAssociation.FileFormats)(i + 1), out err)) log.Add("Невозможно удалить ассоциацию. Причина: " + err.ToString());
                    } else if (!FileAssociation.RegisterAssociation((FileAssociation.FileFormats)(i + 1))) log.Add("Невохможно установить ассоцииацию");
                }
            }
            if (log.Count != 0) MessageBox.Show(string.Join("\n", log), "Ассоциации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("Успешно установленно\\удаленно " + diff + " ассоциаций", "Ассоциации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form_Dialog_Assoc_Load(null, null);
        }

        private void Form_Dialog_Assoc_Load(object sender, EventArgs e)
        {
            startStatus = FileAssociation.GetUnidentifiedAssoc();
            current = FileAssociation.GetUnidentifiedAssoc(); 
            for (int i = 0; i <= checkedListBox.Items.Count - 1; i++)
                checkedListBox.SetItemChecked(i, !startStatus[i]);
            button_save.Enabled = false;
            if(!current.Contains(true))
            {
                selectStatus = true;
                button_selectAll.Text = "Снять выделение";
            } else
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
            for (int i = 0; i <= checkedListBox.Items.Count - 1; i++)
                checkedListBox.SetItemChecked(i, selectStatus);
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
           if(!SkipCloseCheck) if(button_save.Enabled) if (MessageBox.Show("Желаете выйти без сохранения изменений?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            current[e.Index] = e.NewValue == CheckState.Unchecked;
            button_save.Enabled = !Enumerable.SequenceEqual(current, startStatus);
        }
    }
}
