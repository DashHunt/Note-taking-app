using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_Taking_App
{
    public partial class Form1 : Form
    {
        DataTable table; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = 255;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool jaExiste = false;
            
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                if(dataGridView1.Rows[row].Cells[0].Value != null && txtTitle.Text == dataGridView1.Rows[row].Cells[0].Value.ToString())
                {
                    MessageBox.Show("Valor já existe");
                    jaExiste = true; 
                }
            }

            if(jaExiste == false)
            {
                if(txtMessage.Text != "")
                {
                    table.Rows.Add(txtTitle.Text, txtMessage.Text);
                    txtTitle.Clear();
                    txtMessage.Clear();
                }
                else
                {
                    MessageBox.Show("Mensagem em branco!");
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index > -1)
                {
                    txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                    txtMessage.Text = table.Rows[index].ItemArray[1].ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                table.Rows[index].Delete();
            }
            
        }
    }
}
