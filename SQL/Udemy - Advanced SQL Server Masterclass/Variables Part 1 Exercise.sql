--Variables - Exercise 1

/*
Exercise
Refactor the provided code (see the "Variables Part 1 - Exercise Starter Code.sql" 
in the Resources for this section) to utilize variables instead of embedded scalar subqueries.
*/

--Starter code:
SELECT
	   BusinessEntityID
      ,JobTitle
      ,VacationHours
	  ,MaxVacationHours = (SELECT MAX(VacationHours) FROM AdventureWorks2019.HumanResources.Employee)
	  ,PercentOfMaxVacationHours = (VacationHours * 1.0) / (SELECT MAX(VacationHours) FROM AdventureWorks2019.HumanResources.Employee)

FROM AdventureWorks2019.HumanResources.Employee

WHERE (VacationHours * 1.0) / (SELECT MAX(VacationHours) FROM AdventureWorks2019.HumanResources.Employee) >= 0.8

/************************************************************************************************************************************************/

-- My solution:
DECLARE @MaxVacationHours MONEY
SET @MaxVacationHours = (SELECT MAX(VacationHours) FROM AdventureWorks2019.HumanResources.Employee)

SELECT
	   BusinessEntityID
      ,JobTitle
      ,VacationHours
	  ,MaxVacationHours = @MaxVacationHours
	  ,PercentOfMaxVacationHours = FORMAT((VacationHours * 1.0) / @MaxVacationHours,'N4')
	FROM AdventureWorks2019.HumanResources.Employee
	WHERE (VacationHours * 1.0) / (SELECT MAX(VacationHours) FROM AdventureWorks2019.HumanResources.Employee) >= 0.8
