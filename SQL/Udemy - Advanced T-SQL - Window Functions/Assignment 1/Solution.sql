-- Q1: 4 customer agents will receive a bonus of 65% (CustomerRatingGroup1)
-- Q2: 3 customer agents will receive a bonus of 20% (CustomerRatingGroup2)
-- Q3: Sasha Lopez will receive 35% of Bonus, which is $5703.75 for the Bonus, and the Total Salary of $14478.75

; WITH CustomerGroups_CTE AS
(
	SELECT *,
		CustomerRatingGroup = NTILE(4) OVER (ORDER BY CustomerRating DESC)
	FROM [Chinook].[dbo].[Employees]
)

SELECT *,
	BonusPercent = CASE WHEN CustomerRatingGroup = 1 THEN 65
						WHEN CustomerRatingGroup = 2 THEN 50
						WHEN CustomerRatingGroup = 3 THEN 35
						WHEN CustomerRatingGroup = 4 THEN 20
					END,

	BonusAmount = CASE  WHEN CustomerRatingGroup = 1 THEN BaseSalary * 0.65
						WHEN CustomerRatingGroup = 2 THEN BaseSalary * 0.5
						WHEN CustomerRatingGroup = 3 THEN BaseSalary * 0.35
						WHEN CustomerRatingGroup = 4 THEN BaseSalary * 0.2
					END,

	TotalSalary = CASE  WHEN CustomerRatingGroup = 1 THEN BaseSalary * 1.65
						WHEN CustomerRatingGroup = 2 THEN BaseSalary * 0.5
						WHEN CustomerRatingGroup = 3 THEN BaseSalary * 0.35
						WHEN CustomerRatingGroup = 4 THEN BaseSalary * 0.2
					END
FROM CustomerGroups_CTE
GO

-- Q4: Alfred Smith would receive $8437.5 if the bonus was calculated based on the internal rating:
; WITH CustomerGroups_CTE AS
(
	SELECT *,
		CustomerRatingGroup = NTILE(4) OVER (ORDER BY InternalRating DESC)
	FROM [Chinook].[dbo].[Employees]
)

SELECT *,
	BonusPercent = CASE WHEN CustomerRatingGroup = 1 THEN 65
						WHEN CustomerRatingGroup = 2 THEN 50
						WHEN CustomerRatingGroup = 3 THEN 35
						WHEN CustomerRatingGroup = 4 THEN 20
					END,

	BonusAmount = CASE  WHEN CustomerRatingGroup = 1 THEN BaseSalary * 0.65
						WHEN CustomerRatingGroup = 2 THEN BaseSalary * 0.5
						WHEN CustomerRatingGroup = 3 THEN BaseSalary * 0.35
						WHEN CustomerRatingGroup = 4 THEN BaseSalary * 0.2
					END,

	TotalSalary = CASE  WHEN CustomerRatingGroup = 1 THEN BaseSalary * 1.65
						WHEN CustomerRatingGroup = 2 THEN BaseSalary * 1.5
						WHEN CustomerRatingGroup = 3 THEN BaseSalary * 1.35
						WHEN CustomerRatingGroup = 4 THEN BaseSalary * 1.2
					END
FROM CustomerGroups_CTE


-- Q5: 8 employees out of 15 will receive a bonus of 50% in this scenario:
; WITH CustomerGroups_CTE AS
(
	SELECT *,
		CustomerRatingGroup = NTILE(2) OVER (ORDER BY InternalRating DESC)
	FROM [Chinook].[dbo].[Employees]
)

SELECT *,
	BonusPercent = CASE WHEN CustomerRatingGroup = 1 THEN 50
						WHEN CustomerRatingGroup = 2 THEN 25
					END,

	BonusAmount = CASE  WHEN CustomerRatingGroup = 1 THEN BaseSalary * 0.5
						WHEN CustomerRatingGroup = 2 THEN BaseSalary * 0.25
					END,

	TotalSalary = CASE  WHEN CustomerRatingGroup = 1 THEN BaseSalary * 1.5
						WHEN CustomerRatingGroup = 2 THEN BaseSalary * 1.25
					END
FROM CustomerGroups_CTE


GO

-- Q6: 6 CustomerRating values (3 of them are unique) appear multiple times
;WITH CustomerRatingRanks_CTE AS
(
	SELECT *, 
		RowNumber = ROW_NUMBER() OVER(PARTITION BY CustomerRating ORDER BY CustomerRating)
	FROM [Chinook].[dbo].[Employees]
)

SELECT * 
FROM CustomerRatingRanks_CTE
WHERE CustomerRating IN (SELECT CustomerRating FROM CustomerRatingRanks_CTE WHERE RowNumber = 2)
