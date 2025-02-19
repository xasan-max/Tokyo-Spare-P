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
    public partial class Employe : UserControl
    {
        public Employe()
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
            da = new SqlDataAdapter("select * from employe", cn);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            cn.Close();
        }
        private void Employe_Load(object sender, EventArgs e)
        {
            dispalydata();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            SqlCommand cccc = new SqlCommand("insert into employe values(" + txtID.Text + " , '" + txtNAME.Text + "' , " + txtPHONE.Text + " , '" + txtADDERSS.Text + "', " + txtSALARY.Text + " , '" + gunaDateTimePicker1.Value + "')", cn);
            cccc.ExecuteNonQuery();
            MessageBox.Show("Message saved");
            cn.Close();
            dispalydata();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cc = new SqlCommand("update employe set e_name = '"+txtNAME.Text+"', e_phone = "+txtPHONE.Text+", e_adderss = '"+txtADDERSS.Text+"', e_salary = "+txtSALARY.Text+", data= '"+gunaDateTimePicker1.Value+"' where e_id = "+txtID.Text+"", cn);
            cc.ExecuteNonQuery();
            MessageBox.Show("date update");
            cn.Close();
            dispalydata();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmc = new SqlCommand("delete from employe  where e_id = "+txtID.Text+"", cn);
            cmc.ExecuteNonQuery();
            MessageBox.Show("date Delet");
            cn.Close();
            dispalydata();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNAME.Clear();
            txtPHONE.Clear();
            txtADDERSS.Clear();
            txtSALARY.Clear();
        }
    }
}

