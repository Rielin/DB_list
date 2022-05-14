using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace LibraryDBEvolution
{
    public class SQLDB
    {
        public enum RowState // модификаторы для таблиц
        {
            Existed,
            New,
            Modified,
            ModifiedNew,
            Deleted
        }
        public SQLDB(string txt) // Штука для создания экземпляра класса
        {
            SQLConn = new SqlConnection(txt);
            if (SQLConn.State == ConnectionState.Open) { ConneUnever(); }
            SDA = new SqlDataAdapter();
            DataT = new DataTable();
            command = new SqlCommand("", SQLConn);
        }
        public SqlConnection SQLConn { get; set; }
        public SqlDataAdapter SDA { get; private set; }
        public DataTable DataT { get; private set; }
        private SqlCommand command { get; set; }
        public SqlDataReader record { get; set; }
        private int ComInfex { get; set; }
        public bool Staff;
        private object[] RowTxt;
        public void ConneUnever() // Штука для открытия/закрытия соеденения к sql
        {
            switch (SQLConn.State)
            {
                case ConnectionState.Open:
                    SQLConn.Close();
                    break;
                case ConnectionState.Closed:
                    SQLConn.Open();
                    break;
                default:
                    break;
            }
        }
        public int CommandDB(string Comm, bool Edit) // штука для передачи запроса в sql
        {
            command.CommandText = Comm;
            if (Edit)
            {
                ConneUnever();
                try { ComInfex = command.ExecuteNonQuery(); }
                catch { ComInfex = -1; }
                ConneUnever();
                return ComInfex;
            }
            SDA.SelectCommand = command;
            try { DataT.Clear();
            SDA.Fill(DataT); }
            catch { return -1; }
            return ComInfex = DataT.Rows.Count;
        }
        public void Update(DataGridView dgw, string DB) // Запрос для получение всей таблицы
        {
            dgw.Rows.Clear();
            command.CommandText = $"select * from {DB}";
            ConneUnever();
            record = command.ExecuteReader();
            GridEdit(dgw, record);
            record.Close();
            ConneUnever();
        }
        public void TabUpdate(DataGridView dgw, string DBName, string[] Tab)// Обновление таблицы
        {
            if (dgw.Rows.Count > 0)
            {
                int CelCou = dgw.Rows[0].Cells.Count - 1, TaLeng = Tab.Length;
                string[] txt = new string[CelCou];
                ConneUnever();
                foreach (DataGridViewRow DGVRC in dgw.Rows)
                {
                    if ((RowState)Convert.ToInt32(DGVRC.Cells[CelCou].Value) == RowState.Existed)
                    { continue; }
                    if ((RowState)Convert.ToInt32(DGVRC.Cells[CelCou].Value) == RowState.Deleted)
                    {
                        command.CommandText = $"delete from {DBName} where {Convert.ToInt32(Tab[0])}";
                        try { command.ExecuteNonQuery(); }
                        catch { MessageBox.Show($"Связи мешают удалить {DGVRC.Cells[1].Value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    if ((RowState)Convert.ToInt32(DGVRC.Cells[CelCou].Value) == RowState.Modified)
                    {
                        command.CommandText = $"update {DBName} set";
                        for (int i = 0; i < TaLeng; i++)
                        {
                            command.CommandText += $" {Tab[i]} = '{DGVRC.Cells[i].Value}'";
                            if (i < (TaLeng - 1))
                            { command.CommandText += ","; }
                        }
                        command.CommandText += $" where {Tab[0]} = '{DGVRC.Cells[0].Value}'";
                        command.ExecuteNonQuery();
                    }
                }
                ConneUnever();
            }
            else { Update(dgw, DBName); }
        }
        public void GridEdit(DataGridView dgw , SqlDataReader record) // Тут мы передаём модификатор, что таблица изменена 
        {
            //Не знаю как не использовать object
            RowTxt = new object[(record.FieldCount +1)];
            while (record.Read())
            {
                for (int i = 0; i < record.FieldCount; i++)
                {
                    RowTxt[i] = record.GetValue(i).ToString();
                }
                RowTxt[record.FieldCount] = RowState.Modified;
                dgw.Rows.Add(RowTxt);
            }
        }
        public void Search(DataGridView dgw, string txt, string DB ,string[] Tab) // Поиск внутри таблиц
        {
            dgw.Rows.Clear();
            command.CommandText = $"select * from {DB} where concat (";
            for (int i = 0;i < Tab.Length;i++)
            {
                command.CommandText += $"{Tab[i]}";
                if (i < (Tab.Length - 1))
                {
                    command.CommandText += ", ";
                }
            }
            command.CommandText += $") like '%{txt}%'";
            ConneUnever();
            record = command.ExecuteReader();
            GridEdit(dgw, record); 
            record.Close();
            ConneUnever();
        }
        public void Updata(List<Avtor> avtors) // listbox для инициалов в таблице Book_Author/Books_Info
        {
            avtors.Clear();
            command.CommandText = "select * from Book_Author";
            ConneUnever();
            record = command.ExecuteReader();
            while (record.Read()) { avtors.Add(new Avtor(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3))); }
            record.Close();
            ConneUnever();
        }
        public void Updata(List<Avtor> avtors, string txt) // Поиск для таблиц Book_Author
        {
            avtors.Clear();
            command.CommandText = $"select * from Book_Author where concat (id_Author, Author_Name, Author_Surname, Author_Patronymic) like '%{txt}%'";
            ConneUnever();
            record = command.ExecuteReader();
            while (record.Read()) { avtors.Add(new Avtor(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3))); }
            record.Close();
            ConneUnever();
        }
        public void BookGiveDell(int ID_Client,int ID_Book, int ID_Staff) // Удаление даты 
        { // Нужно доработать
            ConneUnever();
            command.CommandText = $"delete from Give_book where id_client = {ID_Client} or id_book = {ID_Book} or id_staff = {ID_Staff}";
            command.ExecuteNonQuery();
            ConneUnever();
        }
    }
}
