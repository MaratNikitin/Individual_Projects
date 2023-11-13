-- Create a report with sales per employee for each month in 2021:
WITH Sales_CTE AS (
	SELECT employee.employeeId, firstName, lastName, strftime('%m %Y', soldDate) AS MonthYear, 
		SUM(salesAmount) AS MonthlyTotal
	FROM employee
		LEFT JOIN sales ON employee.employeeId = sales.employeeId
	WHERE strftime('%Y', soldDate) = '2021'
	GROUP BY firstName, lastName, strftime('%m %Y', soldDate)
)

SELECT firstName, lastName, 
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '01 2021') AS JanSales, 
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '02 2021') AS FebSales, 
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '03 2021') AS MarSales, 
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '04 2021') AS AprSales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '05 2021') AS MaySales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '06 2021') AS JunSales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '07 2021') AS JulSales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '08 2021') AS AugSales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '09 2021') AS SepSales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '10 2021') AS OctSales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '11 2021') AS NovSales,
	(SELECT SUM(MonthlyTotal)FROM Sales_CTE int_CTE WHERE int_CTE.employeeId = ext_CTE.employeeId AND int_CTE.MonthYear = '12 2021') AS DecSales
FROM Sales_CTE ext_CTE
GROUP BY firstName, lastName
ORDER BY lastName

