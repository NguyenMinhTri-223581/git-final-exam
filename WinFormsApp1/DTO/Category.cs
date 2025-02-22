using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTO
{
    public class Category
    {
        public Category(int id, string name) 
        {
            this.iD = id;
            this.name = name;
        } 
        public Category(DataRow row) 
        {
            this.iD = (int)row["ID"];
            this.name = row["tenloai"].ToString();
        }



        private int iD;

        public int ID 
        { 
            get => iD; 
            set => iD = value; }
        
        private string name;
        public string Name 
        { get => name; 
            set => name = value; }

    }
}
