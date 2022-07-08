/*
 * This app is built based on Udemy's Blazor Learning course, part of the self-study.
 *      It allows a full range of CRUD operations with a SQL Server DB and demonstrates Javascript integrations
 *      into the Blazor Server projects.
 * Author: Marat Nikitin.
 * When: July 2022.
 * This file contains the Category class representing the Category entity of the SQL Server DB.
 */

using System.ComponentModel.DataAnnotations;

namespace DataAccessClassLibrary
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
