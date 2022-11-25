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
    internal class PhongDAO
    {
        DataService db = new DataService();

        public DataTable LayDuLieu()
        {
            String sql = "select p.MaPhong,tr.TenLoaiTinhTrang,lp.TenLoaiPhong,lp.DonGia,lp.SoNguoiChuan,lp.SoNguoiToiDa from PHONG p, LOAI_TINH_TRANG tr,LOAI_PHONG lp where p.MaLoaiTinhTrangPhong = tr.MaLoaiTinhTrangPhong and p.MaLoaiPhong = lp.MaLoaiPhong";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public DataTable LayLoaiTinhTrang()
        {
            String sql = "select * from LOAI_TINH_TRANG tr";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public DataTable LayLoaiPhong()
        {
            String sql = "select lp.MaLoaiPhong,lp.TenLoaiPhong,lp.DonGia,lp.SoNguoiChuan,lp.SoNguoiToiDa from LOAI_PHONG lp";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public SqlDataReader CheckMaPhong(string maphong)
        {
            String sql = "Select MaPhong from PHONG where MaPhong ='" + maphong + "'";
            return db.getDataReader(sql);
        }

        public void ThemPhong(PhongDTO phong)
        {
            string sql = "insert into PHONG(MaPhong,MaLoaiPhong,MaLoaiTinhTrangPhong) values ('" + phong.MaPhong + "','" + phong.MaLoaiPhong + "','" + phong.MaLoaiTinhTrangPhong + "')";
            db.executeQuery(sql);
        }

        public void SuaPhong(PhongDTO phong)
        {
            string sql = "update PHONG set MaLoaiPhong=N'" + phong.MaLoaiPhong + "', MaLoaiTinhTrangPhong='" + phong.MaLoaiTinhTrangPhong + "' where MaPhong='" + phong.MaPhong + "'";
            db.executeQuery(sql);
        }

        public void XoaPhong(string maphong)
        {
            String sql = "delete PHONG where MaPhong='" + maphong + "' ";
            db.executeQuery(sql);
        }
    }
}
