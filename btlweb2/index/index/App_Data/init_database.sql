USE [master]
GO
/****** Object:  Database [webqlbandt]    Script Date: 12/8/2024 7:14:16 PM ******/
CREATE DATABASE [webqlbandt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'webqlbandt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\webqlbandt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'webqlbandt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\webqlbandt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [webqlbandt] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [webqlbandt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [webqlbandt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [webqlbandt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [webqlbandt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [webqlbandt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [webqlbandt] SET ARITHABORT OFF 
GO
ALTER DATABASE [webqlbandt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [webqlbandt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [webqlbandt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [webqlbandt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [webqlbandt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [webqlbandt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [webqlbandt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [webqlbandt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [webqlbandt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [webqlbandt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [webqlbandt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [webqlbandt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [webqlbandt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [webqlbandt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [webqlbandt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [webqlbandt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [webqlbandt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [webqlbandt] SET RECOVERY FULL 
GO
ALTER DATABASE [webqlbandt] SET  MULTI_USER 
GO
ALTER DATABASE [webqlbandt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [webqlbandt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [webqlbandt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [webqlbandt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [webqlbandt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [webqlbandt] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'webqlbandt', N'ON'
GO
ALTER DATABASE [webqlbandt] SET QUERY_STORE = ON
GO
ALTER DATABASE [webqlbandt] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [webqlbandt]
GO
/****** Object:  Table [dbo].[tbl_giohang]    Script Date: 12/8/2024 7:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_giohang](
	[MaSP] [char](6) NULL,
	[TenSP] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[BoNho] [int] NULL,
	[GiaTien] [float] NULL,
	[TongTien] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sanpham]    Script Date: 12/8/2024 7:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sanpham](
	[MaSP] [char](6) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[TenHang] [nvarchar](50) NULL,
	[NgayPhatHanh] [datetime] NULL,
	[KichThuocMan] [nvarchar](20) NULL,
	[Chip] [nvarchar](10) NULL,
	[Ram] [nvarchar](15) NULL,
	[BoNho] [nvarchar](15) NULL,
	[DungLuongPin] [nchar](30) NULL,
	[HeDieuHanh] [nchar](30) NULL,
	[TrongLuong] [nchar](20) NULL,
	[GiaNhap] [nvarchar](100) NULL,
	[GiaBan] [nvarchar](100) NULL,
	[MauSac] [nvarchar](20) NULL,
	[MoTa] [nvarchar](300) NULL,
	[HinhAnh1] [nvarchar](100) NULL,
	[HinhAnh2] [nvarchar](100) NULL,
	[HinhAnh3] [nvarchar](100) NULL,
 CONSTRAINT [PK_tbl_sanpham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_taikhoan]    Script Date: 12/8/2024 7:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_taikhoan](
	[TaiKhoan] [nchar](10) NOT NULL,
	[MatKhau] [nvarchar](100) NULL,
	[VaiTro] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[MaXacNhan] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_taikhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[dp_suasanpham]    Script Date: 12/8/2024 7:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[dp_suasanpham]
	@ma char(6),
	@ten nvarchar(50),
	@hang nvarchar(50),
	@ngayph datetime,
	@kichthuoc nvarchar(20),
	@chip nvarchar(10),
	@ram nvarchar(15),@rom nvarchar(15),@pin nchar(30),@hedieuhanh nchar(30),@trongluong nchar(20),@gianhap nvarchar(100),@giaban nvarchar(100),
	@mausac nvarchar(20),
	@mota nvarchar(300),
	@anh1 nvarchar(100),
	@anh2 nvarchar(100),
	@anh3 nvarchar(100)
AS
BEGIN
	UPDATE tbl_sanpham
		SET 
			TenSP = @ten,
			TenHang = @hang,
			NgayPhatHanh = @ngayph,
			KichThuocMan = @kichthuoc,
			Chip = @chip,
			RAM = @ram,
			BoNho = @rom,
			DungLuongPin = @pin,
			HeDieuHanh = @hedieuhanh,
			TrongLuong = @trongluong,
			GiaNhap = @gianhap,
			GiaBan = @giaban,
			MauSac = @mausac,
			MoTa = @mota,
			HinhAnh1 = @anh1,
			HinhAnh2 = @anh2,
			HinhAnh3 = @anh3
		WHERE MaSP = @ma;
END
GO
/****** Object:  StoredProcedure [dbo].[dp_themsanpham]    Script Date: 12/8/2024 7:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[dp_themsanpham]
	@ma char(6),
	@ten nvarchar(50),
	@hang nvarchar(50),
	@ngayph datetime,
	@kichthuoc float,
	@chip nvarchar(10),
	@ram int,@rom int,@pin nchar(30),@hedieuhanh nchar(30),@trongluong nchar(20),@gianhap float,@giaban float,
	@mausac nvarchar(20),
	@mota nvarchar(300),
	@anh1 nvarchar(100),
	@anh2 nvarchar(100),
	@anh3 nvarchar(100)
AS
BEGIN
	insert into tbl_sanpham values(@ma,@ten,@hang,@ngayph,@kichthuoc,@chip,@ram,@rom,@pin,@hedieuhanh,@trongluong,@gianhap,@giaban,@mausac,@mota,@anh1,@anh2,@anh3)
END
GO
USE [master]
GO
ALTER DATABASE [webqlbandt] SET  READ_WRITE 
GO
