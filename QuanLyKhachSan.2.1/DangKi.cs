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
    public partial class DangKi : DevExpress.XtraEditors.XtraForm
    {
        public DangKi()
        {
            InitializeComponent();
        }

        private void DangKi_Load(object sender, EventArgs e)
        {
            LoadData();
            load_phong();
            load_tenkh();
            //#region ham tang ma tu dong    
            //AutoIncreCode a = new AutoIncreCode();
            //a.GetLastID("PHIEU_THUE_PHONG", "MaPhieuThue");
            //string lastid = a.GetLastID("PHIEU_THUE_PHONG", "MaPhieuThue");
            //string ID = a.NextID(lastid, "T");
            //#endregion
        }
        public void LoadData()
        {
            DataService db = new DataService();
            String sql = "select PT.MaPhieuThue,KH.TenKhachHang,KH.CMND,KH.DiaChi,KH.DienThoai,P.MaPhong,CTPT.NgayDangKy,CTPT.NgayNhan  from KHACH_HANG KH,PHIEU_THUE_PHONG PT,PHONG P,CHI_TIET_PHIEU_THUE_PHONG CTPT where KH.MaKhachHang=PT.MaKhachHang and CTPT.MaPhong=P.MaPhong AND CTPT.MaPhieuThue=PT.MaPhieuThue ";
            DataTable dt = db.getDataTable(sql);
            gridControl1.DataSource = dt;


        }
        public void load_tenkh()
        {
            DataService db = new DataService();
            String sql = "select [MaKhachHang],TenKhachHang from [KHACH_HANG]";
            DataTable dt = db.getDataTable(sql);
            cbTenKh.DataSource = dt;
            cbTenKh.DisplayMember = "TenKhachHang";
            cbTenKh.ValueMember = "MaKhachHang";
        }
        public void load_phong()
        {
            DataService db = new DataService();
            String sql = "select [MaPhong] from [PHONG], LOAI_TINH_TRANG where PHONG.MaLoaiTinhTrangPhong=LOAI_TINH_TRANG.MaLoaiTinhTrangPhong and LOAI_TINH_TRANG.TenLoaiTinhTrang like N'" + "Trống" + "'";
            DataTable dt = db.getDataTable(sql);
            cbPhong.DataSource = dt;
            cbPhong.DisplayMember = "MaPhong";
            cbPhong.ValueMember = "MaPhong";
        }
        public void click_them()
        {
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("PHIEU_THUE_PHONG", "MaPhieuThue");
            string lastid = a.GetLastID("PHIEU_THUE_PHONG", "MaPhieuThue");
            string ID = a.NextID(lastid, "T");
            #endregion
            String sql, sql2,sql3;
            txtMADK.Text = ID;
            String makh = cbTenKh.SelectedValue.ToString();
            String phong = cbPhong.SelectedValue.ToString();
            String ngaydk = dtpDangki.Value.ToString();
            String ngaynhan = dtpNhanphong.Value.ToString();
            sql = "insert into PHIEU_THUE_PHONG(MaPhieuThue,MaKhachHang) values ('" + txtMADK.Text + "','" + makh + "')";
            sql2 = "insert into CHI_TIET_PHIEU_THUE_PHONG(MaPhieuThue,MaPhong,NgayDangKy,NgayNhan) values ('" + txtMADK.Text + "','" + phong + "','" + ngaydk + "','" + ngaynhan + "')";
            sql3= "update PHONG set  MaLoaiTinhTrangPhong=N'2' where MaPhong='" + phong + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql2);
            db.executeQuery(sql3);

        }
        public bool check_masv()
        {

            String msv = txtMADK.Text;
            String sql = "Select MaPhieuThue from PHIEU_THUE_PHONG  where   MaPhieuThue ='" + msv + "'";
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
            if (check_masv() == false)
            {
                click_them();
                MessageBox.Show("Bạn đã thêm thành công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
        public void click_sua()
        {

            String sql, sql2;
            String masv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhieuThue").ToString();
            String makh = cbTenKh.SelectedValue.ToString();
            String phong = cbPhong.SelectedValue.ToString();
            String ngaydk = dtpDangki.Value.ToString();
            String ngaynhan = dtpNhanphong.Value.ToString();
            sql = "update PHIEU_THUE_PHONG set  MaKhachHang=N'" + makh + "' where MaPhieuThue='" + masv + "'";
            sql2 = "update CHI_TIET_PHIEU_THUE_PHONG set  MaPhong='" + phong + "',NgayDangKy='" + ngaydk + "',NgayNhan='" + ngaynhan + "'  where MaPhieuThue='" + masv + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql2);

        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("Bạn đã sửa thông tin   ", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void click_xoa()
        {
            String sql, sql1;
            String mapt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhieuThue").ToString();
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            sql = "delete PHIEU_THUE_PHONG where MaPhieuThue='" + mapt + "'";
            sql1 = "delete CHI_TIET_PHIEU_THUE_PHONG where MaPhieuThue='" + mapt + "' and MaPhong='" + maphong + "'";
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
            string sql = "select * from PHIEU_THUE_PHONG ";
            DataTable dt = db.getDataTable(sql);
            if (txtTimkiem.Text != " ")
            {
                dt.DefaultView.RowFilter = "MaPhieuThue LIKE '%" + txtTimkiem.Text + "%' or MaKhachHang LIKE '%" + txtTimkiem.Text + "%' ";

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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            cbTenKh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenKhachHang").ToString();
            cbPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            dtpDangki.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayDangKy").ToString();
            dtpNhanphong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NgayNhan").ToString();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            KhachHang a = new KhachHang();
            a.ShowDialog();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            Phong a = new Phong();
            a.ShowDialog();
        }
    }
}