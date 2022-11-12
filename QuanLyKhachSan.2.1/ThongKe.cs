using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Sql;
using System.Data.SqlClient;
namespace QuanLyKhachSan._2._1
{
    public partial class ThongKe : DevExpress.XtraEditors.XtraForm
    {
        public ThongKe()
        {
            InitializeComponent();
            load_data();
            
        }

        public void load_data()
        {
           
            DataService db = new DataService();
            DataService db1 = new DataService();
            DataService db2 = new DataService();
            DataService db3 = new DataService();
            DataService db4 = new DataService();
            String sql = "select( ((select count(MaPhong) from [PHONG] where MaLoaiPhong='LI')* (select DonGia from LOAI_PHONG where MaLoaiPhong='LI'))+ ((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'LII')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'LII'))+((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'DB')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'DB')))";
            String sql1 = " select Sum(TongTien) from HOA_DON , CHI_TIET_PHIEU_NHAN_PHONG, PHIEU_NHAN_PHONG, PHONG where HOA_DON.MaNhanPhong = PHIEU_NHAN_PHONG.MaNhanPhong and PHIEU_NHAN_PHONG.MaNhanPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaNhanPhong and PHONG.MaPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaPhong";
            String sql2 = " select(((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'LI') * (select DonGia from LOAI_PHONG where MaLoaiPhong = 'LI'))+((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'LII')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'LII'))+((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'DB')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'DB')))/ (select Sum(TongTien)from HOA_DON, CHI_TIET_PHIEU_NHAN_PHONG, PHIEU_NHAN_PHONG, PHONG where HOA_DON.MaNhanPhong = PHIEU_NHAN_PHONG.MaNhanPhong and PHIEU_NHAN_PHONG.MaNhanPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaNhanPhong and PHONG.MaPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaPhong)*100";
            String sql3 = "select count(MaPhong) from [PHONG]";
            String sql4 = "select( ((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'LI') * (select DonGia from LOAI_PHONG where MaLoaiPhong = 'LI'))+((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'LII')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'LII'))+((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'DB')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'DB')))/(select count(MaPhong) from[PHONG])*(((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'LI')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'LI'))+((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'LII')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'LII'))+((select count(MaPhong) from[PHONG] where MaLoaiPhong = 'DB')*(select DonGia from LOAI_PHONG where MaLoaiPhong = 'DB')))/(select Sum(TongTien) from HOA_DON, CHI_TIET_PHIEU_NHAN_PHONG, PHIEU_NHAN_PHONG, PHONG where HOA_DON.MaNhanPhong = PHIEU_NHAN_PHONG.MaNhanPhong and PHIEU_NHAN_PHONG.MaNhanPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaNhanPhong and PHONG.MaPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaPhong)*100";
            SqlDataReader dr = db.getDataReader(sql);
            if (dr.Read())
            {
                txtdoanhthuthang.Text  = dr[0].ToString();
                txttongdoanhthuthang1.Text= dr[0].ToString();
                txtdoanhthuthang.Text =String.Format("{0:0,0 vnđ}", Convert.ToDecimal(txtdoanhthuthang.Text));
                txttongdoanhthuthang1.Text = String.Format("{0:0,0 vnđ}", Convert.ToDecimal(txttongdoanhthuthang1.Text));
            }
            SqlDataReader dr1 = db1.getDataReader(sql1);
            if (dr1.Read())
            {
                txtdoanhthuthucte.Text = dr1[0].ToString();
                txtdoanthuthucte1.Text= dr1[0].ToString();
                txtdoanhthuthucte.Text = String.Format("{0:0,0 vnđ}", Convert.ToDecimal(txtdoanhthuthucte.Text));
                txtdoanthuthucte1.Text = String.Format("{0:0,0 vnđ}", Convert.ToDecimal(txtdoanthuthucte1.Text));
            }
            SqlDataReader dr2 = db2.getDataReader(sql2);
            if (dr2.Read())
            {
                txttiledoanhthu.Text = dr2[0].ToString();
               txttieledoanhthu1.Text= dr2[0].ToString();
               
            }
            SqlDataReader dr3 = db3.getDataReader(sql3);
            if (dr3.Read())
            {
                txtsoluongphong.Text = dr3[0].ToString();
                txtsoluongphong.Text = String.Format("{0:0,0 }", Convert.ToDecimal(txtsoluongphong.Text));
            }
            SqlDataReader dr4 = db4.getDataReader(sql4);
            if (dr4.Read())
            {
                txtchisuatphong.Text = dr4[0].ToString();
                txtchisuatphong.Text = String.Format("{0:0,0 vnđ}", Convert.ToDecimal(txtchisuatphong.Text));
            }
            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }
    }

}