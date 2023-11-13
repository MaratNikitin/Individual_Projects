SELECT EmployeeID, Department, 
    Position, WeeklyPay,
    SUM(WeeklyPay) OVER(PARTITION BY Department) AS DeptTotal
FROM Employees
ORDER BY Department, WeeklyPay