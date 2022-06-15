/* Part 1 - Done On Day 3:
-- Write a procedure spInsertInvoiceWithLine that
-- adds one row to Invoices table and one row to InvoiceLineItems for that  invoice
-- accept parameters for data in both rows
-- you can get some data from other tables
-- do common-sense validation
-- IMPORTANT: make these two statements form a transaction
-- either both succeed or both fail
*/
/* Part 2 - Day 5 class Exercise
Further improve spInsertInvoice procedure by allowing inserting multiple InvoiceLineItems rows 
while inserting a new row into Invoices table
Define table type that contains values that are needed to insert a new row into InvoiceLineItems
table: AccountNo, Amount and Description
Pass data of multiple rows for InvoiceLineItems into the spInsertInvoice procedure as a table 
parameter
In the procedure, loop through this table with a cursor to insert potentially multiple rows of 
data into InvoiceLineItems table
Test it in scenarios when you have two or more lines for an invoice as well as when you have a 
single line
*/

USE AP;
GO

-- Creating table type first:
CREATE TYPE typeLineItemsSet AS TABLE
(
	AccountNo					INT,
	InvoiceLineItemAmount		MONEY,
	InvoiceLineItemDescription  VARCHAR(100)
)
GO

-- Creating or altering the procedure:
CREATE OR ALTER PROCEDURE spInsertInvoiceWithLine
	@VendorID INT,
	@InvoiceNumber VARCHAR(50),
	@InvoiceDate DATE = NULL,
	@InvoiceTotal MONEY,
	@PaymentTotal MONEY,
	@CreditTotal MONEY,
	@TermsID INT,
	@PaymentDate DATE = NULL,
	@LineItemsSet typeLineItemsSet READONLY -- it's used instead of three columns of this table type
AS
	-- Checking if required values are provided:
	IF @VendorID IS NULL
		THROW 50007, 'Please enter VendorID!', 0;
	IF @InvoiceNumber IS NULL
		THROW 50007, 'Please enter invoice #!', 0;

	-- InvoiceTotal must be positive:
	IF @InvoiceTotal IS NULL OR @InvoiceTotal < 0
		THROW 50007, 'Invoice total must be >=0', 0;
	IF @PaymentTotal IS NULL
		SELECT @PaymentTotal = 0
	IF @CreditTotal IS NULL
		SELECT @CreditTotal = 0

	-- Using current date if not specified otherwise:
	IF @InvoiceDate IS NULL
		SELECT @InvoiceDate = GETDATE();

	-- Checking if payment is excessive:
	IF @PaymentTotal + @CreditTotal > @InvoiceTotal
		THROW 50007, 'Excessive Payment!', 0
	
	IF @TermsID IS NULL OR NOT EXISTS(
		SELECT * FROM Terms WHERE TermsID = @TermsID
	)
		THROW 50007, 'Enter valid TermsID!', 0;
	
	DECLARE @InvoiceDueDate DATE;
	SELECT @InvoiceDueDate = 
		DATEADD(DAY, TermsDueDays, @InvoiceDate)
	FROM Terms
	WHERE TermsID = @TermsID

