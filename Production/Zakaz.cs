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
    public partial class Zakaz : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID_Org = string.Empty;
        string ID_Zakaza = string.Empty;

        public Zakaz()
        {
            InitializeComponent();
        }

        public Zakaz(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD_Org = null, string iD_Zakaza = null)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID_Org = iD_Org;
            ID_Zakaza = iD_Zakaza;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            MySqlOperations.Insert_Update(MySqlQueries.Insert_Zakaz, ID_Org, date);
            MySqlOperations.Select_Text(MySqlQueries.Select_Last_Insert, ref ID_Zakaza);
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_CUP, dataGridView1, ID_Zakaza);
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_GP, dataGridView2, ID_Zakaza);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sostav_Zakaza sostav_Zakaza = new Sostav_Zakaza(MySqlQueries, MySqlOperations, ID_Zakaza);
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Product_ComboBox_CUP, sostav_Zakaza.comboBox1);
            sostav_Zakaza.ShowDialog();
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_CUP, dataGridView1, ID_Zakaza);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                MySqlOperations.Delete(MySqlQueries.Delete_Sostav_Zakaza, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_CUP, dataGridView1, ID_Zakaza);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sostav_Zakaza sostav_Zakaza = new Sostav_Zakaza(MySqlQueries, MySqlOperations, ID_Zakaza);
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Product_ComboBox_GP, sostav_Zakaza.comboBox1);
            sostav_Zakaza.ShowDialog();
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_GP, dataGridView2, ID_Zakaza);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
                MySqlOperations.Delete(MySqlQueries.Delete_Sostav_Zakaza, dataGridView2.SelectedRows[i].Cells[0].Value.ToString());
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_GP, dataGridView2, ID_Zakaza);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            MySqlOperations.Insert_Update(MySqlQueries.Update_Zakaz, ID_Zakaza, ID_Org, date);
        }
    }
}
