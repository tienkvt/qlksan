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
    public partial class Phong : DevExpress.XtraEditors.XtraForm
    {
        PhongBUS phongBus = new PhongBUS();
        public Phong()
        {
            InitializeComponent();
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            LoadData();
            load_loaiphong();
            load_loaitinhtrang();
           
        }
        public void LoadData()
        {
            DataTable dt = phongBus.LayDuLieu();
            gridControl1.DataSource = dt;
        }
        public void load_loaitinhtrang()
        {
            DataTable dt = phongBus.LayLoaiTinhTrang();
            cbLoaiTinhTrang.DataSource = dt;
            cbLoaiTinhTrang.DisplayMember = "TenLoaiTinhTrang";
            cbLoaiTinhTrang.ValueMember = "MaLoaiTinhTrangPhong";
        }
        public void load_loaiphong()
        {
            DataTable dt = phongBus.LayLoaiPhong();
            cbLoaiPhong.DataSource = dt;
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.ValueMember = "MaLoaiPhong";
            txtGia.DataBindings.Add("text", dt, "DonGia");
            txtNguoiChuan.DataBindings.Add("text", dt, "SoNguoiChuan");
            txtNguoiToiDa.DataBindings.Add("text", dt, "SoNguoiToiDa");
        }
        public void click_them()
        {
            
            String maphong = txtMaphong.Text;
            String maloaiphong = cbLoaiPhong.SelectedValue.ToString();
            String maloaitinhtrang = cbLoaiTinhTrang.SelectedValue.ToString();
            PhongDTO phong = new PhongDTO()
            {
                MaPhong = maphong,
                MaLoaiPhong = maloaiphong,
                MaLoaiTinhTrangPhong = maloaitinhtrang
            };
            phongBus.ThemPhong(phong);
        }
        public bool check_masv()
        {

            String maphong = txtMaphong.Text;
            SqlDataReader dr = phongBus.CheckMaPhong(maphong);

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

            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            String maloaiphong = cbLoaiPhong.SelectedValue.ToString();
            String maloaitinhtrang = cbLoaiTinhTrang.SelectedValue.ToString();
            PhongDTO phong = new PhongDTO()
            {
                MaPhong = maphong,
                MaLoaiPhong = maloaiphong,
                MaLoaiTinhTrangPhong = maloaitinhtrang
            };
            phongBus.SuaPhong(phong);
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("Bạn đã sửa thông tin  ", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void click_xoa()
        {
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            phongBus.XoaPhong(maphong);
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
            DataTable dt = phongBus.LayDuLieu();
            if (txtTimkiem.Text != " ")
            {
                dt.DefaultView.RowFilter = "MaPhong LIKE '%" + txtTimkiem.Text + "%' ";

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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaphong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void txtNguoiChuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }

        private void txtNguoiToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }
    }
}