-- RANK and DENSE_RANK - Exercises

/*
Exercise 1
Using your solution query to Exercise 4 from the ROW_NUMBER exercises as a staring point, add a derived column 
	called “Category Price Rank With Rank” that uses the RANK function to rank all products by ListPrice – 
	within each category - in descending order. Observe the differences between the “Category Price Rank” 
	and “Category Price Rank With Rank” fields.
*/

SELECT p.[Name] AS ProductName, 
	p.ListPrice, ps.[Name] AS ProductSubcategory, 
	pc.[Name] AS ProductCategory,
	[Price Rank] = ROW_NUMBER() OVER(ORDER BY p.ListPrice DESC),
	[Category Price Rank] = ROW_NUMBER() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
	[Category Price Rank With Rank] = RANK() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
	[Top 5 Price In Category] = CASE WHEN (ROW_NUMBER() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC) > 5) THEN 'No' ELSE 'Yes' END
FROM [AdventureWorks2019].[Production].[Product] p
	JOIN [AdventureWorks2019].[Production].[ProductSubcategory] ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	JOIN [AdventureWorks2019].[Production].[ProductCategory] pc ON pc.ProductCategoryID = ps.ProductCategoryID

/*
Exercise 2
Modify your query from Exercise 2 by adding a derived column called "Category Price Rank With Dense Rank" 
	that that uses the DENSE_RANK function to rank all products by ListPrice – within each category - in 
	descending order. Observe the differences among the “Category Price Rank”, “Category Price Rank With Rank”, 
	and “Category Price Rank With Dense Rank” fields.
*/

SELECT p.[Name] AS ProductName, 
	p.ListPrice, ps.[Name] AS ProductSubcategory, 
	pc.[Name] AS ProductCategory,
	[Price Rank] = ROW_NUMBER() OVER(ORDER BY p.ListPrice DESC),
	[Category Price Rank] = ROW_NUMBER() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
	[Category Price Rank With Rank] = RANK() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
	[Category Price Rank With Dense Rank] = DENSE_RANK() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
	[Top 5 Price In Category] = CASE WHEN (ROW_NUMBER() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC) > 5) THEN 'No' ELSE 'Yes' END
FROM [AdventureWorks2019].[Production].[Product] p
	JOIN [AdventureWorks2019].[Production].[ProductSubcategory] ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
	JOIN [AdventureWorks2019].[Production].[ProductCategory] pc ON pc.ProductCategoryID = ps.ProductCategoryID

/*
Exercise 3
Examine the code you wrote to define the “Top 5 Price In Category” field back in the ROW_NUMBER exercises. 
	Now that you understand the differences among ROW_NUMBER, RANK, and DENSE_RANK, consider which of 
	these functions would be most appropriate to return a true top 5 products by price, assuming we want 
	to see the top 5 distinct prices AND we want “ties” (by price) to all share the same rank.
*/

-- Dense_Rank is the most appropriate option for such a task:
WITH Ranks_CTE AS (
	SELECT p.[Name] AS ProductName, 
		p.ListPrice, ps.[Name] AS ProductSubcategory, 
		pc.[Name] AS ProductCategory,
		[Price Rank] = ROW_NUMBER() OVER(ORDER BY p.ListPrice DESC),
		[Category Price Rank] = ROW_NUMBER() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
		[Category Price Rank With Rank] = RANK() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
		[Category Price Rank With Dense Rank] = DENSE_RANK() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC),
		[Top 5 Price In Category] = CASE WHEN (ROW_NUMBER() OVER(PARTITION BY pc.[Name] ORDER BY p.ListPrice DESC) > 5) THEN 'No' ELSE 'Yes' END
	FROM [AdventureWorks2019].[Production].[Product] p
		JOIN [AdventureWorks2019].[Production].[ProductSubcategory] ps ON p.ProductSubcategoryID = ps.ProductSubcategoryID
		JOIN [AdventureWorks2019].[Production].[ProductCategory] pc ON pc.ProductCategoryID = ps.ProductCategoryID
)
SELECT * FROM Ranks_CTE
WHERE [Category Price Rank With Dense Rank] <= 5
