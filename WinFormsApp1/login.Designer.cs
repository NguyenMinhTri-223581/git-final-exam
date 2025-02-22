namespace WinFormsApp1
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btexit = new Button();
            btlogin = new Button();
            mkac = new Panel();
            txpassword = new TextBox();
            mkusername = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            txusernam = new TextBox();
            lpusername = new Label();
            panel1.SuspendLayout();
            mkac.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btexit);
            panel1.Controls.Add(btlogin);
            panel1.Controls.Add(mkac);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 269);
            panel1.TabIndex = 0;
            // 
            // btexit
            // 
            btexit.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btexit.Location = new Point(651, 188);
            btexit.Name = "btexit";
            btexit.Size = new Size(116, 64);
            btexit.TabIndex = 4;
            btexit.Text = "Thoát";
            btexit.UseVisualStyleBackColor = true;
            btexit.Click += button2_Click;
            // 
            // btlogin
            // 
            btlogin.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btlogin.Location = new Point(486, 188);
            btlogin.Name = "btlogin";
            btlogin.Size = new Size(130, 64);
            btlogin.TabIndex = 3;
            btlogin.Text = "Đăng Nhập";
            btlogin.UseVisualStyleBackColor = true;
            btlogin.Click += button1_Click;
            // 
            // mkac
            // 
            mkac.Controls.Add(txpassword);
            mkac.Controls.Add(mkusername);
            mkac.Location = new Point(0, 113);
            mkac.Name = "mkac";
            mkac.Size = new Size(770, 69);
            mkac.TabIndex = 2;
            // 
            // txpassword
            // 
            txpassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txpassword.Location = new Point(253, 12);
            txpassword.Name = "txpassword";
            txpassword.Size = new Size(514, 34);
            txpassword.TabIndex = 1;
            txpassword.UseSystemPasswordChar = true;
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
            mkusername.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(txusernam);
            panel2.Controls.Add(lpusername);
            panel2.Location = new Point(3, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(770, 69);
            panel2.TabIndex = 0;
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
            txusernam.Size = new Size(514, 34);
            txusernam.TabIndex = 1;
            txusernam.TextChanged += textBox1_TextChanged;
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
            // Login
            // 
            AcceptButton = btlogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btexit;
            ClientSize = new Size(800, 292);
            Controls.Add(panel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            FormClosing += Login_FormClosing;
            panel1.ResumeLayout(false);
            mkac.ResumeLayout(false);
            mkac.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox txusernam;
        private Label lpusername;
        private Panel mkac;
        private TextBox txpassword;
        private Label mkusername;
        private Button btexit;
        private Button btlogin;
        private Panel panel4;
    }
}
