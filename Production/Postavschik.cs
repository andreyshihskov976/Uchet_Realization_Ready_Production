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
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
        }

        private void Postavschik_Load(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
        }

        private void Postavschik_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySqlOperations.CloseConnection();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Search(toolStripTextBox1, dataGridView1);
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

        private void заявкиНаОтгрузкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Zayavka, dataGridView1);
            identify = "zayavka";
        }

        private void отгруженныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Done_Zakaz, dataGridView1);
            identify = "done_zakaz";
        }

        private void ожидающиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Wait_Zakaz, dataGridView1);
            identify = "wait_zakaz";
        }

        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_All_Zakaz, dataGridView1);
            identify = "all_zakaz";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Insert_String();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Update_String();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete_String();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insert_String();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_String();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_String();
        }

        private void Insert_String()
        {
            if (identify == "sklad")
            {
                Sklad sklad = new Sklad(MySqlQueries, MySqlOperations);
                sklad.button3.Visible = false;
                sklad.button1.Visible = true;
                sklad.AcceptButton = sklad.button1;
                sklad.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sklad, dataGridView1);
            }
            else if (identify == "product")
            {
                Product product = new Product(MySqlQueries, MySqlOperations);
                product.button3.Visible = false;
                product.button1.Visible = true;
                product.AcceptButton = product.button1;
                product.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Product, dataGridView1);
            }
            else if (identify == "organizacii")
            {
                Organizacii organizacii = new Organizacii(MySqlQueries, MySqlOperations);
                organizacii.button3.Visible = false;
                organizacii.button1.Visible = true;
                organizacii.AcceptButton = organizacii.button1;
                organizacii.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);
            }
        }

        private void Update_String()
        {
            if (dataGridView1.SelectedRows.Count <= 1)
            {
                if (identify == "sklad")
                {
                    Sklad sklad = new Sklad(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    sklad.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    sklad.button1.Visible = false;
                    sklad.button3.Visible = true;
                    sklad.AcceptButton = sklad.button3;
                    sklad.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sklad, dataGridView1);
                }
                else if (identify == "product")
                {
                    Product product = new Product(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), product.comboBox1);
                    product.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), product.comboBox2);
                    product.button1.Visible = false;
                    product.button3.Visible = true;
                    product.AcceptButton = product.button1;
                    product.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Product, dataGridView1);
                    
                }
                else if (identify == "organizacii")
                {
                    Organizacii organizacii = new Organizacii(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    organizacii.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    organizacii.textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    organizacii.button1.Visible = false;
                    organizacii.button3.Visible = true;
                    organizacii.AcceptButton = organizacii.button1;
                    organizacii.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);

                }
            }
        }

        private void Delete_String()
        {
            if (MessageBox.Show("Желаете удалить выбранную запись(-и)?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (identify == "sklad")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        MySqlOperations.Delete(MySqlQueries.Delete_Sklad, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sklad, dataGridView1);
                }
                else if (identify == "product")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        MySqlOperations.Delete(MySqlQueries.Delete_Product, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Product, dataGridView1);
                }
                else if (identify == "organizacii")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        MySqlOperations.Delete(MySqlQueries.Delete_Organizacii, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Organizacii, dataGridView1);
                }
                else if (identify == "zayavka")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        MySqlOperations.Delete(MySqlQueries.Delete_Zayavka, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Zayavka, dataGridView1);
                }
            }
        }

        private void оформитьЗаявкуНаОтгрузкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (identify == "wait_zakaz" && dataGridView1.SelectedRows.Count <= 1)
            {
                Zayavka zayavka = new Zayavka(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_GP, zayavka.dataGridView1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_CUP, zayavka.dataGridView2, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                zayavka.button1.Visible = true;
                zayavka.button6.Visible = false;
                zayavka.AcceptButton = zayavka.button1;
                zayavka.ShowDialog();
            }
            else
                MessageBox.Show("Для оформления заявки необходимо открыть список заказов, ожидающих отгрузки, и выбрать заказ, на основании которого необхдимо оформить заявку.", "Информация", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void оформитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (identify == "wait_zakaz" && dataGridView1.SelectedRows.Count <= 1)
            {
                Zayavka zayavka = new Zayavka(MySqlQueries, MySqlOperations, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_GP, zayavka.dataGridView1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_CUP, zayavka.dataGridView2, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                zayavka.button1.Visible = true;
                zayavka.button6.Visible = false;
                zayavka.AcceptButton = zayavka.button1;
                zayavka.ShowDialog();
            }
            else
                MessageBox.Show("Для оформления заявки необходимо открыть список заказов, ожидающих отгрузки, и выбрать заказ, на основании которого необхдимо оформить заявку.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
