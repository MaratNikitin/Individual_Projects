SELECT WorkOrderID AS [Work Order ID],
		ScrappedQty AS [Scrapped Quantity],
		StartDate AS [Start Date],
		EndDate AS [End Date]
FROM AdventureWorks2019.Production.WorkOrder
WHERE ScrappedQty > 0
	AND StartDate >= '2013-12-01' 
	AND EndDate <= '2013-12-31'
ORDER BY ScrappedQty DESC