USE [master]
GO
/****** Object:  Database [RFID]    Script Date: 2020/12/6 14:12:52 ******/
CREATE DATABASE [RFID]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RFID', FILENAME = N'E:\RFID\RI\RFID.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RFID_log', FILENAME = N'E:\RFID\RI\RFID_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [RFID] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RFID', N'ON'
GO
ALTER DATABASE [RFID] SET QUERY_STORE = OFF
GO
USE [RFID]
GO
/****** Object:  Table [dbo].[Area_divide_table]    Script Date: 2020/12/6 14:12:53 ******/
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
/****** Object:  Table [dbo].[Area_statistic_table]    Script Date: 2020/12/6 14:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area_statistic_table](
	[Areaname] [varchar](10) NOT NULL,
	[Id] [varchar](12) NOT NULL,
	[Date] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Area_statistic_table] PRIMARY KEY CLUSTERED 
(
	[Areaname] ASC,
	[Id] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_table]    Script Date: 2020/12/6 14:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_table](
	[IdOfOrder] [varchar](13) NOT NULL,
	[Orderdate] [varchar](30) NOT NULL,
	[Id] [varchar](20) NOT NULL,
	[Date] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Order_table] PRIMARY KEY CLUSTERED 
(
	[IdOfOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_statistic_table]    Script Date: 2020/12/6 14:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_statistic_table](
	[IdOfPayment] [varchar](15) NOT NULL,
	[Id] [varchar](12) NOT NULL,
	[TimeOfPay] [varchar](30) NOT NULL,
	[Areaname] [varchar](30) NOT NULL,
	[Payment] [int] NOT NULL,
 CONSTRAINT [PK_Payment_statistic_table] PRIMARY KEY CLUSTERED 
(
	[IdOfPayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_table]    Script Date: 2020/12/6 14:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_table](
	[Id] [varchar](20) NOT NULL,
	[Flag] [bit] NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Sex] [bit] NOT NULL,
	[Role] [varchar](10) NOT NULL,
	[Money] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Idnumber] [varchar](50) NOT NULL,
	[Card] [varchar](50) NULL,
 CONSTRAINT [PK_User_table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Area_divide_table] ([Areaname], [Role], [Rage], [Opentime]) VALUES (N'欢乐海洋', N'1', 0, N'10001800')
INSERT [dbo].[Area_divide_table] ([Areaname], [Role], [Rage], [Opentime]) VALUES (N'欢乐江城', N'1', 0, N'10001800')
INSERT [dbo].[Area_divide_table] ([Areaname], [Role], [Rage], [Opentime]) VALUES (N'欢乐时光', N'1', 0, N'10001800')
INSERT [dbo].[Area_divide_table] ([Areaname], [Role], [Rage], [Opentime]) VALUES (N'极速世界', N'1', 0, N'10001800')
INSERT [dbo].[Area_divide_table] ([Areaname], [Role], [Rage], [Opentime]) VALUES (N'飓风湾', N'1', 0, N'10001800')
INSERT [dbo].[Area_divide_table] ([Areaname], [Role], [Rage], [Opentime]) VALUES (N'渔光岛', N'0', 0, N'10001800')
INSERT [dbo].[Area_divide_table] ([Areaname], [Role], [Rage], [Opentime]) VALUES (N'羽落天堂', N'1', 0, N'10001800')
GO
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-05:29:25')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:17:13')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:19:59')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:21:42')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:23:34')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:23:39')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:23:40')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:23:41')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:29:33')
INSERT [dbo].[Area_statistic_table] ([Areaname], [Id], [Date]) VALUES (N'渔光岛', N'0', N'2020-12-05-21:58:32')
GO
INSERT [dbo].[Order_table] ([IdOfOrder], [Orderdate], [Id], [Date]) VALUES (N'Y202012050000', N'2020-12-18', N'0', N'2020-12-05-09-04-42')
INSERT [dbo].[Order_table] ([IdOfOrder], [Orderdate], [Id], [Date]) VALUES (N'Y202012050002', N'2020-12-17', N'0', N'2020-12-05-21:15:44')
GO
INSERT [dbo].[Payment_statistic_table] ([IdOfPayment], [Id], [TimeOfPay], [Areaname], [Payment]) VALUES (N'P20201205000000', N'0', N'2020-12-05-07-20-47', N'所有区域', 0)
INSERT [dbo].[Payment_statistic_table] ([IdOfPayment], [Id], [TimeOfPay], [Areaname], [Payment]) VALUES (N'P20201205000001', N'0', N'2020-12-05-09-38-41', N'所有区域', -50)
GO
INSERT [dbo].[User_table] ([Id], [Flag], [Password], [Sex], [Role], [Money], [Name], [Idnumber], [Card]) VALUES (N'0', 1, N'0', 0, N'0', 0, N'管理', N'2135', N'0002493193')
INSERT [dbo].[User_table] ([Id], [Flag], [Password], [Sex], [Role], [Money], [Name], [Idnumber], [Card]) VALUES (N'1', 1, N'1', 1, N'1', 1, N'张三', N'1', NULL)
INSERT [dbo].[User_table] ([Id], [Flag], [Password], [Sex], [Role], [Money], [Name], [Idnumber], [Card]) VALUES (N'202012050001', 0, N'1', 0, N'1', 50, N'1', N'1', N'0002493193')
GO
USE [master]
GO
ALTER DATABASE [RFID] SET  READ_WRITE 
GO
