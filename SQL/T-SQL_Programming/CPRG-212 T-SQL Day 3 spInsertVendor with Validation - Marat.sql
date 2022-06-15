/* 
Write  a procedure spInsertVendor that insert a record into Vendors table
- VendorID is identity (procedure returns generated value)
- VendorAddress1, VendorAddress2, VendorPhone, VendorContactLName, 
	VendorContactFName can be null, but not other columns
- DefaultTermsID if not provided assume 1; validate if provided
- Default AccountNo if not provided assume 100 (Cash); validate if provided
*/

USE AP;
GO
 
IF OBJECT_ID('spInsertVendor') IS NOT NULL
    DROP PROC spInsertVendor;
GO

CREATE OR ALTER PROC spInsertVendor
    @VendorName			varchar(50) = NULL,
    @VendorAddress1		varchar(50) = NULL, -- can be NULL
    @VendorAddress2		varchar(50) = NULL, -- can be NULL
    @VendorCity			varchar(50) = NULL,
    @VendorState		char(2) = NULL,
    @VendorZipCode		varchar(20) = NULL,
    @VendorPhone		varchar(50) = NULL, -- can be NULL
    @VendorContactLName varchar(50) = NULL, -- can be NULL
	@VendorContactFName varchar(50) = NULL, -- can be NULL
	@DefaultTermsID		int = NULL,
	@DefaultAccountNo	int = NULL
AS

-- Checking if VendorName is entered (it's required)
IF @VendorName IS NULL
	THROW 50007, 'VendorName must be provided', 1;

-- Checking if VendorCity is entered (it's required)
IF @VendorCity IS NULL
	THROW 50007, 'VendorCity must be provided', 1;

-- Checking if VendorState is entered (it's required)
IF @VendorState IS NULL
	THROW 50007, 'VendorState must be provided', 1;

-- Checking if VendoZipCode is entered (it's required)
IF @VendorZipCode IS NULL
	THROW 50007, 'VendorZipCode must be provided', 1;

-- If DefaultTermsID is not provided, then a default value of 1 is set,
--	 otherwise, it's checked if the entered value of TermsID exists in DB:
IF @DefaultTermsID IS NULL
	SET @DefaultTermsID = 1;
ELSE -- DefaultTermsID is provided and should be validated
	IF NOT EXISTS (SELECT * FROM Terms WHERE TermsID = @DefaultTermsID)
		THROW 50007, 'Enter existing DefaultTermsID', 1

-- If DefaultAccountNo is not provided, then a default value of 100 is set,
--	 otherwise, it's checked if the entered value of AccountNo exists in DB:
IF @DefaultAccountNo IS NULL
	SET @DefaultAccountNo = 100;
ELSE -- DefaultAccountNo is provided and should be validated
	IF NOT EXISTS (SELECT * FROM GLAccounts WHERE AccountNo = @DefaultAccountNo)
		THROW 50007, 'Enter existing DefaultAccountNo', 1

-- Once all the validation is passed, we can insert values:
INSERT Vendors
VALUES (@VendorName, @VendorAddress1, @VendorAddress2, @VendorCity, @VendorState,
	@VendorZipCode, @VendorPhone, @VendorContactLName, @VendorContactFName, 
	@DefaultTermsID, @DefaultAccountNo);
RETURN @@IDENTITY;
GO

-- T-SQL script that calls the stored procedure:
BEGIN TRY
    DECLARE @VendorID INT;
    EXEC @VendorID = spInsertVendor
           @VendorName = 'New Vendor Name'
         , @VendorAddress1 = 'New VendorAddress1'
		 , @VendorAddress2 = 'New VendorAddress2'
		 , @VendorCity = 'New City'
		 , @VendorState = 'ZZ'
		 , @VendorZipCode = '12345'
		 , @DefaultTermsID = '4'
		 , @DefaultAccountNo = '167'
		 ;
    PRINT 'One row was inserted.';
    PRINT 'New VendorID: ' + CONVERT(varchar, @VendorID);
END TRY
BEGIN CATCH
    PRINT 'An error occurred. Row was not inserted.';
    PRINT 'Error number: ' +
        CONVERT(varchar, ERROR_NUMBER());
    PRINT 'Error message: ' +
        CONVERT(varchar, ERROR_MESSAGE());
END CATCH;
							