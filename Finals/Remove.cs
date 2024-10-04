using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class Remove : UserControl
    {
        function1 fc = new function1();
        String query;
        public Remove()
        {
            InitializeComponent();
        }

        private void Remove_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Delete Item?", "Important Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK) 
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from item1 where id = " + id + "";
                fc.setData(query);
                loadData();

            }
        }
    }
}
