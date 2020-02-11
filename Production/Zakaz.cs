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
        string ID = string.Empty;
        string ID_Org = string.Empty;

        public Zakaz()
        {
            InitializeComponent();
        }

        public Zakaz(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD, string iD_Org = null)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID = iD;
            ID_Org = iD_Org;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            MySqlOperations.Insert_Update(MySqlQueries.Insert_Zakaz, ID, date);
            groupBox1.Visible = true;
            groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            MySqlOperations.Insert_Update(MySqlQueries.Update_Zakaz, ID, ID_Org, date);
        }
    }
}
