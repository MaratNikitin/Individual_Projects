/* 1.	Display invoice number, invoice date and invoice total for all invoices that have total at 
least thousand dollars. Order the report by invoice total from lowest to highest.
*/
SELECT InvoiceNumber AS "Invoice Number", InvoiceDate AS "Invoice Date", InvoiceTotal AS "Invoice Total"
FROM Invoices
WHERE InvoiceTotal >=1000
ORDER BY InvoiceTotal
-- Done!

/* 2.	Display invoice number (not invoice ID), vendor ID, and invoice date for all invoices 
that belong to vendors with IDs 121, 122, and 123. First displays all invoices for vendor 121, 
then all for 122, and finally all for 123. For each vendor, display invoices in reversed 
chronological order (that is most recent invoices first).
*/
SELECT InvoiceNumber, VendorID, InvoiceDate
FROM Invoices
WHERE VendorID IN (121, 122, 123)
ORDER BY VendorID, InvoiceDate DESC
-- Done!

/* 3.	Display invoice number, vendor ID, invoice date, and invoice total for all invoices with invoice 
date during the month of October 2019. Order the report chronologically by invoice date.
*/
SELECT InvoiceNumber, VendorID, InvoiceDate, InvoiceTotal
FROM Invoices
-- WHERE InvoiceDate BETWEEN '2019-10-01' AND '2019-10-31' -- it works, but below is an alternative
WHERE InvoiceDate >='2019-10-01' AND InvoiceDate <= '2019-10-31' -- it's an alterbative
ORDER BY InvoiceDate
-- Done!

/*4.	Display vendor names that start with Ca, but not Cal
*/
SELECT DISTINCT VendorName
FROM Vendors
WHERE VendorName LIKE 'Ca%' AND VendorName NOT LIKE 'Cal%'
-- Done!

/*5.	Display all data of vendors whose zip code end with 1 and contain 9 anywhere.
*/
SELECT *
FROM Vendors
WHERE VendorZipCode LIKE '%1' AND VendorZipCode LIKE '%9%'
-- Done!

/*6.	Display all data of vendors who do not have the phone provided (the phone is null).
*/
SELECT *
FROM Vendors
WHERE VendorPhone IS null
ORDER BY VendorName
-- Done!

/*7.	Display in alphabetic order the cities where the vendors are located. Display each city only once.
*/
SELECT DISTINCT VendorCity
FROM Vendors
-- Done!

/*8.	Display all vendor’s data, for vendors who have VendorAddress1 provided, and VendorAddress2 not provided. 
*/
SELECT * 
FROM Vendors
WHERE VendorAddress1 IS NOT null AND VendorAddress2 IS NULL
-- Done!

/*9.	Display vendor name, city, state, and concatenated VedorAddress1 with VendorAddress2 for all vendors 
who have both VendorAddress1 and VendorAddress2 provided. Separate the two parts of vendor address with a comma 
and a space, and present under column title VendorAddress.
*/ 
SELECT VendorName, VendorCity, VendorState, -- VendorAddress1, VendorAddress2,
	[VendorAddress] = VendorAddress1 + ', ' + VendorAddress2
FROM Vendors
WHERE VendorAddress1 IS NOT NULL AND VendorAddress2 IS NOT NULL
-- Done!

/*10.	Display invoice number, invoice date, invoice due date, and number of days to 
the invoice (which is the due date minus the invoice date, counted in days). Name the 
calculated column DaysDue, and order the report by that column in descending order. 
(Note: pay attention that you do not get negative values in the DaysDue column.)
*/
SELECT InvoiceNumber, InvoiceDate, InvoiceDueDate, 
	[DaysDue] = DATEDIFF(day, InvoiceDate, InvoiceDueDate)
FROM Invoices
-- Done!

/* 11. Display all data of invoices that were created on a Friday 
*/
SELECT *
FROM Invoices
WHERE DATENAME(weekday, InvoiceDate) = 'Friday'
ORDER BY InvoiceDate
-- Done!

/* 12. For each invoice, calculate the difference between due date and 
invoice date (how many days to pay) 
*/
SELECT *, -- InvoiceNumber, InvoiceDate, InvoiceDueDate, 
	[DaysDue] = DATEDIFF(day, InvoiceDate, InvoiceDueDate)
FROM Invoices

/* 13. Every invoice that is paid (Paymentdate is not null) is archived 3 months 
after payment date. Display archive date for each invoice that is paid. 
*/
SELECT *, [ArchiveDate] = DATEADD(month, 3, PaymentDate)
FROM Invoices
WHERE PaymentDate IS NOT NULL
-- Done!

/* 14. Separate area code and local phone number from VendorPhone in Vendors 
*/
SELECT *, LEFT(VendorPhone, 5) AS "Area Code", [Local Phone #] = RIGHT(VendorPhone, 8)
FROM Vendors
-- Done!
