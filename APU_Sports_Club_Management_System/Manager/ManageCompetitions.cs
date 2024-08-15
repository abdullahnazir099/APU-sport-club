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

namespace APU_Sports_Club_Management_System.Manager
{
    public partial class ManageCompetitions : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        void display()
        {

            con.Open();
            string query = " SELECT * FROM Competitions";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public ManageCompetitions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string competitionName = addCompetitionName.Text.Trim();
            DateTime date = addTimePicker.Value;
            string location = addLocation.Text.Trim();
            string description = addDescription.Text.Trim();

            if (string.IsNullOrEmpty(competitionName) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please enter competition name and location");
                return;
            }

            // Query to insert competition details into the database
            string query = "INSERT INTO Competitions (CompetitionName, Date, Location, Description) " +
                           "VALUES (@CompetitionName, @Date, @Location, @Description)";


            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CompetitionName", competitionName);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Description", description);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Competition added successfully");
                        // You can perform any additional actions here after adding the competition
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding competition: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int competitionID;
            if (!int.TryParse(editCompetitionID.Text, out competitionID))
            {
                MessageBox.Show("Please enter a valid Competition ID");
                return;
            }

            string competitionName = editCompetitionName.Text.Trim();
            DateTime date = editdateTimePicker.Value;
            string location = editLocation.Text.Trim();
            string description = editDescription.Text.Trim();

            if (string.IsNullOrEmpty(competitionName) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please enter competition name and location");
                return;
            }

            // Query to update competition details in the database
            string query = "UPDATE Competitions SET CompetitionName=@CompetitionName, Date=@Date, " +
                           "Location=@Location, Description=@Description WHERE CompetitionID=@CompetitionID";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CompetitionName", competitionName);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@CompetitionID", competitionID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Competition updated successfully");
                            // You can perform any additional actions here after updating the competition
                        }
                        else
                        {
                            MessageBox.Show("No competition found with the provided Competition ID");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating competition: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int competitionID;
            if (!int.TryParse(delCompetitionID.Text, out competitionID))
            {
                MessageBox.Show("Please enter a valid Competition ID");
                return;
            }

            // Query to delete a competition based on the CompetitionID
            string query = "DELETE FROM Competitions WHERE CompetitionID=@CompetitionID";

            // using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CompetitionID", competitionID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Competition deleted successfully");
                            // You can perform any additional actions here after deleting the competition
                        }
                        else
                        {
                            MessageBox.Show("No competition found with the provided Competition ID");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting competition: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Competitions";

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

        private void ManageCompetitions_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomeManager hm = new HomeManager();
            hm.Show();
            this.Hide();
        }
    }
}
