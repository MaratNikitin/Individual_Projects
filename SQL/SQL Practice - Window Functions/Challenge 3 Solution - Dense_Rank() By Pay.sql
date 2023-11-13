SELECT FirstName, LastName,
    WeeklyPay, Department,
    DENSE_RANK() OVER(PARTITION BY Department ORDER BY WeeklyPay DESC) AS DeptRank
FROM Employees
ORDER BY Department, DeptRank