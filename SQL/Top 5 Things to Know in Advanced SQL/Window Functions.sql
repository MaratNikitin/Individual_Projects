-- Write a query to return each custimer's most recent order
;WITH Orders_CTE AS (
SELECT CustName, OrderDate, ROW_NUMBER() OVER(PARTITION BY CustName ORDER BY OrderDate DESC) AS OrderRow
FROM [Red30Tech].[dbo].[OnlineRetailSales]
--ORDER BY CustName
)
SELECT CustName, OrderDate
FROM Orders_CTE
WHERE OrderRow = 1

/******************************************************************************************************************/

/* Challenge 3. Write a query using ROW_NUMBER(0 that returns:
	- OrderNum
	- OrderDate
	- CustName
	- ProdCategory
	- ProdName
	- OrderTotal
	for the three orders with the highest Order Totals 
	from each ProdCategory purchased by Boehm Inc.
*/

;WITH orders_cte AS (
	SELECT TOP (1000) [OrderNum],[OrderDate],[OrderType],[CustName],[ProdCategory],[ProdName],[Order Total],
		  ROW_NUMBER() OVER(PARTITION BY ProdCategory ORDER BY [Order Total] DESC) AS RankNumber
	FROM [Red30Tech].[dbo].[OnlineRetailSales]
	WHERE CustName = 'Boehm Inc.'
)

SELECT * FROM orders_cte
WHERE RankNumber <= 3

/******************************************************************************************************************/

/* Write a query using LAG() and LEAD() to show the session name and start time of the previous Red30Tech session 
	conducted in Room 102 as well as what the next session will be.
*/

SELECT TOP (1000) [Start Date]
      ,[End Date]
      ,[Session Name],
	  LAG([Session Name],1) OVER(ORDER BY [Start Date]) AS PreviousSessionName,
	  LAG([Start Date],1) OVER(ORDER BY [Start Date]) AS PreviousSessionStartDate,
	  LEAD([Session Name],1) OVER(ORDER BY [Start Date]) AS NextSessionName,
	  LEAD([Start Date],1) OVER(ORDER BY [Start Date]) AS NextSessionStartDate
  FROM [Red30Tech].[dbo].[SessionInfo]
  WHERE [Room Name] = 'Room 102'
  ORDER BY [Start Date]


/******************************************************************************************************************/

/*
Write a query that returns:
	- OrderDate,
	- Quantity,
	- Total quantity from the last five orders
	for each drone order from the OnlineRetailSales order
*/

SELECT [OrderDate], [Quantity], 
	SUM(Quantity) OVER(ORDER BY OrderDate ROWS BETWEEN 4 PRECEDING AND CURRENT ROW) AS TotalOfTheLastFiveOrders
  FROM [Red30Tech].[dbo].[OnlineRetailSales]
  WHERE [ProdCategory] = 'Drones'
  ORDER BY OrderDate

/******************************************************************************************************************/

/* Write a query using RANK() and DENSE_RANK() that ranks employees in alphabetical order by their last name */
SELECT [Last Name], [First Name],[Title],[Department],[Email],
	RANK() OVER(ORDER BY [Last Name]) AS EmployeeRankByLastName,
	DENSE_RANK() OVER(ORDER BY [Last Name]) AS EmployeeDenseRankByLastName
FROM [Red30Tech].[dbo].[EmployeeDirectory]

/******************************************************************************************************************/

/* Write a query that returns the registration information for the first three conference attendees that registered from each state. */

;WITH RegistrationtRanksCTE AS (
	SELECT [Registration Date],[First name],[Last name],[State],
		RANK() OVER(PARTITION BY [State] ORDER BY [Registration Date]) AS RegistrationRank,
		DENSE_RANK() OVER(PARTITION BY [State] ORDER BY [Registration Date]) AS RegistrationDenseRank
	FROM [Red30Tech].[dbo].[ConventionAttendees]
)
SELECT * FROM RegistrationtRanksCTE
WHERE RegistrationRank <= 3
ORDER BY State