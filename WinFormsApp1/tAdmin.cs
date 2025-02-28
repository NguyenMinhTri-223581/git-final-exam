using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.DAO;
using WinFormsApp1.DTO;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{

    public partial class tAdmin : Form
    {
        BindingSource foodlist = new BindingSource();

        BindingSource accountList = new BindingSource();

        BindingSource tableList = new BindingSource();

        BindingSource menuList = new BindingSource();

        public Account loginAccount;
        public tAdmin()
        {
            InitializeComponent();

            Load();
        }
        #region methods
        void Load()

        {
            bangmonan.DataSource = foodlist;

            danhsachtaikhoan.DataSource = accountList;

            danhsachban.DataSource = tableList;

            bangdanhmuc.DataSource = menuList;


            LoadListBillByDate(thoigianvaobill.Value, thoigianrabill.Value);

            LoadDateTimePickeBill();

            LoadListMenu();

            LoadListTable();

            LoadListFood();



            LoadAccount();

            LoadCategoryIntoCombobox(loiamuc);

            LoadTableIntoCombobox(cbtrangthai);

            AddFoodBinding();

            AddAccountBinding();

            AddTableBinding();

            AddMenuBinding();


        }

        void LoadTableIntoCombobox(System.Windows.Forms.ComboBox cb)

        {
            cb.DataSource = TableDAO.Instance.GetListTable();
            cb.DisplayMember = "STATUS";
        }

        void AddMenuBinding()
        {
            txiddanhmuc.DataBindings.Add(new Binding("Text", bangdanhmuc.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtendanhmuc.DataBindings.Add(new Binding("Text", bangdanhmuc.DataSource, "tenloai", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {

            soban.DataBindings.Add(new Binding("Text", danhsachban.DataSource, "ID", true, DataSourceUpdateMode.Never));
            sotenban.DataBindings.Add(new Binding("Text", danhsachban.DataSource, "TEN", true, DataSourceUpdateMode.Never));

        }

        void AddAccountBinding()
        {
            tendangnhap.DataBindings.Add(new Binding("Text", danhsachtaikhoan.DataSource, "TEN", true, DataSourceUpdateMode.Never));
            tenhienthi.DataBindings.Add(new Binding("Text", danhsachtaikhoan.DataSource, "TENTAIKHOAN", true, DataSourceUpdateMode.Never));
            nudlaoitaikhoan.DataBindings.Add(new Binding("Value", danhsachtaikhoan.DataSource, "TYPE", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadDateTimePickeBill()
        {
            DateTime today = DateTime.Now;
            thoigianvaobill.Value = new DateTime(today.Year, today.Month, 1);
            thoigianrabill.Value = thoigianvaobill.Value.AddMonths(1).AddDays(-1);
        }
        void AddFoodBinding()
        {
            tenmon.DataBindings.Add(new Binding("Text", bangmonan.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txusernam.DataBindings.Add(new Binding("Text", bangmonan.DataSource, "ID", true, DataSourceUpdateMode.Never));

            sotienthucan.DataBindings.Add(new Binding("Value", bangmonan.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(System.Windows.Forms.ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetlistCategory();
            cb.DisplayMember = "Name";


        }
        void LoadListFood()
        {
            foodlist.DataSource = FoodDAO.Instance.GetListFood();
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            tongbill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);

        }

        void LoadListTable()
        {
            danhsachban.DataSource = TableDAO.Instance.GetListTable();

        }

        void LoadListMenu()
        {
            menuList.DataSource = MenuDAO.Instance.GetListMenu();
        }
        // ---------------------------------------
        void AddAccount(string userName, string displayname, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayname, type))
            {
                MessageBox.Show("Thêm tài khoản thanh công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();


        }

        void EditAccount(string userName, string displayname, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayname, type))
            {
                MessageBox.Show("Sửa tài khoản thanh công");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại");
            }

            LoadAccount();

        }
        void DelectAccount(string userName)
        {

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xoá tài khoản thanh công");
            }
            else
            {
                MessageBox.Show("Xoá tài khoản thất bại");
            }

            LoadAccount();

        }

        void ResetPassword(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Dật lại mật khẩu thát bại");
            }
        }
        //-----------------------
        void InserMenu(string userName)
        {
            if (MenuDAO.Instance.InsertMenu(userName))
            {
                MessageBox.Show("Thêm Menu thanh công");
            }
            else
            {
                MessageBox.Show("Thêm Menu thất bại");
            }
            LoadListMenu();
        }

        void UpdateMenu(string userName, int id)
        {

            if (MenuDAO.Instance.UpdateMenu(userName, id))
            {
                MessageBox.Show("Sửa Menu thanh công");
            }
            else
            {
                MessageBox.Show("Sửa Menu thất bại");
            }
            LoadListMenu();

        }
        void DeleteMenu(int id)
        {
            if (MenuDAO.Instance.DeleteMenu(id))
            {
                MessageBox.Show("Xoá danh mục thành công");

            }
            else
            {
                MessageBox.Show("Xoá danh mục thất bại");
            }
            LoadListMenu();
        }
        //-------------------------------

        void InserTable (string userName, string status)
        {
            if (TableDAO.Instance.InsertTable(userName, status))
            {
                MessageBox.Show("Thêm bàn ăn thanh công");
                
            }
            else
            {
                MessageBox.Show("Thêm bàn ăn thất bại");
            }
            LoadListTable();

        }

        void UpdateTable(string userName, string status, int id)
        {
            if (TableDAO.Instance.UpdateTable(userName, status, id))
            {
                MessageBox.Show("Sửa bàn ăn thanh công");

               
            }
            else
            {
                MessageBox.Show("Sửa bàn ăn thất bại");
            }
            LoadListTable();
        }

        void DeleteTable(int id)
        {
            if (TableDAO.Instance.DeleteTable( id))
            {
                MessageBox.Show("Xoá bàn ăn thanh công");
                
            }
            else
            {
                MessageBox.Show("Xoá bàn ăn thất bại");
            }
            LoadListTable();
        }


        #endregion

        #region events




        private void thongke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(thoigianvaobill.Value, thoigianrabill.Value);
        }

        private void tongbill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadListBillByDate(thoigianvaobill.Value, thoigianrabill.Value);
        }


        private void txusernam_TextChanged(object sender, EventArgs e)
        {
            if (bangmonan.SelectedCells.Count > 0)
            {
                int id = (int)bangmonan.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                loiamuc.SelectedItem = category;
                int index = -1;
                int i = 0;
                foreach (Category item in loiamuc.Items)
                {
                    if (item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                loiamuc.SelectedIndex = index;





            }
        }

        //--thuc an--
        private void xemthucan_Click(object sender, EventArgs e)
        {
            LoadListFood();

        }

        private void themthucan_Click(object sender, EventArgs e)
        {

            string name = tenmon.Text;
            int categoryID = (loiamuc.SelectedItem as Category).ID;
            float price = (float)sotienthucan.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành cồng");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");

            }

        }

        private void suathucan_Click(object sender, EventArgs e)
        {
            string name = tenmon.Text;
            int categoryID = (loiamuc.SelectedItem as Category).ID;
            float price = (float)sotienthucan.Value;
            int id = Convert.ToInt32(txusernam.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành cồng");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");

            }

        }


        private void xoathucan_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txusernam.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xoá món thành cồng");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xoá thức ăn");

            }

        }

        //--thuc an--
        //--ban an--
        private void xemban_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }
        private void themban_Click(object sender, EventArgs e)
        {
            string usreName = sotenban.Text;
            string status = cbtrangthai.Text;

            InserTable(usreName,status);

        }

        private void xoaban_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(soban.Text);

            DeleteTable(id);

        }

        private void suaban_Click(object sender, EventArgs e)
        {
            string usreName = sotenban.Text;
            string status = cbtrangthai.Text;
            int id = Convert.ToInt32(soban.Text);

            UpdateTable(usreName, status, id);

        }

        //-- ban an

        // --danhmuc--
        private void xemdanhmuc_Click(object sender, EventArgs e)
        {
            LoadListMenu();
        }
        private void themdanhmuc_Click(object sender, EventArgs e)
        {
            string usreName = txtendanhmuc.Text;


            InserMenu(usreName);

        }

        private void xaodanhmuc_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txiddanhmuc.Text);

            DeleteMenu(id);

        }

        private void suadanhmuc_Click(object sender, EventArgs e)
        {
            string usreName = txtendanhmuc.Text;
            int id = Convert.ToInt32(txiddanhmuc.Text);

            UpdateMenu(usreName, id);

        }
        //--danhmuc--
        // xem tai khoan

        private void xemtaikhoan_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void xoataikhoan_Click(object sender, EventArgs e)
        {
            string usreName = tendangnhap.Text;


            DelectAccount(usreName);
        }

        private void suâtikhoan_Click(object sender, EventArgs e)
        {

            string usreName = tendangnhap.Text;
            string displayName = tenhienthi.Text;
            int type = (int)nudlaoitaikhoan.Value;

            EditAccount(usreName, displayName, type);

        }

        private void themtaikhoan_Click(object sender, EventArgs e)
        {
            string usreName = tendangnhap.Text;
            string displayName = tenhienthi.Text;
            int type = (int)nudlaoitaikhoan.Value;

            AddAccount(usreName, displayName, type);
        }

        private void datlaimatkhautaikhoan_Click(object sender, EventArgs e)
        {
            string usreName = tendangnhap.Text;


            ResetPassword(usreName);

        }

       


        // --tai khoan--

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }


        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }


        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }


        }

        


        #endregion

    }
}
