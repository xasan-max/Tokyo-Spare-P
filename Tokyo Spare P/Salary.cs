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
    public partial class Salary : UserControl
    {
        public Salary()
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
            da = new SqlDataAdapter("select * from salary", cn);
            da.Fill(dt);
             gunaDataGridView1.DataSource = dt;
            cn.Close();
        }
       


        private void Salary_Load(object sender, EventArgs e)
        {
            dispalydata();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
             cn.Open();
             SqlCommand cm = new SqlCommand("insert into salary values  ( "+txtID.Text+" ,"+txtEID.Text+" , "+txtAMOUNT.Text+" ,'"+gunaDateTimePicker1.Value+"')" , cn);
             cm.ExecuteNonQuery();
             MessageBox.Show("Message saved");
             cn.Close();
             dispalydata();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cc = new SqlCommand("update salary set e_id = "+txtEID.Text+", sa_amount = "+txtAMOUNT.Text+", data = '"+gunaDateTimePicker1.Value+"' where sa_id = "+txtID.Text+"", cn);
            cc.ExecuteNonQuery();
            MessageBox.Show("date update");
            cn.Close();
            dispalydata();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmc = new SqlCommand("delete from salary  where sa_id = "+txtID.Text+"", cn);
            cmc.ExecuteNonQuery();
            MessageBox.Show("date Delet");
            cn.Close();
            dispalydata();
          
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtEID.Clear();
            txtAMOUNT.Clear();
            
        }

        private void gunaVTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
