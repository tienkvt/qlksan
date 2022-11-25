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
using QuanLyKhachSan._2._1.BUS;
using QuanLyKhachSan._2._1.DTO;

namespace QuanLyKhachSan._2._1
{
    public partial class NhanPhong : DevExpress.XtraEditors.XtraForm
    {
        DataService db = new DataService();
        NhanPhongBUS npBus = new NhanPhongBUS();
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
            gridControl1.DataSource = npBus.LayDuLieu();
        }
        public void load_tenkh()
        {
            DataTable dt =npBus.LayDSTenKhachHang();
            cbTenKH.DataSource = dt;
            cbTenKH.DisplayMember = "TenKhachHang";
            cbTenKH.ValueMember = "MaKhachHang";
        }
        public void load_phong()
        {
            DataTable dt = npBus.LayDSPhong(cbTenKH.SelectedValue.ToString());
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
            DataTable dt = npBus.LayDSPhieuThue(cbTenKH.SelectedValue.ToString());
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
                txtMaphiedk.Text = ID;
                String makh = cbTenKH.SelectedValue.ToString();
                String phong = cbPhong.SelectedValue.ToString();
                String maphieuthue = cbphieuthue.SelectedValue.ToString();
                String ngaynhan = dtNgayNhan.Value.ToString();
                PhieuNhanPhong pnp = new PhieuNhanPhong()
                {
                    MaNhanPhong = ID,
                    MaKhachHang = makh,
                    MaPhieuthue = maphieuthue
                };
                ChiTietPhieuNhanPhong ctpnp = new ChiTietPhieuNhanPhong()
                {
                    MaNhanPhong = ID,
                    MaPhong = phong,
                    NgayNhan = ngaynhan
                };
                npBus.ThemPhong(pnp, ctpnp);
                MessageBox.Show("Bạn đã thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        public bool check_masv()
        {

            String manp = txtMaphiedk.Text;
            SqlDataReader dr = npBus.CheckMaNhanPhong(manp);

            if (dr.Read())
            {
                MessageBox.Show("Mã nhận phòng này đã có rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                
                LoadData();
            }
        }
        public void click_sua()
        {

           
            String manp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanPhong").ToString();
            String makh = cbTenKH.SelectedValue.ToString();
            String phong = cbPhong.SelectedValue.ToString();
            String ngaynhan = dtNgayNhan.Checked.ToString();
            PhieuNhanPhong pnp = new PhieuNhanPhong()
            {
                MaNhanPhong = manp,
                MaKhachHang = makh
            };
            ChiTietPhieuNhanPhong ctpnp = new ChiTietPhieuNhanPhong()
            {
                MaNhanPhong = manp,
                MaPhong = phong,
                NgayNhan = ngaynhan
            };
            npBus.SuaPhong(pnp, ctpnp);

        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("bạn đã sửa thông tin ", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void click_xoa()
        {
            String manp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanPhong").ToString();
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            npBus.XoaPhong(manp, maphong);
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