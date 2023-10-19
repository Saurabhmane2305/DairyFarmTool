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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DairyFarmTool
{
    public partial class MilkProduction : Form
    {
        public MilkProduction()
        {
            InitializeComponent();
            FillCowId();
            populate();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            CowsHealth Ob = new CowsHealth();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Milk_Sales Ob = new Milk_Sales();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

            Finance Ob = new Finance();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }

        private void MilkProduction_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillCowId()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CowId FROM CowTbl", Con);
                SqlDataReader Rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(Rdr); // Load data from the SqlDataReader into the DataTable

                CowIdCb.DisplayMember = "CowId"; // DisplayMember should be set to the column name you want to display
                CowIdCb.ValueMember = "CowId";
                CowIdCb.DataSource = dt;

                Con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the database operations
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close(); // Make sure to close the connection in case of an exception
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from MilkTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Clear()
        {
            CowNametb.Text = "";
            AMTb.Text = "";
            PMTb.Text = "";
            TotalMilkTb.Text = "";
            key = 0;
        }
        private void GetCowName()
        {
            try
            {
                Con.Open();
                string query = "SELECT CowName FROM CowTbl WHERE CowId = " + (int)CowIdCb.SelectedValue;
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    CowNametb.Text = dt.Rows[0]["CowName"].ToString();
                }
                else
                {
                    // Handle the case where no matching CowId is found
                    CowNametb.Text = string.Empty;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNametb.Text == "" || AMTb.Text == "" || PMTb.Text == "" || TotalMilkTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "INSERT INTO MilkTbl (CowId, CowName, AmMilk, PmMilk, TotalMilk, DateProd) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, GETDATE())";
                    SqlCommand cmd = new SqlCommand(Query, Con);

                    // Assuming CowIdCb.SelectedValue is of type int
                    cmd.Parameters.AddWithValue("@Value1", CowIdCb.SelectedValue);

                    cmd.Parameters.AddWithValue("@Value2", CowNametb.Text);
                    cmd.Parameters.AddWithValue("@Value3", AMTb.Text);
                    cmd.Parameters.AddWithValue("@Value4", PMTb.Text);
                    cmd.Parameters.AddWithValue("@Value5", TotalMilkTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Milk Saved Successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Con.Close(); // Close the connection in a finally block to ensure it gets closed.
                    populate();
                    Clear();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void PMTb_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void PMTb_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(PMTb.Text, out parsedValue))
            {
                int total = Convert.ToInt32(AMTb.Text) + Convert.ToInt32(PMTb.Text);
                TotalMilkTb.Text = "" + total;
            }
            else
            {
                // Handle the case where the conversion failed, e.g., show an error message.
            }


        }
        int key = 0;
        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                CowIdCb.SelectedValue = MilkDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                CowNametb.Text = MilkDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                AMTb.Text = MilkDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                PMTb.Text = MilkDGV.Rows[e.RowIndex].Cells[4].Value?.ToString();
                TotalMilkTb.Text = MilkDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();
                Date.Text = MilkDGV.Rows[e.RowIndex].Cells[6].Value?.ToString();



                if (string.IsNullOrEmpty(CowNametb.Text))
                {
                    key = 0;
                }
                else
                {
                    try
                    {
                        key = Convert.ToInt32(MilkDGV.Rows[e.RowIndex].Cells[0].Value?.ToString());
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MilkDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to delete.");
            }
            else
            {
                int selectedRowIndex = MilkDGV.SelectedRows[0].Index;

                if (selectedRowIndex >= 0)
                {
                    int rowId = Convert.ToInt32(MilkDGV.Rows[selectedRowIndex].Cells["MId"].Value); // Replace "MId" with your actual primary key column name

                    try
                    {
                        using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            Con.Open();
                            string deleteQuery = "DELETE FROM MilkTbl WHERE MId = @RowId"; // Replace "MId" with your actual primary key column name
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, Con))
                            {
                                cmd.Parameters.AddWithValue("@RowId", rowId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Milk Deleted Successfully");
                                    populate(); // Refresh the DataGridView after deletion
                                }
                                else
                                {
                                    MessageBox.Show("Milk not found or not deleted.");
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
            if (MilkDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to edit.");
            }
            else
            {
                int selectedRowIndex = MilkDGV.SelectedRows[0].Index;
                DataGridViewRow selectedRow = MilkDGV.Rows[selectedRowIndex];

                try
                {
                    using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        Con.Open();

                        // Loop through all columns in the selected row
                        foreach (DataGridViewCell cell in selectedRow.Cells)
                        {
                            string columnName = MilkDGV.Columns[cell.ColumnIndex].Name;
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
                            string updateQuery = $"UPDATE YourTable SET {columnName} = @NewValue WHERE YourPrimaryKeyColumn = @PrimaryKey";
                            using (SqlCommand cmd = new SqlCommand(updateQuery, Con))
                            {
                                cmd.Parameters.AddWithValue("@NewValue", newValue);

                                // Provide the actual primary key value of the row you're editing
                                cmd.Parameters.AddWithValue("@PrimaryKey", "MId");

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Refresh the DataGridView after editing
                        MilkDGV.Refresh();
                        MessageBox.Show("Row Edited Successfully");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

    }
}

