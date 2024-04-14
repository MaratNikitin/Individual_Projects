--Questions for this assignment

-- Q1. What is the median sales value for Texas (TX)?
	-- A1: $5,061,757.75

-- Q2. Which state has the lowest median sales value?
	-- A2: $4,601,677.05 / New York

-- Q3. Which city has the highest total sales among all states?
	-- A3: Mount Vernon

-- Q4. Which city has the lowest total sales among all states?
	-- A4: Middle Village

-- Q5. What is the total sales value for New York (NY)?
	-- A5: $637,460,411.60

-- Q6. What is the CityRank for Oakland in California?
	-- A6: 24.62%

;WITH base_CTE AS
(
	SELECT DISTINCT c.StateOrRegion, c.City, 
			SUM(OrderTotal) OVER (PARTITION BY c.StateOrRegion) TotalSalesPerState,
			SUM(OrderTotal) OVER (PARTITION BY  c.StateOrRegion, c.City) TotalSalesPerCity
	FROM Sales.Customer c
		JOIN Sales.[Order] o ON o.CustomerID = c.CustomerID
)

SELECT b.StateOrRegion, b.City, FORMAT(b.TotalSalesPerState, 'C2') TotalSalesPerState,
	FORMAT(b.TotalSalesPerCity, 'C2') TotalSalesPerCity,
	FORMAT(PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY b.TotalSalesPerCity) OVER (PARTITION BY b.StateOrRegion), 'C2') [MedianSalesPerState],
	FORMAT(CUME_DIST() OVER (ORDER BY b.TotalSalesPerCity DESC), 'P') [CityRank],
	FORMAT(PERCENT_RANK() OVER (PARTITION BY b.StateOrRegion ORDER BY b.TotalSalesPerCity DESC), 'P') [StateCityRank]
FROM base_CTE b
--WHERE StateOrRegion = 'CA'
ORDER BY StateOrRegion, b.TotalSalesPerCity
