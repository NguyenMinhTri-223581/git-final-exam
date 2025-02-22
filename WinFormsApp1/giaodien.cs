using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.DAO;
using WinFormsApp1.DTO;

namespace WinFormsApp1
{
    public partial class giaodien : Form
    {
        public giaodien()
        {
            InitializeComponent();
            loadTable();
            LoadCategory();
            LoadComboboxTable(soban);
        }
        #region Method

        void LoadCategory()
        {
            List<Category> listcategory = CategoryDAO.Instance.GetlistCategory();
            tenmon.DataSource = listcategory;
            tenmon.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategory(id);
            tenmon1.DataSource = listFood;
            tenmon1.DisplayMember = "Name";


        }

        void loadTable()
        {
            ban.Controls.Clear();
            List<Table> tables = TableDAO.Instance.loadTableList();
            foreach (Table item in tables)
            {
                Button btn = new Button() { Width = TableDAO.Tablewidth, Height = TableDAO.Tableheight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.YellowGreen;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;

                }
                ban.Controls.Add(btn);

            }
        }

        void showbill(int id)
        {

            listViewhoadon.Items.Clear();
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            float totalPrice = 0;
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvitem = new ListViewItem(item.FoodName.ToString());
                lsvitem.SubItems.Add(item.Count.ToString());
                lsvitem.SubItems.Add(item.Price2.ToString());
                lsvitem.SubItems.Add(item.TotaPrice.ToString());
                totalPrice += item.TotaPrice;
                listViewhoadon.Items.Add(lsvitem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            tongtien.Text = totalPrice.ToString("c", culture);

        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.loadTableList();
            cb.DisplayMember = "Name";
        }

        #region Events

        void btn_Click(object? sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            listViewhoadon.Tag = (sender as Button).Tag;
            showbill(tableID);
        }
        private void giaodien_Load(object sender, EventArgs e)
        {

        }

        private void tạoTàiKhoảnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tạoTàiKhoảnNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            taotaikhoannhanvien t = new taotaikhoannhanvien();
            t.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tAdmin tAdmin = new tAdmin();
            tAdmin.ShowDialog();
        }
        #endregion

        private void listViewhoadon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tenmon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category Selected = cb.SelectedItem as Category;

            id = Selected.ID;


            LoadFoodListByCategoryID(id);
        }

        private void thêmmon_Click(object sender, EventArgs e)
        {
            Table table = listViewhoadon.Tag as Table;


            int idBill = BillDAO.Instance.GetUncheckBillTableID(table.ID);
            int idfood = (tenmon1.SelectedItem as Food).ID;
            int count = (int)numericUpDown1.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idfood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idfood, count);

            }
            showbill(table.ID);
            loadTable();

        }

        private void thanhtoan_Click(object sender, EventArgs e)
        {
            Table table = listViewhoadon.Tag as Table;

            int idbill = BillDAO.Instance.GetUncheckBillTableID(table.ID);
            int discount = (int)dícos.Value;

            string cleanedText = tongtien.Text.Replace(".", "").Replace("đ", "").Trim();


            double totalPrice;
            if (double.TryParse(cleanedText, NumberStyles.Any, CultureInfo.InvariantCulture, out totalPrice))           

            if (string.IsNullOrWhiteSpace(tongtien.Text))
            {
                Console.WriteLine("Lỗi: Giá trị tổng tiền rỗng!");
                return;
            }




            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            Console.WriteLine($"Final Total Price: {finalTotalPrice}");

            if (idbill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hoá đơn cho {0}\nTổng tiền - (Tổng tiền / 100) x Giảm Giá\n=> {1} - ({1} / 100) x {2} = {3} ", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idbill, discount);
                    showbill(table.ID);

                    loadTable();
                }

            }
        }
       

        private void chuyenban_Click(object sender, EventArgs e)
        {
            


            int id = (listViewhoadon.Tag as Table).ID;
            int id2 = (soban.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn có thạt sự muốn chuyển bàn {0} qua bàn {1} ", (listViewhoadon.Tag as Table).Name, (soban.SelectedItem as Table).Name), " Thông báo ", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id, id2);

                loadTable();
            }
        }
     #endregion
    }
}