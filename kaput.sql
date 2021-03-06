USE [master]
GO
/****** Object:  Database [ILCDB]    Script Date: 6/19/2018 4:13:29 PM ******/
CREATE DATABASE [ILCDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ILCDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ILCDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ILCDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ILCDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ILCDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ILCDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ILCDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ILCDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ILCDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ILCDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ILCDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ILCDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ILCDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ILCDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ILCDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ILCDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ILCDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ILCDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ILCDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ILCDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ILCDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ILCDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ILCDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ILCDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ILCDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ILCDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ILCDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ILCDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ILCDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ILCDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ILCDB] SET  MULTI_USER 
GO
ALTER DATABASE [ILCDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ILCDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ILCDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ILCDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ILCDB]
GO
/****** Object:  Table [dbo].[ILCInfo]    Script Date: 6/19/2018 4:13:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ILCInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[HeadmasterName] [nvarchar](255) NULL,
	[TrainerName] [nvarchar](255) NULL,
	[ContactNumber] [nvarchar](255) NULL,
 CONSTRAINT [PK_ILCInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 6/19/2018 4:13:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[ILCID] [varchar](50) NULL,
	[ILCEng] [varchar](200) NULL,
	[ILCName] [nvarchar](255) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[UserStatus] [varchar](50) NULL,
	[CStatus] [bit] NULL,
	[RecNo] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ILCInfo] ON 

INSERT [dbo].[ILCInfo] ([ID], [SchoolName], [Address], [HeadmasterName], [TrainerName], [ContactNumber]) VALUES (1, N'মডেল একাডেমী', N'পাইক পাড়া সরকারী (ডি-টাইপ) কলোনীমিরপুর-০১, ঢাকা-১২১৬', N'শুভাশীষ বিশ্বাস', N'রামকৃৃষ্ণ দাশ', N'014575744')
INSERT [dbo].[ILCInfo] ([ID], [SchoolName], [Address], [HeadmasterName], [TrainerName], [ContactNumber]) VALUES (2, N'গণভবন সরকারী উচ্চ বিদ্যালয়', N'বীর উত্তম খালেদ মোশাররফ এভিনিউ, ঢাকা', N'ফৌজৗয়া আহমেদ', N'জাকির হোসেন', N'012343567456')
SET IDENTITY_INSERT [dbo].[ILCInfo] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'1', N'Dhanmondi Government Boys'' High School', N'ধানমন্ডি সরকারি বালক উচ্চ বিদ্যালয়', 23.757781, 90.3730412, N'Loggedon nill', 1, 1)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'2', N'Mohammadpur High School', N'মোহাম্মদপুর উচ্চ বিদ্যালয়', 23.7658444, 90.3561719, N'Loggedon nill', 1, 2)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'3', N'Ganabhaban Government High School', N'গণভবন সরকারি উচ্চ বিদ্যালয়', 23.7680844, 90.3713196, N'Loggedon nill', 1, 3)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'4', N'Dhaka Collegiate School', N'ঢাকা কলেজিয়েট স্কুল', 23.7077314, 90.4083861, N'Loggedon nill', 1, 4)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'5', N'Armanitola Government High School', N'আরমানিটোলা সরকারি উচ্চ বিদ্যালয়', 23.7151171, 90.3997352, N'Loggedon nill', 1, 5)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'6', N'Government Science College Attached High School', N'সরকারী বিজ্ঞান কলেজ সংযুক্ত হাই স্কুল', 23.7580936, 90.389754, N'Loggedon nill', 1, 6)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'7', N'Tajgaon Government High School', N'তেজগাঁও সরকারি উচ্চ বিদ্যালয়', 23.757278, 90.3894735, N'Loggedon nill', 1, 7)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'8', N'Tejgaon Government Girls'' High School', N'তেজগাঁও সরকারী বালিকা উচ্চ বিদ্যালয়', 23.7570562, 90.3885422, N'Loggedon nill', 1, 8)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'9', N'Dhanmondi Government Girls'' High School', N'ধানমন্ডি সরকারি বালিকা উচ্চ বিদ্যালয়', 23.757787, 90.3730413, N'Loggedon nill', 1, 9)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'10', N'Bauniabadh Islamia Alim Madrasha', N'বাউনিয়াবাধ ইসলামিয়া আলিম মাদ্রাসা', 23.8176587, 90.3786816, N'Loggedon nill', 1, 10)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'11', N'Anawara Begum Muslim Girls High School', N'আনোয়ারা বেগম মুসলিম বালিকা উচ্চ বিদ্যালয়', 23.7899245, 90.3244118, N'Loggedon nill', 1, 11)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'12', N'Uttar badda islamia kamil madrasa', N'উত্তর বাড্ডা ইসলামিয়া কামিল মাদরাসা', 23.7860943, 90.4239925, N'Loggedon nill', 1, 12)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'13', N'Motijheel Government Boys High School', N'মতিঝিল সরকারি বালক উচ্চ বিদ্যালয়', 23.7386488, 90.4184491, N'Loggedon nill', 1, 13)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'14', N'Motijheel Govt. Girls'' High School', N'মতিঝিল সরকারি বালিকা উচ্চ বিদ্যালয়', 23.7382055, 90.4190308, N'Loggedon nill', 1, 14)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'15', N'Motijheel Colony High School', N'মতিঝিল কলোনি উচ্চ বিদ্যালয়', 23.7366, 90.4203894, N'Loggedon nill', 0, 15)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'16', N'Misbahul Ulum Kamil Madrasah', N'মিসবাহ উলুম কামিল মাদ্রাসা', 23.7348868, 90.4155914, N'Loggedon nill', 0, 16)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'17', N'Nazrul Shikkhalaya', N'নজরুল শিক্ষালয়', 23.7491792, 90.4053274, N'Loggedon nill', 0, 17)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'18', N'Dhaka Mohammadia Dakhil Madrasah', N'ঢাকা মোহাম্মাদিয়া দাখিল মাদ্রাসা', 23.700764, 90.436116, N'Loggedon nill', 1, 18)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'19', N'Kazipara Siddiquia Fazil Madrasah', N'কাজিপাড়া সিদ্দিকিয়া সিনিয়র ফাযিল মাদ্রাসা', 23.7969179, 90.3710996, N'Loggedon nill', 0, 19)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'20', N'Ashrafabad High School', N'আশ্রাফাবাদ উচ্চ বিদ্যালয়', 23.7108352, 90.3756004, N'Loggedon nill', 1, 20)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'21', N'Banglabazar Govt Girls'' High School', N'বাংলাবাজার সরকারী বালিকা উচ্চ বিদ্যালয়', 23.7072623, 90.4096068, N'Loggedon nill', 0, 21)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'22', N'Dhaka Govt. Muslim High School', N'ঢাকা সরকারী মুসলিম হাইস্কুল', 23.708951, 90.4107676, N'Loggedon nill', 1, 22)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'23', N'Narinda Government High School', N'নারিন্দা সরকারি উচ্চ বিদ্যালয়', 23.7145169, 90.4186683, N'Loggedon nill', 1, 23)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'24', N'NAZNIN SCHOOL AND COLLEGE', N'নাজনীন স্কুল অ্যান্ড কলেজ,', 23.7530441, 90.3847866, N'Loggedon nill', 1, 24)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'25', N'M I Dakhil Madrasah', N'এম আই দাখিল মাদ্রাসা', 23.7407799, 90.4593695, N'Loggedon nill', 1, 25)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'26', N'Shahid Sheikh Rasel Govt. High School', N'শহীদ শেখ রাসেল সরকার। উচ্চ বিদ্যালয', 23.7255581, 90.3693335, N'Loggedon nill', 1, 26)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'27', N'Government Laboratory High School', N'গভর্নমেন্ট ল্যাবরেটরি হাই স্কুল', 23.736158, 90.3794433, N'Loggedon nill', 1, 27)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'28', N'Mirpur Government Boys High School', N'মিরপুর সরকারি বালক উচ্চ বিদ্যালয়', 23.799193, 90.352812, N'Loggedon nill', 1, 28)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'29', N'Abed halima Islamia Dakhil Madrasa', N' আবেদ হালিমা ইসলামিয়া দাখিল মাদ্রাসা', 23.740385, 90.43367, N'Loggedon nill', 0, 29)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'30', N'Manikdi Al Islah Girls Dakhil Madrasah', N'মানিকদী আল ইসলাহ মহিলা দাখিল মাদ্রাসা', 23.826002, 90.391906, N'Loggedon nill', 1, 30)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'31', N'Begum Ayesha Pilot Girls High School', N'বেগম আয়েশা পাইলট বালিকা উচ্চ বিদ্যালয়', 23.6168334, 90.1186127, N'Loggedon nill', 1, 31)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'32', N'Shakta High School', N'শাক্তা উচ্চ বিদ্যালয়', 23.6977666, 90.3315505, N'Loggedon nill', 1, 32)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'33', N'Abdus Sobhan Model High School', N'আব্দুস সোবহান মডেল হাই স্কুল', 23.913582, 90.211181, N'Loggedon nill', 1, 33)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'34', N'Nawabgonj Pilot High School ', N'নবাবগঞ্জ পাইলট উচ্চ বিদ্যালয় ও কলেজ', 23.6627299, 90.1593306, N'Loggedon nill', 1, 34)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'35', N'Nabakumar Institution', N'নবকুমার ইন্সটিটিউশন', 23.721104, 90.3933421, N'Loggedon nill', 0, 35)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'36', N'Islamia Government High School', N'ইসলামিয়া সরকারি উচ্চ বিদ্যালয়', 23.7101914, 90.4111142, N'Loggedon nill', 1, 36)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'37', N'Bhakurta Union High School & College', N'ভাকুর্তা ইউনিয়ন উচ্চ বিদ্যালয় এবং কলেজ', 23.7667748, 90.2885587, N'Loggedon nill', 0, 37)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'38', N'Model Academy School', N'মডেল একাডেমী স্কুল', 23.7866362, 90.3521646, N'Loggedon nill', 1, 38)
INSERT [dbo].[Location] ([ILCID], [ILCEng], [ILCName], [Latitude], [Longitude], [UserStatus], [CStatus], [RecNo]) VALUES (N'39', N'Darul Falah Salehia Shaheb Ali Alim Madrasah', N'দারুল ফালাহ সালেহিয়া সাহেব আলী আলিম মাদ্রাসা', 23.8964656, 90.3825534, N'Loggedon nill', 0, 39)
SET IDENTITY_INSERT [dbo].[Location] OFF
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_UserStatus]  DEFAULT ('Loggedon nill') FOR [UserStatus]
GO
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_CStatus]  DEFAULT ((0)) FOR [CStatus]
GO
USE [master]
GO
ALTER DATABASE [ILCDB] SET  READ_WRITE 
GO
