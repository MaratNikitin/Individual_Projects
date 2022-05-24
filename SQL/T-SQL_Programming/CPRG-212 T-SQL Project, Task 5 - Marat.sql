/* 
CPRG-212 Course, Part 3 - T-SQL, SAIT, OOSD program, March 2, 2022, Author: Marat Nikitin

Task 5.	
Write a script that produces the following report: 
For each instructor, display one line with InstructorID, last name, first name,
how many courses the instructor teaches, and a note that is defined as follows:
•	“On leave”, when instructor teaches no courses, 
•	“Available for another course”, when instructor teaches only one course, and
•	Nothing otherwise
Instructors table contains data about instructors, and each course in the Courses
table references InstructorID of an instructor who teaches the course.
The structure of the script is totally up to you, as long as it displays the 
desired report.
*/

USE College;
GO
 
SELECT Instructors.InstructorID, LastName, FirstName, 
		COUNT(CourseID)	AS NumberOfCourses,
		CASE WHEN COUNT(CourseID)=0 THEN 'On leave'
			WHEN COUNT(CourseID)=1 THEN 'Available for another course'
			ELSE '' END AS Note
FROM Instructors LEFT JOIN Courses 
		ON Instructors.InstructorID = Courses.InstructorID
GROUP BY Instructors.InstructorID, LastName, FirstName