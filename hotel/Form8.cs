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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cm = new SqlCommand("Delete  from tempOrder", con);
                int v = cm.ExecuteNonQuery();

                con.Close();
            }
        }
        string name;
        double qty = 0;
        double amount = 0;
        double price = 0;
        double tot = 0;
        
        private async void button2_Click(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            int year = currentDateTime.Year;
            int month = currentDateTime.Month;
            int day = currentDateTime.Day;
            int hour = currentDateTime.Hour;
            int minute = currentDateTime.Minute;
            int second = currentDateTime.Second;
            int millisecond = currentDateTime.Millisecond;
            

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Items where Item_code='" + textBox1.Text + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            try
                            {
                                while (reader.Read())
                                {
                                    price = double.Parse(reader["price"].ToString());
                                    name = reader["item_name"].ToString();


                                    try
                                    {
                                        amount = price * float.Parse(textBox2.Text);
                                        richTextBox1.AppendText(name + "       " + price + "       " + textBox2.Text + "       " + amount + Environment.NewLine);
                                        tot = tot + amount;
                                        label5.Text = tot.ToString();

                                        using (HOTELEntities db = new HOTELEntities())
                                        {
                                            sell se = new sell() { sells_code = year + month + day + hour + minute + millisecond, Item_code = textBox1.Text, qty = int.Parse(textBox2.Text), date = month.ToString() };
                                            db.sells.Add(se);
                                            
                                            tempOrder to = new tempOrder() { item_name = name, price = (float)price, qty = int.Parse(textBox2.Text), tot = (float)amount };
                                            db.tempOrders.Add(to);
                                            await db.SaveChangesAsync();
                                        }
                                        reader.Close();
                                        SqlCommand command1 = new SqlCommand("Update Items SET qty=qty-'" + textBox2.Text + "' where Item_code='" + textBox1.Text + "'", connection);
                                        command1.ExecuteNonQuery();
                                        connection.Close();
                                        

                                    }

                                    catch
                                    {
                                        MessageBox.Show("Enter all values");
                                        amount = 0;
                                    }


                                    textBox1.Text = "";
                                    textBox2.Text = "";

                                }
                            }
                            catch { }

                        }
                    }
                    connection.Close();
                }
               
            }

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form14 fm14 = new Form14();
            fm14.Show();
            
        }
    }
}
