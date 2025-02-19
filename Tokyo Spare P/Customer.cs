using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Tokyo_Spare_P
{
    public partial class Customer : UserControl
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-OMAVF85;Initial Catalog=tokyo_spare;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        int id = 0;
        private void dispalydata()
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from customer", cn);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            cn.Close();
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            dispalydata();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
             cn.Open();
            SqlCommand cnn = new SqlCommand("insert into customer values ("+txtId.Text+",'"+txtName.Text+"',"+txtPhone.Text+",'"+txtAderss.Text+"','"+gunaDateTimePicker1.Value+"')",cn);
             cnn.ExecuteNonQuery();
             MessageBox.Show("Message saved");
             cn.Close();
             dispalydata();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cc = new SqlCommand("update customer set c_name ='"+txtName.Text+"', s_phone = "+txtPhone.Text+", c_adderss = '"+txtAderss.Text+"', data = '"+gunaDateTimePicker1.Value+"' where c_id = "+txtId.Text+"",cn);
            cc.ExecuteNonQuery();
            MessageBox.Show("date update");
            cn.Close();
            dispalydata();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAderss.Clear();
            
        }
    }
}
