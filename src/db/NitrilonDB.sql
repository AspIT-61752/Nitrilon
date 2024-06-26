USE [master]
GO
/****** Object:  Database [NitrilonDB]    Script Date: 07-05-2024 13:55:48 ******/
CREATE DATABASE [NitrilonDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NitrilonDB', FILENAME = N'C:\Users\61752\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\NitrilonDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NitrilonDB_log', FILENAME = N'C:\Users\61752\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\NitrilonDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NitrilonDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NitrilonDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NitrilonDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [NitrilonDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [NitrilonDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [NitrilonDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [NitrilonDB] SET ARITHABORT ON 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NitrilonDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NitrilonDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [NitrilonDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [NitrilonDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NitrilonDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [NitrilonDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NitrilonDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NitrilonDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NitrilonDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NitrilonDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NitrilonDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NitrilonDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NitrilonDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NitrilonDB] SET RECOVERY FULL 
GO
ALTER DATABASE [NitrilonDB] SET  MULTI_USER 
GO
ALTER DATABASE [NitrilonDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NitrilonDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NitrilonDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NitrilonDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NitrilonDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NitrilonDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NitrilonDB] SET QUERY_STORE = OFF
GO
USE [NitrilonDB]
GO
/****** Object:  Table [dbo].[EventRatings]    Script Date: 07-05-2024 13:55:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventRatings](
	[EventRatingId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[RatingId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventRatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 07-05-2024 13:55:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Attendees] [int] NULL,
	[Description] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 07-05-2024 13:55:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Membership] [int] NOT NULL,
	[FullName] [nvarchar](128) NOT NULL,
	[JoinDate] [datetime] NOT NULL,
	[Email] [nvarchar](128) NULL,
	[PhoneNumber] [nvarchar](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 07-05-2024 13:55:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 07-05-2024 13:55:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [tinyint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EventRatings] ON 

INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (1, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (2, 2, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (3, 2, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (4, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (5, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (6, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (7, 3, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (8, 2, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (9, 2, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (10, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (11, 11, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (12, 11, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (14, 7, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (15, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (16, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (17, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (18, 2, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (19, 2, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (20, 2, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (21, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (22, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (23, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (24, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (25, 2, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (26, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (27, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (28, 5, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (29, 6, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (30, 2, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (31, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (32, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (33, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (34, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (35, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (36, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (37, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (38, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (39, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (40, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (41, 8, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (42, 12, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (43, 12, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (44, 12, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (45, 8, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (46, 3, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (47, 1, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (48, 1, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (49, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (50, 1, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (51, 2, 2)
SET IDENTITY_INSERT [dbo].[EventRatings] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (1, CAST(N'2024-12-31' AS Date), N'Tour De Boom', 1, N'Vær med til et BRAG af en fest hos mig, please, jeg er så ensom...')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2, CAST(N'2024-06-22' AS Date), N'SOMMER FEST D&D CULT', 18, N'SÅ ER DER SOMMMMEEEERRRR FFEEEERRRIIIIEEE!!!')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (3, CAST(N'2024-06-23' AS Date), N'KBH tur', 2, N'Party all week')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (4, CAST(N'2024-04-11' AS Date), N'Software Expo 2077', 0, N'Wake up Samurai B)')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (5, CAST(N'2024-04-11' AS Date), N'Shoelace Party', 0, N'Show YOUR style tonight')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (6, CAST(N'2024-04-11' AS Date), N'404 Fest', 0, N'Good luck finding the event tihi')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (7, CAST(N'2024-08-19' AS Date), N'The Great Game Dev Code-Off', 0, N'Try to code while wearing beer googles or brainstorming sessions with your mouth is full of marshmallows.')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (8, CAST(N'2024-08-19' AS Date), N'CTRL + A; BACKSPACE', 0, N'Dont tell the cops about this event...')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (9, CAST(N'2024-04-12' AS Date), N'Super Flyers Con', 0, N'I am so addicted to these things.')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (10, CAST(N'2024-04-12' AS Date), N'THIS SHIT WORKS GREAT', 42, N'42')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (11, CAST(N'2024-04-15' AS Date), N'string', 0, N'string')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (12, CAST(N'2024-04-22' AS Date), N'string', 0, N'string')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (13, CAST(N'2024-07-01' AS Date), N'Nitrilon Fantasy-Con 2024', 0, N'Are you ready Elves?!')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (1, 2, N'Mads Mikkelsen', CAST(N'2004-03-20T00:00:00.000' AS DateTime), N'mads-mikkelsen@gmail.com', N'+4524879658')
INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (2, 1, N'Morten Master Cheff', CAST(N'2019-03-24T00:00:00.000' AS DateTime), N'morten-cheff@gmail.com', N'+4164879531')
INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (3, 2, N'Tommy Wasup', CAST(N'2024-05-07T00:00:00.000' AS DateTime), N'tommy-was-up@gmail.com', N'+4585467913')
INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (4, 2, N'Sony Eriksen', CAST(N'2024-05-07T00:00:00.000' AS DateTime), N'sony-eriksen@gmail.com', N'+4585449913')
INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (5, 2, N'Nico Vidia', CAST(N'2024-05-07T00:00:00.000' AS DateTime), N'n-vidia@gmail.com', N'+4576144913')
INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (6, 2, N'Ann Droid', CAST(N'2024-05-07T00:00:00.000' AS DateTime), N'anndroid@gmail.com', N'+4545146918')
INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (7, 2, N'Mike Rosoft', CAST(N'2024-05-07T00:00:00.000' AS DateTime), N'mikerosoft@mail.dk', N'+4545744213')
INSERT [dbo].[Members] ([Id], [Membership], [FullName], [JoinDate], [Email], [PhoneNumber]) VALUES (8, 2, N'Sam Sung', CAST(N'2024-05-07T00:00:00.000' AS DateTime), N'samsung@gmail.dk', N'+4546812213')
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[Memberships] ON 

INSERT [dbo].[Memberships] ([Id], [Name], [Description]) VALUES (1, N'Passive', N'Is not a member')
INSERT [dbo].[Memberships] ([Id], [Name], [Description]) VALUES (2, N'Active', N'Is a member')
SET IDENTITY_INSERT [dbo].[Memberships] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 

INSERT [dbo].[Ratings] ([RatingId], [Value], [Description]) VALUES (1, 1, N'If I could give it a lower rating I would...')
INSERT [dbo].[Ratings] ([RatingId], [Value], [Description]) VALUES (2, 2, N'Pretty mid ngl.')
INSERT [dbo].[Ratings] ([RatingId], [Value], [Description]) VALUES (3, 3, N'BEST DAY EVUR ¯\_(?)_/¯')
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
ALTER TABLE [dbo].[Events] ADD  DEFAULT ((-1)) FOR [Attendees]
GO
ALTER TABLE [dbo].[Events] ADD  DEFAULT ('Dette event har endnu ingen beskrivelse.') FOR [Description]
GO
ALTER TABLE [dbo].[EventRatings]  WITH CHECK ADD  CONSTRAINT [FK_EventRatings_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[EventRatings] CHECK CONSTRAINT [FK_EventRatings_Events]
GO
ALTER TABLE [dbo].[EventRatings]  WITH CHECK ADD  CONSTRAINT [FK_EventRatings_Ratings] FOREIGN KEY([RatingId])
REFERENCES [dbo].[Ratings] ([RatingId])
GO
ALTER TABLE [dbo].[EventRatings] CHECK CONSTRAINT [FK_EventRatings_Ratings]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Memberships] FOREIGN KEY([Membership])
REFERENCES [dbo].[Memberships] ([Id])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Memberships]
GO
/****** Object:  StoredProcedure [dbo].[CountAllowedRatingsForEvent]    Script Date: 07-05-2024 13:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountAllowedRatingsForEvent]
    @EventId INT
AS
BEGIN
    DECLARE @BadCount INT, @AverageCount INT, @GoodCount INT;

    SELECT @BadCount = COUNT(CASE WHEN RatingId = 1 THEN 1 ELSE NULL END),
           @AverageCount = COUNT(CASE WHEN RatingId = 2 THEN 1 ELSE NULL END),
           @GoodCount = COUNT(CASE WHEN RatingId = 3 THEN 1 ELSE NULL END)
    FROM EventRatings
    WHERE EventId = @EventId;

    SELECT @BadCount AS RatingBad,
           @AverageCount AS RatingAverage,
           @GoodCount AS RatingGood;
END
GO
USE [master]
GO
ALTER DATABASE [NitrilonDB] SET  READ_WRITE 
GO
