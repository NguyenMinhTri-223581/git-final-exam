using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTO
{
    public class Menu
    {
        public Menu(string foodName, int count, float price, float totalProce = 0)
        {
            this.foodName = foodName;
            this.count = count;
            this.Price = price;
            this.totaPrice = totalProce;
        }
        public Menu(DataRow row)
        {
            this.foodName = row["tenmon"].ToString();
            this.count = (int)row["count"];
            this.Price = (float) Convert.ToDouble( row["gia"].ToString());
            this.totaPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        private float totaPrice;
        public float TotaPrice
        {
            get { return totaPrice; }
            set { totaPrice = value; }
        }
        private float Price;
        public float Price2
        {
            get { return Price; }
            set { Price = value; }
        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }



        private string foodName;

        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }
    }
}
