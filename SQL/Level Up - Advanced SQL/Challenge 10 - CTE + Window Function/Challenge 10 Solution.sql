-- Generate a sales report showing total sales per month and an annual running total
WITH monthly_sales_CTE AS (
	SELECT strftime('%Y', soldDate) AS SaleYear, 
		strftime('%m', soldDate) AS SaleMonth,
		SUM(salesAmount) AS MonthlySalesTotal
	FROM sales
	GROUP BY strftime('%Y', soldDate), strftime('%m', soldDate)
)

SELECT SaleYear, SaleMonth, MonthlySalesTotal, 
	SUM(MonthlySalesTotal) OVER(PARTITION BY SaleYear ORDER BY SaleMonth) AS AnnualSalesRunningTotal
FROM monthly_sales_CTE