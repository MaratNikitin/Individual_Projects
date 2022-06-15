/*
-- Write a procedure spInsertInvoiceWithLine that
-- adds one row to Invoices table and one row to InvoiceLineItems for that  invoice
-- accept parameters for data in both rows
-- you can get some data from other tables
-- do common-sense validation
 
-- IMPORTANT: make these two statements form a transaction
-- either both succeed or both fail
*/

USE AP
GO

CREATE OR ALTER PROC spInsertLineItem
	@InvoiceID int = NULL,
	@AccountNo int = NULL,
	@InvoiceLineItemAmount money = NULL,
	@InvoiceLineItemDescription varchar(100) = NULL, 
		-- length limit from the column definition in the table
	@NextSeq		int = NULL,
	@VendorID       int = NULL,
    @InvoiceNumber  varchar(50) = NULL,
    @InvoiceDate    date = NULL,
    @InvoiceTotal   money = NULL,
    @PaymentTotal   money = NULL,
    @CreditTotal    money = NULL,
    @TermsID        int = NULL,
    @InvoiceDueDate date = NULL,
    @PaymentDate    date = NULL
AS
BEGIN TRY
	BEGIN TRANSACTION -- beginning Transaction
	-- throw error if the invoice doesn't exist
	IF NOT EXISTS(SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID)
		THROW 50000, 'Invoice does not exist!', 0;

	-- generate the next sequence number
	--DECLARE @NextSeq int;
	IF NOT EXISTS(SELECT InvoiceID FROM InvoiceLineItems 
			WHERE InvoiceID = @InvoiceId)
		SET @NextSeq = 1;
	ELSE
					-- COUNT does not work when gaps in the sequence
		SELECT @NextSeq = MAX(InvoiceSequence) + 1 
			FROM InvoiceLineItems WHERE InvoiceID = @InvoiceID;
	
	-- check the account no. 
	-- if null, get default from the Vendors table
	IF (@AccountNo IS NULL)
		BEGIN
			SELECT @VendorID = (SELECT VendorID 
				FROM Invoices WHERE InvoiceID = @InvoiceID);
			SET @AccountNo = (SELECT DefaultAccountNo 
				FROM Vendors WHERE VendorID = @VendorID)
		END
	ELSE -- account no. is not null - validate
		IF NOT EXISTS(SELECT * FROM GLAccounts WHERE AccountNo = @AccountNo)
			THROW 50000, 'Invalid AccountNo.', 0;

	-- check the amount
	IF @InvoiceLineItemAmount IS NULL 
		THROW 50000, 'Must provide an item amount.', 0;
	ELSE -- not null, must be positive
		IF @InvoiceLineItemAmount <= 0
			THROW 50000, 'LineItemAmount must be greater than 0.', 0;

	-- check the description
	IF @InvoiceLineItemDescription IS NULL OR @InvoiceLineItemDescription = ''
		THROW 50000, 'You must provide an item description.', 0;

		IF NOT EXISTS (SELECT * FROM Vendors
				   WHERE VendorID = @VendorID)
		THROW 50001, 'Invalid VendorID.', 1;

	IF @InvoiceNumber IS NULL
		THROW 50001, 'Invalid InvoiceNumber.', 1;

	IF @InvoiceDate IS NULL OR @InvoiceDate > GETDATE() 
			OR DATEDIFF(dd, @InvoiceDate, GETDATE()) > 30
		THROW 50001, 'Invalid InvoiceDate.', 1;

	IF @InvoiceTotal IS NULL OR @InvoiceTotal <= 0
		THROW 50001, 'Invalid InvoiceTotal.', 1;

	IF @PaymentTotal IS NULL
		SET @PaymentTotal = 0;

	IF @CreditTotal IS NULL
		SET @CreditTotal = 0;

	IF @CreditTotal > @InvoiceTotal
		THROW 50001, 'Invalid CreditTotal.', 1;

	IF @PaymentTotal > @InvoiceTotal - @CreditTotal
		THROW 50001, 'Invalid PaymentTotal.', 1;

	IF NOT EXISTS (SELECT * FROM Terms
				   WHERE TermsID = @TermsID)
		IF @TermsID IS NULL
			SELECT @TermsID = DefaultTermsID
			FROM Vendors
			WHERE VendorID = @VendorID;
		ELSE  -- @TermsID IS NOT NULL
			THROW 50001, 'Invalid TermsID.', 1;

	IF @InvoiceDueDate IS NULL
	  BEGIN
		  DECLARE @TermsDueDays int;
		  SELECT @TermsDueDays = TermsDueDays
		  FROM Terms
		  WHERE TermsID = @TermsID;
		  SET @InvoiceDueDate =
			  DATEADD(day, @TermsDueDays, @InvoiceDate);
	  END
	ELSE  -- @InvoiceDueDate IS NOT NULL
		IF @InvoiceDueDate < @InvoiceDate OR
				DATEDIFF(dd, @InvoiceDueDate, @InvoiceDate)
					> 180
			THROW 50001, 'Invalid InvoiceDueDate.', 1;
	IF @PaymentDate < @InvoiceDate OR
			DATEDIFF(dd, @PaymentDate, GETDATE()) > 14
		THROW 50001, 'Invalid PaymentDate.', 1;
	
	-- Inserting into Invoices table:
	INSERT Invoices
	VALUES (@VendorID, @InvoiceNumber, @InvoiceDate,
			@InvoiceTotal, @PaymentTotal, @CreditTotal,
			@TermsID, @InvoiceDueDate, @PaymentDate);
	COMMIT TRANSACTION;

	SET @InvoiceID = @@IDENTITY; -- This overrides whatever InvoiceID was entered

	-- enter the data into the InvoiceLineItems table
	INSERT INTO InvoiceLineItems(InvoiceID, InvoiceSequence, AccountNo,
						InvoiceLineItemAmount, InvoiceLineItemDescription)
	VALUES(	@InvoiceID, @NextSeq, @AccountNo, 
			@InvoiceLineItemAmount,	@InvoiceLineItemDescription	)

	
	PRINT '2 rows were inserted in tables Invoices & InvoiceLineItems.';
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 -- It helps to avoid trying to close a transaction 
								-- that has already been closed (helpful when many)
		ROLLBACK TRANSACTION; 
	PRINT 'Error occurred. The transaction was rolled back';
	PRINT 'Rows were not inserted.';
	PRINT 'Error number: ' +
        CONVERT(varchar, ERROR_NUMBER());
    PRINT 'Error message: ' +
        CONVERT(varchar, ERROR_MESSAGE());
