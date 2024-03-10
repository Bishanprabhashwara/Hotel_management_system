using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class Form5 : Form
    {
        string filename;
        //List<empPhoto> list;
        public Form5()
        {
            InitializeComponent();
        }
        Image ConvertBinaryToImage(byte[]data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                
                return Image.FromStream(ms);
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog(){Filter="JPEG|*.jpg",ValidateNames=true,Multiselect=false})
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

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HOTELEntities db =new HOTELEntities())
            {
                empPhoto pic = new empPhoto() { path = filename, photo = ConvertImageToBinary(pictureBox1.Image),ID=textBox1.Text };
                employee emp = new employee() { ID = textBox1.Text, Name = textBox3.Text, NIC = textBox2.Text, PhoneNo = textBox4.Text, Age = int.Parse(textBox5.Text), Address = textBox6.Text, Salary = float.Parse(textBox7.Text) };
                db.empPhotoes.Add(pic);
                db.employees.Add(emp);
                await db.SaveChangesAsync();
                MessageBox.Show("details saved");

                
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
