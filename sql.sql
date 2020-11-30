USE [master]
GO
/****** Object:  Database [RFID]    Script Date: 2020/11/28 16:13:58 ******/
CREATE DATABASE [RFID]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RFID', FILENAME = N'D:\SQLserver\MSSQL15.MSSQLSERVER\MSSQL\DATA\RFID.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RFID_log', FILENAME = N'D:\SQLserver\MSSQL15.MSSQLSERVER\MSSQL\DATA\RFID_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RFID] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RFID].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RFID] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RFID] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RFID] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RFID] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RFID] SET ARITHABORT OFF 
GO
ALTER DATABASE [RFID] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RFID] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RFID] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RFID] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RFID] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RFID] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RFID] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RFID] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RFID] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RFID] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RFID] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RFID] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RFID] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RFID] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RFID] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RFID] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RFID] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RFID] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RFID] SET  MULTI_USER 
GO
ALTER DATABASE [RFID] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RFID] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RFID] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RFID] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RFID] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RFID] SET QUERY_STORE = OFF
GO
USE [RFID]
GO
/****** Object:  Table [dbo].[Area_divide_table]    Script Date: 2020/11/28 16:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area_divide_table](
	[Areaname] [varchar](10) NOT NULL,
	[Role] [varchar](10) NOT NULL,
	[Rage] [int] NOT NULL,
	[Opentime] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Area_divide_table] PRIMARY KEY CLUSTERED 
(
	[Areaname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area_statistic_table]    Script Date: 2020/11/28 16:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area_statistic_table](
	[Areaname] [varchar](10) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Date] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Area_statistic_table] PRIMARY KEY CLUSTERED 
(
	[Areaname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_table]    Script Date: 2020/11/28 16:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_table](
	[Id] [bigint] NOT NULL,
	[Orderdate] [varchar](10) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Idnumber] [bigint] NOT NULL,
 CONSTRAINT [PK_Order_table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_statistic_table]    Script Date: 2020/11/28 16:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_statistic_table](
	[IdOfPayment] [int] NOT NULL,
	[Id] [bigint] NOT NULL,
	[TimeOfPay] [varchar](10) NOT NULL,
	[Areaname] [varchar](10) NOT NULL,
	[Payment] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Payment_statistic_table] PRIMARY KEY CLUSTERED 
(
	[IdOfPayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_table]    Script Date: 2020/11/28 16:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_table](
	[Id] [bigint] NOT NULL,
	[Flag] [int] NOT NULL,
	[Password] [varchar](10) NOT NULL,
	[Sex] [varchar](10) NOT NULL,
	[Role] [varchar](10) NOT NULL,
	[Money] [int] NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Idnumber] [bigint] NOT NULL,
 CONSTRAINT [PK_User_table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [RFID] SET  READ_WRITE 
GO
