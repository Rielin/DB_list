using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOO_Povarenok
{
    public partial class ProductsView : Form
    {
        public ProductsView()
        {
            InitializeComponent();
        }

        private void ProductsView_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kadaevZachetDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.kadaevZachetDataSet.Product);

        }

        private void ProductsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = ProductsDGV.Rows[selectedRow];

                Description.Text = "Описание: "+ row.Cells[10].Value.ToString();
                Provider.Text = "Производитель: " + row.Cells[6].Value.ToString();
                Price.Text = "Цена: " + row.Cells[3].Value.ToString();
                DiscountLabel.Text = "Размер скидки: " + row.Cells[8].Value.ToString() +"%";

            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        (ProductsDGV.DataSource as DataTable).DefaultView.RowFilter = "";
                        break;
                    case 1:
                        (ProductsDGV.DataSource as DataTable).DefaultView.RowFilter = "productDiscountAmountDataGridViewTextBoxColumn <2";
                        break;
                    case 2:
                        (ProductsDGV.DataSource as DataTable).DefaultView.RowFilter = "productDiscountAmountDataGridViewTextBoxColumn >=3 and <=4";
                        break;
                    case 3:
                        (ProductsDGV.DataSource as DataTable).DefaultView.RowFilter = "productDiscountAmountDataGridViewTextBoxColumn >4";
                        break;
                }

            }
            catch { Exception ex;
                MessageBox.Show("Что-то пошло не так");
            }

            ///Summary
            ///Сортировка таблицы по скидке
            ///</Summary>
        }
    }
}
