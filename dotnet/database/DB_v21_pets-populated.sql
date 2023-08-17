USE [master]
drop database if exists [final_capstone]
GO
/****** Object:  Database [final_capstone]    Script Date: 8/17/2023 6:14:15 PM ******/
CREATE DATABASE [final_capstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'final_capstone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'final_capstone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [final_capstone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [final_capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [final_capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [final_capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [final_capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [final_capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [final_capstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [final_capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [final_capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [final_capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [final_capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [final_capstone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [final_capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [final_capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [final_capstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [final_capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [final_capstone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [final_capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [final_capstone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [final_capstone] SET  MULTI_USER 
GO
ALTER DATABASE [final_capstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [final_capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [final_capstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [final_capstone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [final_capstone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [final_capstone] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [final_capstone] SET QUERY_STORE = OFF
GO
USE [final_capstone]
GO
/****** Object:  Table [dbo].[addresses]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[addresses](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[street] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[state_abr] [varchar](2) NOT NULL,
	[zip] [int] NOT NULL,
 CONSTRAINT [PK_addresses] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attributes]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attributes](
	[attribute_id] [int] IDENTITY(1,1) NOT NULL,
	[spayed_neutered] [bit] NOT NULL,
	[house_trained] [bit] NOT NULL,
	[declawed] [bit] NOT NULL,
	[special_needs] [bit] NOT NULL,
	[shots_current] [bit] NOT NULL,
 CONSTRAINT [PK_attributes] PRIMARY KEY CLUSTERED 
(
	[attribute_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[environments]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[environments](
	[environment_id] [int] IDENTITY(1,1) NOT NULL,
	[children] [bit] NOT NULL,
	[dogs] [bit] NOT NULL,
	[cats] [bit] NOT NULL,
	[other_animals] [bit] NOT NULL,
	[indoor_only] [bit] NOT NULL,
 CONSTRAINT [PK_environment] PRIMARY KEY CLUSTERED 
(
	[environment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pets]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pets](
	[pet_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[species] [nvarchar](50) NOT NULL,
	[color] [varchar](20) NOT NULL,
	[age] [varchar](50) NULL,
	[attribute_id] [int] NULL,
	[environment_id] [int] NULL,
	[tag_id] [int] NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](200) NULL,
	[user_id] [int] NOT NULL,
	[is_adopted] [bit] NOT NULL,
	[address_id] [int] NULL,
 CONSTRAINT [PK_Pet] PRIMARY KEY CLUSTERED 
(
	[pet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[photos]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[photos](
	[photo_id] [int] IDENTITY(1,1) NOT NULL,
	[photo_url] [nvarchar](200) NOT NULL,
	[pet_id] [int] NOT NULL,
	[is_not_active] [bit] NOT NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[photo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tags]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tags](
	[tag_id] [int] IDENTITY(1,1) NOT NULL,
	[playful] [bit] NOT NULL,
	[needs_exercise] [bit] NOT NULL,
	[cute] [bit] NOT NULL,
	[affectionate] [bit] NOT NULL,
	[large] [bit] NOT NULL,
	[intelligent] [bit] NOT NULL,
	[happy] [bit] NOT NULL,
	[short_haired] [bit] NOT NULL,
	[shedder] [bit] NOT NULL,
	[shy] [bit] NOT NULL,
	[faithful] [bit] NOT NULL,
	[leash_trained] [bit] NOT NULL,
	[hypoallergenic] [bit] NOT NULL,
 CONSTRAINT [PK_tags] PRIMARY KEY CLUSTERED 
(
	[tag_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_adopter]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_adopter](
	[pet_id] [int] NOT NULL,
	[adopter_id] [int] NOT NULL,
 CONSTRAINT [PK_user_adopter] PRIMARY KEY CLUSTERED 
(
	[pet_id] ASC,
	[adopter_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 8/17/2023 6:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password_hash] [varchar](200) NOT NULL,
	[salt] [varchar](200) NOT NULL,
	[user_role] [varchar](50) NOT NULL,
	[app_status] [varchar](10) NULL,
	[is_not_active] [bit] NOT NULL,
	[address_id] [int] NULL,
	[email] [varchar](50) NULL,
	[is_adopter] [bit] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[addresses] ON 
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (1, N'918 1st Street', N'McKees Rocks', N'PA', 15136)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (2, N'123 somewhere ave', N'Somewhere', N'PA', 12345)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (3, N'234 Elsewhere St', N'Pittsburgh', N'PA', 15235)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (4, N'321 going nowhere Ave.', N'Green Tree', N'PA', 15106)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (5, N'587 indifferent ln.', N'Martinez', N'CA', 94553)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (6, N'555 Irule Ave.', N'Pittsburgh', N'PA', 15235)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (7, N'123 anywhere ct.', N'Coder', N'PA', 15234)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (8, N'123 throwup ln.', N'Hoosick', N'NY', 12089)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (9, N'234 Wayne Manor', N'Gotham City', N'PA', 53540)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (10, N'345 Bad lane', N'Deadend', N'PA', 15345)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (11, N'456 Ineedadog st.', N'Petlove', N'PA', 23412)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (12, N'5810 Schell Circle', N'Aliquippa', N'PA', 15001)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (13, N'5810 Schell Circle', N'Aliquippa', N'PA', 15001)
GO
INSERT [dbo].[addresses] ([address_id], [street], [city], [state_abr], [zip]) VALUES (14, N'91 Clay Street', N'Kane', N'PA', 16735)
GO
SET IDENTITY_INSERT [dbo].[addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[attributes] ON 
GO
INSERT [dbo].[attributes] ([attribute_id], [spayed_neutered], [house_trained], [declawed], [special_needs], [shots_current]) VALUES (1, 1, 1, 0, 0, 0)
GO
INSERT [dbo].[attributes] ([attribute_id], [spayed_neutered], [house_trained], [declawed], [special_needs], [shots_current]) VALUES (2, 1, 1, 0, 0, 0)
GO
INSERT [dbo].[attributes] ([attribute_id], [spayed_neutered], [house_trained], [declawed], [special_needs], [shots_current]) VALUES (3, 1, 1, 0, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[attributes] OFF
GO
SET IDENTITY_INSERT [dbo].[environments] ON 
GO
INSERT [dbo].[environments] ([environment_id], [children], [dogs], [cats], [other_animals], [indoor_only]) VALUES (1, 0, 0, 0, 0, 1)
GO
INSERT [dbo].[environments] ([environment_id], [children], [dogs], [cats], [other_animals], [indoor_only]) VALUES (2, 0, 0, 1, 0, 1)
GO
INSERT [dbo].[environments] ([environment_id], [children], [dogs], [cats], [other_animals], [indoor_only]) VALUES (3, 0, 1, 1, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[environments] OFF
GO
SET IDENTITY_INSERT [dbo].[pets] ON 
GO
INSERT [dbo].[pets] ([pet_id], [type], [species], [color], [age], [attribute_id], [environment_id], [tag_id], [name], [description], [user_id], [is_adopted], [address_id]) VALUES (1, N'cat', N'Domestic Short Hair', N'White and Brown', N'senior', 1, 1, 1, N'Miika', N'Miika is beautiful and very chatty. She will bond with her special human and never let them forget about her.', 6, 0, 12)
GO
INSERT [dbo].[pets] ([pet_id], [type], [species], [color], [age], [attribute_id], [environment_id], [tag_id], [name], [description], [user_id], [is_adopted], [address_id]) VALUES (2, N'cat', N'Domestic Short Hair', N'White and brown', N'senior', 2, 2, 2, N'Clyde', N'Clyde is spooked easily, but he loves to snuggle.', 6, 0, 13)
GO
INSERT [dbo].[pets] ([pet_id], [type], [species], [color], [age], [attribute_id], [environment_id], [tag_id], [name], [description], [user_id], [is_adopted], [address_id]) VALUES (3, N'dog', N'Yorkshire Terrier', N'Black and brown', N'senior', 3, 3, 3, N'Willow', N'Willow loves hugs and is an excellent watchdog.', 6, 0, 14)
GO
SET IDENTITY_INSERT [dbo].[pets] OFF
GO
SET IDENTITY_INSERT [dbo].[photos] ON 
GO
INSERT [dbo].[photos] ([photo_id], [photo_url], [pet_id], [is_not_active]) VALUES (1, N'https://tegroups.blob.core.windows.net/petphotos/1_1692308505.jpeg', 1, 0)
GO
INSERT [dbo].[photos] ([photo_id], [photo_url], [pet_id], [is_not_active]) VALUES (2, N'https://tegroups.blob.core.windows.net/petphotos/2_1692308632.jpeg', 2, 0)
GO
INSERT [dbo].[photos] ([photo_id], [photo_url], [pet_id], [is_not_active]) VALUES (3, N'https://tegroups.blob.core.windows.net/petphotos/3_1692308813.png', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[photos] OFF
GO
SET IDENTITY_INSERT [dbo].[tags] ON 
GO
INSERT [dbo].[tags] ([tag_id], [playful], [needs_exercise], [cute], [affectionate], [large], [intelligent], [happy], [short_haired], [shedder], [shy], [faithful], [leash_trained], [hypoallergenic]) VALUES (1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0)
GO
INSERT [dbo].[tags] ([tag_id], [playful], [needs_exercise], [cute], [affectionate], [large], [intelligent], [happy], [short_haired], [shedder], [shy], [faithful], [leash_trained], [hypoallergenic]) VALUES (2, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0)
GO
INSERT [dbo].[tags] ([tag_id], [playful], [needs_exercise], [cute], [affectionate], [large], [intelligent], [happy], [short_haired], [shedder], [shy], [faithful], [leash_trained], [hypoallergenic]) VALUES (3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[tags] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (1, N'dunkster', N'2D0yxDbdmAbayziLKwiIegjvR08=', N'dj5a1cVHSps=', N'admin', N'approved', 0, 1, N'clanduncan4@msn.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (2, N'someone', N'B8jyL4bA1xNM2q4O192za6vjdw0=', N'eux6J8I6yDw=', N'friend', N'approved', 0, 2, N'someone@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (3, N'josieD', N'eQd3eCPcCxii1Njr4YEQcKEZ13Q=', N'qYtvtzLJdyE=', N'friend', N'approved', 0, 3, N'jd@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (4, N'John', N'xjIV8dNoq3ZtyG1jk57bfmSTEsk=', N'7ptpa48lgmI=', N'friend', N'approved', 0, 4, N'john@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (5, N'susie', N'uN/eYvLd8e9f69oN+N/Uxh9O6I8=', N'406yYXmyZ/o=', N'friend', N'pending', 0, 5, N'susieq@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (6, N'admin', N'14fj4BCQo5Xg5GLwOJnpi5Y96UU=', N'XBD/7ydYPfg=', N'admin', N'approved', 0, 6, N'admin@fureverfriends.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (7, N'Emelie', N'iH2TV2rgUcg6n7GqGZjvePa/tBw=', N'SLCCRCsNSS4=', N'admin', N'approved', 0, 7, N'emelie@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (8, N'ralph', N'U7dJxvKfyNoewx+j6zrBa2+KT/g=', N'BVZqHeVlpNQ=', N'friend', N'rejected', 0, 8, N'upcheck@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (9, N'Riley', N'+M+eVjAiMikbA0Ee+IYiMWhqSXI=', N'8pyTcI32z7E=', N'admin', N'approved', 0, 9, N'batman@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (10, N'nogo', N'UFbHQ7umAMskO7pKZLmMuOaFAT4=', N'5LICcklpGKY=', N'friend', N'approved', 1, 10, N'nogo@something.com', 0)
GO
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role], [app_status], [is_not_active], [address_id], [email], [is_adopter]) VALUES (11, N'Joeadopter', N'oK7/44n67tnG8bBAH6bbD9MIsNs=', N'5cDGq1X3ltc=', N'friend', N'approved', 0, 11, N'joeadopter@something.com', 0)
GO
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_UserName]    Script Date: 8/17/2023 6:14:15 PM ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [UQ_UserName] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pets] ADD  CONSTRAINT [DF_pets_is_adopted]  DEFAULT ((0)) FOR [is_adopted]
GO
ALTER TABLE [dbo].[pets]  WITH CHECK ADD  CONSTRAINT [FK_pets_addresses] FOREIGN KEY([address_id])
REFERENCES [dbo].[addresses] ([address_id])
GO
ALTER TABLE [dbo].[pets] CHECK CONSTRAINT [FK_pets_addresses]
GO
ALTER TABLE [dbo].[pets]  WITH CHECK ADD  CONSTRAINT [FK_pets_attributes] FOREIGN KEY([attribute_id])
REFERENCES [dbo].[attributes] ([attribute_id])
GO
ALTER TABLE [dbo].[pets] CHECK CONSTRAINT [FK_pets_attributes]
GO
ALTER TABLE [dbo].[pets]  WITH CHECK ADD  CONSTRAINT [FK_pets_environments] FOREIGN KEY([environment_id])
REFERENCES [dbo].[environments] ([environment_id])
GO
ALTER TABLE [dbo].[pets] CHECK CONSTRAINT [FK_pets_environments]
GO
ALTER TABLE [dbo].[pets]  WITH CHECK ADD  CONSTRAINT [FK_pets_tags] FOREIGN KEY([tag_id])
REFERENCES [dbo].[tags] ([tag_id])
GO
ALTER TABLE [dbo].[pets] CHECK CONSTRAINT [FK_pets_tags]
GO
ALTER TABLE [dbo].[pets]  WITH CHECK ADD  CONSTRAINT [FK_pets_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[pets] CHECK CONSTRAINT [FK_pets_users]
GO
ALTER TABLE [dbo].[photos]  WITH CHECK ADD  CONSTRAINT [FK_photos_pets] FOREIGN KEY([pet_id])
REFERENCES [dbo].[pets] ([pet_id])
GO
ALTER TABLE [dbo].[photos] CHECK CONSTRAINT [FK_photos_pets]
GO
ALTER TABLE [dbo].[user_adopter]  WITH CHECK ADD  CONSTRAINT [FK_user_adopter_pets] FOREIGN KEY([adopter_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[user_adopter] CHECK CONSTRAINT [FK_user_adopter_pets]
GO
ALTER TABLE [dbo].[user_adopter]  WITH CHECK ADD  CONSTRAINT [FK_user_adopter_user] FOREIGN KEY([pet_id])
REFERENCES [dbo].[pets] ([pet_id])
GO
ALTER TABLE [dbo].[user_adopter] CHECK CONSTRAINT [FK_user_adopter_user]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_addresses] FOREIGN KEY([address_id])
REFERENCES [dbo].[addresses] ([address_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_addresses]
GO
USE [master]
GO
ALTER DATABASE [final_capstone] SET  READ_WRITE 
GO
