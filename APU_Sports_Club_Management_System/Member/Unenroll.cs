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

namespace APU_Sports_Club_Management_System.Member
{
    public partial class Unenroll : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        void display()
        {
            //SELECT totalfee FROM updaterequest AND
            con.Open();
            string query = " SELECT * FROM Member_Training_Schedules";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public Unenroll()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get user input for enrollment ID
            string input = EnrollmentID.Text; // Assuming txtEnrollmentID is a TextBox where user enters the enrollment ID
            if (!int.TryParse(input, out int enrollmentId))
            {
                MessageBox.Show("Invalid input. Please enter a valid enrollment ID.");
                return; // Exit the method if input is not a valid integer
            }

            {
                // Construct the SQL query to delete the row from the Enrollments table
                string sqlQuery = "DELETE FROM Member_Training_Schedules WHERE training_id = @training_id";

                // Create a SqlCommand object
                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@training_id", enrollmentId);

                    // Open the connection
                    con.Open();

                    try
                    {
                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were deleted
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Enrollment deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Enrollment not found or already deleted.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                        // Handle the exception
                    }
                }
            }
        }

        private void Unenroll_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeMember hm = new HomeMember();
            hm.Show();
            this.Hide();
        }
    }
}
