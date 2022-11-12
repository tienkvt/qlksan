using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan._2._1
{
    public partial class PhanQuyen : Form
    {
        public PhanQuyen()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            DataService db = new DataService();
            String sql = " select TenDangNhap,TenLoaiNguoiDung,NGUOI_DUNG.LoaiNguoiDung from LOAI_NGUOI_DUNG,NGUOI_DUNG where NGUOI_DUNG.LoaiNguoiDung=LOAI_NGUOI_DUNG.LoaiNguoiDung";
            String sql1 = "select * from LOAI_NGUOI_DUNG ";
            cbloai.DataSource = db.getDataTable(sql1);
            cbloai.DisplayMember = "TenLoaiNguoiDung";
            cbloai.ValueMember = "LoaiNguoiDung";
            cbuser.DataSource = db.getDataTable(sql);
            cbuser.DisplayMember = "TenDangNhap";
            cbuser.ValueMember = "TenDangNhap";
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            DataService db = new DataService();
            String sql = " UPDATE NGUOI_DUNG SET LoaiNguoiDung='"+cbloai.SelectedValue.ToString()+"' WHERE TenDangNhap = '" + cbuser.SelectedValue.ToString() + "'";
            db.executeQuery(sql);
            MessageBox.Show("Bạn đã sửa mật khẩu thành công");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PhanQuyen_Load(object sender, EventArgs e)
        {

        }
    }
}
