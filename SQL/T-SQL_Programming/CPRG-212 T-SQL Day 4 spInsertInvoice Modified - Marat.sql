/* 
Improve spInsertInvoice procedure. Get its text using SP_HELPTEXT
Inserting a row into Invoices table should be accompanied by inserting a row into 
InvoiceLineItems.
For now we will assume that an invoice has only one invoice line item
You will need two additional parameters:
For AccountNo (use as default value the DefaultAccountNo from Vendors table)
For InvoiceLineItemDescription
Replace the original parameter @InvoiceTotal with @LineAmount (value for 
InvoiceLineItemAmount) and set InvoiceTotal to the same value
Set  InvoiceSequence it to 1
Simplify by removing original  parameters:
@PaymentTotal, @CreditTotal (set both to zero),
@InvoiceDueDate (can be calculated),
@PaymentDate (set to NULL)
*/

USE AP;
GO
 
IF OBJECT_ID('spInsertInvoice') IS NOT NULL
    DROP PROC spInsertInvoice;
GO
-- Creating procedure
CREATE OR ALTER PROC spInsertInvoice
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
-- Validations first:
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

-- Validations successfull, time to insert values:
-- Inserting into Invoices table:
INSERT Invoices
VALUES (@VendorID, @InvoiceNumber, @InvoiceDate,
        @InvoiceTotal, @PaymentTotal, @CreditTotal,
        @TermsID, @InvoiceDueDate, @PaymentDate);

-- Inserting into InvoiceLineItems table:
INSERT InvoiceLineItems
VALUES (@VendorID);

RETURN @@IDENTITY;

-- An SQL script that calls the stored procedure:
BEGIN TRY
    DECLARE @InvoiceID int;
    EXEC @InvoiceID = spInsertInvoice
         @VendorID = 99,
         @InvoiceNumber = 'RZ99381',
         @InvoiceDate = '2022-02-18',
         @InvoiceTotal = 1292.45;
    PRINT 'Row was inserted.';
    PRINT 'New InvoiceID: ' + CONVERT(varchar, @InvoiceID);
END TRY
BEGIN CATCH
    PRINT 'An error occurred. Row was not inserted.';
    PRINT 'Error number: ' +
        CONVERT(varchar, ERROR_NUMBER());
    PRINT 'Error message: ' +
        CONVERT(varchar, ERROR_MESSAGE());
END CATCH;


							