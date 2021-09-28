
namespace wolfPack_Assign3
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.specificDatePicker = new System.Windows.Forms.DateTimePicker();
            this.subPanel = new System.Windows.Forms.Panel();
            this.lowSub = new System.Windows.Forms.RadioButton();
            this.highSub = new System.Windows.Forms.RadioButton();
            this.avgSub = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.avgUser = new System.Windows.Forms.RadioButton();
            this.highUser = new System.Windows.Forms.RadioButton();
            this.lowUser = new System.Windows.Forms.RadioButton();
            this.silverAward = new System.Windows.Forms.CheckBox();
            this.goldAward = new System.Windows.Forms.CheckBox();
            this.platAward = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.subComboBox = new System.Windows.Forms.ComboBox();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.subPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Posts From a Specific Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(15, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "PostScore Per Subreddit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(15, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "PostScore Per User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(15, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Awards within a Subreddit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(15, 495);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(329, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "List of Subreddits Posted to By a User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(15, 615);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(325, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Points Threshold for Posts/Comment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(431, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Output";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(435, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(509, 658);
            this.textBox1.TabIndex = 7;
            // 
            // specificDatePicker
            // 
            this.specificDatePicker.Location = new System.Drawing.Point(19, 49);
            this.specificDatePicker.Name = "specificDatePicker";
            this.specificDatePicker.Size = new System.Drawing.Size(200, 20);
            this.specificDatePicker.TabIndex = 8;
            // 
            // subPanel
            // 
            this.subPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subPanel.Controls.Add(this.avgSub);
            this.subPanel.Controls.Add(this.highSub);
            this.subPanel.Controls.Add(this.lowSub);
            this.subPanel.Location = new System.Drawing.Point(19, 139);
            this.subPanel.Name = "subPanel";
            this.subPanel.Size = new System.Drawing.Size(231, 66);
            this.subPanel.TabIndex = 9;
            // 
            // lowSub
            // 
            this.lowSub.AutoSize = true;
            this.lowSub.Location = new System.Drawing.Point(8, 21);
            this.lowSub.Name = "lowSub";
            this.lowSub.Size = new System.Drawing.Size(64, 19);
            this.lowSub.TabIndex = 0;
            this.lowSub.TabStop = true;
            this.lowSub.Text = "Lowest";
            this.lowSub.UseVisualStyleBackColor = true;
            // 
            // highSub
            // 
            this.highSub.AutoSize = true;
            this.highSub.Location = new System.Drawing.Point(78, 21);
            this.highSub.Name = "highSub";
            this.highSub.Size = new System.Drawing.Size(67, 19);
            this.highSub.TabIndex = 1;
            this.highSub.TabStop = true;
            this.highSub.Text = "Highest";
            this.highSub.UseVisualStyleBackColor = true;
            // 
            // avgSub
            // 
            this.avgSub.AutoSize = true;
            this.avgSub.Location = new System.Drawing.Point(151, 21);
            this.avgSub.Name = "avgSub";
            this.avgSub.Size = new System.Drawing.Size(69, 19);
            this.avgSub.TabIndex = 2;
            this.avgSub.TabStop = true;
            this.avgSub.Text = "Average";
            this.avgSub.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.avgUser);
            this.panel1.Controls.Add(this.highUser);
            this.panel1.Controls.Add(this.lowUser);
            this.panel1.Location = new System.Drawing.Point(19, 282);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 66);
            this.panel1.TabIndex = 10;
            // 
            // avgUser
            // 
            this.avgUser.AutoSize = true;
            this.avgUser.Location = new System.Drawing.Point(151, 21);
            this.avgUser.Name = "avgUser";
            this.avgUser.Size = new System.Drawing.Size(69, 19);
            this.avgUser.TabIndex = 2;
            this.avgUser.TabStop = true;
            this.avgUser.Text = "Average";
            this.avgUser.UseVisualStyleBackColor = true;
            // 
            // highUser
            // 
            this.highUser.AutoSize = true;
            this.highUser.Location = new System.Drawing.Point(78, 21);
            this.highUser.Name = "highUser";
            this.highUser.Size = new System.Drawing.Size(67, 19);
            this.highUser.TabIndex = 1;
            this.highUser.TabStop = true;
            this.highUser.Text = "Highest";
            this.highUser.UseVisualStyleBackColor = true;
            // 
            // lowUser
            // 
            this.lowUser.AutoSize = true;
            this.lowUser.Location = new System.Drawing.Point(8, 21);
            this.lowUser.Name = "lowUser";
            this.lowUser.Size = new System.Drawing.Size(64, 19);
            this.lowUser.TabIndex = 0;
            this.lowUser.TabStop = true;
            this.lowUser.Text = "Lowest";
            this.lowUser.UseVisualStyleBackColor = true;
            // 
            // silverAward
            // 
            this.silverAward.AutoSize = true;
            this.silverAward.Location = new System.Drawing.Point(19, 411);
            this.silverAward.Name = "silverAward";
            this.silverAward.Size = new System.Drawing.Size(56, 19);
            this.silverAward.TabIndex = 11;
            this.silverAward.Text = "Silver";
            this.silverAward.UseVisualStyleBackColor = true;
            // 
            // goldAward
            // 
            this.goldAward.AutoSize = true;
            this.goldAward.Location = new System.Drawing.Point(19, 436);
            this.goldAward.Name = "goldAward";
            this.goldAward.Size = new System.Drawing.Size(52, 19);
            this.goldAward.TabIndex = 12;
            this.goldAward.Text = "Gold";
            this.goldAward.UseVisualStyleBackColor = true;
            // 
            // platAward
            // 
            this.platAward.AutoSize = true;
            this.platAward.Location = new System.Drawing.Point(19, 461);
            this.platAward.Name = "platAward";
            this.platAward.Size = new System.Drawing.Size(75, 19);
            this.platAward.TabIndex = 13;
            this.platAward.Text = "Platinum";
            this.platAward.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(110, 411);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Subreddit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.OrangeRed;
            this.label9.Location = new System.Drawing.Point(15, 532);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "User";
            // 
            // subComboBox
            // 
            this.subComboBox.FormattingEnabled = true;
            this.subComboBox.Location = new System.Drawing.Point(119, 445);
            this.subComboBox.Name = "subComboBox";
            this.subComboBox.Size = new System.Drawing.Size(204, 21);
            this.subComboBox.TabIndex = 16;
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(19, 554);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(304, 21);
            this.userComboBox.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 719);
            this.Controls.Add(this.userComboBox);
            this.Controls.Add(this.subComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.platAward);
            this.Controls.Add(this.goldAward);
            this.Controls.Add(this.silverAward);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.subPanel);
            this.Controls.Add(this.specificDatePicker);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.subPanel.ResumeLayout(false);
            this.subPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker specificDatePicker;
        private System.Windows.Forms.Panel subPanel;
        private System.Windows.Forms.RadioButton highSub;
        private System.Windows.Forms.RadioButton lowSub;
        private System.Windows.Forms.RadioButton avgSub;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton avgUser;
        private System.Windows.Forms.RadioButton highUser;
        private System.Windows.Forms.RadioButton lowUser;
        private System.Windows.Forms.CheckBox silverAward;
        private System.Windows.Forms.CheckBox goldAward;
        private System.Windows.Forms.CheckBox platAward;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox subComboBox;
        private System.Windows.Forms.ComboBox userComboBox;
    }
}

