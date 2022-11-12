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
    public partial class Phong : DevExpress.XtraEditors.XtraForm
    {
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
            DataService db = new DataService();
            String sql = "select p.MaPhong,tr.TenLoaiTinhTrang,lp.TenLoaiPhong,lp.DonGia,lp.SoNguoiChuan,lp.SoNguoiToiDa from PHONG p, LOAI_TINH_TRANG tr,LOAI_PHONG lp where p.MaLoaiTinhTrangPhong = tr.MaLoaiTinhTrangPhong and p.MaLoaiPhong = lp.MaLoaiPhong";
            DataTable dt = db.getDataTable(sql);
            gridControl1.DataSource = dt;
        }
        public void load_loaitinhtrang()
        {
            DataService db = new DataService();
            String sql = "select * from LOAI_TINH_TRANG tr  ";
            DataTable dt = db.getDataTable(sql);
            cbLoaiTinhTrang.DataSource = dt;
            cbLoaiTinhTrang.DisplayMember = "TenLoaiTinhTrang";
            cbLoaiTinhTrang.ValueMember = "MaLoaiTinhTrangPhong";
        }
        public void load_loaiphong()
        {
            DataService db = new DataService();
            String sql = "select lp.MaLoaiPhong,lp.TenLoaiPhong,lp.DonGia,lp.SoNguoiChuan,lp.SoNguoiToiDa from LOAI_PHONG lp";
            DataTable dt = db.getDataTable(sql);
            cbLoaiPhong.DataSource = dt;
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.ValueMember = "MaLoaiPhong";
            txtGia.DataBindings.Add("text", dt, "DonGia");
            txtNguoiChuan.DataBindings.Add("text", dt, "SoNguoiChuan");
            txtNguoiToiDa.DataBindings.Add("text", dt, "SoNguoiToiDa");
        }
        public void click_them()
        {
            
            String sql;
            String maphong = txtMaphong.Text;
            String maloaiphong = cbLoaiPhong.SelectedValue.ToString();
            String maloaitinhtrang = cbLoaiTinhTrang.SelectedValue.ToString();
            sql = "insert into PHONG(MaPhong,MaLoaiPhong,MaLoaiTinhTrangPhong) values ('" + maphong + "','" + maloaiphong + "','"+maloaitinhtrang+"')";
            DataService db = new DataService();
            db.executeQuery(sql);
        }
        public bool check_masv()
        {

            String msv = txtMaphong.Text;
            String sql = "Select MaPhong from PHONG  where   MaPhong ='" + msv + "'";
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

            String sql;
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            String maloaiphong = cbLoaiPhong.SelectedValue.ToString();
            String maloaitinhtrang = cbLoaiTinhTrang.SelectedValue.ToString();        
            sql = "update PHONG set  MaLoaiPhong=N'" + maloaiphong + "', MaLoaiTinhTrangPhong='"+maloaitinhtrang+"' where MaPhong='" + maphong + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("Bạn đã sửa thông tin  ", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void click_xoa()
        {
            String sql;
            String maphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPhong").ToString();
            //String maloaiphong= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaLoaiPhong").ToString();
            //String matinhtrang= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaLoaiTinhTrangPhong").ToString();/*and MaLoaiPhong='"+maloaiphong+"' and MaLoaiTinhTrangPhong='"+matinhtrang+"'*/ 
            sql = "delete PHONG where MaPhong='" + maphong + "' ";
            DataService db = new DataService();
            db.executeQuery(sql);

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
            string sql = "select * from PHONG ";
            DataTable dt = db.getDataTable(sql);
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