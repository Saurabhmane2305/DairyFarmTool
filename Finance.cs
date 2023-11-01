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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            populateExp();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {


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

        private void label15_Click(object sender, EventArgs e)
        {

            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void populateExp()
        {
            Con.Open();
            string query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Gather data from your UI controls
            DateTime expDate = ExpDate.Value;
            string expPurpose = PurpCb.Text;
            decimal expAmount = decimal.Parse(AmountTb.Text);
            int empId = 1; // Set EmpId to a constant value (e.g., 1)

            // Establish a database connection (replace with your connection string)
            string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30");
            using (SqlConnection connection = new SqlConnection((@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30")))
            {
                connection.Open();

                // Define a SQL query to insert a new expenditure record
                string insertQuery = "INSERT INTO ExpenditureTbl (ExpDate, ExpPurpose, ExpAmount, EmpIdLbl) VALUES (@Date, @Purpose, @Amount, @EmpId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", expDate);
                    cmd.Parameters.AddWithValue("@Purpose", expPurpose);
                    cmd.Parameters.AddWithValue("@Amount", expAmount);
                    cmd.Parameters.AddWithValue("@EmpId", empId);

                    // Execute the query and retrieve the new ExpId
                    int newExpId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Optionally, you can use the newExpId or perform additional actions here

                    // Close the connection
                    connection.Close();
                }
            }

            // Optionally, provide user feedback or reset UI controls
            MessageBox.Show("Expenditure record saved successfully.");
            ExpDate.Value = DateTime.Now; // Reset date to today

            AmountTb.Clear();
        }
        private void FilterExpenses(DateTime filterDate)
        {
            try
            {
                // Clear the current selection to avoid the "row associated with the CurrencyManager's position" error
                ExpDGV.CurrentCell = null;

                // Iterate through the rows of the DataGridView and hide/show rows based on the filter criteria
                foreach (DataGridViewRow row in ExpDGV.Rows)
                {
                    if (!row.IsNewRow) // Check if the row is not a new row
                    {
                        if (row.Cells["ExpDate"].Value is DateTime expenseDate)
                        {
                            if (expenseDate.Date == filterDate.Date)
                            {
                                // Show rows that match the filter criteria (matching date)
                                row.Visible = true;
                            }
                            else
                            {
                                // Hide rows that don't match the filter criteria (non-matching date)
                                row.Visible = false;
                            }
                        }
                        else
                        {
                            // Handle invalid date values in the "ExpDate" column
                            row.Visible = false; // Or display a message or log the issue
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                // Handle exceptions that may occur during filtering (e.g., data type conversion issues)
                MessageBox.Show("An error occurred while filtering expenses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExpDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if a valid cell was clicked (not a header cell)
                // Access the data from the selected row
                int expId = Convert.ToInt32(ExpDGV.Rows[e.RowIndex].Cells["ExpId"].Value);
                string expDate = ExpDGV.Rows[e.RowIndex].Cells["ExpDate"].Value.ToString();
                string expPurpose = ExpDGV.Rows[e.RowIndex].Cells["ExpPurpose"].Value.ToString();
                decimal expAmount = Convert.ToDecimal(ExpDGV.Rows[e.RowIndex].Cells["ExpAmount"].Value);

                // Now you have access to the data in the selected row
                // You can use this data as needed
            }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            PopulateIncomeDataGridView();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Gather data from your UI controls
            DateTime incDate = IncDate.Value;
            string incPurpose = IncPurposeCb.Text;
            decimal incAmount = decimal.Parse(IncAmtTb.Text);
            int empId = 1;

            // Establish a database connection (replace with your connection string)
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define a SQL query to insert a new income record
                string insertQuery = "INSERT INTO IncomeTbl (IncDate, IncPurpose, IncAmt, EmpId) VALUES (@Date, @Purpose, @Amount, @EmpId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Date", incDate);
                    cmd.Parameters.AddWithValue("@Purpose", incPurpose);
                    cmd.Parameters.AddWithValue("@Amount", incAmount);
                    cmd.Parameters.AddWithValue("@EmpId", empId);

                    // Execute the query and retrieve the new IncId
                    int newIncId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Optionally, you can use the newIncId or perform additional actions here

                    // Close the connection
                    connection.Close();
                }
            }

            // Populate the DataGridView with the latest income records
            PopulateIncomeDataGridView();

            // Optionally, provide user feedback or reset UI controls
            MessageBox.Show("Income record saved successfully.");
            IncDate.Value = DateTime.Now; // Reset date to today
            IncAmtTb.Clear();
        }

        private void PopulateIncomeDataGridView()
        {
            // Establish a database connection
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define a SQL query to select all income records
                string selectQuery = "SELECT * FROM IncomeTbl";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Create a DataTable to store the data
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        IncomeDGV.DataSource = dataTable;
                    }
                }

                // Close the connection
                connection.Close();
            }
        }

        // Call PopulateIncomeDataGridView to initially populate the DataGridView
        private void FilterIncome(DateTime filterDate)
        {
            try
            {
                // Clear the current selection to avoid the "row associated with the CurrencyManager's position" error
                IncomeDGV.CurrentCell = null;

                // Iterate through the rows of the DataGridView and hide/show rows based on the filter criteria
                foreach (DataGridViewRow row in IncomeDGV.Rows)
                {
                    if (!row.IsNewRow) // Check if the row is not a new row
                    {
                        if (row.Cells["IncDate"].Value is DateTime incomeDate)
                        {
                            if (incomeDate.Date == filterDate.Date)
                            {
                                // Show rows that match the filter criteria (matching date)
                                row.Visible = true;
                            }
                            else
                            {
                                // Hide rows that don't match the filter criteria (non-matching date)
                                row.Visible = false;
                            }
                        }
                        else
                        {
                            // Handle invalid date values in the "IncDate" column
                            row.Visible = false; // Or display a message or log the issue
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during filtering (e.g., data type conversion issues)
                MessageBox.Show("An error occurred while filtering data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void IncomeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if a valid cell was clicked (not a header cell)
                // Access the data from the selected row
                int incId = Convert.ToInt32(IncomeDGV.Rows[e.RowIndex].Cells["IncId"].Value);
                string incDate = IncomeDGV.Rows[e.RowIndex].Cells["IncDate"].Value.ToString();
                string incPurpose = IncomeDGV.Rows[e.RowIndex].Cells["IncPurpose"].Value.ToString();
                decimal incAmt = Convert.ToDecimal(IncomeDGV.Rows[e.RowIndex].Cells["IncAmt"].Value);
                int empId = Convert.ToInt32(IncomeDGV.Rows[e.RowIndex].Cells["EmpId"].Value);

                // Now you have access to the data in the selected row
                // You can use this data as needed
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(Filterdate.Text, out DateTime filterDate))
            {
                FilterIncome(filterDate);
            }
            else
            {
                // Handle the case where the user's input is not a valid date
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(Filterdate.Text, out DateTime filterDate))
            {
                FilterExpenses(filterDate);
            }
            else
            {
                // Handle the case where the user's input is not a valid date
            }


        }

    }




}
