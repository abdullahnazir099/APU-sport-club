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
    public partial class RecordResult : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        void display()
        {
            //SELECT totalfee FROM updaterequest AND
            con.Open();
            string query = " SELECT * FROM Results";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public RecordResult()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int competitionID, memberID, rank;
            decimal score;

            if (!int.TryParse(CompetitionID.Text, out competitionID) ||
                !int.TryParse(MemberID.Text, out memberID) ||
                !decimal.TryParse(Score.Text, out score) ||
                !int.TryParse(Rank.Text, out rank)
                )
            {
                MessageBox.Show("Please enter valid data");
                return;
            }

            // Query to insert result details into the database
            string query = "INSERT INTO Results (CompetitionID, MemberID, Score, Rank) " +
                           "VALUES (@CompetitionID, @MemberID, @Score, @Rank)";

            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CompetitionID", competitionID);
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    command.Parameters.AddWithValue("@Score", score);
                    command.Parameters.AddWithValue("@Rank", rank);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Result recorded successfully");
                        // You can perform any additional actions here after adding the result
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding result: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Results";

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

        private void RecordResult_Load(object sender, EventArgs e)
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
