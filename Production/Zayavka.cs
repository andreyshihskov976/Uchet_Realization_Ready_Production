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
    public partial class Zayavka : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID_Zakaza = string.Empty;
        public string ID_Zayavki_GP = null;
        public string ID_Zayavki_CUP = null;

        public Zayavka()
        {
            InitializeComponent();
        }

        public Zayavka(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD_Zakaza = null)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID_Zakaza = iD_Zakaza;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            MySqlOperations.Insert_Update(MySqlQueries.Insert_Zayavka_GP, ID_Zakaza, date);
            MySqlOperations.Select_Text(MySqlQueries.Select_Last_Insert, ref ID_Zayavki_GP);
            MySqlOperations.Insert_Update(MySqlQueries.Insert_Zayavka_CUP, ID_Zakaza, date);
            MySqlOperations.Select_Text(MySqlQueries.Select_Last_Insert, ref ID_Zayavki_CUP);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                MySqlOperations.Insert_Update(MySqlQueries.Insert_Sostav_Zayavki, ID_Zayavki_GP, MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_Product_ID,dataGridView1.Rows[i].Cells[1].Value.ToString()), dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                MySqlOperations.Insert_Update(MySqlQueries.Insert_Sostav_Zayavki, ID_Zayavki_CUP, MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_Product_ID, dataGridView2.Rows[i].Cells[1].Value.ToString()), dataGridView2.Rows[i].Cells[2].Value.ToString());
            }
            MySqlOperations.Insert_Update(MySqlQueries.Update_Identify_Zakaz, ID_Zakaza);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            //MySqlOperations.Insert_Update(MySqlQueries, ID_Zakaza, date);
            //this.Close();
        }
    }
}
