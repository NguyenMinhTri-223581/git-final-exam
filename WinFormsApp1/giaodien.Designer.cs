namespace WinFormsApp1
{
    partial class giaodien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(giaodien));
            menuStrip1 = new MenuStrip();
            adminToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            tạoTàiKhoảnNhânViênToolStripMenuItem = new ToolStripMenuItem();
            panel2 = new Panel();
            listViewhoadon = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            panel3 = new Panel();
            chuyenban = new Button();
            tongtien = new TextBox();
            soban = new ComboBox();
            dícos = new NumericUpDown();
            giamgia = new Button();
            thanhtoan = new Button();
            panel4 = new Panel();
            numericUpDown1 = new NumericUpDown();
            thêmmon = new Button();
            tenmon1 = new ComboBox();
            tenmon = new ComboBox();
            ban = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dícos).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thôngTinTàiKhoảnToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngXuấtToolStripMenuItem });
            resources.ApplyResources(adminToolStripMenuItem, "adminToolStripMenuItem");
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            resources.ApplyResources(đăngXuấtToolStripMenuItem, "đăngXuấtToolStripMenuItem");
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tạoTàiKhoảnNhânViênToolStripMenuItem });
            resources.ApplyResources(thôngTinTàiKhoảnToolStripMenuItem, "thôngTinTàiKhoảnToolStripMenuItem");
            thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            // 
            // tạoTàiKhoảnNhânViênToolStripMenuItem
            // 
            tạoTàiKhoảnNhânViênToolStripMenuItem.Name = "tạoTàiKhoảnNhânViênToolStripMenuItem";
            resources.ApplyResources(tạoTàiKhoảnNhânViênToolStripMenuItem, "tạoTàiKhoảnNhânViênToolStripMenuItem");
            tạoTàiKhoảnNhânViênToolStripMenuItem.Click += tạoTàiKhoảnNhânViênToolStripMenuItem_Click_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(listViewhoadon);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            panel2.Paint += panel2_Paint;
            // 
            // listViewhoadon
            // 
            listViewhoadon.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            resources.ApplyResources(listViewhoadon, "listViewhoadon");
            listViewhoadon.GridLines = true;
            listViewhoadon.Name = "listViewhoadon";
            listViewhoadon.UseCompatibleStateImageBehavior = false;
            listViewhoadon.View = View.Details;
            listViewhoadon.SelectedIndexChanged += listViewhoadon_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(columnHeader4, "columnHeader4");
            // 
            // panel3
            // 
            panel3.Controls.Add(chuyenban);
            panel3.Controls.Add(tongtien);
            panel3.Controls.Add(soban);
            panel3.Controls.Add(dícos);
            panel3.Controls.Add(giamgia);
            panel3.Controls.Add(thanhtoan);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // chuyenban
            // 
            resources.ApplyResources(chuyenban, "chuyenban");
            chuyenban.Name = "chuyenban";
            chuyenban.UseVisualStyleBackColor = true;
            chuyenban.Click += chuyenban_Click;
            // 
            // tongtien
            // 
            resources.ApplyResources(tongtien, "tongtien");
            tongtien.Name = "tongtien";
            tongtien.ReadOnly = true;
            // 
            // soban
            // 
            soban.FormattingEnabled = true;
            resources.ApplyResources(soban, "soban");
            soban.Name = "soban";
            // 
            // dícos
            // 
            resources.ApplyResources(dícos, "dícos");
            dícos.Name = "dícos";
            // 
            // giamgia
            // 
            resources.ApplyResources(giamgia, "giamgia");
            giamgia.Name = "giamgia";
            giamgia.UseVisualStyleBackColor = true;
            // 
            // thanhtoan
            // 
            resources.ApplyResources(thanhtoan, "thanhtoan");
            thanhtoan.Name = "thanhtoan";
            thanhtoan.UseVisualStyleBackColor = true;
            thanhtoan.Click += thanhtoan_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(numericUpDown1);
            panel4.Controls.Add(thêmmon);
            panel4.Controls.Add(tenmon1);
            panel4.Controls.Add(tenmon);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(numericUpDown1, "numericUpDown1");
            numericUpDown1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // thêmmon
            // 
            resources.ApplyResources(thêmmon, "thêmmon");
            thêmmon.Name = "thêmmon";
            thêmmon.UseVisualStyleBackColor = true;
            thêmmon.Click += thêmmon_Click;
            // 
            // tenmon1
            // 
            tenmon1.FormattingEnabled = true;
            resources.ApplyResources(tenmon1, "tenmon1");
            tenmon1.Name = "tenmon1";
            // 
            // tenmon
            // 
            tenmon.FormattingEnabled = true;
            resources.ApplyResources(tenmon, "tenmon");
            tenmon.Name = "tenmon";
            tenmon.SelectedIndexChanged += tenmon_SelectedIndexChanged;
            // 
            // ban
            // 
            resources.ApplyResources(ban, "ban");
            ban.Name = "ban";
            // 
            // giaodien
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ban);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "giaodien";
            Load += giaodien_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dícos).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private Panel panel2;
        private Panel panel3;
        private ListView listViewhoadon;
        private Panel panel4;
        private Button thêmmon;
        private ComboBox tenmon1;
        private ComboBox tenmon;
        private NumericUpDown numericUpDown1;
        private FlowLayoutPanel ban;
        private NumericUpDown dícos;
        private Button giamgia;
        private Button thanhtoan;
        private Button chuyenban;
        private ComboBox soban;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem tạoTàiKhoảnNhânViênToolStripMenuItem;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TextBox tongtien;
    }
}