using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance 
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set {FoodDAO.instance = value; } }
        private FoodDAO() { }

        public List<Food> GetFoodByCategory(int id)
        {
            List<Food> list = new List<Food>();

            string query = "SELECT * FROM dbo. THUCDON WHERE idloai =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food =new Food(item);
                list.Add(food);
            } 

            return list;
        }

        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();

            string query = "SELECT * FROM dbo. THUCDON ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public void DeleteFoodByMenuID (int id) 
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.THUCDON WHERE idloai = " + id);

        }

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT dbo.THUCDON (tenmon, idloai, gia) VALUES (N'{0}', {1} , {2} )", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFood(int idfood ,string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.THUCDON SET tenmon = N'{0}' , idloai = {1} , gia = {2} WHERE ID= {3} ", name, id, price, idfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int idfood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idfood);

            string query = string.Format(" Delete THUCDON WHERE ID = {0} ",idfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
