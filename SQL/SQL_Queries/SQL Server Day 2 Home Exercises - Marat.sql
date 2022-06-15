/* 
SQL Server - Day 2 Home Exercises
Author: Marat Nikitin
SAIT, OOSD Fast-Track Program
When: January 2022
*/

/*
1.	For invoices that have PaymentDate later than InvoiceDueDate, display invoice number,
terms id, terms description, terms due days, and difference in days between payment date 
and invoice due date (call it DaysOverDue).
*/
SELECT Invoices.InvoiceNumber, Invoices.TermsID, Terms.TermsDescription, 
	Terms.TermsDueDays, -- Invoices.InvoiceDueDate, Invoices.PaymentDate,
	[DaysOverDue] = DATEDIFF(day, Invoices.InvoiceDueDate, Invoices.PaymentDate)
FROM Invoices INNER JOIN Terms ON Invoices.TermsID = Terms.TermsID
WHERE DATEDIFF(day, Invoices.InvoiceDueDate, Invoices.PaymentDate) > 0
ORDER BY DaysOverDue
-- Done!

/*
2. Some vendor contact names are to be updated. Table ContactUpdates contains VendorId 
and new LastName and FirstName of the contact person for vendors that need their contact 
updated. Write a query that verifies that all these updates indeed change either first 
name or last name of the contact person. Specifically, display vendor id, vendor name, 
vendor contact last name and first name, and the new last name and first name for that 
vendor from ContactUpdates, but list only these entries where either the last name is 
different from vendor contact last name or first name is different from vendor contact 
first name.
*/
SELECT Vendors.VendorID, Vendors.VendorName, 
		Vendors.VendorContactLName, ContactUpdates.LastName,
		Vendors.VendorContactFName, ContactUpdates.FirstName
FROM Vendors INNER JOIN ContactUpdates ON Vendors.VendorID = ContactUpdates.VendorID
WHERE (NOT Vendors.VendorContactLName = ContactUpdates.LastName) OR
		(NOT Vendors.VendorContactFName = ContactUpdates.FirstName)
-- Done!

/*
3.	Display details of invoice with Invoice ID = 12. Include: InvoiceID, InvoiceNumber, 
VendorName, InvoiceDate and for the items from the invoice lines: line number 
(InvoiceSequence), line amount, and description. Order by the line numbers. Hint: 
you need to join three tables.
*/
SELECT Invoices.InvoiceID, 
		Invoices.InvoiceNumber, 
		Vendors.VendorName,
		Invoices.InvoiceDate, 
		InvoiceLineItems.InvoiceSequence,
		InvoiceLineItems.InvoiceLineItemAmount, 
		InvoiceLineItems.InvoiceLineItemDescription
FROM Invoices INNER JOIN Vendors ON Vendors.VendorID = Invoices.VendorID
	INNER JOIN InvoiceLineItems ON Invoices.InvoiceID = InvoiceLineItems.InvoiceID
WHERE Invoices.InvoiceID = 12
ORDER BY InvoiceLineItems.InvoiceSequence
-- Done!

/*
4.	InvoiceLineItems refers to AcountNo in GLAccounts. Display account numbers and 
descriptions, together with sum of InvoiceLineItemAmount values over all invoice 
line items that refer to the particular account. Your report should include all 
accounts, also those that are not referred to by any invoice line items (in other
words, some of the amount sums will be NULL). Order by AccountNo.
*/
SELECT  GLAccounts.AccountNo, 
		GLAccounts.AccountDescription, 
		SUM(InvoiceLineItems.InvoiceLineItemAmount) AS "SumOfInvoiceAmounts"
FROM GLAccounts LEFT JOIN InvoiceLineItems 
	ON GLAccounts.AccountNo = InvoiceLineItems.AccountNo
GROUP BY GLAccounts.AccountNo, GLAccounts.AccountDescription
ORDER BY GLAccounts.AccountNo
-- Done!

/*
-- This query below was used to check the correctness of the answer above
SELECT GLAccounts.AccountNo,  
		InvoiceLineItems.InvoiceLineItemAmount
FROM GLAccounts LEFT JOIN InvoiceLineItems 
	ON GLAccounts.AccountNo = InvoiceLineItems.AccountNo
-- WHERE
ORDER BY GLAccounts.AccountNo
*/

/*
5.	Same as the previous question, but display only the accounts that have the sum 
of InvoiceLineItemAmount values greater than 1000.
*/
SELECT  GLAccounts.AccountNo, 
		GLAccounts.AccountDescription, 
		SUM(InvoiceLineItems.InvoiceLineItemAmount) AS "SumOfInvoiceAmounts"
FROM GLAccounts LEFT JOIN InvoiceLineItems 
	ON GLAccounts.AccountNo = InvoiceLineItems.AccountNo
