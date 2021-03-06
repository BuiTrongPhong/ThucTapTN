USE [master]
GO
/****** Object:  Database [PhongShop]    Script Date: 3/13/2021 5:06:21 PM ******/
CREATE DATABASE [PhongShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhongShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PhongShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PhongShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PhongShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PhongShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhongShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhongShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhongShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhongShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhongShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhongShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhongShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhongShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhongShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhongShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhongShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhongShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhongShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhongShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhongShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhongShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhongShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhongShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhongShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhongShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhongShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhongShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhongShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhongShop] SET RECOVERY FULL 
GO
ALTER DATABASE [PhongShop] SET  MULTI_USER 
GO
ALTER DATABASE [PhongShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhongShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhongShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhongShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PhongShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PhongShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhongShop', N'ON'
GO
ALTER DATABASE [PhongShop] SET QUERY_STORE = OFF
GO
USE [PhongShop]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 3/13/2021 5:06:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSanPham] [nvarchar](50) NOT NULL,
	[TenLoaiSanPham] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 3/13/2021 5:06:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaNhaSanXuat] [nvarchar](50) NOT NULL,
	[TenNhaSanXuat] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaNhaSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 3/13/2021 5:06:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [nvarchar](50) NOT NULL,
	[MaLoaiSanPham] [nvarchar](50) NULL,
	[MaNhaSanXuat] [nvarchar](50) NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[CauHinh] [text] NULL,
	[HinhChinh] [nvarchar](50) NULL,
	[Hinh1] [nvarchar](50) NULL,
	[Hinh2] [nvarchar](50) NULL,
	[Hinh3] [nvarchar](50) NULL,
	[Gia] [int] NULL,
	[SoLuongDaBan] [int] NULL,
	[LuotView] [int] NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LSP01', N'Cao')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LSP02', N'Trung')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LSP03', N'Thấp')
GO
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat]) VALUES (N'NSX01', N'SamSung')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat]) VALUES (N'NSX02', N'Apple')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat]) VALUES (N'NSX03', N'Oppo')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat]) VALUES (N'NSX04', N'Huawei')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat]) VALUES (N'NSX05', N'Redmi')
GO
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang]) VALUES (N'SP01', N'LSP01', N'NSX01', N'Samsung Galaxy Z Flip ', N'Chua xác d?nh', N'1.png', NULL, NULL, NULL, 30990000, 0, 0, N'0')
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang]) VALUES (N'SP02', N'LSP02', N'NSX02', N'Điện thoại iPhone 12 Pro 256GB

', N'Chua xác d?nh', N'2.png', NULL, NULL, NULL, 30990000, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang]) VALUES (N'SP03', N'LSP03', N'NSX03', N'Điện thoại Samsung Galaxy S21 5G', N'Chua xác d?nh', N'3.png', NULL, NULL, NULL, 30990000, NULL, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang]) VALUES (N'SP04', N'LSP04', N'NSX04', N'Điện thoại Vivo Y12s (3GB/32GB)', N'Chua xác d?nh', N'4.png', NULL, NULL, NULL, 30990000, NULL, NULL, NULL)
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_Gia]  DEFAULT ((0)) FOR [Gia]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_SoLuongDaBan]  DEFAULT ((0)) FOR [SoLuongDaBan]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_LuotView]  DEFAULT ((0)) FOR [LuotView]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
USE [master]
GO
ALTER DATABASE [PhongShop] SET  READ_WRITE 
GO
