/* 
Create a function that counts and returns how many invoices a vendor 
has (vendorID is a parameter)
If the vendor does not exist, function  returns -1
Test it for the following vendor IDs: 
34 -> 2
48 -> 1
15 -> 0
999 -> -1
*/

USE AP;
GO
IF OBJECT_ID('fnInvoicesPerVendor') IS NOT NULL
	DROP FUNCTION fnInvoicesPerVendor;
GO 

CREATE OR ALTER FUNCTION fnInvoicesPerVendor(@VendorID INT)
	RETURNS INT
AS
BEGIN
	DECLARE @Result INT
	-- Checking first if a given VendorID exists:
	IF (SELECT TOP 1 Vendors.VendorID -- TOP 1 ensures that only 1 value is returned
		FROM Vendors LEFT JOIN Invoices -- LEFT JOIN ensures that no vendor is lost, which is
										-- critical for Vendors with no corresponding Invoices
			ON Vendors.VendorID = Invoices.VendorID
		WHERE Vendors.VendorID = @VendorID) IS NOT NULL
		BEGIN		
			SELECT @Result = COUNT(Invoices.InvoiceID)
			FROM Vendors JOIN Invoices
				ON Vendors.VendorID = Invoices.VendorID
			WHERE Vendors.VendorID = @VendorID
		END;
	ELSE SELECT @Result = -1; -- It's the case for non-existing VendorID
	RETURN @Result;
END;
GO

PRINT 'Number of invoices for the chosen vendor #34 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoicesPerVendor('34'));
GO

PRINT 'Number of invoices for the chosen vendor #48 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoicesPerVendor(48));
GO

PRINT 'Number of invoices for the chosen vendor #15 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoicesPerVendor(15));
GO

PRINT 'Number of invoices for the chosen vendor #999 is ' + 
		CONVERT(VARCHAR, dbo.fnInvoicesPerVendor(999));
GO

/*
-- This query shows how multiple identical VendorIDs can be returned without TOP-1:
SELECT Vendors.VendorID 
FROM Vendors LEFT JOIN Invoices
	ON Vendors.VendorID = Invoices.VendorID
WHERE Vendors.VendorID = 34
*/