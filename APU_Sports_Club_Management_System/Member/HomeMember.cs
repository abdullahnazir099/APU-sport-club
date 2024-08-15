using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Sports_Club_Management_System.Member
{
    public partial class HomeMember : Form
    {
        public HomeMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnrollAndPay ep = new EnrollAndPay();
            ep.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Unenroll ep = new Unenroll();
            ep.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OwnTrainingSchedule ep = new OwnTrainingSchedule();
            ep.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OwnPerformanceRecord ep = new OwnPerformanceRecord();
            ep.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Competitions ep = new Competitions();
            ep.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SendSuggestion ep = new SendSuggestion();
            ep.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateProfileMember ep = new UpdateProfileMember();
            ep.Show();
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
