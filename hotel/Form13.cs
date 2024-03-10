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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer cu = new customer();
            cu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 room = new Form2(null);
            room.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 se = new Form7();
            se.Show();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}
