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
    public partial class Form4 : Form
    {
        //string username;
        public Form4()
        {
            //this.username = username;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            Form9 face = new Form9(username,1);
            face.Show();
            face.capt();
            for (int i = 0; i > 100; i++)
            {

            }
            this.Close();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
