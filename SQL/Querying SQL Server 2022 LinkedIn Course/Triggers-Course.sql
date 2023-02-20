USE KinetEcoTRG
GO

CREATE TABLE dbo.Products(
	ProductID INT PRIMARY KEY,
	ProductName NVARCHAR(50)
);
GO

INSERT INTO dbo.Products
VALUES
	(5, 'D Battery'),
	(6, 'AA Rechargeable Battery')
GO

CREATE OR ALTER TRIGGER dbo.tr_ProductsInsert
ON dbo.Products
AFTER INSERT
AS
BEGIN
	PRINT 'New product data has been inserted.'
END;
GO

SELECT * FROM dbo.Products;

CREATE TABLE dbo.Customers(
	CustomerID INT PRIMARY KEY,
	CustomerName NVARCHAR(50),
	LastModified datetime2
);
GO

CREATE OR ALTER TRIGGER dbo.tr_CustomersInsertUpdate
ON dbo.Customers
AFTER INSERT, UPDATE
AS
BEGIN
	SET NOCOUNT ON

	UPDATE dbo.Customers
	SET LastModified = GETDATE()
	FROM Inserted
	WHERE dbo.Customers.CustomerID = Inserted.CustomerID
END;
GO

INSERT INTO dbo.Customers (CustomerID, CustomerName)
VALUES
	(5, 'Jeff')
;
GO

SELECT * FROM Customers;

UPDATE dbo.Customers
SET CustomerName = 'Jim'
WHERE CustomerID = 1;
GO

INSERT INTO dbo.Customers (CustomerID, CustomerName)
VALUES
	(2, 'Tina'),
	(3, 'Mark')
;
GO

CREATE TABLE dbo.AccountsPayable (
	AccountID INT PRIMARY KEY IDENTITY,
	AccountNumber NVARCHAR(20)
);
GO

INSERT INTO dbo.AccountsPayable (AccountNumber)
	VALUES ('98016'),('32408'),('32984')
GO 

SELECT * FROM dbo.AccountsPayable;
GO

CREATE OR ALTER TRIGGER tr_AccountsPayableDelete
ON dbo.AccountsPayable
INSTEAD OF DELETE
AS
PRINT 'Delete operations are not allowed for the AccountsPayable database table.'
PRINT 'To delete a record, delete the trigger first.'
ROLLBACK;
GO

DELETE FROM dbo.AccountsPayable
WHERE AccountID = 1;
GO

