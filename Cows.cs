using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.CodeDom;
using Microsoft.VisualBasic;

namespace DairyFarmTool
{
    public partial class Cows : Form
    {
        public Cows()
        {
            InitializeComponent();
            populate();
        }

        public Cows(int rowId)
        {
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label5_Click(object sender, EventArgs e)
        {

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
        private void populate()
        {
            Con.Open();
            string query = "select * from CowTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowsDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Clear()
        {
            CowsNameTb.Text = "";
            EarTagTb.Text = "";
            ColourTb.Text = "";
            BreedTb.Text = "";
            AgeTb.Text = "";
            PastureTb.Text = "";
            key = 0;


        }

        int age = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (CowsNameTb.Text == "" || EarTagTb.Text == "" || ColourTb.Text == "" || BreedTb.Text == "" || PastureTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");


            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "INSERT INTO CowTbl (CowName, EarTag, Colour, Breed, Pasture,Age) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5,@value6)";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.Parameters.AddWithValue("@Value1", CowsNameTb.Text);
                    cmd.Parameters.AddWithValue("@Value2", EarTagTb.Text);
                    cmd.Parameters.AddWithValue("@Value3", ColourTb.Text);
                    cmd.Parameters.AddWithValue("@Value4", BreedTb.Text);
                    cmd.Parameters.AddWithValue("@Value5", PastureTb.Text);
                    cmd.Parameters.AddWithValue("@Value6", AgeTb.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cow Saved Sucessfully");


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

        private void Cows_Load(object sender, EventArgs e)
        {

        }
        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            MessageBox.Show("" + age);
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();

        }
        int key = 0;
        private void CowsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                CowsNameTb.Text = CowsDGV.SelectedRows[0].Cells[1].Value.ToString();
                EarTagTb.Text = CowsDGV.SelectedRows[0].Cells[2].Value.ToString();
                ColourTb.Text = CowsDGV.SelectedRows[0].Cells[3].Value.ToString();
                BreedTb.Text = CowsDGV.SelectedRows[0].Cells[4].Value.ToString();
                PastureTb.Text = CowsDGV.SelectedRows[0].Cells[5].Value.ToString();
                if (CowsNameTb.Text == "")
                {
                    key = 0;
                    age = 0;

                }
                else
                {
                    try
                    {
                        key = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[0].Value.ToString());
                        age = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[0].Value.ToString());
                    }
                    catch (SqlException ex)
                    {


                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            {
                if (CowsDGV.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select a row to delete.");
                }
                else
                {
                    int selectedRowIndex = CowsDGV.SelectedRows[0].Index;
                    int rowId = Convert.ToInt32(CowsDGV.Rows[selectedRowIndex].Cells["CowId"].Value); // Replace "ID" with your actual column name

                    try
                    {
                        using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            Con.Open();
                            string deleteQuery = "DELETE FROM CowTbl WHERE CowId = @RowId"; // Replace "ID" with your actual primary key column name
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, Con))
                            {
                                cmd.Parameters.AddWithValue("@RowId", rowId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cow Deleted Successfully");
                                    populate(); // Refresh the DataGridView after deletion
                                }
                                else
                                {
                                    MessageBox.Show("Cow not found or not deleted.");
                                }
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }







            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CowsDGV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a row to edit.");
            }
            else
            {
                int selectedRowIndex = CowsDGV.SelectedRows[0].Index;
                DataGridViewRow selectedRow = CowsDGV.Rows[selectedRowIndex];

                // Loop through all columns in the selected row
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    // Display a dialog or input box for the user to edit the cell value
                    string currentValue = cell.Value.ToString(); // Current cell value
                    string newValue = Interaction.InputBox($"Edit {CowsDGV.Columns[cell.ColumnIndex].HeaderText}:", "Edit Cell", currentValue);

                    // Check if the user canceled the edit
                    if (newValue == currentValue)
                    {
                        continue;
                    }

                    // Update the cell with the new value
                    cell.Value = newValue;
                }

                // You can also update the database with these changes if needed

                // Refresh the DataGridView after editing
                CowsDGV.Refresh();
                MessageBox.Show("Row Edited Successfully");
            }


        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }

}






