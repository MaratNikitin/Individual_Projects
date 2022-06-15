/* Done!
CPRG-212 Course, SAIT; February 25, 2022; Author: Marat Nikitin
Trigger Exercise: 
Write a trigger that ensured that when InvoiceLineItemAmount in InvoiceLineItems
is updated, the InvoiceTotal for the corresponding invoice is updated accordingly
*/

USE AP;
GO

-- This part is needed if you eventually decide to just delete the trigger: 
IF OBJECT_ID('InvoiceLineItemsUpdateTrigger') IS NOT NULL
    DROP TRIGGER InvoiceLineItemsUpdateTrigger;
GO

-- Creating the trigger:
CREATE OR ALTER TRIGGER InvoiceLineItemsUpdateTrigger
    ON InvoiceLineItems
	AFTER UPDATE 
AS
	UPDATE Invoices
	SET InvoiceTotal = (SELECT InvoiceLineItemAmount FROM Inserted)
	WHERE InvoiceID IN (SELECT InvoiceID FROM Inserted);
	PRINT 'Trigger was executed and InvoiceTotal value was updated ...'
	PRINT '  ... in the Invoices table';
GO

-- Testing the trigger:

-- Query for understanding how these two columns are related and checking
  -- the trigger's performance:
SELECT Invoices.InvoiceID, InvoiceLineItems.InvoiceLineItemAmount, 
		Invoices.InvoiceTotal
FROM InvoiceLineItems JOIN Invoices 
			ON InvoiceLineItems.InvoiceID = Invoices.InvoiceID
GO

-- The trigger is executed (fired) by the following script:
UPDATE InvoiceLineItems
SET InvoiceLineItemAmount = InvoiceLineItemAmount + 111
WHERE InvoiceID = 1 -- it's the uppermost line, which is convenient to track
GO

-- Don't forget to reverse what you just did:
-- (initially for InvoiceID we had InvoiceLineItemAmount = InvoiceTotal = 3813.33)
UPDATE InvoiceLineItems
SET InvoiceLineItemAmount = InvoiceLineItemAmount - 111
WHERE InvoiceID = 1
GO
