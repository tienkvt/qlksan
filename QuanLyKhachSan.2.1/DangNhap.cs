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
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public bool check_TenDangNhap()
        {

            String tendangnhap = txtTenDangNhap.Text;
            String sql = "Select [TenDangNhap] from [NGUOI_DUNG]  where   TenDangNhap ='" + tendangnhap + "'";
            SqlConnection con = new SqlConnection(@"Data Source=LEVY7F50\MSSQLSERVER2014;Initial Catalog=QLKS;Integrated Security=True");
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
            SqlConnection con = new SqlConnection(@"Data Source=LEVY7F50\MSSQLSERVER2014;Initial Catalog=QLKS;Integrated Security=True");
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (check_matkhau() == false || check_TenDangNhap() == false)
            {
                MessageBox.Show("Tên Đăng Nhập Hoặc Mật Khẩu Sai Xin Nhập Lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String sql = " SELECT [LoaiNguoiDung] FROM [NGUOI_DUNG] where TenDangNhap='"+txtTenDangNhap.Text+"'";
                SqlConnection con = new SqlConnection(@"Data Source=LEVY7F50\MSSQLSERVER2014;Initial Catalog=QLKS;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string Msg = dr[0].ToString();
                    Form1 a = new Form1(Msg);
                    a.ShowDialog();
                }
                

            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            DoiMK a = new DoiMK();
            a.ShowDialog();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}