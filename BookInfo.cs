using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBEvolution
{
    public partial class BookInfo : Form
    {
        public BookInfo(SQLDB DB) // Меняем столбцы на адекватные названия
        {
            InitializeComponent();
            dataGridViewAuthor.Columns.Add("id_Author", "ID");
            dataGridViewAuthor.Columns.Add("Author_Name", "Имя");
            dataGridViewAuthor.Columns.Add("Author_Surname", "Фамилия");
            dataGridViewAuthor.Columns.Add("Author_Patronymic", "Отчество");
            dataGridViewAuthor.Columns.Add("isNew", String.Empty);
            this.DB = DB;
            avtors = new List<Avtor>();
            dataGridViewBook.Columns.Add("id_book", "ID Book");
            dataGridViewBook.Columns.Add("id_author", "ID Author");
            dataGridViewBook.Columns.Add("Book_name", "Название");
            dataGridViewBook.Columns.Add("_Availability", "В Нал");
            dataGridViewBook.Columns.Add("isNew", String.Empty);
        }

        private SQLDB DB;
        private int index;
        public List<Avtor> avtors;
        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(textBoxID.Text, out id) && textBoxName.Text != "" && textBoxPatr.Text != "" && textBoxSur.Text != "")
            {
                DB.CommandDB($"insert into Book_Author (id_Author, Author_Name, Author_Surname, Author_Patronymic ) values ({id}, '{textBoxName.Text}', '{textBoxPatr.Text}', '{textBoxSur.Text}')", true);
                DB.Update(dataGridViewAuthor, "Book_Author");
                UpdataListA();
            }
        }

        private void buttonChangeAuthor_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthor.Rows[dataGridViewAuthor.CurrentCell.RowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewAuthor.Rows[dataGridViewAuthor.CurrentCell.RowIndex].SetValues(textBoxID.Text, textBoxName.Text, textBoxSur.Text, textBoxPatr.Text, 2);
            }
        }

        private void buttonDelAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                index = dataGridViewAuthor.CurrentCell.RowIndex;
                if (dataGridViewAuthor.CurrentCell.RowIndex >= 0)
                { dataGridViewAuthor.Rows[index].Cells[4].Value = 4; }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void UpdataListA() // Обновление листбокса Авторов
        {
            DB.Updata(avtors);
            listBox1.Items.Clear();
            for (int i = 0; i < avtors.Count; i++)
            { listBox1.Items.Add(avtors[i].ToString()); }
        }
        private void buttonSaveAuthor_Click(object sender, EventArgs e)
        {
            DB.TabUpdate(dataGridViewAuthor, "Book_Author", new string[] { "id_Author", "Author_Name", "Author_Surname", "Author_Patronymic" });
            DB.Update(dataGridViewAuthor, "Book_Author");
            UpdataListA();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Записываем в тексбоксы данные из таблицы по клику на неё
        {
            textBoxID.Text = dataGridViewAuthor.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewAuthor.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxSur.Text = dataGridViewAuthor.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxPatr.Text = dataGridViewAuthor.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIDbook.Text = dataGridViewBook.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxNameBook.Text = dataGridViewBook.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridViewBook.Rows[e.RowIndex].Cells[3].Value.ToString() == "Да")
            { checkBox1.Checked = true; }
            else { checkBox1.Checked = false; }
        }
        private void BookInfo_Load(object sender, EventArgs e) // Добавляем данные в таблицы 
        {
            dataGridViewAuthor.Rows.Clear();
            DB.Update(dataGridViewAuthor, "Book_Author");
            dataGridViewBook.Rows.Clear();
            DB.Update(dataGridViewBook,"Books_info");
            DB.Updata(avtors);
            listBox1.Items.Clear();
            for (int i = 0; i < avtors.Count;i++)
            {  listBox1.Items.Add(avtors[i].ToString()); }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e) // Мега крутой поиск
        {
            DB.Updata(avtors, textBoxSearch.Text);
            listBox1.Items.Clear();
            for (int i = 0; i < avtors.Count; i++)
            { listBox1.Items.Add(avtors[i].ToString()); }
        }

        private void ButtonAdd_Click(object sender, EventArgs e) // Добавляем книгу
        {
            int id;
            if (int.TryParse(textBoxIDbook.Text, out id)&& listBox1.SelectedIndex >= 0 && textBoxNameBook.Text != "")
            {
                DB.CommandDB($"insert into Books_info (id_book, id_author, Book_name, _Availability) values ({id},{avtors[listBox1.SelectedIndex].ID},'{textBoxNameBook.Text}', '{Convert.ToByte(checkBox1.Checked)}' )", true);
                DB.Update(dataGridViewBook, "Books_info");
            }
        }

        private void buttonChange_Click(object sender, EventArgs e) // Меняем книгу 
        {
            if (dataGridViewBook.Rows[dataGridViewBook.CurrentCell.RowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewBook.Rows[dataGridViewBook.CurrentCell.RowIndex].SetValues(textBoxIDbook.Text, avtors[listBox1.SelectedIndex].ID, textBoxNameBook.Text, Convert.ToByte(checkBox1.Checked), 2);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e) // Удаляем книгу
        {
            try
            {
                index = dataGridViewBook.CurrentCell.RowIndex;
                if (dataGridViewBook.CurrentCell.RowIndex >= 0)
                { dataGridViewAuthor.Rows[index].Cells[4].Value = 4; }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void buttonSave_Click(object sender, EventArgs e) // Сохраняем кигу
        {
            DB.TabUpdate(dataGridViewBook, "Books_info", new string[] { "id_book", "id_author", "Book_Name", "_Availability" });
            DB.Update(dataGridViewBook, "Books_info");
        }
    }
}
