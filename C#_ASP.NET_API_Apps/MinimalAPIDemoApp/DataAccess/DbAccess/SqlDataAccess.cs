/* 
 * This solution contains a .NET 6 REST API, class library and SQL Server database with Dapper for connection.
 * The REST API allows full range of CRUD operations for the User table of the DB.
 * This solution was inspired by Tim Corey's "Minimal API in .NET 6 Using Dapper and SQL" lesson, part of self-study.
 * When: June 2022.
 * Author: Marat Nikitin.
 * This file fascilitates connection to the SQL Server database (inner project inside this solution)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess // interface was extracted from this class
{
    private readonly IConfiguration _config;
    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "Default") // appsettings.json contains a connection string named "Default"
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure); // appropriate stored procedure is executed
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Default")
    {
        // this "using" ensures that connection is automatically closed when we leave this block:
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure); // appropriate stored procedure is executed
    }
}
