using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class Form6 : Form
    {
        
        public Form6()
        {
            InitializeComponent();
        }
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT * FROM employees where ID='" + textBox1.Text + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                textBox2.Text = reader["Name"].ToString();
                                textBox3.Text = reader["NIC"].ToString();
                                textBox4.Text = reader["Address"].ToString();
                                textBox5.Text = reader["Age"].ToString();
                                textBox6.Text = reader["PhoneNo"].ToString();

                            }

                        }
                    }
                    using (SqlCommand command1 = new SqlCommand("SELECT * FROM empPhoto where ID='" + textBox1.Text + "'", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command1))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);



                            using (SqlDataReader reader = command1.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    Byte[] photo = (byte[])reader["photo"];
                                    pictureBox1.Image = ConvertBinaryToImage(photo);

                                }

                            }
                        }


                    }
                    connection.Close();
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
