-- Temp Tables - Exercises

/*
Rewrite your solution from last video's exercise using CREATE and INSERT instead of SELECT INTO.
*/

-- My previous solution with Temp Tables:

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

/*************************************************************************************************************/

-- My new solution with Temp Tables (create the tables first and only then insert into them:

-- The first temp table:

CREATE TABLE #SalesByMonthTempTable
(
	OrderMonth DATE,
	TotalSales MONEY
)

INSERT INTO #SalesByMonthTempTable
(
	OrderMonth,
	TotalSales
)
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

-- The second temp table:

CREATE TABLE #PurchasesByMonthTempTable
(
	OrderMonth DATE,
	TotalPurchases MONEY
)

INSERT INTO #PurchasesByMonthTempTable
(
	OrderMonth,
	TotalPurchases
)

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
