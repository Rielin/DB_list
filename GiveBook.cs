using System;
using System.Windows.Forms;

namespace LibraryDBEvolution
{
    public partial class GiveBook : Form
    {
        public GiveBook(SQLDB DB) // Меняем названия колонок на адекватные 
        {
            InitializeComponent();
            dataGridViewStaff2.Columns.Add("id_staff", "ID");
            dataGridViewStaff2.Columns.Add("Staff_Name", "Имя");
            dataGridViewStaff2.Columns.Add("Staff_Surname", "Фамилия");
            dataGridViewStaff2.Columns.Add("Staff_Patronymic", "Отчество");
            dataGridViewStaff2.Columns.Add("_address", "Адресс");
            dataGridViewStaff2.Columns.Add("post", "Пост");
            dataGridViewStaff2.Columns.Add("isNew", String.Empty);

            dataGridViewClient2.Columns.Add("id_client", "ID");
            dataGridViewClient2.Columns.Add("Clint_Name", "Имя");
            dataGridViewClient2.Columns.Add("Client_Surname", "Фамилия");
            dataGridViewClient2.Columns.Add("Client_Patronymic", "Отчество");
            dataGridViewClient2.Columns.Add("telephone", "Телефон");
            dataGridViewClient2.Columns.Add("isNew", String.Empty);

            dataGridViewBook2.Columns.Add("id_book", "ID Book");
            dataGridViewBook2.Columns.Add("id_author", "ID Author");
            dataGridViewBook2.Columns.Add("Book_name", "Название");
            dataGridViewBook2.Columns.Add("_Availability", "В Нал");
            dataGridViewBook2.Columns.Add("isNew", String.Empty);
            this.DB = DB;

            dataGridViewDataClient.Columns.Add("id_client", "ID Client");
            dataGridViewDataClient.Columns.Add("id_book", "ID Book");
            dataGridViewDataClient.Columns.Add("id_staff", "ID Staff");
            dataGridViewDataClient.Columns.Add("return_date", "До");
            dataGridViewDataClient.Columns.Add("date_of_issue", "От");
        }
        private SQLDB DB;
        private int DGV1 = -1, DGV2 = -1, DGV3 = -1;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { DGV1 = e.RowIndex; }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        { DGV2 = e.RowIndex; }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        { DGV3 = e.RowIndex; }
        private void GiveBook_Load(object sender, EventArgs e)
        {
            Uadate();
        }
        private void DellDataBookButton_Click(object sender, EventArgs e) // Удаление книги у клиента
        {
            DB.BookGiveDell(Convert.ToInt32(dataGridViewDataClient.Rows[dataGridViewDataClient.CurrentCell.RowIndex].Cells[0].Value), Convert.ToInt32(dataGridViewDataClient.Rows[dataGridViewDataClient.CurrentCell.RowIndex].Cells[1].Value), Convert.ToInt32(dataGridViewDataClient.Rows[dataGridViewDataClient.CurrentCell.RowIndex].Cells[2].Value));
            dataGridViewDataClient.Rows.Clear();
            DB.Update(dataGridViewDataClient, "Give_book");
        }
        public void Uadate() // Обновление таблиц
        {
            dataGridViewStaff2.Rows.Clear();
            DB.Update(dataGridViewStaff2, "library_staff");
            dataGridViewClient2.Rows.Clear();
            DB.Update(dataGridViewClient2, "Client");
            dataGridViewBook2.Rows.Clear();
            DB.Update(dataGridViewBook2, "Books_info");
            dataGridViewDataClient.Rows.Clear();
            DB.Update(dataGridViewDataClient, "Give_book");
        }
        private void addGiveBookButton_Click(object sender, EventArgs e) // Добавление книги клиенту
        {
            if (DGV1 >= 0 && DGV2 >= 0 && DGV3 >= 0)
            {
                DB.CommandDB($"insert into Give_book (id_client, id_book, id_staff, return_date, date_of_issue) values ({dataGridViewClient2.Rows[DGV2].Cells[0].Value}, {dataGridViewBook2.Rows[DGV3].Cells[0].Value}, {dataGridViewStaff2.Rows[DGV1].Cells[0].Value},'{dateTimePicker2.Value:yyyy-MM-dd}', '{dateTimePicker1.Value:yyyy-MM-dd}')", true);
                DB.CommandDB($"update Books_info set _Availability = '{0}' where id_book = '{dataGridViewBook2.Rows[DGV3].Cells[0].Value}'", true);
                DB.Staff = false;
                dataGridViewClient2.Rows.Clear();
                DB.Update(dataGridViewClient2, "Book_Author");
                dataGridViewDataClient.Rows.Clear();
                DB.Update(dataGridViewDataClient, "Give_book");
            }
            else { MessageBox.Show($"Нужно выбрать столбец{kek()}"); }
        }
        private string kek()
        {
            string txt = "";
            if (DGV1 >= 0)
            { txt = " левый"; }
            if (DGV2 >= 0)
            { txt = " в середине"; }
            if (DGV3 >= 0)
            { txt = " справо"; }
            return txt;
        }
    }
}
