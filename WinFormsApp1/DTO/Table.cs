using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTO
{
   public class Table
    {
        public Table(int id, string Name, string status)
        {
            this.ID = id;
            this.Name = name; 
            this.Status = status;
        }

        public Table(DataRow row)
        {
            this.iD = (int)row["ID"];
            this.Name = row["TEN"].ToString();
            this.status = row["status"].ToString();
        }

        private string status;
        public string Status 
        { 
          get => status; 
          set => status = value; 
        }

        private string name;
        public string Name 
        { 
          get => name; 
          set => name = value; 
        }

        private int iD;

        public int ID 
        { 
          get => iD; 
          set => iD = value; 
        }
        
    }
}
