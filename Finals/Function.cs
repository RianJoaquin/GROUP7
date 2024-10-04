using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Finals
{
    internal class Function
    {
        protected SqlConnection getSqlConnection()
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=LAPTOP-6MGE7P22\\SMMSQLSERVER;Initial Catalog=orderingsys;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            return conn;    
        }
        public DataSet getData(String query)
        {
            SqlConnection conn = getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet(); 
            adapter.Fill(ds);
            return ds;

        }

        public void setData(String query)
        {
            SqlConnection conn = getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = query;   
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Data Processed Successfully.","Succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

    }
}
