/* Done!
Day 3 Class Exercise
-- spInsertLineItem:
-- + values for all columns are required
-- invoice has to exist
-- invoice sequence is calculated: 1 when there are no invoice line items for this invoices,
--        otherwise takes max sequence number for this invoice + 1
-- account has to exist; if not provided take default from vendor if the invoice to which
--        the item belongs
-- amount has to  be > 0
*/

USE AP;
GO
 
IF OBJECT_ID('spInsertLineItem') IS NOT NULL
    DROP PROC spInsertLineItem;
GO

CREATE OR ALTER PROC spInsertLineItem
	@InvoiceID					int = NULL,
    @InvoiceSequence			smallint = NULL,
    @AccountNo					int = NULL,	
    @InvoiceLineItemAmount		money = NULL, 
    @InvoiceLineItemDescription	varchar(100) = NULL
AS

/* It's redundant as we cover the case when InvoiceSequence = NULL, 
		so it's commented out:
IF @InvoiceSequence IS NULL
	THROW 50007, 'InvoiceSequence required', 1;
*/

-- Validating presence of AccountNo:
IF @AccountNo IS NULL
	THROW 50007, 'AccountNo must be provided', 1;

-- Validating presence of InvoiceLineItemAmount:
IF @InvoiceLineItemAmount IS NULL
	THROW 50007, 'InvoiceLineItemAmount required!', 1;

-- Validating presence of InvoiceLineItemDescription:
IF @InvoiceLineItemDescription IS NULL
	THROW 50007, 'InvoiceLineItemDescription missing!', 1;

-- Invoice has to exist, checking it:
IF NOT EXISTS (SELECT InvoiceID FROM Invoices WHERE InvoiceID = @InvoiceID)
		THROW 50007, 'Invoice ID does not exist!', 1;

-- Invoice sequence is calculated: 1 when there are no invoice line items for this invoice;
--     otherwise, it takes the max sequence number for this invoice + 1:
IF (SELECT MAX(InvoiceSequence) 
	FROM InvoiceLineItems JOIN Invoices 
		ON InvoiceLineItems.InvoiceID = Invoices.InvoiceID
	WHERE Invoices.InvoiceID = @InvoiceID) = NULL
	SELECT @InvoiceSequence = 1
ELSE
	SELECT @InvoiceSequence = 1 + (SELECT MAX(InvoiceSequence) 
									FROM InvoiceLineItems JOIN Invoices 
									ON InvoiceLineItems.InvoiceID = Invoices.InvoiceID
									WHERE Invoices.InvoiceID = @InvoiceID)

-- If AccountNo is provided, take default from Vendors for the invoice to which
--        the item belongs:
IF @AccountNo = NULL
	SELECT @AccountNo = (SELECT DefaultAccountNo 
						FROM Vendors JOIN Invoices 
							ON Vendors.VendorID = Invoices.VendorID
							WHERE InvoiceID = @InvoiceID)


-- Account has to exist: 
IF NOT EXISTS (SELECT AccountNo FROM GLAccounts WHERE AccountNo = @AccountNo)
		THROW 50007, 'Account does not exist!', 1;

-- InvoiceLineItemAmount has to  be > 0:
IF @InvoiceLineItemAmount <=0
		THROW 50007, 'Amount must be > 0!', 1;

-- All validation was successfully passed, time to insert values:
INSERT InvoiceLineItems
VALUES (@InvoiceID, 
		@InvoiceSequence, 
		@AccountNo,  
		@InvoiceLineItemAmount, 
		@InvoiceLineItemDescription);
GO -- End of procedure:

-- It's a legitimate insert operation:
BEGIN TRY
    EXEC spInsertLineItem
           @InvoiceID = '114' -- Any number 1-114 works
         , @InvoiceSequence = NULL 
		 , @AccountNo = '100' -- values 100, 110, 120, 150 exist & work
		 , @InvoiceLineItemAmount = '500' -- Any positive number works
		 , @InvoiceLineItemDescription = 'Ads' -- Any text works
		 ;
    PRINT 'One row was inserted.';
END TRY
BEGIN CATCH
    PRINT 'An error occurred. Row was not inserted.';
    PRINT 'Error number: ' +
        CONVERT(varchar, ERROR_NUMBER());
    PRINT 'Error message: ' +
        CONVERT(varchar, ERROR_MESSAGE());
END CATCH;
							