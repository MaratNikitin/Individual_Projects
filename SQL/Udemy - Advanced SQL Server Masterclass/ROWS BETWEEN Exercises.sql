-- ROWS BETWEEN - Exercises

/*
Exercise 1
Create a query with the following columns:
“OrderMonth”, a derived column (you’ll have to create this one yourself) featuring the month number corresponding 
	with the Order Date in a given row
“OrderYear”, a derived column featuring the year corresponding with the Order Date in a given row
“SubTotal” from the Purchasing.PurchaseOrderHeader table
Your query should be an aggregate query – specifically, it should sum “SubTotal”, and group by the remaining fields.
*/

SELECT MONTH(OrderDate) AS OrderMonth, YEAR(OrderDate) AS OrderYear, SUM(SubTotal) AS SubTotalsSum
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader
GROUP BY YEAR(OrderDate), MONTH(OrderDate)
ORDER BY OrderYear, OrderMonth

/********************************************************************************************************************************/

/*
Exercise 2
Modify your query from Exercise 1 by adding a derived column called "Rolling3MonthTotal", that displays  - for a 
	given row - a running total of “SubTotal” for the prior three months (including the current row).
HINT: You will need to include multiple fields in your ORDER BY to get this to work!
*/
;WITH Monthly_Totals_CTE AS (
	SELECT MONTH(OrderDate) AS OrderMonth, YEAR(OrderDate) AS OrderYear, SUM(SubTotal) AS SubTotalsSum
	FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader
	GROUP BY YEAR(OrderDate), MONTH(OrderDate)	
)
SELECT *, 
	Rolling3MonthTotal = SUM(SubTotalsSum) OVER(ORDER BY OrderYear, OrderMonth ROWS BETWEEN 2 PRECEDING AND CURRENT ROW)
FROM Monthly_Totals_CTE
ORDER BY OrderYear, OrderMonth

/********************************************************************************************************************************/

/*
Exercise 3
Modify your query from Exercise 3 by adding another derived column called "MovingAvg6Month", that calculates a rolling 
	average of “SubTotal” for the previous 6 months, relative to the month in the “current” row. Note that this average 
	should NOT include the current row.
*/

;WITH Monthly_Totals_CTE AS (
	SELECT MONTH(OrderDate) AS OrderMonth, YEAR(OrderDate) AS OrderYear, SUM(SubTotal) AS SubTotalsSum
	FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader
	GROUP BY YEAR(OrderDate), MONTH(OrderDate)	
)
SELECT *, 
	Rolling3MonthTotal = SUM(SubTotalsSum) OVER(ORDER BY OrderYear, OrderMonth ROWS BETWEEN 2 PRECEDING AND CURRENT ROW),
	MovingAvg6Month = AVG(SubTotalsSum) OVER(ORDER BY OrderYear, OrderMonth ROWS BETWEEN 6 PRECEDING AND 1 PRECEDING)
FROM Monthly_Totals_CTE
ORDER BY OrderYear, OrderMonth

/********************************************************************************************************************************/

/*
Exercise 4
Modify your query from Exercise 3 by adding (yet) another derived column called “MovingAvgNext2Months” , that calculates 
	a rolling average of “SubTotal” for the month in the current row and the next two months after that. This moving 
	average will provide a kind of "forecast" for Subtotal by month.
*/

;WITH Monthly_Totals_CTE AS (
	SELECT MONTH(OrderDate) AS OrderMonth, YEAR(OrderDate) AS OrderYear, SUM(SubTotal) AS SubTotalsSum
	FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader
	GROUP BY YEAR(OrderDate), MONTH(OrderDate)	
)
SELECT *, 
	Rolling3MonthTotal = SUM(SubTotalsSum) OVER(ORDER BY OrderYear, OrderMonth ROWS BETWEEN 2 PRECEDING AND CURRENT ROW),
	MovingAvg6Month = AVG(SubTotalsSum) OVER(ORDER BY OrderYear, OrderMonth ROWS BETWEEN 6 PRECEDING AND 1 PRECEDING),
	MovingAvgNext2Months = AVG(SubTotalsSum) OVER(ORDER BY OrderYear, OrderMonth ROWS BETWEEN CURRENT ROW AND 2 FOLLOWING)
FROM Monthly_Totals_CTE
ORDER BY OrderYear, OrderMonth
