-- EXISTS - Exercises

/*
Exercise 1
Select all records from the Purchasing.PurchaseOrderHeader table such that there is at least 
one item in the order with an order quantity greater than 500. The individual items tied to 
an order can be found in the Purchasing.PurchaseOrderDetail table.
Select the following columns:
PurchaseOrderID
OrderDate
SubTotal
TaxAmt
Sort by purchase order ID.
*/

SELECT PurchaseOrderID, OrderDate, SubTotal, TaxAmt
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
WHERE EXISTS (
	SELECT 1 
	FROM AdventureWorks2019.Purchasing.PurchaseOrderDetail pod
	WHERE poh.PurchaseOrderID = pod.PurchaseOrderID 
		AND pod.OrderQty > 500
)
ORDER BY PurchaseOrderID

/****************************************************************************************************/

/*
Exercise 2
Modify your query from Exercise 1 as follows:
Select all records from the Purchasing.PurchaseOrderHeader table such that there is at least 
one item in the order with an order quantity greater than 500, AND a unit price greater than $50.00.
Select ALL columns from the Purchasing.PurchaseOrderHeader table for display in your output.
Even if you have aliased this table to enable the use of a JOIN or EXISTS, you can still use 
the SELECT * shortcut to do this. Assuming you have aliased your table "A", simply use "SELECT A.*" 
to select all columns from that table.
*/

SELECT *
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
WHERE EXISTS (
	SELECT 1 
	FROM AdventureWorks2019.Purchasing.PurchaseOrderDetail pod
	WHERE poh.PurchaseOrderID = pod.PurchaseOrderID 
		AND pod.OrderQty > 500
		AND pod.UnitPrice > 50
)
ORDER BY PurchaseOrderID


/****************************************************************************************************/

/*
Exercise 3
Select all records from the Purchasing.PurchaseOrderHeader table such that NONE of the items 
within the order have a rejected quantity greater than 0.
Select ALL columns from the Purchasing.PurchaseOrderHeader table using the "SELECT *" shortcut.
*/

SELECT *
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
WHERE NOT EXISTS (
	SELECT 1 
	FROM AdventureWorks2019.Purchasing.PurchaseOrderDetail pod
	WHERE poh.PurchaseOrderID = pod.PurchaseOrderID 
		AND pod.RejectedQty > 0
)
ORDER BY PurchaseOrderID

