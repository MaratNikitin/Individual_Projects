/* Write a query that uses a scalar subquery to identify orders where Order Total is higher than 
	the average total price of all other orders */
SELECT *
FROM [Red30Tech].[dbo].[OnlineRetailSales]
WHERE [Order Total] > (SELECT AVG([Order Total]) 
						FROM [Red30Tech].[dbo].[OnlineRetailSales])
ORDER BY [Order Total]


/*
Challenge 1: create a subquery
Use Inventory table and return:
- ProdCategory, ProdNumber, ProdName, In Stock of items that have less that the average amount of products left in stock
*/

SELECT [ProdCategory], [ProdNumber], [ProdName], [In Stock]
FROM [Red30Tech].[dbo].[Inventory]
WHERE [In Stock] < (SELECT AVG([In Stock]) FROM [Red30Tech].[dbo].[Inventory])
ORDER BY [In Stock] DESC