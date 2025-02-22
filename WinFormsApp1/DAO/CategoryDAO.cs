using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance 
        { get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set { CategoryDAO.instance = value; } 
        }

        private CategoryDAO() {}
        public List<Category> GetlistCategory()
        { 
            List<Category> list = new List<Category>();

            string query = "SELECT * FROM dbo.LOAIMON";
            Console.WriteLine("Query: " + query);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
             
            return list;
        }
    }
}
