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

namespace WinFormsApp1
{

    public partial class tAdmin : Form
    {
        public tAdmin()
        {
            InitializeComponent();

            Load();
        }
        #region methods
        void Load()
        {
            LoadListFood();
        }
        void LoadListFood()
        {
            bangmonan.DataSource = FoodDAO.Instance.GetListFood();
        }



        #endregion

        #region events

        private void xemthucan_Click(object sender, EventArgs e)
        {
            LoadListFood();

        }


        #endregion










    }
}
