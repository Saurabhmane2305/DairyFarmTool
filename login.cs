using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyFarmTool
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\DairyFarmToolDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter the UserName and Password");
            }
            else
            {
                if (RoleCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Role");
                }
                else
                {
                    if (RoleCb.SelectedItem.ToString() == "Admin")
                    {
                        // Check the Admin Name and Password
                        if (UnameTb.Text == "Admin" && PasswordTb.Text == "2005")
                        {
                            // Successfully logged in as Admin
                            Employee emp = new Employee();
                            emp.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Admin Name or Password");
                        }
                    }
                    else if (RoleCb.SelectedItem.ToString() == "Employee")
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM EmployeeTbl WHERE EmpName = @Uname AND EmpPass = @Password", Con);
                        sda.SelectCommand.Parameters.AddWithValue("@Uname", UnameTb.Text);
                        sda.SelectCommand.Parameters.AddWithValue("@Password", PasswordTb.Text);

                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        Con.Close();

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            // Successfully logged in as an Employee
                            Cows cow = new Cows();
                            cow.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Role");
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
