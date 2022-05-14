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
    public partial class AddStuff : Form
    {
        public AddStuff(SQLDB DB)
        {
            InitializeComponent();
            this.DB = DB;
        }
        private SQLDB DB;
        private void addSotrud_Click(object sender, EventArgs e) // Добавление сотрудника
        {
            int id;
            if (DB.Staff)
            {
                if (int.TryParse(textBoxID.Text, out id))
                {
                    DB.CommandDB($"insert into library_staff (id_staff, Staff_Name, Staff_Surname, Staff_Patronymic, _address, post) values ('{id}', '{textBoxName.Text}', '{textBoxSur.Text}', '{textBoxPerf.Text}', '{textBoxAdress.Text}', '{textBoxPost.Text}')", true);
                    MessageBox.Show("Запись успешно создана");
                }
                else { MessageBox.Show("Неправильное заполнение"); }
            }
            else  // Добавление клиента
            {
                if (int.TryParse(textBoxID.Text, out id))
                {
                    DB.CommandDB($"insert into Client (id_client, Client_Name, Client_Surname, Client_Patronymic, telephone) values ('{id}', '{textBoxName.Text}', '{textBoxSur.Text}', '{textBoxPerf.Text}', '{textBoxAdress.Text}')", true);
                    MessageBox.Show("Запись успешно создана");
                }
                else { MessageBox.Show("Неправильное заполнение"); }
            }
        }

        private void AddStuff_Load(object sender, EventArgs e) // Костыль для изменения внешнего вида формы и функционала 
        {
            if (DB.Staff)
            {
                label5.Text = "Добавление сотрудника";
            }
            else
            {
                label5.Text = "Добавление клиент";
                label4.Text = "Телефон";
                textBoxPost.Location = new Point(-1000, textBoxPost.Location.Y);
                label6.Location = new Point(-1000, label6.Location.Y);
            }
        }
    }
}
