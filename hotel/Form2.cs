using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class Form2 : Form
    {
        string cusid;
        public Form2(string NIC)
        {
            this.cusid = NIC;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
                     
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            
            string columnValue;
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();

                string ye = "yes";
                string no = "no";
                using (SqlCommand command = new SqlCommand("SELECT room_id FROM available where available='"+ye+"'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        
                        dataGridView1.DataSource = dataTable;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            try
                            {
                                while (reader.Read())
                                {

                                    columnValue = reader["room_id"].ToString();
                                    if (columnValue.Equals(textBox1.Text))
                                    {
                                        reader.Close();
                                        SqlCommand command1 = new SqlCommand("Update available SET available='" + no + "' where room_id='" + textBox1.Text + "'", connection);
                                        command1.ExecuteNonQuery();
                                        connection.Close();
                                    }
                               
                                }
                            }
                            catch
                            {

                            }

                        }
                    }


                }
                connection.Close();
            }
            textBox1.Text = "";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string columnValue;
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();

                string ye = "yes";
                string no = "no";
                using (SqlCommand command = new SqlCommand("SELECT room_id FROM available where available='" + ye + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                columnValue = reader["room_id"].ToString();
                               
                                if (columnValue.Equals(textBox1.Text))
                                {

                                    SqlCommand command1 = new SqlCommand("Update available SET available='" + no + "' where room_id='" + columnValue + "'", connection);
                                    using (HOTELEntities db = new HOTELEntities())
                                    {
                                        room_alo al = new room_alo() { NIC = cusid,room_id=textBox1.Text };
                                        db.room_alo.Add(al);
                                        try
                                        {
                                            await db.SaveChangesAsync();
                                        }
                                        catch
                                        {

                                        }
                                    }

                                }


                            }

                        }
                    }


                }
                
                connection.Close();
            }
            MessageBox.Show("Room Booked");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
