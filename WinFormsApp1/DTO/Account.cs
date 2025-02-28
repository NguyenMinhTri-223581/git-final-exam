using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTO
{
    public class Account

    {
        public Account(string userName, string displayName, int type, string password = null ) 
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            
            
            this.Type = type;
            this.Password = password;
        }

        public Account(DataRow row)
        {
            this.DisplayName = row["TEN"].ToString();
            this.UserName = row["TENTAIKHOAN"].ToString();
            
            this.Type = (int)row["TYPE"];
            this.Password = row["PASSWORD"].ToString();

        }

        private int type;
        public int Type 
        { get => type; 
          set => type = value; }


        private string password;
        public string Password 
        { get => password; 
          set => password = value; }

        private string displayName;
        public string DisplayName 
        { get => displayName; 
          set => displayName = value; }

        private string userName;

        public string UserName 
        { get => userName; 
          set => userName = value; }
       
    }
}
