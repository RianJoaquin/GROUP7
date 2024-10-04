using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class AddItem : UserControl
    {
        function1 fc = new function1();
        String query;
        public AddItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "Insert into item1 (name, category, price, Quantity) values ('" + textBox1.Text + "', '" + comboBox1.Text + "', " + textBox2.Text + ", " + textBox3.Text + ")";
            fc.setData(query);
            clearAll();
        }
        public void clearAll()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void AddItem_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddItem_Load(object sender, EventArgs e)
        {

        }
    }
}
