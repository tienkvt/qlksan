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
    public partial class NhanPhong : DevExpress.XtraEditors.XtraForm
    {
        public NhanPhong()
        {
            InitializeComponent();
        }

        private void NhanPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            load_tenkh();
            load_phong();
            loadphieuthue();
            //#region ham tang ma tu dong    
            //AutoIncreCode a = new AutoIncreCode();
            //a.GetLastID("PHIEU_NHAN_PHONG", "MaNhanPhong");
            //string lastid = a.GetLastID("PHIEU_NHAN_PHONG", "MaNhanPhong");
            //string ID = a.NextID(lastid, "N");
            //#endregion
            //txtMaphiedk.Text = ID;

        }
        public void LoadData()
        {
            DataService db = new DataService();
            String sql = "select PT.MaNhanPhong,KH.TenKhachHang,KH.CMND,KH.DiaChi,KH.DienThoai,P.MaPhong,CTPT.NgayNhan  from KHACH_HANG KH,PHIEU_NHAN_PHONG PT,PHONG P,CHI_TIET_PHIEU_NHAN_PHONG CTPT where KH.MaKhachHang=PT.MaKhachHang and CTPT.MaPhong=P.MaPhong AND CTPT.MaNhanPhong=PT.MaNhanPhong ";
            DataTable dt = db.getDataTable(sql);
            gridControl1.DataSource = dt;


        }
        public void load_tenkh()
        {
            DataService db = new DataService();
            String sql = "select [MaKhachHang],TenKhachHang from [KHACH_HANG]";
            DataTable dt = db.getDataTable(sql);
            cbTenKH.DataSource = dt;
            cbTenKH.DisplayMember = "TenKhachHang";
            cbTenKH.ValueMember = "MaKhachHang";
        }
        public void load_phong()
        {
            DataService db = new DataService();
            String sql = "select ctptp.MaPhong from CHI_TIET_PHIEU_THUE_PHONG ctptp,PHIEU_THUE_PHONG ptp,KHACH_HANG kh where ctptp.MaPhieuThue=ptp.MaPhieuThue and ptp.MaKhachHang=kh.MaKhachHang and kh.MaKhachHang='"+cbTenKH.SelectedValue.ToString()+"'";
            DataTable dt = db.getDataTable(sql);
            cbPhong.DataSource = dt;
            cbPhong.DisplayMember = "MaPhong";
            cbPhong.ValueMember = "MaPhong";
            if(cbPhong.Text=="")
            {
                String sql1 = "select MaPhong from PHONG where [MaLoaiTinhTrangPhong]='1'";
                DataTable dt1 = db.getDataTable(sql1);
                cbPhong.DataSource = dt1;
                cbPhong.DisplayMember = "MaPhong";
                cbPhong.ValueMember = "MaPhong";
            }

           
            
        }
        public void loadphieuthue()
        {
            DataService db = new DataService();
            String sql = "SELECT PHIEU_THUE_PHONG.MaPhieuThue,PHIEU_THUE_PHONG.MaKhachHang FROM PHIEU_THUE_PHONG WHERE  PHIEU_THUE_PHONG.MaKhachHang = '" + cbTenKH.SelectedValue.ToString() + "'";
            DataTable dt = db.getDataTable(sql);
            cbphieuthue.DataSource = dt;
            cbphieuthue.DisplayMember = "MaPhieuThue";
            cbphieuthue.ValueMember = "MaPhieuThue";
        }
        public void click_them()
        {
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("PHIEU_NHAN_PHONG", "MaNhanPhong");
            string lastid = a.GetLastID("PHIEU_NHAN_PHONG", "MaNhanPhong");
            string ID = a.NextID(lastid, "N");
            #endregion
            if (cbphieuthue.Text == "")
            {
                MessageBox.Show("Bạn Phải Đăng Kí Phòng");
                LoadData();
                
            }
            else
            {
                String sql, sql2, sql3;
                txtMaphiedk.Text = ID;
                String makh = cbTenKH.SelectedValue.ToString();
                String phong = cbPhong.SelectedValue.ToString();
                String maphieuthue = cbphieuthue.SelectedValue.ToString();
                String ngaynhan = dtNgayNhan.Value.ToString();
                sql = "insert into PHIEU_NHAN_PHONG(MaNhanPhong,MaKhachHang,MaPhieuThue) values ('" + txtMaphiedk.Text + "','" + makh + "','" + maphieuthue + "')";
                sql2 = "insert into CHI_TIET_PHIEU_NHAN_PHONG(MaNhanPhong,MaPhong,NgayNhan) values ('" + txtMaphiedk.Text + "','" + phong + "','" + ngaynhan + "')";
                sql3 = "update PHONG set  MaLoaiTinhTrangPhong=N'3' where MaPhong='" + phong + "'";
                DataService db = new DataService();
                db.executeQuery(sql);
                db.executeQuery(sql2);
                db.executeQuery(sql3);
                MessageBox.Show("Bạn đã thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        public bool check_masv()
        {

            String msv = txtMaphiedk.Text;
            String sql = "Select MaNhanPhong from PHIEU_NHAN_PHONG  where   MaNhanPhong ='" + msv + "'";
            SqlConnection con = new SqlConnection(@"server=DESKTOP-RHDVU9P\MAYAO;database=QLKS;user id=sa;password=123");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Mã khách hàng này đã có rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
                return true;


            }
            else
            {
                return false;

            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (check_masv() == false )
           // {
                click_them();
                
                LoadData();
            //}
        }
        public void click_sua()
        {

           
            String sql, sql2;
            String masv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanPhong").ToString();
            String makh = cbTenKH.SelectedValue.ToString();
            String phong = cbPhong.SelectedValue.ToString();
            String ngaynhan = dtNgayNhan.Checked.ToString();
            sql = "update PHIEU_NHAN_PHONG set  MaKhachHang=N'" + makh + "' where MaNhanPhong='" + masv + "'";
            sql2 = "update CHI_TIET_PHIEU_NHAN_PHONG set  MaPhong='" + phong + "',NgayNhan='" + ngaynhan + "'  where MaNhanPhong='" + masv + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql2);

        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("bạn đã sửa thông tin ", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void click_xoa()
        {
            String sql, sql1;
            String mapt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanPhong").ToString();
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            sql = "delete PHIEU_NHAN_PHONG where MaNhanPhong='" + mapt + "'";
            sql1 = "delete CHI_TIET_PHIEU_NHAN_PHONG where MaNhanPhong='" + mapt + "' and MaPhong='" + maphong + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa !!!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

                LoadData();
            }

            click_xoa();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataService db = new DataService();
            string sql = "select * from PHIEU_NHAN_PHONG ";
            DataTable dt = db.getDataTable(sql);
            if (txtTimkiem.Text != " ")
            {
                dt.DefaultView.RowFilter = "MaNhanPhong LIKE '%" + txtTimkiem.Text + "%' or MaKhachHang LIKE '%" + txtTimkiem.Text + "%' ";

            }
            else
            {
                dt.DefaultView.RowFilter = " ";
            }
            gridControl1.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            load_phong();
            load_tenkh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTenKH_Click(object sender, EventArgs e)
        {
            KhachHang a = new KhachHang();
            a.ShowDialog();
        }

        private void btphieuthue_Click(object sender, EventArgs e)
        {
            DangKi a = new DangKi();
            a.ShowDialog();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            Phong a = new Phong();
            a.ShowDialog();
        }

        private void cbTenKH_SelectedValueChanged(object sender, EventArgs e)
        {
            load_phong();
            loadphieuthue();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HoaDon1 a = new HoaDon1();
                a.ShowDialog();
        }
    }
}