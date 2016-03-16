USE [master]
GO
/****** Object:  Database [HRMSDB]    Script Date: 3/16/2016 10:43:37 AM ******/
CREATE DATABASE [HRMSDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HRMSDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HRMSDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HRMSDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HRMSDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HRMSDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HRMSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HRMSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HRMSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HRMSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HRMSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HRMSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HRMSDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HRMSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HRMSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HRMSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HRMSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HRMSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HRMSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HRMSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HRMSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HRMSDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HRMSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HRMSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HRMSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HRMSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HRMSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HRMSDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HRMSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HRMSDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HRMSDB] SET  MULTI_USER 
GO
ALTER DATABASE [HRMSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HRMSDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HRMSDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HRMSDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HRMSDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HRMSDB]
GO
/****** Object:  Table [dbo].[EducationalBackground]    Script Date: 3/16/2016 10:43:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationalBackground](
	[EmployeeId] [bigint] NOT NULL,
	[SchoolCode] [nchar](10) NULL,
	[SchoolName] [nchar](10) NULL,
	[SchoolAddress] [nchar](10) NULL,
	[DateAttended] [nchar](10) NULL,
	[DateGraduated] [nchar](10) NULL,
	[Degree] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeAddress]    Script Date: 3/16/2016 10:43:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAddress](
	[EmployeeId] [bigint] NOT NULL,
	[AddressLine1] [nvarchar](100) NOT NULL,
	[Addressline2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeInformation]    Script Date: 3/16/2016 10:43:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeInformation](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber]  AS (((substring([FirstName],(1),(1))+substring([MiddleName],(1),(1)))+substring([LastName],(1),(1)))+CONVERT([nvarchar](20),[EmployeeId])) PERSISTED NOT NULL,
	[Salutation] [nvarchar](5) NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Suffix] [nvarchar](5) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[CivilStatus] [char](1) NOT NULL,
	[EducationalAttainment] [char](1) NULL,
 CONSTRAINT [PK_EmployeeInformation] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EmployeeNumber] UNIQUE NONCLUSTERED 
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployementHistory]    Script Date: 3/16/2016 10:43:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployementHistory](
	[EmployeeId] [bigint] NOT NULL,
	[CompanyName] [nchar](10) NULL,
	[CompanyAddress] [nchar](10) NULL,
	[StartDate] [nchar](10) NULL,
	[EndDate] [nchar](10) NULL,
	[LastPositionHeld] [nchar](10) NULL,
	[Industry] [nchar](10) NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EducationalBackground]  WITH CHECK ADD  CONSTRAINT [FK_EducationalBackground_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInformation] ([EmployeeId])
GO
ALTER TABLE [dbo].[EducationalBackground] CHECK CONSTRAINT [FK_EducationalBackground_EmployeeId]
GO
ALTER TABLE [dbo].[EmployeeAddress]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAddress_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInformation] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeAddress] CHECK CONSTRAINT [FK_EmployeeAddress_EmployeeId]
GO
ALTER TABLE [dbo].[EmployementHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployementHistory_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInformation] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployementHistory] CHECK CONSTRAINT [FK_EmployementHistory_EmployeeId]
GO
USE [master]
GO
ALTER DATABASE [HRMSDB] SET  READ_WRITE 
GO
