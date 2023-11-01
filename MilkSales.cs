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
    public partial class Milk_Sales : Form
    {
        public Milk_Sales()
        {
            InitializeComponent();
            FillEmpId();
            populate();
        }

        private void Milk_Sales_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
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

        private void panel4_Paint(object sender, PaintEventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
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

        private void FillEmpId()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT EmpId FROM EmployeeTbl", Con);
                SqlDataReader Rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(Rdr); // Load data from the SqlDataReader into the DataTable

                EmpIdCb.DisplayMember = "EmpId"; // DisplayMember should be set to the column name you want to display
                EmpIdCb.ValueMember = "EmpId";
                EmpIdCb.DataSource = dt;

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

        private void PriceTb_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PriceTb.Text) && !int.TryParse(PriceTb.Text, out _))
            {
                MessageBox.Show("Please enter a valid integer for Price.");
                PriceTb.Focus(); // Put focus back on the Price textbox for correction.
            }
            else
            {
                // Valid input, you can proceed with the calculation here.
                CalculateTotal();
            }
        }

        private void QuantityTb_Leave(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            if (int.TryParse(PriceTb.Text, out int price) && int.TryParse(QuantityTb.Text, out int quantity))
            {
                int total = price * quantity;
                TotalTb.Text = total.ToString();
            }
            else
            {
                // Clear the Total textbox if the input is not valid.
                TotalTb.Text = "";
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from MilkSalesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalesDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Clear()
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            PriceTb.Text = "";
            QuantityTb.Text = "";
            TotalTb.Text = "";
            EmpIdCb.Text = "";
            Date.Value = DateTime.Now;

        }


        private void SaveTransaction()
        {
            // Establish a database connection
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int empId = (int)EmpIdCb.SelectedValue;

                // Define a SQL query to insert a new income record
                string insertQuery = "INSERT INTO IncomeTbl (IncDate, IncPurpose, IncAmt, EmpId) VALUES (@Date, @Purpose, @Amount, @EmpId);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Purpose", "Milk Sales"); // Provide a purpose for the income record
                    cmd.Parameters.AddWithValue("@Amount", TotalTb.Text);
                    cmd.Parameters.AddWithValue("@EmpId", empId);

                    // Execute the query to save the income record
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(PhoneTb.Text) || string.IsNullOrEmpty(PriceTb.Text) || string.IsNullOrEmpty(QuantityTb.Text))
            {
                MessageBox.Show("Please fill in all the required information.");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO MilkSalesTbl (Date, Uprice, ClientName, ClientPhone, EmpId, Quantity, Amount) VALUES (@Date, @Uprice, @ClientName, @ClientPhone, @EmpId, @Quantity, @Amount)";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    // Assuming EmpId is selected from a combo box, replace this with your actual source.
                    int empId = (int)EmpIdCb.SelectedValue;

                    cmd.Parameters.AddWithValue("@Date", DateTime.Now); // You can change this to your specific date source.
                    cmd.Parameters.AddWithValue("@Uprice", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@ClientName", NameTb.Text);
                    cmd.Parameters.AddWithValue("@ClientPhone", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EmpId", empId); // Replace with actual employee selection.
                    cmd.Parameters.AddWithValue("@Quantity", QuantityTb.Text);

                    // Calculate the Amount based on Uprice and Quantity
                    decimal amount = decimal.Parse(PriceTb.Text) * int.Parse(QuantityTb.Text);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sale data saved successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Con.Close(); // Close the connection in a finally block to ensure it gets closed.
                    populate(); // Refresh the data on your DataGridView.
                    SaveTransaction();
                     Clear(); // Clear the input fields.
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void SalesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Assuming the DataGridView columns are in this order: SId, Date, Uprice, ClientName, ClientPhone, EmpId, Quantity, Amount

                // Assuming SId is in the first column
                key = Convert.ToInt32(SalesDGV.Rows[e.RowIndex].Cells[0].Value?.ToString());

                // Populate other fields
                Date.Text = SalesDGV.Rows[e.RowIndex].Cells[1].Value?.ToString(); // Date
                PriceTb.Text = SalesDGV.Rows[e.RowIndex].Cells[2].Value?.ToString(); // Uprice
                NameTb.Text = SalesDGV.Rows[e.RowIndex].Cells[3].Value?.ToString(); // ClientName
                PhoneTb.Text = SalesDGV.Rows[e.RowIndex].Cells[4].Value?.ToString(); // ClientPhone
                EmpIdCb.SelectedValue = SalesDGV.Rows[e.RowIndex].Cells[5].Value; // EmpId
                QuantityTb.Text = SalesDGV.Rows[e.RowIndex].Cells[6].Value?.ToString(); // Quantity

            }

        }
    }
}
