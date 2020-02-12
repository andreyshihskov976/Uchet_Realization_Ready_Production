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
    public partial class Product : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID = string.Empty;

        public Product()
        {
            InitializeComponent();
        }

        public Product(MySqlQueries mySqlQueries, MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlQueries = mySqlQueries;
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlQueries.Select_Sklad_ComboBox, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "")
            {
                MySqlOperations.Insert_Update(MySqlQueries.Insert_Product, null, MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_Sklad_ID, comboBox1.Text), textBox1.Text, comboBox2.Text, textBox2.Text.Replace(',','.'));
                this.Close();
            }
            else
                MessageBox.Show("Поля не заполнены.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "")
            {
                MySqlOperations.Insert_Update(MySqlQueries.Update_Product, ID, MySqlOperations.Select_ID_From_ComboBox(MySqlQueries.Select_Sklad_ID, comboBox1.Text), textBox1.Text, comboBox2.Text, textBox2.Text.Replace(',', '.'));
                this.Close();
            }
            else
                MessageBox.Show("Поля не заполнены.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
