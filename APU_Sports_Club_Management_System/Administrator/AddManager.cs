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

    public partial class AddManager : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        void display()
        {

            con.Open();
            string query = " SELECT * FROM Manager";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public AddManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string managerID = addManagerID.Text.Trim(); // Assuming addCoach is your input field for Manager ID
            string username = addUsername.Text.Trim(); // Assuming addTimePicker is your input field for Username
            string password = addPassword.Text.Trim(); // Assuming addTrainingType is your input field for Password
            string firstName = addFirstName.Text.Trim(); // Assuming addTrainingLevel is your input field for First Name
            string lastName = addLastName.Text.Trim(); // Assuming addLastName is your input field for Last Name
            string email = addEmail.Text.Trim(); // Assuming addEmail is your input field for Email
            string phone = addPhone.Text.Trim(); // Assuming addPhone is your input field for Phone
            decimal salary = decimal.Parse(addSalary.Text); // Assuming addSalary is your input field for Salary

            if (string.IsNullOrEmpty(managerID) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Manager ID, Username, and Password");
                return;
            }

            // Query to insert manager details into the database
            string query = "INSERT INTO Manager ([Manager ID], Username, Password, FirstName, LastName, Email, Phone, Salary) " +
                           "VALUES (@ManagerID, @Username, @Password, @FirstName, @LastName, @Email, @Phone, @Salary)";

           // using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ManagerID", managerID);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Salary", salary);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Manager details added successfully");
                        // You can perform any additional actions here after adding the manager
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding Manager details: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int managerID;
            if (!int.TryParse(editManagerID.Text, out managerID))
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
            decimal salary = decimal.Parse(editSalary.Text); // Assuming editSalary is your input field for Salary

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Username and Password");
                return;
            }

            // Query to update manager details in the database
            string query = "UPDATE Manager SET Username=@Username, Password=@Password, " +
                           "FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, Salary=@Salary " +
                           "WHERE [Manager ID]=@ManagerID";

            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@ManagerID", managerID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Manager details updated successfully");
                            // You can perform any additional actions here after updating the manager details
                        }
                        else
                        {
                            MessageBox.Show("No manager found with the provided Manager ID");
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating manager details: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int managerID;
            if (!int.TryParse(delManagerID.Text, out managerID))
            {
                MessageBox.Show("Please enter a valid Manager ID");
                return;
            }

            string query = "DELETE FROM Manager WHERE [Manager ID]=@ManagerID";

            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ManagerID", managerID);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Manager deleted successfully");
                            // You can perform any additional actions here after deleting the manager
                        }
                        else
                        {
                            MessageBox.Show("No manager found with the provided Manager ID");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting manager: " + ex.Message);
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Manager";

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

        private void AddManager_Load(object sender, EventArgs e)
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
