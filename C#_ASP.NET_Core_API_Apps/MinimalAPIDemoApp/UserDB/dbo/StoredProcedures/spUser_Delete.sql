/* 
 * This solution contains a .NET 6 REST API, class library and SQL Server database with Dapper for connection.
 * The REST API allows full range of CRUD operations for the User table of the DB.
 * This solution was inspired by Tim Corey's "Minimal API in .NET 6 Using Dapper and SQL" lesson, part of self-study.
 * When: June 2022.
 * Author: Marat Nikitin.
 * This is a stored DB procedure for deleting a user with a specified ID from the User table of the SQL Server DB.
 */

CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM dbo.[User]
	WHERE Id = @Id;
END