
namespace APU_Sports_Club_Management_System.Coach
{
    partial class RecordPerformance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button5 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.MemberID = new System.Windows.Forms.TextBox();
            this.DateTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.PerformanceDetails = new System.Windows.Forms.TextBox();
            this.coachID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(139, 497);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 23);
            this.button5.TabIndex = 101;
            this.button5.Text = "Back to Home";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(72, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(362, 42);
            this.label11.TabIndex = 100;
            this.label11.Text = "Performance Record";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 99;
            this.button1.Text = "Record";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(136, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 98;
            this.label10.Text = "Membr ID";
            // 
            // MemberID
            // 
            this.MemberID.Location = new System.Drawing.Point(139, 161);
            this.MemberID.Name = "MemberID";
            this.MemberID.Size = new System.Drawing.Size(204, 20);
            this.MemberID.TabIndex = 97;
            // 
            // DateTime
            // 
            this.DateTime.CustomFormat = "yyyy-MM-dd";
            this.DateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTime.Location = new System.Drawing.Point(139, 308);
            this.DateTime.Name = "DateTime";
            this.DateTime.Size = new System.Drawing.Size(204, 20);
            this.DateTime.TabIndex = 96;
            this.DateTime.Value = new System.DateTime(2024, 3, 13, 2, 24, 29, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "Performance Date";
            // 
            // PerformanceDetails
            // 
            this.PerformanceDetails.Location = new System.Drawing.Point(139, 386);
            this.PerformanceDetails.Multiline = true;
            this.PerformanceDetails.Name = "PerformanceDetails";
            this.PerformanceDetails.Size = new System.Drawing.Size(204, 85);
            this.PerformanceDetails.TabIndex = 94;
            // 
            // coachID
            // 
            this.coachID.Location = new System.Drawing.Point(139, 223);
            this.coachID.Name = "coachID";
            this.coachID.Size = new System.Drawing.Size(204, 20);
            this.coachID.TabIndex = 93;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Performance Details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Coach ID";
            // 
            // RecordPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 561);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MemberID);
            this.Controls.Add(this.DateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PerformanceDetails);
            this.Controls.Add(this.coachID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Name = "RecordPerformance";
            this.Text = "RecordPerformance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox MemberID;
        private System.Windows.Forms.DateTimePicker DateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PerformanceDetails;
        private System.Windows.Forms.TextBox coachID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}