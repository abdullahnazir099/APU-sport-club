﻿using System;
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
    public partial class OwnTrainingSchedule : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-KTQKC01\\SQLEXPRESS;Initial Catalog=APU_Sports_Club_Management_System;Integrated Security=True");


        private void SearchByUsername(string username)
        {
            try
            {
                //using (SqlConnection connection = new SqlConnection(SqlConnection))
                {
                    con.Open();

                    string query = "SELECT * FROM Member_Training_Schedules WHERE member_id = @member_id";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@member_id", username);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            DataTable.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public OwnTrainingSchedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            if (!string.IsNullOrEmpty(username))
            {
                SearchByUsername(username);
            }
            else
            {
                MessageBox.Show("Please enter a username.");
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

