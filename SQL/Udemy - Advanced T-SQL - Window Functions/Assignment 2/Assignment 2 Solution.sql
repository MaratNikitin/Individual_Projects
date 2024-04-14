-- Q1.How many years have we been selling to customers from the Czech Republic?
	-- Answer: 5

-- Q2.What is the running total for Germany in 2012?
	-- Answer: 4432.23

-- Q3.What is the running total for Portugal in 2011?
	-- Answer: 1051.57

-- Q4.Which country has the highest percentage of sales in 2009?
	-- Answer: USA

-- Q5.Which country has the lowest percentage of sales in 2011?
	-- Answer: Argentina

-- Q6.Which country has the second-best performance in 2009, 2010, 2011, and 2013?
	-- Answer: Canada


-- Questions 1-3 can be answered by the query below:
; WITH SalesByCountry_CTE AS
(
	SELECT BillingCountry AS Country, YEAR(InvoiceDate) AS [Year], 
		SUM(InvoiceTotal) AS AnnualCountrySales
	FROM [Chinook].[dbo].[Invoice]
	GROUP BY BillingCountry, YEAR(InvoiceDate)
) 

SELECT Country, [Year], 
	TotalYearsActive = COUNT(*) OVER(PARTITION BY Country),
	AnnualCountrySales,
	RunningTotal = SUM(AnnualCountrySales) OVER(PARTITION BY Country ORDER BY [Year])
FROM SalesByCountry_CTE

/***************************************************************************************/

-- Questions 4-6 can be answered by the query below:
; WITH SalesByCountry_CTE AS
(
	SELECT BillingCountry AS Country, YEAR(InvoiceDate) AS [Year], 
		SUM(InvoiceTotal) AS AnnualCountrySales
	FROM [Chinook].[dbo].[Invoice]
	GROUP BY BillingCountry, YEAR(InvoiceDate)
) 
, SalesByCountryWithRunningTotals_CTE AS
(
	SELECT [Year], Country, 
		TotalYearsActive = COUNT(*) OVER(PARTITION BY Country),
		AnnualCountrySales,
		RunningTotal = SUM(AnnualCountrySales) OVER(PARTITION BY Country ORDER BY [Year]),
		AnnualSales = SUM(AnnualCountrySales) OVER(PARTITION BY [Year])
	FROM SalesByCountry_CTE
)
SELECT [Year], Country, AnnualCountrySales, AnnualSales,
	[%AnnualCountrySales] = FORMAT(AnnualCountrySales / AnnualSales, 'P2')
FROM SalesByCountryWithRunningTotals_CTE

