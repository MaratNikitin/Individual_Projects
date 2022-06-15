/*
Use database MyGuitarShop
Write a script  that prints a report of all the products 
(IDs, codes, and names from Products),  their quantity sold 
(sum of Quantity in OrderItems for the given product), and a comment:
“Very popular” – when quantity sold is 10 or more
“Unpopular” – when quantity sold is less than or equal 3
Nothing otherwise
*/

USE MyGuitarShop;
GO

-- Everything asked is here:
SELECT  Products.ProductID,	ProductCode, ProductName,
		SUM(Quantity) as QuantitySold,
		CASE WHEN SUM(Quantity)>=10 THEN 'Very Popular'
			WHEN SUM(Quantity)<10 AND SUM(Quantity)>=3 THEN ''
			ELSE 'Unpopular' END AS Comment
FROM Products JOIN OrderItems 
	ON Products.ProductID = OrderItems.ProductID
GROUP BY Products.ProductID, ProductCode, ProductName
