using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.DAO;
using WinFormsApp1.DTO;

namespace WinFormsApp1;

    public partial class taotaikhoannhanvien : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                if (loginAccount != null) // Kiểm tra null trước khi gọi ChangeAccount
                {
                    ChangeAccount(loginAccount);
                }
            }
        }
        public taotaikhoannhanvien(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            if (loginAccount != null)
            {
                txusernam.Text = LoginAccount.UserName;
                txtenhienthi.Text = LoginAccount.DisplayName;
            }
            else
            {
                MessageBox.Show("LoginAccount is null. Please check the initialization.");
            }


        }
        void UpdateAccountInfo()
        {
            string displayName = txtenhienthi.Text;
            string password = txmatkhau.Text;
            string newpass = txmatkhaumoi.Text;
            string reenterPass = txnhaplai.Text;
            string userName = txusernam.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mất khẩu đúng với mật khẩu mới !");
            }
            else
            {
                if (AccountDAO.Instance.UpdateByAcount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");

                    if (updateAcount!=null)
                        updateAcount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }

                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu");
                }

            }
        }
        private event EventHandler<AccountEvent> updateAcount;
        public event EventHandler<AccountEvent> UpdateAcount
        {
            add { updateAcount += value; }
            remove { updateAcount -= value; }
        }


        private void thoatAC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        public class AccountEvent:EventArgs
        {
            private Account acc;

            public Account Acc
            {
                get => acc;
                set => acc = value;
            }

            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }
    }
