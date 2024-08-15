using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Sports_Club_Management_System.Manager
{
    public partial class HomeManager : Form
    {
        public HomeManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageCompetitions mc = new ManageCompetitions();
            mc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewRecomendation vr = new ViewRecomendation();
            vr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AssignMember am = new AssignMember();
            am.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecordResult rr = new RecordResult();
            rr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateProfileManager up = new UpdateProfileManager();
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
