SELECT Name
FROM AdventureWorks2019.Purchasing.Vendor
WHERE Name LIKE 'C%'
	AND (Name LIKE '%Bike%' OR Name LIKE '%Bicycle%')