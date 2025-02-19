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
    public partial class Supplier : UserControl
    {
        public Supplier()
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
            da = new SqlDataAdapter("select * from supplier", cn);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            cn.Close();
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            dispalydata();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("insert into supplier values(" + txtID.Text + ", '" + txtNAME.Text + "', '" + txtADDERSS.Text + "', " + txtPHONE.Text + ",  '" + gunaDateTimePicker1.Value + "')", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Message saved");
            cn.Close();
            dispalydata();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cc = new SqlCommand("update supplier set s_name = '"+txtNAME.Text+"', s_adderss = '"+txtADDERSS.Text+"', phone = "+txtPHONE.Text+", data = '"+gunaDateTimePicker1.Value+"' where s_id = "+txtID.Text+"", cn);
            cc.ExecuteNonQuery();
            MessageBox.Show("date update");
            cn.Close();
            dispalydata();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmc = new SqlCommand("delete from supplier where s_id = "+txtID.Text+"", cn);
            cmc.ExecuteNonQuery();
            MessageBox.Show("Data Delet !!");
            cn.Close();
            dispalydata();
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPHONE_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtADDERSS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNAME.Clear();
            txtADDERSS.Clear();
            txtPHONE.Clear();
        }
    }
}
