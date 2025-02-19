using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tokyo_Spare_P
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gunaTextBox2.PasswordChar == '\0')
            {
                button1.BringToFront();
                gunaTextBox2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (gunaTextBox2.PasswordChar == '*')
            {
                button2.BringToFront();
                gunaTextBox2.PasswordChar = '\0';
            }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = gunaTextBox1.Text;
            pass = gunaTextBox2.Text;
            if (user == "admin" && pass == "admin")
            {
                Dashbord dsh = new Dashbord();
                dsh.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("please try again");
              
            }
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
