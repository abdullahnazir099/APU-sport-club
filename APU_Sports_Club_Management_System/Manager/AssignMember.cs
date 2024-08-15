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
    public partial class AssignMember : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        public AssignMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int competitionID, memberID;
            if (!int.TryParse(CompetitionID.Text, out competitionID) || !int.TryParse(MemberID.Text, out memberID))
            {
                MessageBox.Show("Please enter valid Competition ID and Member ID");
                return;
            }

            DateTime assignedDate = dateTimePicker.Value;

            // Query to insert assignment details into the database
            string query = "INSERT INTO AssignedMembers (CompetitionID, MemberID, AssignedDate) " +
                           "VALUES (@CompetitionID, @MemberID, @AssignedDate)";


            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CompetitionID", competitionID);
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    command.Parameters.AddWithValue("@AssignedDate", assignedDate);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Member Assigned successfully");
                        // You can perform any additional actions here after adding the assignment
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding assignment: " + ex.Message);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomeManager hm = new HomeManager();
            hm.Show();
            this.Hide();
        }
    }
}
