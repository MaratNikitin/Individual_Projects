/* 
Create and test a procedure that accepts state as a parameter @StateVar 
and has another parameter @VendorCount which is OUTPUT
The procedure sets @VendorCount to the count of vendors in  this state
Test it  for states:
‘CA’ -> 75
‘FL’ -> 1
*/

USE AP;
GO
IF OBJECT_ID('uspCountVendorsInState') IS NOT NULL
	DROP PROCEDURE uspCountVendorsInState;
GO 

-- Creating procedure:
CREATE OR ALTER PROCEDURE uspCountVendorsInState
	@StateVar VARCHAR(2)
	, @VendorCount INT OUTPUT
AS
SELECT @VendorCount = COUNT(VendorID) 
FROM Vendors
WHERE VendorState = @StateVar;
GO

-- Executing the procedure for VendorState = 'CA':
DECLARE @VendorCount INT
EXECUTE uspCountVendorsInState 'CA', @VendorCount OUTPUT
PRINT 'Vendors count in CA: ' + CONVERT(VARCHAR, @VendorCount);
GO

-- Executing the procedure for VendorState = 'FL':
DECLARE @VendorCount INT
EXECUTE uspCountVendorsInState 'FL', @VendorCount OUTPUT
PRINT 'Vendors count in FL: ' + CONVERT(VARCHAR, @VendorCount);
GO
