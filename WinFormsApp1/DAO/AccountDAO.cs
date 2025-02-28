using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
            { get { if (instance == null) instance = new AccountDAO(); return instance; } 
            private set { instance = value; }
        }
        private AccountDAO() { }
         public bool Login(string username,string password)
        {
            string query = "USP_Login @UserName , @Password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username, password});
            return result.Rows.Count > 0;
                
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT TEN , TENTAIKHOAN , TYPE FROM dbo.TAIKHOAN");

        }
        public bool UpdateByAcount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @userName , @displayName , @password , @newPassword ",new object[] { userName, displayName, pass, newPass });
            
            return result > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TAIKHOAN WHERE TENTAIKHOAN = '" + userName + "'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);

            }
            return null;
        }

        public bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.TAIKHOAN (TEN , TENTAIKHOAN , TYPE ) VALUES ( N'{0}', N'{1}' , {2} ) " , name , displayName , type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo. TAIKHOAN SET TENTAIKHOAN = N'{1}' , TYPE = {2} WHERE TEN= N'{0}' ", name , displayName , type );
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            

            string query = string.Format(" Delete TAIKHOAN WHERE TEN = N'{0}' ", name );
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name)
        {

            string query = string.Format(" UPDATE TAIKHOAN SET PASSWORD = N'0' WHERE TEN = N'{0}' ", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
