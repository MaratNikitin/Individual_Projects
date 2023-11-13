-- Create a report that totals the number of cars sold by each employee
SELECT firstName, lastName, title, COUNT(salesId) AS NumberOfCarsSold
FROM employee
	LEFT JOIN sales ON employee.employeeId = sales.employeeId
GROUP BY firstName, lastName, title
ORDER BY NumberOfCarsSold DESC