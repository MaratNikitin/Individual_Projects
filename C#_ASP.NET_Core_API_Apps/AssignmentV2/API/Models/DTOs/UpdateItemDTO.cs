/*
 * This ASP.NET7 Web API app allows sharing items coming from a SQL Server database 
    using Entity Framework Core; full range of CRUD operations for Items is enabled.
 *  This DTO is used when updating Items.
 * Author: Marat Nikitin
 * Assignment
 * When: March 2023
 */

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class UpdateItemDTO : BaseItemDTO
    {
        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
    }
}
