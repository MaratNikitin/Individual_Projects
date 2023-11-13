-- Create a report showing the monthly number of cars sold
WITH monthly_car_sales_cte AS (
	SELECT strftime('%Y-%m', soldDate) AS SalesMonth,
		COUNT(*) AS NumberOfCarsSold,
		DATE(MIN(soldDate),'start of month','-1 month') AS PreviousMonthStart
	FROM sales
	GROUP BY strftime('%Y-%m', soldDate)
	ORDER BY SalesMonth
)

SELECT SalesMonth, NumberOfCarsSold 
	, LAG(NumberOfCarsSold,1,0) OVER () AS NumberOfCarsSoldLastMonth
FROM monthly_car_sales_cte ext_cte