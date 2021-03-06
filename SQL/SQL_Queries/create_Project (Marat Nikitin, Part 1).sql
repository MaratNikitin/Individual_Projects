/* This SQL script creates the Project database on SQL Server 
* It's an individual project assignment, Part 1
* Author: Marat Nikitin
* Date: January 13, 2022
*/

USE master
GO

IF DB_ID('Project') IS NOT NULL
	DROP DATABASE Project
GO	
CREATE DATABASE Project
GO

USE Project
GO

/* Creating the Job table */
SET ANSI_NULLS ON
/* When SET ANSI_NULLS is ON, a SELECT statement that uses WHERE 
column_name = NULL returns zero rows even if there are null values 
in column_name. A SELECT statement that uses WHERE column_name <> NULL 
returns zero rows even if there are non-null values in column_name.*/
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job]
(
	[JobID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[JobName] [varchar](50) NOT NULL,
	[JobRate] [money] NOT NULL CHECK ([JobRate] > 0)
)
GO

/* Creating the Project table */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project]
(
	[ProjectID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[ProjectStartDate] [DateTime] NULL
)
GO

/* Creating the Employee table */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee]
(
	[EmployeeNo] [int] PRIMARY KEY IDENTITY(100,1) NOT NULL,
	[EmployeeFName] [varchar](50) NOT NULL,
	[EmployeeLName] [varchar](50) NOT NULL,
	[JobID] [int] NOT NULL,
	FOREIGN KEY (JobID) REFERENCES Job(JobID)
)
GO

/* Creating the ProjEmp table */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjEmp]
(
	[EmployeeNo] [int] NOT NULL,
	[ProjectID] [int]  NOT NULL,
	[HoursWorked] [int] NOT NULL DEFAULT 0,
	PRIMARY KEY (EmployeeNo, ProjectID),
	FOREIGN KEY (EmployeeNo) REFERENCES Employee(EmployeeNo),
	FOREIGN KEY (ProjectID) REFERENCES Project(ProjectID)
)
GO

-- Inserting rows into the Job table
INSERT INTO Job
(JobName, JobRate)
Values
('Project Manager', '45.00'),
('Business Analyst', '34.50'),
('Software Developer', '37.50'),
('Database Administrator', '47.50'),
('Web Designer', '33.50')
GO

-- Inserting rows into the Project table
INSERT INTO Project
(ProjectName, ProjectStartDate)
Values
('Database1', '2019-10-20'),
('Website1', '2019-12-10'),
('Website2', '2020-02-10')
GO

-- Inserting rows into the Employee table
INSERT INTO Employee
(EmployeeFName, EmployeeLName, JobID)
Values
('Bob', 'Miller', 1),
('Tara', 'Johnson', 1),
('Richard', 'Sommers', 2),
('Rebecca', 'Brown', 3),
('Tom', 'Walsh', 4),
('Carl', 'Logan', 3),
('Natasha', 'Wong', 5),
('Randy', 'Clark', 3),
('Ted', 'Colton', 3)
GO

-- Inserting rows into the ProjEmp table
INSERT INTO ProjEmp
(EmployeeNo, ProjectID, HoursWorked)
Values
(100, 1, 50), (100, 3, 75), (101, 2, 85), (102, 1, 45), 
(103, 1, 85), (103, 2, 38), (104, 1, 95), (105, 2, 75),
(105, 3, 58), (106, 2, 45), (106, 3, 39), (107, 2, 93), 
(107, 3, 64), (108, 1, 45), (108, 2, 35)
GO

-- SELECT * query for each table:
SELECT * FROM Job;
SELECT * FROM Project;
SELECT * FROM Employee;
SELECT * FROM ProjEmp;

-- SELECT query that joins all four tables as required in the task:
SELECT Employee.EmployeeNo AS EmpNo, EmployeeFName AS EmpFName,
		EmployeeLName AS EmpLName, ProjectName, 
		FORMAT(ProjectStartDate, 'dd-MM-yyyy') AS ProjStartDate, JobName AS Job, 
		FORMAT(JobRate, 'c') AS JobRate, HoursWorked AS [Hours]
FROM Job JOIN Employee ON Job.JobID = Employee.JobID
		JOIN ProjEmp ON Employee.EmployeeNo = ProjEmp.EmployeeNo
		JOIN Project ON ProjEmp.ProjectID = Project.ProjectID