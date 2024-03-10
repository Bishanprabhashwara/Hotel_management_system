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
    public partial class Form7 : Form
    {
        public Form7()
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


                using (SqlCommand command = new SqlCommand("SELECT * FROM custo where NIC='" + textBox2.Text + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {


                                textBox3.Text = reader["cname"].ToString();
                                textBox4.Text = reader["phone_no"].ToString();
                                textBox5.Text = reader["check_in"].ToString();
                                textBox6.Text = reader["check_out"].ToString();

                            }

                        }
                    }
                    using (SqlCommand command1 = new SqlCommand("SELECT photo FROM custo where NIC='" + textBox2.Text + "'", connection))
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
                        using (SqlCommand command2 = new SqlCommand("SELECT * FROM room_alo where NIC='" + textBox2.Text + "'", connection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command2))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);



                                using (SqlDataReader reader = command2.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        textBox7.Text = reader["room_id"].ToString();

                                    }

                                }
                            }


                        }
                        connection.Close();
                    }
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
