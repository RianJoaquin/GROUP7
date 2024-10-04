using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class UC_PlaceOrder : UserControl
    {
        function1 fc = new function1();
        String query;
        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void UC_PlaceOrder_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = comboBox1.Text;
            query = "select name from item1 where category = '" + category + "'";
            ItemList(query);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            String category = comboBox1.Text;
            query = "select name from item1 where category = '" + category + "' and name like '" + textBox1.Text + "'";
            ItemList(query);
        }

        private void ItemList(String query)
        {
            listBox1.Items.Clear();
            DataSet ds = fc.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.ResetText();
            textBox4.Clear();
            String text = listBox1.GetItemText(listBox1.SelectedItem);
            textBox2.Text = text;
            query = "select price from item1 where name = '" + text + "'";
            DataSet ds = fc.getData(query);
            try
            {
                textBox3.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(numericUpDown1.Value.ToString());
            Int64 pri = Int64.Parse(textBox3.Text);
            textBox4.Text = (quan * pri).ToString();
        }

        protected int n, total = 0;

        private void label8_Click(object sender, EventArgs e)
        {

        }

        int amount;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch
            {
            }
            total -= amount;
            label8.Text = "PHP. " + total;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "update item1 set Quantity = Quantity - " + numericUpDown1.Value.ToString() + " where name = '" + textBox2.Text + "'";
            fc.setData(query);

            DGVPrinter print = new DGVPrinter();
            print.Title = "Customer Bill";
            print.SubTitle = string.Format("Data: {0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total Payable Amount: " + label8.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(dataGridView1);

            total = 0;
            dataGridView1.Rows.Clear();
            label8.Text = "PHP. " + total;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            query = "select Quantity from item1 where name = '" + textBox2.Text + "'";
            DataSet ds = fc.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int quantity = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                if (quantity == 0)
                {
                    {
                        MessageBox.Show("Out of Stock", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (quantity < numericUpDown1.Value)
                {

                    MessageBox.Show("Your order exceed our stock, try to lower it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else if (quantity > 0)
                {
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[1].Value = textBox3.Text;
                    dataGridView1.Rows[n].Cells[2].Value = numericUpDown1.Value;
                    dataGridView1.Rows[n].Cells[3].Value = textBox4.Text.ToString();

                    total += int.Parse(textBox4.Text);
                    label8.Text = "PHP. " + total;
                }
                

                
                else
                {
                    MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
