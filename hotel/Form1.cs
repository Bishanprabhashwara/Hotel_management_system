using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hotel
{
    public partial class customer : Form
    {
        string filename;
        public customer()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private async void button1_Click(object sender, EventArgs e)
        {
            
            using (HOTELEntities db = new HOTELEntities())
            {
                try
                {
                    DateTime selectedDate1 = dateTimePicker1.Value;
                    DateTime selectedDate2 = dateTimePicker2.Value;
                    string formattedDate1 = selectedDate1.ToString("yyyy-MM-dd");
                    string formattedDate2 = selectedDate2.ToString("yyyy-MM-dd");
                    custo cus = new custo() { NIC = textBox1.Text, cname = textBox2.Text, check_in = formattedDate1, phone_no = textBox3.Text, check_out = formattedDate2, photo = ConvertImageToBinary(pictureBox1.Image) };
                    db.custoes.Add(cus);
                    await db.SaveChangesAsync();
                    MessageBox.Show("details saved");
                    Form2 room = new Form2(textBox1.Text);
                    room.Show();
                    for (int i = 0; i > 100; i++)
                    {

                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Invalid Input Try Again");
                    
                }
                



            }
        }

        private void customer_Load(object sender, EventArgs e)
        {

        }
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(filename);
                }
            }

        }
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
