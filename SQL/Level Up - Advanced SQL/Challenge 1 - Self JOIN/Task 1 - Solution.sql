SELECT emp.firstName AS [EmployeeFirstName],
	emp.lastName AS [EmployeeLastName],
	emp.title AS [EmployeeTitle],
	man.firstName AS [ManagerFirstName],
	man.lastName AS [ManagerLastName]
FROM employee emp
	JOIN employee man ON emp.managerId = man.employeeId