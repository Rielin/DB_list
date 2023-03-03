using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private Map map;
        private void button1_Click(object sender, EventArgs e)
        {
            map = new Map(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox2.Text));           
            map.Set(new Coordinates(0, 0), new Coordinates((Convert.ToInt32(textBox4.Text)-1), (Convert.ToInt32(textBox3.Text)-1))).Set(Convert.ToInt32(textBox1.Text)).Set(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2.Enabled = false;
            map.lol = lol.Checked;
            map.SetRange(Convert.ToInt32(textBox2.Text));
            map.Start(label1);
        }

    }
}