END CATCH;
GO

-- It's a legitimate insert operation:
    EXEC spInsertLineItem
           @InvoiceID = '114' -- Any number 1-114 works
         , @NextSeq = NULL
		 , @AccountNo = '110' -- values 100, 110, 120, 150 exist & work
		 , @InvoiceLineItemAmount = '222' -- Any positive number works
		 , @InvoiceLineItemDescription = 'Others' -- Any text works
		 , @VendorID = 1
		 , @InvoiceNumber = 'QWERTY'
		 , @InvoiceDate = '2022-02-24'
		 , @InvoiceTotal = '333'
		 , @PaymentTotal = '0'
		 , @CreditTotal = '0'			
		 , @TermsID = 1			
		 , @InvoiceDueDate = '2022-03-20'			
		 , @PaymentDate = NULL
		 ;  

-- Buggy values are to be entered here:
    EXEC spInsertLineItem
           @InvoiceID = '99114' -- Any number 1-114 works
         , @NextSeq = NULL
		 , @AccountNo = '150' -- values 100, 110, 120, 150 exist & work
		 , @InvoiceLineItemAmount = '777' -- Any positive number works
		 , @InvoiceLineItemDescription = 'Ads' -- Any text works
		 , @VendorID = 1
		 , @InvoiceNumber = 'ABCD'
		 , @InvoiceDate = '2022-02-24'
		 , @InvoiceTotal = '333'
		 , @PaymentTotal = '0'
		 , @CreditTotal = '0'			
		 , @TermsID = 1			
		 , @InvoiceDueDate = '2022-03-20'			
		 , @PaymentDate = NULL
		 ;  


-- Checking changes:
SELECT * FROM InvoiceLineItems
SELECT * FROM Invoices