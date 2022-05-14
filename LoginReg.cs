using System;
using System.Threading;
using System.Windows.Forms;

namespace LibraryDBEvolution
{
    public partial class LoginReg : Form
    {
        public LoginReg()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox_pass.PasswordChar = '*'; // Скрытие пароля
            textBox_pass.MaxLength = 500;
            textBox_login.MaxLength = 500;
        }
        private SQLDB DB = new SQLDB(@"Data Source =DESKTOP-M4IOCDE\SQLEXPRESS;Initial Catalog=library;Integrated Security=True");
        private void Log_Click(object sender, EventArgs e) // Функция авторизации, если нет аккаунта, то предложит создать
        {
            if (textBox_login.Text != "" && textBox_pass.Text != "")
            {
                switch (DB.CommandDB($"select id_user, login_user, password_user from register where login_user = '{textBox_login.Text}' and password_user = '{textBox_pass.Text}'", false))
                {
                    case 0:
                        if (MessageBox.Show("Такого аккаунта не существует.\nЗарегистрироватся?", "Bad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (DB.CommandDB($"select id_user, login_user, password_user from register where login_user = '{textBox_login.Text}' and password_user = '{textBox_pass.Text}'", false) > 0)
                            { MessageBox.Show("Пользователь уже существует"); }
                            else if (DB.CommandDB($"insert into register(login_user, password_user) values ('{textBox_login.Text}', '{textBox_pass.Text}')", true) == 1)
                            { MessageBox.Show("Аккаунт успешно создан", "Успех");
                                For();
                            }
                            else { MessageBox.Show("Аккаунт не удалось создать"); }
                        }
                        break;
                    case 1:
                        MessageBox.Show("Вы успешно вошли", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        For();
                        break;
                    default:
                        MessageBox.Show("Неправильное веденние команды", "=(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                } }
            else { MessageBox.Show("Не должно быть пустых полей", "=(", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void For()
        {
            Hide();
            Choice che = new Choice(DB);
            che.ShowDialog();
            while (che.Modal)
            {
                Thread.Sleep(10);
            }
            Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
