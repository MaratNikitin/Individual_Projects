-- Temp Tables - Exercises

/*
Exercise
Refactor your solution to the exercise from the section on CTEs (average sales/purchases minus top 10) 
	using temp tables in place of CTEs.
*/

/*************************************************************************************************************/

-- My CTE solution:
;WITH SalesByMonthCTE AS (
	SELECT
		OrderMonth,
		TotalSales = SUM(TotalDue)
		FROM (
			SELECT 
			   OrderDate
			  ,OrderMonth = DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1)
			  ,TotalDue
			  ,OrderRank = ROW_NUMBER() OVER(PARTITION BY DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1) ORDER BY TotalDue DESC)
			FROM AdventureWorks2019.Sales.SalesOrderHeader
			) S
		WHERE OrderRank > 10
		GROUP BY OrderMonth
)
, PurchasesByMonthCTE AS (
	SELECT
		OrderMonth,
		TotalPurchases = SUM(TotalDue)
		FROM (
			SELECT 
			   OrderDate
			  ,OrderMonth = DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1)
			  ,TotalDue
			  ,OrderRank = ROW_NUMBER() OVER(PARTITION BY DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1) ORDER BY TotalDue DESC)
			FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader
			) P
		WHERE OrderRank > 10
		GROUP BY OrderMonth
)
SELECT A.OrderMonth,
	A.TotalSales,
	B.TotalPurchases
FROM SalesByMonthCTE AS A
	JOIN PurchasesByMonthCTE AS B ON A.OrderMonth = B.OrderMonth
ORDER BY A.OrderMonth

/*************************************************************************************************************/

-- My solution with Temp Tables:

-- The first temp table:
SELECT
OrderMonth,
TotalSales = SUM(TotalDue)
INTO #SalesByMonthTempTable
FROM (
	SELECT 
		OrderDate
		,OrderMonth = DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1)
		,TotalDue
		,OrderRank = ROW_NUMBER() OVER(PARTITION BY DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1) ORDER BY TotalDue DESC)
	FROM AdventureWorks2019.Sales.SalesOrderHeader
	) S
WHERE OrderRank > 10
GROUP BY OrderMonth

-- The second temp table:
SELECT
OrderMonth,
TotalPurchases = SUM(TotalDue)
INTO #PurchasesByMonthTempTable
FROM (
	SELECT 
		OrderDate
		,OrderMonth = DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1)
		,TotalDue
		,OrderRank = ROW_NUMBER() OVER(PARTITION BY DATEFROMPARTS(YEAR(OrderDate),MONTH(OrderDate),1) ORDER BY TotalDue DESC)
	FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader
	) P
WHERE OrderRank > 10
GROUP BY OrderMonth

-- Get the result using the temp tables
SELECT A.OrderMonth,
	A.TotalSales,
	B.TotalPurchases
FROM #SalesByMonthTempTable AS A
	JOIN #PurchasesByMonthTempTable AS B ON A.OrderMonth = B.OrderMonth
ORDER BY A.OrderMonth

-- Delete the temp tables - collect garbage:
DROP TABLE #SalesByMonthTempTable
DROP TABLE #PurchasesByMonthTempTable