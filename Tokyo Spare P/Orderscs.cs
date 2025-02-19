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
    public partial class Orderscs : UserControl
    {
        public Orderscs()
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
            da = new SqlDataAdapter("select * from orders", cn);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            cn.Close();
        }

        private void Orderscs_Load(object sender, EventArgs e)
        {
            dispalydata();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
             cn.Open();
             SqlCommand cmd = new SqlCommand("insert into orders values ( "+txtID.Text+",'"+txtNAME.Text+"' , "+txtPRICE.Text+" , "+txtQTY.Text+" , "+txtTOTAL.Text+" , "+txtPid.Text+" , "+txtCid.Text+", '"+gunaDateTimePicker1.Value+"')" , cn);
             cmd.ExecuteNonQuery();
             MessageBox.Show("Message saved");
             cn.Close();
             dispalydata();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmc = new SqlCommand("delete from orders  where o_id = "+txtID.Text+"", cn);
            cmc.ExecuteNonQuery();
            MessageBox.Show("Data Was Delet");
            cn.Close();
            dispalydata();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cc = new SqlCommand("update orders set o_name = '"+txtNAME.Text+"', o_price = "+txtPRICE.Text+", o_qty = "+txtQTY.Text+", o_total = "+txtTOTAL.Text+", p_id = "+txtPid.Text+", c_id = "+txtCid.Text+", data = '"+gunaDateTimePicker1.Value+"' where o_id = "+txtID.Text+"", cn);
            cc.ExecuteNonQuery();
            MessageBox.Show("Data Update");
            cn.Close();
            dispalydata();
        }

        private void txtPid_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtQTY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQTY.Text != "")
                {
                    int qty = int.Parse(txtQTY.Text);
                    double price = int.Parse(txtPRICE.Text);
                    double total = price * qty;
                    txtTOTAL.Text = total.ToString();
                }
                else
                {
                    txtTOTAL.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }
    }
}
