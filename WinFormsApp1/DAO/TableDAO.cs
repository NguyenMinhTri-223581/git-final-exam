using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set {TableDAO.instance = value; }          

        }

        public static int Tablewidth = 150;
        public static int Tableheight = 150;

        private TableDAO() { }

        public void SwitchTable(int id, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTabel  @idTable , @idTable2  ", new object[] { id , id2 });
        }

        public List<Table> loadTableList()
        {
            List<Table> tablelist = new List<Table>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("USP_Table ");

            foreach (DataRow item in dt.Rows)
            { 
                Table table = new Table(item);
                tablelist.Add(table);
            }

            return tablelist;

        }
        public DataTable GetListTable()
        {
            return DataProvider.Instance.ExecuteQuery("\r\nSELECT * FROM dbo.BAN ");

        }
        public bool InsertTable(string name, string status)
        {
            string query = string.Format("INSERT dbo.BAN (TEN , STATUS) VALUES (N'{0}', N'{1}' )", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTable(string name, string status , int id)
        {
            string query = string.Format("UPDATE dbo.BAN SET TEN = N'{0}' , STATUS =N'{1}' WHERE ID= {2} ", name,  status, id );
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int id)
        {
            BillDAO.Instance.DeleteBillByTableID(id);

            string query = string.Format(" Delete BAN WHERE ID = {0} ", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
