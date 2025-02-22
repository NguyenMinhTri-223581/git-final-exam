using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        { 
          get { if (instance == null) instance = new BillDAO(); return instance; }
           
        }

        private BillDAO()
        { 

        }
        // thanh toán rồi là 1: chưa thanh toán là 0
        public int GetUncheckBillTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(" SELECT * FROM dbo. HOADON WHERE IDBANG = " + id + " AND STATUS = 0 ");

            if (data.Rows.Count >0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;

            }
            return -1;
        }
        public void CheckOut(int id, int Discount)
        {
            string query = "UPDATE dbo.HOADON set STATUS = 1 , " + " GIAMGIA  = " + Discount+ " WHERE ID =  "+id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] {id});
        }
        public int GetMaxIDBill()
        {
            try 
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(ID) FROM dbo. HOADON");
            }
            
            catch
            {
                return 1;
            }

        }
    }
}
