--SELECT TOP 10 * FROM Sales.SalesOrderHeader
--SELECT TOP 10 * FROM Person.Person

SELECT CustomerID, 
		Person.FirstName + ' ' + Person.LastName AS CustomerName,
		SUM(TotalDue) AS TotalAmountSpent,
		MIN(TotalDue) AS MinAmountSpent,
		MAX(TotalDue) AS MaxAmountSpent,
		AVG(TotalDue) AS AverageAmountSpent
FROM Sales.SalesOrderHeader 
	JOIN Person.Person ON SalesOrderHeader.CustomerID = Person.BusinessEntityID
GROUP BY CustomerID, FirstName, LastName
ORDER BY TotalAmountSpent DESC