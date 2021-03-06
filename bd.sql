USE [master]
GO
/****** Object:  Database [ServiceDB]    Script Date: 20.07.2021 5:23:51 ******/
CREATE DATABASE [ServiceDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ServiceDB', FILENAME = N'E:\Program Files\MSSQL15.SQLEXPRESS\MSSQL\DATA\ServiceDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ServiceDB_log', FILENAME = N'E:\Program Files\MSSQL15.SQLEXPRESS\MSSQL\DATA\ServiceDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ServiceDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ServiceDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ServiceDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServiceDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServiceDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServiceDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServiceDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServiceDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ServiceDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServiceDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServiceDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServiceDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServiceDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServiceDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServiceDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServiceDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServiceDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ServiceDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServiceDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServiceDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServiceDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServiceDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServiceDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServiceDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServiceDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ServiceDB] SET  MULTI_USER 
GO
ALTER DATABASE [ServiceDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServiceDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServiceDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServiceDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ServiceDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ServiceDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ServiceDB] SET QUERY_STORE = OFF
GO
USE [ServiceDB]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[phonNumber] [nvarchar](50) NOT NULL,
	[comment] [text] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[phonNumber] [nvarchar](50) NULL,
	[comment] [text] NULL,
	[perm] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idClient] [int] NOT NULL,
	[status] [int] NOT NULL,
	[dateCreation] [date] NOT NULL,
	[device] [nvarchar](50) NOT NULL,
	[equipment] [nvarchar](50) NOT NULL,
	[comment] [text] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Password]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Password](
	[idEmployee] [int] NOT NULL,
	[passHash] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[IdEmployee] [int] NOT NULL,
	[passHash] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[idOrder] [int] NOT NULL,
	[idEmployee] [int] NOT NULL,
	[price] [money] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[comment] [text] NULL,
	[dateCreation] [date] NOT NULL,
	[termTicks] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client1] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client1]
