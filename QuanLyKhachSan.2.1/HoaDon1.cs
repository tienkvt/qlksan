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

namespace QuanLyKhachSan._2._1
{
    public partial class HoaDon1 : DevExpress.XtraEditors.XtraForm
    {
        string tenkh,ma;
        public HoaDon1()
        {
            InitializeComponent();
        }
        public HoaDon1( string hotenkh, string makh) : this()
        {
            tenkh = hotenkh;
            ma = makh;
        }
       
        private void HoaDon1_Load(object sender, EventArgs e)
        {TraPhong a = new TraPhong();
            
            // TODO: This line of code loads data into the 'HoaDon.HOA_DON' table. You can move, or remove it, as needed.
            this.HOA_DONTableAdapter.Fill(this.HoaDon.HOA_DON);
            // TODO: This line of code loads data into the 'HoaDon.CHI_TIET_HOA_DON' table. You can move, or remove it, as needed.
            this.CHI_TIET_HOA_DONTableAdapter.Fill(this.HoaDon.CHI_TIET_HOA_DON,ma);
            // TODO: This line of code loads data into the 'HoaDon.PHIEU_NHAN_PHONG' table. You can move, or remove it, as needed.
            this.PHIEU_NHAN_PHONGTableAdapter.Fill(this.HoaDon.PHIEU_NHAN_PHONG);
            // TODO: This line of code loads data into the 'HoaDon.KHACH_HANG' table. You can move, or remove it, as needed.
            this.KHACH_HANGTableAdapter.Fill(this.HoaDon.KHACH_HANG, tenkh);
            // TODO: This line of code loads data into the 'HoaDon.DICH_VU' table. You can move, or remove it, as needed.
            this.DICH_VUTableAdapter.Fill(this.HoaDon.DICH_VU);
            // TODO: This line of code loads data into the 'HoaDon.DANH_SACH_SU_DUNG_DICH_VU' table. You can move, or remove it, as needed.
            this.DANH_SACH_SU_DUNG_DICH_VUTableAdapter.Fill(this.HoaDon.DANH_SACH_SU_DUNG_DICH_VU);

            this.reportViewer1.RefreshReport();
        }
    }
}