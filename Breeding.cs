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
using System.Windows.Forms.Design;

namespace DairyFarmTool
{
    public partial class Breeding : Form
    {
        public Breeding()
        {
            InitializeComponent();
            populate();
            FillCowId();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel5_Paint(object sender, PaintEventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            CowsHealth Ob = new CowsHealth();
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

                CowIdCb.DisplayMember = "CowId";
                CowIdCb.ValueMember = "CowId";
                CowIdCb.DataSource = dt;
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

        private void populate()
        {
            try
            {
                Con.Open();
                string query = "select * from BreedTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                BreedDGV.DataSource = ds.Tables[0];
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

        private void GetCowName()
        {
            try
            {
                Con.Open();
                string query = "SELECT CowName, Age FROM CowTbl WHERE CowId = @CowId";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@CowId", (int)CowIdCb.SelectedValue);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cownameTb.Text = dt.Rows[0]["CowName"].ToString();
                    if (dt.Columns.Contains("Age"))
                    {
                        ageTb.Text = dt.Rows[0]["Age"].ToString();
                    }
                    else
                    {
                        ageTb.Text = "Age not available";
                    }
                }
                else
                {
                    cownameTb.Text = string.Empty;
                    ageTb.Text = string.Empty;
                }
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

        private void Breeding_Load(object sender, EventArgs e)
        {
            FillCowId();
            populate();
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void Clear()
        {
            cownameTb.Text = "";
            colourTb.Text = "";
            breedTb.Text = "";
            Remarkstb.Text = "";
            ageTb.Text = "";
            key = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || cownameTb.Text == "" || colourTb.Text == "" || breedTb.Text == "" || Remarkstb.Text == "" || ageTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "INSERT INTO BreedTbl (CowId, CowName, Colour, Breed, CowAge, Remarks, BreedingDate,PregDate) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, GETDATE(),GETDATE())";
                    SqlCommand cmd = new SqlCommand(Query, Con);

                    cmd.Parameters.AddWithValue("@Value1", CowIdCb.SelectedValue);
                    cmd.Parameters.AddWithValue("@Value2", cownameTb.Text);
                    cmd.Parameters.AddWithValue("@Value3", colourTb.Text);
                    cmd.Parameters.AddWithValue("@Value4", breedTb.Text);
                    cmd.Parameters.AddWithValue("@Value5", ageTb.Text);
                    cmd.Parameters.AddWithValue("@Value6", Remarkstb.Text);

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

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void BreedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                CowIdCb.SelectedValue = BreedDGV.Rows[e.RowIndex].Cells[0].Value?.ToString();
                cownameTb.Text = BreedDGV.Rows[e.RowIndex].Cells[1].Value?.ToString();
                colourTb.Text = BreedDGV.Rows[e.RowIndex].Cells[2].Value?.ToString();
                breedTb.Text = BreedDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                ageTb.Text = BreedDGV.Rows[e.RowIndex].Cells[4].Value?.ToString();
                Remarkstb.Text = BreedDGV.Rows[e.RowIndex].Cells[5].Value?.ToString();
                // Update other fields as needed

                if (string.IsNullOrEmpty(cownameTb.Text))
                {
                    key = 0;
                }
                else
                {
                    try
                    {
                        key = Convert.ToInt32(BreedDGV.Rows[e.RowIndex].Cells[0].Value?.ToString());
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

            if (BreedDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to delete.");
            }
            else
            {
                int selectedRowIndex = BreedDGV.SelectedRows[0].Index;

                if (selectedRowIndex >= 0)
                {
                    int rowId = Convert.ToInt32(BreedDGV.Rows[selectedRowIndex].Cells["BrId"].Value); // Replace "MId" with your actual primary key column name

                    try
                    {
                        using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            Con.Open();
                            string deleteQuery = "DELETE FROM BreedTbl WHERE BrId = @RowId"; // Replace "MId" with your actual primary key column name
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, Con))
                            {
                                cmd.Parameters.AddWithValue("@RowId", rowId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Breed Report Deleted Successfully");
                                    populate(); // Refresh the DataGridView after deletion
                                }
                                else
                                {
                                    MessageBox.Show("Breed Report not found or not deleted.");
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

            if (BreedDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to edit.");
            }
            else
            {
                int selectedRowIndex = BreedDGV.SelectedRows[0].Index;
                DataGridViewRow selectedRow = BreedDGV.Rows[selectedRowIndex];

                try
                {
                    using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        Con.Open();

                        // Loop through all columns in the selected row
                        foreach (DataGridViewCell cell in selectedRow.Cells)
                        {
                            string columnName = BreedDGV.Columns[cell.ColumnIndex].Name;
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
                                cmd.Parameters.AddWithValue("@PrimaryKey", "BrId");

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Refresh the DataGridView after editing
                        BreedDGV.Refresh();
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


