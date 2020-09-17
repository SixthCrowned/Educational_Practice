USE [master]
GO
/****** Object:  Database [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF]    Script Date: 17.09.2020 22:34:19 ******/
CREATE DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Database1', FILENAME = N'C:\Users\User\Desktop\Study\Programs\Database Management Software (DMS)\Database1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Database1_log', FILENAME = N'C:\Users\User\Desktop\Study\Programs\Database Management Software (DMS)\Database1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET ARITHABORT OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET  ENABLE_BROKER 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET  MULTI_USER 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET QUERY_STORE = OFF
GO
USE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF]
GO
/****** Object:  Table [dbo].[ИД_Еденицы_Измерения]    Script Date: 17.09.2020 22:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ИД_Еденицы_Измерения](
	[ИД_Еденицы_Измерения] [tinyint] NOT NULL,
	[Название] [char](10) NOT NULL,
	[Краткое_Название] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ИД_Еденицы_Измерения] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ИД_Продукта]    Script Date: 17.09.2020 22:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ИД_Продукта](
	[ИД_Продукта] [int] NOT NULL,
	[Наименование] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ИД_Продукта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Продукты]    Script Date: 17.09.2020 22:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Продукты](
	[Штриховой_Код] [char](10) NULL,
	[ИД_Продукта] [int] NOT NULL,
	[Количество] [char](10) NOT NULL,
	[Цена] [char](10) NOT NULL,
	[ИД_Еденицы_Измерения] [tinyint] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[ИД_Продукта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ИД_Еденицы_Измерения] ([ИД_Еденицы_Измерения], [Название], [Краткое_Название]) VALUES (1, N'Package   ', N'Package   ')
INSERT [dbo].[ИД_Еденицы_Измерения] ([ИД_Еденицы_Измерения], [Название], [Краткое_Название]) VALUES (2, N'Piece     ', N'Piece     ')
INSERT [dbo].[ИД_Еденицы_Измерения] ([ИД_Еденицы_Измерения], [Название], [Краткое_Название]) VALUES (3, N'Kilogram  ', N'Kg        ')
GO
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (1, N'Corn')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (2, N'Candy')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (3, N'Potato')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (4, N'Milk')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (5, N'Jelly')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (6, N'Nuts')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (7, N'Lolipop')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (8, N'Banana')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (9, N'Melon')
INSERT [dbo].[ИД_Продукта] ([ИД_Продукта], [Наименование]) VALUES (10, N'Watermelon')
GO
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 1, N'1         ', N'1         ', 3)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 2, N'1         ', N'1         ', 1)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 3, N'1         ', N'1         ', 3)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 4, N'1         ', N'1         ', 1)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 5, N'1         ', N'1         ', 1)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 6, N'1         ', N'1         ', 3)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 7, N'1         ', N'1         ', 2)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 8, N'1         ', N'1         ', 3)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 9, N'1         ', N'1         ', 3)
INSERT [dbo].[Продукты] ([Штриховой_Код], [ИД_Продукта], [Количество], [Цена], [ИД_Еденицы_Измерения]) VALUES (NULL, 10, N'1         ', N'1         ', 3)
GO
ALTER TABLE [dbo].[Продукты]  WITH CHECK ADD  CONSTRAINT [FK_Продукты_ИД_Еденицы_Измерения] FOREIGN KEY([ИД_Еденицы_Измерения])
REFERENCES [dbo].[ИД_Еденицы_Измерения] ([ИД_Еденицы_Измерения])
GO
ALTER TABLE [dbo].[Продукты] CHECK CONSTRAINT [FK_Продукты_ИД_Еденицы_Измерения]
GO
ALTER TABLE [dbo].[Продукты]  WITH CHECK ADD  CONSTRAINT [FK_Продукты_ИД_Продукта] FOREIGN KEY([ИД_Продукта])
REFERENCES [dbo].[ИД_Продукта] ([ИД_Продукта])
GO
ALTER TABLE [dbo].[Продукты] CHECK CONSTRAINT [FK_Продукты_ИД_Продукта]
GO
USE [master]
GO
ALTER DATABASE [C:\USERS\USER\DESKTOP\STUDY\PROGRAMS\DATABASE MANAGEMENT SOFTWARE (DMS)\DATABASE1.MDF] SET  READ_WRITE 
GO
