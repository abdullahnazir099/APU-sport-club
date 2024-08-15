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
    public partial class AddMember : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        void display()
        {

            con.Open();
            string query = " SELECT * FROM Member";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public AddMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string memberID = addManagerID.Text.Trim(); // Assuming addCoach is your input field for Manager ID
            string username = addUsername.Text.Trim(); // Assuming addTimePicker is your input field for Username
            string password = addPassword.Text.Trim(); // Assuming addTrainingType is your input field for Password
            string firstName = addFirstName.Text.Trim(); // Assuming addTrainingLevel is your input field for First Name
            string lastName = addLastName.Text.Trim(); // Assuming addLastName is your input field for Last Name
            string email = addEmail.Text.Trim(); // Assuming addEmail is your input field for Email
            string phone = addPhone.Text.Trim(); // Assuming addPhone is your input field for Phone

            if (string.IsNullOrEmpty(memberID) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Member ID, Username, and Password");
                return;
            }

            // Query to insert manager details into the database
            string query = "INSERT INTO Member (MemberID, Username, Password, FirstName, LastName, Email, Phone) " +
                           "VALUES (@MemberID, @Username, @Password, @FirstName, @LastName, @Email, @Phone)";

            // using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Member details added successfully");
                        // You can perform any additional actions here after adding the manager
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding Member details: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int memberID;
            if (!int.TryParse(editManagerID.Text, out memberID))
            {
                MessageBox.Show("Please enter a valid Manager ID");
                return;
            }

            string username = editusername.Text.Trim(); // Assuming editCoachID is your input field for Username
            string password = editPassword.Text.Trim(); // Assuming editdateTimePicker is your input field for Password
            string firstName = editfirstName.Text.Trim(); // Assuming editTrainingType is your input field for First Name
            string lastName = editlastName.Text.Trim(); // Assuming editTrainingLevel is your input field for Last Name
            string email = editEmail.Text.Trim(); // Assuming editEmail is your input field for Email
            string phone = editPhone.Text.Trim(); // Assuming editPhone is your input field for Phone

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Username and Password");
                return;
            }

            // Query to update manager details in the database
            string query = "UPDATE Member SET Username=@Username, Password=@Password, " +
                           "FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone " +
                           "WHERE MemberID=@MemberID";

            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@MemberID", memberID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member details updated successfully");
                            // You can perform any additional actions here after updating the manager details
                        }
                        
                        else
                        {
                            MessageBox.Show("No Member found with the provided Member ID");
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating Member details: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int memberID;
            if (!int.TryParse(delManagerID.Text, out memberID))
            {
                MessageBox.Show("Please enter a valid Member ID");
                return;
            }

            string query = "DELETE FROM Member WHERE MemberID=@MemberID";

            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@MemberID", memberID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member deleted successfully");
                            // You can perform any additional actions here after deleting the manager
                        }
                        else
                        {
                            MessageBox.Show("No Member found with the provided Member ID");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting Member: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Member";

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

        private void AddMember_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomeAdmin ha = new HomeAdmin();
            ha.Show();
            this.Hide();
        }
    }
}