GROUP BY GLAccounts.AccountNo, GLAccounts.AccountDescription
HAVING SUM(InvoiceLineItems.InvoiceLineItemAmount) > 1000
ORDER BY GLAccounts.AccountNo
-- Done!

/*
6.	Display account numbers and descriptions of all accounts that are NOT referred 
to by any invoice line item.
*/
SELECT GLAccounts.AccountNo,
		GLAccounts.AccountDescription
		,InvoiceLineItems.InvoiceLineItemAmount
FROM GLAccounts LEFT JOIN InvoiceLineItems 
				ON GLAccounts.AccountNo = InvoiceLineItems.AccountNo
WHERE InvoiceLineItemAmount IS NULL
ORDER BY GLAccounts.AccountNo
-- Done!

/*
7.	Display account number and description for GL account that is referred 
the largest number of times from invoice line items.
*/
SELECT GLAccounts.AccountNo, GLAccounts.AccountDescription, 
		COUNT(InvoiceLineItems.InvoiceID) AS [InvoicesCount]
FROM GLAccounts JOIN InvoiceLineItems 
				ON GLAccounts.AccountNo = InvoiceLineItems.AccountNo
GROUP BY GLAccounts.AccountNo, GLAccounts.AccountDescription
HAVING COUNT(InvoiceLineItems.InvoiceID) >= 
			ALL(SELECT COUNT(InvoiceLineItems.InvoiceID) 
				FROM GLAccounts JOIN InvoiceLineItems 
				ON GLAccounts.AccountNo = InvoiceLineItems.AccountNo
				GROUP BY GLAccounts.AccountNo)
-- Done!

/*
8.	For each city, display name of the vendor who has the highest sum of invoice 
totals. Include the sum of invoice totals for that vendor.
*/
SELECT Vend_Main.VendorCity, Vend_Main.VendorState, 
		Vend_Main.VendorName AS [City Champion Vendor's Name],
		SUM(InvoiceTotal) AS [Sum Of Invoice Totals]
FROM Vendors AS Vend_Main
		JOIN Invoices AS Inv_Main ON Vend_Main.VendorID = Inv_Main.VendorID
GROUP BY Vend_Main.VendorCity, Vend_Main.VendorState, Vend_Main.VendorName
HAVING SUM(InvoiceTotal) >= 
		ALL(SELECT SUM(InvoiceTotal)
			FROM Vendors AS Vend_Sub
				JOIN Invoices AS Inv_Sub ON Vend_Sub.VendorID = Inv_Sub.VendorID
			WHERE Vend_Sub.VendorCity = Vend_Main.VendorCity
				AND Vend_Sub.VendorState = Vend_Main.VendorState)
ORDER BY Vend_Main.VendorCity, Vend_Main.VendorState
-- Done!

-- This query is for testing the correctness of the main query
SELECT VendorCity, VendorState, VendorName,
		SUM(InvoiceTotal) AS [Sum Of Invoice Totals]
FROM Vendors 
		JOIN Invoices ON Vendors.VendorID = Invoices.VendorID
GROUP BY VendorCity, VendorState, VendorName
ORDER BY VendorCity, VendorState




-- Jolanta's solution
-- which vendor has the largest number of invoices for vendors in the same city/state

select outerVen.VendorID, outerVen.VendorCity, outerVen.VendorState,
       count(InvoiceID) as InvoiceCount
from Invoices outerInv join Vendors outerVen on outerInv.VendorID = outerVen.VendorID
group by outerVen.VendorID, outerVen.VendorCity, outerVen.VendorState
having count(InvoiceID) >= all (select count(InvoiceID) 
                               from Invoices join Vendors on Invoices.VendorID = Vendors.VendorID
							   where VendorCity = outerVen.VendorCity
							     and VendorState = outerVen.VendorState
							   group by Invoices.VendorID)
order by outerVen.VendorCity, outerVen.VendorState

-- check it
select Vendors.VendorID, VendorCity, VendorState, count(InvoiceID)
from Invoices join Vendors on Invoices.VendorID = Vendors.VendorID
group by Vendors.VendorID, VendorCity, VendorState
order by VendorCity, VendorState


-- question 8 answered from Nigel:
select outerVen.VendorID, outerVen.VendorCity, outerVen.VendorState,
SUM(InvoiceTotal) as InvoiceSum
from Invoices outerInv join Vendors outerVen on outerInv.VendorID = outerVen.VendorID
group by outerVen.VendorID, outerVen.VendorCity, outerVen.VendorState
having SUM(InvoiceTotal) >= all (select SUM(InvoiceTotal)
from Invoices join Vendors on Invoices.VendorID = Vendors.VendorID
where VendorCity = outerVen.VendorCity
and VendorState = outerVen.VendorState
group by Invoices.VendorID)
ORDER BY InvoiceSum DESC