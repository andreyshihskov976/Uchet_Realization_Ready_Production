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
    public partial class Zakazchik : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string ID_Org = string.Empty;
        string identify = string.Empty;

        public Zakazchik(string ID)
        {
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
            this.ID_Org = ID;
        }

        private void Zakazchik_Load(object sender, EventArgs e)
        {
            MySqlOperations.OpenConnection();
        }

        private void Zakazchik_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySqlOperations.CloseConnection();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Search(toolStripTextBox1, dataGridView1);
        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Product, dataGridView1);
            identify = "product";
        }

        private void отгруженныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Done_Zakaz_2, dataGridView1, ID_Org);
            identify = "done_zakaz";
        }

        private void ожидающиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Wait_Zakaz_2, dataGridView1, ID_Org);
            identify = "wait_zakaz";
        }

        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_All_Zakaz_2, dataGridView1,ID_Org);
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
            if (identify == "wait_zakaz")
            {
                Zakaz zakaz = new Zakaz(MySqlQueries, MySqlOperations, ID_Org);
                zakaz.button6.Visible = false;
                zakaz.button1.Visible = true;
                zakaz.AcceptButton = zakaz.button1;
                zakaz.dateTimePicker1.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
                zakaz.dateTimePicker1.MinDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                zakaz.dateTimePicker1.MaxDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                zakaz.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_Wait_Zakaz_2, dataGridView1, ID_Org);
            }
            else if (identify == "all_zakaz")
            {
                Zakaz zakaz = new Zakaz(MySqlQueries, MySqlOperations, ID_Org);
                zakaz.button6.Visible = false;
                zakaz.button1.Visible = true;
                zakaz.AcceptButton = zakaz.button1;
                zakaz.dateTimePicker1.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
                zakaz.dateTimePicker1.MinDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                zakaz.dateTimePicker1.MaxDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                zakaz.ShowDialog();
                MySqlOperations.Select_DataGridView(MySqlQueries.Select_All_Zakaz_2, dataGridView1, ID_Org);
            }
            else
                MessageBox.Show("Вставка записей в данноую таблицу невозможно.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Update_String()
        {
            if (dataGridView1.SelectedRows.Count <= 1 && dataGridView1.SelectedRows.Count > 0)
            {
                if (identify == "wait_zakaz")
                {
                    Zakaz zakaz = new Zakaz(MySqlQueries, MySqlOperations, ID_Org, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    zakaz.dateTimePicker1.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                    zakaz.dateTimePicker1.MinDate = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                    zakaz.dateTimePicker1.MaxDate = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                    zakaz.button1.Visible = false;
                    zakaz.button6.Visible = true;
                    zakaz.groupBox1.Visible = true;
                    zakaz.groupBox2.Visible = true;
                    zakaz.AcceptButton = zakaz.button6;
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_CUP, zakaz.dataGridView1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_GP, zakaz.dataGridView2, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    zakaz.ShowDialog();
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Wait_Zakaz_2, dataGridView1, ID_Org);
                }
                else if (identify == "all_zakaz")
                {
                    if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString() != "Отгружен")
                    {
                        Zakaz zakaz = new Zakaz(MySqlQueries, MySqlOperations, ID_Org, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        zakaz.dateTimePicker1.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                        zakaz.dateTimePicker1.MinDate = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                        zakaz.dateTimePicker1.MaxDate = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                        zakaz.button1.Visible = false;
                        zakaz.button6.Visible = true;
                        zakaz.groupBox1.Visible = true;
                        zakaz.groupBox2.Visible = true;
                        zakaz.AcceptButton = zakaz.button6;
                        MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_CUP, zakaz.dataGridView1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        MySqlOperations.Select_DataGridView(MySqlQueries.Select_Sostav_GP, zakaz.dataGridView2, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        zakaz.ShowDialog();
                        MySqlOperations.Select_DataGridView(MySqlQueries.Select_All_Zakaz_2, dataGridView1, ID_Org);
                    }
                    else
                        MessageBox.Show("Данный заказ уже отгружен со склада." + '\n' + "Редактирование невозможно.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Редактирование записей данной таблицы невозможно.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Delete_String()
        {
            if (MessageBox.Show("Желаете удалить выбранную запись(-и)?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (identify == "wait_zakaz")
                {
                    for(int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Delete(MySqlQueries.Delete_Zakaz, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Wait_Zakaz_2, dataGridView1, ID_Org);

                }
                else if (identify == "all_zakaz")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Delete(MySqlQueries.Delete_Zakaz, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_All_Zakaz_2, dataGridView1, ID_Org);

                }
                else if (identify == "done_zakaz")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        MySqlOperations.Delete(MySqlQueries.Delete_Zakaz, dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Done_Zakaz_2, dataGridView1, ID_Org);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 1 && dataGridView1.SelectedRows.Count > 0)
                if (identify == "wait_zakaz" || identify == "done_zakaz" || identify == "all_zakaz")
                {
                    MySqlOperations.Print_Zakaz(MySqlQueries, dataGridView2, saveFileDialog1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                    MessageBox.Show("Печать заказов из данной таблицы невозможно.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
