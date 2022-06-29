/* 
 * This solution contains a .NET 6 REST API, class library and SQL Server database with Dapper for connection.
 * The REST API allows full range of CRUD operations for the User table of the DB.
 * This solution was inspired by Tim Corey's "Minimal API in .NET 6 Using Dapper and SQL" lesson, part of self-study.
 * When: June 2022.
 * Author: Marat Nikitin.
 * This class inside a separate class library project describes a user entity of the DB.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
