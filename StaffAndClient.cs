using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBEvolution
{
    public partial class StaffAndClient : Form
    {
        public StaffAndClient(SQLDB DB, bool Staff) // Меняем столбцы в dataGridView на адекватные
        {
            InitializeComponent();
            this.DB = DB;
            if (Staff)
            {
                dataGridView1.Columns.Add("id_staff", "ID");
                dataGridView1.Columns.Add("Staff_Name", "Имя");
                dataGridView1.Columns.Add("Staff_Surname", "Фамилия");
                dataGridView1.Columns.Add("Staff_Patronymic", "Отчество");
                dataGridView1.Columns.Add("_address", "Адресс");
                dataGridView1.Columns.Add("post", "Пост");
                dataGridView1.Columns.Add("isNew", String.Empty);
                addStuff = new AddStuff(DB);
            }
            else
            {
                dataGridView1.Columns.Add("id_client", "ID");
                dataGridView1.Columns.Add("Clint_Name", "Имя");
                dataGridView1.Columns.Add("Client_Surname", "Фамилия");
                dataGridView1.Columns.Add("Client_Patronymic", "Отчество");
                dataGridView1.Columns.Add("telephone", "Телефон");
                dataGridView1.Columns.Add("isNew", String.Empty);
                label6.Text = "Телефон";
                textBoxPost.Location = new Point(-1000, textBoxPost.Location.Y);
                label7.Location = new Point(-1000, textBoxPost.Location.Y);
                addStuff = new AddStuff(DB);
            }
        }
        private AddStuff addStuff;
        private SQLDB DB;
        private int index;
        private void buttonNew_Click(object sender, EventArgs e) // Загрузка формы добавления
        {
            addStuff.ShowDialog();
            while (addStuff.Modal)
            {
                Thread.Sleep(10);
            }
            RefreshDataGrid();
        }
        private void RefreshDataGrid() // 
        {
            dataGridView1.Rows.Clear();
            if (DB.Staff)
            { DB.TabUpdate(dataGridView1, "library_staff", new string[] { "id_staff", "Staff_Name", "Staff_Surname", "Staff_Patronymic", "_address", "post", }); }
            else { DB.TabUpdate(dataGridView1, "Client", new string[] { "id_client", "Client_Name", "Client_Surname", "Client_Patronymic", "telephone" }); }
        }
        private void DeleteRow() // Присваивание столбцам модификатора "Удален"
        {
            try
            {
                index = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    dataGridView1.Rows[index].Visible = false; //скрытие их до момента, пока пользователь не нажмёт "Сохранить"
                    if (DB.Staff) { dataGridView1.Rows[index].Cells[6].Value = 4; }
                    else { dataGridView1.Rows[index].Cells[5].Value = 4; }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void ClearFields() //Метод для отчищения текстбоксов после удаления 
        {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxSur.Text = "";
            textBoxPatr.Text = "";
            textBoxAdress.Text = "";
            textBoxPost.Text = "";
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            DeleteRow();
            ClearFields();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
        private void buttonChange_Click(object sender, EventArgs e) // Присваиваем модификатор Change 
        {
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (DB.Staff)
                {
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].SetValues(textBoxID.Text, textBoxName.Text, textBoxSur.Text, textBoxPatr.Text, textBoxAdress.Text, textBoxPost.Text);
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value = 2;
                }
                else 
                {
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].SetValues(textBoxID.Text, textBoxName.Text, textBoxSur.Text, textBoxPatr.Text, textBoxAdress.Text, 4);
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value = 2;
                }
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e) // Супер крутой поиск, который спамит запросами
        {
            if (DB.Staff)
            { DB.Search(dataGridView1, textBoxSearch.Text, "library_staff", new string[] { "id_staff", "Staff_Name", "Staff_Surname", "Staff_Patronymic", "_address", "post"}); }
            else { DB.Search(dataGridView1, textBoxSearch.Text, "Client", new string[] { "id_client", "Client_Name", "Client_Surname", "Client_Patronymic", "telephone"}); }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // При нажатии на какой-то столбец, записывает все данные из таблицы в текстбоксы для последущего взаимодействия с ними
        {
            if (e.RowIndex >= 0)
            {
                if (DB.Staff)
                {
                    textBoxID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBoxSur.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBoxPatr.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBoxAdress.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBoxPost.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
                else
                {
                    textBoxID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBoxSur.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBoxPatr.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBoxAdress.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }
        }
        private void StaffAndClient_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
