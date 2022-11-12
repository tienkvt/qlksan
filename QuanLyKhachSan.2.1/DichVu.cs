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
using System.Threading;
namespace QuanLyKhachSan._2._1
{
    public partial class DichVu : DevExpress.XtraEditors.XtraForm
    {
        public DichVu()
        {
            InitializeComponent();
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKSDataSet.DICH_VU' table. You can move, or remove it, as needed.
            this.dICH_VUTableAdapter.Fill(this.qLKSDataSet.DICH_VU);
          //#region ham tang ma tu dong    
          //  AutoIncreCode a = new AutoIncreCode();
          //  a.GetLastID("DICH_VU", "MaDichVu");
          //  string lastid = a.GetLastID("DICH_VU", "MaDichVu");
          //  string ID = a.NextID(lastid, "DV");
          //  #endregion
          //  txtMaDV.Text = ID;  
        }
        public void LoadData()
        {
            DataService db = new DataService();
            String sql = "select MaDichVu,LoaiDichVu,DonVi,DonGia from DICH_VU";
            DataTable dt = db.getDataTable(sql);
            gridControl1.DataSource = dt;


        }
        public void click_them()
        {
          
            #region ham tang ma tu dong    
            AutoIncreCode a = new AutoIncreCode();
            a.GetLastID("DICH_VU", "MaDichVu");
            string lastid = a.GetLastID("DICH_VU", "MaDichVu");
            string ID = a.NextID(lastid, "DV");
            #endregion
            txtMaDV.Text = ID;
            String sql;
            String madv = txtMaDV.Text;
            String tendv = txtTenDV.Text;
            String donvi = txtDonVi.Text;
            String gia = txtGia.Text;
            sql = "insert into DICH_VU(MaDichVu,LoaiDichVu,DonVi,DonGia) values ('" + madv + "','" + tendv + "','" + donvi + "','" + gia + "')";
            DataService db = new DataService();
            db.executeQuery(sql);
        }
        public bool check_masv()
        {

            String msv = txtMaDV.Text;
            String sql = "Select MaDichVu from DICH_VU  where   MaDichVu ='" + msv + "'";
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
            String madv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaDichVu").ToString();
            String tendv = txtTenDV.Text;
            String donvi = txtDonVi.Text;
            String gia = txtGia.Text;
            sql = "update DICH_VU set  LoaiDichVu=N'" + tendv + "' ,DonVi=N'"+ donvi + "',DonGia='"+ gia + "' where MaDichVu='" + madv + "'";
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
            String madv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaDichVu").ToString();
            sql = "delete DICH_VU where MaDichVu='" + madv + "'";     
            DataService db = new DataService();
            db.executeQuery(sql);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa  !!!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

                LoadData();
            }

            click_xoa();
            LoadData();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataService db = new DataService();
            string sql = "select * from DICH_VU ";
            DataTable dt = db.getDataTable(sql);
            if (txtTimkiem.Text != " ")
            {
                dt.DefaultView.RowFilter = "MaDichVu LIKE '%" + txtTimkiem.Text + "%' or LoaiDichVu LIKE '%" + txtTimkiem.Text + "%' ";

            }
            else
            {
                dt.DefaultView.RowFilter = " ";
            }
            gridControl1.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaDV.Text = " ";
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            txtMaDV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaDichVu").ToString();
            txtTenDV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LoaiDichVu").ToString();
            txtDonVi.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DonVi").ToString();
           txtDonVi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DonGia").ToString();
        }

        private void txtDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Vui lòng nhập dữ liệu đúng", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            //}
            
               
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