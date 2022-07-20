/*
 * This ASP.NET Core MVC app creates two pages used for tracking borrowed items and a list of expences allowing full range of CRUD
 *      operations using a created (Code First) SQL Server database. This app is inspired by a Udemy ASP.NET course.
 * Author: Marat Nikitin.
 * When: January 2022.
 * This file is used to access DB data.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }
}
