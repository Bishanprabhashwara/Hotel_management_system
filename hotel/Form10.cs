using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 cust = new Form7();
            cust.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 em = new Form6();
            em.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 addemp = new Form5();
            addemp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 an = new Form12();
            an.Show();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
