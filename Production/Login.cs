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
    public partial class Login : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        public string ID = string.Empty;
        public Login()
        {
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
            string output = string.Empty;
            MySqlOperations.Select_Text(MySqlQueries.Select_Avtorizaciya, ref output, null, textBox1.Text, textBox2.Text);
            if (output == "1")
            {
                MySqlOperations.Select_Text(MySqlQueries.Select_User_Form, ref output, null, textBox1.Text, textBox2.Text);
                if (output == "")
                {
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
                else
                {
                    ID = output;
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
            else MessageBox.Show("Неверный логин или пароль.", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MySqlOperations.CloseConnection();
        }
    }
}
