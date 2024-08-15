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
    public partial class SendRecomendation : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        public SendRecomendation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CoachID = coachID.Text.Trim();
            string memberID = MemberID.Text.Trim();
            DateTime date = DateTime.Value;
            string RecommendationDetails = RecomendationDetails.Text.Trim();

            if (string.IsNullOrEmpty(memberID) || string.IsNullOrEmpty(CoachID))
            {
                MessageBox.Show("Please enter Member ID name and Coach ID");
                return;
            }

            // Query to insert competition details into the database
            string query = "INSERT INTO Recommendations (CoachID, MemberID, RecommendationDate, RecommendationDetails) " +
                           "VALUES (@CoachID, @MemberID, @RecommendationDate, @RecommendationDetails)";


            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CoachID", CoachID);
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    command.Parameters.AddWithValue("@RecommendationDate", date);
                    command.Parameters.AddWithValue("@RecommendationDetails", RecommendationDetails);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Recomendation added successfully");
                        // You can perform any additional actions here after adding the competition
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding Recomendations record: " + ex.Message);
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
