-- LEAD and LAG - Exercises

/*
Exercise 1
Create a query with the following columns:
“PurchaseOrderID” from the Purchasing.PurchaseOrderHeader table
“OrderDate” from the Purchasing.PurchaseOrderHeader table
“TotalDue” from the Purchasing.PurchaseOrderHeader table
“Name” from the Purchasing.Vendor table, which can be aliased as “VendorName”*
Apply the following criteria to the query:
Order must have taken place on or after 2013
TotalDue must be greater than $500
*/

SELECT poh.PurchaseOrderID, poh.OrderDate, poh.TotalDue, v.[Name] AS VendorName  
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
	JOIN AdventureWorks2019.Purchasing.Vendor v ON v.BusinessEntityID = poh.VendorID
WHERE poh.OrderDate >= '2013-01-01'
	AND poh.TotalDue > 500

/*********************************************************************************************************/

/*
Exercise 2
Modify your query from Exercise 1 by adding a derived column called
"PrevOrderFromVendorAmt", that returns the “previous” TotalDue value (relative to the current row) 
	within the group of all orders with the same vendor ID. We are defining “previous” based on 
	order date.
*/

SELECT poh.PurchaseOrderID, poh.OrderDate, v.[Name] AS VendorName, poh.TotalDue, 
	PrevOrderFromVendorAmt = LAG(poh.TotalDue,1) OVER(PARTITION BY poh.VendorID ORDER BY OrderDate)
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
	JOIN AdventureWorks2019.Purchasing.Vendor v ON v.BusinessEntityID = poh.VendorID
WHERE poh.OrderDate >= '2013-01-01'
	AND poh.TotalDue > 500
ORDER BY VendorName, poh.OrderDate

/*********************************************************************************************************/

/*
Exercise 3
Modify your query from Exercise 2 by adding a derived column called
"NextOrderByEmployeeVendor", that returns the “next” vendor name (the “name” field from Purchasing.Vendor) 
	within the group of all orders that have the same EmployeeID value in Purchasing.PurchaseOrderHeader. 
	Similar to the last exercise, we are defining “next” based on order date.
*/

SELECT poh.EmployeeID, poh.PurchaseOrderID, poh.OrderDate, v.[Name] AS VendorName,  
	NextOrderByEmployeeVendor = LEAD(v.[Name],1) OVER(PARTITION BY EmployeeID ORDER BY OrderDate),
	poh.TotalDue,
	PrevOrderFromVendorAmt = LAG(poh.TotalDue,1) OVER(PARTITION BY poh.VendorID ORDER BY OrderDate)
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
	JOIN AdventureWorks2019.Purchasing.Vendor v ON v.BusinessEntityID = poh.VendorID
WHERE poh.OrderDate >= '2013-01-01'
	AND poh.TotalDue > 500
ORDER BY EmployeeID, poh.OrderDate

/*********************************************************************************************************/

/*
Exercise 4
Modify your query from Exercise 3 by adding a derived column called "Next2OrderByEmployeeVendor" that 
	returns, within the group of all orders that have the same EmployeeID, the vendor name offset TWO 
	orders into the “future” relative to the order in the current row. The code should be very similar 
	to Exercise 3, but with an extra argument passed to the Window Function used.
*/

SELECT poh.EmployeeID, poh.PurchaseOrderID, poh.OrderDate, v.[Name] AS VendorName,  
	NextOrderByEmployeeVendor = LEAD(v.[Name],1) OVER(PARTITION BY EmployeeID ORDER BY OrderDate),
	Next2OrderByEmployeeVendor = LEAD(v.[Name],2) OVER(PARTITION BY EmployeeID ORDER BY OrderDate),
	poh.TotalDue,
	PrevOrderFromVendorAmt = LAG(poh.TotalDue,1) OVER(PARTITION BY poh.VendorID ORDER BY OrderDate)
FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader poh
	JOIN AdventureWorks2019.Purchasing.Vendor v ON v.BusinessEntityID = poh.VendorID
WHERE poh.OrderDate >= '2013-01-01'
	AND poh.TotalDue > 500
ORDER BY EmployeeID, poh.OrderDate

/*********************************************************************************************************/

-- The exercise author's suggested solution:
SELECT 
	   PurchaseOrderID
      ,OrderDate
      ,TotalDue
	  ,VendorName = B.Name
	  ,PrevOrderFromVendorAmt = LAG(A.TotalDue) OVER(PARTITION BY A.VendorID ORDER BY A.OrderDate)
	  ,NextOrderByEmployeeVendor = LEAD(B.Name) OVER(PARTITION BY A.EmployeeID ORDER BY A.OrderDate)
	  ,Next2OrderByEmployeeVendor = LEAD(B.Name,2) OVER(PARTITION BY A.EmployeeID ORDER BY A.OrderDate)

  FROM AdventureWorks2019.Purchasing.PurchaseOrderHeader A
  JOIN AdventureWorks2019.Purchasing.Vendor B
    ON A.VendorID = B.BusinessEntityID

  WHERE YEAR(A.OrderDate) >= 2013
	AND A.TotalDue > 500

  ORDER BY 
  A.EmployeeID,
  A.OrderDate