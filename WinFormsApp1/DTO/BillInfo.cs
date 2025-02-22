using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID, int count) 
        {
            this.iD = id;
            this.billid = billID;
            this.Foodid = foodID;
            this.count = count;

        }

        public BillInfo(DataRow row ) 
        {
            this.iD = (int)row["id"];
            var billtemp = row["idhoadon"];
            if (billtemp.ToString() != "null") ;
            this.billid = (int)billtemp;
            this.Foodid = (int)row["idthucdon"];
            var counttemp = row["count"];
            if (counttemp.ToString() != "null") ;
            this.count = (int)counttemp;
        }



        private int count;
        public int Count
        {
            get => count;
            set => count = value;
        }



        private int Foodid;
        public int Foodid1
        {
            get { return Foodid; }
            set { Foodid = value; }
        }
        private int billid;
        public int Billid
        {
            get => billid;
            set => billid = value;
        }


        private int iD;

        public int ID
        {
            get => iD;
            set => iD = value;
        }


    }
}
