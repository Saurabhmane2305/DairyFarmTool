
using Microsoft.VisualBasic;
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
            GenCb.Text = "";
            EmpPassTb.Text = "";
            DOB.Value = DateTime.Now; // Set the value to clear the DateTimePicker
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (GenCb.SelectedIndex == -1 || string.IsNullOrWhiteSpace(GenCb.Text) || NameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Format the date as a string
                    string Query = "INSERT INTO EmployeeTbl (EmpName, EmpDob, Gender, Phone, Adress,EmpPass) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5,@value6)";
                    SqlCommand cmd = new SqlCommand(Query, Con);

                    cmd.Parameters.AddWithValue("@Value1", NameTb.Text);
                    cmd.Parameters.AddWithValue("@Value2", currentDate); // Insert the formatted date string
                    cmd.Parameters.AddWithValue("@Value3", GenCb.Text);
                    cmd.Parameters.AddWithValue("@Value4", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Value5", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Value6", EmpPassTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Employee Record Saved Successfully");
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
            if (e.RowIndex >= 0)
            {
                // Assuming the DataGridView columns are in this order: EmpID, EmpName, EmpDob, Gender, Phone, Address

                NameTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[1].Value?.ToString(); // EmpName
                DOB.Text = EmployeeDGV.Rows[e.RowIndex].Cells[2].Value?.ToString(); // EmpDob
                GenCb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[3].Value?.ToString(); // Gender
                PhoneTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[4].Value?.ToString(); // Phone
                AddressTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();// Address
                EmpPassTb.Text = EmployeeDGV.Rows[e.RowIndex].Cells[6].Value?.ToString();

                if (string.IsNullOrEmpty(NameTb.Text))
                {
                    key = 0;
                }
                else
                {
                    try
                    {
                        key = Convert.ToInt32(EmployeeDGV.Rows[e.RowIndex].Cells[0].Value?.ToString()); // EmpID
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (EmployeeDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to delete.");
            }
            else
            {
                int selectedRowIndex = EmployeeDGV.SelectedRows[0].Index;

                if (selectedRowIndex >= 0)
                {
                    int empId = Convert.ToInt32(EmployeeDGV.Rows[selectedRowIndex].Cells["EmpID"].Value); // Replace "EmpID" with your actual primary key column name

                    try
                    {
                        using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            Con.Open();
                            string deleteQuery = "DELETE FROM EmployeeTbl WHERE EmpID = @EmpId"; // Replace "EmpID" with your actual primary key column name
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, Con))
                            {
                                cmd.Parameters.AddWithValue("@EmpId", empId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Employee Deleted Successfully");
                                    populate(); // Refresh the DataGridView after deletion
                                }
                                else
                                {
                                    MessageBox.Show("Employee not found or not deleted.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmployeeDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to edit.");
            }
            else
            {
                int selectedRowIndex = EmployeeDGV.SelectedRows[0].Index;
                DataGridViewRow selectedRow = EmployeeDGV.Rows[selectedRowIndex];

                try
                {
                    using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        Con.Open();

                        // Loop through all columns in the selected row
                        foreach (DataGridViewCell cell in selectedRow.Cells)
                        {
                            string columnName = EmployeeDGV.Columns[cell.ColumnIndex].Name;
                            string currentValue = cell.Value.ToString(); // Current cell value
                            string newValue = Interaction.InputBox($"Edit {columnName}:", "Edit Cell", currentValue);

                            // Check if the user canceled the edit
                            if (newValue == currentValue)
                            {
                                continue;
                            }

                            // Update the cell with the new value
                            cell.Value = newValue;

                            // If you want to update the database, construct an UPDATE query and execute it
                            string updateQuery = $"UPDATE EmployeeTbl SET {columnName} = @NewValue WHERE EmpID = @PrimaryKey";
                            using (SqlCommand cmd = new SqlCommand(updateQuery, Con))
                            {
                                cmd.Parameters.AddWithValue("@NewValue", newValue);

                                // Provide the actual primary key value of the row you're editing
                                cmd.Parameters.AddWithValue("@PrimaryKey", EmployeeDGV.Rows[selectedRowIndex].Cells["EmpID"].Value.ToString());

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Refresh the DataGridView after editing
                        EmployeeDGV.Refresh();
                        MessageBox.Show("Row Edited Successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}









