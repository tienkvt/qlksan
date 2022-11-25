using QuanLyKhachSan._2._1.DAO;
using QuanLyKhachSan._2._1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan._2._1.BUS
{
    internal class NhanPhongBUS
    {
        NhanPhongDAO npDao = new NhanPhongDAO();
        public DataTable LayDuLieu()
        {
            return npDao.LayDuLieu();
        }

        public DataTable LayDSTenKhachHang()
        {
            return npDao.LayDSTenKhachHang();
        }

        public DataTable LayDSPhong(string makh)
        {
            return npDao.LayDSPhong(makh);
        }

        public DataTable LayDSPhieuThue(string makh)
        {
            return npDao.LayDSPhieuThue(makh);
        }

        public SqlDataReader CheckMaNhanPhong(string manhanphong)
        {
            return npDao.CheckMaNhanPhong(manhanphong);
        }

        public void ThemPhong(PhieuNhanPhong pnp, ChiTietPhieuNhanPhong ctpnp)
        {
            npDao.ThemPhong(pnp, ctpnp);
        }

        public void SuaPhong(PhieuNhanPhong pnp, ChiTietPhieuNhanPhong ctpnp)
        {
            npDao.SuaPhong(pnp, ctpnp);
        }

        public void XoaPhong(string manp, string maphong)
        {
            npDao.XoaPhong(manp, maphong);
        }
    }
}
