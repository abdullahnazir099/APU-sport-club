using APU_Sports_Club_Management_System.Administrator;
using APU_Sports_Club_Management_System.Coach;
using APU_Sports_Club_Management_System.Manager;
using APU_Sports_Club_Management_System.Member;
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

namespace APU_Sports_Club_Management_System
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            string role = AuthenticateUser(username, password);

            if (role != null)
            {
                MessageBox.Show($"Welcome, {username}!");
                // Open the main application form or home form for the user
                // You can pass the username and role to the main form if needed
                switch (role)
                {
                    case "Administrator":
                        OpenAdministratorHomePage();
                        break;
                    case "Manager":
                        OpenManagerHomePage();
                        break;
                    case "Member":
                        OpenMemberHomePage();
                        break;
                    case "Coach":
                        OpenCoachHomePage();
                        break;
                    default:
                        MessageBox.Show("Invalid role.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private string AuthenticateUser(string username, string password)
        {
            string[] tables = { "Administrator", "Manager", "Member", "Coach" };

            foreach (string table in tables)
            {
                string query = $"SELECT COUNT(*) FROM {table} WHERE Username = @Username AND Password = @Password";

                //using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        con.Open();
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            return table; // Return the role if user is found in a table
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return null; // Return null if user is not found in any table
        }


        private void OpenAdministratorHomePage()
        {
            // Open the Administrator Home form
            HomeAdmin adminHomePage = new HomeAdmin();
            adminHomePage.Show();
            this.Hide(); // Hide the login form
        }

        private void OpenManagerHomePage()
        {
            // Open the Manager Home form
            HomeManager managerHomePage = new HomeManager();
            managerHomePage.Show();
            this.Hide(); // Hide the login form
        }

        private void OpenMemberHomePage()
        {
            // Open the Member Home form
            HomeMember memberHomePage = new HomeMember();
            memberHomePage.Show();
            this.Hide(); // Hide the login form
        }

        private void OpenCoachHomePage()
        {
            // Open the Coach Home form
            HomeCoach coachHomePage = new HomeCoach();
            coachHomePage.Show();
            this.Hide(); // Hide the login form
        }
    }
}
