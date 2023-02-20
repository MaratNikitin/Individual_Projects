-- Challenge Two Start
USE WideWorldImporters;
GO

-- Create an audit table for customer accounts
CREATE TABLE Sales.CustomerAccountAudit (
    AuditID INT IDENTITY PRIMARY KEY,
    CustomerID INT,
    ReviewDate datetime2
);
GO

-- View existing data
SELECT * FROM Sales.Customers;
SELECT * FROM Sales.Orders;
SELECT * FROM Sales.CustomerAccountAudit;
GO

-- Write a stored procedure to:
-- 1) view information from Sales.Customers for the specific customer
-- 2) view information from Sales.Orders for the specific customer
-- 3) write a row to Sales.CustomerAccountAudit to log activity

CREATE OR ALTER PROCEDURE Sales.uspCustomerAccountAudit (@CustomerID AS INT)
AS
	SELECT CustomerID, CustomerName, PhoneNumber 
	FROM Sales.Customers
	WHERE CustomerID = @CustomerID;

	SELECT OrderID, CustomerID, OrderDate 
	FROM Sales.Orders
	WHERE CustomerID = @CustomerID;

	INSERT INTO Sales.CustomerAccountAudit(CustomerID,ReviewDate)
		VALUES (@CustomerID, GETDATE());
GO

-- Testing the newly created procedure:
EXECUTE Sales.uspCustomerAccountAudit @CustomerID=1;
SELECT * FROM Sales.CustomerAccountAudit;