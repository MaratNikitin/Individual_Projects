/* Done!
Create a procedure that moves payment amount from one invoice to another 
invoice (three parameters: source invoice ID, target invoice ID, and money amount)
Perform the following checks:
- Both invoices belong to the same vendor
- Money amount must be > 0
- Money amount to move must be <= PaymentTotal of the source invoice
- Money amount to move must be <= (InvoiceTotal -PaymentTotal –CreditTotal) 
of the target invoice
The procedure decreases PaymentTotal  of the source invoice and increases 
PaymentTotal of the target invoice by money amount in a transaction
If for whatever reason something goes wrong, the transaction is rolled back
*/

USE AP;
GO
 
IF OBJECT_ID('uspMoneyTransaction') IS NOT NULL
    DROP PROCEDURE uspMoneyTransaction;
GO

-- Creating the procedure:
CREATE OR ALTER PROCEDURE uspMoneyTransaction
    @SourceInvoiceID INT,
	@TargetInvoiceID INT,
	@MoneyAmount MONEY
AS
BEGIN TRY
	BEGIN TRANSACTION -- beginning Transaction

		-- Subtracting money amount from the source invoice:
		UPDATE Invoices
		SET PaymentTotal = PaymentTotal - @MoneyAmount
		WHERE InvoiceID = @SourceInvoiceID

		-- Adding money amount to the target invoice:
		UPDATE Invoices
		SET PaymentTotal = PaymentTotal + @MoneyAmount
		WHERE InvoiceID = @TargetInvoiceID

		-- Validating that money belong to the same vendor:
		IF (SELECT VendorID FROM Invoices WHERE InvoiceID = @SourceInvoiceID) != 
			(SELECT VendorID FROM Invoices WHERE InvoiceID = @TargetInvoiceID)
			BEGIN
				ROLLBACK TRANSACTION;
				PRINT 'Invoices must belong to the same Vendor to '+
				'complete the money transaction!'; 
				PRINT 'The Transaction was rolled back';
			END;

		-- Validating that MoneyAmount is positive:
		IF @MoneyAmount <= 0
			BEGIN
				ROLLBACK TRANSACTION;
				PRINT 'MoneyAmount must be a positive number! ';
				PRINT 'Transaction was rolled back';
			END;

		-- Validating that MoneyAmount <= (InvoiceTotal-PaymentTotal–CreditTotal):
		IF @MoneyAmount > (SELECT InvoiceTotal-PaymentTotal-CreditTotal + @MoneyAmount
		-- @MoneyAmount was added back because it was already subtracted above
							FROM Invoices WHERE InvoiceID = @TargetInvoiceID)
			BEGIN
				ROLLBACK TRANSACTION;
				PRINT 'The target invoice does not need that much money! '
				PRINT 'The transaction was rolled back'
			END;
	COMMIT TRANSACTION; -- If all is good, the transaction is committed
	PRINT 'The transaction was completed successfully!' -- Feedback to a user
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 -- It helps to avoid trying to close a transaction that has already been closed
		ROLLBACK TRANSACTION; 
	PRINT 'Error occurred. The transaction was rolled back'
END CATCH;
GO

-- Executing the procedure (Invoices do not belong to the same vendor):
EXECUTE uspMoneyTransaction '1', '2', '100'
GO

-- Executing the procedure (The target invoice does not need any money transfer):
EXECUTE uspMoneyTransaction '2', '3', '100'
GO

-- Executing the procedure (Money amount is not positive):
EXECUTE uspMoneyTransaction '3', '4', '-100'
GO

-- Demonstrating state of invoices 102 & 106 before & after the transaction:
SELECT InvoiceID, VendorID, InvoiceTotal, PaymentTotal, CreditTotal
FROM Invoices 
WHERE VendorID = 110
GO

-- Executing a legitimate transaction passing all validation.
-- Passing $50 from invoice #106 (initially, PaymentTotal = 21221.63) 
--             to invoice #102 (initially, Invoice Total = 0):
EXECUTE uspMoneyTransaction '106', '102', '50'
GO

-- Reversing the legitimate transaction by returning $50 from invoice #102
--	back to invoice #106 (i.e. returning the DB to its initial state):
EXECUTE uspMoneyTransaction '102', '106', '50'
GO
