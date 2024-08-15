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

namespace APU_Sports_Club_Management_System.Coach
{
    public partial class UpdateProfileCoach : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");


        public UpdateProfileCoach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CoachID;
            if (!int.TryParse(coachID.Text, out CoachID))
            {
                MessageBox.Show("Please enter a valid Manager ID");
                return;
            }

            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            // Query to update manager profile details in the database
            string query = "UPDATE Coach SET Username=@Username, Password=@Password  " +
                           "WHERE CoachID=@CoachID";

            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CoachID", CoachID);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile updated successfully");
                            // You can perform any additional actions here after updating the profile
                        }
                        else
                        {
                            MessageBox.Show("No manager found with the provided Manager ID");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating profile: " + ex.Message);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomeCoach hc = new HomeCoach();
            hc.Show();
            this.Hide();
        }
    }
}
