-- Stored Procedures - Exercise

/*
Exercise
Create a stored procedure called "uspOrdersAboveThreshold" that pulls in all sales orders 
with a total due amount above a threshold specified in a parameter called "@Threshold". 
The value for threshold will be supplied by the caller of the stored procedure.
The proc should have two other parameters: "@StartYear" and "@EndYear" (both INT data 
types), also specified by the called of the procedure. All order dates returned by the 
proc should fall between these two years.
*/

CREATE OR ALTER PROCEDURE dbo.uspOrdersAboveThreshold
(
	@Threshold MONEY,
	@StartYear INT,
	@EndYear INT
)
AS
BEGIN
	SELECT SalesOrderID,OrderDate,TotalDue
	FROM AdventureWorks2019.Sales.SalesOrderHeader
	WHERE TotalDue > @Threshold
		AND YEAR(OrderDate) >= @StartYear
		AND YEAR(OrderDate) <= @EndYear
END
GO

-- Test the stored procedure:
EXECUTE dbo.uspOrdersAboveThreshold 
	@Threshold = 10000, 
	@StartYear = 2013, 
	@EndYear = 2015

