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
            cboLoaiphong.SelectedItem = "LI";
            load_data();
        }

        public void load_data()
        {
           
            DataService db = new DataService();
            DataService db1 = new DataService();
            String sql = "select sum(HOA_DON.TongTien) from HOA_DON, CHI_TIET_PHIEU_NHAN_PHONG, PHIEU_NHAN_PHONG, PHONG where HOA_DON.MaNhanPhong = PHIEU_NHAN_PHONG.MaNhanPhong and PHIEU_NHAN_PHONG.MaNhanPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaNhanPhong and PHONG.MaPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaPhong and PHONG.MaLoaiPhong='" + cboLoaiphong.SelectedItem + "'";
            String sql1 = " select Sum(TongTien) from HOA_DON , CHI_TIET_PHIEU_NHAN_PHONG, PHIEU_NHAN_PHONG, PHONG where HOA_DON.MaNhanPhong = PHIEU_NHAN_PHONG.MaNhanPhong and PHIEU_NHAN_PHONG.MaNhanPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaNhanPhong and PHONG.MaPhong = CHI_TIET_PHIEU_NHAN_PHONG.MaPhong";
            SqlDataReader dr = db.getDataReader(sql);
            if (dr.Read())
            {
                txtdoanhthuloaiphong.Text = dr[0].ToString();
                txtdoanhthuloaiphong.Text = String.Format("{0:0,0 vnđ}", Convert.ToDecimal(txtdoanhthuloaiphong.Text));
            }
            SqlDataReader dr1 = db1.getDataReader(sql1);
            if (dr1.Read())
            {
                txtdoanhthuthucte.Text = dr1[0].ToString();
                txtdoanhthuthucte.Text = String.Format("{0:0,0 vnđ}", Convert.ToDecimal(txtdoanhthuthucte.Text));
            }
            if(txtdoanhthuloaiphong.Text != String.Empty && txtdoanhthuthucte.Text != String.Empty)
            {
                decimal tongdoanhthu = Convert.ToDecimal(dr1[0].ToString());
                decimal doanhthuloaiphong = Convert.ToDecimal(dr[0].ToString());
                txttiledoanhthu.Text = String.Format("{0:0%}", doanhthuloaiphong/tongdoanhthu);
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

        private void cboLoaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }
    }

}