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
    public partial class SendSuggestion : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");
        public SendSuggestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || message.Text == "")
            {
                MessageBox.Show("All field is required", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string query = "INSERT INTO Suggestions VALUES (@username  , @suggestion_text)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@suggestion_text", message.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Suggestion Sended", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
