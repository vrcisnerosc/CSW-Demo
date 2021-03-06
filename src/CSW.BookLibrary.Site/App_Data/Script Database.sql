USE [master]
GO
/****** Object:  Database [CSW]    Script Date: 3/25/2017 4:56:35 PM ******/
CREATE DATABASE [CSW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CSW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CSW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CSW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CSW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CSW] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSW] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CSW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CSW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CSW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CSW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSW] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSW] SET  MULTI_USER 
GO
ALTER DATABASE [CSW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CSW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CSW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CSW] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CSW] SET QUERY_STORE = OFF
GO
USE [CSW]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CSW]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 3/25/2017 4:56:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 3/25/2017 4:56:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/25/2017 4:56:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [Country]) VALUES (N'e831cfe9-9257-48fd-b494-5f48c38eee5b', N'Jaime', N'Bayly', N'Perú')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [Country]) VALUES (N'ef2d66e8-a63d-4e63-97d9-cc670b8bda88', N'Mario', N'Vargas Llosa', N'Perú')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [Country]) VALUES (N'784237b8-41fd-4196-a7f1-ef760ecc0c83', N'Ciro', N'Alegría', N'Perú')
INSERT [dbo].[Books] ([Id], [Name], [AuthorId], [CategoryId]) VALUES (N'e208c823-55e3-4c74-bb25-24e13e22b262', N'The Golden Serpent', N'784237b8-41fd-4196-a7f1-ef760ecc0c83', N'5c1f65ac-e6bf-4755-a1e5-8fe501b59293')
INSERT [dbo].[Books] ([Id], [Name], [AuthorId], [CategoryId]) VALUES (N'c1176869-4061-435e-a104-70fe8837b09d', N'The hungry dogs', N'784237b8-41fd-4196-a7f1-ef760ecc0c83', N'5c1f65ac-e6bf-4755-a1e5-8fe501b59293')
INSERT [dbo].[Books] ([Id], [Name], [AuthorId], [CategoryId]) VALUES (N'b9d3aa60-af01-484e-a2b3-7969d8695e8c', N'The Cubs and Other Stories', N'ef2d66e8-a63d-4e63-97d9-cc670b8bda88', N'd7a16417-a2bc-459d-9bd3-38d85e79499e')
INSERT [dbo].[Books] ([Id], [Name], [AuthorId], [CategoryId]) VALUES (N'a8a8c1b6-97c0-4dd9-84ed-b9dcb7050405', N'The Sentimental Jerk', N'e831cfe9-9257-48fd-b494-5f48c38eee5b', N'cb4b4593-6b3d-409d-9cb1-0cf4288b933e')
INSERT [dbo].[Books] ([Id], [Name], [AuthorId], [CategoryId]) VALUES (N'95354e5a-1af4-4ecd-bd41-f90c24b7e5c4', N'The Time of the Hero', N'ef2d66e8-a63d-4e63-97d9-cc670b8bda88', N'cb4b4593-6b3d-409d-9cb1-0cf4288b933e')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'cb4b4593-6b3d-409d-9cb1-0cf4288b933e', N'Narrative', N'literary works whose content is produced by the imagination and is not necessarily based on fact')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'd7a16417-a2bc-459d-9bd3-38d85e79499e', N'Fiction', N'Short Stories')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'3919ffbc-bf9d-47e0-bd1f-520a73bca62e', N'Documentals', N'Geography')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'5c1f65ac-e6bf-4755-a1e5-8fe501b59293', N'Literary Fiction', N'Fiction & Literature')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'59e25166-1ae0-466c-9806-a2d5710295da', N'Technology', N'About tech')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'4f0b4e66-c872-466c-917f-e66b30b361ae', N'Horror', N'Horror Films')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'118c7dd0-5664-4b59-837f-f8da8c27090e', N'Humor', N'To Laught')
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
USE [master]
GO
ALTER DATABASE [CSW] SET  READ_WRITE 
GO
