/****** Object:  Database [net-core-framework-database]    Script Date: 11/10/2020 16:55:34 ******/
USE [master]
GO

--DROP DATABASE IF EXISTS [net-core-framework-database]
--GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'net-core-framework-database')
BEGIN
ALTER DATABASE [net-core-framework-database] SET OFFLINE WITH ROLLBACK IMMEDIATE
ALTER DATABASE [net-core-framework-database] SET ONLINE
DROP DATABASE [net-core-framework-database]
END
GO

CREATE DATABASE [net-core-framework-database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'net-core-framework-database', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\net-core-framework-database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'net-core-framework-database_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\net-core-framework-database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [net-core-framework-database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [net-core-framework-database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [net-core-framework-database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [net-core-framework-database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [net-core-framework-database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [net-core-framework-database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [net-core-framework-database] SET ARITHABORT OFF 
GO
ALTER DATABASE [net-core-framework-database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [net-core-framework-database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [net-core-framework-database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [net-core-framework-database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [net-core-framework-database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [net-core-framework-database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [net-core-framework-database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [net-core-framework-database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [net-core-framework-database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [net-core-framework-database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [net-core-framework-database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [net-core-framework-database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [net-core-framework-database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [net-core-framework-database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [net-core-framework-database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [net-core-framework-database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [net-core-framework-database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [net-core-framework-database] SET RECOVERY FULL 
GO
ALTER DATABASE [net-core-framework-database] SET  MULTI_USER 
GO
ALTER DATABASE [net-core-framework-database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [net-core-framework-database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [net-core-framework-database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [net-core-framework-database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [net-core-framework-database] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'net-core-framework-database', N'ON'
GO
ALTER DATABASE [net-core-framework-database] SET QUERY_STORE = OFF
GO
USE [net-core-framework-database]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 11/10/2020 16:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [smallint] NOT NULL,
	[Name] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 11/10/2020 16:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Code_Phone] [smallint] NOT NULL,
	[Code_Alpha2] [char](2) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Cities_of_Countries]    Script Date: 11/10/2020 16:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Cities_of_Countries]
AS
SELECT dbo.Cities.Id, dbo.Cities.CountryId, dbo.Cities.Name, dbo.Countries.Id AS Expr1, dbo.Countries.Name AS Expr2, dbo.Countries.Code_Phone, dbo.Countries.Code_Alpha2
FROM   dbo.Cities INNER JOIN
             dbo.Countries ON dbo.Cities.CountryId = dbo.Countries.Id
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [Code_Phone], [Code_Alpha2]) VALUES (1, N'United Kingdom', 44, N'GB')
INSERT [dbo].[Countries] ([Id], [Name], [Code_Phone], [Code_Alpha2]) VALUES (2, N'Switzerland', 41, N'CH')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (1, 1, N'Bristol')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (2, 1, N'Bradford')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (3, 2, N'Bern')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (4, 2, N'Zürich')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (5, 1, N'Birmingham')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (6, 1, N'Leeds')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (7, 1, N'City of London')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (8, 2, N'Geneva')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (9, 2, N'Basel')
INSERT [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (10, 2, N'Lucerne')

SET IDENTITY_INSERT [dbo].[Cities] OFF
GO

ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cities"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 179
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Countries"
            Begin Extent = 
               Top = 9
               Left = 336
               Bottom = 206
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cities_of_Countries'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Cities_of_Countries'
GO
USE [master]
GO
ALTER DATABASE [net-core-framework-database] SET  READ_WRITE 
GO