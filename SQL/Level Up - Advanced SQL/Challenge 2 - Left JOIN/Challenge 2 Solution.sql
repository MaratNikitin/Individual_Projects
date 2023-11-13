-- Find sales people with zero sales.
SELECT firstName, lastName, title
FROM employee
	LEFT JOIN sales ON employee.employeeId = sales.employeeId
WHERE salesId IS NULL
	AND employee.title = 'Sales Person'