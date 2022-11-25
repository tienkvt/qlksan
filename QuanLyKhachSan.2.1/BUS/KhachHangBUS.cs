using QuanLyKhachSan._2._1.DTO;
using QuanLyKhachSan._2._1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachSan._2._1.BUS
{
    internal class KhachHangBUS
    {
        public KhachHangDAO khDao = new KhachHangDAO();
        public DataTable LayDuLieu()
        {
            return khDao.LayDuLieu();
        }

        public SqlDataReader CheckMaKH(string makh)
        {
            return khDao.CheckMaKH(makh);
        }

        public void ThemKhachHang(KH kh)
        {
            khDao.ThemKhachHang(kh);
        }

        public void SuaKhachHang(KH kh)
        {
            khDao.SuaKhachHang(kh);
        }

        public void XoaKhachHang(KH kh)
        {
            khDao.XoaKhachHang(kh);
        }
    }
}
