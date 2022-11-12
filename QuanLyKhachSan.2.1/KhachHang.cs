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
    public partial class KhachHang : DevExpress.XtraEditors.XtraForm
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'qLKSDataSet.KHACH_HANG' table. You can move, or remove it, as needed.
            this.kHACH_HANGTableAdapter.Fill(this.qLKSDataSet.KHACH_HANG);
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
            DataService db = new DataService();
            String sql = "select * from KHACH_HANG ";
            DataTable dt = db.getDataTable(sql);
              gridControl1.DataSource = dt;
            
        }


        public void click_them()
        {
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("KHACH_HANG", "MaKhachHang");
            string lastid = a.GetLastID("KHACH_HANG", "MaKhachHang");
            string ID = a.NextID(lastid, "K");
            #endregion
            String sql;
            txtMAKH.Text = ID;    
            String hoten = txtTENKH.Text;
            String cmnd = txtCMND.Text;
            String diachi = txtDIACHI.Text;
            String dienthoai = txtSDT.Text;
            String quoctich = txtQuocTich.Text;
            String gioitinh=cbGioiTinh.SelectedItem.ToString();
            sql = "insert into KHACH_HANG(MaKhachHang,TenKhachHang,CMND,GioiTinh ,DiaChi,DienThoai ,QuocTich) values ('" + txtMAKH.Text + "',N'" + hoten + "','" + cmnd + "',N'" + gioitinh + "',N'" + diachi + "','" + dienthoai + "',N'" + quoctich + "')";
            DataService db = new DataService();
            db.executeQuery(sql);


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (check_masv() == false)
            {
                click_them();
                MessageBox.Show("Bạn đã thêm thành công sinh viên và điểm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }

        }
        public void click_xoa()
        {

            String masv = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaKhachHang").ToString();
            String sql1 = "delete KHACH_HANG where MaKhachHang='" + masv + "'";
            DataService db = new DataService();

            db.executeQuery(sql1);
        }
       

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa một sinh viên !!!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                
                LoadData();
            }
           
            click_xoa();
            LoadData();


        }
        public void click_sua()
        {

            String sql;
            String masv = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaKhachHang").ToString();
            String hoten = txtTENKH.Text;
            String cmnd = txtCMND.Text;
            String diachi = txtDIACHI.Text;
            String dienthoai = txtSDT.Text;
            String quoctich = txtQuocTich.Text;
            String gioitinh = cbGioiTinh.SelectedItem.ToString();
            sql = "update KHACH_HANG set  TenKhachHang=N'" + hoten + "', CMND='" + cmnd + "',DiaChi=N'" + diachi + "' , DienThoai='" + dienthoai + "',QuocTich=N'" + quoctich + "',GioiTinh=N'" + gioitinh + "' where MaKhachHang='" + masv + "'";
            DataService db = new DataService();
            db.executeQuery(sql);

        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("bạn đã sửa thông tin sinh viên  ", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataService db = new DataService();
            string sql = "select * from KHACH_HANG ";
            DataTable dt = db.getDataTable(sql);
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

            String msv = txtMAKH.Text;
            String sql = "Select MaKhachHang from KHACH_HANG  where   MaKhachHang ='" + msv + "'";
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
       
    }
}