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
    internal class NhanPhongDAO
    {
        DataService db = new DataService();

        public DataTable LayDuLieu()
        {
            String sql = "select PT.MaNhanPhong,KH.TenKhachHang,KH.CMND,KH.DiaChi,KH.DienThoai,P.MaPhong,CTPT.NgayNhan  from KHACH_HANG KH,PHIEU_NHAN_PHONG PT,PHONG P,CHI_TIET_PHIEU_NHAN_PHONG CTPT where KH.MaKhachHang=PT.MaKhachHang and CTPT.MaPhong=P.MaPhong AND CTPT.MaNhanPhong=PT.MaNhanPhong ";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public DataTable LayDSTenKhachHang()
        {
            String sql = "select [MaKhachHang],TenKhachHang from [KHACH_HANG]";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public DataTable LayDSPhong(string makh)
        {
            String sql = "select ctptp.MaPhong from CHI_TIET_PHIEU_THUE_PHONG ctptp,PHIEU_THUE_PHONG ptp,KHACH_HANG kh where ctptp.MaPhieuThue=ptp.MaPhieuThue and ptp.MaKhachHang=kh.MaKhachHang and kh.MaKhachHang='" + makh + "'";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public DataTable LayDSPhieuThue(string makh)
        {
            String sql = "SELECT PHIEU_THUE_PHONG.MaPhieuThue,PHIEU_THUE_PHONG.MaKhachHang FROM PHIEU_THUE_PHONG WHERE  PHIEU_THUE_PHONG.MaKhachHang = '" + makh + "'";
            DataTable dt = db.getDataTable(sql);
            return dt;
        }

        public SqlDataReader CheckMaNhanPhong(string manhanphong)
        {
            String sql = "Select MaNhanPhong from PHIEU_NHAN_PHONG where MaNhanPhong ='" + manhanphong + "'";
            return db.getDataReader(sql);
        }

        public void ThemPhong(PhieuNhanPhong pnp, ChiTietPhieuNhanPhong ctpnp)
        {
            String sql, sql2, sql3;
            sql = "insert into PHIEU_NHAN_PHONG(MaNhanPhong,MaKhachHang,MaPhieuThue) values ('" + pnp.MaNhanPhong + "','" + pnp.MaKhachHang + "','" + pnp.MaPhieuthue + "')";
            sql2 = "insert into CHI_TIET_PHIEU_NHAN_PHONG(MaNhanPhong,MaPhong,NgayNhan) values ('" + ctpnp.MaNhanPhong + "','" + ctpnp.MaPhong + "','" + ctpnp.NgayNhan + "')";
            sql3 = "update PHONG set  MaLoaiTinhTrangPhong=N'3' where MaPhong='" + ctpnp.MaPhong + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql2);
            db.executeQuery(sql3);
        }

        public void SuaPhong(PhieuNhanPhong pnp, ChiTietPhieuNhanPhong ctpnp)
        {
            String sql, sql2;
            sql = "update PHIEU_NHAN_PHONG set  MaKhachHang=N'" + pnp.MaKhachHang + "' where MaNhanPhong='" + pnp.MaNhanPhong + "'";
            sql2 = "update CHI_TIET_PHIEU_NHAN_PHONG set  MaPhong='" + ctpnp.MaPhong + "',NgayNhan='" + ctpnp.NgayNhan + "'  where MaNhanPhong='" + ctpnp.MaNhanPhong + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql2);
        }

        public void XoaPhong(string manp, string maphong)
        {
            String sql, sql1;
            sql = "delete PHIEU_NHAN_PHONG where MaNhanPhong='" + manp + "'";
            sql1 = "delete CHI_TIET_PHIEU_NHAN_PHONG where MaNhanPhong='" + manp + "' and MaPhong='" + maphong + "'";
            DataService db = new DataService();
            db.executeQuery(sql);
            db.executeQuery(sql1);
        }
    }
}
