-- PARTITION BY - Exercises

/*Exercise 1
Create a query with the following columns:
“Name” from the Production.Product table, which can be alised as “ProductName”
“ListPrice” from the Production.Product table
“Name” from the Production.ProductSubcategory table, which can be alised as “ProductSubcategory”*
“Name” from the Production.ProductCategory table, which can be alised as “ProductCategory”**

All the tables can be inner joined, and you do not need to apply any criteria.
*/
--SELECT TOP 5 * FROM [AdventureWorks2019].[Production].[Product] p
--SELECT TOP 5 * FROM [AdventureWorks2019].[Production].[ProductCategory] pc
--SELECT TOP 5 * FROM [AdventureWorks2019].[Production].[ProductSubcategory] ps

SELECT p.[Name] AS ProductName, 
	p.ListPrice, ps.[Name] AS ProductionSubcategory, 
	pc.[Name] AS ProductionCategory   
FROM [AdventureWorks2019].[Production].[Product] p
	JOIN [AdventureWorks2019].[Production].[ProductSubcategory] ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	JOIN [AdventureWorks2019].[Production].[ProductCategory] pc ON pc.ProductCategoryID = ps.ProductCategoryID 

/*
Exercise 2
Enhance your query from Exercise 1 by adding a derived column called
"AvgPriceByCategory " that returns the average ListPrice for the product category in each given row.
*/

SELECT p.[Name] AS ProductName, 
	p.ListPrice, ps.[Name] AS ProductionSubcategory, 
	pc.[Name] AS ProductionCategory,
	AVG(p.ListPrice) OVER(PARTITION BY pc.[Name]) AS AvgPriceByCategory
FROM [AdventureWorks2019].[Production].[Product] p
	JOIN [AdventureWorks2019].[Production].[ProductSubcategory] ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	JOIN [AdventureWorks2019].[Production].[ProductCategory] pc ON pc.ProductCategoryID = ps.ProductCategoryID 


/*
Exercise 3
Enhance your query from Exercise 2 by adding a derived column called
"AvgPriceByCategoryAndSubcategory" that returns the average ListPrice for the product category AND subcategory in each given row.
*/

SELECT p.[Name] AS ProductName, 
	p.ListPrice, ps.[Name] AS ProductionSubcategory, 
	pc.[Name] AS ProductionCategory,
	AVG(p.ListPrice) OVER(PARTITION BY pc.[Name]) AS AvgPriceByCategory,
	AVG(p.ListPrice) OVER(PARTITION BY pc.[Name], ps.[Name]) AS AvgPriceByCategoryAndSubcategory
FROM [AdventureWorks2019].[Production].[Product] p
	JOIN [AdventureWorks2019].[Production].[ProductSubcategory] ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	JOIN [AdventureWorks2019].[Production].[ProductCategory] pc ON pc.ProductCategoryID = ps.ProductCategoryID 


/*
Exercise 4:
Enhance your query from Exercise 3 by adding a derived column called
"ProductVsCategoryDelta" that returns the result of the following calculation:
A product's list price, MINUS the average ListPrice for that product’s category.
*/

SELECT p.[Name] AS ProductName, 
	p.ListPrice, ps.[Name] AS ProductionSubcategory, 
	pc.[Name] AS ProductionCategory,
	AVG(p.ListPrice) OVER(PARTITION BY pc.[Name]) AS AvgPriceByCategory,
	AVG(p.ListPrice) OVER(PARTITION BY pc.[Name], ps.[Name]) AS AvgPriceByCategoryAndSubcategory,
	(p.ListPrice - (AVG(p.ListPrice) OVER(PARTITION BY pc.[Name]))) AS ProductVsCategoryDelta
FROM [AdventureWorks2019].[Production].[Product] p
	JOIN [AdventureWorks2019].[Production].[ProductSubcategory] ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	JOIN [AdventureWorks2019].[Production].[ProductCategory] pc ON pc.ProductCategoryID = ps.ProductCategoryID 


-- Author's suggested solution: 
SELECT 
  ProductName = A.Name,
  A.ListPrice,
  ProductSubcategory = B.Name,
  ProductCategory = C.Name,
  AvgPriceByCategory = AVG(A.ListPrice) OVER(PARTITION BY C.Name),
  AvgPriceByCategoryAndSubcategory = AVG(A.ListPrice) OVER(PARTITION BY C.Name, B.Name),
  ProductVsCategoryDelta = A.ListPrice - AVG(A.ListPrice) OVER(PARTITION BY C.Name)

FROM AdventureWorks2019.Production.Product A
  JOIN AdventureWorks2019.Production.ProductSubcategory B
    ON A.ProductSubcategoryID = B.ProductSubcategoryID
  JOIN AdventureWorks2019.Production.ProductCategory C
    ON B.ProductCategoryID = C.ProductCategoryID