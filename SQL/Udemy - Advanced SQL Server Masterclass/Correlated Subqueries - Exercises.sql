-- Correlated Subqueries - Exercises

/*
Exercise 1
Write a query that outputs all records from the Purchasing.PurchaseOrderHeader table. 
Include the following columns from the table:
PurchaseOrderID
VendorID
OrderDate
TotalDue
Add a derived column called NonRejectedItems which returns, for each purchase order ID in the query 
	output, the number of line items from the Purchasing.PurchaseOrderDetail table which did not have 
	any rejections (i.e., RejectedQty = 0). Use a correlated subquery to do this.
*/

-- The correlated subquery solution:
SELECT poh.PurchaseOrderID AS PurchaseOrderID, 
	poh.VendorID AS VendorID, 
	poh.OrderDate AS OrderDate, 
	poh.TotalDue AS TotalDue, 
	NonRejectedItems = (SELECT COUNT(*) 
						FROM AdventureWorks2019.Purchasing.PurchaseOrderDetail pod 
						WHERE poh.PurchaseOrderID = pod.PurchaseOrderID AND pod.rejectedQty = 0)
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
ORDER BY poh.PurchaseOrderID, poh.VendorID, poh.OrderDate, poh.TotalDue

/****************************************************************************************************************************************************************/

/*
Exercise 2
Modify your query to include a second derived field called MostExpensiveItem.
This field should return, for each purchase order ID, the UnitPrice of the most expensive item for that order in the Purchasing.PurchaseOrderDetail table.
Use a correlated subquery to do this as well.
Hint: Think of the most appropriate aggregate function to use in the correlated subquery for this scenario.
*/

SELECT poh.PurchaseOrderID AS PurchaseOrderID, 
	poh.VendorID AS VendorID, 
	poh.OrderDate AS OrderDate, 
	poh.TotalDue AS TotalDue, 
	NonRejectedItems = (SELECT COUNT(*) 
						FROM AdventureWorks2019.Purchasing.PurchaseOrderDetail pod 
						WHERE poh.PurchaseOrderID = pod.PurchaseOrderID AND pod.rejectedQty = 0),
	MostExpensiveItem = (SELECT MAX(UnitPrice) 
						FROM AdventureWorks2019.Purchasing.PurchaseOrderDetail pod 
						WHERE poh.PurchaseOrderID = pod.PurchaseOrderID)
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
ORDER BY poh.PurchaseOrderID, poh.VendorID, poh.OrderDate, poh.TotalDue

/****************************************************************************************************************************************************************/

-- The exercise author's suggested solution (it returns the identical result):
SELECT 
	   PurchaseOrderID
      ,VendorID
      ,OrderDate
      ,TotalDue
	  ,NonRejectedItems = 
	  (
		  SELECT
			COUNT(*)
		  FROM Purchasing.PurchaseOrderDetail B
		  WHERE A.PurchaseOrderID = B.PurchaseOrderID
		  AND B.RejectedQty = 0
	  )
	  ,MostExpensiveItem = 
	  (
		  SELECT
			MAX(B.UnitPrice)
		  FROM Purchasing.PurchaseOrderDetail B
		  WHERE A.PurchaseOrderID = B.PurchaseOrderID
	  )

FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader A
