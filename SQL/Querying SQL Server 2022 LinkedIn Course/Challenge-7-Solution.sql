DECLARE @numberOfRowsToReturn INT = 6,
		@startingBusinessEntityID INT = 25
SELECT TOP (@numberOfRowsToReturn) * 
FROM AdventureWorks2019.Person.Person
WHERE BusinessEntityID >= @startingBusinessEntityID