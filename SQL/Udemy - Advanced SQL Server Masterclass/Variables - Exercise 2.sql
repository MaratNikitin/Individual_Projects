-- Variables - Exercise 2

/*
Exercise
Let's say your company pays once per month, on the 15th.
If it's already the 15th of the current month (or later), the previous pay period will run from the 15th 
of the previous month, to the 14th of the current month.
If on the other hand it's not yet the 15th of the current month, the previous pay period will run from the
15th two months ago to the 14th on the previous month.
Set up variables defining the beginning and end of the previous pay period in this scenario. Select the variables 
to ensure they are working properly.
*/

DECLARE @CurrentDate DATE,
	@BeginningOfPreviousPayPeriod DATE,
	@EndOfPreviousPayPeriod DATE,
	@FifteenthOfCurrentMonth DATE,
	@PrintText VARCHAR(255)

SET @CurrentDate = CAST(GETDATE() AS DATE)
--SET @CurrentDate = CAST('2023-01-15' AS DATE) -- This line is for testing different dates.

SET @FifteenthOfCurrentMonth = DATEFROMPARTS(YEAR(@CurrentDate),MONTH(@CurrentDate),15)

SET @BeginningOfPreviousPayPeriod = 
	CASE 
		WHEN DAY(@CurrentDate) >= 15 THEN DATEADD(MONTH,-1,@FifteenthOfCurrentMonth)
		ELSE DATEADD(MONTH,-2,@FifteenthOfCurrentMonth)
	END

SET @EndOfPreviousPayPeriod = DATEADD(MONTH,1,@BeginningOfPreviousPayPeriod)
SET @EndOfPreviousPayPeriod = DATEADD(DAY,-1,@EndOfPreviousPayPeriod)


PRINT('For the current date of ' + CAST(@CurrentDate AS VARCHAR) + ':')
PRINT('Start of the previous pay period: ' + CAST(@BeginningOfPreviousPayPeriod AS VARCHAR) + ';')
PRINT('End of the previous pay period: ' + CAST(@EndOfPreviousPayPeriod AS VARCHAR) + '.')
