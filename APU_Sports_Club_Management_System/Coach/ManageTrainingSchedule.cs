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
    public partial class ManageTrainingSchedule : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        void display()
        {

            con.Open();
            string query = " SELECT * FROM TrainingSchedules";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public ManageTrainingSchedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CoachID = addCoachID.Text.Trim();
            DateTime date = addTimePicker.Value;
            string TrainingType = addTrainingType.Text.Trim();
            string TrainingLevel = addTrainingLevel
                .Text.Trim();

            if (string.IsNullOrEmpty(CoachID) || string.IsNullOrEmpty(TrainingType))
            {
                MessageBox.Show("Please enter Coach ID name and Training Type");
                return;
            }

            // Query to insert competition details into the database
            string query = "INSERT INTO TrainingSchedules (CoachID, Date, TrainingType, TrainingLevel) " +
                           "VALUES (@CoachID, @Date, @TrainingType, @TrainingLevel)";


            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CoachID", CoachID);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@TrainingType", TrainingType);
                    command.Parameters.AddWithValue("@TrainingLevel", TrainingLevel);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Training Schedule added successfully");
                        // You can perform any additional actions here after adding the competition
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding Training Schedule: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int scheduleID;
            if (!int.TryParse(editScheduleID.Text, out scheduleID))
            {
                MessageBox.Show("Please enter a valid Competition ID");
                return;
            }

            string coachID = editCoachID.Text.Trim();
            DateTime date = editdateTimePicker.Value;
            string TrainingType = editTrainingType.Text.Trim();
            string TrainingLevel = editTrainingLevel.Text.Trim();

            if (string.IsNullOrEmpty(coachID) || string.IsNullOrEmpty(TrainingType))
            {
                MessageBox.Show("Please enter coach ID and Training Type");
                return;
            }

            // Query to update competition details in the database
            string query = "UPDATE TrainingSchedules SET CoachID=@CoachID, Date=@Date, " +
                           "TrainingType=@TrainingType, TrainingLevel=@TrainingLevel WHERE ScheduleID=@ScheduleID";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CoachID", coachID);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@TrainingType", TrainingType);
                    command.Parameters.AddWithValue("@TrainingLevel", TrainingLevel);
                    command.Parameters.AddWithValue("@ScheduleID", scheduleID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Training Schedule updated successfully");
                            // You can perform any additional actions here after updating the competition
                        }
                        else
                        {
                            MessageBox.Show("No Training Schedule found with the provided Schedule ID");
                        }
                        con.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating Training Schedule: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int scheduleID;
            if (!int.TryParse(delScheduleID.Text, out scheduleID))
            {
                MessageBox.Show("Please enter a valid Schedule ID");
                return;
            }

            string query = "DELETE FROM TrainingSchedules WHERE ScheduleID=@ScheduleID";

            // using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ScheduleID", scheduleID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Training Schedule deleted successfully");
                            // You can perform any additional actions here after deleting the competition
                        }
                        else
                        {
                            MessageBox.Show("No Training Schedule found with the provided Schedule ID");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting Training Schedule: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TrainingSchedules";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataGridView to the new data source
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void ManageTrainingSchedule_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomeCoach hc = new HomeCoach();
            hc.Show();
            this.Hide();
        }
    }
}
