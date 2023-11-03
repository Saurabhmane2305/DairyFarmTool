namespace DairyFarmTool
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            panel1 = new Panel();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            UnameTb = new TextBox();
            PasswordTb = new TextBox();
            button1 = new Button();
            RoleCb = new ComboBox();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 684);
            panel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlDark;
            label7.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(67, 375);
            label7.Name = "label7";
            label7.Size = new Size(170, 25);
            label7.TabIndex = 8;
            label7.Text = "Professionalism\r\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlDark;
            label5.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(67, 203);
            label5.Name = "label5";
            label5.Size = new Size(136, 50);
            label5.TabIndex = 7;
            label5.Text = "Nice Quality\r\n\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlDark;
            label6.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(67, 288);
            label6.Name = "label6";
            label6.Size = new Size(150, 25);
            label6.TabIndex = 6;
            label6.Text = "Echo Friendly\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Clarendon Blk BT", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(320, 52);
            label1.Name = "label1";
            label1.Size = new Size(322, 42);
            label1.TabIndex = 2;
            label1.Text = "Dairy Farm Tool\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(380, 119);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(216, 134);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(296, 350);
            label2.Name = "label2";
            label2.Size = new Size(124, 50);
            label2.TabIndex = 4;
            label2.Text = "\r\nUser Name\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(296, 418);
            label3.Name = "label3";
            label3.Size = new Size(106, 75);
            label3.TabIndex = 5;
            label3.Text = "\r\nPassword\r\n\r\n";
            // 
            // UnameTb
            // 
            UnameTb.Font = new Font("Sanskrit Text", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            UnameTb.Location = new Point(426, 371);
            UnameTb.Name = "UnameTb";
            UnameTb.Size = new Size(231, 37);
            UnameTb.TabIndex = 6;
            UnameTb.TextChanged += textBox1_TextChanged;
            // 
            // PasswordTb
            // 
            PasswordTb.Font = new Font("Sanskrit Text", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordTb.Location = new Point(426, 437);
            PasswordTb.Name = "PasswordTb";
            PasswordTb.PasswordChar = '*';
            PasswordTb.Size = new Size(231, 37);
            PasswordTb.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(411, 510);
            button1.Name = "button1";
            button1.Size = new Size(185, 42);
            button1.TabIndex = 8;
            button1.Text = "Login\r\n";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // RoleCb
            // 
            RoleCb.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            RoleCb.FormattingEnabled = true;
            RoleCb.Items.AddRange(new object[] { "Admin", "Employee" });
            RoleCb.Location = new Point(380, 280);
            RoleCb.Name = "RoleCb";
            RoleCb.Size = new Size(203, 33);
            RoleCb.TabIndex = 9;
            RoleCb.Text = "Select Role";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(477, 579);
            label4.Name = "label4";
            label4.Size = new Size(67, 50);
            label4.TabIndex = 10;
            label4.Text = "Reset\r\n\r\n";
            label4.Click += label4_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(653, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(698, 684);
            Controls.Add(pictureBox2);
            Controls.Add(label4);
            Controls.Add(RoleCb);
            Controls.Add(button1);
            Controls.Add(PasswordTb);
            Controls.Add(UnameTb);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "login";
            Load += login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private TextBox UnameTb;
        private TextBox PasswordTb;
        private Button button1;
        private ComboBox RoleCb;
        private Label label6;
        private Label label4;
        private Label label7;
        private Label label5;
        private PictureBox pictureBox2;
    }
}