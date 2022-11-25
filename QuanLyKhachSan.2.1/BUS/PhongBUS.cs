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
    internal class PhongBUS
    {
        PhongDAO phongDao = new PhongDAO();
        public DataTable LayDuLieu()
        {
            return phongDao.LayDuLieu();
        }

        public DataTable LayLoaiTinhTrang()
        {
            return phongDao.LayLoaiTinhTrang();
        }

        public DataTable LayLoaiPhong()
        {
            return phongDao.LayLoaiPhong();
        }

        public SqlDataReader CheckMaPhong(string maphong)
        {
            return phongDao.CheckMaPhong(maphong);
        }

        public void ThemPhong(PhongDTO phong)
        {
            phongDao.ThemPhong(phong);
        }

        public void SuaPhong(PhongDTO phong)
        {
            phongDao.SuaPhong(phong);
        }

        public void XoaPhong(string maphong)
        {
            phongDao.XoaPhong(maphong);
        }
    }
}
