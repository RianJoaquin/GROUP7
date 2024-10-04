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
    public partial class dashboard : Form
    {
        

        public dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            addItem1.Visible = false;
            uC_PlaceOrder1.Visible = false;
            update1.Visible = false;
            remove1.Visible = false;   
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uC_PlaceOrder1.Visible = true;
            uC_PlaceOrder1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addItem1.Visible = true;
            addItem1.BringToFront();
        }

        private void addItem1_Load(object sender, EventArgs e)
        {
           
        }

        private void uC_PlaceOrder1_Load(object sender, EventArgs e)
        {

        }

        private void addItem1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            update1.Visible = true;
            update1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            remove1.Visible = true;
            remove1.BringToFront();

        }

        private void uC_PlaceOrder1_Load_1(object sender, EventArgs e)
        {

        }

        private void remove1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void remove1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
