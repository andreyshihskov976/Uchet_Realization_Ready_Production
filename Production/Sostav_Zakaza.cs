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
    public partial class Sostav_Zakaza : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID = string.Empty;
        public Sostav_Zakaza()
        {
            InitializeComponent();
        }

        public Sostav_Zakaza(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string output = string.Empty;
                MySqlOperations.Select_Text(MySqlQueries.Select_Product_ID, ref output, null, comboBox1.Text);
                MySqlOperations.Insert_Update(MySqlQueries.Insert_Sostav_Zakaza, ID, output, numericUpDown1.Value.ToString().Replace(',','.').ToString());
                this.Close();
            }
            else
                MessageBox.Show("Выберите продукцию.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
