using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Sports_Club_Management_System.Administrator
{
    public partial class HomeAdmin : Form
    {
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddManager am = new AddManager();
            am.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddCoach ac = new AddCoach();
            ac.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMember am = new AddMember();
            am.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateProfileAdmin am = new UpdateProfileAdmin();
            am.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MonthlyIncome am = new MonthlyIncome();
            am.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewSuggestion am = new ViewSuggestion();
            am.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SummaryCompetition am = new SummaryCompetition();
            am.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
        }
    }
}
