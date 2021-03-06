/****** This SQL script creates the Group1Books database on SQL Server ******/

IF DB_ID('MyWebDB') IS NOT NULL
	DROP DATABASE MyWebDB
GO	
CREATE DATABASE MyWebDB
GO

USE MyWebDB
GO

/****** Create Products table ******/
SET ANSI_NULLS ON
/* When SET ANSI_NULLS is ON, a SELECT statement that uses WHERE 
column_name = NULL returns zero rows even if there are null values 
in column_name. A SELECT statement that uses WHERE column_name <> NULL 
returns zero rows even if there are non-null values in column_name.*/
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NOT NULL)
 

/****** Create Users table ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL)
GO

/****** Create Downloads table ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Downloads](
	DownloadID [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UserID [int] NOT NULL,
	DownloadDate [Date] NOT NULL,
	[FileName] [varchar](50) NOT NULL,
	ProductID [int] NOT NULL,
	FOREIGN KEY (UserID)
    REFERENCES Users(UserID),
	FOREIGN KEY (ProductID)
    REFERENCES Products(ProductID))
GO

-- Inserting rows into the Users table
INSERT INTO Users
(EmailAddress, FirstName, LastName)
Values
('janedoe@gmail.com', 'Jane', 'Doe'),
('johndoe@yahoo.com', 'John', 'Doe'),
('jimkerry@gmail.com', 'Jim', 'Kerry'),
('tomjones@hotmail.com', 'Tom', 'Jones')


-- Inserting rows into the Products table
INSERT INTO Products
(ProductName)
Values
('Local Music Vol 1'),
('Local Music Vol 7'),
('Local Music Vol 17'),
('Local Music Vol 12');

-- Inserting rows into the Downloads table
INSERT INTO Downloads
(UserID, DownloadDate, [FileName], ProductID)
Values
(1, '2022-01-13', 'Petals Are Falling.mp3', 2),
(3, '2022-01-11', 'Turn The Page.mp3', 1),
(2, '2022-01-12', 'Unforgiven.mp3', 3),
(4, '2022-01-13', 'Nothing Else Matters.mp3', 4);

-- SELECT * query for each table:
SELECT * from Users;
SELECT * from Downloads;
SELECT * from Products;

-- SELECT query that joins all three tables as in the example:
SELECT EmailAddress, FirstName, LastName, DownloadDate, 
		[FileName], ProductName
FROM Users JOIN Downloads ON Users.UserID = Downloads.DownloadID
	JOIN Products ON Products.ProductID = Downloads.ProductID