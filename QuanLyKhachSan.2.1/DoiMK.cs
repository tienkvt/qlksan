using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLyKhachSan._2._1
{
    public partial class DoiMK : Form
    {
        public DoiMK()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (check_matkhau() == false || check_TenDangNhap() == false)
            {
                MessageBox.Show("Tên Đăng Nhập Hoặc Mật Khẩu Sai Xin Nhập Lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataService db = new DataService();
                String sql = "  UPDATE NGUOI_DUNG SET MatKhau = '" + txtMatKhauMoi.Text+"' WHERE TenDangNhap = '"+ txtTenDangNhap.Text+"'";
                db.executeQuery(sql);
                MessageBox.Show("Bạn đã sửa mật khẩu thành công");
            }
        }
        public bool check_TenDangNhap()
        {

            String tendangnhap = txtTenDangNhap.Text;
            String sql = "Select [TenDangNhap] from [NGUOI_DUNG]  where   TenDangNhap ='" + tendangnhap + "'";
            SqlConnection con = new SqlConnection(@"server=DESKTOP-RHDVU9P\MAYAO;database=QLKS;user id=sa;password=123");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                return true;
            }
            else
            {
                return false;
            }

        }
        public bool check_matkhau()
        {

            String matkhau = txtMatKhau.Text;
            String sql = "Select [MatKhau] from [NGUOI_DUNG]  where   MatKhau ='" + matkhau + "'";
            SqlConnection con = new SqlConnection(@"server=DESKTOP-RHDVU9P\MAYAO;database=QLKS;user id=sa;password=123");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        private void DoiMK_Load(object sender, EventArgs e)
        {

        }
    }
}
