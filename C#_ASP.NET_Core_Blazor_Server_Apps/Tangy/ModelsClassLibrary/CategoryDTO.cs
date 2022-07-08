/*
 * This app is built based on Udemy's Blazor Learning course, part of the self-study.
 *      It allows a full range of CRUD operations with a SQL Server DB and demonstrates Javascript integrations
 *      into the Blazor Server projects.
 * Author: Marat Nikitin.
 * When: July 2022.
 * This file contains the CategoryDTO which is used for interactions with the DB hiding part of the DB data.
 */

using System.ComponentModel.DataAnnotations;


namespace ModelsClassLibrary
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }           
    }
}
