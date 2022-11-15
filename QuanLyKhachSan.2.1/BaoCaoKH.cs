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
    public partial class BaoCaoKH : Form
    {
        public BaoCaoKH()
        {
            InitializeComponent();
        }

        private void BaoCaoKH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLKSDataSet.KHACH_HANG' table. You can move, or remove it, as needed.
            this.KHACH_HANGTableAdapter.Fill(this.QLKSDataSet.KHACH_HANG);

            this.reportViewer1.RefreshReport();
        }
    } 
}


