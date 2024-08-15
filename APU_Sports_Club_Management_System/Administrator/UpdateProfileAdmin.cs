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

namespace APU_Sports_Club_Management_System.Administrator
{

    public partial class UpdateProfileAdmin : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");
        public UpdateProfileAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int adminID;
            if (!int.TryParse(coachID.Text, out adminID))
            {
                MessageBox.Show("Please enter a valid Administrator ID");
                return;
            }

            string username = Username.Text.Trim();
            string password = Password.Text.Trim();


            // Query to update manager profile details in the database
            string query = "UPDATE Administrator SET Username=@Username, Password=@Password  " +
                           "WHERE admin_id=@admin_id";

            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@admin_id", adminID);
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
                            MessageBox.Show("No Administrator found with the provided Administrator ID");
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
            HomeAdmin ha = new HomeAdmin();
            ha.Show();
            this.Show();
        }
    }
}
