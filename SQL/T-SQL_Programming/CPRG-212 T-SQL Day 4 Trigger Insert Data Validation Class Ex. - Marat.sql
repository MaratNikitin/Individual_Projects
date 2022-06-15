/* 
-- make a trigger that runs when insert happens on Invoices
-- that validates data in Inserted row (restrict to a single row)
-- that comes into the insert
-- logic:
-- make it either for or after insert
-- restrict to a single row
-- go through sequence of checks of data from Inserted: if bad, throw exception
-- (throwing an exception in  the trigger reverses the operation that cause 
	the trigger to run)
*/

USE AP;
GO 

-- This part is needed if you eventually decide to just delete the trigger: 
IF OBJECT_ID('InvoiceDataValidationTrigger') IS NOT NULL
    DROP TRIGGER InvoiceDataValidationTrigger;
GO

-- Creating or altering the trigger:
CREATE OR ALTER TRIGGER InvoiceDataValidationTrigger
    ON Invoices
	AFTER INSERT -- Validating data after an insert event happens
AS
	BEGIN TRY
		-- Data validations (modified & simplified validations from the book example):
		
		-- Restricting insert to a single row:
		IF (SELECT COUNT(InvoiceID) FROM inserted) > 1
			THROW 50001, 'Limit insert to 1 row!', 1;
		
		-- VendorID must be valid:
		IF NOT EXISTS (SELECT * FROM Vendors
					   WHERE VendorID =  (SELECT VendorID FROM Inserted))
			THROW 50001, 'Invalid VendorID.', 1;
		
		-- InvoiceNumber must be provided:
		IF (SELECT InvoiceNumber  FROM Inserted) IS NULL
			THROW 50001, 'Invalid InvoiceNumber.', 1;
		
		-- InvoiceDate should not be in the future or more than 30 days in the past
		IF (SELECT InvoiceDate FROM Inserted) IS NULL 
				OR (SELECT InvoiceDate FROM Inserted) > GETDATE() 
				OR DATEDIFF(dd, (SELECT InvoiceDate FROM Inserted), GETDATE()) > 30
			THROW 50001, 'Invalid InvoiceDate.', 1;
		
		-- InvoiceTotal can not be NULL or a non-positive number:
		IF  (SELECT InvoiceTotal FROM Inserted) IS NULL 
				OR (SELECT InvoiceTotal FROM Inserted) <= 0
			THROW 50001, 'Invalid InvoiceTotal.', 1;
		
		-- CreditTotal can not be greater than InvoiceTotal:
		IF (SELECT CreditTotal FROM Inserted) >  (SELECT InvoiceTotal FROM Inserted)
			THROW 50001, 'Invalid CreditTotal.', 1;

		-- Enforcing PaymentTotal <= InvoiceTotal-CreditTotal
		IF (SELECT PaymentTotal FROM Inserted) > (SELECT InvoiceTotal-CreditTotal FROM Inserted) 
			THROW 50001, 'Invalid PaymentTotal.', 1;
		
		-- Terms ID must be an existing one:
		IF NOT EXISTS (SELECT * FROM Terms
					   WHERE TermsID = (SELECT TermsID FROM Inserted))			
				THROW 50001, 'Invalid TermsID.', 1;

		-- InvoiceDueDate must be present:
		IF (SELECT InvoiceDueDate FROM Inserted) IS NULL
		  	THROW 50001, 'InvoiceDueDate Required', 1;
	END TRY
	BEGIN CATCH
		PRINT 'An error occurred. A trigger was executed - row was not inserted.';
    PRINT 'Error number: ' +
        CONVERT(VARCHAR, ERROR_NUMBER());
    PRINT 'Error message: ' +
        CONVERT(VARCHAR, ERROR_MESSAGE());
	END CATCH
GO

-- Testing the trigger:

-- Inserting valid data into the Invoices table:
INSERT INTO Invoices (VendorID, InvoiceNumber, InvoiceDate,
        InvoiceTotal, PaymentTotal, CreditTotal,
        TermsID, InvoiceDueDate, PaymentDate)
VALUES (1, 'QWERTY123', '2022-02-20', '500', '0', '0', 3, '2022-03-20', '2022-02-22');
GO

-- Trying to insert faulty data into the Invoices table 
   -- (trying to insert valid rows, but 2 rows!):
INSERT INTO Invoices (VendorID, InvoiceNumber, InvoiceDate,
        InvoiceTotal, PaymentTotal, CreditTotal,
        TermsID, InvoiceDueDate, PaymentDate)
VALUES (1, 'DEF456', '2022-02-20', '500', '0', '0', 3, '2022-03-20', '2022-02-22'),
		(1, 'DEF456', '2022-02-20', '500', '0', '0', 3, '2022-03-20', '2022-02-22');
GO

-- Trying to insert faulty data into the Invoices table 
   -- (InvoiceDate is far away in the past):
INSERT INTO Invoices (VendorID, InvoiceNumber, InvoiceDate,
        InvoiceTotal, PaymentTotal, CreditTotal,
        TermsID, InvoiceDueDate, PaymentDate)
VALUES (1, 'DEF456', '2019-06-06', '500', '0', '0', 3, '2022-03-20', '2022-02-22');
GO

-- Checking if rows were added or not into the Invoices table
SELECT * 
FROM Invoices
WHERE InvoiceID > 113
