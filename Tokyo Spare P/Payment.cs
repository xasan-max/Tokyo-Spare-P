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
    public partial class Payment : UserControl
    {
        public Payment()
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
            da = new SqlDataAdapter("select * from payment", cn);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            cn.Close();
        }

        private void gunaLabel9_Click(object sender, EventArgs e)
        {

        }

        private void txtPid_TextChanged(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            dispalydata();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
             cn.Open();
             SqlCommand cccc = new SqlCommand("insert into payment values ( " + txtID.Text + " , " + txto_id.Text + ", '" + txtNAME.Text + "', " + txtPRICE.Text + " , " + txtQTY.Text + " ,   " + txtCid.Text + ", " + txtEid.Text + ", " + py_Discount.Text + " ,  '" + dateTimePicker1.Value + "' , " + txtAmount.Text + " ," + txtTotal.Text + ")", cn);
            cccc.ExecuteNonQuery();
            
            MessageBox.Show("Message saved");
            cn.Close();
            dispalydata();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cc = new SqlCommand(("update payment set o_id = "+txto_id.Text+",o_name = '"+txtNAME.Text+"', o_price = "+txtPRICE.Text+", o_qty = "+txtQTY.Text+", c_id = "+txtCid.Text+", e_id = "+txtEid.Text+", discount = "+py_Discount.Text+", data = '"+dateTimePicker1.Value+"', net_amount = "+txtAmount.Text+", o_total = "+txtTotal.Text+" where py_id ="+txtID.Text+""),cn);
            cc.ExecuteNonQuery();
            MessageBox.Show("Data Update");
            cn.Close();
            dispalydata();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmc = new SqlCommand("delete from payment  where py_id = "+txtID.Text+"", cn);
            cmc.ExecuteNonQuery();
            MessageBox.Show("Data Delet");
            cn.Close();
            dispalydata();
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txto_id.Text != "")
                {
                    cn.Open();
                    string select = "select * from orders where o_id=" + txto_id.Text + "";
                    SqlCommand ccccc = new SqlCommand(select, cn);
                    SqlDataReader dr = ccccc.ExecuteReader();
                    while (dr.Read())
                    {
                      
                        txtNAME.Text = dr.GetValue(1).ToString();
                        txtPRICE.Text = dr.GetValue(2).ToString();
                    
                        txtTotal.Text = dr.GetValue(3).ToString();
                    }
                    cn.Close();
                }
                else
                {
                    txto_id.Clear();
                    txtNAME.Clear();
                    txtPRICE.Clear();
                    txtQTY.Clear();
                    
                    txtTotal.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }

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
                    txtTotal.Text = total.ToString();
                }
                else
                {
                    txtTotal.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txto_id.Clear();
            txtNAME.Clear();
            txtPRICE.Clear();
            txtQTY.Clear();
            txtCid.Clear();
            txtEid.Clear();
            py_Discount.Clear();
            txtTotal.Clear();
            txtAmount.Clear();
        }

        private void py_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (py_Discount.Text != "")
                {
                    double total = double.Parse(txtTotal.Text);
                    double discount = double.Parse(py_Discount.Text);
                    double tot = total - discount;
                    txtAmount .Text = tot.ToString();
                }
                else
                {
                    txtAmount.Text = "0";
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

