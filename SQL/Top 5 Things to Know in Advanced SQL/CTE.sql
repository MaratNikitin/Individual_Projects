/*
Challenge 2: create a CTE
Use Inventory table and return:
- ProdCategory, ProdNumber, ProdName, In Stock of items that have less that the average amount of products left in stock
*/

;WITH AverageInStockCTE (AVGInStock) AS (
	SELECT AVG([In Stock]) AS AVG_In_Stock FROM [Red30Tech].[dbo].[Inventory]
)

SELECT [ProdCategory], [ProdNumber], [ProdName], [In Stock]
FROM [Red30Tech].[dbo].[Inventory], AverageInStockCTE
WHERE [In Stock] < AVGInStock
ORDER BY [In Stock] DESC