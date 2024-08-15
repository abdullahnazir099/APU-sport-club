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
    public partial class EnrollAndPay : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        public EnrollAndPay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || level.Text == "" || date.Text == "" || payment.Text == "" || TrainingType.Text == "")
            {
                MessageBox.Show("All field is required", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string query = "INSERT INTO Member_Training_Schedules VALUES (@member_id ,@level ,@training_date, @training_type, @payment_status)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@member_id", id.Text);
                cmd.Parameters.AddWithValue("@level", level.Text);
                cmd.Parameters.AddWithValue("@training_date", date.Text);
                cmd.Parameters.AddWithValue("@training_type", TrainingType.Text);
                cmd.Parameters.AddWithValue("@payment_status", payment.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Enrollment Succesfull", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeMember hm = new HomeMember();
            hm.Show();
            this.Hide();
        }
    }
}
