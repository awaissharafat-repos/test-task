USE [master]
GO
/****** Object:  Database [MyTestDatabase]    Script Date: 2/1/2025 12:35:39 PM ******/
CREATE DATABASE [MyTestDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyTestDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyTestDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyTestDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyTestDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyTestDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyTestDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyTestDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyTestDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyTestDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyTestDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyTestDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyTestDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyTestDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyTestDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyTestDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyTestDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyTestDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyTestDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyTestDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyTestDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyTestDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyTestDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyTestDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyTestDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyTestDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyTestDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyTestDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyTestDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyTestDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyTestDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [MyTestDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyTestDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyTestDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyTestDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyTestDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyTestDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyTestDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyTestDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyTestDatabase]
GO
/****** Object:  Table [dbo].[SYS_Products]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SYS_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_UserDetails]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_UserDetails](
	[UserDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_SYS_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_Users]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [varbinary](32) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SYS_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SYS_Products] ON 

INSERT [dbo].[SYS_Products] ([ProductId], [Name], [Price], [Quantity], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, N'Test Product 1', CAST(1.00 AS Decimal(18, 2)), 2, 0, CAST(N'2025-01-31T13:34:44.417' AS DateTime), 1, CAST(N'2025-01-31T20:18:28.017' AS DateTime), 1)
INSERT [dbo].[SYS_Products] ([ProductId], [Name], [Price], [Quantity], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (6, N'Test Product 2', CAST(2.30 AS Decimal(18, 2)), 2, 1, CAST(N'2025-01-31T19:46:58.567' AS DateTime), 1, CAST(N'2025-01-31T19:48:03.097' AS DateTime), 1)
INSERT [dbo].[SYS_Products] ([ProductId], [Name], [Price], [Quantity], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (7, N'Test Product 3', CAST(1.00 AS Decimal(18, 2)), 1, 1, CAST(N'2025-01-31T20:17:57.053' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[SYS_Products] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_UserDetails] ON 

INSERT [dbo].[SYS_UserDetails] ([UserDetailId], [UserId], [FirstName], [LastName], [DOB], [Phone], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, N'Awais', N'Sharafat', CAST(N'1992-08-20' AS Date), N'+923124155946', 1, CAST(N'2025-01-31T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[SYS_UserDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[SYS_Users] ON 

INSERT [dbo].[SYS_Users] ([UserId], [Email], [Password], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, N'awaissharafat@gmail.com', 0xDAF26EE06BCC48562CBC134B1070158F6D3535076984AD28D3CD98C54E9CE666, 1, CAST(N'2025-01-31T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[SYS_Users] ([UserId], [Email], [Password], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, N'awaissharafat1@gmail.com', 0xDAF26EE06BCC48562CBC134B1070158F6D3535076984AD28D3CD98C54E9CE666, 1, CAST(N'2025-01-31T00:45:23.517' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[SYS_Users] OFF
GO
/****** Object:  Index [Email_SYS_Users]    Script Date: 2/1/2025 12:35:39 PM ******/
ALTER TABLE [dbo].[SYS_Users] ADD  CONSTRAINT [Email_SYS_Users] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYS_Products] ADD  CONSTRAINT [DF_SYS_Products_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SYS_Users] ADD  CONSTRAINT [DF_SYS_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SYS_UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_SYS_UserDetails_SYS_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[SYS_Users] ([UserId])
GO
ALTER TABLE [dbo].[SYS_UserDetails] CHECK CONSTRAINT [FK_SYS_UserDetails_SYS_Users]
GO
/****** Object:  StoredProcedure [dbo].[sproc_DeleteProduct]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sproc_DeleteProduct]
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SYS_Products]
	SET IsActive = 0
    WHERE 
        [ProductId] = @ProductId;
END
GO
/****** Object:  StoredProcedure [dbo].[sproc_GetAllProducts]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sproc_GetAllProducts]
	@Name NVARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [ProductId],
        [Name],
        [Price],
        [Quantity],
        [CreatedBy],
        [CreatedDate],
        [ModifiedBy],
        [ModifiedDate]
    FROM 
        [dbo].[SYS_Products]
	WHERE
		IsActive = 1
		AND (@Name IS NULL OR [Name] Like '%' + @Name + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[sproc_GetProductById]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sproc_GetProductById]
	@ProductId int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [ProductId],
        [Name],
        [Price],
        [Quantity],
        [CreatedBy],
        [CreatedDate],
        [ModifiedBy],
        [ModifiedDate]
    FROM 
        [dbo].[SYS_Products]
	WHERE
		ProductId = @ProductId
END
GO
/****** Object:  StoredProcedure [dbo].[sproc_InsertProduct]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sproc_InsertProduct]
    @ProductId INT,
    @Name NVARCHAR(250),
    @Price DECIMAL(18, 2),
    @Quantity INT,
    @CreatedBy INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @ProductId = 0
    BEGIN
        INSERT INTO [dbo].[SYS_Products] 
            ([Name], [Price], [Quantity], [CreatedBy], [CreatedDate], [IsActive])
        VALUES 
            (@Name, @Price, @Quantity, @CreatedBy, GETUTCDATE(), 1)
    END
    ELSE
    BEGIN
        UPDATE [dbo].[SYS_Products]
        SET 
            [Name] = @Name,
            [Price] = @Price,
            [Quantity] = @Quantity,
            [ModifiedBy] = @CreatedBy,
            [ModifiedDate] = GETUTCDATE()
        WHERE 
            ProductId = @ProductId
    END

END
GO
/****** Object:  StoredProcedure [dbo].[sproc_UserLogin]    Script Date: 2/1/2025 12:35:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sproc_UserLogin] 
    @Email NVARCHAR(250),
    @Password VARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;


    SELECT 
        UR.UserId,
		UR.Email,
		UR.IsActive,
		UD.UserDetailId,
        UD.FirstName,
        UD.LastName,
        UD.DOB,
        UD.Phone
    FROM 
        SYS_Users UR INNER JOIN 
        SYS_UserDetails UD ON UR.UserId = UD.UserId
    WHERE 
        UR.Email = @Email 
		AND UR.[Password] = HASHBYTES('SHA2_256', @Password)

END
GO
USE [master]
GO
ALTER DATABASE [MyTestDatabase] SET  READ_WRITE 
GO
