USE [master]
GO

/****** Object:  Database [Gsb_Hopital]    Script Date: 03/05/2016 09:48:57 ******/
CREATE DATABASE [Gsb_Hopital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gsb_Hopital', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Gsb_Hopital.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Gsb_Hopital_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Gsb_Hopital_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Gsb_Hopital] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gsb_Hopital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Gsb_Hopital] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET ARITHABORT OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [Gsb_Hopital] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Gsb_Hopital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Gsb_Hopital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Gsb_Hopital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Gsb_Hopital] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Gsb_Hopital] SET  MULTI_USER 
GO

ALTER DATABASE [Gsb_Hopital] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Gsb_Hopital] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Gsb_Hopital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Gsb_Hopital] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Gsb_Hopital] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Gsb_Hopital] SET  READ_WRITE 
GO
