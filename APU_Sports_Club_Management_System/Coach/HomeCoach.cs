using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Sports_Club_Management_System.Coach
{
    public partial class HomeCoach : Form
    {
        public HomeCoach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageTrainingSchedule mts = new ManageTrainingSchedule();
            mts.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewPayments vp = new ViewPayments();
            vp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordPerformance rp = new RecordPerformance();
            rp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendRecomendation sr = new SendRecomendation();
            sr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateProfileCoach up = new UpdateProfileCoach();
            up.Show();
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
