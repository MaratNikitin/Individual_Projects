/* 
CPRG-212 Course, Part 3 - T-SQL, SAIT, OOSD program, March 2, 2022, Author: Marat Nikitin

Task 4.	Create a trigger named InstructorInsertSalaryTR that fires when a new row is added 
to the Instructors table.
Throw an error when multiple rows are inserted.
When there is only one row inserted, validate that the AnnualSalary value is positive 
(strictly greater than zero) and less than or equal to 120000. Throw an error with 
appropriate message if the salary value is negative or too big. 
Also, if the salary value is between 0 and 10000, assume that there was a mistake of 
entering monthly salary instead of annual salary, and multiply thesalary value by 12. 
For example, if the new value of the salary is 5000, it should be changed to 60000. 
No need to validate any other data from the inserted row.
Test the trigger with appropriate INSERT statements. There should be four cases: 
1) with negative salary, 2) with positive salary <= 10000, 3) with salary greater 
than 10000 and less than or equal to 120000, and 4) with salary > 120000.
*/

USE College;
GO
 
IF OBJECT_ID('InstructorInsertSalaryTR') IS NOT NULL
    DROP TRIGGER InstructorInsertSalaryTR;
GO

-- Creating the trigger:
CREATE OR ALTER TRIGGER InstructorInsertSalaryTR
    ON Instructors
	AFTER INSERT
AS
BEGIN TRY
BEGIN TRANSACTION
	-- Throwing an error when multiple rows are inserted:
		-- LastName is required in the DB, therefore, we can count by it:
	IF (SELECT COUNT(LastName) FROM Inserted) > 1
		THROW 50007, 'Please insert 1 row only', 1;

	-- Validating that the AnnualSalary value is positive 
		-- (strictly greater than zero) and less than or equal to 120000: 
	IF (SELECT AnnualSalary FROM Inserted) <= 0 
		OR (SELECT AnnualSalary FROM Inserted) > 120000 
		THROW 50007, 'AnnualSalary must be $0-120K!', 1;

	-- if the salary value is between 0 and 10000, assume that there was a mistake of 
		-- entering monthly salary instead of annual salary, and multiply the 
			-- salary value by 12:
	IF (SELECT AnnualSalary FROM Inserted) > 0 
		AND (SELECT AnnualSalary FROM Inserted) <= 10000
		BEGIN
			UPDATE Instructors
			SET AnnualSalary = 12 * (SELECT AnnualSalary FROM Inserted)
			WHERE InstructorID = (SELECT InstructorID FROM Inserted);
			-- Feedback/warning to a user about magic happening behind the scenes: 
			PRINT 'Trigger was fired and the inserted AnnualSalary value was multiplied by 12'
		END
COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	PRINT 'Error ' + CONVERT(VARCHAR, Error_Number()) + ': ' + Error_Message();
	PRINT 'The InstructorInsertSalaryTR trigger was executed:'
	PRINT 'Transaction was rolled back - row insert was cancelled.'
END CATCH;
GO -- End of the trigger

-- Testing:

-- 1. Trying to insert negative salary (does not work):
INSERT INTO Instructors(LastName, FirstName, Status, DepartmentChairman, HireDate,
							AnnualSalary, DepartmentID)
VALUES ('Hendrix', 'James', 'F', '0', '2022-03-02', '-70000', '1')
GO 

-- 2. Trying to insert positive salary 5000 <= 10000:
INSERT INTO Instructors(LastName, FirstName, Status, DepartmentChairman, HireDate,
							AnnualSalary, DepartmentID)
VALUES ('Brown', 'Sara', 'F', '0', '2022-03-02', '5000', '1')
GO 

-- 3. Inserting legitimate values with salary 10K-120K (trigger does not change anything):
INSERT INTO Instructors(LastName, FirstName, Status, DepartmentChairman, HireDate,
							AnnualSalary, DepartmentID)
VALUES ('Doe', 'John', 'F', '0', '2022-03-02', '70000', '1')
GO 

-- 4. Trying to insert salary >120K (trigger does not allow it):
INSERT INTO Instructors(LastName, FirstName, Status, DepartmentChairman, HireDate,
							AnnualSalary, DepartmentID)
VALUES ('Monroe', 'Frank', 'F', '0', '2022-03-02', '121000', '1')
GO 

-- Seeing the freshly added rows: 
SELECT * FROM Instructors
WHERE InstructorID > 15

-- Deleting added rows from the database:
DELETE FROM Instructors
WHERE InstructorID > 16