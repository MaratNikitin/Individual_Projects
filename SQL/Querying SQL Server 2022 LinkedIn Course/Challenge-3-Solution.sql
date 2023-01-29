--SELECT TOP 5 * FROM Person.Address
--SELECT TOP 5 * FROM Person.StateProvince
--SELECT TOP 5 * FROM Person.CountryRegion

SELECT AddressID, AddressLine1, AddressLine2, City, 
	StateProvince.[Name] AS [State/Province Name], 
	CountryRegion.[Name] AS 'Country Name'--, * 
FROM Person.[Address] 
	JOIN Person.StateProvince ON [Address].StateProvinceID = StateProvince.StateProvinceID
	JOIN Person.CountryRegion ON StateProvince.CountryRegionCode = CountryRegion.CountryRegionCode
ORDER BY AddressID
	