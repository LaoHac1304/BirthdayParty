USE [master]
GO
/****** Object:  Database [PartyDB]    Script Date: 2/19/2024 11:39:19 AM ******/
CREATE DATABASE [PartyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PartyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LAOHAC\MSSQL\DATA\PartyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PartyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LAOHAC\MSSQL\DATA\PartyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PartyDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PartyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PartyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PartyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PartyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PartyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PartyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PartyDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PartyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PartyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PartyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PartyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PartyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PartyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PartyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PartyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PartyDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PartyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PartyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PartyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PartyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PartyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PartyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PartyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PartyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PartyDB] SET  MULTI_USER 
GO
ALTER DATABASE [PartyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PartyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PartyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PartyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PartyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PartyDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PartyDB] SET QUERY_STORE = OFF
GO
USE [PartyDB]
GO
/****** Object:  Table [dbo].[account]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[role] [nvarchar](255) NULL,
	[phone_number] [nvarchar](255) NULL,
	[full_name] [nvarchar](255) NULL,
	[image_url] [nvarchar](255) NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [uniqueidentifier] NOT NULL,
	[user_id] [uniqueidentifier] NULL,
	[day_of_birth] [datetime2](6) NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[discount]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[discount](
	[id] [uniqueidentifier] NOT NULL,
	[discount_percent] [decimal](18, 0) NULL,
	[status] [nvarchar](255) NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[host_party]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[host_party](
	[id] [uniqueidentifier] NOT NULL,
	[description] [nvarchar](255) NULL,
	[rating] [nvarchar](255) NULL,
	[user_id] [uniqueidentifier] NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL,
	[price] [decimal](18, 0) NULL,
	[party_package_id] [uniqueidentifier] NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[message]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[message](
	[id] [uniqueidentifier] NOT NULL,
	[content] [nvarchar](255) NULL,
	[sender_id] [uniqueidentifier] NULL,
	[receiver_id] [uniqueidentifier] NULL,
	[status] [nvarchar](255) NULL,
	[sent_at] [datetime2](6) NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_detail]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_detail](
	[id] [uniqueidentifier] NOT NULL,
	[total_price] [decimal](18, 0) NULL,
	[date] [datetime2](6) NULL,
	[customer_id] [uniqueidentifier] NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_items]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_items](
	[id] [uniqueidentifier] NOT NULL,
	[price] [decimal](18, 0) NULL,
	[date] [datetime2](6) NULL,
	[party_package_id] [uniqueidentifier] NULL,
	[order_detail_id] [uniqueidentifier] NULL,
	[is_preorder] [bit] NULL,
	[status] [nvarchar](255) NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[party_package]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[party_package](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL,
	[location] [nvarchar](255) NULL,
	[image_url] [nvarchar](255) NULL,
	[available_dates] [datetime2](6) NULL,
	[host_party_id] [uniqueidentifier] NULL,
	[status] [nvarchar](255) NULL,
	[price] [int] NULL,
	[discount_id] [uniqueidentifier] NULL,
	[available_for_preorder] [bit] NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_detail]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_detail](
	[id] [uniqueidentifier] NOT NULL,
	[provider] [nvarchar](255) NULL,
	[amount] [int] NULL,
	[order_detail_id] [uniqueidentifier] NULL,
	[status] [nvarchar](255) NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post]    Script Date: 2/19/2024 11:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
	[id] [uniqueidentifier] NOT NULL,
	[content] [nvarchar](255) NULL,
	[date] [datetime2](6) NULL,
	[image_url] [nvarchar](255) NULL,
	[party_package_id] [uniqueidentifier] NULL,
	[created_at] [datetime2](6) NULL,
	[updated_at] [datetime2](6) NULL,
	[is_deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[account] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[discount] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[discount] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[discount] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[discount] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[host_party] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[host_party] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[host_party] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[host_party] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[menu] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[menu] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[menu] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[menu] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[message] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[message] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[message] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[message] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[order_detail] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[order_detail] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[order_detail] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[order_detail] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[order_items] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[order_items] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[order_items] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[order_items] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[party_package] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[party_package] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[party_package] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[party_package] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[payment_detail] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[payment_detail] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[payment_detail] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[payment_detail] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT (getutcdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT (getutcdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[post] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[host_party]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[menu]  WITH CHECK ADD FOREIGN KEY([party_package_id])
REFERENCES [dbo].[party_package] ([id])
GO
ALTER TABLE [dbo].[menu]  WITH CHECK ADD FOREIGN KEY([party_package_id])
REFERENCES [dbo].[party_package] ([id])
GO
ALTER TABLE [dbo].[message]  WITH CHECK ADD FOREIGN KEY([receiver_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[message]  WITH CHECK ADD FOREIGN KEY([sender_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[order_items]  WITH CHECK ADD FOREIGN KEY([order_detail_id])
REFERENCES [dbo].[order_detail] ([id])
GO
ALTER TABLE [dbo].[order_items]  WITH CHECK ADD FOREIGN KEY([order_detail_id])
REFERENCES [dbo].[order_detail] ([id])
GO
ALTER TABLE [dbo].[order_items]  WITH CHECK ADD FOREIGN KEY([party_package_id])
REFERENCES [dbo].[party_package] ([id])
GO
ALTER TABLE [dbo].[order_items]  WITH CHECK ADD FOREIGN KEY([party_package_id])
REFERENCES [dbo].[party_package] ([id])
GO
ALTER TABLE [dbo].[party_package]  WITH CHECK ADD FOREIGN KEY([discount_id])
REFERENCES [dbo].[discount] ([id])
GO
ALTER TABLE [dbo].[party_package]  WITH CHECK ADD FOREIGN KEY([host_party_id])
REFERENCES [dbo].[host_party] ([id])
GO
ALTER TABLE [dbo].[party_package]  WITH CHECK ADD FOREIGN KEY([host_party_id])
REFERENCES [dbo].[host_party] ([id])
GO
ALTER TABLE [dbo].[payment_detail]  WITH CHECK ADD FOREIGN KEY([order_detail_id])
REFERENCES [dbo].[order_detail] ([id])
GO
ALTER TABLE [dbo].[payment_detail]  WITH CHECK ADD FOREIGN KEY([order_detail_id])
REFERENCES [dbo].[order_detail] ([id])
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD FOREIGN KEY([party_package_id])
REFERENCES [dbo].[party_package] ([id])
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD FOREIGN KEY([party_package_id])
REFERENCES [dbo].[party_package] ([id])
GO
USE [master]
GO
ALTER DATABASE [PartyDB] SET  READ_WRITE 
GO
