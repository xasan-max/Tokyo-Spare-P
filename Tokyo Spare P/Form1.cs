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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (gunaCircleProgressBar1.Value < 100)
            {
                gunaCircleProgressBar1.Value += 1;
                gunaLabel3.Text = gunaCircleProgressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Hide();
                Login lg = new Login();
                lg.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}
