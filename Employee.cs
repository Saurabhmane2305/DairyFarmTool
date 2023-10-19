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

namespace DairyFarmTool
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30");



        private void populate()
        {
            try
            {
                Con.Open();
                string query = "select * from EmployeeTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                EmployeeDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        private void Clear()
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            AddressTb.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GenCb.SelectedIndex == -1 || string.IsNullOrWhiteSpace(GenCb.Text) || NameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Format the date as a string
                    string Query = "INSERT INTO EmployeeTbl (EmpName, EmpDob, Gender, Phone, Adress) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5)";
                    SqlCommand cmd = new SqlCommand(Query, Con);

                    cmd.Parameters.AddWithValue("@Value1", NameTb.Text);
                    cmd.Parameters.AddWithValue("@Value2", currentDate); // Insert the formatted date string
                    cmd.Parameters.AddWithValue("@Value3", GenCb.Text);
                    cmd.Parameters.AddWithValue("@Value4", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Value5", AddressTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Breeding Record Saved Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Con.Close();
                    populate();
                    Clear();
                }
            }


        }
        int key = 0;
        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
                if (e.RowIndex >= 0) // Check if a valid row is clicked
                {
                    // Assuming that the DataGridView columns are in this order: EmpID, EmpName, EmpDob, Gender, Phone, Address
                    GenCb.SelectedValue = EmployeeDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
                    NameTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                PhoneTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                AddressTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                // You can continue updating other text fields with the respective cell values from the DataGridView.

                if (string.IsNullOrEmpty(NameTb.Text))
                    {
                        key = 0;
                    }
                    else
                    {
                        try
                        {
                            key = Convert.ToInt32(EmployeeDGV.Rows[e.RowIndex].Cells[0].Value?.ToString());
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }

        }
    }