GO
ALTER TABLE [dbo].[Work]  WITH CHECK ADD  CONSTRAINT [FK_Work_Order] FOREIGN KEY([idOrder])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Work] CHECK CONSTRAINT [FK_Work_Order]
GO
/****** Object:  StoredProcedure [dbo].[AddClient]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddClient]
			@name nvarchar(50)
           ,@phonNumber nvarchar(50)
           ,@comment text
as
INSERT INTO [dbo].[Client]
           ([name]
           ,[phonNumber]
           ,[comment])

     VALUES
           (@name
           ,@phonNumber 
           ,@comment)
Select scope_identity();
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEmployee]
			@name nvarchar(50)
			,@phonNumber nvarchar(50)
			,@comment text
			,@passHash text
			,@perm int
		   as
INSERT INTO [dbo].[Employee]
           ([name]
           ,[phonNumber]
           ,[comment]
		   ,[perm])
     VALUES
           (@name
			,@phonNumber
			,@comment
			,@perm)

DECLARE @lastID INT;
SET @lastID = scope_identity();


INSERT INTO [dbo].[Password]
([IdEmployee] 
,[passHash])
VALUES
(@lastID,@passHash)

Select @lastID
GO
/****** Object:  StoredProcedure [dbo].[AddOrder]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddOrder]
           @idClient int
          ,@status int
           
           ,@dateCreation date
           ,@device nvarchar(50)
          ,@equipment nvarchar(50)
           ,@comment text
as
INSERT INTO [dbo].[Order]
           ([idClient]
           ,[status]
           
           ,[dateCreation]
           ,[device]
           ,[equipment]
           ,[comment])
     VALUES
           (@idClient
          ,@status
           
           ,@dateCreation
           ,@device
          ,@equipment
           ,@comment)
GO
/****** Object:  StoredProcedure [dbo].[AddWork]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddWork]
            @idOrder int
           ,@idEmployee int 
           ,@price int
           ,@name nvarchar(50)
           ,@comment nvarchar(50)
           ,@dateCreation date 
           ,@termTicks bigint
as
INSERT INTO [dbo].[Work]
           ([idOrder]
           ,[idEmployee]
           ,[price]
           ,[name]
           ,[comment]
           ,[dateCreation]
           ,[termTicks])
     VALUES
           ( @idOrder 
           ,@idEmployee 
           ,@price 
           ,@name
           ,@comment
           ,@dateCreation 
           ,@termTicks)
GO
/****** Object:  StoredProcedure [dbo].[GetClient]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClient] 
@id int
as
SELECT [id]
      ,[name]
      ,[phonNumber]
      ,[comment]
  FROM [dbo].[Client]
    WHERE [id] =@id

GO
/****** Object:  StoredProcedure [dbo].[GetClients]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[GetClients] 
as
SELECT [id]
      ,[name]
      ,[phonNumber]
      ,[comment]
  FROM [dbo].[Client]

GO
/****** Object:  StoredProcedure [dbo].[GetEmployee]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployee]
@id int
as
SELECT [id]
      ,[name]
      ,[phonNumber]
      ,[comment]
	  ,[perm]
  FROM [dbo].[Employee]
  WHERE [id] =@id
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeByName]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetEmployeeByName]
@name nvarchar(50)
as
SELECT [id]
      ,[name]
      ,[phonNumber]
      ,[comment]
	  ,[perm]
  FROM [dbo].[Employee]
  WHERE [name] =@name
GO
/****** Object:  StoredProcedure [dbo].[GetEmployees]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployees]
as
SELECT [id]
      ,[name]
      ,[phonNumber]
      ,[comment]
	  ,[perm]
  FROM [dbo].[Employee]
GO
/****** Object:  StoredProcedure [dbo].[GetOrder]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrder]
@id int
as
SELECT [id]
      ,[idClient]
      ,[status]      
      ,[dateCreation]
      ,[device]
      ,[equipment]
      ,[comment]
  FROM [dbo].[Order]
  WHERE [id] =@id
GO
/****** Object:  StoredProcedure [dbo].[GetOrders]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetOrders]
as
SELECT [id]
      ,[idClient]
      ,[status]      
      ,[dateCreation]
      ,[device]
      ,[equipment]
      ,[comment]
  FROM [dbo].[Order]
  ORDER BY [id] DESC
GO
/****** Object:  StoredProcedure [dbo].[GetOrdersFrom]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetOrdersFrom]
@idFrom int,
@count int
as


SELECT TOP(@count)
	[id]
	,[idClient]
	,[status]	
	,[dateCreation]
	,[device]
	,[equipment]
	,[comment]
FROM [dbo].[Order] Where [id]< @idFrom 


GO
/****** Object:  StoredProcedure [dbo].[GetOrdersFromIdToId]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetOrdersFromIdToId]
@FromId int,
@ToId int
as
SELECT [id]
      ,[idClient]
      ,[status]      
      ,[dateCreation]
      ,[device]
      ,[equipment]
      ,[comment]
  FROM [dbo].[Order]
  WHERE [id]>@FromId and [id]<@FromId
GO
/****** Object:  StoredProcedure [dbo].[GetPassHash]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetPassHash]
@IdEmployee int
as
SELECT 
      [passHash]
FROM [dbo].[Password]
WHERE [idEmployee] = @IdEmployee
GO
/****** Object:  StoredProcedure [dbo].[SearchWorkByName]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SearchWorkByName]
@name nvarchar(50)
as
SELECT [idOrder]
      ,[idEmployee]
      ,[price]
      ,[name]
      ,[comment]
      ,[dateCreation]
      ,[termTicks]
  FROM [dbo].[Work]
  WHERE [name] LIKE @name
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateOrder] 
			@id int 
          , @idClient int
          ,@status int           
           ,@dateCreation date
           ,@device nvarchar(50)
          ,@equipment nvarchar(50)
           ,@comment text
as
UPDATE [dbo].[Order]
   SET [idClient] = @idClient
      ,[status] = @status
      ,[dateCreation] = @dateCreation
      ,[device] = @device
      ,[equipment] = @equipment
      ,[comment] = @comment
 WHERE [id]=@id
GO
/****** Object:  StoredProcedure [dbo].[WorkIn]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[WorkIn] 
@name nvarchar(50)
as
SELECT [idOrder]
      ,[idEmployee]
      ,[price]
      ,[name]
      ,[comment]
      ,[dateCreation]
      ,[termTicks]
  FROM [dbo].[Work]
  WHERE [name] LIKE @name
GO
/****** Object:  StoredProcedure [dbo].[WorkInOrder]    Script Date: 20.07.2021 5:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[WorkInOrder] 
@idOrder int
as
SELECT [idOrder]
      ,[idEmployee]
      ,[price]
      ,[name]
      ,[comment]
      ,[dateCreation]
      ,[termTicks]
  FROM [dbo].[Work]
  WHERE @idOrder=[idOrder]
  ORDER By dateCreation
GO
USE [master]
GO
ALTER DATABASE [ServiceDB] SET  READ_WRITE 
GO
