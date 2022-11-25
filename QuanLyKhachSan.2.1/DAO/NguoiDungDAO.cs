using QuanLyKhachSan._2._1.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan._2._1.DAO
{
    internal class NguoiDungDAO
    {
        private readonly DataService db = new DataService();

        public SqlDataReader layTenDangNhap(NguoiDung nd)
        {
            String sql = "Select [TenDangNhap] from [NGUOI_DUNG]  where   TenDangNhap ='" + nd.tennd + "'";
            return db.getDataReader(sql);
        }

        public SqlDataReader layMatKhau(NguoiDung nd)
        {
            String sql = "Select [MatKhau] from [NGUOI_DUNG]  where   MatKhau ='" + nd.matkhau + "'";
            return db.getDataReader(sql);
        }

        public SqlDataReader layLoaiNguoiDung(NguoiDung nd)
        {
            String sql = "SELECT [LoaiNguoiDung] FROM [NGUOI_DUNG] where TenDangNhap='" + nd.tennd + "'";
            return db.getDataReader(sql);
        }
    }
}
