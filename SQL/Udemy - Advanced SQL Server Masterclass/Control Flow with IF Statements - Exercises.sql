-- Control Flow With IF Statements - Exercise

/*
Exercise
Modify the stored procedure you created for the stored procedures exercise (dbo.OrdersAboveThreshold) to include an 
additional parameter called "@OrderType" (data type INT).
If the user supplies a value of 1 to this parameter, your modified proc should return the same output as previously.
If however the user supplies a value of 2, your proc should return purchase orders instead of sales orders.
Use IF/ELSE blocks to accomplish this.
*/

CREATE OR ALTER PROCEDURE dbo.uspOrdersAboveThreshold
(
	@Threshold MONEY,
	@StartYear INT,
	@EndYear INT,
	@OrderType INT
)
AS
BEGIN
	-- The code structure is simpler and easier to read without nested if/else statements.
	IF (@OrderType = 1)
	BEGIN
		SELECT SalesOrderID, CAST(OrderDate AS DATE) OrderDate, TotalDue
			FROM AdventureWorks2019.Sales.SalesOrderHeader
			WHERE TotalDue > @Threshold
				AND YEAR(OrderDate) >= @StartYear
				AND YEAR(OrderDate) <= @EndYear
	END

	IF (@OrderType = 2)
	BEGIN
		SELECT PurchaseOrderID, CAST(OrderDate AS DATE) OrderDate, TotalDue
			FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader
			WHERE TotalDue > @Threshold
				AND YEAR(OrderDate) >= @StartYear
				AND YEAR(OrderDate) <= @EndYear
	END

	IF(@OrderType <> 1 AND @OrderType <> 2)
	BEGIN
		SELECT 'Incorrect @OrderType value. Enter 1 for sales orders or 2 for purchase orders' AS ErrorMessage
	END

END
GO

-- Test the stored procedure:
EXECUTE dbo.uspOrdersAboveThreshold 
	@Threshold = 10000, 
	@StartYear = 2013, 
	@EndYear = 2015,
	@OrderType = 3
