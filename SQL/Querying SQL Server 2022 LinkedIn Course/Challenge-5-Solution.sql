-- 1: Using the Production.ProductInventory table, 
--    combine the LocationID, Shelf, and Bin values 
--    into a single column with hyphens between each.

SELECT CONCAT_WS('-',LocationID,Shelf,Bin) AS ComplexKey --, *
FROM Production.ProductInventory

-- 2: Using the HumanResources.Employee table,
--    Locate all of the people hired in February of any year.
--    Then identify the date that their 90 day new hire 
--    performance evaluation is due

SELECT Employee.BusinessEntityID,
	CONCAT_WS(' ',FirstName,MiddleName,LastName) AS EmployeeName, 
	NationalIDNumber, JobTitle, HireDate, 
	DATEADD(DAY, 90, HireDate) AS '90 Days Evaluation Due'
FROM HumanResources.Employee
	JOIN Person.Person ON Person.BusinessEntityID = Employee.BusinessEntityID
WHERE MONTH(HireDate) = 2


-- 3: View CreditRating information for each vendor in the 
--    Purchasing.Vendor table.  Then use a CASE statement to 
--    translate the 1 - 5 credit rating into the text ratings:
--    poor, below average, average, good, excellent

SELECT BusinessEntityID, [Name] AS VendorName, CreditRating
		,CASE CreditRating 
			WHEN 1 THEN 'Poor'
			WHEN 2 THEN 'Below Average'
			WHEN 3 THEN 'Average'
			WHEN 4 THEN 'Good'
			WHEN 5 THEN 'Excellent'
		END AS CreditRatingDescription
FROM Purchasing.Vendor
ORDER BY CreditRating DESC

-- 4: Select three random people from Sales.SalesPerson.
--    Then use an IIF function to compare their SalesYTD 
--    to the SalesLastYear and indicate whether their 
--    performance has increased or decreased

SELECT TOP 3 BusinessEntityID, SalesYTD, SalesLastYear,
	IIF(SalesYTD > SalesLastYear, 'Sales Increased', 'Sales Decreased') AS SalesPerformance
FROM Sales.SalesPerson
ORDER BY NEWID()
