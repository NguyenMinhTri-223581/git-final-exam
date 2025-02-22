using System.Web;
using WinFormsApp1.DAO;

namespace WinFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = txusernam.Text;
            string Password = txpassword.Text;

            if (login( UserName, Password))
            {
                giaodien giaodien = new giaodien();
                this.Hide();
                giaodien.ShowDialog();
                this.Show();
            }
            else 
            {
                MessageBox.Show(" Sai tên đăng nhập hoặc mật khẩu! ");
            } 
                
        }
        bool login(string UserName , string Password)
        {

            return AccountDAO.Instance.Login(UserName , Password );
        }
    
           
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình? ", " Thông báo ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        
    }
}
