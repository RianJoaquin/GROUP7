using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Finals
{
    public partial class Update : UserControl
    {
        function1 fc = new function1();
        String query;
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            
            loadData();
        }
        public void loadData() 

        {
            query = "select * from item1";
            DataSet ds = fc.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String name = textBox1.Text;

            query = "select * from item1 where name = '" + name + "'and name like '" + textBox1.Text + "'";
            DataSet ds = fc.getData(query);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string category = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            int Quantity = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            textBox2.Text = category;
            textBox3.Text = name;
            textBox4.Text = price.ToString();
            textBox5.Text = Quantity.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "update item1 set name='" + textBox3.Text + "', category='" + textBox2.Text + "', price=" + textBox4.Text + ", Quantity=" + textBox5.Text + " where id=" + id;
            fc.setData(query);
            loadData();

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
