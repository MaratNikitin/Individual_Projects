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

CREATE TABLE dbo.Colors (
	ColorID INT IDENTITY PRIMARY KEY,
	ColorName NVARCHAR(20)
);
GO

CREATE OR ALTER TRIGGER DBO.TR_ColorsInsertUpdateDelete
ON dbo.Colors
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SELECT * FROM inserted;
	SELECT * FROM deleted;
END;
GO

INSERT INTO dbo.Colors (ColorName)
	VALUES ('Red'), ('Green'), ('Blue')
;

UPDATE dbo.Colors
SET ColorName = 'Yellow'
WHERE ColorID = 3;

DELETE FROM dbo.Colors
WHERE ColorID = 2;

SELECT * FROM Colors
GO

CREATE TABLE dbo.NumberParity (
	RowID INT IDENTITY PRIMARY KEY,
	MyNumber INT,
	Parity NVARCHAR(20)
);
GO

CREATE OR ALTER TRIGGER DBO.tr_NumberParityInsert
ON dbo.NumberParity
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.NumberParity
		SET Parity = 'Even Number'
		FROM inserted
		WHERE dbo.NumberParity.RowID = inserted.RowID
			AND inserted.MyNumber % 2 = 0;

	UPDATE dbo.NumberParity
	SET Parity = 'Odd Number'
	FROM inserted
	WHERE dbo.NumberParity.RowID = inserted.RowID
		AND inserted.MyNumber % 2 <> 0;
END;
GO

INSERT INTO dbo.NumberParity (MyNumber)
	VALUES (12), (23), (16), (22), (43)
;

SELECT * FROM dbo.NumberParity

INSERT INTO dbo.NumberParity (MyNumber, Parity)
	VALUES (99, 'Even Number')
;
GO

CREATE TABLE dbo.Vendor (
	VendorID INT IDENTITY PRIMARY KEY,
	VendorName NVARCHAR(50),
);
GO

CREATE TABLE dbo.VendorArchive (
	VendorID INT PRIMARY KEY,
	VendorName NVARCHAR(50),
	DateArchived DATETIME2
);
GO

INSERT INTO dbo.Vendor (VendorName)
	VALUES ('KinetEco');
GO

SELECT * FROM dbo.Vendor;
GO

SELECT * FROM dbo.VendorArchive;
GO

CREATE OR ALTER TRIGGER DBO.tr_VendorDelete
ON dbo.Vendor
AFTER DELETE
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO VendorArchive (VendorID, VendorName)
		SELECT deleted.VendorId, deleted.VendorName
		FROM deleted;

	UPDATE VendorArchive
		SET DateArchived = GETDATE()
		FROM deleted
		WHERE VendorArchive.VendorID = deleted.VendorID

END;
GO

DELETE FROM dbo.Vendor
	WHERE VendorID = 1;

