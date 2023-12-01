--Recursive CTEs - Exercises

/*
Exercise 1
Use a recursive CTE to generate a list of all odd numbers between 1 and 100.
*/

; WITH NumberSeries AS (
	SELECT 1 AS CurrentNumber

	UNION ALL

	SELECT CurrentNumber + 2
	FROM NumberSeries
	WHERE CurrentNumber < 99
)

SELECT CurrentNumber
FROM NumberSeries

/********************************************************************************************************************************/

/*
Exercise 2
Use a recursive CTE to generate a date series of all FIRST days of the month (1/1/2021, 2/1/2021, etc.)
from 1/1/2020 to 12/1/2029.
*/

; WITH DateSeries AS (
	SELECT CAST('2020-01-01' AS DATE) AS CurrentDate

	UNION ALL

	SELECT DATEADD(MONTH,1,CurrentDate)
	FROM DateSeries
	WHERE CurrentDate < '2029-12-01'
)

SELECT CurrentDate
FROM DateSeries
OPTION(MAXRECURSION 119)

