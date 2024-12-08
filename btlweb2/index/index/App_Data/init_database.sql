USE [master];
-- Tạo database
CREATE DATABASE [webqlbandt]
CONTAINMENT = NONE
ON PRIMARY 
(
    NAME = N'webqlbandt', 
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\webqlbandt.mdf', 
    SIZE = 8192KB, 
    MAXSIZE = UNLIMITED, 
    FILEGROWTH = 64MB
)
LOG ON 
(
    NAME = N'webqlbandt_log', 
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\webqlbandt_log.ldf', 
    SIZE = 8192KB, 
    MAXSIZE = 2048GB, 
    FILEGROWTH = 64MB
)
WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF;

-- Chuyển database sang chế độ tương thích
ALTER DATABASE [webqlbandt] SET COMPATIBILITY_LEVEL = 160;

-- Bật tính năng Full-Text nếu được hỗ trợ
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
    EXEC [webqlbandt].[dbo].[sp_fulltext_database] @action = 'enable';
END;

-- Thiết lập thông số cho database
ALTER DATABASE [webqlbandt] SET AUTO_CLOSE OFF;
ALTER DATABASE [webqlbandt] SET AUTO_SHRINK OFF;
ALTER DATABASE [webqlbandt] SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE [webqlbandt] SET RECOVERY FULL;
ALTER DATABASE [webqlbandt] SET MULTI_USER;
ALTER DATABASE [webqlbandt] SET PAGE_VERIFY CHECKSUM;

-- Sử dụng database
USE [webqlbandt];

-- Tạo bảng tbl_giohang
CREATE TABLE [dbo].[tbl_giohang](
    MaGH INT PRIMARY KEY,
    MaSP CHAR(6) NOT NULL,
    SoLuong INT NULL,
    BoNho INT NULL,
    GiaTien DECIMAL(18, 2) NULL,
    TongTien DECIMAL(18, 2) NULL
);

-- Tạo bảng tbl_sanpham
CREATE TABLE [dbo].[tbl_sanpham](
    MaSP CHAR(6) NOT NULL PRIMARY KEY,
    TenSP NVARCHAR(50) NULL,
    TenHang NVARCHAR(50) NULL,
    NgayPhatHanh DATETIME NULL,
    KichThuocMan DECIMAL(4, 1) NULL,
    Chip NVARCHAR(10) NULL,
    RAM INT NULL,
    BoNho INT NULL,
    DungLuongPin NVARCHAR(30) NULL,
    HeDieuHanh NVARCHAR(30) NULL,
    TrongLuong NVARCHAR(20) NULL,
    GiaNhap DECIMAL(18, 2) NULL,
    GiaBan DECIMAL(18, 2) NULL,
    MauSac NVARCHAR(20) NULL,
    MoTa NVARCHAR(300) NULL,
    HinhAnh1 NVARCHAR(100) NULL,
    HinhAnh2 NVARCHAR(100) NULL,
    HinhAnh3 NVARCHAR(100) NULL
);

-- Tạo bảng tbl_taikhoan
CREATE TABLE [dbo].[tbl_taikhoan](
    TaiKhoan NVARCHAR(50) NOT NULL PRIMARY KEY,
    MatKhau NVARCHAR(50) NOT NULL,
    VaiTro INT NULL,
    Email NVARCHAR(100) NULL,
    MaXacNhan NVARCHAR(MAX) NULL
);

-- Tạo stored procedure dp_suasanpham


-- Tạo stored procedure dp_themsanpham


-- Chuyển database sang chế độ đọc-ghi
ALTER DATABASE [webqlbandt] SET READ_WRITE;
