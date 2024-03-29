USE [master]
GO
/****** Object:  Database [DMarysDB]    Script Date: 11/01/2012 09:29:29 ******/
CREATE DATABASE [DMarysDB] ON  PRIMARY 
( NAME = N'DMarysDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup\DMarysDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DMarysDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup\DMarysDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DMarysDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DMarysDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DMarysDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DMarysDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DMarysDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DMarysDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DMarysDB] SET ARITHABORT OFF
GO
ALTER DATABASE [DMarysDB] SET AUTO_CLOSE ON
GO
ALTER DATABASE [DMarysDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DMarysDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DMarysDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DMarysDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DMarysDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DMarysDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DMarysDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DMarysDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DMarysDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DMarysDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [DMarysDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DMarysDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DMarysDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DMarysDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DMarysDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DMarysDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DMarysDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DMarysDB] SET  READ_WRITE
GO
ALTER DATABASE [DMarysDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DMarysDB] SET  MULTI_USER
GO
ALTER DATABASE [DMarysDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DMarysDB] SET DB_CHAINING OFF
GO
USE [DMarysDB]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 11/01/2012 09:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ventas](
	[cliente] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NULL,
	[sucursal] [varchar](50) NULL,
	[fecha] [datetime] NULL,
	[idVenta] [int] NULL,
	[subtotal] [float] NULL,
	[iva] [float] NULL,
	[total] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VentaProducto]    Script Date: 11/01/2012 09:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentaProducto](
	[idVentaProducto] [int] NOT NULL,
	[idVenta] [int] NULL,
	[idProducto] [int] NULL,
	[cantidad] [int] NULL,
	[productoVendido] [varchar](50) NULL,
	[importe] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/01/2012 09:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](100) NULL,
	[sexo] [varchar](20) NULL,
	[telefono] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 11/01/2012 09:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedores](
	[idProveedor] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[codigoProducto] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/01/2012 09:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[codigo] [varchar](50) NOT NULL,
	[cantidad] [int] NULL,
	[talla] [varchar](50) NULL,
	[modelo] [varchar](50) NULL,
	[color] [varchar](20) NULL,
	[marca] [varchar](50) NULL,
	[estilo] [varchar](50) NULL,
	[tipoProducto] [varchar](50) NULL,
	[precio] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeterminarCredito]    Script Date: 11/01/2012 09:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeterminarCredito](
	[idDeterminarCredito] [int] NOT NULL,
	[idCredito] [int] NULL,
	[abono] [float] NULL,
	[fecha] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Creditos]    Script Date: 11/01/2012 09:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Creditos](
	[usuario] [varchar](50) NOT NULL,
	[cliente] [varchar](50) NULL,
	[montoInicial] [float] NULL,
	[intereses] [float] NULL,
	[idCredito] [int] NULL,
	[montoActual] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
