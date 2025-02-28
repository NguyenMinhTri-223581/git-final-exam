using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance 
        { get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
           private set {MenuDAO.instance = value; } 
        }
        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id) 
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "SELECT TD.tenmon, HCT.COUNT,TD.gia, TD.gia*HCT.COUNT AS totalPrice FROM dbo. CTHOADON AS HCT, dbo.HOADON AS HD, dbo.THUCDON AS TD \r\n\tWHERE HCT.IDHOADON = HD.ID AND HCT.IDTHUCDON = TD.ID AND HD.STATUS = 0 AND HD.IDBANG = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
        public DataTable GetListMenu()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.LOAIMON ");

        }
        public bool InsertMenu(string name )
        {
            string query = string.Format("INSERT dbo.LOAIMON (tenloai) VALUES (N'{0}' )", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateMenu( string name, int id )
        {
            string query = string.Format("UPDATE dbo.LOAIMON SET tenloai = N'{0}' WHERE ID= {1}  ", name , id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteMenu(int id)
        {

            FoodDAO.Instance.DeleteFoodByMenuID(id);

            string query = string.Format(" Delete LOAIMON WHERE ID = {0} ", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