BEGIN TRY
	BEGIN TRANSACTION
	-- Inserting a single line into the Invoices table happens here:
	INSERT INTO Invoices
	VALUES(
		@VendorID, @InvoiceNumber, @InvoiceDate, @InvoiceTotal,
		@PaymentTotal, @CreditTotal, @TermsID, @InvoiceDueDate,
		@PaymentDate
		)
	-- Since InvoiceID is the same for each InvoiceLineItem of each invoice,
		-- the next line is placed outside of the cursor:
	DECLARE @InvoiceID INT = @@IDENTITY
	-- Below all the magic of inserting multiple invoice line items happens:
	
	-- Declaring outside the cursor three variables for holding line items temporarily:
	DECLARE @AccountNo					INT,
			@InvoiceLineItemAmount		MONEY, 
			@InvoiceLineItemDescription VARCHAR(100)

	-- Declaring the magic cursor:
	DECLARE @InvoiceLineItemsCursor AS CURSOR 
	-- Assigning a query to the cursor:
	SET @InvoiceLineItemsCursor = CURSOR FOR SELECT * FROM @LineItemsSet
	-- Opening the cursor:
	OPEN @InvoiceLineItemsCursor
	-- Getting the first item:
	FETCH NEXT FROM @InvoiceLineItemsCursor
		INTO @AccountNo, @InvoiceLineItemAmount, @InvoiceLineItemDescription

	-- Looping through items of the @CategoryName table type:
	WHILE @@FETCH_STATUS = 0 -- i.e. looping until there are no more items left
		BEGIN
			DECLARE @InvoiceSequence INT

			-- InvoiceSequence is calculated by deafault:
			SELECT @InvoiceSequence = MAX(InvoiceSequence) + 1
			FROM InvoiceLineItems
			WHERE InvoiceID = @InvoiceID

			-- If @InvoiceSequence was not given a value above, it means it was NULL:
			IF @InvoiceSequence IS NULL
				SELECT @InvoiceSequence = 1
			
			-- All local variables are assigned and ready to be inserted into the DB table:
			INSERT INTO InvoiceLineItems
			VALUES(
				@InvoiceID, @InvoiceSequence, @AccountNo,
				@InvoiceLineItemAmount, @InvoiceLineItemDescription
			)
			PRINT '1 line was inserted into InvoiceLineItems'
			-- Moving on to the next item:
			FETCH NEXT FROM @InvoiceLineItemsCursor
				INTO @AccountNo, @InvoiceLineItemAmount, @InvoiceLineItemDescription
			-- Moving to the loop's beginning, having a new item (line).
		END -- This is the end of the WHILE loop

	-- Closing the cursor - mission accomplished!
	CLOSE @InvoiceLineItemsCursor
	-- Deallocating the cursor - R.I.P.
	DEALLOCATE @InvoiceLineItemsCursor;
	-- If we got here, we can finally commit all row inserts into the DB:
	COMMIT TRANSACTION
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
END CATCH
GO -- End of the procedure

-- Testing:

-- It's a legitimate operation with one Invoice and three InvoiceLineItems insert:
DECLARE @LineItemsSet typeLineItemsSet -- a temporary table
INSERT INTO @LineItemsSet 
VALUES  ('100', '101', 'LineItem 1'), -- AccountNo, InvoiceLineItemAmount, InvoiceLineItemDescription
		('100', '201', 'LineItem 2'),
		('100', '301', 'LineItem 3');
EXEC spInsertInvoiceWithLine
        96				-- @VendorID
		, 'QWERTY'		-- @InvoiceNumber
		, '2022-02-24'	-- @InvoiceDate
		, '333'			-- @InvoiceTotal
		, '0'			-- @PaymentTotal
		, '0'			-- @CreditTotal
		, 1				-- @TermsID	
		, '2022-02-28'	-- @PaymentDate
		, @LineItemsSet	--  typeLineItemsSet
		;  
GO

-- It's a legitimate operation with one Invoice and three InvoiceLineItems insert:
DECLARE @LineItemsSet typeLineItemsSet -- a temporary table
INSERT INTO @LineItemsSet 
VALUES ('100', '101', 'Single LineItem') -- AccountNo, InvoiceLineItemAmount, InvoiceLineItemDescription 
EXEC spInsertInvoiceWithLine
        96				-- @VendorID
		, 'QWERTY'		-- @InvoiceNumber
		, '2022-02-24'	-- @InvoiceDate
		, '333'			-- @InvoiceTotal
		, '0'			-- @PaymentTotal
		, '0'			-- @CreditTotal
		, 1				-- @TermsID	
		, '2022-02-28'	-- @PaymentDate
		, @LineItemsSet	--  typeLineItemsSet
		;  
GO		 

-- Checking only the changes:
SELECT * FROM InvoiceLineItems WHERE InvoiceID > 114
SELECT * FROM Invoices WHERE InvoiceID > 114

-- Cleaning up the DB after all changes made:
DELETE FROM InvoiceLineItems WHERE InvoiceID > 114
DELETE FROM Invoices WHERE InvoiceID > 114

-- Seeing how two tables are connected, 
	-- and how one invoice can have multiple invoice line items:
SELECT * 
FROM Invoices JOIN InvoiceLineItems 
	ON Invoices.InvoiceID = InvoiceLineItems.InvoiceID
WHERE VendorID IN (96, 95)
