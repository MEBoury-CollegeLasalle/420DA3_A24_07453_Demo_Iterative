USE [420da3_07453_demo_iterative]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoursEtudiants]') AND type in (N'U'))
ALTER TABLE [dbo].[CoursEtudiants] DROP CONSTRAINT IF EXISTS [FK_CoursEtudiants_Etudiants]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoursEtudiants]') AND type in (N'U'))
ALTER TABLE [dbo].[CoursEtudiants] DROP CONSTRAINT IF EXISTS [FK_CoursEtudiants_Cours]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Etudiants]') AND type in (N'U'))
ALTER TABLE [dbo].[Etudiants] DROP CONSTRAINT IF EXISTS [DF_Etudiants_DateCreation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cours]') AND type in (N'U'))
ALTER TABLE [dbo].[Cours] DROP CONSTRAINT IF EXISTS [DF_Cours_DateCreation]
GO
/****** Object:  Index [IX_CoursEtudiants_Etudiants]    Script Date: 2024-10-03 11:42:15 AM ******/
DROP INDEX IF EXISTS [IX_CoursEtudiants_Etudiants] ON [dbo].[CoursEtudiants]
GO
/****** Object:  Index [IX_CoursEtudiants_Cours]    Script Date: 2024-10-03 11:42:15 AM ******/
DROP INDEX IF EXISTS [IX_CoursEtudiants_Cours] ON [dbo].[CoursEtudiants]
GO
/****** Object:  Table [dbo].[Etudiants]    Script Date: 2024-10-03 11:42:15 AM ******/
DROP TABLE IF EXISTS [dbo].[Etudiants]
GO
/****** Object:  Table [dbo].[CoursEtudiants]    Script Date: 2024-10-03 11:42:15 AM ******/
DROP TABLE IF EXISTS [dbo].[CoursEtudiants]
GO
/****** Object:  Table [dbo].[Cours]    Script Date: 2024-10-03 11:42:15 AM ******/
DROP TABLE IF EXISTS [dbo].[Cours]
GO
USE [master]
GO
/****** Object:  Database [420da3_07453_demo_iterative]    Script Date: 2024-10-03 11:42:15 AM ******/
DROP DATABASE IF EXISTS [420da3_07453_demo_iterative]
GO
/****** Object:  Database [420da3_07453_demo_iterative]    Script Date: 2024-10-03 11:42:15 AM ******/
CREATE DATABASE [420da3_07453_demo_iterative]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'420da3_07453_demo_iterative', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022DEV\MSSQL\DATA\420da3_07453_demo_iterative.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'420da3_07453_demo_iterative_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022DEV\MSSQL\DATA\420da3_07453_demo_iterative_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [420da3_07453_demo_iterative].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET ARITHABORT OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET  DISABLE_BROKER 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET RECOVERY FULL 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET  MULTI_USER 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET DB_CHAINING OFF 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'420da3_07453_demo_iterative', N'ON'
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET QUERY_STORE = ON
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [420da3_07453_demo_iterative]
GO
/****** Object:  Table [dbo].[Cours]    Script Date: 2024-10-03 11:42:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodeCours] [nvarchar](12) NOT NULL,
	[Titre] [nvarchar](128) NOT NULL,
	[DateCreation] [datetime2](7) NOT NULL,
	[DateModification] [datetime2](7) NULL,
	[DateSuppression] [datetime2](7) NULL,
 CONSTRAINT [PK_Cours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoursEtudiants]    Script Date: 2024-10-03 11:42:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursEtudiants](
	[CoursId] [int] NOT NULL,
	[EtudiantId] [int] NOT NULL,
 CONSTRAINT [PK_CoursEtudiants] PRIMARY KEY CLUSTERED 
(
	[CoursId] ASC,
	[EtudiantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etudiants]    Script Date: 2024-10-03 11:42:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etudiants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](64) NOT NULL,
	[Prenom] [nvarchar](64) NOT NULL,
	[CodePermanent] [nvarchar](12) NOT NULL,
	[DateEnregistrement] [datetime2](7) NOT NULL,
	[DateCreation] [datetime2](7) NOT NULL,
	[DateModification] [datetime2](7) NULL,
	[DateSuppression] [datetime2](7) NULL,
 CONSTRAINT [PK_Etudiants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cours] ON 

INSERT [dbo].[Cours] ([Id], [CodeCours], [Titre], [DateCreation], [DateModification], [DateSuppression]) VALUES (1, N'420DA3AS', N'Développement d''applications multi-tiers', CAST(N'2024-10-03T11:25:24.0566667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Cours] ([Id], [CodeCours], [Titre], [DateCreation], [DateModification], [DateSuppression]) VALUES (2, N'420DW3AS', N'Développement web serveur I', CAST(N'2024-10-03T11:26:17.9300000' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cours] OFF
GO
INSERT [dbo].[CoursEtudiants] ([CoursId], [EtudiantId]) VALUES (1, 1)
INSERT [dbo].[CoursEtudiants] ([CoursId], [EtudiantId]) VALUES (2, 1)
GO
SET IDENTITY_INSERT [dbo].[Etudiants] ON 

INSERT [dbo].[Etudiants] ([Id], [Nom], [Prenom], [CodePermanent], [DateEnregistrement], [DateCreation], [DateModification], [DateSuppression]) VALUES (1, N'Doe', N'John', N'JOHD90071315', CAST(N'2024-08-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-03T11:27:49.9266667' AS DateTime2), NULL, NULL)
INSERT [dbo].[Etudiants] ([Id], [Nom], [Prenom], [CodePermanent], [DateEnregistrement], [DateCreation], [DateModification], [DateSuppression]) VALUES (2, N'Doe', N'Jane', N'JOHD92020512', CAST(N'2024-07-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-03T11:28:20.0933333' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Etudiants] OFF
GO
/****** Object:  Index [IX_CoursEtudiants_Cours]    Script Date: 2024-10-03 11:42:15 AM ******/
CREATE NONCLUSTERED INDEX [IX_CoursEtudiants_Cours] ON [dbo].[CoursEtudiants]
(
	[CoursId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CoursEtudiants_Etudiants]    Script Date: 2024-10-03 11:42:15 AM ******/
CREATE NONCLUSTERED INDEX [IX_CoursEtudiants_Etudiants] ON [dbo].[CoursEtudiants]
(
	[EtudiantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cours] ADD  CONSTRAINT [DF_Cours_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[Etudiants] ADD  CONSTRAINT [DF_Etudiants_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[CoursEtudiants]  WITH CHECK ADD  CONSTRAINT [FK_CoursEtudiants_Cours] FOREIGN KEY([CoursId])
REFERENCES [dbo].[Cours] ([Id])
GO
ALTER TABLE [dbo].[CoursEtudiants] CHECK CONSTRAINT [FK_CoursEtudiants_Cours]
GO
ALTER TABLE [dbo].[CoursEtudiants]  WITH CHECK ADD  CONSTRAINT [FK_CoursEtudiants_Etudiants] FOREIGN KEY([EtudiantId])
REFERENCES [dbo].[Etudiants] ([Id])
GO
ALTER TABLE [dbo].[CoursEtudiants] CHECK CONSTRAINT [FK_CoursEtudiants_Etudiants]
GO
USE [master]
GO
ALTER DATABASE [420da3_07453_demo_iterative] SET  READ_WRITE 
GO
