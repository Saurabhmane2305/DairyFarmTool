namespace DairyFarmTool
{
    partial class Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            panel1 = new Panel();
            label16 = new Label();
            pictureBox8 = new PictureBox();
            GenCb = new ComboBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label11 = new Label();
            EmployeeDGV = new DataGridView();
            AddressTb = new TextBox();
            label10 = new Label();
            label9 = new Label();
            DOB = new DateTimePicker();
            PhoneTb = new TextBox();
            NameTb = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            label8 = new Label();
            EmpPassTb = new TextBox();
            pictureBox9 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmployeeDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label16);
            panel1.Controls.Add(pictureBox8);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 600);
            panel1.TabIndex = 50;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = SystemColors.ControlDark;
            label16.Font = new Font("Clarendon Blk BT", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = SystemColors.ControlLightLight;
            label16.Location = new Point(80, 44);
            label16.Name = "label16";
            label16.Size = new Size(177, 22);
            label16.TabIndex = 16;
            label16.Text = "Dairy Farm Tool\r\n";
            // 
            // pictureBox8
            // 
            pictureBox8.BorderStyle = BorderStyle.Fixed3D;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(3, 22);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(74, 61);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 15;
            pictureBox8.TabStop = false;
            // 
            // GenCb
            // 
            GenCb.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            GenCb.FormattingEnabled = true;
            GenCb.Items.AddRange(new object[] { "Male", "Female" });
            GenCb.Location = new Point(881, 139);
            GenCb.Name = "GenCb";
            GenCb.Size = new Size(146, 23);
            GenCb.TabIndex = 90;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDark;
            button4.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(870, 261);
            button4.Name = "button4";
            button4.Size = new Size(185, 42);
            button4.TabIndex = 89;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDark;
            button3.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(664, 261);
            button3.Name = "button3";
            button3.Size = new Size(185, 42);
            button3.TabIndex = 88;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(266, 261);
            button2.Name = "button2";
            button2.Size = new Size(185, 42);
            button2.TabIndex = 87;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(473, 261);
            button1.Name = "button1";
            button1.Size = new Size(185, 42);
            button1.TabIndex = 86;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Control;
            label11.Font = new Font("Century", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.Highlight;
            label11.Location = new Point(612, 316);
            label11.Name = "label11";
            label11.Size = new Size(147, 23);
            label11.TabIndex = 85;
            label11.Text = "Employees List";
            // 
            // EmployeeDGV
            // 
            EmployeeDGV.AllowUserToOrderColumns = true;
            EmployeeDGV.BackgroundColor = SystemColors.Control;
            EmployeeDGV.BorderStyle = BorderStyle.Fixed3D;
            EmployeeDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmployeeDGV.Cursor = Cursors.Cross;
            EmployeeDGV.Location = new Point(266, 364);
            EmployeeDGV.Name = "EmployeeDGV";
            EmployeeDGV.RowTemplate.Height = 25;
            EmployeeDGV.Size = new Size(793, 206);
            EmployeeDGV.TabIndex = 84;
            EmployeeDGV.CellContentClick += EmployeeDGV_CellContentClick;
            // 
            // AddressTb
            // 
            AddressTb.Location = new Point(543, 217);
            AddressTb.Name = "AddressTb";
            AddressTb.Size = new Size(261, 23);
            AddressTb.TabIndex = 83;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.Control;
            label10.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(640, 189);
            label10.Name = "label10";
            label10.Size = new Size(91, 25);
            label10.TabIndex = 82;
            label10.Text = "Address";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.Control;
            label9.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(650, 106);
            label9.Name = "label9";
            label9.Size = new Size(59, 25);
            label9.TabIndex = 81;
            label9.Text = "DOB";
            // 
            // DOB
            // 
            DOB.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DOB.Location = new Point(543, 139);
            DOB.Name = "DOB";
            DOB.Size = new Size(261, 27);
            DOB.TabIndex = 80;
            // 
            // PhoneTb
            // 
            PhoneTb.Location = new Point(328, 217);
            PhoneTb.Name = "PhoneTb";
            PhoneTb.Size = new Size(146, 23);
            PhoneTb.TabIndex = 78;
            // 
            // NameTb
            // 
            NameTb.Location = new Point(328, 139);
            NameTb.Name = "NameTb";
            NameTb.Size = new Size(146, 23);
            NameTb.TabIndex = 77;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(361, 178);
            label4.Name = "label4";
            label4.Size = new Size(74, 25);
            label4.TabIndex = 76;
            label4.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(364, 106);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 75;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Clarendon Blk BT", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(506, 0);
            label2.Name = "label2";
            label2.Size = new Size(322, 42);
            label2.TabIndex = 74;
            label2.Text = "Dairy Farm Tool\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(913, 111);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 73;
            label1.Text = "Gender";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(612, 58);
            label5.Name = "label5";
            label5.Size = new Size(119, 25);
            label5.TabIndex = 95;
            label5.Text = "Employees";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.Control;
            label8.Font = new Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(913, 178);
            label8.Name = "label8";
            label8.Size = new Size(106, 25);
            label8.TabIndex = 96;
            label8.Text = "Password";
            // 
            // EmpPassTb
            // 
            EmpPassTb.Location = new Point(890, 217);
            EmpPassTb.Name = "EmpPassTb";
            EmpPassTb.Size = new Size(146, 23);
            EmpPassTb.TabIndex = 97;
            // 
            // pictureBox9
            // 
            pictureBox9.BorderStyle = BorderStyle.Fixed3D;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(1023, 0);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(46, 32);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 98;
            pictureBox9.TabStop = false;
            pictureBox9.Click += pictureBox9_Click;
            // 
            // Employee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 600);
            Controls.Add(pictureBox9);
            Controls.Add(label8);
            Controls.Add(EmpPassTb);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(GenCb);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(NameTb);
            Controls.Add(button3);
            Controls.Add(PhoneTb);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(DOB);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(EmployeeDGV);
            Controls.Add(label10);
            Controls.Add(AddressTb);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Employee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee";
            Load += Employee_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmployeeDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label16;
        private PictureBox pictureBox8;
        private Panel panel8;
        private PictureBox pictureBox7;
        private Label label15;
        private Panel panel7;
        private PictureBox pictureBox6;
        private Label label14;
        private Panel panel6;
        private PictureBox pictureBox5;
        private Label label13;
        private Panel panel5;
        private PictureBox pictureBox4;
        private Label label12;
        private Panel panel4;
        private PictureBox pictureBox3;
        private Label label7;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Label label6;
        private Panel panel2;
        private PictureBox pictureBox1;
        private ComboBox GenCb;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label11;
        private DataGridView EmployeeDGV;
        private TextBox AddressTb;
        private Label label10;
        private Label label9;
        private DateTimePicker DOB;
        private TextBox PhoneTb;
        private TextBox NameTb;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label8;
        private TextBox EmpPassTb;
        private PictureBox pictureBox9;
    }
}