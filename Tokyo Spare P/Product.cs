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
    public partial class Product : UserControl
    {
        public Product()
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
            da = new SqlDataAdapter("select * from product", cn);
            da.Fill(dt);
            gunaDataGridView1. DataSource = dt;
            cn.Close();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            dispalydata();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("insert into product values (" + txtID.Text + ",'" + txtNAME.Text + "' , " + txtQTY.Text + " , " + txtPRICE.Text + " ," + txtTOTAL.Text + ", " + txtPHONE.Text + ", '" + gunaDateTimePicker1.Value + "', " + gunaTextBox1.Text + ")", cn);
            cm.ExecuteNonQuery();
            MessageBox.Show("data saved");
            cn.Close();
            dispalydata();

        }

        private void txtNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cc = new SqlCommand("update product set p_name = '"+txtNAME.Text+"', p_qty = "+txtQTY.Text+", p_price = "+txtPRICE.Text+" , p_total = "+txtTOTAL.Text+", s_phone = "+txtPHONE.Text+", data = '"+gunaDateTimePicker1.Value+"', s_id = "+gunaTextBox1.Text+" where p_id = "+txtID.Text+"", cn);
            cc.ExecuteNonQuery();
            MessageBox.Show("date update");
            cn.Close();
            dispalydata();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmc = new SqlCommand("delete from product  where p_id = "+txtID.Text+"", cn);
            cmc.ExecuteNonQuery();
            MessageBox.Show("Data Was Delet");
            cn.Close();
            dispalydata();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel9_Click(object sender, EventArgs e)
        {

        }

        private void txtPHONE_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }

        private void gunaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPRICE_TextChanged(object sender, EventArgs e)
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

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNAME.Clear();
            txtQTY.Clear();
            txtPRICE.Clear();
            txtTOTAL.Clear();
            txtPHONE.Clear();
            gunaTextBox1.Clear();
        }
    }
}
