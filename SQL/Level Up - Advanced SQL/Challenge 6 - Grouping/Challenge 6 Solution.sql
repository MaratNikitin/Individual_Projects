-- Create a report showing the total sales per year
SELECT strftime('%Y', soldDate) AS CalendarYear, 
	ROUND(SUM(salesAmount),2) AS TotalSales
FROM sales
GROUP BY strftime('%Y', soldDate)