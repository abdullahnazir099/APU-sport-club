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
    public partial class SummaryCompetition : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");

        void display()
        {
            con.Open();
            string query = " SELECT CompetitionID, MemberID, Rank FROM Results";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public SummaryCompetition()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeAdmin ha = new HomeAdmin();
            ha.Show();
            this.Hide();
        }

        private void SummaryCompetition_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
