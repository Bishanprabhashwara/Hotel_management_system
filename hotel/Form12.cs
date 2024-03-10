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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT avg(qty) FROM sell where date='" + textBox1.Text + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            double average = Convert.ToDouble(result);
                            label1.Text = average.ToString();
                        }
                    }
                    connection.Close();
                }
            }
        }
        double max;
        private void button2_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT max(qty) FROM sell where date='" + textBox1.Text + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            max = Convert.ToDouble(result);


                        }
                    }

                }
                using (SqlCommand command2 = new SqlCommand("SELECT Item_code FROM sell where qty='" + max + "'", connection))
                {
                    using (SqlDataAdapter adapter2 = new SqlDataAdapter(command2))
                    {
                        object result2 = command2.ExecuteScalar();

                        if (result2 != DBNull.Value)
                        {
                            label2.Text = result2.ToString();

                        }
                    }

                }
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT sum(qty) FROM sell where date='" + textBox1.Text + "'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            double average = Convert.ToDouble(result);
                            label3.Text = average.ToString();
                        }
                    }
                    connection.Close();
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            int[] sumqty = new int[12];
            int val = 0;
            int total = 0;
            
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CJT3444\\SQLEXPRESS;Initial Catalog=HOTEL;Integrated Security=True"))
                {
                    
                    for (int i = 0; i < 12; i++)
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("SELECT sum(qty) FROM sell where date='" +i  + "'", connection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                object result = command.ExecuteScalar();

                                if (result != DBNull.Value)
                                {
                                    sumqty[i] = Convert.ToInt32(result);
                                    val= Convert.ToInt32(result);
                                    total = total + val;
                                }
                            }

                        }
                        connection.Close();
                    }
                    
                }
                int tot=0;
                for (int i = 0; i < 12; i++)
                {
                    tot = tot + sumqty[i];
                    
                }
            chart1.Series["Months"].Points.AddXY("1", sumqty[0]);
            chart1.Series["Months"].Points.AddXY("2", sumqty[1]);
            chart1.Series["Months"].Points.AddXY("3", sumqty[2]);
            chart1.Series["Months"].Points.AddXY("4", sumqty[3]);
            chart1.Series["Months"].Points.AddXY("5", sumqty[4]);
            chart1.Series["Months"].Points.AddXY("6", sumqty[5]);
            chart1.Series["Months"].Points.AddXY("7", sumqty[6]);
            chart1.Series["Months"].Points.AddXY("8", sumqty[7]);
            chart1.Series["Months"].Points.AddXY("9", sumqty[8]);
            chart1.Series["Months"].Points.AddXY("10", sumqty[9]);
            chart1.Series["Months"].Points.AddXY("11", sumqty[10]);
            chart1.Series["Months"].Points.AddXY("12", sumqty[11]);

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
