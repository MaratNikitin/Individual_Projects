/*
CPRG-212 Course, Part 3 - T-SQL, SAIT, OOSD program, March 2, 2022, Author: Marat Nikitin

Task 1.	Create a stored procedure named spInsertDepartment that takes as a parameter
a value for the department name and adds a new row into the Departments table. 
•	Even thoughDepartments table allows null department name, validate that 
department name is provided and is not an empty string. Throw an error with 
message “Department name must be provided” if incorrect.
•	Department namehas to be unique. The procedure should throw an errorwith 
message “Department name must be unique” upon attempt to insert a department 
with a name that is already in the table.
Code three tests executing this procedure:1) with null or empty department 
name, 2) with a unique department name, and 3) with a duplicate department name. 
*/

USE College;
GO
 
IF OBJECT_ID('spInsertDepartment') IS NOT NULL
    DROP PROC spInsertDepartment;
GO

CREATE OR ALTER PROC spInsertDepartment
    @DepartmentName			VARCHAR(40) = NULL
AS
BEGIN TRY
	-- Validating presence of DepartmentName:
	IF @DepartmentName IS NULL OR @DepartmentName = ''
		THROW 50007, 'Department name must be provided', 1;

	-- Validating uniqueness of DepartmentName
	IF @DepartmentName IN (SELECT DepartmentName FROM Departments)
		THROW 50007, 'Department name must be unique', 1;

	-- All basic validation was successfully passed, time to insert a row:
	INSERT INTO Departments
	VALUES (@DepartmentName);
		PRINT 'Success! One row was inserted.';
END TRY
BEGIN CATCH
PRINT 'An error occurred. Row was not inserted.';
    PRINT 'Error number: ' +
        CONVERT(varchar, ERROR_NUMBER());
    PRINT 'Error message: ' +
        CONVERT(varchar, ERROR_MESSAGE());
END CATCH;
GO -- End of the procedure


-- It's a legitimate insert operation that inserts the row:
EXEC spInsertDepartment 'Research & Development' 

-- Checking changes in the DB after successful Insert operation:		 
SELECT * FROM Departments
ORDER BY DepartmentID
    
-- Trying to insert duplicate category name:
EXEC spInsertDepartment 'Business' 			

-- Trying to insert empty string category name:
EXEC spInsertDepartment '' 	

-- Trying to insert NULL category name:
EXEC spInsertDepartment NULL 	

-- End of task 1