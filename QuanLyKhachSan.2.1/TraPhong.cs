﻿using System;
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
using System.Timers;
using System.Globalization;

namespace QuanLyKhachSan._2._1
{    
    public partial class TraPhong : DevExpress.XtraEditors.XtraForm
    {
        
        public TraPhong()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
           
            
        }

        private void TraPhong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKSDataSet.CHI_TIET_PHIEU_NHAN_PHONG' table. You can move, or remove it, as needed.
            load_tenkh();
            load_manhanphong();
            LoadData();
            //load_machinhsach();
            load_maphong();
            //load_masddv();
            load_songay();
            load_tienphong();
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("HOA_DON", "MaHoaDon");
            string lastid = a.GetLastID("HOA_DON", "MaHoaDon");
            string ID = a.NextID(lastid, "D");
            #endregion
            load_ngaynhan();
          
        }
        public void LoadData()
        {
            DataService db = new DataService();
            //String sql = "select cthd.MaHoaDon,kh.MaKhachHang,kh.TenKhachHang,ctnp.MaPhong,LoaiDichVu,MaChinhSach,PhuThu,TienPhong,TienDichVu,GiamGiaKH,HinhThucThanhToan,SoNgay,ThanhTien from HOA_DON hd,CHI_TIET_HOA_DON cthd,PHIEU_NHAN_PHONG pnp,KHACH_HANG kh,CHI_TIET_PHIEU_NHAN_PHONG ctnp,DANH_SACH_SU_DUNG_DICH_VU ds,DICH_VU dv where hd.MaHoaDon=cthd.MaHoaDon and hd.MaNhanPhong=pnp.MaNhanPhong and pnp.MaKhachHang=kh.MaKhachHang and cthd.MaSuDungDVu=ds.MaSuDungDvu and ds.MaDichVu=dv.MaDichVu and pnp.MaNhanPhong=ctnp.MaNhanPhong";
            String sql = "select cthd.MaHoaDon,kh.MaKhachHang,kh.TenKhachHang,ctnp.MaPhong,PhuThu,TienPhong,TienDichVu,GiamGiaKH,HinhThucThanhToan,SoNgay,ThanhTien from HOA_DON hd,CHI_TIET_HOA_DON cthd,PHIEU_NHAN_PHONG pnp,KHACH_HANG kh,CHI_TIET_PHIEU_NHAN_PHONG ctnp,DANH_SACH_SU_DUNG_DICH_VU ds,DICH_VU dv where hd.MaHoaDon=cthd.MaHoaDon and hd.MaNhanPhong=pnp.MaNhanPhong and pnp.MaKhachHang=kh.MaKhachHang and ds.MaDichVu=dv.MaDichVu and pnp.MaNhanPhong=ctnp.MaNhanPhong";
            DataTable dt = db.getDataTable(sql);
            gridControl1.DataSource = dt;


        }
      
        public void load_tenkh()
        {
            DataService db = new DataService();
            String sql = "select kh.TenKhachHang, pn.MaKhachHang,pt.MaKhachHang from PHIEU_THUE_PHONG pt,PHIEU_NHAN_PHONG pn ,KHACH_HANG kh where  kh.MaKhachHang=pt.MaKhachHang and kh.MaKhachHang=pn.MaKhachHang";
            DataTable dt = db.getDataTable(sql);
            cbTenKH.DataSource = dt;
            cbTenKH.DisplayMember = "TenKhachHang";
            cbTenKH.ValueMember = "MaKhachHang";

        }
       
       
        public void load_maphong()
        {
            DataService db = new DataService();
            String sql = "select ctnp.MaPhong from PHIEU_NHAN_PHONG np,PHIEU_THUE_PHONG tp,CHI_TIET_PHIEU_NHAN_PHONG ctnp,KHACH_HANG kh where np.MaNhanPhong=ctnp.MaNhanPhong and np.MaKhachHang=kh.MaKhachHang and tp.MaKhachHang=kh.MaKhachHang and kh.MaKhachHang='"+cbTenKH.SelectedValue.ToString()+"'";
            DataTable dt = db.getDataTable(sql);
            cbPhong.DataSource = dt;
            cbPhong.DisplayMember = "MaPhong";
            cbPhong.ValueMember = "MaPhong";
        }
        public void load_manhanphong()
        {
            DataService db = new DataService();
            String sql = "select pn.MaNhanPhong,kh.MaKhachHang from PHIEU_NHAN_PHONG pn,KHACH_HANG kh where pn.MaKhachHang=kh.MaKhachHang and kh.MaKhachHang='"+cbTenKH.SelectedValue.ToString()+"'";
            DataTable dt = db.getDataTable(sql);
            cbphieuthue.DataSource = dt;
            cbphieuthue.DisplayMember = "MaNhanPhong";
            cbphieuthue.ValueMember = "MaNhanPhong";
        }
        public void load_masddv()
        {
            DataService db = new DataService();
            String sql = "select [MaSuDungDvu] from [DANH_SACH_SU_DUNG_DICH_VU] ";
            DataTable dt = db.getDataTable(sql);
            cbDV.DataSource = dt;
            cbDV.DisplayMember = "MaSuDungDvu";
            cbDV.ValueMember = "MaSuDungDvu";
        }
        public void load_machinhsach()
        {
            DataService db = new DataService();
            String sql = "select [MaChinhSach] from [CHINH_SACH_TRA_PHONG]";
            DataTable dt = db.getDataTable(sql);
            cbMaCS.DataSource = dt;
            cbMaCS.DisplayMember = "MaChinhSach";
            cbMaCS.ValueMember = "MaChinhSach";
        }
        public void load_tienphong()
        {
            DataService db = new DataService();
            String sql = "select [DonGia] from [LOAI_PHONG],[PHONG] where LOAI_PHONG.MaLoaiPhong=PHONG.MaLoaiPhong";
            SqlDataReader dr = db.getDataReader(sql);
            if (dr.Read())
            {
                txtTienPhong.Text = dr[0].ToString();
                
            }

        }
        public void load_songay()
        {
            TraPhong a = new TraPhong();
            txtSoNgay.Text = Convert.ToString(a.songay());
        }
       public void load_ngaynhan()
        {
            DataService db = new DataService();
            //string sql = "select NgayNhan from CHI_TIET_PHIEU_NHAN_PHONG where MaNhanPhong='" + cbphieuthue.SelectedValue.ToString()+"'";
            string sql = "select ctnp.NgayNhan from PHIEU_NHAN_PHONG np,CHI_TIET_PHIEU_NHAN_PHONG ctnp where np.MaNhanPhong=ctnp.MaNhanPhong and np.MaKhachHang='" + cbTenKH.SelectedValue.ToString() + "'";
            SqlDataReader dr = db.getDataReader(sql);
            if(dr.Read())
            {
                dtNgatNhan.Value = DateTime.Parse(dr[0].ToString());
            }
            
        }
        public void thanhtien()
        {
            if (txtTienDV.Text == "" || txtPhuThu.Text == ""|| txtGiamGia.Text== "")
            {
                MessageBox.Show("Tiền dịch vụ và tiền Phụ Thu và Giả Giá chưa có ");
                LoadData();
            }
            else
            {
                TraPhong a = new TraPhong();

                float tienphong = Convert.ToSingle(txtTienPhong.Text);
                float tiendv = Convert.ToSingle(txtTienDV.Text);
                float giamgia = Convert.ToSingle(txtGiamGia.Text);
                int songay =Convert.ToInt16( txtSoNgay.Text);
                float phuthu = Convert.ToSingle(txtPhuThu.Text);
                float thanhtien = Convert.ToSingle((tienphong * songay) + tiendv + phuthu - giamgia);
                txtThanhTien.Text = string.Format("{0,6:##0.00}", thanhtien);
                txtTongTien.Text = txtThanhTien.Text;
             
                
            }

        }
        

        private void btnPhong_Click(object sender, EventArgs e)
        {
            thanhtien();
        }
        public void click_them()
        {
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("HOA_DON", "MaHoaDon");
            string lastid = a.GetLastID("HOA_DON", "MaHoaDon");
            string ID = a.NextID(lastid, "D");
            #endregion
            txtMADK.Text = ID;
            TraPhong b = new TraPhong();
            b.songay();
            String sql,sql3;
            var tienphong = float.Parse(txtTienPhong.Text);
            //String masddv = cbDV.SelectedValue.ToString();
            String maphong = cbPhong.SelectedValue.ToString();
            var tiendv = float.Parse(txtTienDV.Text);
            var giamgiakh = float.Parse(txtGiamGia.Text);
            //String machinhsach = cbMaCS.SelectedValue.ToString();
            var phuthu = float.Parse(txtPhuThu.Text);
            txtSoNgay.Text = b.songay().ToString();
            var thanhtoan = txtThanhToan.Text;
            var thanhtien = float.Parse(txtThanhTien.Text);
            String mahoadon = txtMADK.Text;
            String nhanvien = txtNhanVien.Text;
            String makh = cbTenKH.SelectedValue.ToString();
            String manhanphong = cbphieuthue.SelectedValue.ToString();
            var tongtien = float.Parse(txtTongTien.Text);
            String time1 = dtNgayTra.Value.ToString();
            sql = "insert into [HOA_DON]([MaHoaDon],[NhanVienLap] ,[MaNhanPhong],[TongTien],[NgayLap]) values ('" + mahoadon + "',N'" + nhanvien + "','" + manhanphong + "','" + tongtien + "','" + time1 + "')";
            String sql1 = "insert into [CHI_TIET_HOA_DON]([MaHoaDon],[MaPhong] ,[PhuThu],[TienPhong],[TienDichVu],[GiamGiaKH],[HinhThucThanhToan],[SoNgay],[ThanhTien]) values ('" + mahoadon + "','" + maphong + "','" + phuthu + "','" + tienphong + "','" + tiendv + "','" + giamgiakh + "',N'" + thanhtoan + "','" + txtSoNgay.Text + "','" + thanhtien + "')";
            //String sql1 = "insert into [CHI_TIET_HOA_DON]([MaHoaDon],[MaPhong] ,[PhuThu],[TienPhong],[TienDichVu],[GiamGiaKH],[HinhThucThanhToan],[SoNgay],[ThanhTien]) values ('" + mahoadon + "','" + maphong + "',N'" + "','" + phuthu + "','" + tienphong + "','" + tiendv + "','" + giamgiakh + "',N'" + thanhtoan + "','" + txtSoNgay.Text + "','" + thanhtien + "')";
            sql3 = "update PHONG set  MaLoaiTinhTrangPhong=N'1' where MaPhong='" + maphong + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql1);
            db.executeQuery(sql3);
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
        public bool check_masv()
        {

            String msv = txtMADK.Text;
            String sql = "Select [MaHoaDon] from [HOA_DON]  where   MaHoaDon ='" + msv + "'";
            SqlConnection con = new SqlConnection(@"server=DESKTOP-RHDVU9P\MAYAO;database=QLKS;user id=sa;password=123");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Mã này đã có rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
                return true;


            }
            else
            {
                return false;

            }

        }
        public void click_xoa()
        {
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            //String makh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaKhachHang").ToString();
           // String manhanphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanPhong").ToString();
            String mahoadon = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaHoaDon").ToString();
            //String masddv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaSuDungDichVu").ToString();
            //String macs = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaChinhSach").ToString();
            String sql1 = "delete [HOA_DON] where [MaHoaDon]='" + mahoadon + "' ";
            String sql = "delete [CHI_TIET_HOA_DON] where [MaHoaDon]='" + mahoadon + "'and [MaPhong]='" + maphong + "' ";
            DataService db = new DataService();

            db.executeQuery(sql);
            db.executeQuery(sql1);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa  !!!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                LoadData();
            }

            click_xoa();
            LoadData();
        }
        public void click_sua()
        {
            TraPhong a = new TraPhong();
            a.songay();
            String sql;
            String tienphong = txtTienPhong.Text;
            String tiendv = txtTienDV.Text;
            String giamgiakh = txtGiamGia.Text;
            String phuthu = txtPhuThu.Text;
            Int32 songay = a.songay();
            String thanhtoan = txtThanhToan.Text;
            String thanhtien = txtThanhTien.Text;
            String nhanvien = txtNhanVien.Text;
            String manhanphong = cbphieuthue.SelectedValue.ToString();
            String tongtien = txtTongTien.Text;
            String time1 = dtNgayTra.Value.ToString();
            String mahoadon = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaHoaDon").ToString();
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            //String masddv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaSuDungDVu").ToString();
            //String macs = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaChinhSach").ToString();
            sql = "update [CHI_TIET_HOA_DON] set[PhuThu]='" + phuthu + "',[TienPhong]='" + tienphong + "',[TienDichVu]='" + tiendv + "',  [GiamGiaKH]='" + giamgiakh + "',[HinhThucThanhToan]=N'" + thanhtoan + "',[SoNgay]='" + songay + "',[ThanhTien]='" + thanhtien + "' where [MaHoaDon]='" + mahoadon + "' and [MaPhong]='" + maphong + "' ";
            DataService db = new DataService();
           db.executeQuery(sql);

        }
        public int songay()
        {
            int songay;
            DateTime ngaynhan = new DateTime(); DateTime ngaytra = new DateTime();
            DataService db = new DataService();
            string sql = "select NgayNhan from CHI_TIET_PHIEU_NHAN_PHONG";
            SqlDataReader dr = db.getDataReader(sql); 
            if(dr.Read())
            {
                ngaynhan = Convert.ToDateTime(DateTime.Parse(dr[0].ToString()));
            }
          
            ngaytra = Convert.ToDateTime(dtNgayTra.Value.ToString());
            songay = (ngaytra - ngaynhan).Days;
            txtSoNgay.Text = songay.ToString();
            return songay;
            
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("Bạn Đã Sửa Thông Tin Thành Công  ", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTenKH_Click(object sender, EventArgs e)
        {
            KhachHang a = new KhachHang();
            a.ShowDialog();

        }

        private void btphieuthue_Click(object sender, EventArgs e)
        {
            NhanPhong a = new NhanPhong();
            a.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DichVu a = new DichVu();
            a.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataService db = new DataService();
            string sql = "select * from CHI_TIET_HOA_DON ";
            DataTable dt = db.getDataTable(sql);
            if (txtTimkiem.Text != " ")
            {
                dt.DefaultView.RowFilter = "MaHoaDon LIKE '%" + txtTimkiem.Text + "%' ";

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
            //load_machinhsach();
            load_manhanphong();
            load_maphong();
            //load_masddv();
            load_tenkh();
            load_tienphong();
            songay();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
      
            load_manhanphong();
            //load_machinhsach();      
            load_maphong();
            //load_masddv();
            load_tienphong();
            load_ngaynhan();
        }

        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            songay();
        }

        private void txtTienDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void txtPhuThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            String tenkh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenKhachHang").ToString();
            String ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaKhachHang").ToString();
           // String makh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaHoaDon").ToString();
            HoaDon1 a = new HoaDon1(tenkh,ma);
            a.ShowDialog();
        }

        private void txtPhuThu_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}