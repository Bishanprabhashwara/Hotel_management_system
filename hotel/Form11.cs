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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer cus = new customer();
            cus.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 admin = new Form4();
            admin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Strore st = new Strore();
            st.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 cha = new Form8();
            cha.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 em = new Form13();
            em.Show();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
