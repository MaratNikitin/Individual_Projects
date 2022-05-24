/* 
CPRG-212 Course, Part 3 - T-SQL, SAIT, OOSD program, March 2, 2022, Author: Marat Nikitin

Task 2.	Create a function named fnStudentUnits that calculates the sum of 
course units of a student. This function accepts one parameter, the student
ID, and returns an integer value that is the sum of the course units for 
the student. You can find courses that the student takes in StudentCourses 
table, and CourseUnits for each course in the Courses tables.
If the student does not exist or has no courses, this function should return 0.
Code three tests: 1)for a student who has courses, 2) for student who does 
not have courses, and 3) a non-existing studentID. For each test,display 
the value of the student ID that was passed to the function and the result
returned by the function. Also, run a supportive SELECT query or queries 
that prove the test results are correct.
*/

USE College;
GO
IF OBJECT_ID('fnStudentUnits') IS NOT NULL
	DROP FUNCTION fnStudentUnits;
GO 

CREATE OR ALTER FUNCTION fnStudentUnits(@StudentID INT)
	RETURNS INT
AS
BEGIN
	DECLARE @Result INT
	-- Checking first if a given StudentID exists:
	IF (SELECT StudentID FROM Students WHERE StudentID = @StudentID) IS NULL
		SET @Result = 0 -- returning 0 for a non-existing StudentID
	ELSE -- it means that the given StudentID exists (this side works
			-- both for students with courses and without courses)
		BEGIN		
			SELECT @Result = SUM(Courses.CourseUnits)
			FROM Students JOIN StudentCourses 
				ON Students.StudentID = StudentCourses.StudentID
				JOIN Courses
				ON Courses.CourseID = StudentCourses.CourseID
			WHERE Students.StudentID = @StudentID
		END
		IF @Result IS NULL -- It means this student does not have courses
			SET @Result = 0 -- Assigning 0 units to students without courses
	RETURN @Result
END
GO

-- Supportive query to prove that test results are correct
 -- Among StudentID = 1, 5, 999 only StudentID = 5 has courses, 
 -- StudentID = 1 exists but doesn't have courses, S
SELECT Students.StudentID,  Courses.CourseID, Courses.CourseUnits
FROM Students JOIN StudentCourses 
				ON Students.StudentID = StudentCourses.StudentID
			JOIN Courses
				ON Courses.CourseID = StudentCourses.CourseID
WHERE Students.StudentID IN (5, 1, 999)


-- Testing function on a StudentID = 5 (this student has 13 courses):
PRINT 'Number of course units for student with StudentID = 5 is ' + 
		CONVERT(VARCHAR, dbo.fnStudentUnits('5'));
GO

-- Testing function on a StudentID = 1 (this student does not have courses):
PRINT 'Number of course units for student with StudentID = 1 is ' + 
		CONVERT(VARCHAR, dbo.fnStudentUnits('1'));
GO


-- Testing function on a StudentID = 999 (this StudentID does not exist):
PRINT 'Number of course units for student with StudentID = 999 is ' + 
		CONVERT(VARCHAR, dbo.fnStudentUnits('999'));
GO

-- End of Task 2
----------------------------------------------------------------------------------------------

/*
Task 3.	Create a function named fnTuition that calculates the tuition for a student. 
This function accepts one parameter, the student ID, and it calls the 
fnStudentUnits function that you created in task 2. The tuition value for the
student calculated according to the following pseudocode:
if(student does not exist) or (student units = 0)
   tuition = 0
else if (student units >= 9)
   tuition = (full time cost) +(student units) * (per unit cost)
else 
   tuition = (part time cost) +(student units) * (per unit cost)
Retrieve values ofFullTimeCost, PartTimeCost, and PerUnitCost from table Tuition.
Jolanta clarified in the chat, that the function should return 0!
Code two tests: 1) a student who has <9 student units, and 2) for a 
student who has >= 9 student units. For each test, display StudentID 
and the result returned by the function. Also, run supportive SELECT 
query or queries that prove the results to be correct.
*/

USE College;
GO
IF OBJECT_ID('fnTuition') IS NOT NULL
	DROP FUNCTION fnTuition;
GO 

CREATE OR ALTER FUNCTION fnTuition(@StudentID INT)
	RETURNS MONEY
AS
BEGIN
	DECLARE @Tuition MONEY
	-- Checking first if a given StudentID exists using task 2 function:
	IF (dbo.fnStudentUnits(@StudentID) = 0)
	-- the task 2 function returns 0 both for non-existing StudentIDs 
		-- and students without courses, for all of them Tuition = 0:
		SET @Tuition = 0 
	ELSE -- it means that the given StudentID exists (this side works
			-- both for students with courses and without courses)
		BEGIN		
			IF (dbo.fnStudentUnits(@StudentID) >= 9) -- it's full-time
				SELECT @Tuition = (SELECT FullTimeCost FROM Tuition) + 
					dbo.fnStudentUnits(@StudentID)*(SELECT PerUnitCost FROM Tuition)
			ELSE -- it's part time
				SELECT @Tuition = (SELECT PartTimeCost FROM Tuition) + 
					dbo.fnStudentUnits(@StudentID)*(SELECT PerUnitCost FROM Tuition)
		END
		IF @Tuition IS NULL -- It means this student does not have courses
			SET @Tuition = 0 -- Assigning 0 units to students without courses
	RETURN @Tuition
END
GO

-- Testing function on a StudentID = 5 (this full-time student has 13 units):
PRINT 'Tuition for the student with StudentID = 5 (full time, 13 units) is $' + 
		CONVERT(VARCHAR, dbo.fnTuition('5'));
GO

-- Testing function on a StudentID = 10 (this part-time student has 7 units):
PRINT 'Tuition for the student with StudentID = 10 (part-time, 7 units) is $' + 
		CONVERT(VARCHAR, dbo.fnTuition('10'));
GO

-- Testing function on a StudentID = 1 (exists, bot no units):
PRINT 'Tuition for the student with StudentID = 1 (no units) is $' + 
		CONVERT(VARCHAR, dbo.fnTuition('1'));
GO

-- Testing function on a StudentID = 999 (does not exist):
PRINT 'Tuition for the student with StudentID = 999 (does not exist) is $' + 
		CONVERT(VARCHAR, dbo.fnTuition('999'));
GO

-- Supportive SELECT query for testing the results (all needed values are displayed, so that the 
	-- result can be easily tested checked a calculator: 1250+62.5*13 = 2062.5 & 750+62.5*7=1187.5):
SELECT StudentCourses.StudentID,  
		CASE WHEN (SUM(Courses.CourseUnits) >= 9)
				THEN CONCAT('Full-Time Fee: $', (SELECT FullTimeCost FROM Tuition))
		ELSE CONCAT('Part-Time Fee: $', (SELECT PartTimeCost FROM Tuition)) END AS CommentOnFee,
		(SELECT PerUnitCost FROM Tuition) AS PerUnitCost,
		SUM(Courses.CourseUnits) AS CourseUnits#,
		CASE WHEN (SUM(Courses.CourseUnits) >= 9)
			THEN (SELECT FullTimeCost FROM Tuition)+(SELECT PerUnitCost FROM Tuition)*SUM(Courses.CourseUnits)
		ELSE (SELECT PartTimeCost FROM Tuition)+(SELECT PerUnitCost FROM Tuition)*SUM(Courses.CourseUnits) 
		END AS Tuition
FROM StudentCourses JOIN Courses
				ON Courses.CourseID = StudentCourses.CourseID
WHERE StudentCourses.StudentID IN (5, 10, 1, 999)
GROUP BY StudentCourses.StudentID