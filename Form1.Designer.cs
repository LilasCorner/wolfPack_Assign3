
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
            this.label4.Size = new System.Drawing.Size(215, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "PostScore Per Subreddit";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 719);
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
    }
}

