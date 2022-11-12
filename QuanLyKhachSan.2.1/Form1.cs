using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachSan._2._1
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();

        }
        //void load_grid()
        //{

        //    DataService db = new DataService();
        //    String sql = "SELECT PHONG.MaPhong, LOAI_TINH_TRANG.TenLoaiTinhTrang, LOAI_PHONG.TenLoaiPhong, LOAI_PHONG.DonGia, LOAI_PHONG.SoNguoiChuan FROM PHONG INNER JOIN LOAI_PHONG ON PHONG.MaLoaiPhong = LOAI_PHONG.MaLoaiPhong INNER JOIN LOAI_TINH_TRANG ON PHONG.MaLoaiTinhTrangPhong = LOAI_TINH_TRANG.MaLoaiTinhTrangPhong ";
        //    DataTable dt = db.getDataTable(sql);
        //    gridControl1.DataSource = dt;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            OnOff(this);
            //load_grid();

        }

        private void barHeaderItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHang a = new KhachHang();
            a.ShowDialog();
        }

        private void barHeaderItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DangKi a = new DangKi();
            a.ShowDialog();
        }

        private void barHeaderItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhanPhong a = new NhanPhong();
            a.ShowDialog();
        }

        private void barHeaderItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TraPhong a = new TraPhong();
            a.ShowDialog();
        }

        private void barHeaderItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DichVu a = new DichVu();
            a.ShowDialog();
        }

        private void barHeaderItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Phong a = new Phong();
            a.ShowDialog();

        }

        private void barHeaderItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHang a = new KhachHang();
            a.ShowDialog();
        }

        private void barHeaderItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThietBi a = new ThietBi();
            a.ShowDialog();
        }

        private void barHeaderItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoaiPhong a = new LoaiPhong();
            a.ShowDialog();
        }

        private void barHeaderItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DichVu a = new DichVu();
            a.ShowDialog();
        }

   

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThongKe a = new ThongKe();
            a.ShowDialog();
        }
        String msg;
        public Form1(string loianguoidung) : this()
        {
            msg = loianguoidung;
        }
        public void OnOff(Form frm)
        {
            Form1 f = (Form1)frm;
            if(msg=="2")
            {
                f.ribbonPageGroup7.Enabled = false;
                f.barHeaderItem10.Enabled = false;
                f.barHeaderItem16.Enabled = false;
                f.barHeaderItem17.Enabled = false;
                f.barHeaderItem18.Enabled = false;
                f.barButtonItem2.Enabled = false;

            }

        }

        private void barHeaderItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HoaDon1 a = new HoaDon1();
            a.ShowDialog();
        }

        private void barHeaderItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhsachHD a = new DanhsachHD();
            a.ShowDialog();
        }

        private void barHeaderItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Close();
           
            DangNhap a = new DangNhap();
            a.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhanQuyen a = new PhanQuyen();
            a.ShowDialog();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
