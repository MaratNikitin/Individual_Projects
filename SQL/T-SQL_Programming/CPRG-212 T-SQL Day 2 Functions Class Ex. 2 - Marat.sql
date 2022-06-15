/* 
2.1. Create a function fnInvoiceBalance that, given InvoiceID, returns balance
for that invoice (balance is InvoiceTotal – PaymentTotal – CreditTotal). 
If the invoice does not exist, it returns 0.
*/

USE AP;
GO
IF OBJECT_ID('fnInvoiceBalance') IS NOT NULL
	DROP FUNCTION fnInvoiceBalance;
GO 

CREATE OR ALTER FUNCTION fnInvoiceBalance(@InvoiceID INT)
	RETURNS MONEY
AS
BEGIN
	DECLARE @Result MONEY
	IF (SELECT InvoiceID
		FROM Invoices
		WHERE InvoiceID = @InvoiceID) IS NOT NULL
		BEGIN		
			SELECT @Result = InvoiceTotal - PaymentTotal - CreditTotal
			FROM Invoices
			WHERE InvoiceID = @InvoiceID
		END;
	ELSE SELECT @Result = 0;
	RETURN @Result;
END;
GO

PRINT 'Balance for the invoice #1 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoiceBalance('1'));
GO

PRINT 'Balance for the invoice #100 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoiceBalance('100'));
GO

PRINT 'Balance for the invoice #102 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoiceBalance('102'));
GO

PRINT 'Balance for the invoice #106 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoiceBalance('106'));
GO


-- Checking the results:
SELECT InvoiceTotal - PaymentTotal - CreditTotal AS InvoiceBalance
FROM Invoices
WHERE InvoiceID IN (1, 100, 102, 106)


/* 
2.2. Create a function fnVendorBalance that receives VendorID and calls fnInvoiceBalance 
to calculate balance due for the given vendor (sum of balance due of all invoices 
for this vendor’s)
*/

USE AP;
IF OBJECT_ID('fnVendorBalance') IS NOT NULL
	DROP FUNCTION fnVendorBalance;
GO 

CREATE OR ALTER FUNCTION fnVendorBalance(@VendorID INT)
	RETURNS MONEY
AS
BEGIN
	DECLARE @Result MONEY
	SELECT @Result = SUM(InvoiceTotal - PaymentTotal - CreditTotal)
	-- Inserting fnInvoiceBalance inside SUM() would make this code super complicated
	FROM Vendors JOIN Invoices
		ON Vendors.VendorID = Invoices.VendorID
	WHERE Vendors.VendorID = @VendorID
	RETURN @Result;
END;
GO

PRINT 'Balance due for the vendor #34 is ' + 
		CONVERT(VARCHAR, dbo.fnVendorBalance(34));
GO

PRINT 'Balance due for the vendor #37 is ' + 
		CONVERT(VARCHAR, dbo.fnVendorBalance(37));
GO

PRINT 'Balance due for the vendor #72 is ' + 
		CONVERT(VARCHAR, dbo.fnVendorBalance(72));
GO

PRINT 'Balance due for the vendor #123 is ' + 
		CONVERT(VARCHAR, dbo.fnVendorBalance(123));
GO

-- For checking the results:
SELECT Vendors.VendorID, SUM(InvoiceTotal - PaymentTotal - CreditTotal) AS "Balance Due"
FROM Vendors JOIN Invoices
			ON Vendors.VendorID = Invoices.VendorID
WHERE Vendors.VendorID IN (34, 37, 72, 123)
GROUP BY Vendors.VendorID



/*
-- Why using a function is a problem (vendors can have many invoices):
SELECT Invoices.InvoiceID
FROM Vendors JOIN Invoices ON Vendors.VendorID = Invoices.VendorID
WHERE Vendors.VendorID = 37
*/