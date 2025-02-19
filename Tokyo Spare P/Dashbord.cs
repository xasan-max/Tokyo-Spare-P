using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace Tokyo_Spare_P
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            supplier1.BringToFront();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            product1.BringToFront();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            customer1.BringToFront();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            orderscs1.BringToFront();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            payment1.BringToFront();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            employe1.BringToFront();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            salary1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCirclePictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
