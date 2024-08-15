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
    public partial class RecordPerformance : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        public RecordPerformance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string memberID = MemberID.Text.Trim();
            string CoachID = coachID.Text.Trim();
            DateTime date = DateTime.Value;
            string Performancedetails = PerformanceDetails.Text.Trim();

            if (string.IsNullOrEmpty(memberID) || string.IsNullOrEmpty(Performancedetails))
            {
                MessageBox.Show("Please enter Member ID name and Performance Details");
                return;
            }

            // Query to insert competition details into the database
            string query = "INSERT INTO PerformanceRecords (MemberID, CoachID, PerformanceDate, PerformanceDetails) " +
                           "VALUES (@MemberID, @CoachID, @PerformanceDate, @PerformanceDetails)";


            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    command.Parameters.AddWithValue("@CoachID", CoachID);
                    command.Parameters.AddWithValue("@PerformanceDate", date);
                    command.Parameters.AddWithValue("@PerformanceDetails", Performancedetails);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Performance Recorded successfully");
                        // You can perform any additional actions here after adding the competition
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding Performance record: " + ex.Message);
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
