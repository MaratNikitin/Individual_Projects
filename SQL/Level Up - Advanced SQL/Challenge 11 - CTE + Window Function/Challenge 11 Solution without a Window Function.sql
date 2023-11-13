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
	,IFNULL((SELECT NumberOfCarsSold 
		FROM monthly_car_sales_cte int_cte 
		WHERE int_cte.PreviousMonthStart = DATE(ext_cte.PreviousMonthStart,'-1 month')),0) 
		AS NumberOfCarsLastMonth
FROM monthly_car_sales_cte ext_cte