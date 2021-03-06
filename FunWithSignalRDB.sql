USE [master]
GO
/****** Object:  Database [FunWithSignalRDI]    Script Date: 05/07/2012 09:14:12 ******/
CREATE DATABASE [FunWithSignalRDI] ON  PRIMARY 
( NAME = N'FunWithSignalRDI', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESSR2\MSSQL\DATA\FunWithSignalRDI.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FunWithSignalRDI_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESSR2\MSSQL\DATA\FunWithSignalRDI_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FunWithSignalRDI] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FunWithSignalRDI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FunWithSignalRDI] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET ANSI_NULLS OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET ANSI_PADDING OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET ARITHABORT OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET AUTO_CLOSE ON
GO
ALTER DATABASE [FunWithSignalRDI] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [FunWithSignalRDI] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [FunWithSignalRDI] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [FunWithSignalRDI] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET  ENABLE_BROKER
GO
ALTER DATABASE [FunWithSignalRDI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [FunWithSignalRDI] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [FunWithSignalRDI] SET  READ_WRITE
GO
ALTER DATABASE [FunWithSignalRDI] SET RECOVERY SIMPLE
GO
ALTER DATABASE [FunWithSignalRDI] SET  MULTI_USER
GO
ALTER DATABASE [FunWithSignalRDI] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [FunWithSignalRDI] SET DB_CHAINING OFF
GO
USE [FunWithSignalRDI]
GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 05/07/2012 09:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Post] [nvarchar](max) NULL,
 CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
