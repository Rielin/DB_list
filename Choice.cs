using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LibraryDBEvolution
{
    public partial class Choice : Form // Форма с переходом на разные таблицы
    {
        public Choice()
        {
            InitializeComponent();
        }
        public Choice(SQLDB DB)
        {
            InitializeComponent();
            this.DB = DB;
            staffAnd = new StaffAndClient(DB, true);
            clientAnd = new StaffAndClient(DB, false);
            bookInfo = new BookInfo(DB);
            giveBook = new GiveBook(DB);
        }
        public StaffAndClient staffAnd;
        public StaffAndClient clientAnd;
        public BookInfo bookInfo;
        public SQLDB DB;
        public GiveBook giveBook;
        private void staffBT_Click(object sender, EventArgs e)
        {
            DB.Staff = true;
            Hide();
            staffAnd.ShowDialog();
            while (staffAnd.Modal)
            {
                Thread.Sleep(10);
            }
            Show();
        }

        private void ClientInfoBT_Click(object sender, EventArgs e)
        {
            DB.Staff = false;
            Hide();
            clientAnd.ShowDialog();
            while (staffAnd.Modal)
            {
                Thread.Sleep(10);
            }
            Show();
        }

        private void BookInfoBT_Click(object sender, EventArgs e)
        {
            DB.Staff = false;
            Hide();
            bookInfo.ShowDialog();
            while (bookInfo.Modal)
            {
                Thread.Sleep(10);
            }
            Show();
        }

        private void GiveBookBT_Click(object sender, EventArgs e)
        {
            DB.Staff = false;
            Hide();
            giveBook.ShowDialog();
            while (giveBook.Modal)
            {
                Thread.Sleep(10);
            }
            Show();
        }
    }
}
