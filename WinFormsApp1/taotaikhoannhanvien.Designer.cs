namespace WinFormsApp1
{
    partial class taotaikhoannhanvien
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
            panel2 = new Panel();
            panel4 = new Panel();
            txusernam = new TextBox();
            lpusername = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            textBox1 = new TextBox();
            NAME = new Label();
            btlogin = new Button();
            thoatAC = new Button();
            panel5 = new Panel();
            username = new TextBox();
            mkusername = new Label();
            panel6 = new Panel();
            textBox3 = new TextBox();
            label2 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(txusernam);
            panel2.Controls.Add(lpusername);
            panel2.Location = new Point(12, 23);
            panel2.Name = "panel2";
            panel2.Size = new Size(728, 69);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Location = new Point(136, 67);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 125);
            panel4.TabIndex = 2;
            // 
            // txusernam
            // 
            txusernam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txusernam.Location = new Point(253, 12);
            txusernam.Name = "txusernam";
            txusernam.Size = new Size(455, 34);
            txusernam.TabIndex = 1;
            // 
            // lpusername
            // 
            lpusername.AutoSize = true;
            lpusername.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lpusername.Location = new Point(13, 12);
            lpusername.Name = "lpusername";
            lpusername.Size = new Size(244, 35);
            lpusername.TabIndex = 0;
            lpusername.Text = "Tên Đăng Nhập:";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(NAME);
            panel1.Location = new Point(12, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(728, 69);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Location = new Point(136, 67);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 125);
            panel3.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(253, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(455, 34);
            textBox1.TabIndex = 1;
            // 
            // NAME
            // 
            NAME.AutoSize = true;
            NAME.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NAME.Location = new Point(13, 12);
            NAME.Name = "NAME";
            NAME.Size = new Size(195, 35);
            NAME.TabIndex = 0;
            NAME.Text = "Tên Hiển thị:";
            // 
            // btlogin
            // 
            btlogin.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btlogin.Location = new Point(370, 354);
            btlogin.Name = "btlogin";
            btlogin.Size = new Size(130, 67);
            btlogin.TabIndex = 4;
            btlogin.Text = "Cập nhật";
            btlogin.UseVisualStyleBackColor = true;
            // 
            // thoatAC
            // 
            thoatAC.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            thoatAC.Location = new Point(549, 354);
            thoatAC.Name = "thoatAC";
            thoatAC.Size = new Size(130, 67);
            thoatAC.TabIndex = 5;
            thoatAC.Text = "Thoát";
            thoatAC.UseVisualStyleBackColor = true;
            thoatAC.Click += thoatAC_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(username);
            panel5.Controls.Add(mkusername);
            panel5.Location = new Point(12, 168);
            panel5.Name = "panel5";
            panel5.Size = new Size(728, 69);
            panel5.TabIndex = 6;
            // 
            // username
            // 
            username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            username.Location = new Point(253, 12);
            username.Name = "username";
            username.Size = new Size(455, 34);
            username.TabIndex = 1;
            username.UseSystemPasswordChar = true;
            // 
            // mkusername
            // 
            mkusername.AutoSize = true;
            mkusername.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mkusername.Location = new Point(13, 12);
            mkusername.Name = "mkusername";
            mkusername.Size = new Size(160, 35);
            mkusername.TabIndex = 0;
            mkusername.Text = "Mật Khẩu:";
            // 
            // panel6
            // 
            panel6.Controls.Add(textBox3);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(12, 243);
            panel6.Name = "panel6";
            panel6.Size = new Size(728, 69);
            panel6.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(253, 12);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(455, 34);
            textBox3.TabIndex = 1;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 12);
            label2.Name = "label2";
            label2.Size = new Size(141, 35);
            label2.TabIndex = 0;
            label2.Text = "Nhập lại:";
            // 
            // taotaikhoannhanvien
            // 
            AcceptButton = btlogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = thoatAC;
            ClientSize = new Size(756, 452);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(thoatAC);
            Controls.Add(btlogin);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "taotaikhoannhanvien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo tài khoản nhân viên";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel4;
        private TextBox txusernam;
        private Label lpusername;
        private Panel panel1;
        private Panel panel3;
        private TextBox textBox1;
        private Label NAME;
        private Button btlogin;
        private Button thoatAC;
        private Panel panel5;
        private TextBox username;
        private Label mkusername;
        private Panel panel6;
        private TextBox textBox3;
        private Label label2;
    }
}