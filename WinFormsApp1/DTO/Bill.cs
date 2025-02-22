using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckout, int status, int discount = 0) 
        { 
            this.iD = id;
            this.DateCheckIn = dateCheckin;
            this.dateCheckOut = dateCheckout;
            this.Status = status;
            this.Discount = discount;
        }

       

        public Bill(DataRow row)
        {
            this.iD = (int)row["id"];
            var dateCheckInTemp = row["ngayvao"];
            if (dateCheckInTemp.ToString() != "")
                this.DateCheckIn = (DateTime?)dateCheckInTemp;
            var dateCheckOutTemp = row["ngayra"];
            if (dateCheckOutTemp.ToString() != "") 
                this.dateCheckOut = (DateTime?)dateCheckOutTemp;

 
            this.Status = (int)row["status"];
            if (row["GIAMGIA"].ToString() != "") 
                this.Discount = (int)row["GIAMGIA"];

        }
        private int discount;
        public int Discount 
        { get => discount; set => discount = value; }

        private int status;
        public int Status
        {
            get => status;
            set => status = value;
        }

        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut
        {
            get => dateCheckOut;
            set => dateCheckOut = value;
        }




        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn
        {
            get => dateCheckIn;
            set => dateCheckIn = value;
        }



        private int iD;

        public int ID
        {
            get => iD;
            set => iD = value;
        }
       
    }
}
