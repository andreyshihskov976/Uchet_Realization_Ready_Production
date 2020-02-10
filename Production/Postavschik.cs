using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production
{
    public partial class Postavschik : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID = string.Empty;
        string identify = string.Empty;
        public Postavschik()
        {
            InitializeComponent();
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sklad, dataGridView1);
            identify = "sklad";
        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Product, dataGridView1);
            identify = "product";
        }

        private void заказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);
            identify = "organizacii";
        }

        private void Postavschik_Load(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
        }

        private void Postavschik_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySqlOperations.CloseConnection();
        }
    }
}
