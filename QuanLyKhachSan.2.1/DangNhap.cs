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
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        NguoiDungBUS ndBus = new NguoiDungBUS();
        public DangNhap()
        {
            InitializeComponent();
        }
        public bool check_TenDangNhap()
        {
            NguoiDung nd = new NguoiDung()
            {
                tennd = txtTenDangNhap.Text
            };
            SqlDataReader dr = ndBus.layTenDangNhap(nd);

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
            NguoiDung nd = new NguoiDung()
            {
                matkhau = txtMatKhau.Text
            };
            SqlDataReader dr = ndBus.layMatKhau(nd);

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
                NguoiDung nd = new NguoiDung()
                {
                    tennd = txtTenDangNhap.Text
                };
                SqlDataReader dr = ndBus.layLoaiNguoiDung(nd);

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