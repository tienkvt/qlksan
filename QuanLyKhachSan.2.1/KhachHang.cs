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
using QuanLyKhachSan._2._1.DAO;
using QuanLyKhachSan._2._1.BUS;
using QuanLyKhachSan._2._1.DTO;

namespace QuanLyKhachSan._2._1
{
    public partial class KhachHang : DevExpress.XtraEditors.XtraForm
    {
        KhachHangBUS khBus = new KhachHangBUS();
        public KhachHang()
        {
            InitializeComponent();
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'qLKSDataSet.KHACH_HANG' table. You can move, or remove it, as needed.
            this.kHACH_HANGTableAdapter.Fill(this.qLKSDataSet.KHACH_HANG);
            gridControl1.DataSource = this.qLKSDataSet.KHACH_HANG;
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("KHACH_HANG", "MaKhachHang");
            string lastid = a.GetLastID("KHACH_HANG", "MaKhachHang");
            string ID = a.NextID(lastid, "K");
            #endregion
            txtMAKH.Text = ID;
        }
        public void LoadData()
        {
            DataTable dt = khBus.LayDuLieu();
            gridControl1.DataSource = dt;
        }

        public void resetForm()
        {
            txtTENKH.Text = "";
            txtQuocTich.Text = "";
            txtDIACHI.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            cbGioiTinh.SelectedItem = "Nam";
        }

        public void click_them()
        {
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("KHACH_HANG", "MaKhachHang");
            string lastid = a.GetLastID("KHACH_HANG", "MaKhachHang");
            string ID = a.NextID(lastid, "K");
            #endregion

            String hoten = txtTENKH.Text;
            String cmnd = txtCMND.Text;
            String diachi = txtDIACHI.Text;
            String dienthoai = txtSDT.Text;
            String quoctich = txtQuocTich.Text;
            String gioitinh=cbGioiTinh.SelectedItem.ToString();
            KH kh = new KH()
            {
                id = ID,
                hoten = hoten,
                cmnd = cmnd,
                diachi = diachi,
                dienthoai = dienthoai,
                quoctich = quoctich,
                gioitinh = gioitinh
            };
            khBus.ThemKhachHang(kh);

            txtMAKH.Text = a.NextID(ID, "K");
            resetForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (check_masv() == false)
            {
                click_them();
                MessageBox.Show("Bạn đã thêm thành công Khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }

        }
        public void click_xoa()
        {
            String masv = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaKhachHang").ToString();
            KH kh = new KH()
            {
                id = masv
            };
            khBus.XoaKhachHang(kh);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa Khách hàng này!!!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                
                LoadData();
            }
           
            click_xoa();
            LoadData();
        }
        public void click_sua()
        {

            String masv = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaKhachHang").ToString();
            String hoten = txtTENKH.Text;
            String cmnd = txtCMND.Text;
            String diachi = txtDIACHI.Text;
            String dienthoai = txtSDT.Text;
            String quoctich = txtQuocTich.Text;
            String gioitinh = cbGioiTinh.SelectedItem.ToString();
            KH kh = new KH()
            {
                id = masv,
                hoten = hoten,
                cmnd = cmnd,
                diachi = diachi,
                dienthoai = dienthoai,
                quoctich = quoctich,
                gioitinh = gioitinh
            };
            khBus.SuaKhachHang(kh);
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("Bạn đã sửa thông tin Khách hàng", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = khBus.LayDuLieu();
            if (txtTimkiem.Text != " ")
            {
                dt.DefaultView.RowFilter = "MaKhachHang LIKE '%" + txtTimkiem.Text + "%' or TenKhachHang LIKE '%" + txtTimkiem.Text + "%' ";

            }
            else
            {
                dt.DefaultView.RowFilter = " ";
            }
            gridControl1.DataSource = dt;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            txtMAKH.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaKhachHang").ToString();
            txtCMND.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CMND").ToString();
            txtDIACHI.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DiaChi").ToString();
            txtQuocTich.Text =gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "QuocTich").ToString(); 
            txtSDT.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DienThoai").ToString();
            txtTENKH.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenKhachHang").ToString();
        }
        public bool check_masv()
        {

            String makh = txtMAKH.Text;
            SqlDataReader dr = khBus.CheckMaKH(makh);

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

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BaoCaoKH a = new BaoCaoKH();
            a.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void kHACHHANGBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}