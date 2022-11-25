using DevExpress.Utils.Drawing.Helpers;
using QuanLyKhachSan._2._1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan._2._1.DAO
{
    public class KhachHangDAO
    {
        DataService db = new DataService();
        public DataTable LayDuLieu()
        {
            String sql = "select * from KHACH_HANG ";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public SqlDataReader CheckMaKH(string makh)
        {
            String sql = "Select MaKhachHang from KHACH_HANG where MaKhachHang ='" + makh + "'";
            return db.getDataReader(sql);
        }

        public void ThemKhachHang(KH kh)
        {
            string sql = "insert into KHACH_HANG(MaKhachHang,TenKhachHang,CMND,GioiTinh ,DiaChi,DienThoai ,QuocTich) values ('" + kh.id + "',N'" + kh.hoten + "','" + kh.cmnd + "',N'" + kh.gioitinh + "',N'" + kh.diachi + "','" + kh.dienthoai + "',N'" + kh.quoctich + "')";
            db.executeQuery(sql);
        }

        public void SuaKhachHang(KH kh)
        {
            string sql = "update KHACH_HANG set  TenKhachHang=N'" + kh.hoten + "', CMND='" + kh.cmnd + "',DiaChi=N'" + kh.diachi + "' , DienThoai='" + kh.dienthoai + "',QuocTich=N'" + kh.quoctich + "',GioiTinh=N'" + kh.gioitinh + "' where MaKhachHang='" + kh.id + "'";
            db.executeQuery(sql);
        }

        public void XoaKhachHang(KH kh)
        {
            String sql = "delete KHACH_HANG where MaKhachHang='" + kh.id + "'";
            db.executeQuery(sql);
        }
    }
}
