/* 
Create function fnDateRange that takes two parameters of type DATE that define begin 
and end of the date range
Return  result set that contains InvoiceNumber, InvoiceDate, InvoiceTotal, and Balance 
for all invoices with InvoiceDate within the date range
Balance is InvoiceTotal – PaymentTotal – CreditTotal
Invoke the function in a SELECT query to return invoices from Oct 10-Oct 20, 2019
*/

USE AP;
GO
IF OBJECT_ID('fnDateRange') IS NOT NULL
	DROP FUNCTION fnDateRange;
GO 

-- Creating the function
CREATE OR ALTER FUNCTION fnDateRange(@BeginDate DATE, @EndDate DATE)
	RETURNS @OutTable TABLE(InvoiceNumber VARCHAR(50), InvoiceDate DATE,
		InvoiceTotal MONEY, Balance MONEY) -- Defining table columns
AS
BEGIN
	-- Inserting values into the table to be returned by the function:
	INSERT @OutTable
		SELECT InvoiceNumber, InvoiceDate, InvoiceTotal, 
			(InvoiceTotal-PaymentTotal-CreditTotal) AS Balance
		FROM Invoices
		-- Specifying dates range between the BeginDate & EndDate
		WHERE InvoiceDate >= @BeginDate AND InvoiceDate <= @EndDate;
		RETURN;
END;
GO

-- Invoking the function in a SELECT query to return invoices from Oct 10-Oct 20, 2019:
SELECT * 
FROM dbo.fnDateRange('2019-10-10','2019-10-20')

