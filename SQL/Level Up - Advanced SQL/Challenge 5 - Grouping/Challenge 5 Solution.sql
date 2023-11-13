-- Create a list of employees with more than 5 sales this year (2023):
SELECT firstName, lastName, title, 
	COUNT(salesId) AS NumberOfCarsSold
FROM employee
	JOIN sales ON employee.employeeId = sales.employeeId
WHERE strftime('%Y', soldDate) = strftime('%Y', DATE('now'))
GROUP BY employee.employeeId
HAVING COUNT(*) > 5
ORDER BY lastName