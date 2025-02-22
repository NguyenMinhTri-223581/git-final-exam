using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTO
{
    public class Food
    {
        public Food(int id, string name, int categoryID , float price) 
        {
            this.iD = id;
            this.name = name;
            this.categoryID = categoryID;
            this.price = price;   
        }
        public Food(DataRow row)
        {
            this.iD = (int)row["ID"];
            this.name = row["tenmon"].ToString();
            this.categoryID = (int)row["idloai"];
            this.price = (float)Convert.ToDouble(row["gia"].ToString());
        }

        private float price;
        public float Price 
        { get => price; 
            set => price = value; }

        private int categoryID;
        public int CategoryID 
        { get => categoryID; 
            set => categoryID = value; }


        private string name;
        public string Name 
        { get => name; 
            set => name = value; }

        private int iD;

        public int ID 
        { get => iD; 
            set => iD = value; }
       
    }
}
