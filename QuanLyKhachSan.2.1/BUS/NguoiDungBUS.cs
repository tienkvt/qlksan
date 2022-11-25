using QuanLyKhachSan._2._1.DAO;
using QuanLyKhachSan._2._1.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan._2._1.BUS
{
    internal class NguoiDungBUS
    {
        NguoiDungDAO ndDao = new NguoiDungDAO();
        public SqlDataReader layTenDangNhap(NguoiDung nd)
        {
            return ndDao.layTenDangNhap(nd);
        }

        public SqlDataReader layMatKhau(NguoiDung nd)
        {
            return ndDao.layMatKhau(nd);
        }

        public SqlDataReader layLoaiNguoiDung(NguoiDung nd)
        {
            return ndDao.layLoaiNguoiDung(nd);
        }
    }
}
