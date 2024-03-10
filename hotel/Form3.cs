using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class Strore : Form
    {
        public Strore()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //OleDbConnection con = new OleDbConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True");

        private async void button1_Click(object sender, EventArgs e)
        {
            int che = check();
            if (che == 0)
            {
                HOTELEntities dh = new HOTELEntities();
                Item it = new Item() { Item_code = textBox1.Text, item_name = textBox2.Text, Qty = int.Parse(textBox3.Text), price = double.Parse(textBox4.Text) };
                dh.Items.Add(it);
                await dh.SaveChangesAsync();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                

            }

        }

        private void Strore_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataSet11.Clear();
            sqlDataAdapter1.Fill(dataSet11);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public int check()
        {
            string columnValue;
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT Item_code FROM Items where Item_code='" + textBox1.Text + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                columnValue = reader["Item_code"].ToString();
                                if (columnValue.Equals(textBox1.Text))
                                {
                                    string updateQuery = "UPDATE Items SET Qty = Qty + @NewValue WHERE Item_code = @PrimaryKeyValue";
                                    using (SqlCommand command2 = new SqlCommand(updateQuery, connection))
                                    {
                                        command2.Parameters.AddWithValue("@NewValue", int.Parse(textBox3.Text));
                                        command2.Parameters.AddWithValue("@PrimaryKeyValue", columnValue);
                                    }
                                    return 1;
                                }

                            }

                        }
                    }


                }
                connection.Close();
            }
            return 0;
        }
    }
}
    

