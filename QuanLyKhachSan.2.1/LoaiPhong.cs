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
    public partial class LoaiPhong : DevExpress.XtraEditors.XtraForm
    {
        public LoaiPhong()
        {
            InitializeComponent();
        }

        private void LoaiPhong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKSDataSet.LOAI_PHONG' table. You can move, or remove it, as needed.
            this.lOAI_PHONGTableAdapter.Fill(this.qLKSDataSet.LOAI_PHONG);

        }
        public void LoadData()
        {
            DataService db = new DataService();
            String sql = "select * from LOAI_PHONG";
            DataTable dt = db.getDataTable(sql);
            gridControl1.DataSource = dt;


        }
        public void click_them()
        {

            //#region ham tang ma tu dong    
            //AutoIncreCode a = new AutoIncreCode();
            //a.GetLastID("LOAI_PHONG", "MaLoaiPhong");
            //string lastid = a.GetLastID("LOAI_PHONG", "MaLoaiPhong");
            //string ID = a.NextID(lastid, "LP");
            //#endregion
           // txtMaLP.Text = ID;
            String sql;
            String malp = txtMaLP.Text;
            String tentb = txtTenLP.Text;
            String gia = txtGia.Text;
            String soluongchuan = nbSLC.Value.ToString();
            String soluongtoida = nbSLTD.Value.ToString();
            sql = "insert into LOAI_PHONG(MaLoaiPhong,TenLoaiPhong,DonGia,SoNguoiChuan,SoNguoiToiDa) values ('" + malp + "','" + tentb + "','" + gia + "','" + soluongchuan + "','" + soluongtoida + "')";
            DataService db = new DataService();
            db.executeQuery(sql);
        }
        public bool check_masv()
        {

            String msv = txtMaLP.Text;
            String sql = "Select MaLoaiPhong from LOAI_PHONG  where   MaLoaiPhong ='" + msv + "'";
            SqlConnection con = new SqlConnection(@"Data Source=LEVY7F50\MSSQLSERVER2014;Initial Catalog=QLKS;Integrated Security=True");
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
                MessageBox.Show("Bạn đã thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
        public void click_sua()
        {

            String sql;
            String malp = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaLoaiPhong").ToString();
            String tentb = txtTenLP.Text;
            String gia = txtGia.Text;
            String soluongchuan = nbSLC.Value.ToString();
            String soluongtoida = nbSLTD.Value.ToString();
            sql = "update LOAI_PHONG set  TenLoaiPhong=N'" + tentb + "' ,DonGia='" + gia + "',SoNguoiChuan='" + soluongchuan + "' ,SoNguoiToiDa='" + soluongtoida + "' where MaLoaiPhong='" + malp + "'";
            DataService db = new DataService();
            db.executeQuery(sql);

        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            click_sua();
            LoadData();
            MessageBox.Show("bạn đã sửa thông tin sinh viên  ", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void click_xoa()
        {
            String sql;
            String madv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaLoaiPhong").ToString();
            sql = "delete LOAI_PHONG where MaLoaiPhong='" + madv + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa một sinh viên !!!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

                LoadData();
            }

            click_xoa();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataService db = new DataService();
            string sql = "select * from LOAI_PHONG ";
            DataTable dt = db.getDataTable(sql);
            if (txtTimkiem.Text != " ")
            {
                dt.DefaultView.RowFilter = "MaLoaiPhong LIKE '%" + txtTimkiem.Text + "%' or TenLoaiPhong LIKE '%" + txtTimkiem.Text + "%' ";

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

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
        }
    }
}