
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
    public partial class CowsHealth : Form
    {
        public CowsHealth()
        {
            InitializeComponent();
            FillCowId();
            populate();
            Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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
            string query = "select * from HealthTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HealthDGV.DataSource = ds.Tables[0];
            Con.Close();

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
                    CowNameTb.Text = dt.Rows[0]["CowName"].ToString();
                }
                else
                {
                    // Handle the case where no matching CowId is found
                    CowNameTb.Text = string.Empty;
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
        private void CowsHealth_Load(object sender, EventArgs e)
        {

        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            EventTb.Text = "";
            DiagnosisTb.Text = "";
            TreatmentTb.Text = "";
            VetNameTb.Text = "";
            TreatmentCostTb.Text = "";
            key = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || DiagnosisTb.Text == "" || TreatmentTb.Text == "" || VetNameTb.Text == "" || TreatmentCostTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "INSERT INTO HealthTbl (CowId, CowName, Event, Diagnosis, Treatment, VetName, Cost, RepDate) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5,@value6,@value7,GETDATE())";
                    SqlCommand cmd = new SqlCommand(Query, Con);

                    // Assuming CowIdCb.SelectedValue is of type int
                    cmd.Parameters.AddWithValue("@Value1", CowIdCb.SelectedValue);

                    cmd.Parameters.AddWithValue("@Value2", CowNameTb.Text);
                    cmd.Parameters.AddWithValue("@Value3", EventTb.Text);
                    cmd.Parameters.AddWithValue("@Value4", DiagnosisTb.Text);
                    cmd.Parameters.AddWithValue("@Value5", TreatmentTb.Text);
                    cmd.Parameters.AddWithValue("@Value6", VetNameTb.Text);
                    cmd.Parameters.AddWithValue("@Value7", TreatmentCostTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Health Issue Saved Successfully");
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
        int key = 0;
        private void HealthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                CowIdCb.SelectedValue = HealthDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                CowNameTb.Text = HealthDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                Date.Text = HealthDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                EventTb.Text = HealthDGV.Rows[e.RowIndex].Cells[4].Value?.ToString();
                DiagnosisTb.Text = HealthDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();
                TreatmentTb.Text = HealthDGV.Rows[e.RowIndex].Cells[6].Value?.ToString();

                TreatmentCostTb.Text = HealthDGV.Rows[e.RowIndex].Cells[7].Value?.ToString();
                VetNameTb.Text = HealthDGV.Rows[e.RowIndex].Cells[8].Value?.ToString();




                if (string.IsNullOrEmpty(CowNameTb.Text))
                {
                    key = 0;
                }
                else
                {
                    try
                    {
                        key = Convert.ToInt32(HealthDGV.Rows[e.RowIndex].Cells[0].Value?.ToString());
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

            if (HealthDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to delete.");
            }
            else
            {
                int selectedRowIndex = HealthDGV.SelectedRows[0].Index;

                if (selectedRowIndex >= 0)
                {
                    int rowId = Convert.ToInt32(HealthDGV.Rows[selectedRowIndex].Cells["RepId"].Value); // Replace "MId" with your actual primary key column name

                    try
                    {
                        using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            Con.Open();
                            string deleteQuery = "DELETE FROM HealthTbl WHERE RepId = @RowId"; // Replace "MId" with your actual primary key column name
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, Con))
                            {
                                cmd.Parameters.AddWithValue("@RowId", rowId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Health Issue Deleted Successfully");
                                    populate(); // Refresh the DataGridView after deletion
                                }
                                else
                                {
                                    MessageBox.Show("Health Issue not found or not deleted.");
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
            if (HealthDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to edit.");
            }
            else
            {
                int selectedRowIndex = HealthDGV.SelectedRows[0].Index;
                DataGridViewRow selectedRow = HealthDGV.Rows[selectedRowIndex];

                try
                {
                    using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        Con.Open();

                        // Loop through all columns in the selected row
                        foreach (DataGridViewCell cell in selectedRow.Cells)
                        {
                            string columnName = HealthDGV.Columns[cell.ColumnIndex].Name;
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
                                cmd.Parameters.AddWithValue("@PrimaryKey", "RepId");

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Refresh the DataGridView after editing
                        HealthDGV.Refresh();
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
