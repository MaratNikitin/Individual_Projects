-- Display a count of the number of products in each category
SELECT ProductCategory.Name AS [Category Name]
    , COUNT(Product.ProductID) AS [Number of Products]
FROM Production.ProductCategory
    INNER JOIN Production.ProductSubcategory
        ON ProductCategory.ProductCategoryID = ProductSubcategory.ProductCategoryID
    INNER JOIN Production.Product
        ON ProductSubcategory.ProductSubcategoryID = Product.ProductSubcategoryID
GROUP BY ProductCategory.Name;

-- Create a pivot table version of the above results
SELECT 'Number of Products' AS 'Category Name',
		Accessories,
		Bikes,
		Clothing,
		Components
FROM (SELECT ProductCategory.Name
			, Product.ProductID
		FROM Production.ProductCategory
			INNER JOIN Production.ProductSubcategory
				ON ProductCategory.ProductCategoryID = ProductSubcategory.ProductCategoryID
			INNER JOIN Production.Product
				ON ProductSubcategory.ProductSubcategoryID = Product.ProductSubcategoryID
		) AS SourceData
PIVOT (COUNT(ProductID) FOR Name IN (Accessories,Bikes,Clothing,Components)) AS PivotTable

