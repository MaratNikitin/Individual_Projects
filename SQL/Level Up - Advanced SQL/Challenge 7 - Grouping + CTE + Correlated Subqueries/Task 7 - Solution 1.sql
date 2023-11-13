-- Create a report with sales per employee for each month in 2021:
SELECT firstName, lastName, title, strftime('%m-%Y', soldDate) AS MonthYear,
	COUNT(salesId) AS NumberOfCarsSold
FROM employee
	JOIN sales ON employee.employeeId = sales.employeeId
WHERE strftime('%Y', soldDate) = '2021'
GROUP BY firstName, lastName, title, strftime('%m %Y', soldDate)
ORDER BY firstName, lastName, MonthYear