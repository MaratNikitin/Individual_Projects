/* 
 * This solution contains a .NET 6 REST API, class library and SQL Server database with Dapper for connection.
 * The REST API allows full range of CRUD operations for the User table of the DB.
 * This solution was inspired by Tim Corey's "Minimal API in .NET 6 Using Dapper and SQL" lesson, part of self-study.
 * When: June 2022.
 * Author: Marat Nikitin.
 * This file with an interface was created by extracting interface from the SqlDataAccess class.
 */

namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
}
