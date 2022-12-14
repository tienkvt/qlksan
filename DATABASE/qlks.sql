USE [master]
GO
/****** Object:  Database [QLKS]    Script Date: 11/15/2022 8:36:40 PM ******/
CREATE DATABASE [QLKS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\QLKS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLKS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\QLKS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLKS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKS] SET RECOVERY FULL 
GO
ALTER DATABASE [QLKS] SET  MULTI_USER 
GO
ALTER DATABASE [QLKS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLKS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLKS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLKS', N'ON'
GO
ALTER DATABASE [QLKS] SET QUERY_STORE = OFF
GO
USE [QLKS]
GO
/****** Object:  Table [dbo].[CHI_TIET_HOA_DON]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHI_TIET_HOA_DON](
	[MaHoaDon] [nvarchar](50) NOT NULL,
	[MaPhong] [nvarchar](50) NOT NULL,
	[PhuThu] [float] NULL,
	[TienPhong] [float] NULL,
	[TienDichVu] [float] NULL,
	[GiamGiaKH] [float] NULL,
	[HinhThucThanhToan] [nvarchar](50) NULL,
	[SoNgay] [int] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CHI_TIET_HOA_DON_1] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHI_TIET_PHIEU_NHAN_PHONG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHI_TIET_PHIEU_NHAN_PHONG](
	[MaNhanPhong] [nvarchar](50) NOT NULL,
	[MaPhong] [nvarchar](50) NOT NULL,
	[NgayNhan] [datetime] NULL,
	[NgayTra] [datetime] NULL,
 CONSTRAINT [PK_CHI_TIET_PHIEU_NHAN_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaNhanPhong] ASC,
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHI_TIET_PHIEU_THUE_PHONG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHI_TIET_PHIEU_THUE_PHONG](
	[MaPhieuThue] [nvarchar](50) NOT NULL,
	[MaPhong] [nvarchar](50) NOT NULL,
	[NgayDangKy] [datetime] NULL,
	[NgayNhan] [datetime] NULL,
 CONSTRAINT [PK_CHI_TIET_PHIEU_THUE_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaPhieuThue] ASC,
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHINH_SACH_TRA_PHONG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHINH_SACH_TRA_PHONG](
	[MaChinhSach] [nvarchar](50) NOT NULL,
	[ThoiGianQuyDinh] [int] NULL,
	[PhuThu] [float] NULL,
 CONSTRAINT [PK_CHINH_SACH_TRA_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaChinhSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DANH_SACH_SU_DUNG_DICH_VU]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANH_SACH_SU_DUNG_DICH_VU](
	[MaSuDungDvu] [nvarchar](50) NOT NULL,
	[MaDichVu] [nvarchar](50) NULL,
	[MaPhieuThue] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_DANH_SACH_SU_DUNG_DICH_VU] PRIMARY KEY CLUSTERED 
(
	[MaSuDungDvu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DICH_VU]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DICH_VU](
	[MaDichVu] [nvarchar](50) NOT NULL,
	[LoaiDichVu] [nvarchar](50) NULL,
	[DonVi] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
 CONSTRAINT [PK_DICH_VU] PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOA_DON]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOA_DON](
	[MaHoaDon] [nvarchar](50) NOT NULL,
	[NhanVienLap] [nvarchar](50) NULL,
	[TongTien] [float] NULL,
	[NgayLap] [datetime] NULL,
	[MaNhanPhong] [nvarchar](50) NULL,
 CONSTRAINT [PK_HOA_DON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[MaKhachHang] [nvarchar](50) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[CMND] [nvarchar](10) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[DienThoai] [nvarchar](10) NULL,
	[QuocTich] [nvarchar](50) NULL,
 CONSTRAINT [PK_KHACH_HANG] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAI_NGUOI_DUNG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_NGUOI_DUNG](
	[LoaiNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNguoiDung] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAI_NGUOI_DUNG] PRIMARY KEY CLUSTERED 
(
	[LoaiNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAI_PHONG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_PHONG](
	[MaLoaiPhong] [nvarchar](50) NOT NULL,
	[TenLoaiPhong] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[SoNguoiChuan] [int] NULL,
	[SoNguoiToiDa] [int] NULL,
 CONSTRAINT [PK_LOAI_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAI_TINH_TRANG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_TINH_TRANG](
	[MaLoaiTinhTrangPhong] [nvarchar](50) NOT NULL,
	[TenLoaiTinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAI_TINH_TRANG] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTinhTrangPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGUOI_DUNG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOI_DUNG](
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[LoaiNguoiDung] [int] NULL,
 CONSTRAINT [PK_NGUOI_DUNG] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEU_NHAN_PHONG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEU_NHAN_PHONG](
	[MaNhanPhong] [nvarchar](50) NOT NULL,
	[MaPhieuThue] [nvarchar](50) NULL,
	[MaKhachHang] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHIEU_NHAN_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaNhanPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEU_THUE_PHONG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEU_THUE_PHONG](
	[MaPhieuThue] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHIEU_THUE_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaPhieuThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[MaPhong] [nvarchar](50) NOT NULL,
	[MaLoaiPhong] [nvarchar](50) NULL,
	[MaLoaiTinhTrangPhong] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHONG] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THIET_BI]    Script Date: 11/15/2022 8:36:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THIET_BI](
	[MaThietBi] [nvarchar](50) NOT NULL,
	[TenThietBi] [nvarchar](50) NULL,
	[MaLoaiPhong] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_THIET_BI] PRIMARY KEY CLUSTERED 
(
	[MaThietBi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHI_TIET_HOA_DON]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_HOA_DON_HOA_DON] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HOA_DON] ([MaHoaDon])
GO
ALTER TABLE [dbo].[CHI_TIET_HOA_DON] CHECK CONSTRAINT [FK_CHI_TIET_HOA_DON_HOA_DON]
GO
ALTER TABLE [dbo].[CHI_TIET_HOA_DON]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_HOA_DON_PHONG] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[CHI_TIET_HOA_DON] CHECK CONSTRAINT [FK_CHI_TIET_HOA_DON_PHONG]
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_NHAN_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_PHIEU_NHAN_PHONG_PHIEU_NHAN_PHONG] FOREIGN KEY([MaNhanPhong])
REFERENCES [dbo].[PHIEU_NHAN_PHONG] ([MaNhanPhong])
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_NHAN_PHONG] CHECK CONSTRAINT [FK_CHI_TIET_PHIEU_NHAN_PHONG_PHIEU_NHAN_PHONG]
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_NHAN_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_PHIEU_NHAN_PHONG_PHONG] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_NHAN_PHONG] CHECK CONSTRAINT [FK_CHI_TIET_PHIEU_NHAN_PHONG_PHONG]
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_THUE_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_PHIEU_THUE_PHONG_PHIEU_THUE_PHONG] FOREIGN KEY([MaPhieuThue])
REFERENCES [dbo].[PHIEU_THUE_PHONG] ([MaPhieuThue])
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_THUE_PHONG] CHECK CONSTRAINT [FK_CHI_TIET_PHIEU_THUE_PHONG_PHIEU_THUE_PHONG]
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_THUE_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_PHIEU_THUE_PHONG_PHONG] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[CHI_TIET_PHIEU_THUE_PHONG] CHECK CONSTRAINT [FK_CHI_TIET_PHIEU_THUE_PHONG_PHONG]
GO
ALTER TABLE [dbo].[DANH_SACH_SU_DUNG_DICH_VU]  WITH CHECK ADD  CONSTRAINT [FK_DANH_SACH_SU_DUNG_DICH_VU_DICH_VU] FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DICH_VU] ([MaDichVu])
GO
ALTER TABLE [dbo].[DANH_SACH_SU_DUNG_DICH_VU] CHECK CONSTRAINT [FK_DANH_SACH_SU_DUNG_DICH_VU_DICH_VU]
GO
ALTER TABLE [dbo].[HOA_DON]  WITH CHECK ADD  CONSTRAINT [FK_HOA_DON_PHIEU_NHAN_PHONG] FOREIGN KEY([MaNhanPhong])
REFERENCES [dbo].[PHIEU_NHAN_PHONG] ([MaNhanPhong])
GO
ALTER TABLE [dbo].[HOA_DON] CHECK CONSTRAINT [FK_HOA_DON_PHIEU_NHAN_PHONG]
GO
ALTER TABLE [dbo].[NGUOI_DUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOI_DUNG_LOAI_NGUOI_DUNG] FOREIGN KEY([LoaiNguoiDung])
REFERENCES [dbo].[LOAI_NGUOI_DUNG] ([LoaiNguoiDung])
GO
ALTER TABLE [dbo].[NGUOI_DUNG] CHECK CONSTRAINT [FK_NGUOI_DUNG_LOAI_NGUOI_DUNG]
GO
ALTER TABLE [dbo].[PHIEU_NHAN_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU_NHAN_PHONG_KHACH_HANG] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACH_HANG] ([MaKhachHang])
GO
ALTER TABLE [dbo].[PHIEU_NHAN_PHONG] CHECK CONSTRAINT [FK_PHIEU_NHAN_PHONG_KHACH_HANG]
GO
ALTER TABLE [dbo].[PHIEU_NHAN_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU_NHAN_PHONG_PHIEU_THUE_PHONG] FOREIGN KEY([MaPhieuThue])
REFERENCES [dbo].[PHIEU_THUE_PHONG] ([MaPhieuThue])
GO
ALTER TABLE [dbo].[PHIEU_NHAN_PHONG] CHECK CONSTRAINT [FK_PHIEU_NHAN_PHONG_PHIEU_THUE_PHONG]
GO
ALTER TABLE [dbo].[PHIEU_THUE_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU_THUE_PHONG_KHACH_HANG] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACH_HANG] ([MaKhachHang])
GO
ALTER TABLE [dbo].[PHIEU_THUE_PHONG] CHECK CONSTRAINT [FK_PHIEU_THUE_PHONG_KHACH_HANG]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_LOAI_PHONG] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LOAI_PHONG] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_LOAI_PHONG]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_LOAI_TINH_TRANG] FOREIGN KEY([MaLoaiTinhTrangPhong])
REFERENCES [dbo].[LOAI_TINH_TRANG] ([MaLoaiTinhTrangPhong])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_LOAI_TINH_TRANG]
GO
ALTER TABLE [dbo].[THIET_BI]  WITH CHECK ADD  CONSTRAINT [FK_THIET_BI_LOAI_PHONG] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LOAI_PHONG] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[THIET_BI] CHECK CONSTRAINT [FK_THIET_BI_LOAI_PHONG]
GO
USE [master]
GO
ALTER DATABASE [QLKS] SET  READ_WRITE 
GO
