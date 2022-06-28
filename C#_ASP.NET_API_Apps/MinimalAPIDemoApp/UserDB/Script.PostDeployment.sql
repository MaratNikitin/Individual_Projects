/* 
 * This solution contains a .NET 6 REST API, class library and SQL Server database with Dapper for connection.
 * The REST API allows full range of CRUD operations for the User table of the DB.
 * This solution was inspired by Tim Corey's "Minimal API in .NET 6 Using Dapper and SQL" lesson, part of self-study.
 * When: June 2022.
 * Author: Marat Nikitin.
 * This script is executed only once and populates the "User" table of the inner SQL Server DB with data.
 */

IF NOT EXISTS (SELECT 1 FROM dbo.[User])
BEGIN
	INSERT INTO dbo.[User] (FirstName,LastName)
	VALUES ('John', 'Doe'),
		('Jane', 'Doe'),
		('Sue', 'Storm'),
		('John', 'Smith'),
		('Mary', 'Jones');
END
