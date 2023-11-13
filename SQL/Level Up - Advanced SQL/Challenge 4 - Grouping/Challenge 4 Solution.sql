-- Create a report that lists the least and most expensive car sold by each employee sold this year (2023):
SELECT firstName, lastName, title, 
	MIN(salesAmount) AS LeastExpensiveCarSold, 
	MAX(salesAmount) AS MostExpensiveCarSold,
	COUNT(*) AS NumberOfCarsSold
FROM employee
	JOIN sales ON employee.employeeId = sales.employeeId
WHERE strftime('%Y', soldDate) = strftime('%Y', DATE('now'))
GROUP BY employee.employeeId
ORDER BY lastName